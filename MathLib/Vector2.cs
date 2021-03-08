using System;

namespace MathLib
{
	public struct Vector2
	{
		public float x;
		public float y;

		public Vector2 (float x, float y)
		{
			this.x = x;
			this.y = y;
		}

		public Vector2 operator +(Vector2 a, Vector2 b)
		{
			return new Vector2()
		}
	}
}
