using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Evolution
{
    class GameForm : Form
    {
        Game game;
        Label l;
        Random rnd = new Random();
        int tickCount = 0;
        
        public GameForm()
        {
            Height = 600;
            Width = 800;
            Text = "Evolution";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            game = new Game();
            
            InitializeUI();
        }

        private void InitializeUI()
        {
            var creatureTypes = GetCreatureTypes();

            Menu = new MainMenu();
            var spawner = new MenuItem("Spawn a creature");
            foreach (var type in creatureTypes)
            {
                var item = new MenuItem(type.Name);
                item.Click += (sender, args) =>
                {
                    var ctor = type.GetConstructor(new Type[] { typeof(int), typeof(int) });
                    var creature = (ICreature)ctor.Invoke(new object[] { rnd.Next(Size.Width), rnd.Next(Size.Height) });
                    game.creatures.Add(creature);
                    Invalidate();
                };
                spawner.MenuItems.Add(item);
            }
            Menu.MenuItems.Add(spawner);

            var img = new Bitmap("gfx\\caterpillar.jpg");
            l = new Label { Top = 50, Left = 50, Height = img.Height, Width = img.Width, Image = img };
            Controls.Add(l);
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
            //l.Left += game.ctplr.command.dx;
            //l.Top += game.ctplr.command.dy;
            //game.ctplr.command = new CreatureCommand();
            Invalidate();
            base.OnKeyPress(e);
        }

        void Act()
        {
            foreach (var c in game.creatures)
            { /*c.Act();*/ }
        }

        /*void TimerTick(object sender, EventArgs args)
        {
            if (tickCount == 0) 
                Act();
            foreach(


        }*/

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            foreach (var c in game.creatures)
                g.DrawImage(c.image, c.coords);
            base.OnPaint(e);
        }
    }
}
