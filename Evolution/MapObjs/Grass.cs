﻿using System.Drawing;

namespace Evolution
{
    public class Grass : MapObject
    {
        static char mapSymbol = '-';

        public Grass(int x, int y)
        {
            Location = new Point(x, y);
            Hitbox = new Rectangle(0, 0, 64, 64);
        }
    }
}
