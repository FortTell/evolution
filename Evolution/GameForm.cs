using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Evolution
{
    class GameForm : Form
    {
        Game game;
        Label l;
        Random rnd = new Random();
        int tickCount = 0;
        Dictionary<Type, List<Bitmap>> creatureImages;
        
        public GameForm()
        {
            Height = 600;
            Width = 800;
            Text = "Evolution";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            game = new Game();

            var creatureTypes = GetCreatureTypes();
            InitializeUI(creatureTypes);
            FillCreatureImageDict(creatureTypes);

            var timer = new Timer();
            timer.Interval = 100;
            timer.Tick += (sender, args) => TimerTick();
            timer.Start();
        }

        private void InitializeUI(List<Type> creatureTypes)
        {
            Menu = new MainMenu();
            var spawner = new MenuItem("Spawn a creature");
            foreach (var type in creatureTypes)
            {
                var item = new MenuItem(type.Name);
                item.Click += (sender, args) =>
                {
                    var ctor = type.GetConstructor(new Type[] { typeof(int), typeof(int) });
                    var creature = (ICreature)ctor.Invoke(
                        new object[] { rnd.Next(Size.Width - 64), rnd.Next(Size.Height - 64) });
                    game.creatures.Add(creature);
                    Invalidate();
                };
                spawner.MenuItems.Add(item);
            }
            Menu.MenuItems.Add(spawner);
        }

        private void FillCreatureImageDict(List<Type> creatureTypes)
        {
            creatureImages = new Dictionary<Type, List<Bitmap>>();
            foreach (var type in creatureTypes)
            {
                creatureImages.Add(type, new List<Bitmap>());
                var name = type.Name.ToLower();
                for (int i = 1; i <= 8; i++) 
                //possible inconsistency: image lists are left small if no pictures (and then take i % list.Count)
                //while CrAnims should be padded to 8 items(or more, but longer lists are useless) or else. <- And nobody even knows that beforehand.
                {
                    var filename = @"Gfx\" + name + i + ".png";
                    if (File.Exists(filename))
                        creatureImages[type].Add(new Bitmap(filename));
                    else 
                        break;
                }
            }
        }

        private List<Type> GetCreatureTypes()
        {
            var ass = System.Reflection.Assembly.GetEntryAssembly();
            return ass.GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(ICreature)))
                .ToList();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            game.HandleKeyPress(e.KeyChar.ToString());
            Invalidate();
            base.OnKeyPress(e);
        }

        void TimerTick()
        {
            if (tickCount == 0)
                foreach (var c in game.creatures)
                    c.SetCurrentAnim();
            foreach (var c in game.creatures)
                c.Location = new Point { 
                    X = c.Location.X + c.currentAnim[tickCount].dx, 
                    Y = c.Location.Y + c.currentAnim[tickCount].dy 
                };
            if (tickCount == 7)
            {
                //handle collisions
            }
            tickCount++;
            if (tickCount == 8) 
                tickCount = 0;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            foreach (var c in game.creatures)
            {
                var imgList = creatureImages[c.GetType()];
                g.DrawImage(imgList[tickCount % imgList.Count], c.Location);
            }
            base.OnPaint(e);
        }
    }
}
