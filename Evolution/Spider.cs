using System;

namespace Evolution
{
	public class Spider : Creature
	{
		int webWidth;
		int webHeight;
		bool up;
		bool left;

		public Spider (int x, int y) : base(x, y)
		{
			up = false;
			left = false;
			MakeNextMove();
		}

		public override CreatureAnimation MakeCurrentAnim()
		{
			CreatureAnimation result;
			if (!up)
			{
				result = new CreatureAnimation ()
					.Add (new CreatureCommand { dy = 2 })
					.Repeat (1);
				up = true;
			}

			else if (up)
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
				left = true;
			}

			else if (left)
			{
				result = new CreatureAnimation ()
					.Add (new CreatureCommand { dx = -2 })
					.Repeat (1);
				left = false;
			}
		}
	}
}

