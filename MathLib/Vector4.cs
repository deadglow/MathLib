using System;

namespace MathLib
{
	public struct Vector4
	{
		public float x;
		public float y;
		public float z;
		public float w;

		public Vector4 (float x, float y, float z, float w)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}

		public static Vector4 operator +(Vector4 a, Vector4 b)
		{
			return new Vector4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
		}
		public static Vector4 operator -(Vector4 a, Vector4 b)
		{
			return new Vector4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
		}
		public static Vector4 operator *(Vector4 a, float scalar)
		{
			return new Vector4(a.x * scalar, a.y * scalar, a.z * scalar, a.w * scalar);
		}
		public static Vector4 operator *(float scalar, Vector4 a)
		{
			return a * scalar;
		}
		public static Vector4 operator /(Vector4 a, float scalar)
		{
			return new Vector4(a.x / scalar, a.y / scalar, a.z / scalar, a.w / scalar);
		}

		public static float Magnitude(Vector4 a)
		{
			return (float)Math.Sqrt(a.x * a.x + a.y * a.y + a.z * a.z + a.w * a.w);
		}

		public static Vector4 Normalised(Vector4 a)
		{
			return a / Magnitude(a);
		}

		public static float Dot(Vector4 a, Vector4 b)
		{
			return a.x * b.x + a.y + b.y + a.z * b.z + a.w * b.w;
		}

		public static Vector4 Cross(Vector4 a, Vector4 b)
		{
			return new Vector4(
				a.y * b.z - a.z * b.y,
				a.z * b.x - a.x * b.z,
				a.x * b.y - a.y * b.x,
				0);
		}

		public float Magnitude()
		{
			return Magnitude(this);
		}

		public Vector4 Normalised()
		{
			return Normalised(this);
		}

		public float Dot(Vector4 other)
		{
			return Dot(this, other);
		}

		public Vector4 Cross(Vector4 other)
		{
			return Cross(this, other);
		}

	}
}
