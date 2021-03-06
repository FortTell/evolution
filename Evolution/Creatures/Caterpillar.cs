﻿using System.Collections.Generic;
using System.Drawing;
using Evolution.Logic;

namespace Evolution.Entities
{
    public class Caterpillar : Creature
    {
        public const char mapSymbol = 'C';
        private CreatureCommand[] moveChoices = new CreatureCommand[] 
        {
            new CreatureCommand { dx = 1 }, 
            new CreatureCommand { dx = -1 }, 
            new CreatureCommand { dy = 1 }, 
            new CreatureCommand { dy = -1 }, 
            new CreatureCommand { dx = 1, dy = -1 } 
        };

        public Caterpillar(int x, int y)
            : base(x, y)
        {
            MakeNextMove();
        }

        public override CreatureAnimation MakeCurrentAnim()
        {
            return new CreatureAnimation()
                .AddRandom(moveChoices)
                .AddRandom(moveChoices)
                .AddRandom(moveChoices)
                .AddRandom(moveChoices)
                .Repeat(2);
        }

        public void MakeRealAnim(List<Terrain> mapObjs, string pressedKey)
        {
            bool isOnGround = false;
            foreach (var o in mapObjs)
            {
                if (o.Hitbox.Contains(new Point(Location.X - o.Location.X, Location.Y - o.Location.Y + 64 + 1)))
                {
                    isOnGround = true;
                    break;
                }
            }
            if (isOnGround)
            {
                if (pressedKey == "A")
                    currentAnim = new CreatureAnimation().Add(new CreatureCommand { dx = -1 }).Repeat(8);
                else if (pressedKey == "D")
                    currentAnim = new CreatureAnimation().Add(new CreatureCommand { dx = 1 }).Repeat(8);
                else
                    currentAnim = new CreatureAnimation().Add(new CreatureCommand()).Repeat(8);
            }
            else
                currentAnim = new CreatureAnimation().Add(new CreatureCommand { dy = 1 }).Repeat(8);
        }
    }
}
