using System;
using System.Collections.Generic;
using System.Text;

namespace MathLib
{
	public struct Matrix4
	{
		public static Matrix4 Identity
		{
			get
			{
				Matrix4 mat = new Matrix4();
				mat.SetIdentity();
				return mat;
			}
		}

		public float m0;
		public float m1;
		public float m2;
		public float m3;
		public float m4;
		public float m5;
		public float m6;
		public float m7;
		public float m8;
		public float m9;
		public float m10;
		public float m11;
		public float m12;
		public float m13;
		public float m14;
		public float m15;

		public Matrix4(float m0, float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8, float m9, float m10, float m11, float m12, float m13, float m14, float m15)
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
			this.m9 = m9;
			this.m10 = m10;
			this.m11 = m11;
			this.m12 = m12;
			this.m13 = m13;
			this.m14 = m14;
			this.m15 = m15;
		}

		public static Matrix4 operator *(Matrix4 a, Matrix4 b)
		{
			//	________Structure_______________
			//	|	0	|	4	|	8	|	12	|
			//	|_______|_______|_______|_______|
			//	|	1	|	5	|	9	|	13	|
			//	|_______|_______|_______|_______|
			//	|	2	|	6	|	10	|	14	|
			//	|_______|_______|_______|_______|
			//	|	3	|	7	|	11	|	15	|
			//	|_______|_______|_______|_______|

			return new Matrix4(
				a.m0 * b.m0  + a.m4 * b.m1  + a.m8  * b.m2  + a.m12 * b.m3,
				a.m1 * b.m0  + a.m5 * b.m1  + a.m9  * b.m2  + a.m13 * b.m3,
				a.m2 * b.m0  + a.m6 * b.m1  + a.m10 * b.m2  + a.m14 * b.m3,
				a.m3 * b.m0  + a.m7 * b.m1  + a.m11 * b.m2  + a.m15 * b.m3,
				a.m0 * b.m4  + a.m4 * b.m5  + a.m8  * b.m6  + a.m12 * b.m7,
				a.m1 * b.m4  + a.m5 * b.m5  + a.m9  * b.m6  + a.m13 * b.m7,
				a.m2 * b.m4  + a.m6 * b.m5  + a.m10 * b.m6  + a.m14 * b.m7,
				a.m3 * b.m4  + a.m7 * b.m5  + a.m11 * b.m6  + a.m15 * b.m7,
				a.m0 * b.m8  + a.m4 * b.m9  + a.m8  * b.m10 + a.m12 * b.m11,
				a.m1 * b.m8  + a.m5 * b.m9  + a.m9  * b.m10 + a.m13 * b.m11,
				a.m2 * b.m8  + a.m6 * b.m9  + a.m10 * b.m10 + a.m14 * b.m11,
				a.m3 * b.m8  + a.m7 * b.m9  + a.m11 * b.m10 + a.m15 * b.m11,
				a.m0 * b.m12 + a.m4 * b.m13 + a.m8  * b.m14 + a.m12 * b.m15,
				a.m1 * b.m12 + a.m5 * b.m13 + a.m9  * b.m14 + a.m13 * b.m15,
				a.m2 * b.m12 + a.m6 * b.m13 + a.m10 * b.m14 + a.m14 * b.m15,
				a.m3 * b.m12 + a.m7 * b.m13 + a.m11 * b.m14 + a.m15 * b.m15 );
		}

		public static Vector4 operator *(Matrix4 mat, Vector4 vec)
		{
			return new Vector4(	mat.m0 * vec.x + mat.m4 * vec.y + mat.m8  * vec.z + mat.m12 * vec.w,
								mat.m1 * vec.x + mat.m5 * vec.y + mat.m9  * vec.z + mat.m13 * vec.w,
								mat.m2 * vec.x + mat.m6 * vec.y + mat.m10 * vec.z + mat.m14 * vec.w,
								mat.m3 * vec.w + mat.m7 * vec.w + mat.m11 * vec.w + mat.m15 * vec.w);
		}

		//public static Matrix4 ScaleMatrix(Vector3 v)
		//{
		//	return new Matrix4(v.x, 0, 0, 0, v.y, 0, 0, 0, v.z, 0, 0, 0, 0, 0, 0, 0);
		//}

		public void SetRotateX(float radians)
		{
			float sin = (float)Math.Sin(radians);
			float cos = (float)Math.Cos(radians);
			SetIdentity();
			m5 = cos;
			m6 = sin;
			m9 = -sin;
			m10 = cos;
		}

		public void SetRotateY(float radians)
		{
			float sin = (float)Math.Sin(radians);
			float cos = (float)Math.Cos(radians);
			SetIdentity();
			m0 = cos;
			m2 = -sin;
			m8 = sin;
			m10 = cos;
		}

		public void SetRotateZ(float radians)
		{
			float sin = (float)Math.Sin(radians);
			float cos = (float)Math.Cos(radians);
			SetIdentity();
			m0 = cos;
			m1 = sin;
			m4 = -sin;
			m5 = cos;
		}

		public void SetIdentity()
		{
			m0 = 1;
			m5 = 1;
			m10 = 1;
			m15 = 1;
		}
	}
}
