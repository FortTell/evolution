using System.Drawing;

namespace Evolution.Logic
{
    public class Terrain
    {
        public Rectangle Hitbox { get; protected set; }
        public Point Location { get; protected set; }

        public Terrain(int x, int y) { }

        static char mapSymbol;
    }
}
