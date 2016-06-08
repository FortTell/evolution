using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution
{
    public abstract class Creature
    {
        static char mapSymbol;
        public CreatureAnimation currentAnim { get; protected set; } //or better to leave setter as private?
        public Point Location { get; private set; }

        public Creature(int x, int y)
        {
            SetLocation(x, y);
            //MakeNextMove();
        }


        public void MakeNextMove()
        {
            var anim = MakeCurrentAnim();
            if (anim.Length != 8)
                throw new InvalidOperationException("Animation must be 8 commands long!");
            this.currentAnim = anim;
        }
        public abstract CreatureAnimation MakeCurrentAnim();
        public void SetLocation(int x, int y)
        {
            Location = new Point(x, y);
        }
        //Rectangle hitbox { get; set; }
    }
}
