using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Snake__SNAKE__SNAAAAAKE____
{
    internal class Map  
    {
        private List<List<char>> map;

        public Map()
        {
            map = new List<List<char>>();
            initMap();

        }

		public Vector2 Size { get; private set; }

		public void Draw(GameObject[] gameObjects)
        {
            for (int x = 0; x < map.Count; x++)
            {

                for (int y = 0; y < map[x].Count; y++)
                {
                    bool drawnObject = false;
                    foreach (var gameObject in gameObjects)
                    {
                        if (gameObject.Position == new Vector2(y, x))
                        {
                            gameObject.Draw();
                            drawnObject = true;
                            break;
                        }
                    }

                    if (!drawnObject)
					{
						Console.Write(map[x][y]);
					}

				}
                Console.WriteLine();
			}
        }

        private void initMap()
        {
            var dir = Directory.GetCurrentDirectory();
            var mapRes = MapRes.Map;

			string[] mapText = mapRes.Split(
				new string[] { Environment.NewLine },
				StringSplitOptions.None
			);

            foreach (var line in mapText.Select((content, index) => (content, index)))
            {
                map.Add(new List<char>());
                char[] lineChar = line.content.ToCharArray();
                foreach (var character in lineChar.Select((content, index) => (content, index)))
                {
                    map[line.index].Add(character.content);
                }
            }

            Size = new Vector2(map[0].Count, map.Count);
        }
    }
}
