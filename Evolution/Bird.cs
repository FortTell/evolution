using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Evolution
{
    public class Bird : ICreature
    {
        public Point Location { get; set; }
        public CreatureAnimation currentAnim { get; private set; }

        public Bird(int x, int y)
        {
            this.Location = new System.Drawing.Point(x, y);
        }

        public void SetCurrentAnim()
        {
            //more readable
            var result = new CreatureAnimation()
                .Add(new CreatureCommand { dy = 1 })
                .Add(new CreatureCommand { dx = 1, dy = 1 })
                .Repeat(4)
                .DoUntil(this, c => c.Location.Y >= 300).Then()
                .Add(new CreatureCommand { dy = -1 })
                .Add(new CreatureCommand { dx = 1, dy = -1 })                
                .Repeat(4);

                /*.Repeat(4, anim => anim//anim.Down().DownRight()
                    .Add(new CreatureCommand{dy = 1})
                    .Add(new CreatureCommand{dx = 1, dy = 1}))
                .DoUntil(this, c => c.Location.Y >= 300).Then()
                .Repeat(4, anim => anim
                    .Add(new CreatureCommand { dy = -1 })
                    .Add(new CreatureCommand { dx = 1, dy = -1 }));*/
            this.currentAnim = result;
        }
    }
}
