using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolution
{
    public class Game
    {
        public List<Creature> creatures;

        public Game()
        {
            creatures = new List<Creature> { new Caterpillar(10, 10) };
            creatures[0].MakeNextMove();
        }

        public void HandleKeyPress(string s)
        {
            switch (s.ToLower())
            {
                //add caterpillar movement keys
                default: break;
            }
        }
    }
}
