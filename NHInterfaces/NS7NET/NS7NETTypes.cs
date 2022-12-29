using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace System.Data.NS7NET
{
	// Token: 0x02000008 RID: 8
	public static class Boolean
	{
		// Token: 0x06000030 RID: 48 RVA: 0x00004572 File Offset: 0x00002772
		public static bool GetValue(byte value, int bit)
		{
			return ((int)value & (int)Math.Pow(2.0, (double)bit)) != 0;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x0000458C File Offset: 0x0000278C
		public static byte SetBit(byte value, int bit)
		{
			return (byte)(value | (byte)Math.Pow(2.0, (double)bit));
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000045A2 File Offset: 0x000027A2
		public static byte ClearBit(byte value, int bit)
		{
			return (byte)(value & ~(byte)Math.Pow(2.0, (double)bit));
		}
	}
	// Token: 0x02000009 RID: 9
	public static class Byte
	{
		// Token: 0x06000033 RID: 51 RVA: 0x000045BA File Offset: 0x000027BA
		public static byte[] ToByteArray(byte value)
		{
			return new byte[]
			{
				value
			};
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000045C6 File Offset: 0x000027C6
		public static byte FromByteArray(byte[] bytes)
		{
			if (bytes.Length != 1)
			{
				throw new ArgumentException("Wrong number of bytes. Bytes array must contain 1 bytes.");
			}
			return bytes[0];
		}
	}
	// Token: 0x0200000A RID: 10
	internal class ByteArray
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000035 RID: 53 RVA: 0x000045DC File Offset: 0x000027DC
		public byte[] array
		{
			get
			{
				return this.list.ToArray();
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000045E9 File Offset: 0x000027E9
		public ByteArray()
		{
			this.list = new List<byte>();
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00004607 File Offset: 0x00002807
		public ByteArray(int size)
		{
			this.list = new List<byte>(size);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00004626 File Offset: 0x00002826
		public void Clear()
		{
			this.list = new List<byte>();
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00004633 File Offset: 0x00002833
		public void Add(byte item)
		{
			this.list.Add(item);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00004641 File Offset: 0x00002841
		public void Add(byte[] items)
		{
			this.list.AddRange(items);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x0000464F File Offset: 0x0000284F
		public void Add(ByteArray byteArray)
		{
			this.list.AddRange(byteArray.array);
		}

		// Token: 0x0400002A RID: 42
		private List<byte> list = new List<byte>();
	}
	// Token: 0x0200000B RID: 11
	public static class Class
	{
		// Token: 0x0600003C RID: 60 RVA: 0x00004664 File Offset: 0x00002864
		public static int GetClassSize(Type classType)
		{
			double num = 0.0;
			PropertyInfo[] properties = classType.GetProperties();
			int i = 0;
			while (i < properties.Length)
			{
				PropertyInfo propertyInfo = properties[i];
				string name = propertyInfo.PropertyType.Name;
				uint num2 = Utilities.ComputeStringHash(name);
				if (num2 <= 2386971688U)
				{
					if (num2 <= 1283547685U)
					{
						if (num2 != 765439473U)
						{
							if (num2 != 1283547685U)
							{
								goto IL_267;
							}
							if (!(name == "Float"))
							{
								goto IL_267;
							}
							goto IL_21F;
						}
						else if (!(name == "Int16"))
						{
							goto IL_267;
						}
					}
					else if (num2 != 1323747186U)
					{
						if (num2 != 2386971688U)
						{
							goto IL_267;
						}
						if (!(name == "Double"))
						{
							goto IL_267;
						}
						goto IL_21F;
					}
					else if (!(name == "UInt16"))
					{
						goto IL_267;
					}
					num = Math.Ceiling(num);
					if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
					{
						num += 1.0;
					}
					num += 2.0;
					goto IL_276;
				IL_21F:
					num = Math.Ceiling(num);
					if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
					{
						num += 1.0;
					}
					num += 4.0;
				}
				else
				{
					if (num2 <= 3409549631U)
					{
						if (num2 != 2711245919U)
						{
							if (num2 != 3409549631U)
							{
								goto IL_267;
							}
							if (!(name == "Byte"))
							{
								goto IL_267;
							}
							num = Math.Ceiling(num);
							num += 1.0;
							goto IL_276;
						}
						else if (!(name == "Int32"))
						{
							goto IL_267;
						}
					}
					else if (num2 != 3538687084U)
					{
						if (num2 != 3969205087U)
						{
							goto IL_267;
						}
						if (!(name == "Boolean"))
						{
							goto IL_267;
						}
						num += 0.125;
						goto IL_276;
					}
					else if (!(name == "UInt32"))
					{
						goto IL_267;
					}
					num = Math.Ceiling(num);
					if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
					{
						num += 1.0;
					}
					num += 4.0;
				}
			IL_276:
				i++;
				continue;
			IL_267:
				num += (double)Class.GetClassSize(propertyInfo.PropertyType);
				goto IL_276;
			}
			return (int)num;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000048F8 File Offset: 0x00002AF8
		public static void FromBytes(object sourceClass, Type classType, byte[] bytes)
		{
			if (bytes == null)
			{
				return;
			}
			if (bytes.Length != Class.GetClassSize(classType))
			{
				return;
			}
			double num = 0.0;
			PropertyInfo[] properties = sourceClass.GetType().GetProperties();
			int i = 0;
			while (i < properties.Length)
			{
				PropertyInfo propertyInfo = properties[i];
				string name = propertyInfo.PropertyType.Name;
				uint num2 = Utilities.ComputeStringHash(name);
				if (num2 <= 2386971688U)
				{
					if (num2 != 765439473U)
					{
						if (num2 != 1323747186U)
						{
							if (num2 != 2386971688U)
							{
								goto IL_424;
							}
							if (!(name == "Double"))
							{
								goto IL_424;
							}
							num = Math.Ceiling(num);
							if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
							{
								num += 1.0;
							}
							propertyInfo.SetValue(sourceClass, Double.FromByteArray(new byte[]
							{
								bytes[(int)num],
								bytes[(int)num + 1],
								bytes[(int)num + 2],
								bytes[(int)num + 3]
							}), null);
							num += 4.0;
						}
						else
						{
							if (!(name == "UInt16"))
							{
								goto IL_424;
							}
							num = Math.Ceiling(num);
							if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
							{
								num += 1.0;
							}
							propertyInfo.SetValue(sourceClass, Word.FromBytes(bytes[(int)num + 1], bytes[(int)num]), null);
							num += 2.0;
						}
					}
					else
					{
						if (!(name == "Int16"))
						{
							goto IL_424;
						}
						num = Math.Ceiling(num);
						if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
						{
							num += 1.0;
						}
						ushort input = Word.FromBytes(bytes[(int)num + 1], bytes[(int)num]);
						propertyInfo.SetValue(sourceClass, input.ConvertToShort(), null);
						num += 2.0;
					}
				}
				else if (num2 <= 3409549631U)
				{
					if (num2 != 2711245919U)
					{
						if (num2 != 3409549631U)
						{
							goto IL_424;
						}
						if (!(name == "Byte"))
						{
							goto IL_424;
						}
						num = Math.Ceiling(num);
						propertyInfo.SetValue(sourceClass, bytes[(int)num], null);
						num += 1.0;
					}
					else
					{
						if (!(name == "Int32"))
						{
							goto IL_424;
						}
						num = Math.Ceiling(num);
						if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
						{
							num += 1.0;
						}
						uint input2 = DWord.FromBytes(bytes[(int)num + 3], bytes[(int)num + 2], bytes[(int)num + 1], bytes[(int)num]);
						propertyInfo.SetValue(sourceClass, input2.ConvertToInt(), null);
						num += 4.0;
					}
				}
				else if (num2 != 3538687084U)
				{
					if (num2 != 3969205087U)
					{
						goto IL_424;
					}
					if (!(name == "Boolean"))
					{
						goto IL_424;
					}
					int num3 = (int)Math.Floor(num);
					int num4 = (int)((num - (double)num3) / 0.125);
					if (((int)bytes[num3] & (int)Math.Pow(2.0, (double)num4)) != 0)
					{
						propertyInfo.SetValue(sourceClass, true, null);
					}
					else
					{
						propertyInfo.SetValue(sourceClass, false, null);
					}
					num += 0.125;
				}
				else
				{
					if (!(name == "UInt32"))
					{
						goto IL_424;
					}
					num = Math.Ceiling(num);
					if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
					{
						num += 1.0;
					}
					propertyInfo.SetValue(sourceClass, DWord.FromBytes(bytes[(int)num], bytes[(int)num + 1], bytes[(int)num + 2], bytes[(int)num + 3]), null);
					num += 4.0;
				}
			IL_481:
				i++;
				continue;
			IL_424:
				byte[] array = new byte[Class.GetClassSize(propertyInfo.PropertyType)];
				if (array.Length != 0)
				{
					Buffer.BlockCopy(bytes, (int)Math.Ceiling(num), array, 0, array.Length);
					object obj = Activator.CreateInstance(propertyInfo.PropertyType);
					Class.FromBytes(obj, propertyInfo.PropertyType, array);
					propertyInfo.SetValue(sourceClass, obj, null);
					num += (double)array.Length;
					goto IL_481;
				}
				goto IL_481;
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00004D98 File Offset: 0x00002F98
		public static byte[] ToBytes(object sourceClass)
		{
			byte[] array = new byte[Class.GetClassSize(sourceClass.GetType())];
			double num = 0.0;
			foreach (PropertyInfo propertyInfo in sourceClass.GetType().GetProperties())
			{
				byte[] array2 = null;
				string name = propertyInfo.PropertyType.Name;
				uint num2 = Utilities.ComputeStringHash(name);
				if (num2 <= 2386971688U)
				{
					if (num2 != 765439473U)
					{
						if (num2 != 1323747186U)
						{
							if (num2 == 2386971688U)
							{
								if (name == "Double")
								{
									array2 = Double.ToByteArray((double)propertyInfo.GetValue(sourceClass, null));
								}
							}
						}
						else if (name == "UInt16")
						{
							array2 = Word.ToByteArray((ushort)propertyInfo.GetValue(sourceClass, null));
						}
					}
					else if (name == "Int16")
					{
						array2 = Int.ToByteArray((short)propertyInfo.GetValue(sourceClass, null));
					}
				}
				else if (num2 <= 3409549631U)
				{
					if (num2 != 2711245919U)
					{
						if (num2 == 3409549631U)
						{
							if (name == "Byte")
							{
								num = (double)((int)Math.Ceiling(num));
								int num3 = (int)num;
								array[num3] = (byte)propertyInfo.GetValue(sourceClass, null);
								num += 1.0;
							}
						}
					}
					else if (name == "Int32")
					{
						array2 = DInt.ToByteArray((int)propertyInfo.GetValue(sourceClass, null));
					}
				}
				else if (num2 != 3538687084U)
				{
					if (num2 == 3969205087U)
					{
						if (name == "Boolean")
						{
							int num3 = (int)Math.Floor(num);
							int num4 = (int)((num - (double)num3) / 0.125);
							if ((bool)propertyInfo.GetValue(sourceClass, null))
							{
								byte[] array3 = array;
								int num5 = num3;
								array3[num5] |= (byte)Math.Pow(2.0, (double)num4);
							}
							else
							{
								byte[] array4 = array;
								int num6 = num3;
								array4[num6] &= (byte)~(byte)Math.Pow(2.0, (double)num4);
							}
							num += 0.125;
						}
					}
				}
				else if (name == "UInt32")
				{
					array2 = DWord.ToByteArray((uint)propertyInfo.GetValue(sourceClass, null));
				}
				if (array2 != null)
				{
					num = Math.Ceiling(num);
					if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
					{
						num += 1.0;
					}
					int num3 = (int)num;
					for (int j = 0; j < array2.Length; j++)
					{
						array[num3 + j] = array2[j];
					}
					num += (double)array2.Length;
				}
			}
			return array;
		}
	}
	// Token: 0x0200000C RID: 12
	public static class Counter
	{
		// Token: 0x0600003F RID: 63 RVA: 0x0000508F File Offset: 0x0000328F
		public static ushort FromByteArray(byte[] bytes)
		{
			if (bytes.Length != 2)
			{
				throw new ArgumentException("Wrong number of bytes. Bytes array must contain 2 bytes.");
			}
			return Counter.FromBytes(bytes[1], bytes[0]);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x000050AD File Offset: 0x000032AD
		public static ushort FromBytes(byte LoVal, byte HiVal)
		{
			return (ushort)((int)HiVal * 256 + (int)LoVal);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x000050BC File Offset: 0x000032BC
		public static byte[] ToByteArray(ushort value)
		{
			byte[] array = new byte[2];
			int num = 2;
			long num2 = (long)((ulong)value);
			for (int i = 0; i < num; i++)
			{
				long num3 = (long)Math.Pow(256.0, (double)i);
				long num4 = num2 / num3;
				array[num - i - 1] = (byte)(num4 & 255L);
				num2 -= (long)((ulong)array[num - i - 1] * (ulong)num3);
			}
			return array;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x0000511C File Offset: 0x0000331C
		public static byte[] ToByteArray(ushort[] value)
		{
			ByteArray byteArray = new ByteArray();
			foreach (ushort value2 in value)
			{
				byteArray.Add(Counter.ToByteArray(value2));
			}
			return byteArray.array;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00005158 File Offset: 0x00003358
		public static ushort[] ToArray(byte[] bytes)
		{
			ushort[] array = new ushort[bytes.Length / 2];
			int num = 0;
			for (int i = 0; i < bytes.Length / 2; i++)
			{
				array[i] = Counter.FromByteArray(new byte[]
				{
					bytes[num++],
					bytes[num++]
				});
			}
			return array;
		}
	}
	// Token: 0x0200000D RID: 13
	public class DataItem
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000044 RID: 68 RVA: 0x000051A5 File Offset: 0x000033A5
		// (set) Token: 0x06000045 RID: 69 RVA: 0x000051AD File Offset: 0x000033AD
		public DataType DataType { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000046 RID: 70 RVA: 0x000051B6 File Offset: 0x000033B6
		// (set) Token: 0x06000047 RID: 71 RVA: 0x000051BE File Offset: 0x000033BE
		public VarType VarType { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000048 RID: 72 RVA: 0x000051C7 File Offset: 0x000033C7
		// (set) Token: 0x06000049 RID: 73 RVA: 0x000051CF File Offset: 0x000033CF
		public int DB { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600004A RID: 74 RVA: 0x000051D8 File Offset: 0x000033D8
		// (set) Token: 0x0600004B RID: 75 RVA: 0x000051E0 File Offset: 0x000033E0
		public int StartByteAdr { get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600004C RID: 76 RVA: 0x000051E9 File Offset: 0x000033E9
		// (set) Token: 0x0600004D RID: 77 RVA: 0x000051F1 File Offset: 0x000033F1
		public int Count { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600004E RID: 78 RVA: 0x000051FA File Offset: 0x000033FA
		// (set) Token: 0x0600004F RID: 79 RVA: 0x00005202 File Offset: 0x00003402
		public object Value { get; set; }

		// Token: 0x06000050 RID: 80 RVA: 0x0000520B File Offset: 0x0000340B
		public DataItem()
		{
			this.VarType = VarType.Byte;
			this.Count = 1;
		}
	}
	// Token: 0x0200000E RID: 14
	public static class DInt
	{
		// Token: 0x06000051 RID: 81 RVA: 0x00005221 File Offset: 0x00003421
		public static int FromByteArray(byte[] bytes)
		{
			if (bytes.Length != 4)
			{
				throw new ArgumentException("Wrong number of bytes. Bytes array must contain 4 bytes.");
			}
			return DInt.FromBytes(bytes[3], bytes[2], bytes[1], bytes[0]);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00005248 File Offset: 0x00003448
		public static int FromBytes(byte v1, byte v2, byte v3, byte v4)
		{
			return (int)((double)v1 + (double)v2 * Math.Pow(2.0, 8.0) + (double)v3 * Math.Pow(2.0, 16.0) + (double)v4 * Math.Pow(2.0, 24.0));
		}

		// Token: 0x06000053 RID: 83 RVA: 0x000052AC File Offset: 0x000034AC
		public static byte[] ToByteArray(int value)
		{
			byte[] array = new byte[4];
			int num = 4;
			long num2 = (long)value;
			for (int i = 0; i < num; i++)
			{
				long num3 = (long)Math.Pow(256.0, (double)i);
				long num4 = num2 / num3;
				array[num - i - 1] = (byte)(num4 & 255L);
				num2 -= (long)((ulong)array[num - i - 1] * (ulong)num3);
			}
			return array;
		}

		// Token: 0x06000054 RID: 84 RVA: 0x0000530C File Offset: 0x0000350C
		public static byte[] ToByteArray(int[] value)
		{
			ByteArray byteArray = new ByteArray();
			foreach (int value2 in value)
			{
				byteArray.Add(DInt.ToByteArray(value2));
			}
			return byteArray.array;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00005348 File Offset: 0x00003548
		public static int[] ToArray(byte[] bytes)
		{
			int[] array = new int[bytes.Length / 4];
			int num = 0;
			for (int i = 0; i < bytes.Length / 4; i++)
			{
				array[i] = DInt.FromByteArray(new byte[]
				{
					bytes[num++],
					bytes[num++],
					bytes[num++],
					bytes[num++]
				});
			}
			return array;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000053A9 File Offset: 0x000035A9
		public static int CDWord(long value)
		{
			if (value > 2147483647L)
			{
				var minVal = int.MinValue;
				value -= (long)((ulong)minVal);
				value = (long)((ulong)minVal - (ulong)value);
				value *= -1L;
			}
			return (int)value;
		}
	}
	// Token: 0x0200000F RID: 15
	public static class Double
	{
		// Token: 0x06000057 RID: 87 RVA: 0x000053D0 File Offset: 0x000035D0
		public static double FromByteArray(byte[] bytes)
		{
			if (bytes.Length != 4)
			{
				throw new ArgumentException("Wrong number of bytes. Bytes array must contain 4 bytes.");
			}
			byte b = bytes[0];
			byte b2 = bytes[1];
			byte b3 = bytes[2];
			byte b4 = bytes[3];
			if (b + b2 + b3 + b4 == 0)
			{
				return 0.0;
			}
			string text = Double.ValToBinString(b) + Double.ValToBinString(b2) + Double.ValToBinString(b3) + Double.ValToBinString(b4);
			int num = int.Parse(text.Substring(0, 1));
			int num2 = text.Substring(1, 8).BinStringToInt32();
			string text2 = text.Substring(9, 23);
			double num3 = 1.0;
			double num4 = 1.0;
			for (int i = 0; i <= 22; i++)
			{
				num4 /= 2.0;
				if (text2.Substring(i, 1) == "1")
				{
					num3 += num4;
				}
			}
			return Math.Pow(-1.0, (double)num) * Math.Pow(2.0, (double)(num2 - 127)) * num3;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000054D2 File Offset: 0x000036D2
		public static double FromDWord(int value)
		{
			return Double.FromByteArray(DInt.ToByteArray(value));
		}

		// Token: 0x06000059 RID: 89 RVA: 0x0000248F File Offset: 0x0000068F
		public static double FromDWord(uint value)
		{
			return Double.FromByteArray(DWord.ToByteArray(value));
		}

		// Token: 0x0600005A RID: 90 RVA: 0x000054E0 File Offset: 0x000036E0
		public static byte[] ToByteArray(double value)
		{
			double num = value;
			byte[] array = new byte[4];
			if (num != 0.0)
			{
				string text;
				if (num < 0.0)
				{
					num *= -1.0;
					text = "1";
				}
				else
				{
					text = "0";
				}
				int num2 = (int)Math.Floor(Math.Log(num) / Math.Log(2.0));
				num = num / Math.Pow(2.0, (double)num2) - 1.0;
				text += Double.ValToBinString((byte)(num2 + 127));
				for (int i = 1; i <= 23; i++)
				{
					if (num - Math.Pow(2.0, (double)(-(double)i)) >= 0.0)
					{
						num -= Math.Pow(2.0, (double)(-(double)i));
						text += "1";
					}
					else
					{
						text += "0";
					}
				}
				array[0] = Double.BinStringToByte(text.Substring(0, 8)).Value;
				array[1] = Double.BinStringToByte(text.Substring(8, 8)).Value;
				array[2] = Double.BinStringToByte(text.Substring(16, 8)).Value;
				array[3] = Double.BinStringToByte(text.Substring(24, 8)).Value;
			}
			else
			{
				array[0] = 0;
				array[1] = 0;
				array[2] = 0;
				array[3] = 0;
			}
			return array;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00005658 File Offset: 0x00003858
		public static byte[] ToByteArray(double[] value)
		{
			ByteArray byteArray = new ByteArray();
			foreach (double value2 in value)
			{
				byteArray.Add(Double.ToByteArray(value2));
			}
			return byteArray.array;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00005694 File Offset: 0x00003894
		public static double[] ToArray(byte[] bytes)
		{
			double[] array = new double[bytes.Length / 4];
			int num = 0;
			for (int i = 0; i < bytes.Length / 4; i++)
			{
				array[i] = Double.FromByteArray(new byte[]
				{
					bytes[num++],
					bytes[num++],
					bytes[num++],
					bytes[num++]
				});
			}
			return array;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x000056F8 File Offset: 0x000038F8
		private static string ValToBinString(byte value)
		{
			string text = "";
			for (int i = 7; i >= 0; i += -1)
			{
				if ((value & (byte)Math.Pow(2.0, (double)i)) > 0)
				{
					text += "1";
				}
				else
				{
					text += "0";
				}
			}
			return text;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00005748 File Offset: 0x00003948
		private static byte? BinStringToByte(string txt)
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
	}
	// Token: 0x02000010 RID: 16
	public static class DWord
	{
		// Token: 0x0600005F RID: 95 RVA: 0x000057AC File Offset: 0x000039AC
		public static uint FromByteArray(byte[] bytes)
		{
			return DWord.FromBytes(bytes[3], bytes[2], bytes[1], bytes[0]);
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000057C0 File Offset: 0x000039C0
		public static uint FromBytes(byte v1, byte v2, byte v3, byte v4)
		{
			return (uint)((double)v1 + (double)v2 * Math.Pow(2.0, 8.0) + (double)v3 * Math.Pow(2.0, 16.0) + (double)v4 * Math.Pow(2.0, 24.0));
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00005824 File Offset: 0x00003A24
		public static byte[] ToByteArray(uint value)
		{
			byte[] array = new byte[4];
			int num = 4;
			long num2 = (long)((ulong)value);
			for (int i = 0; i < num; i++)
			{
				long num3 = (long)Math.Pow(256.0, (double)i);
				long num4 = num2 / num3;
				array[num - i - 1] = (byte)(num4 & 255L);
				num2 -= (long)((ulong)array[num - i - 1] * (ulong)num3);
			}
			return array;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00005884 File Offset: 0x00003A84
		public static byte[] ToByteArray(uint[] value)
		{
			ByteArray byteArray = new ByteArray();
			foreach (uint value2 in value)
			{
				byteArray.Add(DWord.ToByteArray(value2));
			}
			return byteArray.array;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x000058C0 File Offset: 0x00003AC0
		public static uint[] ToArray(byte[] bytes)
		{
			uint[] array = new uint[bytes.Length / 4];
			int num = 0;
			for (int i = 0; i < bytes.Length / 4; i++)
			{
				array[i] = DWord.FromByteArray(new byte[]
				{
					bytes[num++],
					bytes[num++],
					bytes[num++],
					bytes[num++]
				});
			}
			return array;
		}
	}
	// Token: 0x02000011 RID: 17
	public static class Int
	{
		// Token: 0x06000064 RID: 100 RVA: 0x00005921 File Offset: 0x00003B21
		public static short FromByteArray(byte[] bytes)
		{
			if (bytes.Length != 2)
			{
				throw new ArgumentException("Wrong number of bytes. Bytes array must contain 2 bytes.");
			}
			return Int.FromBytes(bytes[1], bytes[0]);
		}

		// Token: 0x06000065 RID: 101 RVA: 0x0000593F File Offset: 0x00003B3F
		public static short FromBytes(byte LoVal, byte HiVal)
		{
			return (short)((int)HiVal * 256 + (int)LoVal);
		}

		// Token: 0x06000066 RID: 102 RVA: 0x0000594C File Offset: 0x00003B4C
		public static byte[] ToByteArray(short value)
		{
			byte[] array = new byte[2];
			int num = 2;
			long num2 = (long)value;
			for (int i = 0; i < num; i++)
			{
				long num3 = (long)Math.Pow(256.0, (double)i);
				long num4 = num2 / num3;
				array[num - i - 1] = (byte)(num4 & 255L);
				num2 -= (long)((ulong)array[num - i - 1] * (ulong)num3);
			}
			return array;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000059AC File Offset: 0x00003BAC
		public static byte[] ToByteArray(short[] value)
		{
			ByteArray byteArray = new ByteArray();
			foreach (short value2 in value)
			{
				byteArray.Add(Int.ToByteArray(value2));
			}
			return byteArray.array;
		}

		// Token: 0x06000068 RID: 104 RVA: 0x000059E8 File Offset: 0x00003BE8
		public static short[] ToArray(byte[] bytes)
		{
			short[] array = new short[bytes.Length / 2];
			int num = 0;
			for (int i = 0; i < bytes.Length / 2; i++)
			{
				array[i] = Int.FromByteArray(new byte[]
				{
					bytes[num++],
					bytes[num++]
				});
			}
			return array;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00005A35 File Offset: 0x00003C35
		public static short CWord(int value)
		{
			if (value > 32767)
			{
				value -= 32768;
				value = 32768 - value;
				value *= -1;
			}
			return (short)value;
		}
	}
	// Token: 0x02000012 RID: 18
	public static class String
	{
		// Token: 0x0600006A RID: 106 RVA: 0x00005A58 File Offset: 0x00003C58
		public static byte[] ToByteArray(string value)
		{
			char[] array = value.ToCharArray();
			byte[] array2 = new byte[value.Length];
			for (int i = 0; i <= array.Length - 1; i++)
			{
				array2[i] = (byte)String.Asc(array[i].ToString());
			}
			return array2;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00005A9E File Offset: 0x00003C9E
		public static string FromByteArray(byte[] bytes)
		{
			return Encoding.ASCII.GetString(bytes);
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00005AAC File Offset: 0x00003CAC
		private static int Asc(string s)
		{
			byte[] bytes = Encoding.ASCII.GetBytes(s);
			if (bytes.Length != 0)
			{
				return (int)bytes[0];
			}
			return 0;
		}
	}
	// Token: 0x02000013 RID: 19
	public static class Struct
	{
		// Token: 0x0600006D RID: 109 RVA: 0x00005AD0 File Offset: 0x00003CD0
		public static int GetStructSize(Type structType)
		{
			double num = 0.0;
			FieldInfo[] fields = structType.GetFields();
			int i = 0;
			while (i < fields.Length)
			{
				FieldInfo fieldInfo = fields[i];
				string name = fieldInfo.FieldType.Name;
				uint num2 = Utilities.ComputeStringHash(name);
				if (num2 <= 2386971688U)
				{
					if (num2 <= 1283547685U)
					{
						if (num2 != 765439473U)
						{
							if (num2 != 1283547685U)
							{
								goto IL_267;
							}
							if (!(name == "Float"))
							{
								goto IL_267;
							}
							goto IL_21F;
						}
						else if (!(name == "Int16"))
						{
							goto IL_267;
						}
					}
					else if (num2 != 1323747186U)
					{
						if (num2 != 2386971688U)
						{
							goto IL_267;
						}
						if (!(name == "Double"))
						{
							goto IL_267;
						}
						goto IL_21F;
					}
					else if (!(name == "UInt16"))
					{
						goto IL_267;
					}
					num = Math.Ceiling(num);
					if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
					{
						num += 1.0;
					}
					num += 2.0;
					goto IL_276;
				IL_21F:
					num = Math.Ceiling(num);
					if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
					{
						num += 1.0;
					}
					num += 4.0;
				}
				else
				{
					if (num2 <= 3409549631U)
					{
						if (num2 != 2711245919U)
						{
							if (num2 != 3409549631U)
							{
								goto IL_267;
							}
							if (!(name == "Byte"))
							{
								goto IL_267;
							}
							num = Math.Ceiling(num);
							num += 1.0;
							goto IL_276;
						}
						else if (!(name == "Int32"))
						{
							goto IL_267;
						}
					}
					else if (num2 != 3538687084U)
					{
						if (num2 != 3969205087U)
						{
							goto IL_267;
						}
						if (!(name == "Boolean"))
						{
							goto IL_267;
						}
						num += 0.125;
						goto IL_276;
					}
					else if (!(name == "UInt32"))
					{
						goto IL_267;
					}
					num = Math.Ceiling(num);
					if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
					{
						num += 1.0;
					}
					num += 4.0;
				}
			IL_276:
				i++;
				continue;
			IL_267:
				num += (double)Struct.GetStructSize(fieldInfo.FieldType);
				goto IL_276;
			}
			return (int)num;
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00005D64 File Offset: 0x00003F64
		public static object FromBytes(Type structType, byte[] bytes)
		{
			if (bytes == null)
			{
				return null;
			}
			if (bytes.Length != Struct.GetStructSize(structType))
			{
				return null;
			}
			double num = 0.0;
			object obj = Activator.CreateInstance(structType);
			FieldInfo[] fields = obj.GetType().GetFields();
			int i = 0;
			while (i < fields.Length)
			{
				FieldInfo fieldInfo = fields[i];
				string name = fieldInfo.FieldType.Name;
				uint num2 = Utilities.ComputeStringHash(name);
				if (num2 <= 2386971688U)
				{
					if (num2 != 765439473U)
					{
						if (num2 != 1323747186U)
						{
							if (num2 != 2386971688U)
							{
								goto IL_427;
							}
							if (!(name == "Double"))
							{
								goto IL_427;
							}
							num = Math.Ceiling(num);
							if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
							{
								num += 1.0;
							}
							fieldInfo.SetValue(obj, Double.FromByteArray(new byte[]
							{
								bytes[(int)num],
								bytes[(int)num + 1],
								bytes[(int)num + 2],
								bytes[(int)num + 3]
							}));
							num += 4.0;
						}
						else
						{
							if (!(name == "UInt16"))
							{
								goto IL_427;
							}
							num = Math.Ceiling(num);
							if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
							{
								num += 1.0;
							}
							fieldInfo.SetValue(obj, Word.FromBytes(bytes[(int)num + 1], bytes[(int)num]));
							num += 2.0;
						}
					}
					else
					{
						if (!(name == "Int16"))
						{
							goto IL_427;
						}
						num = Math.Ceiling(num);
						if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
						{
							num += 1.0;
						}
						ushort input = Word.FromBytes(bytes[(int)num + 1], bytes[(int)num]);
						fieldInfo.SetValue(obj, input.ConvertToShort());
						num += 2.0;
					}
				}
				else if (num2 <= 3409549631U)
				{
					if (num2 != 2711245919U)
					{
						if (num2 != 3409549631U)
						{
							goto IL_427;
						}
						if (!(name == "Byte"))
						{
							goto IL_427;
						}
						num = Math.Ceiling(num);
						fieldInfo.SetValue(obj, bytes[(int)num]);
						num += 1.0;
					}
					else
					{
						if (!(name == "Int32"))
						{
							goto IL_427;
						}
						num = Math.Ceiling(num);
						if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
						{
							num += 1.0;
						}
						uint input2 = DWord.FromBytes(bytes[(int)num + 3], bytes[(int)num + 2], bytes[(int)num + 1], bytes[(int)num]);
						fieldInfo.SetValue(obj, input2.ConvertToInt());
						num += 4.0;
					}
				}
				else if (num2 != 3538687084U)
				{
					if (num2 != 3969205087U)
					{
						goto IL_427;
					}
					if (!(name == "Boolean"))
					{
						goto IL_427;
					}
					int num3 = (int)Math.Floor(num);
					int num4 = (int)((num - (double)num3) / 0.125);
					if (((int)bytes[num3] & (int)Math.Pow(2.0, (double)num4)) != 0)
					{
						fieldInfo.SetValue(obj, true);
					}
					else
					{
						fieldInfo.SetValue(obj, false);
					}
					num += 0.125;
				}
				else
				{
					if (!(name == "UInt32"))
					{
						goto IL_427;
					}
					num = Math.Ceiling(num);
					if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
					{
						num += 1.0;
					}
					fieldInfo.SetValue(obj, DWord.FromBytes(bytes[(int)num], bytes[(int)num + 1], bytes[(int)num + 2], bytes[(int)num + 3]));
					num += 4.0;
				}
			IL_471:
				i++;
				continue;
			IL_427:
				byte[] array = new byte[Struct.GetStructSize(fieldInfo.FieldType)];
				if (array.Length != 0)
				{
					Buffer.BlockCopy(bytes, (int)Math.Ceiling(num), array, 0, array.Length);
					fieldInfo.SetValue(obj, Struct.FromBytes(fieldInfo.FieldType, array));
					num += (double)array.Length;
					goto IL_471;
				}
				goto IL_471;
			}
			return obj;
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000061F4 File Offset: 0x000043F4
		public static byte[] ToBytes(object structValue)
		{
			Type type = structValue.GetType();
			byte[] array = new byte[Struct.GetStructSize(type)];
			double num = 0.0;
			foreach (FieldInfo fieldInfo in type.GetFields())
			{
				byte[] array2 = null;
				string name = fieldInfo.FieldType.Name;
				uint num2 = Utilities.ComputeStringHash(name);
				if (num2 <= 2386971688U)
				{
					if (num2 != 765439473U)
					{
						if (num2 != 1323747186U)
						{
							if (num2 == 2386971688U)
							{
								if (name == "Double")
								{
									array2 = Double.ToByteArray((double)fieldInfo.GetValue(structValue));
								}
							}
						}
						else if (name == "UInt16")
						{
							array2 = Word.ToByteArray((ushort)fieldInfo.GetValue(structValue));
						}
					}
					else if (name == "Int16")
					{
						array2 = Int.ToByteArray((short)fieldInfo.GetValue(structValue));
					}
				}
				else if (num2 <= 3409549631U)
				{
					if (num2 != 2711245919U)
					{
						if (num2 == 3409549631U)
						{
							if (name == "Byte")
							{
								num = (double)((int)Math.Ceiling(num));
								int num3 = (int)num;
								array[num3] = (byte)fieldInfo.GetValue(structValue);
								num += 1.0;
							}
						}
					}
					else if (name == "Int32")
					{
						array2 = DInt.ToByteArray((int)fieldInfo.GetValue(structValue));
					}
				}
				else if (num2 != 3538687084U)
				{
					if (num2 == 3969205087U)
					{
						if (name == "Boolean")
						{
							int num3 = (int)Math.Floor(num);
							int num4 = (int)((num - (double)num3) / 0.125);
							if ((bool)fieldInfo.GetValue(structValue))
							{
								byte[] array3 = array;
								int num5 = num3;
								array3[num5] |= (byte)Math.Pow(2.0, (double)num4);
							}
							else
							{
								byte[] array4 = array;
								int num6 = num3;
								array4[num6] &= (byte)~(byte)Math.Pow(2.0, (double)num4);
							}
							num += 0.125;
						}
					}
				}
				else if (name == "UInt32")
				{
					array2 = DWord.ToByteArray((uint)fieldInfo.GetValue(structValue));
				}
				if (array2 != null)
				{
					num = Math.Ceiling(num);
					if (num / 2.0 - Math.Floor(num / 2.0) > 0.0)
					{
						num += 1.0;
					}
					int num3 = (int)num;
					for (int j = 0; j < array2.Length; j++)
					{
						array[num3 + j] = array2[j];
					}
					num += (double)array2.Length;
				}
			}
			return array;
		}
	}
	// Token: 0x02000014 RID: 20
	public static class Timer
	{
		// Token: 0x06000070 RID: 112 RVA: 0x000064E0 File Offset: 0x000046E0
		public static double FromByteArray(byte[] bytes)
		{
			string text = ((short)Word.FromBytes(bytes[1], bytes[0])).ValToBinString();
			double num = (double)text.Substring(4, 4).BinStringToInt32() * 100.0;
			num += (double)text.Substring(8, 4).BinStringToInt32() * 10.0;
			num += (double)text.Substring(12, 4).BinStringToInt32();
			string a = text.Substring(2, 2);
			if (!(a == "00"))
			{
				if (!(a == "01"))
				{
					if (!(a == "10"))
					{
						if (a == "11")
						{
							num *= 10.0;
						}
					}
					else
					{
						num *= 1.0;
					}
				}
				else
				{
					num *= 0.1;
				}
			}
			else
			{
				num *= 0.01;
			}
			return num;
		}

		// Token: 0x06000071 RID: 113 RVA: 0x000065CC File Offset: 0x000047CC
		public static byte[] ToByteArray(ushort value)
		{
			byte[] array = new byte[2];
			int num = 2;
			long num2 = (long)((ulong)value);
			for (int i = 0; i < num; i++)
			{
				long num3 = (long)Math.Pow(256.0, (double)i);
				long num4 = num2 / num3;
				array[num - i - 1] = (byte)(num4 & 255L);
				num2 -= (long)((ulong)array[num - i - 1] * (ulong)num3);
			}
			return array;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x0000662C File Offset: 0x0000482C
		public static byte[] ToByteArray(ushort[] value)
		{
			ByteArray byteArray = new ByteArray();
			foreach (ushort value2 in value)
			{
				byteArray.Add(Timer.ToByteArray(value2));
			}
			return byteArray.array;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00006668 File Offset: 0x00004868
		public static double[] ToArray(byte[] bytes)
		{
			double[] array = new double[bytes.Length / 2];
			int num = 0;
			for (int i = 0; i < bytes.Length / 2; i++)
			{
				array[i] = Timer.FromByteArray(new byte[]
				{
					bytes[num++],
					bytes[num++]
				});
			}
			return array;
		}
	}
	// Token: 0x02000015 RID: 21
	public static class Word
	{
		// Token: 0x06000074 RID: 116 RVA: 0x000066B5 File Offset: 0x000048B5
		public static ushort FromByteArray(byte[] bytes)
		{
			if (bytes.Length != 2)
			{
				throw new ArgumentException("Wrong number of bytes. Bytes array must contain 2 bytes.");
			}
			return Word.FromBytes(bytes[1], bytes[0]);
		}

		// Token: 0x06000075 RID: 117 RVA: 0x000050AD File Offset: 0x000032AD
		public static ushort FromBytes(byte LoVal, byte HiVal)
		{
			return (ushort)((int)HiVal * 256 + (int)LoVal);
		}

		// Token: 0x06000076 RID: 118 RVA: 0x000066D4 File Offset: 0x000048D4
		public static byte[] ToByteArray(ushort value)
		{
			byte[] array = new byte[2];
			int num = 2;
			long num2 = (long)((ulong)value);
			for (int i = 0; i < num; i++)
			{
				long num3 = (long)Math.Pow(256.0, (double)i);
				long num4 = num2 / num3;
				array[num - i - 1] = (byte)(num4 & 255L);
				num2 -= (long)((ulong)array[num - i - 1] * (ulong)num3);
			}
			return array;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00006734 File Offset: 0x00004934
		public static byte[] ToByteArray(ushort[] value)
		{
			ByteArray byteArray = new ByteArray();
			foreach (ushort value2 in value)
			{
				byteArray.Add(Word.ToByteArray(value2));
			}
			return byteArray.array;
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00006770 File Offset: 0x00004970
		public static ushort[] ToArray(byte[] bytes)
		{
			ushort[] array = new ushort[bytes.Length / 2];
			int num = 0;
			for (int i = 0; i < bytes.Length / 2; i++)
			{
				array[i] = Word.FromByteArray(new byte[]
				{
					bytes[num++],
					bytes[num++]
				});
			}
			return array;
		}
	}
}
