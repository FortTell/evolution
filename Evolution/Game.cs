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
        public List<MapObject> mapObjs;

        public Game()
        {
            creatures = new List<Creature> { new Caterpillar(10, 10) };
            mapObjs = new List<MapObject>();
            for (var i = 0; i < 5; i++)
                mapObjs.Add(new Grass(64 * i, 200));
            for (var i = 6; i < 8; i++)
                mapObjs.Add(new Grass(64 * i, 300));
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
