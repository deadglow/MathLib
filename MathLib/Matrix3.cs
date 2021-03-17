using System;
using System.Collections.Generic;
using System.Text;

namespace MathLib
{
	public struct Matrix3
	{
		public float m0;
		public float m1;
		public float m2;
		public float m3;
		public float m4;
		public float m5;
		public float m6;
		public float m7;
		public float m8;

		public Matrix3(bool isDefault = true) : this(1, 0, 0, 0, 1, 0, 0, 0, 1) { }

		public Matrix3(float m0, float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8)
		{
			this.m0 = m0;
			this.m1 = m1;
			this.m2 = m2;
			this.m3 = m3;
			this.m4 = m4;
			this.m5 = m5;
			this.m6 = m6;
			this.m7 = m7;
			this.m8 = m8;
		}

		public static Matrix3 operator *(Matrix3 a, Matrix3 b)
		{
			//	________Structure________
			//	|	0	|	3	|	6	|
			//	|_______|_______|_______|
			//	|	1	|	4	|	7	|
			//	|_______|_______|_______|
			//	|	2	|	5	|	8	|
			//	|_______|_______|_______|

			Matrix3 mat = new Matrix3
			{
				m0 = a.m0 * b.m0 + a.m3 * b.m1 + a.m6 * b.m2,
				m3 = a.m0 * b.m3 + a.m3 * b.m4 + a.m6 * b.m5,
				m6 = a.m0 * b.m6 + a.m3 * b.m7 + a.m6 * b.m8,
				m1 = a.m1 * b.m0 + a.m4 * b.m1 + a.m7 * b.m2,
				m4 = a.m1 * b.m3 + a.m4 * b.m4 + a.m7 * b.m5,
				m7 = a.m1 * b.m6 + a.m4 * b.m7 + a.m7 * b.m8,
				m2 = a.m2 * b.m0 + a.m5 * b.m1 + a.m8 * b.m2,
				m5 = a.m2 * b.m3 + a.m5 * b.m4 + a.m8 * b.m5,
				m8 = a.m2 * b.m6 + a.m5 * b.m7 + a.m8 * b.m8
			};

			return mat;
		}

		public static Vector3 operator *(Matrix3 mat, Vector3 vec)
		{
			return new Vector3(	mat.m0 * vec.x + mat.m3 * vec.y + mat.m6 * vec.z,
								mat.m1 * vec.x + mat.m4 * vec.y + mat.m7 * vec.z,
								mat.m2 * vec.x + mat.m5 * vec.y + mat.m8 * vec.z);
		}

		public void SetRotateX(float radians)
		{
			m0 = 1;
			m4 = (float)Math.Cos(radians);
			m5 = (float)Math.Sin(radians);
			m7 = (float)-Math.Sin(radians);
			m8 = (float)Math.Cos(radians);
		}

		public void SetRotateY(float radians)
		{
			m0 = (float)Math.Cos(radians);
			m2 = (float)-Math.Sin(radians);
			m4 = 1;
			m6 = (float)Math.Sin(radians);
			m8 = (float)Math.Cos(radians);
		}

		public void SetRotateZ(float radians)
		{
			m0 = (float)Math.Cos(radians);
			m1 = (float)Math.Sin(radians);
			m3 = (float)-Math.Sin(radians);
			m4 = (float)Math.Cos(radians);
			m8 = 1;
		}
	}
}
