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
        string pressedKey = "";
        Dictionary<Type, List<Bitmap>> creatureImages;
        Dictionary<Type, Bitmap> mapObjImages;

        public GameForm()
        {
            Height = 600;
            Width = 800;
            Text = "Evolution";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.DoubleBuffered = true;

            StartGame();

            var creatureTypes = Util.GetTypesInheritedFrom(typeof(Creature));
            InitializeUI(creatureTypes);
            creatureImages = FillCreatureImageDict(creatureTypes);

            var mapObjTypes = Util.GetTypesInheritedFrom(typeof(MapObject));
            mapObjImages = FillMapObjImageDict(mapObjTypes);

            var timer = new Timer();
            timer.Interval = 100;
            timer.Tick += (sender, args) => TimerTick();
            timer.Start();
        }

        private void StartGame()
        {
            string filename = @"Levels\levelList.txt";
            if (File.Exists(filename))
            {
                var levels = File.ReadAllLines(filename);
                game = Game.LoadLevelFromFile(@"Levels\" + levels[0]);
            }
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
                    var creature = (Creature)ctor.Invoke(
                        new object[] { rnd.Next(Size.Width - 64), rnd.Next(Size.Height - 64) });
                    game.creatures.Add(creature);
                    Invalidate();
                };
                spawner.MenuItems.Add(item);
            }
            Menu.MenuItems.Add(spawner);
        }

        private Dictionary<Type, List<Bitmap>> FillCreatureImageDict(List<Type> creatureTypes)
        {
            var dct = new Dictionary<Type, List<Bitmap>>();
            foreach (var type in creatureTypes)
            {
                dct.Add(type, new List<Bitmap>());
                var name = type.Name.ToLower();
                for (int i = 1; i <= 8; i++)
                {
                    var filename = @"Gfx\" + name + i + ".png";
                    if (File.Exists(filename))
                        dct[type].Add(new Bitmap(filename));
                    else
                        break;
                }
            }
            return dct;
        }

        private Dictionary<Type, Bitmap> FillMapObjImageDict(List<Type> mapObjTypes)
        {
            var dct = new Dictionary<Type, Bitmap>();
            foreach (var type in mapObjTypes)
            {
                var filename = @"Gfx\" + type.Name.ToLower() + ".png";
                if (File.Exists(filename))
                    dct.Add(type, new Bitmap(filename));
                else
                    throw new Exception(String.Format(
                        "The image for type {0}, which is expected to be at {1}, is not found!", type.Name, filename));
            }
            return dct;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            pressedKey = e.KeyCode.ToString();
            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            pressedKey = "";
            base.OnKeyUp(e);
        }

        void TimerTick()
        {
            if (tickCount == 0)
            {
                foreach (var c in game.creatures)
                    c.MakeNextMove();
                var ctplr = (Caterpillar)game.creatures[0]; //very dirty hack to see if the new ai works
                ctplr.MakeRealAnim(game.mapObjs, pressedKey);           //
            }
            foreach (var c in game.creatures)
                c.SetLocation(
                    c.Location.X + c.currentAnim[tickCount].dx,
                    c.Location.Y + c.currentAnim[tickCount].dy);
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

            foreach (var o in game.mapObjs)
                g.DrawImage(mapObjImages[o.GetType()], o.Location);
            foreach (var c in game.creatures)
            {
                var imgList = creatureImages[c.GetType()];
                g.DrawImage(imgList[tickCount % imgList.Count], c.Location);
            }
            base.OnPaint(e);
        }
    }
}
