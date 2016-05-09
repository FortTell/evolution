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
        //CreatureAnimation currentAnim { get; set; }
        //Queue<CC>?
        Bitmap image { get; }
        //Rectangle hitbox { get; set; }
        Point coords { get; }
    }
}
