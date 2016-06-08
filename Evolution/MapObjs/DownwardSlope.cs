using System.Drawing;

namespace Evolution
{
    class DownwardSlope : MapObject
    {
        static char mapSymbol = '\\';

        public DownwardSlope(int x, int y)
        {
            Location = new Point(x, y);
            Hitbox = new Rectangle(0, 0, 64, 64);
        }
    }
}
