using System;
using System.Collections.Generic;
using System.Text;

namespace MathLib
{
	class Matrix4
	{
		public float[] m = new float[16];

		public Matrix4(float m0, float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8, float m9, float m10, float m11, float m12, float m13, float m14, float m15)
		{
			m[0] = m0;
			m[1] = m1;
			m[2] = m2;
			m[3] = m3;
			m[4] = m4;
			m[5] = m5;
			m[6] = m6;
			m[7] = m7;
			m[8] = m8;
			m[9] = m9;
			m[10] = m10;
			m[11] = m11;
			m[12] = m12;
			m[13] = m13;
			m[14] = m14;
			m[15] = m15;
		}
		public Matrix4() : this(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0) { }

		public float this[int i]
		{
			get
			{
				return m[i];
			}
			set
			{
				m[i] = value;
			}
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
				a[0] * b[0]  + a[4] * b[1]  + a[8]  * b[2]  + a[12] * b[3],
				a[1] * b[0]  + a[5] * b[1]  + a[9]  * b[2]  + a[13] * b[3],
				a[2] * b[0]  + a[6] * b[1]  + a[10] * b[2]  + a[14] * b[3],
				a[3] * b[0]  + a[7] * b[1]  + a[11] * b[2]  + a[15] * b[3],
				a[0] * b[4]  + a[4] * b[5]  + a[8]  * b[6]  + a[12] * b[7],
				a[1] * b[4]  + a[5] * b[5]  + a[9]  * b[6]  + a[13] * b[7],
				a[2] * b[4]  + a[6] * b[5]  + a[10] * b[6]  + a[14] * b[7],
				a[3] * b[4]  + a[7] * b[5]  + a[11] * b[6]  + a[15] * b[7],
				a[0] * b[8]  + a[4] * b[9]  + a[8]  * b[10] + a[12] * b[11],
				a[1] * b[8]  + a[5] * b[9]  + a[9]  * b[10] + a[13] * b[11],
				a[2] * b[8]  + a[6] * b[9]  + a[10] * b[10] + a[14] * b[11],
				a[3] * b[8]  + a[7] * b[9]  + a[11] * b[10] + a[15] * b[11],
				a[0] * b[12] + a[4] * b[13] + a[8]  * b[14] + a[12] * b[15],
				a[1] * b[12] + a[5] * b[13] + a[9]  * b[14] + a[13] * b[15],
				a[2] * b[12] + a[6] * b[13] + a[10] * b[14] + a[14] * b[15],
				a[3] * b[12] + a[7] * b[13] + a[11] * b[14] + a[15] * b[15]
				);
		}

		public static Vector4 operator *(Matrix4 mat, Vector4 vec)
		{
			return new Vector4(	mat[0] * vec.x + mat[4] * vec.y + mat[8]  * vec.z + mat[12] * vec.w,
								mat[1] * vec.x + mat[5] * vec.y + mat[9]  * vec.z + mat[13] * vec.w,
								mat[2] * vec.x + mat[6] * vec.y + mat[10] * vec.z + mat[14] * vec.w,
								mat[3] * vec.w + mat[7] * vec.w + mat[11] * vec.w + mat[15] * vec.w);
		}

		public void SetRotateX(float radians)
		{
			m[4] = (float)Math.Cos(radians);
			m[5] = (float)-Math.Sin(radians);
			m[7] = (float)Math.Sin(radians);
			m[8] = (float)Math.Cos(radians);
		}

		public void SetRotate(float radians)
		{

		}
	}
}
