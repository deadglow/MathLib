using System;

namespace MathLib
{
	public struct Vector3
	{
		public float x, y, z;
		#region Statics
		public static Vector3 Zero
		{
			get
			{
				return new Vector3(0f, 0f, 0f);
			}
		}
		public static Vector3 One
		{
			get
			{
				return new Vector3(1f, 1f, 1f);
			}
		}
		public static Vector3 Forward
		{
			get
			{
				return new Vector3(0f, 0f, 1f);
			}
		}
		public static Vector3 Right
		{
			get
			{
				return new Vector3(1f, 0f, 0f);
			}
		}
		public static Vector3 Up
		{
			get
			{
				return new Vector3(0f, 1f, 0f);
			}
		}
		#endregion

		public Vector3 (float x, float y, float z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public static Vector3 operator +(Vector3 a, Vector3 b)
		{
			return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
		}
		public static Vector3 operator -(Vector3 a, Vector3 b)
		{
			return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
		}
		public static Vector3 operator *(Vector3 a, float scalar)
		{
			return new Vector3(a.x * scalar, a.y * scalar, a.z * scalar);
		}
		public static Vector3 operator *(float scalar, Vector3 a)
		{
			return a * scalar;
		}
		public static Vector3 operator /(Vector3 a, float scalar)
		{
			return new Vector3(a.x / scalar, a.y / scalar, a.z / scalar);
		}
		public static Vector3 operator -(Vector3 a)
		{
			return new Vector3(-a.x, -a.y, -a.z);
		}

		//Conversion overload
		public static implicit operator Vector2(Vector3 vec) { return new Vector2(vec.x, vec.y); }

		public static float Magnitude(Vector3 a)
		{
			return (float)Math.Sqrt(a.x * a.x + a.y * a.y + a.z * a.z);
		}

		public static Vector3 Normalise(Vector3 a)
		{
			return (a / Magnitude(a));
		}

		public static float Dot(Vector3 a, Vector3 b)
		{
			return a.x * b.x + a.y * b.y + a.z * b.z;
		}

		public static Vector3 Cross(Vector3 a, Vector3 b)
		{
			return new Vector3(
				a.y * b.z - a.z * b.y,
				a.z * b.x - a.x * b.z,
				a.x * b.y - a.y * b.x);
		}

		public float Magnitude()
		{
			return Magnitude(this);
		}

		public void Normalise()
		{
			Vector3 vec = Normalise(this);
			x = vec.x;
			y = vec.y;
			z = vec.z;
		}

		public float Dot(Vector3 other)
		{
			return Dot(this, other);
		}

		public Vector3 Cross (Vector3 other)
		{
			return Cross(this, other);
		}

	}
}
