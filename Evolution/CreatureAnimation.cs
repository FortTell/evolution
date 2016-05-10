using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution
{
    public class CreatureAnimation
    {
        private readonly List<CreatureCommand> commands = new List<CreatureCommand>();

        public CreatureCommand this[int i]
        {
            get { return this.commands[i]; }
        }

        private void AddInner(CreatureCommand c)
        {
            commands.Add(c);
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

        public CreatureAnimation DoUntil(ICreature actor, Func<ICreature, bool> condition)
        {
            if (condition(actor))
                commands.Clear();
            return this;
        }

        public CreatureAnimation Then()
        {
            return this;
        }
    }
}
