using System.Drawing;

namespace Evolution
{
    public class Grass : MapObject
    {
        public const char mapSymbol = '-';

        public Grass(int x, int y) : base(x, y)
        {
            Location = new Point(x, y);
            Hitbox = new Rectangle(0, 0, 64, 64);
        }
    }
}
