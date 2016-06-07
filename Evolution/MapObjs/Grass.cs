using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Evolution
{
    public class Grass : MapObject
    {
        public Grass(int x, int y)
        {
            Location = new Point(x, y);
            Hitbox = new Rectangle(x, y + 40, 64, 24);
        }
    }
}
