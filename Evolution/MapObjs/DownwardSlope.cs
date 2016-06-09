using System.Drawing;

namespace Evolution
{
    public class DownwardSlope : MapObject
    {
        public const char mapSymbol = '\\';

        public DownwardSlope(int x, int y) : base(x, y)
        {
            Location = new Point(x, y);
            Hitbox = new Rectangle(0, 0, 64, 64);
        }
    }
}
