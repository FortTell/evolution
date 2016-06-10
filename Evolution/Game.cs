using System;
using System.Collections.Generic;
using System.Linq;

namespace Evolution.Logic
{
    public class Game
    {
        public List<Creature> creatures;
        public List<Terrain> terrainObjs;
        public Creature playerCreature;

        public Game()
        {
            creatures = new List<Creature>();// { new Caterpillar(10, 10) };
            terrainObjs = new List<Terrain>();
            //for (var i = 0; i < 5; i++)
            //    mapObjs.Add(new Grass(64 * i, 200));
            //mapObjs.Add(new DownwardSlope(64 * 5, 200));
            //for (var i = 6; i < 8; i++)
            //    mapObjs.Add(new Grass(64 * i, 300));
        }

        public static Game LoadLevelFromFile(string filename, Type pcType)
        {
            var game = new Game();
            MapLoader.LoadMap(game, filename);
            game.playerCreature = game.creatures.Where(c => c.GetType() == pcType).First();
            return game;
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
