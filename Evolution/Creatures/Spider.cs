using System;
using System.Drawing;

namespace Evolution
{
	public class Spider : Creature
	{
        public const char mapSymbol = 's';

        Size webSize;
        Point originalCoords;
		bool isGoingUp;

		public Spider (int x, int y) : base(x, y)
		{
			isGoingUp = true;
            webSize = new Size(32, 32);
            originalCoords = new Point(x, y);
            MakeNextMove();
		}

        public override CreatureAnimation MakeCurrentAnim()
        {
            CreatureAnimation result;
            if (isGoingUp)
            {
                var distToUpperBorder = Location.Y - originalCoords.Y + webSize.Height;
                if (distToUpperBorder > 8)
                    result = new CreatureAnimation().Add(new CreatureCommand { dy = -1 }).Repeat(8);
                else
                {
                    result = new CreatureAnimation().Add(new CreatureCommand { dy = -1 }).Repeat(distToUpperBorder)
                        .Add(new CreatureAnimation().Add(new CreatureCommand { dy = 1 }).Repeat(8 - distToUpperBorder));
                    isGoingUp = false;
                }
            }
            else
            {
                var distToLowerBorder = (originalCoords.Y + webSize.Height + 64) - Location.Y; //remove magic constants (sprite size)
                if (distToLowerBorder > 8)
                    result = new CreatureAnimation().Add(new CreatureCommand { dy = 1 }).Repeat(8);
                else
                {
                    result = new CreatureAnimation()
                        .Add(new CreatureCommand { dy = 1 }).Repeat(distToLowerBorder)
                        .Add(new CreatureAnimation().Add(new CreatureCommand { dy = -1 }).Repeat(8 - distToLowerBorder));
                    isGoingUp = true;
                }
            }
            return result;
        }

		/*public override CreatureAnimation MakeCurrentAnim()
		{
			CreatureAnimation result;
			if (!up)
			{
				result = new CreatureAnimation ()
					.Add (new CreatureCommand { dy = 2 })
					.Repeat (1);
				up = true;
			}

			else
			{
				result = new CreatureAnimation ()
					.Add (new CreatureCommand { dy = -2 })
					.Repeat (1);
				up = false;
			}
			
			if (!left)
			{
				result = new CreatureAnimation ()
					.Add (new CreatureCommand { dx = 2 })
					.Repeat (1);
			}

			else
			{
				result = new CreatureAnimation ()
					.Add (new CreatureCommand { dx = -2 })
					.Repeat (1);
			}
            left = !left;
            return result;
		}*/
	}
}

