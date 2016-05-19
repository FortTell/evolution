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
        CreatureAnimation currentAnim { get; }
        void SetCurrentAnim();
        //must make an anim 8 or more items long, or NullRefExcept on tick. Fix?

        Point Location { get; set; }
        //Rectangle hitbox { get; set; }
    }
}
