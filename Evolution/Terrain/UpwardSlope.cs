using System.Drawing;
using Evolution.Logic;

namespace Evolution.Entities
{
    public class UpwardSlope : Terrain
    {
        public const char mapSymbol = '/';

        public UpwardSlope(int x, int y) : base(x, y)
        {
            Location = new Point(x, y);
            Hitbox = new Rectangle(0, 0, 64, 64);
        }
    }
}
