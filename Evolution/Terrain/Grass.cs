using System.Drawing;
using Evolution.Logic;

namespace Evolution.Entities
{
    public class Grass : Terrain
    {
        public const char mapSymbol = '-';

        public Grass(int x, int y) : base(x, y)
        {
            Location = new Point(x, y);
            Hitbox = new Rectangle(0, 0, 64, 64);
        }
    }
}
