using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution
{
    public class Caterpillar : Creature
    {
        private CreatureCommand[] moveChoices = new CreatureCommand[] 
        {
            new CreatureCommand { dx = 1 }, 
            new CreatureCommand { dx = -1 }, 
            new CreatureCommand { dy = 1 }, 
            new CreatureCommand { dy = -1 }, 
            new CreatureCommand { dx = 1, dy = -1 } 
        };

        public Caterpillar(int x, int y)
        {
            SetLocation(x, y);
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
    }
}
