using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Snake__SNAKE__SNAAAAAKE____
{
    internal class Game
    {
        private bool running = true;
        private System.Timers.Timer timer;
        private Map map;
		private Snake snake;
        private List<GameObject> gameObjects;

		public Game()
        {
            snake= new Snake();

            gameObjects= new List<GameObject>();
            gameObjects.Add(snake);

            map = new Map(snake);
        }

        /// <summary>
        /// Runs when game starts.
        /// </summary>
        internal void start()
        {
            BeginLoop();
        }

        private void BeginLoop()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 500;

            timer.Elapsed += Update;
            timer.Start();
            snake.ChangeDirection(Snake.Directions.Up);

			while (running)
			{
				if (Console.KeyAvailable)
				{

                    var pressedKey = Console.ReadKey(true).Key;
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
            Draw();

        }


        private void Draw()
        {
            map.Draw(gameObjects.ToArray());
        }
    }
}
