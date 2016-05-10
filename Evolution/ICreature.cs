using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution
{
    public interface ICreature
    {
        //public CreatureCommand command;
        CreatureAnimation currentAnim { get; }
        void SetCurrentAnim();
        //Queue<CC>?
        //Rectangle hitbox { get; set; }
        Point Location { get; set; }
    }
}
