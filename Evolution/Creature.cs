using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution
{
    public class Caterpillar : ICreature
    {
        public CreatureCommand command;
        //Queue<CC>?
        Bitmap image;
        Rectangle hitbox;
        int x;
        int y;

        public Caterpillar()
        {

        }

        /*void Refresh()
        {
            commands.Enqueue(...);
            hitbox = new Rectangle(x, y, image.Width, image.Height);
        }*/
    }
}
