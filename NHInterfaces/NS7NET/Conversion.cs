using System;
using System.Globalization;

namespace System.Data.NS7NET
{
	// Token: 0x02000002 RID: 2
	public static class Conversion
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static int BinStringToInt32(this string txt)
		{
			int num = 0;
			for (int i = txt.Length - 1; i >= 0; i += -1)
			{
				if (int.Parse(txt.Substring(i, 1)) == 1)
				{
					num += (int)Math.Pow(2.0, (double)(txt.Length - 1 - i));
				}
			}
			return num;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020A4 File Offset: 0x000002A4
		public static byte? BinStringToByte(this string txt)
		{
			int num = 0;
			if (txt.Length == 8)
			{
				for (int i = 7; i >= 0; i += -1)
				{
					if (int.Parse(txt.Substring(i, 1)) == 1)
					{
						num += (int)Math.Pow(2.0, (double)(txt.Length - 1 - i));
					}
				}
				return new byte?((byte)num);
			}
			return null;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002108 File Offset: 0x00000308
		public static string ValToBinString(this object value)
		{
			string text = "";
			string text2;
			try
			{
				if (value.GetType().Name.IndexOf("[]") < 0)
				{
					text2 = value.GetType().Name;
					int num;
					long num2;
					if (!(text2 == "Byte"))
					{
						if (!(text2 == "Int16"))
						{
							if (!(text2 == "Int32"))
							{
								if (!(text2 == "Int64"))
								{
									throw new Exception();
								}
								num = 63;
								num2 = (long)value;
							}
							else
							{
								num = 31;
								num2 = (long)((int)value);
							}
						}
						else
						{
							num = 15;
							num2 = (long)((short)value);
						}
					}
					else
					{
						num = 7;
						num2 = (long)((ulong)((byte)value));
					}
					for (int i = num; i >= 0; i += -1)
					{
						if ((num2 & (long)Math.Pow(2.0, (double)i)) > 0L)
						{
							text += "1";
						}
						else
						{
							text += "0";
						}
					}
				}
				else
				{
					text2 = value.GetType().Name;
					if (!(text2 == "Byte[]"))
					{
						if (!(text2 == "Int16[]"))
						{
							if (!(text2 == "Int32[]"))
							{
								if (!(text2 == "Int64[]"))
								{
									throw new Exception();
								}
								int num = 63;
								byte[] array = (byte[])value;
								for (int j = 0; j <= array.Length - 1; j++)
								{
									for (int i = num; i >= 0; i += -1)
									{
										if ((array[j] & (byte)Math.Pow(2.0, (double)i)) > 0)
										{
											text += "1";
										}
										else
										{
											text += "0";
										}
									}
								}
							}
							else
							{
								int num = 31;
								int[] array2 = (int[])value;
								for (int j = 0; j <= array2.Length - 1; j++)
								{
									for (int i = num; i >= 0; i += -1)
									{
										if ((array2[j] & (int)((byte)Math.Pow(2.0, (double)i))) > 0)
										{
											text += "1";
										}
										else
										{
											text += "0";
										}
									}
								}
							}
						}
						else
						{
							int num = 15;
							short[] array3 = (short[])value;
							for (int j = 0; j <= array3.Length - 1; j++)
							{
								for (int i = num; i >= 0; i += -1)
								{
									if ((array3[j] & (short)((byte)Math.Pow(2.0, (double)i))) > 0)
									{
										text += "1";
									}
									else
									{
										text += "0";
									}
								}
							}
						}
					}
					else
					{
						int num = 7;
						byte[] array4 = (byte[])value;
						for (int j = 0; j <= array4.Length - 1; j++)
						{
							for (int i = num; i >= 0; i += -1)
							{
								if ((array4[j] & (byte)Math.Pow(2.0, (double)i)) > 0)
								{
									text += "1";
								}
								else
								{
									text += "0";
								}
							}
						}
					}
				}
				text2 = text;
			}
			catch
			{
				text2 = "";
			}
			return text2;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002408 File Offset: 0x00000608
		public static bool SelectBit(this byte data, int bitPosition)
		{
			int num = 1 << bitPosition;
			return ((int)data & num) != 0;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002422 File Offset: 0x00000622
		public static short ConvertToShort(this ushort input)
		{
			return short.Parse(input.ToString("X"), NumberStyles.HexNumber);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000243A File Offset: 0x0000063A
		public static ushort ConvertToUshort(this short input)
		{
			return ushort.Parse(input.ToString("X"), NumberStyles.HexNumber);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002452 File Offset: 0x00000652
		public static int ConvertToInt(this uint input)
		{
			return int.Parse(input.ToString("X"), NumberStyles.HexNumber);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x0000246A File Offset: 0x0000066A
		public static uint ConvertToUInt(this int input)
		{
			return uint.Parse(input.ToString("X"), NumberStyles.HexNumber);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002482 File Offset: 0x00000682
		public static uint ConvertToUInt(this double input)
		{
			return DWord.FromByteArray(System.Data.NS7NET.Double.ToByteArray(input));
		}

		// Token: 0x0600000A RID: 10 RVA: 0x0000248F File Offset: 0x0000068F
		public static double ConvertToDouble(this uint input)
		{
			return Double.FromByteArray(System.Data.NS7NET.DWord.ToByteArray(input));
		}
	}
}
