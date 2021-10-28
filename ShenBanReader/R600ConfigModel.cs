using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// 深坂600的配置模型
    /// </summary>
    public struct R600ConfigModel
    {
        /// <summary>
        /// 寄存器
        /// </summary>
        public byte ReadId;
        /// <summary>
        /// 主版本
        /// </summary>
        public byte Major;
        /// <summary>
        /// 次版本
        /// </summary>
        public byte Minor;
        /// <summary>
        /// 波特率
        /// </summary>
        public byte IndexBaudrate;
        /// <summary>
        /// 温度正负
        /// </summary>
        public byte PlusMinus;
        /// <summary>
        /// 温度
        /// </summary>
        public byte Temperature;
        /// <summary>
        /// 温度℃
        /// </summary>
        public string TemperatureText;
        /// <summary>
        /// 输出功率
        /// </summary>
        public byte OutputPower;
        /// <summary>
        /// 工作天线
        /// </summary>
        public byte WorkAntenna;
        /// <summary>
        /// DRM状态
        /// </summary>
        public byte DrmMode;
        /// <summary>
        /// 射频频谱
        /// </summary>
        public byte FrequencyRegion;
        /// <summary>
        /// 频谱开始
        /// </summary>
        public byte FrequencyStart;
        /// <summary>
        /// 频谱结束
        /// </summary>
        public byte FrequencyEnd;
        /// <summary>
        /// 用户自定义频谱开始
        /// </summary>
        public int UserDefineStartFrequency;
        /// <summary>
        /// 用户自定义频谱间距
        /// </summary>
        public byte UserDefineFrequencyInterval;
        /// <summary>
        /// 用户自定义量值
        /// </summary>
        public byte UserDefineChannelQuantity;
        /// <summary>
        /// 蜂鸣模式
        /// </summary>
        public byte BeeperMode;
        /// <summary>
        /// GPIO1值
        /// </summary>
        public byte Gpio1Value;
        /// <summary>
        /// GPIO2值
        /// </summary>
        public byte Gpio2Value;
        /// <summary>
        /// GPIO3值
        /// </summary>
        public byte Gpio3Value;
        /// <summary>
        /// GPIO4值
        /// </summary>
        public byte Gpio4Value;
        /// <summary>
        /// 是GPIO1低位
        /// </summary>
        public bool IsGpio1Low;
        /// <summary>
        /// 是GPIO2低位
        /// </summary>
        public bool IsGpio2Low;
        /// <summary>
        /// 读取天线连接检测阈值
        /// </summary>
        public byte AntDetector;
        /// <summary>
        /// 
        /// </summary>
        public byte MonzaStatus;
        /// <summary>
        /// 
        /// </summary>
        public string ReaderIdentifier;
        /// <summary>
        /// 测量天线端口阻抗匹配
        /// 1.读写标签时系统自动测量天线端口的回波损耗(Return Loss)。
        /// 2.为保护设备，检测到回波损耗大于此阈值将报错并停止读写标签操作。
        /// 3.此阈值越大对天线端口阻抗匹配要求越高，设为0关闭此功能。
        /// </summary>
        public byte AntImpedance;
        /// <summary>
        /// 
        /// </summary>
        public byte ImpedanceFrequency;

        /// <summary>
        /// 射频通讯链路
        /// </summary>
        public byte LinkProfile;
        /// <summary>
        /// 射频通讯链路枚举
        /// </summary>
        public R600LinkProfileType R600LinkProfileType;
        /// <summary>
        /// 固件版本
        /// </summary>
        public string FirmwareVersion;
        /// <summary>
        /// 选定标签
        /// </summary>
        internal byte[] AccessEpcMatch;
        #region // R600InventoryISO18000Model
        /// <summary>
        /// 
        /// </summary>
        public byte IsoAntId;
        /// <summary>
        /// 
        /// </summary>
        public int IsoTagCnt;
        /// <summary>
        /// 
        /// </summary>
        public byte[] IsoReadData;
        /// <summary>
        /// 
        /// </summary>
        public byte IsoWriteLength;
        /// <summary>
        /// 
        /// </summary>
        public byte IsoStatus;
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, R600TagModel> IsoTags;
        #endregion
        #region // R600InventoryModel
        /// <summary>
        /// 
        /// </summary>
        public byte InvRepeat;
        /// <summary>
        /// 
        /// </summary>
        public byte InvSession;
        /// <summary>
        /// 
        /// </summary>
        public byte InvTarget;
        /// <summary>
        /// 
        /// </summary>
        public List<byte> InvAntennas;
        /// <summary>
        /// 
        /// </summary>
        public bool IsInvLoop;
        /// <summary>
        /// 
        /// </summary>
        public int InvIndexAntenna;
        /// <summary>
        /// 
        /// </summary>
        public int InvCommond;
        /// <summary>
        /// 
        /// </summary>
        public bool IsInvLoopReal;
        /// <summary>
        /// 
        /// </summary>
        public bool IsInvLoopSession;
        /// <summary>
        /// 标签计数
        /// </summary>
        public int InvTagCount;
        /// <summary>
        /// 返回的标签数量
        /// </summary>
        public int InvDataCount; //执行一次命令所返回的标签记录条数
        /// <summary>
        /// 
        /// </summary>
        public int InvCommandDuration;
        /// <summary>
        /// 读取速率
        /// </summary>
        public int InvReadRate;
        /// <summary>
        /// 
        /// </summary>
        public int InvCurrentAnt;
        /// <summary>
        /// 
        /// </summary>
        public List<int> InvTotalReads;
        /// <summary>
        /// 开始
        /// </summary>
        public DateTime InvStart;
        /// <summary>
        /// 结束
        /// </summary>
        public DateTime InvEnd;
        /// <summary>
        /// 间距
        /// </summary>
        public int InvDuration;
        /// <summary>
        /// 
        /// </summary>
        public int InvMaxRSSI;
        /// <summary>
        /// 
        /// </summary>
        public int InvMinRSSI;
        /// <summary>
        /// 标签列表
        /// </summary>
        public ConcurrentDictionary<string, R600TagModel> InvTags;
        /// <summary>
        /// 正在盘存
        /// </summary>
        public bool IsInventory;
        /// <summary>
        /// 盘存次数
        /// </summary>
        internal int InvTotal;

        internal void SetMaxMinRSSI(int nRSSI)
        {
            if (InvMaxRSSI < nRSSI)
            {
                InvMaxRSSI = nRSSI;
            }

            if (InvMinRSSI == 0)
            {
                InvMinRSSI = nRSSI;
            }
            else if (InvMinRSSI > nRSSI)
            {
                InvMinRSSI = nRSSI;
            }
        }
        #endregion
    }
    /// <summary>
    /// R600标签模型
    /// </summary>
    public struct R600TagModel
    {
        /// <summary>
        /// 键
        /// </summary>
        public string Key;
        /// <summary>
        /// 
        /// </summary>
        public byte[] PC;
        /// <summary>
        /// 
        /// </summary>
        public Byte[] CRC;
        /// <summary>
        /// 
        /// </summary>
        public byte[] EPC;
        /// <summary>
        /// 
        /// </summary>
        public int ELen;
        /// <summary>
        /// 
        /// </summary>
        public byte RSSI;
        /// <summary>
        /// 
        /// </summary>
        public double FREQ;
        /// <summary>
        /// 
        /// </summary>
        public int INVCNT;
        /// <summary>
        /// 
        /// </summary>
        public byte[] Data;
        /// <summary>
        /// 
        /// </summary>
        public int DLen;
        /// <summary>
        /// 
        /// </summary>
        public byte AntId;
        /// <summary>
        /// 
        /// </summary>
        public byte ReadCount;
        /// <summary>
        /// 
        /// </summary>
        public int ANT1;
        /// <summary>
        /// 
        /// </summary>
        public int ANT2;
        /// <summary>
        /// 
        /// </summary>
        public int ANT3;
        /// <summary>
        /// 
        /// </summary>
        public int ANT4;
        #region // R600TagISO18000Model
        /// <summary>
        /// 
        /// </summary>
        public byte IsoAntId;
        /// <summary>
        /// 
        /// </summary>
        public byte[] IsoUID;
        /// <summary>
        /// 
        /// </summary>
        public int IsoTotal;
        /// <summary>
        /// 
        /// </summary>
        public byte IsoStartAdd;
        /// <summary>
        /// 
        /// </summary>
        public int IsoLength;
        /// <summary>
        /// 
        /// </summary>
        public byte[] IsoData;
        /// <summary>
        /// 
        /// </summary>
        public byte IsoStatus;
        #endregion
        /// <summary>
        /// 填充数据
        /// </summary>
        /// <param name="aryData"></param>
        /// <returns></returns>
        public static R600TagModel Read(byte[] aryData)
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
            return new R600TagModel
            {
                Key = epc.GetHexString(),
                PC = pc,
                CRC = crc,
                EPC = epc,
                ELen = nEpcLen,
                Data = data,
                DLen = nDataLen,
                AntId = byAntId,
                ReadCount = aryData[nLen - 1]
            };
        }
        /// <summary>
        /// 填充数据(缓存)
        /// </summary>
        /// <param name="aryData"></param>
        /// <returns></returns>
        public static R600TagModel Buffer(byte[] aryData)
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
            return new R600TagModel
            {
                Key = epc.GetHexString(),
                PC = pc,
                CRC = crc,
                EPC = epc,
                ELen = nEpcLen,
                AntId = byAntId,
                RSSI = rssi,
                INVCNT = invcnt
            };
        }
        /// <summary>
        /// 填充数据(不包括data部分)
        /// </summary>
        /// <param name="aryData"></param>
        /// <returns></returns>
        public static R600TagModel Write(byte[] aryData)
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
            return new R600TagModel
            {
                Key = epc.GetHexString(),
                PC = pc,
                CRC = crc,
                EPC = epc,
                ELen = nEpcLen,
                Data = data,
                DLen = 0,
                AntId = byAntId,
                ReadCount = aryData[nLen - 1]
            };
        }
        /// <summary>
        /// 填充数据(不包括data部分)
        /// </summary>
        /// <param name="aryData"></param>
        /// <returns></returns>
        public static R600TagModel Lock(byte[] aryData)
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
            return new R600TagModel
            {
                Key = epc.GetHexString(),
                PC = pc,
                CRC = crc,
                EPC = epc,
                ELen = nEpcLen,
                Data = data,
                DLen = 0,
                AntId = byAntId,
                ReadCount = aryData[nLen - 1]
            };
        }
        /// <summary>
        /// 填充数据(不包括data部分)
        /// </summary>
        /// <param name="aryData"></param>
        /// <returns></returns>
        public static R600TagModel Kill(byte[] aryData)
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
            return new R600TagModel
            {
                Key = epc.GetHexString(),
                PC = pc,
                CRC = crc,
                EPC = epc,
                ELen = nEpcLen,
                Data = data,
                DLen = 0,
                AntId = byAntId,
                ReadCount = aryData[nLen - 1]
            };
        }
    }
}
