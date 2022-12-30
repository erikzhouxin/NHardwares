using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace System.Data.NS7NET
{
    /// <summary>
    /// PLC类接口
    /// </summary>
    public interface IS7NetPlc : IDisposable
    {
        /// <summary>
        /// IP地址
        /// </summary>
        string IP { get; }
        /// <summary>
        /// CUP类型
        /// </summary>
        CpuType CPU { get; }
        /// <summary>
        /// 机架
        /// </summary>
        short Rack { get; }
        /// <summary>
        /// 槽位
        /// </summary>
        short Slot { get; }
        /// <summary>
        /// 是有效的
        /// </summary>
        bool IsAvailable { get; }
        /// <summary>
        /// 是连接
        /// </summary>
        bool IsConnected { get; }
        /// <summary>
        /// 最后一次错误
        /// </summary>
        string LastErrorString { get; }
        /// <summary>
        /// 最后一次错误码
        /// </summary>
        ErrorCode LastErrorCode { get; }
        /// <summary>
        /// 打开
        /// </summary>
        /// <returns></returns>
        ErrorCode Open();
        /// <summary>
        /// 关闭
        /// </summary>
        void Close();
        /// <summary>
        /// 读多个变量
        /// </summary>
        /// <param name="dataItems"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        void ReadMultipleVars(List<DataItem> dataItems);
        /// <summary>
        /// 读字节
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="db"></param>
        /// <param name="startByteAdr"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        byte[] ReadBytes(DataType dataType, int db, int startByteAdr, int count);
        /// <summary>
        /// 读对象
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="db"></param>
        /// <param name="startByteAdr"></param>
        /// <param name="varType"></param>
        /// <param name="varCount"></param>
        /// <returns></returns>
        object Read(DataType dataType, int db, int startByteAdr, VarType varType, int varCount);
        /// <summary>
        /// 读对象
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        public object Read(string variable);
        /// <summary>
        /// 读结构
        /// </summary>
        /// <param name="structType"></param>
        /// <param name="db"></param>
        /// <param name="startByteAdr"></param>
        /// <returns></returns>
        public object ReadStruct(Type structType, int db, int startByteAdr = 0);
        /// <summary>
        /// 读类
        /// </summary>
        /// <param name="sourceClass"></param>
        /// <param name="db"></param>
        /// <param name="startByteAdr"></param>
        public void ReadClass(object sourceClass, int db, int startByteAdr = 0);
        /// <summary>
        /// 写字节
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="db"></param>
        /// <param name="startByteAdr"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public ErrorCode WriteBytes(DataType dataType, int db, int startByteAdr, byte[] value);
        /// <summary>
        /// 写对象
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="db"></param>
        /// <param name="startByteAdr"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public ErrorCode Write(DataType dataType, int db, int startByteAdr, object value);
        /// <summary>
        /// 写入字符串函数
        /// </summary>
        /// <param name="dataType">数据块类型</param>
        /// <param name="db">DB块号码</param>
        /// <param name="startByteAdr">起始地址</param>
        /// <param name="stringWrite">写入字符串</param>
        /// <param name="stringLength">字符总长度，只针对1200以上PLC，200不需要设置0</param>
        /// <returns></returns>
        public ErrorCode WriteString(DataType dataType, int db, int startByteAdr, string stringWrite, byte stringLength = 0);
        /// <summary>
        /// 写值
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public ErrorCode Write(string variable, object value);
        /// <summary>
        /// 写结构体
        /// </summary>
        /// <param name="structValue"></param>
        /// <param name="db"></param>
        /// <param name="startByteAdr"></param>
        /// <returns></returns>
        public ErrorCode WriteStruct(object structValue, int db, int startByteAdr = 0);
        /// <summary>
        /// 写类
        /// </summary>
        /// <param name="classValue"></param>
        /// <param name="db"></param>
        /// <param name="startByteAdr"></param>
        /// <returns></returns>
        public ErrorCode WriteClass(object classValue, int db, int startByteAdr = 0);
        /// <summary>
        /// 清除最后一次错误
        /// </summary>
        public void ClearLastError();
    }
    internal class S7NetPlc : IS7NetPlc
    {
        private Socket _mSocket;
        /// <summary>
        /// IP地址
        /// </summary>
        public string IP { get; private set; }
        /// <summary>
        /// CUP类型
        /// </summary>
        public CpuType CPU { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public short Rack { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public short Slot { get; private set; }
        /// <summary>
        /// 是有效的
        /// </summary>
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
        /// <summary>
        /// 是连接
        /// </summary>
        public bool IsConnected
        {
            get
            {
                if (this._mSocket == null) { return false; }
                try
                {
                    return ((!this._mSocket.Poll(1000, SelectMode.SelectRead) || this._mSocket.Available != 0) && this._mSocket.Connected);
                }
                catch { }
                return false;
            }
        }
        /// <summary>
        /// 最后一次错误
        /// </summary>
        public string LastErrorString { get; private set; }
        /// <summary>
        /// 最后一次错误码
        /// </summary>
        public ErrorCode LastErrorCode { get; private set; }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="cpu"></param>
        /// <param name="ip"></param>
        /// <param name="rack"></param>
        /// <param name="slot"></param>
        public S7NetPlc(CpuType cpu, string ip, short rack, short slot)
        {
            this.IP = ip;
            this.CPU = cpu;
            this.Rack = rack;
            this.Slot = slot;
        }
        /// <summary>
        /// 打开
        /// </summary>
        /// <returns></returns>
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
                this.LastErrorString = string.Format("目标IP地址【{0}】不可用！", this.IP);
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
                byte[] array = new byte[] { 3, 0, 0, 22, 17, 224, 0, 0, 0, 46, 0, 193, 2, 1, 0, 194, 2, 3, 0, 192, 1, 9 };
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
                byte[] buffer2 = new byte[] { 3, 0, 0, 25, 2, 240, 128, 50, 1, 0, 0, byte.MaxValue, byte.MaxValue, 0, 8, 0, 0, 240, 0, 0, 3, 0, 3, 1, 0 };
                this._mSocket.Send(buffer2, 25, SocketFlags.None);
                if (this._mSocket.Receive(buffer, 27, SocketFlags.None) != 27)
                {
                    throw new Exception(ErrorCode.WrongNumberReceivedBytes.ToString());
                }
            }
            catch (Exception ex2)
            {
                this.LastErrorCode = ErrorCode.ConnectionError;
                this.LastErrorString = $"无法建立连接与{this.IP}的连接。\n错误信息是：{ex2.Message}";
                return ErrorCode.ConnectionError;
            }
            return ErrorCode.NoError;
        }
        /// <summary>
        /// 关闭
        /// </summary>
        public void Close()
        {
            if (this._mSocket != null && this._mSocket.Connected)
            {
                this._mSocket.Shutdown(SocketShutdown.Both);
                this._mSocket.Close();
            }
        }
        /// <summary>
        /// 读多个变量
        /// </summary>
        /// <param name="dataItems"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void ReadMultipleVars(List<DataItem> dataItems)
        {
            if (dataItems == null || dataItems.Count == 0)
            {
                throw new ArgumentNullException("请求变量数必须大于0");
            }
            if (dataItems.Count > 20)
            {
                throw new ArgumentOutOfRangeException("请求变量数量超过20个限制");
            }
            int num = dataItems.Sum((DataItem dataItem) => VarTypeToByteLength(dataItem.VarType, dataItem.Count));
            if (num > 222)
            {
                throw new ArgumentException("请求变量字节长度超过222个字节限制");
            }
            try
            {
                ByteArray byteArray = new ByteArray(19 + dataItems.Count * 12);
                byteArray.Add(this.ReadHeaderPackage(dataItems.Count));
                foreach (DataItem dataItem3 in dataItems)
                {
                    byteArray.Add(this.CreateReadDataRequestPackage(dataItem3.DataType, dataItem3.DB, dataItem3.StartByteAdr, VarTypeToByteLength(dataItem3.VarType, dataItem3.Count)));
                }
                this._mSocket.Send(byteArray.Array, byteArray.Array.Length, SocketFlags.None);
                byte[] array = new byte[512];
                this._mSocket.Receive(array, 512, SocketFlags.None);
                if (array[21] != 255)
                {
                    throw new Exception(ErrorCode.WrongNumberReceivedBytes.ToString());
                }
                int num2 = 25;
                foreach (DataItem dataItem2 in dataItems)
                {
                    int num3 = VarTypeToByteLength(dataItem2.VarType, dataItem2.Count);
                    byte[] array2 = new byte[num3];
                    for (int i = 0; i < num3; i++)
                    {
                        array2[i] = array[i + num2];
                    }
                    num2 += num3 + 4;
                    dataItem2.Value = ParseBytes(dataItem2.VarType, array2, dataItem2.Count);
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
        /// <summary>
        /// 读字节
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="db"></param>
        /// <param name="startByteAdr"></param>
        /// <param name="count"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 读对象
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="db"></param>
        /// <param name="startByteAdr"></param>
        /// <param name="varType"></param>
        /// <param name="varCount"></param>
        /// <returns></returns>
        public object Read(DataType dataType, int db, int startByteAdr, VarType varType, int varCount)
        {
            int count = VarTypeToByteLength(varType, varCount);
            byte[] bytes = this.ReadBytes(dataType, db, startByteAdr, count);
            return ParseBytes(varType, bytes, varCount);
        }
        /// <summary>
        /// 读对象
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        public object Read(string variable)
        {
            string text = variable.ToUpper();
            text = text.Replace(" ", "");
            object result;
            try
            {
                string text2 = text.Substring(0, 2);
                uint num = S7NetCaller.ComputeStringHash(text2);
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
                num = S7NetCaller.ComputeStringHash(text2);
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
                this.LastErrorString = $"变量【{variable}】不可读，请检查变量名，然后重试。";
                result = this.LastErrorCode;
            }
            return result;
        }
        /// <summary>
        /// 读结构
        /// </summary>
        /// <param name="structType"></param>
        /// <param name="db"></param>
        /// <param name="startByteAdr"></param>
        /// <returns></returns>
        public object ReadStruct(Type structType, int db, int startByteAdr = 0)
        {
            int structSize = S7NetCaller.GetStructSize(structType);
            byte[] bytes = this.ReadBytes(DataType.DataBlock, db, startByteAdr, structSize);
            return S7NetCaller.StructFromBytes(structType, bytes);
        }
        /// <summary>
        /// 读类
        /// </summary>
        /// <param name="sourceClass"></param>
        /// <param name="db"></param>
        /// <param name="startByteAdr"></param>
        public void ReadClass(object sourceClass, int db, int startByteAdr = 0)
        {
            Type type = sourceClass.GetType();
            int classSize = S7NetCaller.GetClassSize(type);
            byte[] bytes = this.ReadBytes(DataType.DataBlock, db, startByteAdr, classSize);
            S7NetCaller.ClassFromBytes(sourceClass, type, bytes);
        }
        /// <summary>
        /// 写字节
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="db"></param>
        /// <param name="startByteAdr"></param>
        /// <param name="value"></param>
        /// <returns></returns>
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
                byteArray.Add(new byte[] { 2, 240, 128, 50, 1, 0, 0 });
                byteArray.Add(S7NetCaller.WordToByteArray((ushort)(num - 1)));
                byteArray.Add(new byte[] { 0, 14 });
                byteArray.Add(S7NetCaller.WordToByteArray((ushort)(num + 4)));
                byteArray.Add(new byte[] { 5, 1, 18, 10, 16, 2 });
                byteArray.Add(S7NetCaller.WordToByteArray((ushort)num));
                byteArray.Add(S7NetCaller.WordToByteArray((ushort)db));
                byteArray.Add((byte)dataType);
                int num3 = (int)((long)(startByteAdr * 8) / 65535L);
                byteArray.Add((byte)num3);
                byteArray.Add(S7NetCaller.WordToByteArray((ushort)(startByteAdr * 8)));
                byteArray.Add(new byte[] { 0, 4 });
                byteArray.Add(S7NetCaller.WordToByteArray((ushort)(num * 8)));
                byteArray.Add(value);
                this._mSocket.Send(byteArray.Array, byteArray.Array.Length, SocketFlags.None);
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
        /// <summary>
        /// 写对象
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="db"></param>
        /// <param name="startByteAdr"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public ErrorCode Write(DataType dataType, int db, int startByteAdr, object value)
        {
            string name = value.GetType().Name;
            uint num = S7NetCaller.ComputeStringHash(name);
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
                                    value2 = S7NetCaller.WordToByteArray((ushort)value);
                                    goto IL_2B3;
                                }
                            }
                        }
                        else if (name == "UInt16[]")
                        {
                            value2 = S7NetCaller.WordToByteArray((ushort[])value);
                            goto IL_2B3;
                        }
                    }
                    else if (name == "Int16")
                    {
                        value2 = S7NetCaller.IntToByteArray((short)value);
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
                                value2 = S7NetCaller.IntToByteArray((short[])value);
                                goto IL_2B3;
                            }
                        }
                    }
                    else if (name == "UInt32[]")
                    {
                        value2 = S7NetCaller.DWordToByteArray((uint[])value);
                        goto IL_2B3;
                    }
                }
                else if (name == "String")
                {
                    value2 = S7NetCaller.StringToByteArray(value as string);
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
                                value2 = S7NetCaller.DIntToByteArray((int)value);
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
                    value2 = S7NetCaller.DoubleToByteArray((double)value);
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
                            value2 = S7NetCaller.DoubleToByteArray((double[])value);
                            goto IL_2B3;
                        }
                    }
                }
                else if (name == "Byte")
                {
                    value2 = S7NetCaller.ByteToByteArray((byte)value);
                    goto IL_2B3;
                }
            }
            else if (num != 3538687084U)
            {
                if (num == 3646816451U)
                {
                    if (name == "Int32[]")
                    {
                        value2 = S7NetCaller.DIntToByteArray((int[])value);
                        goto IL_2B3;
                    }
                }
            }
            else if (name == "UInt32")
            {
                value2 = S7NetCaller.DWordToByteArray((uint)value);
                goto IL_2B3;
            }
            return ErrorCode.WrongVarFormat;
        IL_2B3:
            return this.WriteBytes(dataType, db, startByteAdr, value2);
        }
        /// <summary>
        /// 写入字符串函数
        /// </summary>
        /// <param name="dataType">数据块类型</param>
        /// <param name="db">DB块号码</param>
        /// <param name="startByteAdr">起始地址</param>
        /// <param name="stringWrite">写入字符串</param>
        /// <param name="stringLength">字符总长度，只针对1200以上PLC，200不需要设置0</param>
        /// <returns></returns>
        public ErrorCode WriteString(DataType dataType, int db, int startByteAdr, string stringWrite, byte stringLength = 0)
        {
            if (stringWrite == null)
            {
                LastErrorString = "写入数据不允许为null";
                return LastErrorCode = ErrorCode.WriteData;
            }
            int Lentgh = stringWrite.Length;
            byte[] vaule = new byte[Lentgh + 2];
            byte[] array = System.Text.Encoding.ASCII.GetBytes(stringWrite);
            switch (CPU)
            {
                case CpuType.S7200:
                    {
                        vaule[0] = (byte)Lentgh;
                        for (int i = 0; i <= Lentgh - 1; i++)
                        {
                            vaule[i + 1] = (byte)array[i];
                        }
                    }
                    break;
                case CpuType.S7300:
                case CpuType.S7400:
                case CpuType.S71200:
                case CpuType.S71500:
                default:
                    {
                        vaule[0] = stringLength;
                        vaule[1] = (byte)Lentgh;
                        for (int i = 0; i <= Lentgh - 1; i++)
                        {
                            vaule[i + 2] = (byte)array[i];
                        }
                    }
                    break;
            }
            return WriteBytes(dataType, db, startByteAdr, vaule);
        }
        /// <summary>
        /// 写值
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public ErrorCode Write(string variable, object value)
        {
            string text = variable.ToUpper();
            text = text.Replace(" ", "");
            ErrorCode result;
            try
            {
                string text2 = text.Substring(0, 2);
                uint num = S7NetCaller.ComputeStringHash(text2);
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
                                    throw new Exception(string.Format("寻址错误：无法解析地址【{0}】，支持的格式包括DBB (byte)、DBW (word)、DBD (dword)、DBX (bitwise)、DBS (string)。", text3));
                                }
                                return this.Write(DataType.DataBlock, db, num2, (string)value);
                            }
                            else
                            {
                                startByteAdr = num2;
                                num3 = int.Parse(array[2]);
                                if (num3 > 7)
                                {
                                    throw new Exception(string.Format("寻址错误：您只能引用按位0-7的位置，地址【{0}】无效。", num3));
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
                num = S7NetCaller.ComputeStringHash(text2);
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
                throw new Exception(string.Format("未知的变量类型【{0}】。", text.Substring(0, 1)));
            IL_7AB:
                string text4 = text.Substring(1);
                int num4 = text4.IndexOf(".");
                if (num4 == -1)
                {
                    throw new Exception(string.Format("无法解析变量【{0}】，输入、输出、内存地址、定时器和计数器类型需要位级寻址(例如I0.1)。", text4));
                }
                startByteAdr = int.Parse(text4.Substring(0, num4));
                num3 = int.Parse(text4.Substring(num4 + 1));
                if (num3 > 7)
                {
                    throw new Exception(string.Format("寻址错误：您只能引用按位0-7的位置，地址【{0}】无效", num3));
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
                this.LastErrorString = $"变量【{variable}】无法解析，请检查变量名，然后重试。\n错误信息：{ex.Message}";
                result = this.LastErrorCode;
            }
            return result;
        }
        /// <summary>
        /// 写结构体
        /// </summary>
        /// <param name="structValue"></param>
        /// <param name="db"></param>
        /// <param name="startByteAdr"></param>
        /// <returns></returns>
        public ErrorCode WriteStruct(object structValue, int db, int startByteAdr = 0)
        {
            List<byte> bytes = S7NetCaller.StructToBytes(structValue).ToList<byte>();
            return this.WriteMultipleBytes(bytes, db, startByteAdr);
        }
        /// <summary>
        /// 写类
        /// </summary>
        /// <param name="classValue"></param>
        /// <param name="db"></param>
        /// <param name="startByteAdr"></param>
        /// <returns></returns>
        public ErrorCode WriteClass(object classValue, int db, int startByteAdr = 0)
        {
            List<byte> bytes = S7NetCaller.ClassToBytes(classValue).ToList<byte>();
            return this.WriteMultipleBytes(bytes, db, startByteAdr);
        }
        /// <summary>
        /// 清除最后一次错误
        /// </summary>
        public void ClearLastError()
        {
            this.LastErrorCode = ErrorCode.NoError;
            this.LastErrorString = string.Empty;
        }
        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            if (this._mSocket != null && this._mSocket.Connected)
            {
                this._mSocket.Shutdown(SocketShutdown.Both);
                this._mSocket.Close();
            }
        }
        #region // 辅助方法
        /// <summary>
        /// 写多个字节
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="db"></param>
        /// <param name="startByteAdr"></param>
        /// <returns></returns>
        internal ErrorCode WriteMultipleBytes(List<byte> bytes, int db, int startByteAdr = 0)
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
                this.LastErrorString = "写数据时发生错误：" + ex.Message;
            }
            return errorCode;
        }
        /// <summary>
        /// 读包头
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        internal ByteArray ReadHeaderPackage(int amount = 1)
        {
            ByteArray byteArray = new ByteArray(19);
            ByteArray byteArray2 = byteArray;
            byte[] array = new byte[3];
            array[0] = 3;
            byteArray2.Add(array);
            byteArray.Add((byte)(19 + 12 * amount));
            byteArray.Add(new byte[] { 2, 240, 128, 50, 1, 0, 0, 0, 0 });
            byteArray.Add(S7NetCaller.WordToByteArray((ushort)(2 + amount * 12)));
            byteArray.Add(new byte[] { 0, 0, 4 });
            byteArray.Add((byte)amount);
            return byteArray;
        }
        /// <summary>
        /// 创建读请求数据包
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="db"></param>
        /// <param name="startByteAdr"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        internal ByteArray CreateReadDataRequestPackage(DataType dataType, int db, int startByteAdr, int count = 1)
        {
            ByteArray byteArray = new ByteArray(12);
            byteArray.Add(new byte[] { 18, 10, 16 });
            if (dataType == DataType.Counter || dataType == DataType.Timer)
            {
                byteArray.Add((byte)dataType);
            }
            else
            {
                byteArray.Add(2);
            }
            byteArray.Add(S7NetCaller.WordToByteArray((ushort)count));
            byteArray.Add(S7NetCaller.WordToByteArray((ushort)db));
            byteArray.Add((byte)dataType);
            int num = (int)((long)(startByteAdr * 8) / 65535L);
            byteArray.Add((byte)num);
            if (dataType == DataType.Counter || dataType == DataType.Timer)
            {
                byteArray.Add(S7NetCaller.WordToByteArray((ushort)startByteAdr));
            }
            else
            {
                byteArray.Add(S7NetCaller.WordToByteArray((ushort)(startByteAdr * 8)));
            }
            return byteArray;
        }
        /// <summary>
        /// 读字节数组用一个请求
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="db"></param>
        /// <param name="startByteAdr"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        internal byte[] ReadBytesWithASingleRequest(DataType dataType, int db, int startByteAdr, int count)
        {
            byte[] array = new byte[count];
            byte[] result;
            try
            {
                ByteArray byteArray = new ByteArray(31);
                byteArray.Add(this.ReadHeaderPackage(1));
                byteArray.Add(this.CreateReadDataRequestPackage(dataType, db, startByteAdr, count));
                this._mSocket.Send(byteArray.Array, byteArray.Array.Length, SocketFlags.None);
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
        #endregion
        #region // 静态辅助方法
        /// <summary>
        /// 转换字节
        /// </summary>
        /// <param name="varType"></param>
        /// <param name="bytes"></param>
        /// <param name="varCount"></param>
        /// <returns></returns>
        static object ParseBytes(VarType varType, byte[] bytes, int varCount)
        {
            if (bytes == null) { return null; }
            switch (varType)
            {
                case VarType.Bit: return null;
                case VarType.Byte: return varCount == 1 ? bytes[0] : bytes;
                case VarType.Word: return varCount == 1 ? S7NetCaller.WordFromByteArray(bytes) : S7NetCaller.WordToArray(bytes);
                case VarType.DWord: return varCount == 1 ? S7NetCaller.DWordFromByteArray(bytes) : S7NetCaller.DWordToArray(bytes);
                case VarType.Int: return varCount == 1 ? S7NetCaller.IntFromByteArray(bytes) : S7NetCaller.IntToArray(bytes);
                case VarType.DInt: return varCount == 1 ? S7NetCaller.DIntFromByteArray(bytes) : S7NetCaller.DIntToArray(bytes);
                case VarType.Real: return varCount == 1 ? S7NetCaller.DoubleFromByteArray(bytes) : S7NetCaller.DoubleToArray(bytes);
                case VarType.String: return S7NetCaller.StringFromByteArray(bytes);
                case VarType.Timer: return varCount == 1 ? S7NetCaller.TimerFromByteArray(bytes) : S7NetCaller.TimerToArray(bytes);
                case VarType.Counter: return varCount == 1 ? S7NetCaller.CounterFromByteArray(bytes) : S7NetCaller.CounterToArray(bytes);
                default: return null;
            }
        }
        /// <summary>
        /// 变量类型长度
        /// </summary>
        /// <param name="varType"></param>
        /// <param name="varCount"></param>
        /// <returns></returns>
        static int VarTypeToByteLength(VarType varType, int varCount = 1)
        {
            switch (varType)
            {
                case VarType.Bit:
                    return varCount;
                case VarType.Byte:
                    return varCount >= 1 ? varCount : 1;
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
        #endregion
    }
    /// <summary>
    /// PLC类 <see cref="S7NetSdk.Create"/>
    /// </summary>
    [Obsolete("替代方案:S7NetSdk.Create进行创建接口类,使用接口【IS7NetPlc】")]
    public class Plc : IS7NetPlc
    {
        private IS7NetPlc _proxy;
        /// <summary>
        /// IP地址
        /// </summary>
        public string IP => _proxy.IP;
        /// <summary>
        /// CPU类型
        /// </summary>
        public CpuType CPU => _proxy.CPU;
        /// <summary>
        /// 机架
        /// </summary>
        public short Rack => _proxy.Rack;
        /// <summary>
        /// 槽位
        /// </summary>
        public short Slot => _proxy.Slot;
        /// <summary>
        /// 是合法
        /// </summary>
        public bool IsAvailable => _proxy.IsAvailable;
        /// <summary>
        /// 是连接
        /// </summary>
        public bool IsConnected => _proxy.IsConnected;
        /// <summary>
        /// 最有一次错误信息
        /// </summary>
        public string LastErrorString => _proxy.LastErrorString;
        /// <summary>
        /// 最后一次错误码
        /// </summary>
        public ErrorCode LastErrorCode => _proxy.LastErrorCode;
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="cpu"></param>
        /// <param name="ip"></param>
        /// <param name="rack"></param>
        /// <param name="slot"></param>
        public Plc(CpuType cpu, string ip, short rack, short slot)
        {
            _proxy = new S7NetPlc(cpu, ip, rack, slot);
        }
        /// <summary>
        /// 清理最后一次错误
        /// </summary>
        public void ClearLastError()
        {
            _proxy.ClearLastError();
        }
        /// <summary>
        /// 关闭
        /// </summary>
        public void Close()
        {
            _proxy.Close();
        }
        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            _proxy.Dispose();
        }
        /// <summary>
        /// 打开
        /// </summary>
        /// <returns></returns>
        public ErrorCode Open()
        {
            return _proxy.Open();
        }
        /// <summary>
        /// 读数据
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="db"></param>
        /// <param name="startByteAdr"></param>
        /// <param name="varType"></param>
        /// <param name="varCount"></param>
        /// <returns></returns>
        public object Read(DataType dataType, int db, int startByteAdr, VarType varType, int varCount)
        {
            return _proxy.Read(dataType, db, startByteAdr, varType, varCount);
        }
        /// <summary>
        /// 读数据
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        public object Read(string variable)
        {
            return _proxy.Read(variable);
        }
        /// <summary>
        /// 读字节数组
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="db"></param>
        /// <param name="startByteAdr"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public byte[] ReadBytes(DataType dataType, int db, int startByteAdr, int count)
        {
            return _proxy.ReadBytes(dataType, db, startByteAdr, count);
        }
        /// <summary>
        /// 读类型
        /// </summary>
        /// <param name="sourceClass"></param>
        /// <param name="db"></param>
        /// <param name="startByteAdr"></param>
        public void ReadClass(object sourceClass, int db, int startByteAdr = 0)
        {
            _proxy.ReadClass(sourceClass, db, startByteAdr);
        }
        /// <summary>
        /// 读多个变量
        /// </summary>
        /// <param name="dataItems"></param>
        public void ReadMultipleVars(List<DataItem> dataItems)
        {
            _proxy.ReadMultipleVars(dataItems);
        }
        /// <summary>
        /// 读结构体
        /// </summary>
        /// <param name="structType"></param>
        /// <param name="db"></param>
        /// <param name="startByteAdr"></param>
        /// <returns></returns>
        public object ReadStruct(Type structType, int db, int startByteAdr = 0)
        {
            return _proxy.ReadStruct(structType, db, startByteAdr);
        }
        /// <summary>
        /// 写数据
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="db"></param>
        /// <param name="startByteAdr"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public ErrorCode Write(DataType dataType, int db, int startByteAdr, object value)
        {
            return _proxy.Write(dataType, db, startByteAdr, value);
        }
        /// <summary>
        /// 写对象
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public ErrorCode Write(string variable, object value)
        {
            return _proxy.Write(variable, value);
        }
        /// <summary>
        /// 写字节数组
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="db"></param>
        /// <param name="startByteAdr"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public ErrorCode WriteBytes(DataType dataType, int db, int startByteAdr, byte[] value)
        {
            return _proxy.WriteBytes(dataType, db, startByteAdr, value);
        }
        /// <summary>
        /// 写对象
        /// </summary>
        /// <param name="classValue"></param>
        /// <param name="db"></param>
        /// <param name="startByteAdr"></param>
        /// <returns></returns>
        public ErrorCode WriteClass(object classValue, int db, int startByteAdr = 0)
        {
            return _proxy.WriteClass(classValue, db, startByteAdr);
        }
        /// <summary>
        /// 写字符串内容
        /// </summary>
        /// <param name="dataType">数据块类型</param>
        /// <param name="db">DB块号码</param>
        /// <param name="startByteAdr">起始地址</param>
        /// <param name="stringWrite">写入字符串</param>
        /// <param name="stringLength">字符总长度，只针对1200以上PLC，200不需要设置0</param>
        /// <returns></returns>
        public ErrorCode WriteString(DataType dataType, int db, int startByteAdr, string stringWrite, byte stringLength = 0)
        {
            return _proxy.WriteString(dataType, db, startByteAdr, stringWrite, stringLength);
        }
        /// <summary>
        /// 写结构体
        /// </summary>
        /// <param name="structValue"></param>
        /// <param name="db"></param>
        /// <param name="startByteAdr"></param>
        /// <returns></returns>
        public ErrorCode WriteStruct(object structValue, int db, int startByteAdr = 0)
        {
            return _proxy.WriteStruct(structValue, db, startByteAdr);
        }
    }
}
