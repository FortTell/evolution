using System.Drawing;

namespace Evolution
{
    class UpwardSlope : MapObject
    {
        static char mapSymbol = '/';

        public UpwardSlope(int x, int y)
        {
            Location = new Point(x, y);
            Hitbox = new Rectangle(0, 0, 64, 64);
        }
    }
}
