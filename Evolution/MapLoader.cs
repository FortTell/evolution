using System;
using System.IO;
using System.Linq;
using Evolution;
using System.Reflection;
using System.Collections.Generic;
//using Creatures;

namespace Evolution
{
    public static class MapLoader
    {
        public static void ReadMap(Game game, string filename)
        {
            var raw = File.ReadAllLines(filename);

            var creatureTypes = Util.GetTypesInheritedFrom(typeof(Creature));
            var mapObjTypes = Util.GetTypesInheritedFrom(typeof(MapObject));

            var creaturesDct = new Dictionary<char, Type>();
            foreach (var t in creatureTypes)
                creaturesDct.Add((char)t.GetField("mapSymbol").GetRawConstantValue(), t);

            var mapObjsDct = new Dictionary<char, Type>();
            foreach (var t in mapObjTypes)
                mapObjsDct.Add((char)t.GetField("mapSymbol").GetRawConstantValue(), t);

            for (var i = 0; i < raw.Length; i++)
                for (var j = 0; j < raw[0].Length; j++)
                {
                    if (creaturesDct.ContainsKey((char)raw[i][j]))
                    {
                        var ctor = creaturesDct[raw[i][j]].GetConstructor(new Type[] { typeof(int), typeof(int) });
                        var creature = (Creature)ctor.Invoke(new object[] { j * 64, i * 64 });
                        game.creatures.Add(creature);
                    }

                    if (creaturesDct.ContainsKey((char)raw[i][j]))
                    {
                        var ctor = creaturesDct[raw[i][j]].GetConstructor(new Type[] { typeof(int), typeof(int) });
                        var mapObj = (MapObject)ctor.Invoke(new object[] { j * 64, i * 64 });
                        game.mapObjs.Add(mapObj);
                    }
                }
        }
    }
}

