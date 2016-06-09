using System;
using System.IO;
using System.Linq;
using Evolution;
using Creatures;

namespace Evolution
{
	public class MapLoader
	{
		public MapObject[][] ReadMap(string filename)
		{
			var raw = File.ReadAllLines(filename);
			var arr = new MapObject[raw.Length][];
			for (var i = 0; i < raw.Length; i++)
				for (var j = 0; j < raw[0].Length; j++)
				{
					switch (raw[i][j])
					{
						case Spider.mapSymbol:
							arr [i] [j] = new Spider (j * 64, i * 64);
						case Bird.mapSymbol:
							arr [i] [j] = new Bird (j * 64, i * 64);
						case Caterpillar.mapSymbol:
							arr [i] [j] = new Caterpillar (j * 64, i * 64);
					}
					
				}
			return  arr;
		}
	}
}

