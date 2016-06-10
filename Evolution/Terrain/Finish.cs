using System.Drawing;
using Evolution.Logic;

namespace Evolution.Entities
{
    public class Finish : Terrain
    {
        public const char mapSymbol = '#';

        public Finish(int x, int y) : base(x, y)
        {
            Location = new Point(x, y);
            Hitbox = new Rectangle(0, 0, 64, 64);
        }
    }
}
