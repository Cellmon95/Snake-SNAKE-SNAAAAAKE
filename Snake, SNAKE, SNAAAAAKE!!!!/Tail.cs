using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Snake__SNAKE__SNAAAAAKE____
{
	internal class Tail : GameObject
	{
		private Vector2 accVector;
		private Vector2 lastPosition;

		public override void Draw()
		{
			Console.Write('t');
		}

		public override void Update()
		{
			lastPosition = Position;
			Position += accVector;
		}
	}
}
