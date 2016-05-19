using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution
{
    public class CreatureAnimation
    {
        private readonly List<CreatureCommand> commands;
        private Random rnd = new Random();

        public CreatureAnimation()
        {
            commands = new List<CreatureCommand>();
        }

        public CreatureAnimation(List<CreatureCommand> commands)
        {
            this.commands = commands;
        }

        public static CreatureAnimation DoNothing
        {
            get
            {
                return new CreatureAnimation().Add(new CreatureCommand()).Repeat(8);
            }
        }

        public CreatureCommand this[int i]
        {
            get { return this.commands[i]; }
        }

        public CreatureAnimation Add(CreatureCommand c)
        {
            var newCommands = new List<CreatureCommand>(commands);
            newCommands.Add(c);
            return new CreatureAnimation(newCommands);
        }

        public CreatureAnimation Repeat(int count)
        {
            var repeatSize = commands.Count;
            var newCommands = new List<CreatureCommand>();
            for (int i = 0; i < count; i++)
                for (var j = 0; j < repeatSize; j++)
                    newCommands.Add(commands[j]);
            return new CreatureAnimation(newCommands);
        }

        public CreatureAnimation AddRandom(params CreatureCommand[] choices)
        {
            var command = choices[rnd.Next(choices.Length)];
            var newCommands = new List<CreatureCommand>(commands);
            newCommands.Add(command);
            return new CreatureAnimation(newCommands);
        }

        public CreatureAnimation DoUntil(ICreature actor, Func<ICreature, bool> condition)
        {
            if (condition(actor))
                return CreatureAnimation.DoNothing;
            else
                return this;
        }

        public CreatureAnimation Then()
        {
            return this;
        }
    }
}
