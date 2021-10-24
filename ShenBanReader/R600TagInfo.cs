using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// 标签信息
    /// </summary>
    public class R600TagInfo
    {
        /// <summary>
        /// 键
        /// </summary>
        public string Key { get; }
        /// <summary>
        /// 
        /// </summary>
        public byte[] PC { get; }
        /// <summary>
        /// 
        /// </summary>
        public Byte[] CRC { get; }
        /// <summary>
        /// 
        /// </summary>
        public byte[] EPC { get; }
        /// <summary>
        /// 
        /// </summary>
        public int ELen { get; }
        /// <summary>
        /// 
        /// </summary>
        public byte RSSI { get; }
        /// <summary>
        /// 
        /// </summary>
        public byte FREQ { get; }
        /// <summary>
        /// 
        /// </summary>
        public int INVCNT { get; }
        /// <summary>
        /// 
        /// </summary>
        public byte[] Data { get; }
        /// <summary>
        /// 
        /// </summary>
        public int DLen { get; }
        /// <summary>
        /// 
        /// </summary>
        public byte AntId { get; }
        /// <summary>
        /// 
        /// </summary>
        public byte ReadCount { get; }
        /// <summary>
        /// 
        /// </summary>
        public int ANT1 { get; }
        /// <summary>
        /// 
        /// </summary>
        public int ANT2 { get; }
        /// <summary>
        /// 
        /// </summary>
        public int ANT3 { get; }
        /// <summary>
        /// 
        /// </summary>
        public int ANT4 { get; }
        /// <summary>
        /// 读标签构造
        /// </summary>
        internal R600TagInfo(InitType type, byte[] aryData)
        {
            switch (type)
            {
                case InitType.Read:
                    {
                        int nLen = aryData.Length;
                        int nDataLen = Convert.ToInt32(aryData[nLen - 3]);
                        int nEpcLen = Convert.ToInt32(aryData[2]) - nDataLen - 4;
                        byte[] pc = new byte[2];
                        Array.Copy(aryData, 3, pc, 0, 2);  // string strPC = R600Method.ByteArrayToString(aryData, 3, 2);
                        byte[] epc = new byte[nEpcLen];
                        Array.Copy(aryData, 5, epc, 0, nEpcLen); // string strEPC = R600Method.ByteArrayToString(aryData, 5, nEpcLen);
                        byte[] crc = new byte[2];
                        Array.Copy(aryData, 5 + nEpcLen, crc, 0, 2);// string strCRC = R600Method.ByteArrayToString(aryData, 5 + nEpcLen, 2);
                        byte[] data = new byte[nDataLen];
                        Array.Copy(aryData, 7 + nEpcLen, data, 0, nDataLen);// string strData = R600Method.ByteArrayToString(aryData, 7 + nEpcLen, nDataLen);
                        byte byAntId = (byte)((aryData[nLen - 2] & 0x03) + 1);

                        this.Key = epc.GetMd5String();
                        this.PC = pc;
                        this.CRC = crc;
                        this.EPC = epc;
                        this.ELen = nEpcLen;
                        this.Data = data;
                        this.DLen = nDataLen;
                        this.AntId = byAntId;
                        this.ReadCount = aryData[nLen - 1];
                    }
                    break;
                case InitType.Write:
                    {
                        int nLen = aryData.Length;
                        int nEpcLen = Convert.ToInt32(aryData[2]) - 4;
                        byte[] pc = new byte[2];
                        Array.Copy(aryData, 3, pc, 0, 2);  // string strPC = R600Method.ByteArrayToString(aryData, 3, 2);
                        byte[] epc = new byte[nEpcLen];
                        Array.Copy(aryData, 5, epc, 0, nEpcLen); // string strEPC = R600Method.ByteArrayToString(aryData, 5, nEpcLen);
                        byte[] crc = new byte[2];
                        Array.Copy(aryData, 5 + nEpcLen, crc, 0, 2);// string strCRC = R600Method.ByteArrayToString(aryData, 5 + nEpcLen, 2);
                        byte[] data = new byte[] { };
                        byte byAntId = (byte)((aryData[nLen - 2] & 0x03) + 1);

                        this.Key = epc.GetMd5String();
                        this.PC = pc;
                        this.CRC = crc;
                        this.EPC = epc;
                        this.ELen = nEpcLen;
                        this.Data = data;
                        this.DLen = 0;
                        this.AntId = byAntId;
                        this.ReadCount = aryData[nLen - 1];
                    }
                    break;
                case InitType.Buffer:
                    {
                        int nLen = aryData.Length;
                        int nEpcLen = Convert.ToInt32(aryData[2]) - 4;
                        byte[] pc = new byte[2];
                        Array.Copy(aryData, 3, pc, 0, 2);  // string strPC = R600Method.ByteArrayToString(aryData, 3, 2);
                        byte[] epc = new byte[nEpcLen];
                        Array.Copy(aryData, 5, epc, 0, nEpcLen); // string strEpc = R600Method.ByteArrayToString(aryData, 5, nEpcLen);
                        byte[] crc = new byte[2];
                        Array.Copy(aryData, 5 + nEpcLen, crc, 0, 2);// string strCRC = R600Method.ByteArrayToString(aryData, 5 + nEpcLen, 2);
                        byte byAntId = (byte)((aryData[nLen - 2] & 0x03) + 1);
                        var rssi = aryData[nLen - 3];
                        var invcnt = aryData[nLen - 1];

                        this.Key = epc.GetMd5String();
                        this.PC = pc;
                        this.CRC = crc;
                        this.EPC = epc;
                        this.ELen = nEpcLen;
                        this.AntId = byAntId;
                        this.RSSI = rssi;
                        this.INVCNT = invcnt;
                    }
                    break;
                case InitType.Lock:
                    {
                        int nLen = aryData.Length;
                        int nEpcLen = Convert.ToInt32(aryData[2]) - 4;
                        byte[] pc = new byte[2];
                        Array.Copy(aryData, 3, pc, 0, 2);  // string strPC = R600Method.ByteArrayToString(aryData, 3, 2);
                        byte[] epc = new byte[nEpcLen];
                        Array.Copy(aryData, 5, epc, 0, nEpcLen); // string strEPC = R600Method.ByteArrayToString(aryData, 5, nEpcLen);
                        byte[] crc = new byte[2];
                        Array.Copy(aryData, 5 + nEpcLen, crc, 0, 2); // string strCRC = R600Method.ByteArrayToString(aryData, 5 + nEpcLen, 2);
                        byte[] data = new byte[] { };
                        byte byAntId = (byte)((aryData[nLen - 2] & 0x03) + 1);

                        this.Key = epc.GetMd5String();
                        this.PC = pc;
                        this.CRC = crc;
                        this.EPC = epc;
                        this.ELen = nEpcLen;
                        this.Data = data;
                        this.DLen = 0;
                        this.AntId = byAntId;
                        this.ReadCount = aryData[nLen - 1];
                    }
                    break;
                case InitType.Kill:
                    {
                        int nLen = aryData.Length;
                        int nEpcLen = Convert.ToInt32(aryData[2]) - 4;
                        byte[] pc = new byte[2];
                        Array.Copy(aryData, 3, pc, 0, 2);  // string strPC = R600Method.ByteArrayToString(aryData, 3, 2);
                        byte[] epc = new byte[nEpcLen];
                        Array.Copy(aryData, 5, epc, 0, nEpcLen); // string strEPC = R600Method.ByteArrayToString(aryData, 5, nEpcLen);
                        byte[] crc = new byte[2];
                        Array.Copy(aryData, 5 + nEpcLen, crc, 0, 2); // string strCRC = R600Method.ByteArrayToString(aryData, 5 + nEpcLen, 2);
                        byte[] data = new byte[] { };
                        byte byAntId = (byte)((aryData[nLen - 2] & 0x03) + 1);

                        this.Key = epc.GetMd5String();
                        this.PC = pc;
                        this.CRC = crc;
                        this.EPC = epc;
                        this.ELen = nEpcLen;
                        this.Data = data;
                        this.DLen = 0;
                        this.AntId = byAntId;
                        this.ReadCount = aryData[nLen - 1];
                    }
                    break;
                case InitType.Real:
                    {
                        int nLength = aryData.Length;
                        int nEpcLength = nLength - 4;
                        var epc = new byte[nEpcLength];
                        Array.Copy(aryData, 3, epc, 0, nEpcLength); // string strEPC = R600Method.ByteArrayToString(msgTran.AryData, 3, nEpcLength);
                        var pc = new byte[2];
                        Array.Copy(aryData, 1, pc, 0, 2); // string strPC = R600Method.ByteArrayToString(msgTran.AryData, 1, 2);
                        var rssi = aryData[nLength - 1];
                        byte btTemp = aryData[0];
                        byte btAntId = (byte)((btTemp & 0x03) + 1);
                        byte btFreq = (byte)(btTemp >> 2);

                        this.Key = epc.GetMd5String();
                        this.EPC = epc;
                        this.PC = pc;
                        this.AntId = btAntId;
                        this.RSSI = rssi;
                        this.INVCNT = 1;
                        this.FREQ = btFreq;
                    }
                    break;
                case InitType.Fast:
                    {
                        int nLength = aryData.Length;
                        int nEpcLength = nLength - 4;
                        //增加盘存明细表
                        var epc = new byte[nEpcLength];
                        Array.Copy(aryData, 3, epc, 0, nEpcLength); // string strEPC = R600Method.ByteArrayToString(msgTran.AryData, 3, nEpcLength);
                        var pc = new byte[2];
                        Array.Copy(aryData, 1, pc, 0, 2); // string strPC = R600Method.ByteArrayToString(msgTran.AryData, 1, 2);
                        var rssi = aryData[nLength - 1];
                        byte btTemp = aryData[0];
                        byte btAntId = (byte)((btTemp & 0x03) + 1);
                        byte btFreq = (byte)(btTemp >> 2);

                        this.Key = epc.GetMd5String();
                        this.PC = pc;
                        this.EPC = epc;
                        this.AntId = AntId;
                        this.INVCNT = 1;
                        this.RSSI = rssi;
                        this.FREQ = btFreq;
                        switch (btAntId)
                        {
                            case 0x01:
                                this.ANT1 = 1;
                                break;
                            case 0x02:
                                this.ANT2 = 1;
                                break;
                            case 0x03:
                                this.ANT3 = 1;
                                break;
                            case 0x04:
                                this.ANT4 = 1;
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                default: throw new NotImplementedException();
            }
        }
        internal enum InitType
        {
            /// <summary>
            /// 读标签
            /// </summary>
            Read,
            /// <summary>
            /// 写标签
            /// </summary>
            Write,
            /// <summary>
            /// 缓存标签
            /// </summary>
            Buffer,
            /// <summary>
            /// 锁定标签
            /// </summary>
            Lock,
            /// <summary>
            /// 销毁标签
            /// </summary>
            Kill,
            /// <summary>
            /// 实时标签
            /// </summary>
            Real,
            /// <summary>
            /// 快速4天
            /// </summary>
            Fast,
        }
    }
    /// <summary>
    /// 标签信息
    /// </summary>
    public class R600TagInfoIso18000
    {
        /// <summary>
        /// 键
        /// </summary>
        public string Key { get; }
        /// <summary>
        /// 
        /// </summary>
        public byte AntId { get; }
        /// <summary>
        /// 
        /// </summary>
        public byte[] UID { get; }
        /// <summary>
        /// 
        /// </summary>
        public int Total { get; }
        /// <summary>
        /// 
        /// </summary>
        public byte StartAdd { get; }
        /// <summary>
        /// 
        /// </summary>
        public int Length { get; }
        /// <summary>
        /// 
        /// </summary>
        public byte[] Data { get; }
        /// <summary>
        /// 
        /// </summary>
        public byte Status { get; }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="aryData"></param>
        public R600TagInfoIso18000(byte[] aryData)
        {
            var antId = aryData[0]; // string strAntID = R600Method.ByteArrayToString(msgTran.AryData, 0, 1);
            var uid = new byte[8];
            Array.Copy(aryData, 1, uid, 0, 8);// string strUID = R600Method.ByteArrayToString(msgTran.AryData, 1, 8);

            this.Key = uid.GetMd5String();
            this.AntId = antId;
            this.UID = uid;
            this.Total = 1;
        }
    }
}
