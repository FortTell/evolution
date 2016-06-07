using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution
{
    public class MapObject
    {
        public Rectangle Hitbox { get; protected set; }
        public Point Location { get; protected set; }
        
    }
}
