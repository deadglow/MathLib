using System;
using System.Collections.Generic;
using System.Text;

namespace MathLib
{
	public struct Matrix3
	{
		public static Matrix3 Identity
		{
			get
			{
				return new Matrix3(1, 0, 0, 0, 1, 0, 0, 0, 1);
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

		public static Matrix3 operator *(Matrix3 mat, float scalar)
		{
			return new Matrix3(mat.m0 * scalar, mat.m1 * scalar, mat.m2 * scalar, mat.m3 * scalar, mat.m4 * scalar, mat.m5 * scalar, mat.m6 * scalar, mat.m7 * scalar, mat.m8 * scalar);
		}

		public Matrix3 Inverse()
		{
			//Gets matrix of minors, negates every second element, moves each element diagonally to the opposite side
			Matrix3 minors = new Matrix3
			{
				m0 = (m4 * m8 - m7 * m5),	m3 = (m1 * m8 - m7 * m2),	m6 = (m1 * m5 - m4 * m2),
				m1 = (m3 * m8 - m6 * m5),	m4 = (m0 * m8 - m6 * m2),	m7 = (m0 * m5 - m3 * m2), 
				m2 = (m3 * m7 - m4 * m6),	m5 = (m0 * m7 - m6 * m1),	m8 = (m0 * m4 - m3 * m1)
			};
			Matrix3 adjugate = new Matrix3(minors.m0, -minors.m3, minors.m6, -minors.m1, minors.m4, -minors.m7, minors.m2, -minors.m5, minors.m8);

			float determinant = m0 * minors.m0 - m3 * minors.m3 + m6 * minors.m6;

			if (determinant == 0)
				throw new Exception("Cannot divide adjugate by 0");

			return adjugate * (1 / determinant);
		}

		public void SetRotateX(float radians)
		{
			float sin = (float)Math.Sin(radians);
			float cos = (float)Math.Cos(radians);
			m0 = 1;
			m4 = cos;
			m5 = sin;
			m7 = -sin;
			m8 = cos;
		}

		public void SetRotateY(float radians)
		{
			float sin = (float)Math.Sin(radians);
			float cos = (float)Math.Cos(radians);
			m0 = cos;
			m2 = -sin;
			m4 = 1;
			m6 = sin;
			m8 = cos;
		}

		public void SetRotateZ(float radians)
		{
			float sin = (float)Math.Sin(radians);
			float cos = (float)Math.Cos(radians);
			m0 = cos;
			m1 = sin;
			m3 = -sin;
			m4 = cos;
			m8 = 1;
		}

		public Vector2 GetRight()
		{
			return new Vector2(m0, m1);
		}

		public Vector2 GetUp()
		{
			return new Vector2(m3, m4);
		}

		public float GetScaleX()
		{
			return GetRight().Magnitude();
		}

		public float GetScaleY()
		{
			return GetUp().Magnitude();
		}

		public void SetScaleX(float scale)
		{
			Vector2 right = GetRight().Normalised() * scale;

			m0 = right.x;
			m1 = right.y;
		}

		public void SetScaleY(float scale)
		{
			Vector2 up = GetUp().Normalised() * scale;

			m3 = up.x;
			m4 = up.y;
		}

		public void SetRotation(float radians)
		{
			Vector2 scale = new Vector2(GetScaleX(), GetScaleY());

			//Reset rotation axes to 0
			m0 = 1;
			m1 = 0;
			m3 = 0;
			m4 = 1;

			//Creates a new rotation matrix
			Matrix3 rotMat = Identity;
			rotMat.SetRotateZ(radians);

			//Scale x and y axis by scale x and scale y
			rotMat.m0 *= scale.x;
			rotMat.m1 *= scale.x;
			rotMat.m3 *= scale.y;
			rotMat.m4 *= scale.y;
		}
		
		public float GetRotation()
		{
			Vector2 up = GetUp().Normalised();
			return (float)Math.Atan2(up.y, up.x);
		}

		public void SetIdentity()
		{
			m0 = 1;
			m4 = 1;
			m8 = 1;
		}
	}
}
