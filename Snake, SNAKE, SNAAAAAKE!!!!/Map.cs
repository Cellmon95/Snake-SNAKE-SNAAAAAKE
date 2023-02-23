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
        private Snake snake;

        public Map(Snake snake)
        {
            map = new List<List<char>>();
            this.snake = snake;
            initMap();

        }

        public void Draw(GameObject[] gameObjects)
        {
            Console.SetCursorPosition(0, 0);
            for (int x = 0; x < map.Count; x++)
            {

                for (int y = 0; y < map[x].Count; y++)
                {
                    if (snake.Position == new Vector2(y, x))
                    {
                        Console.Write('s');
                    }
                    else
                    {
						Console.Write(map[x][y]);
					}
				}
                Console.WriteLine();
			}
        }

        private void initMap()
        {
            string[] mapText = System.IO.File.ReadAllLines(@"C:\Users\Lucas\source\repos\Snake, SNAKE, SNAAAAAKE!!!!\Snake, SNAKE, SNAAAAAKE!!!!\Map.txt");

            foreach (var line in mapText.Select((content, index) => (content, index)))
            {
                map.Add(new List<char>());
                char[] lineChar = line.content.ToCharArray();
                foreach (var character in lineChar.Select((content, index) => (content, index)))
                {
                    map[line.index].Add(character.content);
                }
            }
        }
    }
}
