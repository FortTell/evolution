using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Evolution
{
    public class Bird : Creature
    {
        bool isGoingUp;
        int originalY;
        int bottomY;

        public Bird(int x, int y)
        {
            SetLocation(x, y);
            originalY = y;
            bottomY = y + 160;
            isGoingUp = false;
            MakeNextMove();
        }

        public override CreatureAnimation MakeCurrentAnim()
        {
            CreatureAnimation result;
            if (!isGoingUp)
            {
                if (Location.Y > bottomY)
                    isGoingUp = true;
                result = new CreatureAnimation()
                    .Add(new CreatureCommand { dy = 1 })
                    .Add(new CreatureCommand { dx = 1, dy = 1 })
                    .Repeat(4);
            }
            else
            {
                if (Location.Y < originalY)
                {
                    //disappear and remove from game.creatures
                }
                result = new CreatureAnimation()
                    .Add(new CreatureCommand { dy = -1 })
                    .Add(new CreatureCommand { dx = 1, dy = -1 })
                    .Repeat(4);
            }
            return result;
        }


        //public void MakeNextMove()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
