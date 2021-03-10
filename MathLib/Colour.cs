using System;
using System.Collections.Generic;
using System.Text;

namespace MathLib
{
	struct Colour
	{
		public uint Value { get; private set; }

		public Colour(byte red, byte green, byte blue, byte alpha)
		{
			Value = (uint)((red << 24) | (green << 16) | (blue << 8) | alpha);
		}

		public byte GetRed()
		{
			return (byte)(Value >> 24);
		}

		public void SetRed(byte red)
		{
			Value = (Value & 0x00FFFFFF) | (uint)(red << 24);
		}

		public byte GetGreen()
		{
			return (byte)(Value >> 16);
		}

		public void SetGreen(byte green)
		{
			Value = (Value & 0xFF00FFFF) | (uint)(green << 16);
		}

		public byte GetBlue()
		{
			return (byte)(Value >> 8);
		}

		public void SetBlue(byte blue)
		{
			Value = (Value & 0xFFFF00FF) | (uint)(blue << 8);
		}

		public byte GetAlpha()
		{
			return (byte)Value;
		}

		public void SetAlpha(byte alpha)
		{
			Value = (Value & 0xFFFFFF00) | alpha;
		}


	}
}
