using System.Drawing;

namespace Evolution
{
    public class UpwardSlope : MapObject
    {
        public const char mapSymbol = '/';

        public UpwardSlope(int x, int y)
        {
            Location = new Point(x, y);
            Hitbox = new Rectangle(0, 0, 64, 64);
        }
    }
}
