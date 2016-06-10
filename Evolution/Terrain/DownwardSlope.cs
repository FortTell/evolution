using System.Drawing;
using Evolution.Logic;

namespace Evolution.Entities
{
    public class DownwardSlope : Terrain
    {
        public const char mapSymbol = '\\';

        public DownwardSlope(int x, int y) : base(x, y)
        {
            Location = new Point(x, y);
            Hitbox = new Rectangle(0, 0, 64, 64);
        }
    }
}
