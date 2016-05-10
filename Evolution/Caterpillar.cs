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

        public Caterpillar(int x, int y)
        {
            this.Location = new Point(x, y);
        }

        public void SetCurrentAnim()
        {

        }
    }
}
