using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution
{
    public class Bird : ICreature
    {
        public Bird()
        {
            var c = (ICreature)this;
            c.currentAnim = AILogic();
        }

        public CreatureAnimation AILogic()
        {
            var result = new CreatureAnimation()
                .Repeat(4, anim => anim
                    .Add(new CreatureCommand{dy = 1})
                    .Add(new CreatureCommand{dx = 1, dy = 1}))
                .Until(this, c => c.y < 100)
                .Repeat(4, anim => anim
                    .Add(new CreatureCommand { dy = -1 })
                    .Add(new CreatureCommand { dx = 1, dy = -1 }));
            return result;
        }
    }
}
