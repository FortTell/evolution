using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution
{
    public class Caterpillar : ICreature
    {
        public Point Location { get; set; }
        public CreatureAnimation currentAnim { get; private set; }

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
            this.Location = new Point(x, y);
        }

        public void SetCurrentAnim()
        {
            currentAnim = new CreatureAnimation()
                .AddRandom(moveChoices)
                .AddRandom(moveChoices)
                .AddRandom(moveChoices)
                .AddRandom(moveChoices)
                .Repeat(2);
        }
    }
}
