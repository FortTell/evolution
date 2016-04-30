using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution
{
    public class CreatureAnimation
    {
        private readonly Queue<CreatureCommand> commands = new Queue<CreatureCommand>();

        private void AddInner(CreatureCommand c)
        {
            commands.Enqueue(c);
        }

        public CreatureAnimation Add(CreatureCommand c)
        {
            AddInner(c);
            return this;
        }

        public CreatureAnimation Repeat(int count, Func<CreatureAnimation, CreatureAnimation> inner)
        {
            var innerAnim = inner(new CreatureAnimation());
            for (var i = 0; i < count; i++)
                foreach(var c in innerAnim.commands)
                    AddInner(c);
            return this;
        }

        public CreatureAnimation Until(ICreature actor, Func<ICreature, bool> condition)
        {
            while (!condition(actor)) //Не знаю, как написать
            {

            }
            return this;
        }
    }
}
