﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution
{
    public class Game
    {
        public List<ICreature> creatures;
        public Caterpillar ctplr;

        public Game()
        {
            creatures = new List<ICreature>();
            ctplr = new Caterpillar(10, 10);
        }

        public void HandleKeyPress(string s)
        {
            switch (s.ToLower())
            {
                //case "w": ctplr.command = new CreatureCommand { dy = -1 }; break;
                //case "s": ctplr.command = new CreatureCommand { dy = 1 }; break;
                //case "a": ctplr.command = new CreatureCommand { dx = -1 }; break;
                //case "d": ctplr.command = new CreatureCommand { dx = 1 }; break;
                default: break;
            }
        }
    }
}
