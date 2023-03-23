using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace Snake__SNAKE__SNAAAAAKE____
{
    internal class Game
    {
        private bool running;
        private System.Timers.Timer timer;
        private Map map;
		private Snake snake;
        private List<GameObject> gameObjects;
        private int score;
		private Random rand;

		public Game()
        {
			snake = new Snake();
			timer = new System.Timers.Timer();
			rand = new Random();
            score = 0;

			gameObjects = new List<GameObject>();
            gameObjects.Add(snake);

            map = new Map();
        }

        /// <summary>
        /// Runs when game starts.
        /// </summary>
        internal void start()
		{
			CreateRandomPoint();

			BeginLoop();
		}

		private void CreateRandomPoint()
		{
		    Point point = new Point();

			int randX = rand.Next(1, 15);
			int randY = rand.Next(1, 7);

			point.Position = new Vector2(randX, randY);

			gameObjects.Add(point);
		}

		private void BeginLoop()
        {
            timer.Interval = 400;

            timer.Elapsed += Update;
            timer.Start();
            snake.ChangeDirection(Snake.Directions.Up);
			running = true;

			while (running)
			{
				if (Console.KeyAvailable)
				{

                    var pressedKey = Console.ReadKey(true).Key;
                    if (pressedKey == ConsoleKey.Escape)
                    {
                        running = false;
                    }
                    snake.ChangeDirection((Snake__SNAKE__SNAAAAAKE____.Snake.Directions)pressedKey);
				}
			} 
        }

		/// <summary>
		/// Updates the game
		/// </summary>
		private void Update(object? sender, System.Timers.ElapsedEventArgs e)
		{
			snake.Update();

			HandleTails();
			HandlePoints();

			if (snake.Position.X > map.Size.X - 2 || snake.Position.X < 1 ||
				snake.Position.Y > map.Size.Y - 2 || snake.Position.Y < 1)
				GameOver();
			

			Draw();
		}

		private void HandlePoints()
		{


			if (rand.Next(1, 6) == 5)
			{
				CreateRandomPoint();
			}

			var points = gameObjects.OfType<Point>().ToArray();

			foreach (var point in points)
			{
				if (snake.Position == point.Position)
				{
					gameObjects.Remove(point);
					score++;
					var newTail = snake.CreateNewTail();
					gameObjects.Add(newTail);
				}
			}
		}

		private void HandleTails()
		{

			var tails = gameObjects.OfType<Tail>().ToArray();
			foreach (var tail in tails)
			{
				if (tail.Position == snake.Position)
				{
					GameOver();
				}
			}
		}

		private void GameOver()
		{
			Console.WriteLine("Game Over");
			timer.Stop();
		}

		private void Draw()
        {
			Console.SetCursorPosition(0, 0);
			map.Draw(gameObjects.ToArray());
            Console.WriteLine("Score:" + score);
        }
    }
}
