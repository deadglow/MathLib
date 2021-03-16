using System;
using System.Collections.Generic;
using System.Text;

namespace MathLib
{
	struct Matrix2
	{
		public float[] m;

		public Matrix2(float m0, float m1, float m2, float m3)
		{
			m = new float[4];
			m[0] = m0;
			m[1] = m1;
			m[2] = m2;
			m[3] = m3;
		}

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

		public static Matrix2 operator*(Matrix2 a, Matrix2 b)
		{
			//	____Structure___
			//	|	0	|	2	|
			//	|_______|_______|
			//	|	1	|	3	|
			//	|_______|_______|

			return new Matrix2(	a[0] * b[0] + a[2] * b[1], a[0] * b[2] + a[2] * b[3],
								a[1] * b[0] + a[3] * b[1], a[1] * b[2] + a[3] * b[3]);
		}
	}
}
