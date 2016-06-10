using System;
using System.Collections.Generic;
using Evolution.Logic;

namespace Evolution.Entities
{
    public class CreatureAnimation
    {
        private readonly List<CreatureCommand> commands;
        private static Random rnd = new Random();

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

        public int Length
        {
            get { return this.commands.Count; }
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

        public CreatureAnimation Add(CreatureAnimation other)
        {
            var newCommands = new List<CreatureCommand>(commands);
            newCommands.AddRange(other.commands);
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

        public CreatureAnimation DoUntil(Creature actor, Func<Creature, bool> condition)
        {
            if (condition(actor))
                return new CreatureAnimation();
            else
                return this;
        }

        public CreatureAnimation Then()
        {
            return this;
        }
    }
}
