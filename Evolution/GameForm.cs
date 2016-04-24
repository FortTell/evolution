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
        int tickCount = 0;
        
        public GameForm()
        {
            Height = 600;
            Width = 800;
            Text = "Evolution";
            game = new Game();
            var img = new Bitmap("gfx\\caterpillar.jpg");
            l = new Label { Top = 50, Left = 50, Height = img.Height, Width = img.Width, Image = img };
            Controls.Add(l);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            game.HandleKeyPress(e.KeyChar.ToString());
            l.Left += game.ctplr.command.dx;
            l.Top += game.ctplr.command.dy;
            game.ctplr.command = new CreatureCommand();
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
            base.OnPaint(e);
        }
    }
}
