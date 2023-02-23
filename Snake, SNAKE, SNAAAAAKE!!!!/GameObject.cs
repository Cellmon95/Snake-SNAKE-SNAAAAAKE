using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Snake__SNAKE__SNAAAAAKE____
{
	internal abstract class GameObject
	{
		public Vector2 Position { get; set; }

		public abstract void Update();

		public abstract void Draw();
	}
}
