using System;
using System.Collections.Generic;
using System.Text;

namespace MathLib
{
	class Matrix3
	{
		public float[] m = new float[9];

		public Matrix3(float m0, float m1, float m2, float m3, float m4, float m5, float m6, float m7, float m8)
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
		}
		public Matrix3() : this(0, 0, 0, 0, 0, 0, 0, 0, 0) { }

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

		public static Matrix3 operator *(Matrix3 a, Matrix3 b)
		{
			//	________Structure________
			//	|	0	|	3	|	6	|
			//	|_______|_______|_______|
			//	|	1	|	4	|	7	|
			//	|_______|_______|_______|
			//	|	2	|	5	|	8	|
			//	|_______|_______|_______|

			Matrix3 mat = new Matrix3();
			mat[0] = a[0] * b[0] + a[3] * b[1] + a[6] * b[2];
			mat[3] = a[0] * b[3] + a[3] * b[4] + a[6] * b[5];
			mat[6] = a[0] * b[6] + a[3] * b[7] + a[6] * b[8];
			mat[1] = a[1] * b[0] + a[4] * b[1] + a[7] * b[2];
			mat[4] = a[1] * b[3] + a[4] * b[4] + a[7] * b[5];
			mat[7] = a[1] * b[6] + a[4] * b[7] + a[7] * b[8];
			mat[2] = a[2] * b[0] + a[5] * b[1] + a[8] * b[2];
			mat[5] = a[2] * b[3] + a[5] * b[4] + a[8] * b[5];
			mat[8] = a[2] * b[6] + a[5] * b[7] + a[8] * b[8];

			return mat;
		}

		public static Vector3 operator *(Matrix3 mat, Vector3 vec)
		{
			return new Vector3(	mat[0] * vec.x + mat[3] * vec.y + mat[6] * vec.z,
								mat[1] * vec.x + mat[4] * vec.y + mat[7] * vec.z,
								mat[2] * vec.x + mat[5] * vec.y + mat[8] * vec.z);
		}

	}
}
