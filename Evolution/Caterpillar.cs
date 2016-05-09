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
        public Point coords { get; private set; }
        public Bitmap image { get; private set; }

        public Caterpillar()
        {
            this.coords = new Point(200, 200);
            this.image = new Bitmap(@"Gfx\caterpillar.jpg");
        }

        /*void Refresh()
        {
            commands.Enqueue(...);
            hitbox = new Rectangle(x, y, image.Width, image.Height);
        }*/
    }
}
