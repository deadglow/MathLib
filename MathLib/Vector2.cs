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

		//Operator overloading
		public static Vector2 operator +(Vector2 a, Vector2 b)
		{
			return new Vector2(a.x + b.x, a.y + b.y);
		}
		public static Vector2 operator -(Vector2 a, Vector2 b)
		{
			return new Vector2(a.x - b.x, a.y - b.y);
		}
		public static Vector2 operator *(Vector2 a, float scalar)
		{
			return new Vector2(a.x * scalar, a.y * scalar);
		}
		public static Vector2 operator *(float scalar, Vector2 a)
		{
			return a * scalar;
		}
		public static Vector2 operator /(Vector2 a, float scalar)
		{
			return new Vector2(a.x / scalar, a.y / scalar);
		}
		public static Vector3 operator -(Vector2 a)
		{
			return new Vector2(-a.x, -a.y);
		}

		//Conversion overload
		public static implicit operator Vector3(Vector2 vec) { return new Vector3(vec.x, vec.y, 0.0f); }

		//Static methods
		public static float Dot(Vector2 a, Vector2 b)
		{
			return a.x * b.x + a.y * b.y;
		}

		public static Vector2 RightAngle(Vector2 a)
		{
			return new Vector2(a.y, -a.x);
		}

		public static float Angle(Vector2 a, Vector2 b)
		{
			//dot = |a||b| * cos(angle)
			//angle = acos( dot / |a||b| )
			return (float)Math.Acos(Dot(a, b) / (a.Magnitude() * b.Magnitude()));
		}

		public static float SignedAngle(Vector2 a, Vector2 b)
		{
			a = a.Normalised();
			b = b.Normalised();
			float dot = Dot(a, b);

			float angle = (float)Math.Acos(dot);

			//Check if angle is clockwise/anticlockwise
			Vector2 rAngle = RightAngle(a);
			float rightAngleDot = Dot(b, rAngle);
			if (rightAngleDot < 0)
				angle *= -1.0f;

			return angle;
		}
		
		//Member methods
		public float Magnitude()
		{
			return (float)Math.Sqrt(x * x + y * y);
		}

		public Vector2 Normalised()
		{
			return this / Magnitude();
		}

		public float Dot(Vector2 other)
		{
			return Dot(this, other);
		}

		public Vector2 RightAngle()
		{
			Vector3 a = new Vector3();
			Vector2 b = new Vector2();
			return RightAngle(this);
		}
	}
}
