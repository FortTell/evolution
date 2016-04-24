using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evolution
{
    public partial class Form1 : Form
    {
        Game game;
        public Form1()
        {
            InitializeComponent();
        }

        int tickCount = 0;

        /*void TimerTick(object sender, EventArgs args)
        {
            if (tickCount == 0) Act();
            foreach (var e in animations)
                e.Location = new Point(e.Location.X + 4 * e.Command.DeltaX, e.Location.Y + 4 * e.Command.DeltaY);
            if (tickCount == 7)
            {
                for (int x = 0; x < game.MapWidth; x++) for (int y = 0; y < game.MapHeight; y++) game.Map[x, y] = null;
                foreach (var e in animations)
                {
                    var x = e.Location.X / 32;
                    var y = e.Location.Y / 32;
                    var nextCreature = e.Command.TransformTo == null ? e.Creature : e.Command.TransformTo;
                    if (game.Map[x, y] == null) game.Map[x, y] = nextCreature;
                    else
                    {
                        bool newDead = nextCreature.DeadInConflict(game, game.Map[x, y]);
                        bool oldDead = game.Map[x, y].DeadInConflict(game, nextCreature);
                        if (newDead && oldDead)
                            game.Map[x, y] = null;
                        else if (!newDead && oldDead)
                            game.Map[x, y] = nextCreature;
                        else if (!newDead && !oldDead)
                            throw new Exception(string.Format("Существа {0} и {1} претендуют на один и тот же участок карты", nextCreature.GetType().Name, game.Map[x, y].GetType().Name));
                    }

                }
            }
            tickCount++;
            if (tickCount == 8) tickCount = 0;
            Invalidate();
        }*/

    }
}
