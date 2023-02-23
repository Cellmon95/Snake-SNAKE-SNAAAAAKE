using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Snake__SNAKE__SNAAAAAKE____
{
    internal class Snake : GameObject
    {

        public enum Directions
        {
            Up = ConsoleKey.UpArrow,
            Left = ConsoleKey.LeftArrow,
            Right = ConsoleKey.RightArrow,
            Down = ConsoleKey.DownArrow
        }

        /// <summary>
        /// Contains the direction vectors.
        /// </summary>
        private readonly Dictionary<Directions, Vector2> directionVectors;
        private Vector2 accVector;

		public Snake() 
        {
            directionVectors = new Dictionary<Directions, Vector2>()
            {
                {Directions.Up, new Vector2(0, -1) },
                {Directions.Right, new Vector2(1, 0) },
                {Directions.Left, new Vector2(-1, 0) },
                {Directions.Down, new Vector2(0, 1) }
            };

            Position = new Vector2(6, 6);
            accVector = new Vector2(1, 0);
        }

        public void ChangeDirection(Directions direction)
        {
            try
            {
				accVector = directionVectors[direction];
			}
            catch (KeyNotFoundException)
            {

            }
		}

        

        public void Update()
        {
            Position += accVector;
        }

    }
}
