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
        private List<Tail> tails;
		private Vector2 lastPosition;

		public Snake() 
        {
            tails = new List<Tail>();

            directionVectors = new Dictionary<Directions, Vector2>()
            {
                {Directions.Up, new Vector2(0, -1) },
                {Directions.Right, new Vector2(1, 0) },
                {Directions.Left, new Vector2(-1, 0) },
                {Directions.Down, new Vector2(0, 1) }
            };

            Position = new Vector2(6, 5);
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

        public override void Draw()
        {
            Console.Write('s');
        }

		public override void Update()
		{
			lastPosition = Position;
			Position += accVector;

            for (int i = tails.Count - 1; i >= 0; i--)
            {
                int nextTail = i;
                nextTail--;

                //if (lastTail <= tails.Count)
                //{
                if (nextTail < 0)
                {
                    tails[i].Position = this.lastPosition;
                }
                else
                {
                    tails[i].Position = tails[nextTail].Position;
                }
                //}
            }
		}

		public Tail CreateNewTail()
		{
			Tail tail = new Tail();
            if (tails.Count > 0)
            {
				tail.Position = tails.Last().Position;
			}
            else 
            {
                tail.Position = this.lastPosition; 
            }

			tails.Add(tail);

            return tail;
		}
	}
}
