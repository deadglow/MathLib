using System;
using System.Collections.Generic;
using System.Text;

namespace MathLib
{
	public struct Colour
	{
		public uint colour { get; private set; }

		public Colour(byte red, byte green, byte blue, byte alpha)
		{
			colour = (uint)((red << 24) | (green << 16) | (blue << 8) | alpha);
		}

		public byte GetRed()
		{
			return (byte)(colour >> 24);
		}

		public void SetRed(byte red)
		{
			colour = (colour & 0x00FFFFFF) | (uint)(red << 24);
		}
		public void SetRed(float val)
		{
			SetRed((byte)(uint)Math.Floor(255 * val));
		}

		public byte GetGreen()
		{
			return (byte)(colour >> 16);
		}

		public void SetGreen(byte green)
		{
			colour = (colour & 0xFF00FFFF) | (uint)(green << 16);
		}
		public void SetGreen(float val)
		{
			SetGreen((byte)(uint)Math.Floor(255 * val));
		}

		public byte GetBlue()
		{
			return (byte)(colour >> 8);
		}

		public void SetBlue(byte blue)
		{
			colour = (colour & 0xFFFF00FF) | (uint)(blue << 8);
		}
		public void SetBlue(float val)
		{
			SetBlue((byte)(uint)Math.Floor(255 * val));
		}


		public byte GetAlpha()
		{
			return (byte)colour;
		}

		public void SetAlpha(byte alpha)
		{
			colour = (colour & 0xFFFFFF00) | alpha;
		}
		public void SetAlpha(float val)
		{
			SetAlpha((byte)(uint)Math.Floor(255f * val));
		}



	}
}
