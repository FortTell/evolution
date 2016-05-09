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
        public Point coords { get; private set; }
        public Bitmap image { get; private set; }

        public Bird()
        {
            this.image = new System.Drawing.Bitmap(@"Gfx\bird.png");
            this.coords = new System.Drawing.Point(100, 100);
            //c.currentAnim = AILogic();
        }

        public CreatureAnimation AILogic()
        {
            var result = new CreatureAnimation()
                .Repeat(4, anim => anim//anim.Down().DownRight()
                    .Add(new CreatureCommand{dy = 1})
                    .Add(new CreatureCommand{dx = 1, dy = 1}))
                .Until(this, c => c.coords.Y < 100).Then()
                .Repeat(4, anim => anim
                    .Add(new CreatureCommand { dy = -1 })
                    .Add(new CreatureCommand { dx = 1, dy = -1 }));
            return result;
        }
    }
}
