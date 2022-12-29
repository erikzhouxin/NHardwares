using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace System.Data.NS7NET
{
	// Token: 0x02000007 RID: 7
	public class Plc : IDisposable
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000B RID: 11 RVA: 0x0000249C File Offset: 0x0000069C
		// (set) Token: 0x0600000C RID: 12 RVA: 0x000024A4 File Offset: 0x000006A4
		public string IP { get; private set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000024AD File Offset: 0x000006AD
		// (set) Token: 0x0600000E RID: 14 RVA: 0x000024B5 File Offset: 0x000006B5
		public CpuType CPU { get; private set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000F RID: 15 RVA: 0x000024BE File Offset: 0x000006BE
		// (set) Token: 0x06000010 RID: 16 RVA: 0x000024C6 File Offset: 0x000006C6
		public short Rack { get; private set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000011 RID: 17 RVA: 0x000024CF File Offset: 0x000006CF
		// (set) Token: 0x06000012 RID: 18 RVA: 0x000024D7 File Offset: 0x000006D7
		public short Slot { get; private set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000013 RID: 19 RVA: 0x000024E0 File Offset: 0x000006E0
		public bool IsAvailable
		{
			get
			{
				bool result;
				using (Ping ping = new Ping())
				{
					PingReply pingReply;
					try
					{
						pingReply = ping.Send(this.IP);
					}
					catch (PingException)
					{
						pingReply = null;
					}
					result = (pingReply != null && pingReply.Status == IPStatus.Success);
				}
				return result;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000014 RID: 20 RVA: 0x00002540 File Offset: 0x00000740
		public bool IsConnected
		{
			get
			{
				bool result;
				try
				{
					if (this._mSocket == null)
					{
						result = false;
					}
					else
					{
						result = ((!this._mSocket.Poll(1000, SelectMode.SelectRead) || this._mSocket.Available != 0) && this._mSocket.Connected);
					}
				}
				catch
				{
					result = false;
				}
				return result;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000015 RID: 21 RVA: 0x000025A0 File Offset: 0x000007A0
		// (set) Token: 0x06000016 RID: 22 RVA: 0x000025A8 File Offset: 0x000007A8
		public string LastErrorString { get; private set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000017 RID: 23 RVA: 0x000025B1 File Offset: 0x000007B1
		// (set) Token: 0x06000018 RID: 24 RVA: 0x000025B9 File Offset: 0x000007B9
		public ErrorCode LastErrorCode { get; private set; }

		// Token: 0x06000019 RID: 25 RVA: 0x000025C2 File Offset: 0x000007C2
		public Plc(CpuType cpu, string ip, short rack, short slot)
		{
			this.IP = ip;
			this.CPU = cpu;
			this.Rack = rack;
			this.Slot = slot;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000025E8 File Offset: 0x000007E8
		public ErrorCode Open()
		{
			byte[] buffer = new byte[256];
			try
			{
				if (!this.IsAvailable)
				{
					throw new Exception();
				}
			}
			catch
			{
				this.LastErrorCode = ErrorCode.IPAddressNotAvailable;
				this.LastErrorString = string.Format("Destination IP-Address '{0}' is not available!", this.IP);
				return this.LastErrorCode;
			}
			try
			{
				this._mSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				this._mSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 1000);
				this._mSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 1000);
				IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(this.IP), 102);
				this._mSocket.Connect(remoteEP);
			}
			catch (Exception ex)
			{
				this.LastErrorCode = ErrorCode.ConnectionError;
				this.LastErrorString = ex.Message;
				return ErrorCode.ConnectionError;
			}
			try
			{
				byte[] array = new byte[]
				{
					3,
					0,
					0,
					22,
					17,
					224,
					0,
					0,
					0,
					46,
					0,
					193,
					2,
					1,
					0,
					194,
					2,
					3,
					0,
					192,
					1,
					9
				};
				CpuType cpu = this.CPU;
				if (cpu <= CpuType.S7300)
				{
					if (cpu == CpuType.S7200)
					{
						array[11] = 193;
						array[12] = 2;
						array[13] = 16;
						array[14] = 0;
						array[15] = 194;
						array[16] = 2;
						array[17] = 16;
						array[18] = 0;
						goto IL_241;
					}
					if (cpu != CpuType.S7300)
					{
						goto IL_23A;
					}
				}
				else
				{
					if (cpu == CpuType.S7400)
					{
						array[11] = 193;
						array[12] = 2;
						array[13] = 1;
						array[14] = 0;
						array[15] = 194;
						array[16] = 2;
						array[17] = 3;
						array[18] = (byte)(this.Rack * 2 * 16 + this.Slot);
						goto IL_241;
					}
					if (cpu != CpuType.S71200)
					{
						if (cpu != CpuType.S71500)
						{
							goto IL_23A;
						}
						array[11] = 193;
						array[12] = 2;
						array[13] = 16;
						array[14] = 2;
						array[15] = 194;
						array[16] = 2;
						array[17] = 3;
						array[18] = (byte)(this.Rack * 2 * 16 + this.Slot);
						goto IL_241;
					}
				}
				array[11] = 193;
				array[12] = 2;
				array[13] = 1;
				array[14] = 0;
				array[15] = 194;
				array[16] = 2;
				array[17] = 3;
				array[18] = (byte)(this.Rack * 2 * 16 + this.Slot);
				goto IL_241;
				IL_23A:
				return ErrorCode.WrongCPU_Type;
				IL_241:
				this._mSocket.Send(array, 22, SocketFlags.None);
				if (this._mSocket.Receive(buffer, 22, SocketFlags.None) != 22)
				{
					throw new Exception(ErrorCode.WrongNumberReceivedBytes.ToString());
				}
				byte[] buffer2 = new byte[]
				{
					3,
					0,
					0,
					25,
					2,
					240,
					128,
					50,
					1,
					0,
					0,
					byte.MaxValue,
					byte.MaxValue,
					0,
					8,
					0,
					0,
					240,
					0,
					0,
					3,
					0,
					3,
					1,
					0
				};
				this._mSocket.Send(buffer2, 25, SocketFlags.None);
				if (this._mSocket.Receive(buffer, 27, SocketFlags.None) != 27)
				{
					throw new Exception(ErrorCode.WrongNumberReceivedBytes.ToString());
				}
			}
			catch (Exception ex2)
			{
				this.LastErrorCode = ErrorCode.ConnectionError;
				this.LastErrorString = "Couldn't establish the connection to " + this.IP + ".\nMessage: " + ex2.Message;
				return ErrorCode.ConnectionError;
			}
			return ErrorCode.NoError;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002940 File Offset: 0x00000B40
		public void Close()
		{
			if (this._mSocket != null && this._mSocket.Connected)
			{
				this._mSocket.Shutdown(SocketShutdown.Both);
				this._mSocket.Close();
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002970 File Offset: 0x00000B70
		public void ReadMultipleVars(List<DataItem> dataItems)
		{
			int num = dataItems.Sum((DataItem dataItem) => this.VarTypeToByteLength(dataItem.VarType, dataItem.Count));
			if (dataItems.Count > 20)
			{
				throw new Exception("Too many vars requested");
			}
			if (num > 222)
			{
				throw new Exception("Too many bytes requested");
			}
			try
			{
				ByteArray byteArray = new ByteArray(19 + dataItems.Count * 12);
				byteArray.Add(this.ReadHeaderPackage(dataItems.Count));
				foreach (DataItem dataItem3 in dataItems)
				{
					byteArray.Add(this.CreateReadDataRequestPackage(dataItem3.DataType, dataItem3.DB, dataItem3.StartByteAdr, this.VarTypeToByteLength(dataItem3.VarType, dataItem3.Count)));
				}
				this._mSocket.Send(byteArray.array, byteArray.array.Length, SocketFlags.None);
				byte[] array = new byte[512];
				this._mSocket.Receive(array, 512, SocketFlags.None);
				if (array[21] != 255)
				{
					throw new Exception(ErrorCode.WrongNumberReceivedBytes.ToString());
				}
				int num2 = 25;
				foreach (DataItem dataItem2 in dataItems)
				{
					int num3 = this.VarTypeToByteLength(dataItem2.VarType, dataItem2.Count);
					byte[] array2 = new byte[num3];
					for (int i = 0; i < num3; i++)
					{
						array2[i] = array[i + num2];
					}
					num2 += num3 + 4;
					dataItem2.Value = this.ParseBytes(dataItem2.VarType, array2, dataItem2.Count);
				}
			}
			catch (SocketException ex)
			{
				this.LastErrorCode = ErrorCode.WriteData;
				this.LastErrorString = ex.Message;
			}
			catch (Exception ex2)
			{
				this.LastErrorCode = ErrorCode.WriteData;
				this.LastErrorString = ex2.Message;
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002BBC File Offset: 0x00000DBC
		public byte[] ReadBytes(DataType dataType, int db, int startByteAdr, int count)
		{
			List<byte> list = new List<byte>();
			int num = startByteAdr;
			while (count > 0)
			{
				int num2 = Math.Min(count, 200);
				byte[] array = this.ReadBytesWithASingleRequest(dataType, db, num, num2);
				if (array == null)
				{
					return list.ToArray();
				}
				list.AddRange(array);
				count -= num2;
				num += num2;
			}
			return list.ToArray();
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002C14 File Offset: 0x00000E14
		public object Read(DataType dataType, int db, int startByteAdr, VarType varType, int varCount)
		{
			int count = this.VarTypeToByteLength(varType, varCount);
			byte[] bytes = this.ReadBytes(dataType, db, startByteAdr, count);
			return this.ParseBytes(varType, bytes, varCount);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002C44 File Offset: 0x00000E44
		public object Read(string variable)
		{
			string text = variable.ToUpper();
			text = text.Replace(" ", "");
			object result;
			try
			{
				string text2 = text.Substring(0, 2);
				uint num = Utilities.ComputeStringHash(text2);
				int startByteAdr;
				int num3;
				if (num <= 752165258U)
				{
					if (num <= 382469260U)
					{
						if (num != 348914022U)
						{
							if (num == 382469260U)
							{
								if (text2 == "ED")
								{
									return (uint)this.Read(DataType.Input, 0, int.Parse(text.Substring(2)), VarType.DWord, 1);
								}
							}
						}
						else if (text2 == "EB")
						{
							return (byte)this.Read(DataType.Input, 0, int.Parse(text.Substring(2)), VarType.Byte, 1);
						}
					}
					else if (num != 651499544U)
					{
						if (num != 701244021U)
						{
							if (num == 752165258U)
							{
								if (text2 == "AB")
								{
									return (byte)this.Read(DataType.Output, 0, int.Parse(text.Substring(2)), VarType.Byte, 1);
								}
							}
						}
						else if (text2 == "EW")
						{
							return (ushort)this.Read(DataType.Input, 0, int.Parse(text.Substring(2)), VarType.Word, 1);
						}
					}
					else if (text2 == "AD")
					{
						return (uint)this.Read(DataType.Output, 0, int.Parse(text.Substring(2)), VarType.DWord, 1);
					}
				}
				else if (num <= 970274305U)
				{
					if (num != 919500163U)
					{
						if (num == 970274305U)
						{
							if (text2 == "AW")
							{
								return (ushort)this.Read(DataType.Output, 0, int.Parse(text.Substring(2)), VarType.Word, 1);
							}
						}
					}
					else if (text2 == "DB")
					{
						string[] array = text.Split(new char[]
						{
							'.'
						});
						if (array.Length < 2)
						{
							throw new Exception();
						}
						int db = int.Parse(array[0].Substring(2));
						string a = array[1].Substring(0, 3);
						int num2 = int.Parse(array[1].Substring(3));
						if (a == "DBB")
						{
							return (byte)this.Read(DataType.DataBlock, db, num2, VarType.Byte, 1);
						}
						if (a == "DBW")
						{
							return (ushort)this.Read(DataType.DataBlock, db, num2, VarType.Word, 1);
						}
						if (a == "DBD")
						{
							return (uint)this.Read(DataType.DataBlock, db, num2, VarType.DWord, 1);
						}
						if (!(a == "DBX"))
						{
							throw new Exception();
						}
						startByteAdr = num2;
						num3 = int.Parse(array[2]);
						if (num3 > 7)
						{
							throw new Exception();
						}
						byte b = (byte)this.Read(DataType.DataBlock, db, startByteAdr, VarType.Byte, 1);
						return new BitArray(new byte[]
						{
							b
						})[num3];
					}
				}
				else if (num != 970965853U)
				{
					if (num != 1155519662U)
					{
						if (num == 1189074900U)
						{
							if (text2 == "MD")
							{
								return (uint)this.Read(DataType.Memory, 0, int.Parse(text.Substring(2)), VarType.DWord, 1);
							}
						}
					}
					else if (text2 == "MB")
					{
						return (byte)this.Read(DataType.Memory, 0, int.Parse(text.Substring(2)), VarType.Byte, 1);
					}
				}
				else if (text2 == "MW")
				{
					return (ushort)this.Read(DataType.Memory, 0, int.Parse(text.Substring(2)), VarType.Word, 1);
				}
				text2 = text.Substring(0, 1);
				num = Utilities.ComputeStringHash(text2);
				DataType dataType;
				if (num <= 3356228888U)
				{
					if (num <= 3289118412U)
					{
						if (num != 3222007936U)
						{
							if (num != 3289118412U)
							{
								goto IL_613;
							}
							if (!(text2 == "A"))
							{
								goto IL_613;
							}
							goto IL_5B0;
						}
						else if (!(text2 == "E"))
						{
							goto IL_613;
						}
					}
					else if (num != 3322673650U)
					{
						if (num != 3356228888U)
						{
							goto IL_613;
						}
						if (!(text2 == "M"))
						{
							goto IL_613;
						}
						dataType = DataType.Memory;
						goto IL_619;
					}
					else
					{
						if (!(text2 == "C"))
						{
							goto IL_613;
						}
						goto IL_5E9;
					}
				}
				else if (num <= 3423339364U)
				{
					if (num != 3389784126U)
					{
						if (num != 3423339364U)
						{
							goto IL_613;
						}
						if (!(text2 == "I"))
						{
							goto IL_613;
						}
					}
					else
					{
						if (!(text2 == "O"))
						{
							goto IL_613;
						}
						goto IL_5B0;
					}
				}
				else if (num != 3507227459U)
				{
					if (num != 3742114125U)
					{
						goto IL_613;
					}
					if (!(text2 == "Z"))
					{
						goto IL_613;
					}
					goto IL_5E9;
				}
				else
				{
					if (!(text2 == "T"))
					{
						goto IL_613;
					}
					return (double)this.Read(DataType.Timer, 0, int.Parse(text.Substring(1)), VarType.Timer, 1);
				}
				dataType = DataType.Input;
				goto IL_619;
				IL_5B0:
				dataType = DataType.Output;
				goto IL_619;
				IL_5E9:
				return (ushort)this.Read(DataType.Counter, 0, int.Parse(text.Substring(1)), VarType.Counter, 1);
				IL_613:
				throw new Exception();
				IL_619:
				string text3 = text.Substring(1);
				if (text3.IndexOf(".") == -1)
				{
					throw new Exception();
				}
				startByteAdr = int.Parse(text3.Substring(0, text3.IndexOf(".")));
				num3 = int.Parse(text3.Substring(text3.IndexOf(".") + 1));
				if (num3 > 7)
				{
					throw new Exception();
				}
				byte b2 = (byte)this.Read(dataType, 0, startByteAdr, VarType.Byte, 1);
				result = new BitArray(new byte[]
				{
					b2
				})[num3];
			}
			catch
			{
				this.LastErrorCode = ErrorCode.WrongVarFormat;
				this.LastErrorString = "The variable'" + variable + "' could not be read. Please check the syntax and try again.";
				result = this.LastErrorCode;
			}
			return result;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00003348 File Offset: 0x00001548
		public object ReadStruct(Type structType, int db, int startByteAdr = 0)
		{
			int structSize = Struct.GetStructSize(structType);
			byte[] bytes = this.ReadBytes(DataType.DataBlock, db, startByteAdr, structSize);
			return Struct.FromBytes(structType, bytes);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00003374 File Offset: 0x00001574
		public void ReadClass(object sourceClass, int db, int startByteAdr = 0)
		{
			Type type = sourceClass.GetType();
			int classSize = Class.GetClassSize(type);
			byte[] bytes = this.ReadBytes(DataType.DataBlock, db, startByteAdr, classSize);
			Class.FromBytes(sourceClass, type, bytes);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000033A8 File Offset: 0x000015A8
		public ErrorCode WriteBytes(DataType dataType, int db, int startByteAdr, byte[] value)
		{
			byte[] array = new byte[513];
			ErrorCode result;
			try
			{
				int num = value.Length;
				int num2 = 35 + value.Length;
				ByteArray byteArray = new ByteArray(num2);
				ByteArray byteArray2 = byteArray;
				byte[] array2 = new byte[3];
				array2[0] = 3;
				byteArray2.Add(array2);
				byteArray.Add((byte)num2);
				byteArray.Add(new byte[]
				{
					2,
					240,
					128,
					50,
					1,
					0,
					0
				});
				byteArray.Add(Word.ToByteArray((ushort)(num - 1)));
				byteArray.Add(new byte[]
				{
					0,
					14
				});
				byteArray.Add(Word.ToByteArray((ushort)(num + 4)));
				byteArray.Add(new byte[]
				{
					5,
					1,
					18,
					10,
					16,
					2
				});
				byteArray.Add(Word.ToByteArray((ushort)num));
				byteArray.Add(Word.ToByteArray((ushort)db));
				byteArray.Add((byte)dataType);
				int num3 = (int)((long)(startByteAdr * 8) / 65535L);
				byteArray.Add((byte)num3);
				byteArray.Add(Word.ToByteArray((ushort)(startByteAdr * 8)));
				byteArray.Add(new byte[]
				{
					0,
					4
				});
				byteArray.Add(Word.ToByteArray((ushort)(num * 8)));
				byteArray.Add(value);
				this._mSocket.Send(byteArray.array, byteArray.array.Length, SocketFlags.None);
				this._mSocket.Receive(array, 512, SocketFlags.None);
				if (array[21] != 255)
				{
					result = ErrorCode.WrongNumberReceivedBytes;
					throw new Exception(result.ToString());
				}
				result = ErrorCode.NoError;
			}
			catch (Exception ex)
			{
				this.LastErrorCode = ErrorCode.WriteData;
				this.LastErrorString = ex.Message;
				result = this.LastErrorCode;
			}
			return result;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00003550 File Offset: 0x00001750
		public ErrorCode Write(DataType dataType, int db, int startByteAdr, object value)
		{
			string name = value.GetType().Name;
			uint num = Utilities.ComputeStringHash(name);
			byte[] value2;
			if (num <= 2341828857U)
			{
				if (num <= 1323747186U)
				{
					if (num != 765439473U)
					{
						if (num != 1189326818U)
						{
							if (num == 1323747186U)
							{
								if (name == "UInt16")
								{
									value2 = Word.ToByteArray((ushort)value);
									goto IL_2B3;
								}
							}
						}
						else if (name == "UInt16[]")
						{
							value2 = Word.ToByteArray((ushort[])value);
							goto IL_2B3;
						}
					}
					else if (name == "Int16")
					{
						value2 = Int.ToByteArray((short)value);
						goto IL_2B3;
					}
				}
				else if (num != 1615808600U)
				{
					if (num != 2313474264U)
					{
						if (num == 2341828857U)
						{
							if (name == "Int16[]")
							{
								value2 = Int.ToByteArray((short[])value);
								goto IL_2B3;
							}
						}
					}
					else if (name == "UInt32[]")
					{
						value2 = DWord.ToByteArray((uint[])value);
						goto IL_2B3;
					}
				}
				else if (name == "String")
				{
					value2 = System.Data.NS7NET.String.ToByteArray(value as string);
					goto IL_2B3;
				}
			}
			else if (num <= 2711245919U)
			{
				if (num != 2386971688U)
				{
					if (num != 2642490659U)
					{
						if (num == 2711245919U)
						{
							if (name == "Int32")
							{
								value2 = DInt.ToByteArray((int)value);
								goto IL_2B3;
							}
						}
					}
					else if (name == "Byte[]")
					{
						value2 = (byte[])value;
						goto IL_2B3;
					}
				}
				else if (name == "Double")
				{
					value2 = System.Data.NS7NET.Double.ToByteArray((double)value);
					goto IL_2B3;
				}
			}
			else if (num <= 3509231420U)
			{
				if (num != 3409549631U)
				{
					if (num == 3509231420U)
					{
						if (name == "Double[]")
						{
							value2 = System.Data.NS7NET.Double.ToByteArray((double[])value);
							goto IL_2B3;
						}
					}
				}
				else if (name == "Byte")
				{
					value2 = System.Data.NS7NET.Byte.ToByteArray((byte)value);
					goto IL_2B3;
				}
			}
			else if (num != 3538687084U)
			{
				if (num == 3646816451U)
				{
					if (name == "Int32[]")
					{
						value2 = DInt.ToByteArray((int[])value);
						goto IL_2B3;
					}
				}
			}
			else if (name == "UInt32")
			{
				value2 = DWord.ToByteArray((uint)value);
				goto IL_2B3;
			}
			return ErrorCode.WrongVarFormat;
			IL_2B3:
			return this.WriteBytes(dataType, db, startByteAdr, value2);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x0000381C File Offset: 0x00001A1C
		public ErrorCode Write(string variable, object value)
		{
			string text = variable.ToUpper();
			text = text.Replace(" ", "");
			ErrorCode result;
			try
			{
				string text2 = text.Substring(0, 2);
				uint num = Utilities.ComputeStringHash(text2);
				int startByteAdr;
				int num3;
				if (num <= 752165258U)
				{
					if (num <= 382469260U)
					{
						if (num != 348914022U)
						{
							if (num == 382469260U)
							{
								if (text2 == "ED")
								{
									object obj = Convert.ChangeType(value, typeof(uint));
									return this.Write(DataType.Input, 0, int.Parse(text.Substring(2)), (uint)obj);
								}
							}
						}
						else if (text2 == "EB")
						{
							object obj = Convert.ChangeType(value, typeof(byte));
							return this.Write(DataType.Input, 0, int.Parse(text.Substring(2)), (byte)obj);
						}
					}
					else if (num != 651499544U)
					{
						if (num != 701244021U)
						{
							if (num == 752165258U)
							{
								if (text2 == "AB")
								{
									object obj = Convert.ChangeType(value, typeof(byte));
									return this.Write(DataType.Output, 0, int.Parse(text.Substring(2)), (byte)obj);
								}
							}
						}
						else if (text2 == "EW")
						{
							object obj = Convert.ChangeType(value, typeof(ushort));
							return this.Write(DataType.Input, 0, int.Parse(text.Substring(2)), (ushort)obj);
						}
					}
					else if (text2 == "AD")
					{
						object obj = Convert.ChangeType(value, typeof(uint));
						return this.Write(DataType.Output, 0, int.Parse(text.Substring(2)), (uint)obj);
					}
				}
				else if (num <= 970274305U)
				{
					if (num != 919500163U)
					{
						if (num == 970274305U)
						{
							if (text2 == "AW")
							{
								object obj = Convert.ChangeType(value, typeof(ushort));
								return this.Write(DataType.Output, 0, int.Parse(text.Substring(2)), (ushort)obj);
							}
						}
					}
					else if (text2 == "DB")
					{
						string[] array = text.Split(new char[]
						{
							'.'
						});
						if (array.Length < 2)
						{
							throw new Exception();
						}
						int db = int.Parse(array[0].Substring(2));
						string text3 = array[1].Substring(0, 3);
						int num2 = int.Parse(array[1].Substring(3));
						if (text3 == "DBB")
						{
							object obj = Convert.ChangeType(value, typeof(byte));
							return this.Write(DataType.DataBlock, db, num2, (byte)obj);
						}
						if (text3 == "DBW")
						{
							object obj;
							if (value is short)
							{
								obj = ((short)value).ConvertToUshort();
							}
							else
							{
								obj = Convert.ChangeType(value, typeof(ushort));
							}
							return this.Write(DataType.DataBlock, db, num2, (ushort)obj);
						}
						if (!(text3 == "DBD"))
						{
							if (!(text3 == "DBX"))
							{
								if (!(text3 == "DBS"))
								{
									throw new Exception(string.Format("Addressing Error: Unable to parse address {0}. Supported formats include DBB (byte), DBW (word), DBD (dword), DBX (bitwise), DBS (string).", text3));
								}
								return this.Write(DataType.DataBlock, db, num2, (string)value);
							}
							else
							{
								startByteAdr = num2;
								num3 = int.Parse(array[2]);
								if (num3 > 7)
								{
									throw new Exception(string.Format("Addressing Error: You can only reference bitwise locations 0-7. Address {0} is invalid", num3));
								}
								byte b = (byte)this.Read(DataType.DataBlock, db, startByteAdr, VarType.Byte, 1);
								if (Convert.ToInt32(value) == 1)
								{
									b |= (byte)Math.Pow(2.0, (double)num3);
								}
								else
								{
									b &= (byte)(b ^ (byte)Math.Pow(2.0, (double)num3));
								}
								return this.Write(DataType.DataBlock, db, startByteAdr, b);
							}
						}
						else
						{
							if (value is int)
							{
								return this.Write(DataType.DataBlock, db, num2, (int)value);
							}
							object obj = Convert.ChangeType(value, typeof(uint));
							return this.Write(DataType.DataBlock, db, num2, (uint)obj);
						}
					}
				}
				else if (num != 970965853U)
				{
					if (num != 1155519662U)
					{
						if (num == 1189074900U)
						{
							if (text2 == "MD")
							{
								return this.Write(DataType.Memory, 0, int.Parse(text.Substring(2)), value);
							}
						}
					}
					else if (text2 == "MB")
					{
						object obj = Convert.ChangeType(value, typeof(byte));
						return this.Write(DataType.Memory, 0, int.Parse(text.Substring(2)), (byte)obj);
					}
				}
				else if (text2 == "MW")
				{
					object obj = Convert.ChangeType(value, typeof(ushort));
					return this.Write(DataType.Memory, 0, int.Parse(text.Substring(2)), (ushort)obj);
				}
				text2 = text.Substring(0, 1);
				num = Utilities.ComputeStringHash(text2);
				DataType dataType;
				if (num <= 3356228888U)
				{
					if (num <= 3289118412U)
					{
						if (num != 3222007936U)
						{
							if (num != 3289118412U)
							{
								goto IL_792;
							}
							if (!(text2 == "A"))
							{
								goto IL_792;
							}
							goto IL_732;
						}
						else if (!(text2 == "E"))
						{
							goto IL_792;
						}
					}
					else if (num != 3322673650U)
					{
						if (num != 3356228888U)
						{
							goto IL_792;
						}
						if (!(text2 == "M"))
						{
							goto IL_792;
						}
						dataType = DataType.Memory;
						goto IL_7AB;
					}
					else
					{
						if (!(text2 == "C"))
						{
							goto IL_792;
						}
						goto IL_76A;
					}
				}
				else if (num <= 3423339364U)
				{
					if (num != 3389784126U)
					{
						if (num != 3423339364U)
						{
							goto IL_792;
						}
						if (!(text2 == "I"))
						{
							goto IL_792;
						}
					}
					else
					{
						if (!(text2 == "O"))
						{
							goto IL_792;
						}
						goto IL_732;
					}
				}
				else if (num != 3507227459U)
				{
					if (num != 3742114125U)
					{
						goto IL_792;
					}
					if (!(text2 == "Z"))
					{
						goto IL_792;
					}
					goto IL_76A;
				}
				else
				{
					if (!(text2 == "T"))
					{
						goto IL_792;
					}
					return this.Write(DataType.Timer, 0, int.Parse(text.Substring(1)), (double)value);
				}
				dataType = DataType.Input;
				goto IL_7AB;
				IL_732:
				dataType = DataType.Output;
				goto IL_7AB;
				IL_76A:
				return this.Write(DataType.Counter, 0, int.Parse(text.Substring(1)), (short)value);
				IL_792:
				throw new Exception(string.Format("Unknown variable type {0}.", text.Substring(0, 1)));
				IL_7AB:
				string text4 = text.Substring(1);
				int num4 = text4.IndexOf(".");
				if (num4 == -1)
				{
					throw new Exception(string.Format("Cannot parse variable {0}. Input, Output, Memory Address, Timer, and Counter types require bit-level addressing (e.g. I0.1).", text4));
				}
				startByteAdr = int.Parse(text4.Substring(0, num4));
				num3 = int.Parse(text4.Substring(num4 + 1));
				if (num3 > 7)
				{
					throw new Exception(string.Format("Addressing Error: You can only reference bitwise locations 0-7. Address {0} is invalid", num3));
				}
				byte b2 = (byte)this.Read(dataType, 0, startByteAdr, VarType.Byte, 1);
				if ((int)value == 1)
				{
					b2 |= (byte)Math.Pow(2.0, (double)num3);
				}
				else
				{
					b2 &= (byte)(b2 ^ (byte)Math.Pow(2.0, (double)num3));
				}
				result = this.Write(dataType, 0, startByteAdr, b2);
			}
			catch (Exception ex)
			{
				this.LastErrorCode = ErrorCode.WrongVarFormat;
				this.LastErrorString = "The variable'" + variable + "' could not be parsed. Please check the syntax and try again.\nException: " + ex.Message;
				result = this.LastErrorCode;
			}
			return result;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000040F0 File Offset: 0x000022F0
		public ErrorCode WriteStruct(object structValue, int db, int startByteAdr = 0)
		{
			List<byte> bytes = Struct.ToBytes(structValue).ToList<byte>();
			return this.WriteMultipleBytes(bytes, db, startByteAdr);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00004114 File Offset: 0x00002314
		public ErrorCode WriteClass(object classValue, int db, int startByteAdr = 0)
		{
			List<byte> bytes = Class.ToBytes(classValue).ToList<byte>();
			return this.WriteMultipleBytes(bytes, db, startByteAdr);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00004136 File Offset: 0x00002336
		public void ClearLastError()
		{
			this.LastErrorCode = ErrorCode.NoError;
			this.LastErrorString = string.Empty;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x0000414C File Offset: 0x0000234C
		private ErrorCode WriteMultipleBytes(List<byte> bytes, int db, int startByteAdr = 0)
		{
			ErrorCode errorCode = ErrorCode.NoError;
			int num = startByteAdr;
			try
			{
				while (bytes.Count > 0)
				{
					int num2 = Math.Min(bytes.Count, 200);
					List<byte> range = bytes.ToList<byte>().GetRange(0, num2);
					errorCode = this.WriteBytes(DataType.DataBlock, db, num, range.ToArray());
					bytes.RemoveRange(0, num2);
					num += num2;
					if (errorCode != ErrorCode.NoError)
					{
						break;
					}
				}
			}
			catch (Exception ex)
			{
				this.LastErrorCode = ErrorCode.WriteData;
				this.LastErrorString = "An error occurred while writing data:" + ex.Message;
			}
			return errorCode;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000041E0 File Offset: 0x000023E0
		private ByteArray ReadHeaderPackage(int amount = 1)
		{
			ByteArray byteArray = new ByteArray(19);
			ByteArray byteArray2 = byteArray;
			byte[] array = new byte[3];
			array[0] = 3;
			byteArray2.Add(array);
			byteArray.Add((byte)(19 + 12 * amount));
			byteArray.Add(new byte[]
			{
				2,
				240,
				128,
				50,
				1,
				0,
				0,
				0,
				0
			});
			byteArray.Add(Word.ToByteArray((ushort)(2 + amount * 12)));
			byteArray.Add(new byte[]
			{
				0,
				0,
				4
			});
			byteArray.Add((byte)amount);
			return byteArray;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00004258 File Offset: 0x00002458
		private ByteArray CreateReadDataRequestPackage(DataType dataType, int db, int startByteAdr, int count = 1)
		{
			ByteArray byteArray = new ByteArray(12);
			byteArray.Add(new byte[]
			{
				18,
				10,
				16
			});
			if (dataType == DataType.Counter || dataType == DataType.Timer)
			{
				byteArray.Add((byte)dataType);
			}
			else
			{
				byteArray.Add(2);
			}
			byteArray.Add(Word.ToByteArray((ushort)count));
			byteArray.Add(Word.ToByteArray((ushort)db));
			byteArray.Add((byte)dataType);
			int num = (int)((long)(startByteAdr * 8) / 65535L);
			byteArray.Add((byte)num);
			if (dataType == DataType.Counter || dataType == DataType.Timer)
			{
				byteArray.Add(Word.ToByteArray((ushort)startByteAdr));
			}
			else
			{
				byteArray.Add(Word.ToByteArray((ushort)(startByteAdr * 8)));
			}
			return byteArray;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00004300 File Offset: 0x00002500
		private byte[] ReadBytesWithASingleRequest(DataType dataType, int db, int startByteAdr, int count)
		{
			byte[] array = new byte[count];
			byte[] result;
			try
			{
				ByteArray byteArray = new ByteArray(31);
				byteArray.Add(this.ReadHeaderPackage(1));
				byteArray.Add(this.CreateReadDataRequestPackage(dataType, db, startByteAdr, count));
				this._mSocket.Send(byteArray.array, byteArray.array.Length, SocketFlags.None);
				byte[] array2 = new byte[512];
				this._mSocket.Receive(array2, 512, SocketFlags.None);
				if (array2[21] != 255)
				{
					throw new Exception(ErrorCode.WrongNumberReceivedBytes.ToString());
				}
				for (int i = 0; i < count; i++)
				{
					array[i] = array2[i + 25];
				}
				result = array;
			}
			catch (SocketException ex)
			{
				this.LastErrorCode = ErrorCode.WriteData;
				this.LastErrorString = ex.Message;
				result = null;
			}
			catch (Exception ex2)
			{
				this.LastErrorCode = ErrorCode.WriteData;
				this.LastErrorString = ex2.Message;
				result = null;
			}
			return result;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x0000440C File Offset: 0x0000260C
		private object ParseBytes(VarType varType, byte[] bytes, int varCount)
		{
			if (bytes == null)
			{
				return null;
			}
			switch (varType)
			{
			case VarType.Bit:
				return null;
			case VarType.Byte:
				if (varCount == 1)
				{
					return bytes[0];
				}
				return bytes;
			case VarType.Word:
				if (varCount == 1)
				{
					return Word.FromByteArray(bytes);
				}
				return Word.ToArray(bytes);
			case VarType.DWord:
				if (varCount == 1)
				{
					return DWord.FromByteArray(bytes);
				}
				return DWord.ToArray(bytes);
			case VarType.Int:
				if (varCount == 1)
				{
					return Int.FromByteArray(bytes);
				}
				return Int.ToArray(bytes);
			case VarType.DInt:
				if (varCount == 1)
				{
					return DInt.FromByteArray(bytes);
				}
				return DInt.ToArray(bytes);
			case VarType.Real:
				if (varCount == 1)
				{
					return System.Data.NS7NET.Double.FromByteArray(bytes);
				}
				return System.Data.NS7NET.Double.ToArray(bytes);
			case VarType.String:
				return System.Data.NS7NET.String.FromByteArray(bytes);
			case VarType.Timer:
				if (varCount == 1)
				{
					return Timer.FromByteArray(bytes);
				}
				return Timer.ToArray(bytes);
			case VarType.Counter:
				if (varCount == 1)
				{
					return Counter.FromByteArray(bytes);
				}
				return Counter.ToArray(bytes);
			default:
				return null;
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x0000450C File Offset: 0x0000270C
		private int VarTypeToByteLength(VarType varType, int varCount = 1)
		{
			switch (varType)
			{
			case VarType.Bit:
				return varCount;
			case VarType.Byte:
				if (varCount >= 1)
				{
					return varCount;
				}
				return 1;
			case VarType.Word:
			case VarType.Int:
			case VarType.Timer:
			case VarType.Counter:
				return varCount * 2;
			case VarType.DWord:
			case VarType.DInt:
			case VarType.Real:
				return varCount * 4;
			case VarType.String:
				return varCount;
			default:
				return 0;
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002940 File Offset: 0x00000B40
		public void Dispose()
		{
			if (this._mSocket != null && this._mSocket.Connected)
			{
				this._mSocket.Shutdown(SocketShutdown.Both);
				this._mSocket.Close();
			}
		}

		// Token: 0x04000023 RID: 35
		private Socket _mSocket;
	}
}
