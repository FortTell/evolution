using System;
using System.Drawing;
using Evolution.Entities;

namespace Evolution.Logic
{
    public abstract class Creature
    {
        public CreatureAnimation currentAnim { get; protected set; } 
        public Point Location { get; private set; }

        public Creature(int x, int y)
        {
            SetLocation(x, y);
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
