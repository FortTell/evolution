using System;
using System.IO;
using System.Collections.Generic;

namespace Evolution.Logic
{
    public static class MapLoader
    {
        public static void LoadMap(Game game, string filename)
        {
            var raw = File.ReadAllLines(filename);

            var creatureTypes = ReflectionUtil.GetTypesInheritedFrom(typeof(Creature));
            var creaturesDct = new Dictionary<char, Type>();
            foreach (var t in creatureTypes)
                creaturesDct.Add((char)t.GetField("mapSymbol").GetRawConstantValue(), t);

            var terrainObjTypes = ReflectionUtil.GetTypesInheritedFrom(typeof(Terrain));
            var terrainObjsDct = new Dictionary<char, Type>();
            foreach (var t in terrainObjTypes)
                terrainObjsDct.Add((char)t.GetField("mapSymbol").GetRawConstantValue(), t);

            for (var i = 0; i < raw.Length; i++)
                for (var j = 0; j < raw[i].Length; j++)
                {
                    if (creaturesDct.ContainsKey((char)raw[i][j]))
                    {
                        var creature = (Creature)ReflectionUtil.CreateAtCoords(creaturesDct[(char)raw[i][j]], j * 64, i * 64);
                        game.creatures.Add(creature);
                    }

                    if (terrainObjsDct.ContainsKey((char)raw[i][j]))
                    {
                        var terrain = (Terrain)ReflectionUtil.CreateAtCoords(terrainObjsDct[(char)raw[i][j]], j * 64, i * 64);
                        game.terrainObjs.Add(terrain);
                    }
                }
        }
    }
}

