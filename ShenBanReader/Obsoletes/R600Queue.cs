using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// 响应接口
    /// </summary>
    public interface IR600Queue : IDisposable
    {
        /// <summary>
        /// 接收回调
        /// </summary>
        Action<Byte[]> ReceiveCallback { get; }
        /// <summary>
        /// 发送回调
        /// </summary>
        Action<Byte[]> SendCallback { get; }
        /// <summary>
        /// 是连接状态
        /// </summary>
        bool IsConnected { get; }
        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="portName"></param>
        /// <param name="baudRate"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        bool Connect(string portName, int baudRate, out string exception);
        /// <summary>
        /// 连接网口
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        bool Connect(IPAddress ip, int port, out string exception);
        /// <summary>
        /// 注册命令回调
        /// </summary>
        /// <param name="model"></param>
        void RegistCallback(IR600CallMethod model);
        /// <summary>
        /// 注册命令回调
        /// </summary>
        /// <param name="model"></param>
        void RegistCallback(IR600CallAction model);
        /// <summary>
        /// 读GPIO值
        /// <see cref="IR600CallAction.ReadGpioValue"/>
        /// </summary>
        /// <returns></returns>
        int ReadGpioValue(byte btReadId, Action<IReadMessage, byte, byte, bool, bool> ReadGpioValue);
        /// <summary>
        /// 写GPIO值
        /// <see cref="IR600CallAction.WriteGpioValue"/>
        /// </summary>
        /// <returns></returns>
        int WriteGpioValue(byte btReadId, byte btChooseGpio, byte btGpioValue, Action<IReadMessage> WriteGpioValue);
        /// <summary>
        /// 设置天线连接检测阈值
        /// </summary>
        /// <returns></returns>
        /// <see cref="IR600CallAction.SetAntDetector"/>
        int SetAntDetector(byte btReadId, byte btDetectorStatus, Action<IReadMessage> SetAntDetector);
        /// <summary>
        /// 读取天线连接检测阈值
        /// <see cref="IR600CallAction.GetAntDetector"/>
        /// </summary>
        /// <returns></returns>
        int GetAntDetector(byte btReadId, Action<IReadMessage, byte> GetAntDetector);
        /// <summary>
        /// 设置读ID
        /// <see cref="IR600CallAction.SetReaderIdentifier"/>
        /// </summary>
        /// <returns></returns>
        int SetReaderIdentifier(byte btReadId, byte[] identifier, Action<IReadMessage> SetReaderIdentifier);
        /// <summary>
        /// 获取读ID
        /// <see cref="IR600CallAction.GetReaderIdentifier"/>
        /// </summary>
        /// <returns></returns>
        int GetReaderIdentifier(byte btReadId, Action<IReadMessage, byte[]> GetReaderIdentifier);
        /// <summary>
        /// 设置配置
        /// <see cref="IR600CallAction.SetLinkProfile"/>
        /// </summary>
        /// <returns></returns>
        int SetLinkProfile(byte btReadId, byte btProfile, Action<IReadMessage, byte> SetLinkProfile);
        /// <summary>
        /// 获取配置
        /// <see cref="IR600CallAction.GetLinkProfile"/>
        /// </summary>
        /// <returns></returns>
        int GetLinkProfile(byte btReadId, Action<IReadMessage, ReadLinkProfileType> GetLinkProfile);
        /// <summary>
        /// 重置
        /// </summary>
        /// <returns></returns>
        int Reset(byte btReadId);
        /// <summary>
        /// 设置非同步收发传输器波特率
        /// <see cref="IR600CallAction.SetUartBaudRate"/>
        /// </summary>
        /// <returns></returns>
        int SetUartBaudRate(byte btReadId, int nIndexBaudrate, Action<IReadMessage> SetUartBaudRate);
        /// <summary>
        /// 获取固件版本
        /// <see cref="IR600CallAction.GetFirmwareVersion"/>
        /// </summary>
        /// <returns></returns>
        int GetFirmwareVersion(byte btReadId, Action<IReadMessage, byte, byte> GetFirmwareVersion);
        /// <summary>
        /// 设置读地址
        /// <see cref="IR600CallAction.SetReaderAddress"/>
        /// </summary>
        /// <returns></returns>
        int SetReaderAddress(byte btReadId, byte btNewReadId, Action<IReadMessage> SetReaderAddress);
        /// <summary>
        /// 设置工作天线
        /// <see cref="IR600CallAction.SetWorkAntenna"/>
        /// </summary>
        /// <returns></returns>
        int SetWorkAntenna(byte btReadId, byte btWorkAntenna, Action<IReadMessage> SetWorkAntenna);
        /// <summary>
        /// 获取工作天线
        /// <see cref="IR600CallAction.GetWorkAntenna"/>
        /// </summary>
        /// <returns></returns>
        int GetWorkAntenna(byte btReadId, Action<IReadMessage, ReadAntennaType> GetWorkAntenna);
        /// <summary>
        /// 设置输出功率
        /// <see cref="IR600CallAction.SetOutputPower"/>
        /// </summary>
        /// <returns></returns>
        int SetOutputPower(byte btReadId, byte btOutputPower, Action<IReadMessage> SetOutputPower);
        /// <summary>
        /// 获取输出功率
        /// <see cref="IR600CallAction.GetOutputPower"/>
        /// </summary>
        /// <returns></returns>
        int GetOutputPower(byte btReadId, Action<IReadMessage, byte> GetOutputPower);
        /// <summary>
        /// 设置频率区域
        /// <see cref="IR600CallAction.SetFrequencyRegion"/>
        /// </summary>
        /// <returns></returns>
        int SetFrequencyRegion(byte btReadId, ReadFreqRegionType btRegion, int btStart, byte btInterval, byte btChanelQuality, Action<IReadMessage> SetFrequencyRegion);
        /// <summary>
        /// 得到频率区域
        /// <see cref="IR600CallAction.GetFrequencyRegion"/>
        /// </summary>
        /// <returns></returns>
        int GetFrequencyRegion(byte btReadId, Action<IReadMessage, ReadFreqRegionType, int, byte, byte> GetFrequencyRegion);
        /// <summary>
        /// 设置呼叫模式
        /// <see cref="IR600CallAction.SetBeeperMode"/>
        /// </summary>
        /// <returns></returns>
        int SetBeeperMode(byte btReadId, byte btMode, Action<IReadMessage> SetBeeperMode);
        /// <summary>
        /// 得到工作温度
        /// <see cref="IR600CallAction.GetReaderTemperature"/>
        /// </summary>
        /// <returns></returns>
        int GetReaderTemperature(byte btReadId, Action<IReadMessage, int> GetReaderTemperature);
        /// <summary>
        /// 设置DRM模式
        /// <see cref="IR600CallAction.SetDrmMode"/>
        /// </summary>
        /// <returns></returns>
        int SetDrmMode(byte btReadId, byte btDrmMode, Action<IReadMessage> SetDrmMode);
        /// <summary>
        /// 获取DRM模式
        /// <see cref="IR600CallAction.GetDrmMode"/>
        /// </summary>
        /// <returns></returns>
        int GetDrmMode(byte btReadId, Action<IReadMessage, bool> GetDrmMode);
        /// <summary>
        /// 回波损耗测量
        /// <see cref="IR600CallAction.GetImpedanceMatch"/>
        /// </summary>
        /// <returns></returns>
        [Obsolete("替代方案:GetImpedanceMatch")]
        int MeasureReturnLoss(byte btReadId, byte btFrequency, Action<IReadMessage, byte> GetImpedanceMatch);
        /// <summary>
        /// 获得阻抗匹配
        /// <see cref="IR600CallAction.GetImpedanceMatch"/>
        /// </summary>
        /// <returns></returns>
        int GetImpedanceMatch(byte btReadId, byte btFrequency, Action<IReadMessage, byte> GetImpedanceMatch);
        /// <summary>
        /// 盘存
        /// <see cref="IR600CallAction.Inventory"/>
        /// </summary>
        /// <returns></returns>
        int Inventory(byte btReadId, byte byRound, Action<IReadMessage, byte, int, int, int, int> Inventory);
        /// <summary>
        /// 读标签
        /// <see cref="IR600CallAction.ReadTag"/>
        /// </summary>
        /// <returns></returns>
        int ReadTag(byte btReadId, byte btMemBank, byte btWordAdd, byte btWordCnt, Action<IReadMessage, R600TagInfo> ReadTag);
        /// <summary>
        /// 写标签
        /// <see cref="IR600CallAction.WriteTag"/>
        /// </summary>
        /// <returns></returns>
        int WriteTag(byte btReadId, byte[] btAryPassWord, byte btMemBank, byte btWordAdd, byte btWordCnt, byte[] btAryData, Action<IReadMessage, R600TagInfo> WriteTag);
        /// <summary>
        /// 锁定标签
        /// <see cref="IR600CallAction.LockTag"/>
        /// </summary>
        /// <returns></returns>
        int LockTag(byte btReadId, byte[] btAryPassWord, byte btMembank, byte btLockType, Action<IReadMessage, R600TagInfo> LockTag);
        /// <summary>
        /// 释放标记
        /// <see cref="IR600CallAction.KillTag"/>
        /// </summary>
        /// <returns></returns>
        int KillTag(byte btReadId, byte[] btAryPassWord, Action<IReadMessage, R600TagInfo> KillTag);
        /// <summary>
        /// 设置EPC(btEpcLen=0为取消)
        /// <see cref="IR600CallAction.SetAccessEpcMatch"/>
        /// </summary>
        /// <returns></returns>
        int SetAccessEpcMatch(byte btReadId, byte btMode, byte btEpcLen, byte[] btAryEpc, Action<IReadMessage> SetAccessEpcMatch);
        /// <summary>
        /// 获取EPC
        /// <see cref="IR600CallAction.GetAccessEpcMatch"/>
        /// </summary>
        /// <returns></returns>
        int GetAccessEpcMatch(byte btReadId, Action<IReadMessage, byte[]> GetAccessEpcMatch);
        /// <summary>
        /// 实时存盘
        /// <see cref="IR600CallAction.InventoryReal"/>
        /// <see cref="IR600CallAction.InventoryRealEnd"/>
        /// </summary>
        /// <returns></returns>
        int InventoryReal(byte btReadId, byte byRound, Action<IReadMessage, R600TagInfo> InventoryReal, Action<IReadMessage, int, int> InventoryRealEnd);
        /// <summary>
        /// 快速存盘
        /// <see cref="IR600CallAction.FastSwitchInventory"/>
        /// <see cref="IR600CallAction.FastSwitchInventoryEnd"/>
        /// </summary>
        /// <returns></returns>
        int FastSwitchInventory(byte btReadId, byte[] btAryData, Action<IReadMessage, R600TagInfo> FastSwitchInventory, Action<IReadMessage, int, int> FastSwitchInventoryEnd);
        /// <summary>
        /// 自定义存盘
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="session"></param>
        /// <param name="target"></param>
        /// <param name="byRound"></param>
        /// <returns></returns>
        int CustomizedInventory(byte btReadId, byte session, byte target, byte byRound);
        /// <summary>
        /// 设置Impinj Monza快速读TID功能
        /// <see cref="IR600CallAction.GetMonzaStatus"/>
        /// </summary>
        /// <returns></returns>
        int GetMonzaStatus(byte btReadId, Action<IReadMessage, byte> GetMonzaStatus);
        /// <summary>
        /// 设置Impinj Monza快速读TID功能
        /// <see cref="IR600CallAction.SetMonzaStatus"/>
        /// </summary>
        /// <returns></returns>
        int SetMonzaStatus(byte btReadId, byte btMonzaStatus, Action<IReadMessage, byte> SetMonzaStatus);
        /// <summary>
        /// 获取存盘
        /// <see cref="IR600CallAction.GetInventoryBuffer"/>
        /// </summary>
        /// <returns></returns>
        int GetInventoryBuffer(byte btReadId, Action<IReadMessage, R600TagInfo> GetInventoryBuffer);
        /// <summary>
        /// 
        /// <see cref="IR600CallAction.GetAndResetInventoryBuffer"/>
        /// </summary>
        /// <returns></returns>
        int GetAndResetInventoryBuffer(byte btReadId, Action<IReadMessage, R600TagInfo> GetAndResetInventoryBuffer);
        /// <summary>
        /// 
        /// <see cref="IR600CallAction.GetInventoryBufferTagCount"/>
        /// </summary>
        /// <returns></returns>
        int GetInventoryBufferTagCount(byte btReadId, Action<IReadMessage, int> GetInventoryBufferTagCount);
        /// <summary>
        /// 
        /// <see cref="IR600CallAction.ResetInventoryBuffer"/>
        /// </summary>
        /// <returns></returns>
        int ResetInventoryBuffer(byte btReadId, Action<IReadMessage> ResetInventoryBuffer);
        /// <summary>
        /// 未实现
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btInterval"></param>
        /// <returns></returns>
        int SetBufferDataFrameInterval(byte btReadId, byte btInterval);
        /// <summary>
        /// 未实现
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetBufferDataFrameInterval(byte btReadId);
        /// <summary>
        /// 
        /// <see cref="IR600CallAction.InventoryISO18000"/>
        /// </summary>
        /// <returns></returns>
        int InventoryISO18000(byte btReadId, Action<IReadMessage, R600TagInfoIso18000> InventoryISO18000, Action<IReadMessage, int> InventoryISO18000End);
        /// <summary>
        /// 
        /// <see cref="IR600CallAction.ReadTagISO18000"/>
        /// </summary>
        /// <returns></returns>
        int ReadTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd, byte btWordCnt, Action<IReadMessage, byte, byte[]> ReadTagISO18000);
        /// <summary>
        /// 
        /// <see cref="IR600CallAction.WriteTagISO18000"/>
        /// </summary>
        /// <returns></returns>
        int WriteTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd, byte btWordCnt, byte[] btAryBuffer, Action<IReadMessage, byte, byte> WriteTagISO18000);
        /// <summary>
        /// 
        /// <see cref="IR600CallAction.LockTagISO18000"/>
        /// </summary>
        /// <returns></returns>
        int LockTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd, Action<IReadMessage, byte, ReadLockTagStatus> LockTagISO18000);
        /// <summary>
        /// 
        /// <see cref="IR600CallAction.QueryTagISO18000"/>
        /// </summary>
        /// <returns></returns>
        int QueryTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd, Action<IReadMessage, byte, ReadLockTagStatus> QueryTagISO18000);
        /// <summary>
        /// 正在连接
        /// </summary>
        /// <returns></returns>
        bool IsConnecting();
        /// <summary>
        /// 关闭com口
        /// </summary>
        void Close();
    }
    /// <summary>
    /// 调用实现类
    /// </summary>
    internal class R600Queue : IR600Queue
    {
        /// <summary>
        /// 接收回调
        /// </summary>
        public Action<Byte[]> ReceiveCallback { get; internal set; }
        /// <summary>
        /// 发送回调
        /// </summary>
        public Action<Byte[]> SendCallback { get; internal set; }
        /// <summary>
        /// 分析回调
        /// </summary>
        public Action<IReadMessage> AnalysisCallback { get; internal set; }
        /// <summary>
        /// 回调模型
        /// </summary>
        protected IR600CallAction _recall;
        /// <summary>
        /// 内部链接模型
        /// </summary>
        internal ITalkReadModel _talker;
        /// <summary>
        /// 记录未处理的接收数据，主要考虑接收数据分段
        /// </summary>
        protected byte[] m_btAryBuffer = new byte[4096];
        /// <summary>
        /// 记录未处理数据的有效长度
        /// </summary>
        protected int m_nLenth = 0;
        #region // 构造及连接
        ///// <summary>
        ///// 配置信息
        ///// </summary>
        //private R600ConfigModel _config;
        /// <summary>
        /// 构造
        /// </summary>
        public R600Queue()
        {
            this._recall = new R600CallAction();
            this._talker = new TalkReadModel();
            this.AnalysisCallback = AnalyData;
            //_config = new R600ConfigModel();
        }
        /// <summary>
        /// 串口构造
        /// </summary>
        /// <param name="portName"></param>
        /// <param name="baudRate"></param>
        public R600Queue(string portName, int baudRate)
        {
            Connect(portName, baudRate, out string exception);
            this.AnalysisCallback = AnalyData;
        }
        /// <summary>
        /// 网口构造
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="baudRate"></param>
        public R600Queue(IPAddress ip, int baudRate)
        {
            Connect(ip, baudRate, out string exception);
            this.AnalysisCallback = AnalyData;
        }
        /// <summary>
        /// 是连接
        /// </summary>
        public bool IsConnected { get => _talker.IsConnected; }
        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="portName"></param>
        /// <param name="baudRate"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public bool Connect(string portName, int baudRate, out string exception)
        {
            _talker?.Dispose();
            _talker = new SerialTalkReadModel();
            _talker.Received += RunReceiveDataCallback;
            return _talker.Connect(portName, baudRate, out exception);
        }
        /// <summary>
        /// 连接网口
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public bool Connect(IPAddress ip, int port, out string exception)
        {
            _talker?.Dispose();
            _talker = new TcpTalkReadModel();
            _talker.Received += RunReceiveDataCallback;
            return _talker.Connect(ip, port, out exception);
        }
        #endregion
        #region // 接收及分析
        private void RunReceiveDataCallback(byte[] btAryReceiveData)
        {
            try
            {
                ReceiveCallback?.Invoke(btAryReceiveData);

                int nCount = btAryReceiveData.Length;
                byte[] btAryBuffer = new byte[nCount + m_nLenth];
                Array.Copy(m_btAryBuffer, btAryBuffer, m_nLenth);
                Array.Copy(btAryReceiveData, 0, btAryBuffer, m_nLenth, btAryReceiveData.Length);

                //分析接收数据，以0xA0为数据起点，以协议中数据长度为数据终止点
                int nIndex = 0;//当数据中存在A0时，记录数据的终止点
                int nMarkIndex = 0;//当数据中不存在A0时，nMarkIndex等于数据组最大索引
                for (int nLoop = 0; nLoop < btAryBuffer.Length; nLoop++)
                {
                    if (btAryBuffer.Length > nLoop + 1)
                    {
                        if (btAryBuffer[nLoop] == 0xA0)
                        {
                            int nLen = Convert.ToInt32(btAryBuffer[nLoop + 1]);
                            if (nLoop + 1 + nLen < btAryBuffer.Length)
                            {
                                byte[] btAryAnaly = new byte[nLen + 2];
                                Array.Copy(btAryBuffer, nLoop, btAryAnaly, 0, nLen + 2);
                                try
                                {
                                    AnalysisCallback?.Invoke(new R600Message(btAryAnaly));
                                }
                                catch (Exception ex)
                                {
                                    _recall.AlertCallbackError(ex);
                                }

                                nLoop += 1 + nLen;
                                nIndex = nLoop + 1;
                            }
                            else
                            {
                                nLoop += 1 + nLen;
                            }
                        }
                        else
                        {
                            nMarkIndex = nLoop;
                        }
                    }
                }

                if (nIndex < nMarkIndex)
                {
                    nIndex = nMarkIndex + 1;
                }

                if (nIndex < btAryBuffer.Length)
                {
                    m_nLenth = btAryBuffer.Length - nIndex;
                    Array.Clear(m_btAryBuffer, 0, 4096);
                    Array.Copy(btAryBuffer, nIndex, m_btAryBuffer, 0, btAryBuffer.Length - nIndex);
                }
                else
                {
                    m_nLenth = 0;
                }
            }
            catch { }
        }

        /// <summary>
        /// 分析数据
        /// </summary>
        /// <param name="msgTran"></param>
        private void AnalyData(IReadMessage msgTran)
        {
            if (msgTran.PacketType != 0xA0)
            {
                _recall.AlertUnknownPacketType(msgTran);
                return;
            }
            switch (msgTran.Cmd)
            {
                case 0x60: ProcessReadGpioValue(msgTran); break;
                case 0x61: ProcessWriteGpioValue(msgTran); break;
                case 0x62: ProcessSetAntDetector(msgTran); break;
                case 0x63: ProcessGetAntDetector(msgTran); break;
                case 0x67: ProcessSetReaderIdentifier(msgTran); break;
                case 0x68: ProcessGetReaderIdentifier(msgTran); break;
                case 0x69: ProcessSetLinkProfile(msgTran); break;
                case 0x6A: ProcessGetLinkProfile(msgTran); break;
                case 0x70: ProcessReset(msgTran); break;
                case 0x71: ProcessSetUartBaudRate(msgTran); break;
                case 0x72: ProcessGetFirmwareVersion(msgTran); break;
                case 0x73: ProcessSetReaderAddress(msgTran); break;
                case 0x74: ProcessSetWorkAntenna(msgTran); break;
                case 0x75: ProcessGetWorkAntenna(msgTran); break;
                case 0x76: ProcessSetOutputPower(msgTran); break;
                case 0x77: ProcessGetOutputPower(msgTran); break;
                case 0x78: ProcessSetFrequencyRegion(msgTran); break;
                case 0x79: ProcessGetFrequencyRegion(msgTran); break;
                case 0x7A: ProcessSetBeeperMode(msgTran); break;
                case 0x7B: ProcessGetReaderTemperature(msgTran); break;
                case 0x7C: ProcessSetDrmMode(msgTran); break;
                case 0x7D: ProcessGetDrmMode(msgTran); break;
                case 0x7E: ProcessGetImpedanceMatch(msgTran); break;
                case 0x80: ProcessInventory(msgTran); break;
                case 0x81: ProcessReadTag(msgTran); break;
                case 0x82: ProcessWriteTag(msgTran); break;
                case 0x83: ProcessLockTag(msgTran); break;
                case 0x84: ProcessKillTag(msgTran); break;
                case 0x85: ProcessSetAccessEpcMatch(msgTran); break;
                case 0x86: ProcessGetAccessEpcMatch(msgTran); break;
                case 0x89: ProcessInventoryReal(msgTran); break;
                case 0x8A: ProcessFastSwitchInventory(msgTran); break;
                case 0x8B: ProcessInventoryReal(msgTran); break;
                case 0x8D: ProcessSetMonzaStatus(msgTran); break;
                case 0x8E: ProcessGetMonzaStatus(msgTran); break;
                case 0x90: ProcessGetInventoryBuffer(msgTran); break;
                case 0x91: ProcessGetAndResetInventoryBuffer(msgTran); break;
                case 0x92: ProcessGetInventoryBufferTagCount(msgTran); break;
                case 0x93: ProcessResetInventoryBuffer(msgTran); break;
                case 0x94: ProcessSetBufferDataFrameInterval(msgTran); break;
                case 0x95: ProcessGetBufferDataFrameInterval(msgTran); break;
                case 0xB0: ProcessInventoryISO18000(msgTran); break;
                case 0xB1: ProcessReadTagISO18000(msgTran); break;
                case 0xB2: ProcessWriteTagISO18000(msgTran); break;
                case 0xB3: ProcessLockTagISO18000(msgTran); break;
                case 0xB4: ProcessQueryTagISO18000(msgTran); break;
                default:
                    _recall.AlertUnknownPacketType(msgTran);
                    break;
            }
        }

        /// <summary>
        /// 读取GPIO状态
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessReadGpioValue(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length == 2)
            {
                byte gpio1Value = msgTran.AryData[0];
                byte gpio2Value = msgTran.AryData[1];
                bool isGpio1Low = gpio1Value == 0x00;
                bool isGpio2Low = gpio2Value == 0x00;
                //_config.ReadId = msgTran.ReadId;
                //_config.Gpio1Value = gpio1Value;
                //_config.Gpio2Value = gpio2Value;
                //_config.IsGpio1Low = isGpio1Low;
                //_config.IsGpio2Low = isGpio2Low;
                _recall.ReadGpioValue(msgTran, gpio1Value, gpio2Value, isGpio1Low, isGpio2Low);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.ReadGpioValue, code, nameof(ProcessReadGpioValue), $"读取GPIO状态失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 设置GPIO状态
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessWriteGpioValue(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length == 1 && msgTran.AryData[0] == 0x10)
            {
                //_config.ReadId = msgTran.ReadId;
                _recall?.WriteGpioValue(msgTran);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.WriteGpioValue, code, nameof(ProcessWriteGpioValue), $"设置GPIO状态失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 设置天线连接检测阈值
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessSetAntDetector(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length == 1 && msgTran.AryData[0] == 0x10)
            {
                //_config.ReadId = msgTran.ReadId;
                _recall.SetAntDetector(msgTran);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.SetAntDetector, code, nameof(ProcessSetAntDetector), $"设置天线连接检测阈值失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 读取天线连接检测阈值
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessGetAntDetector(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                //_config.ReadId = msgTran.ReadId;
                //_config.AntDetector = msgTran.AryData[0];
                _recall.GetAntDetector(msgTran, msgTran.AryData[0]);
                return;
            }
            ProcessError(ReadCmdType.GetAntDetector, 0, nameof(ProcessGetAntDetector), "失败，失败原因：未知错误", msgTran);
        }

        /// <summary>
        /// 设置读写器识别标记
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessSetReaderIdentifier(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length == 1 && msgTran.AryData[0] == 0x10)
            {
                //_config.ReadId = msgTran.ReadId;
                _recall.SetReaderIdentifier(msgTran);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.SetReaderIdentifier, 0, nameof(ProcessSetReaderIdentifier), $"设置读写器识别标记失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 读取读写器识别标记
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessGetReaderIdentifier(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length == 12)
            {
                //_config.ReadId = msgTran.ReadId;
                //_config.ReaderIdentifier = msgTran.AryData.GetHexString();
                _recall.GetReaderIdentifier(msgTran, msgTran.AryData);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.GetReaderIdentifier, code, nameof(ProcessGetReaderIdentifier), $"读取读写器识别标记失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 设置射频通讯链路配置
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessSetLinkProfile(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length == 1 && msgTran.AryData[0] == 0x10)
            {
                //_config.ReadId = msgTran.ReadId;
                //_config.LinkProfile = msgTran.AryData[0];
                _recall.SetLinkProfile(msgTran, msgTran.AryData[0]);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.SetLinkProfile, code, nameof(ProcessSetLinkProfile), $"设置射频通讯链路配置失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 读取射频通讯链路配置
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessGetLinkProfile(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length == 1 && (msgTran.AryData[0] >= 0xd0) && (msgTran.AryData[0] <= 0xd3))
            {
                //_config.ReadId = msgTran.ReadId;
                //_config.LinkProfile = msgTran.AryData[0];
                //_config.R600LinkProfileType = (R600LinkProfileType)_config.LinkProfile;
                _recall.GetLinkProfile(msgTran, (ReadLinkProfileType)msgTran.AryData[0]);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.GetLinkProfile, code, nameof(ProcessGetLinkProfile), $"读取射频通讯链路配置失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 复位读写器(可以不需要返回)
        /// </summary>
        /// <param name="msgTran"></param>
        private void ProcessReset(IReadMessage msgTran)
        {

        }

        /// <summary>
        /// 设置波特率
        /// </summary>
        /// <param name="msgTran"></param>
        private void ProcessSetUartBaudRate(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length == 1 && msgTran.AryData[0] == 0x10)
            {
                //_config.ReadId = msgTran.ReadId;
                _recall.SetUartBaudRate(msgTran);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.SetUartBaudRate, code, nameof(ProcessSetUartBaudRate), $"设置波特率失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 取得读写器版本号
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessGetFirmwareVersion(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length == 2)
            {
                //_config.Major = msgTran.AryData[0];
                //_config.Minor = msgTran.AryData[1];
                //_config.ReadId = msgTran.ReadId;
                //_config.FirmwareVersion = $"{_config.Major}.{_config.Minor}";
                _recall.GetFirmwareVersion(msgTran, msgTran.AryData[0], msgTran.AryData[1]);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.GetFirmwareVersion, code, nameof(ProcessGetFirmwareVersion), $"取得读写器版本号失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 设置读写器地址
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessSetReaderAddress(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length == 1 && msgTran.AryData[0] == 0x10)
            {
                //_config.ReadId = msgTran.ReadId;
                _recall.SetReaderAddress(msgTran);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.SetReaderAddress, code, nameof(ProcessSetReaderAddress), $"设置读写器地址失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 设置工作天线
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessSetWorkAntenna(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length == 1 && msgTran.AryData[0] == 0x10)
            {
                //_config.ReadId = msgTran.ReadId;
                _recall.SetWorkAntenna(msgTran);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.SetWorkAntenna, code, nameof(ProcessSetWorkAntenna), $"设置工作天线失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 取得工作天线
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessGetWorkAntenna(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                if (msgTran.AryData[0] == 0x00 || msgTran.AryData[0] == 0x01 || msgTran.AryData[0] == 0x02 || msgTran.AryData[0] == 0x03)
                {
                    //_config.ReadId = msgTran.ReadId;
                    //_config.WorkAntenna = msgTran.AryData[0];
                    _recall.GetWorkAntenna(msgTran, (ReadAntennaType)msgTran.AryData[0]);
                    return;
                }
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.GetWorkAntenna, code, nameof(ProcessGetWorkAntenna), $"取得工作天线失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 设置输出功率
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessSetOutputPower(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length == 1 && msgTran.AryData[0] == 0x10)
            {
                //_config.ReadId = msgTran.ReadId;
                _recall.SetOutputPower(msgTran);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.SetOutputPower, code, nameof(ProcessSetOutputPower), $"设置输出功率失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 取得输出功率
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessGetOutputPower(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                //_config.ReadId = msgTran.ReadId;
                //_config.OutputPower = msgTran.AryData[0];
                _recall.GetOutputPower(msgTran, msgTran.AryData[0]);
                return;
            }
            ProcessError(ReadCmdType.GetOutputPower, 0, nameof(ProcessGetOutputPower), "取得输出功率失败，失败原因：未知错误", msgTran);
        }

        /// <summary>
        /// 设置射频规范
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessSetFrequencyRegion(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length == 1 && msgTran.AryData[0] == 0x10)
            {
                //_config.ReadId = msgTran.ReadId;
                _recall.SetFrequencyRegion(msgTran);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.SetFrequencyRegion, code, nameof(ProcessSetFrequencyRegion), $"设置射频规范失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 取得射频规范
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessGetFrequencyRegion(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length == 3)
            {
                //_config.ReadId = msgTran.ReadId;
                //_config.FrequencyRegion = msgTran.AryData[0];
                //_config.FrequencyStart = msgTran.AryData[1];
                //_config.FrequencyEnd = msgTran.AryData[2];
                _recall.GetFrequencyRegion(msgTran, (ReadFreqRegionType)msgTran.AryData[0], (int)msgTran.AryData[1], msgTran.AryData[2], 0x00);
                return;
            }
            else if (msgTran.AryData.Length == 6)
            {
                var start = new byte[] { msgTran.AryData[3], msgTran.AryData[4], msgTran.AryData[5] }.ConvertInt32();
                //_config.ReadId = msgTran.ReadId;
                //_config.FrequencyRegion = msgTran.AryData[0];
                //_config.UserDefineFrequencyInterval = msgTran.AryData[1];
                //_config.UserDefineChannelQuantity = msgTran.AryData[2];
                //_config.UserDefineStartFrequency = start;
                _recall.GetFrequencyRegion(msgTran, (ReadFreqRegionType)msgTran.AryData[0], start, msgTran.AryData[1], msgTran.AryData[2]);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.GetFrequencyRegion, code, nameof(ProcessGetFrequencyRegion), $"取得射频规范失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 设置蜂鸣器模式
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessSetBeeperMode(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length == 1 && msgTran.AryData[0] == 0x10)
            {
                //_config.ReadId = msgTran.ReadId;
                _recall.SetBeeperMode(msgTran);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.SetBeeperMode, code, nameof(ProcessSetBeeperMode), $"设置蜂鸣器模式失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 取得读写器温度
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessGetReaderTemperature(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length == 2)
            {
                var temperature = msgTran.AryData[0] == '-' ? -msgTran.AryData[1] : msgTran.AryData[1];
                //_config.ReadId = msgTran.ReadId;
                //_config.PlusMinus = msgTran.AryData[0];
                //_config.Temperature = msgTran.AryData[1];
                //_config.TemperatureText = $"{temperature}℃";
                _recall.GetReaderTemperature(msgTran, temperature);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.GetReaderTemperature, code, nameof(ProcessGetReaderTemperature), $"取得读写器温度失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 设置DRM模式
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessSetDrmMode(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length == 1 && msgTran.AryData[0] == 0x10)
            {
                //_config.ReadId = msgTran.ReadId;
                _recall.SetDrmMode(msgTran);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.SetDrmMode, code, nameof(ProcessSetDrmMode), $"设置DRM模式失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 取得DRM模式
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessGetDrmMode(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length == 1 && (msgTran.AryData[0] == 0x00 || msgTran.AryData[0] == 0x01))
            {
                //_config.ReadId = msgTran.ReadId;
                //_config.DrmMode = msgTran.AryData[0];
                _recall.GetDrmMode(msgTran, msgTran.AryData[0] == 0x00);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.GetDrmMode, code, nameof(ProcessGetDrmMode), $"取得DRM模式失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 测量天线端口阻抗匹配
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessGetImpedanceMatch(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                //_config.ReadId = msgTran.ReadId;
                //_config.AntImpedance = msgTran.AryData[0];
                _recall.GetImpedanceMatch(msgTran, msgTran.AryData[0]);
                return;
            }
            ProcessError(ReadCmdType.GetAntImpedanceMatch, 0, nameof(ProcessGetImpedanceMatch), $"测量天线端口阻抗匹配失败，失败原因：未知错误", msgTran);
        }

        /// <summary>
        /// 盘存标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessInventory(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length == 9)
            {
                var tagCount = Convert.ToInt32(msgTran.AryData[1]) * 256 + Convert.ToInt32(msgTran.AryData[2]);
                var readRate = Convert.ToInt32(msgTran.AryData[3]) * 256 + Convert.ToInt32(msgTran.AryData[4]);
                int totalRead = Convert.ToInt32(msgTran.AryData[5]) * 256 * 256 * 256
                    + Convert.ToInt32(msgTran.AryData[6]) * 256 * 256
                    + Convert.ToInt32(msgTran.AryData[7]) * 256
                    + Convert.ToInt32(msgTran.AryData[8]);
                var duration = readRate > 0 ? totalRead * 1000 / readRate : 0;

                //_config.InvCurrentAnt = msgTran.AryData[0];
                //_config.InvTagCount = tagCount;
                //_config.InvReadRate = readRate;
                //_config.InvDataCount = totalRead;
                //_config.InvTotalReads.Add(totalRead);
                //_config.InvEnd = DateTime.Now;
                //_config.InvDuration = duration;

                _recall.Inventory(msgTran, msgTran.AryData[0], tagCount, readRate, totalRead, duration);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.Inventory, code, nameof(ProcessInventory), $"盘存标签失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 读标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessReadTag(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length > 1)
            {
                //var model = R600TagModel.Read(msgTran.AryData);
                //_config.InvTags[model.Key] = model;
                _recall.ReadTag(msgTran, new R600TagInfo(R600TagInfo.InitType.Read, msgTran.AryData));
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.ReadTag, code, nameof(ProcessReadTag), $"读标签失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 写标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessWriteTag(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length > 1 && msgTran.AryData[msgTran.AryData.Length - 3] == 0x10)
            {
                //var model = R600TagModel.Write(msgTran.AryData);
                //_config.InvTags[model.Key] = model;
                _recall.WriteTag(msgTran, new R600TagInfo(R600TagInfo.InitType.Write, msgTran.AryData));
                return;
            }
            var code = 0;
            string message = msgTran.AryData.Length > 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[msgTran.AryData.Length - 3], out code) : (msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误");
            ProcessError(ReadCmdType.WriteTag, code, nameof(ProcessWriteTag), $"写标签失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 锁定标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessLockTag(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length > 1 && msgTran.AryData[msgTran.AryData.Length - 3] == 0x10)
            {
                //var model = R600TagModel.Lock(msgTran.AryData);
                //_config.InvTags[model.Key] = model;
                _recall.LockTag(msgTran, new R600TagInfo(R600TagInfo.InitType.Lock, msgTran.AryData));
                return;
            }
            int code = 0;
            var message = msgTran.AryData.Length > 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[msgTran.AryData.Length - 3], out code) : (msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误");
            ProcessError(ReadCmdType.LockTag, code, nameof(ProcessLockTag), $"锁定标签失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 销毁标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessKillTag(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length != 1 && msgTran.AryData[msgTran.AryData.Length - 3] == 0x10)
            {
                //var model = R600TagModel.Kill(msgTran.AryData);
                //_config.InvTags[model.Key] = model;
                _recall.KillTag(msgTran, new R600TagInfo(R600TagInfo.InitType.Kill, msgTran.TranData));
                return;
            }
            int code = 0;
            var message = msgTran.AryData.Length > 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[msgTran.AryData.Length - 3], out code) : (msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误");
            ProcessError(ReadCmdType.KillTag, code, nameof(ProcessKillTag), $"销毁标签失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 选定/取消选定标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessSetAccessEpcMatch(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length == 1 && msgTran.AryData[0] == 0x10)
            {
                _recall.SetAccessEpcMatch(msgTran);
                return;
            }
            var code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.SetAccessEpcMatch, code, nameof(ProcessSetAccessEpcMatch), $"选定/取消选定标签失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 取得选定标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessGetAccessEpcMatch(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                byte[] data = null;
                if (msgTran.AryData[0] == 0x01)
                {
                    data = new byte[] { };
                }
                if (msgTran.AryData[0] == 0x00)
                {
                    var len = Convert.ToInt32(msgTran.AryData[1]);
                    data = new byte[len];
                    Array.Copy(msgTran.AryData, 2, data, 0, len);
                }
                if (data != null)
                {
                    //_config.AccessEpcMatch = data;
                    _recall.GetAccessEpcMatch(msgTran, data);
                    return;
                }
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.GetAccessEpcMatch, code, nameof(ProcessGetAccessEpcMatch), $"取得选定标签失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 实时盘存/自定义Session和Inventoried Flag盘存
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessInventoryReal(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length > 1)
            {
                if (msgTran.AryData.Length == 7)
                {
                    var readRate = Convert.ToInt32(msgTran.AryData[1]) * 256 + Convert.ToInt32(msgTran.AryData[2]);
                    var dataCount = Convert.ToInt32(msgTran.AryData[3]) * 256 * 256 * 256 +
                        Convert.ToInt32(msgTran.AryData[4]) * 256 * 256 +
                        Convert.ToInt32(msgTran.AryData[5]) * 256 +
                        Convert.ToInt32(msgTran.AryData[6]);
                    //_config.InvReadRate = readRate;
                    //_config.InvDataCount = dataCount;
                    _recall.InventoryRealEnd(msgTran, readRate, dataCount);
                    return;
                }
                else
                {
                    var model = new R600TagInfo(R600TagInfo.InitType.Real, msgTran.AryData);

                    //_config.SetMaxMinRSSI(Convert.ToInt32(model.RSSI));
                    //_config.InvTotal++;
                    //_config.InvCurrentAnt = model.AntId;
                    //var freq = R600Builder.GetFreq(_config.FrequencyRegion, _config.UserDefineStartFrequency, _config.UserDefineFrequencyInterval, model.FREQ);
                    //var info = _config.InvTags.FirstOrDefault(s => s.Key == model.Key);
                    //var model1 = info.Value;
                    //if (model1.IsDefault())
                    //{
                    //    model1 = new R600TagModel
                    //    {
                    //        Key = model.Key,
                    //        EPC = model.EPC,
                    //        PC = model.PC,
                    //    };
                    //}
                    //model1.RSSI = model.RSSI;
                    //model1.INVCNT += 1;
                    //model1.FREQ = freq;
                    //_config.InvTags[model.Key] = model;
                    //_config.InvEnd = DateTime.Now;

                    _recall.InventoryReal(msgTran, model);
                    return;
                }
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError((ReadCmdType)msgTran.Cmd, code, nameof(ProcessInventoryReal), $"盘存失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 快速4天线盘存
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessFastSwitchInventory(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length > 2)
            {
                if (msgTran.AryData.Length == 7)
                {
                    var dataCount = Convert.ToInt32(msgTran.AryData[0]) * 255 * 255 + Convert.ToInt32(msgTran.AryData[1]) * 255 + Convert.ToInt32(msgTran.AryData[2]);
                    var cmdDuration = Convert.ToInt32(msgTran.AryData[3]) * 255 * 255 * 255 + Convert.ToInt32(msgTran.AryData[4]) * 255 * 255 + Convert.ToInt32(msgTran.AryData[5]) * 255 + Convert.ToInt32(msgTran.AryData[6]);
                    //_config.InvDataCount = dataCount;
                    //_config.InvCommandDuration = cmdDuration;
                    _recall.FastSwitchInventoryEnd(msgTran, dataCount, cmdDuration);
                    return;
                }
                else
                {
                    var model = new R600TagInfo(R600TagInfo.InitType.Fast, msgTran.AryData);

                    //_config.InvTotal++;
                    //_config.SetMaxMinRSSI(Convert.ToInt32(model.RSSI));
                    //_config.InvCurrentAnt = (int)model.AntId;
                    //var freq = R600Builder.GetFreq(_config.FrequencyRegion, _config.UserDefineStartFrequency, _config.UserDefineFrequencyInterval, model.FREQ);
                    //var info = _config.InvTags.FirstOrDefault(s => s.Key == model.Key);
                    //R600TagModel model1 = info.Value;
                    //if (model1.Equals(default(R600TagModel)))
                    //{
                    //    model1 = new R600TagModel
                    //    {
                    //        Key = model.Key,
                    //        PC = model.PC,
                    //        EPC = model.EPC,
                    //        ANT1 = 0,
                    //        ANT2 = 0,
                    //        ANT3 = 0,
                    //        ANT4 = 0,
                    //    };
                    //}
                    //model1.INVCNT += 1;
                    //model1.RSSI = model.RSSI;
                    //model1.FREQ = freq;
                    //switch (model.AntId)
                    //{
                    //    case 0x01:
                    //        model1.ANT1 += 1;
                    //        break;
                    //    case 0x02:
                    //        model1.ANT2 += 1;
                    //        break;
                    //    case 0x03:
                    //        model1.ANT3 += 1;
                    //        break;
                    //    case 0x04:
                    //        model1.ANT4 += 1;
                    //        break;
                    //    default:
                    //        break;
                    //}
                    //_config.InvEnd = DateTime.Now;
                    //_config.InvTags[model.Key] = model1;

                    _recall.FastSwitchInventory(msgTran, model);
                    return;
                }
            }
            var code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : (msgTran.AryData.Length == 2 ? $"{ReaderCaller.FormatErrorCode(msgTran.AryData[1], out code)}--天线{(msgTran.AryData[0] + 1)}" : "未知错误");
            ProcessError(ReadCmdType.FastSwitchInventory, code, nameof(ProcessFastSwitchInventory), $"快速4天线盘存失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 设置Impinj Monza快速读TID功能
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessSetMonzaStatus(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length == 1 && msgTran.AryData[0] == 0x10)
            {
                //_config.ReadId = msgTran.ReadId;
                //_config.AntDetector = msgTran.AryData[0];
                _recall.SetMonzaStatus(msgTran, msgTran.AryData[0]);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.SetMonzaStatus, code, nameof(ProcessSetMonzaStatus), $"设置快速读TID功能失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 读取Impinj Monza快速读TID功能
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessGetMonzaStatus(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length == 1 && (msgTran.AryData[0] == 0x00 || msgTran.AryData[0] == 0x8D))
            {
                //_config.ReadId = msgTran.ReadId;
                //_config.AntDetector = msgTran.AryData[0];
                _recall.GetMonzaStatus(msgTran, msgTran.AryData[0]);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.GetMonzaStatus, code, nameof(ProcessGetMonzaStatus), $"读取快速读TID功能失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessGetInventoryBuffer(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length > 1)
            {
                //var model = R600TagModel.Buffer(msgTran.AryData);
                //_config.SetMaxMinRSSI(Convert.ToInt32(model.RSSI));
                //_config.InvTags[model.Key] = model;
                _recall.GetInventoryBuffer(msgTran, new R600TagInfo(R600TagInfo.InitType.Buffer, msgTran.AryData));
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.GetInventoryBuffer, code, nameof(ProcessGetInventoryBuffer), $"读取缓存失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 读取清空缓存
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessGetAndResetInventoryBuffer(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length > 1)
            {
                //var model = R600TagModel.Buffer(msgTran.AryData);
                //_config.SetMaxMinRSSI(Convert.ToInt32(model.RSSI));
                //_config.InvTags[model.Key] = model;
                _recall.GetAndResetInventoryBuffer(msgTran, new R600TagInfo(R600TagInfo.InitType.Buffer, msgTran.AryData));
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.GetAndResetInventoryBuffer, code, nameof(ProcessGetAndResetInventoryBuffer), $"读取清空缓存失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 读取缓存标签数量
        /// </summary>
        /// <param name="msgTran"></param>
        private void ProcessGetInventoryBufferTagCount(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length == 2)
            {
                //_config.InvTagCount = Convert.ToInt32(msgTran.AryData[0]) * 256 + Convert.ToInt32(msgTran.AryData[1]);
                _recall.GetInventoryBufferTagCount(msgTran, msgTran.AryData.ConvertInt32());
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.GetInventoryBufferTagCount, code, nameof(ProcessGetInventoryBufferTagCount), $"读取缓存标签数量失败，失败原因：{message}", msgTran);
        }
        /// <summary>
        /// 清空缓存
        /// </summary>
        /// <param name="msgTran"></param>
        private void ProcessResetInventoryBuffer(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length == 1 && msgTran.AryData[0] == 0x10)
            {
                _recall.ResetInventoryBuffer(msgTran);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.ResetInventoryBuffer, code, nameof(ProcessResetInventoryBuffer), $"清空缓存失败，失败原因：{message}", msgTran);
        }

        private void ProcessSetBufferDataFrameInterval(IReadMessage msgTran)
        {

        }

        private void ProcessGetBufferDataFrameInterval(IReadMessage msgTran)
        {

        }
        /// <summary>
        /// 盘存标签
        /// </summary>
        /// <param name="msgTran"></param>
        private void ProcessInventoryISO18000(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length == 9)
            {
                var model = new R600TagInfoIso18000(msgTran.AryData);

                ////增加保存标签列表，原未盘存则增加记录，否则将标签盘存数量加1
                //var info = _config.IsoTags.FirstOrDefault(s => s.Key == model.Key);
                //var model1 = info.Value;
                //if (model1.Equals(default(R600TagModel)))
                //{
                //    model1 = new R600TagModel
                //    {
                //        Key = model.Key,
                //        IsoAntId = model.AntId,
                //        IsoUID = model.UID,
                //    };
                //}
                //model1.IsoTotal += 1;
                //_config.IsoTags[model.Key] = model1;

                _recall.InventoryISO18000(msgTran, model);
                return;
            }
            else if (msgTran.AryData.Length == 2)
            {
                var tagCnt = Convert.ToInt32(msgTran.AryData[1]);
                //_config.IsoTagCnt = tagCnt;
                _recall.InventoryISO18000End(msgTran, tagCnt);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.InventoryISO18000, code, nameof(ProcessInventoryISO18000), $"盘存标签失败，失败原因：{message}", msgTran);
        }
        /// <summary>
        /// 读取标签
        /// </summary>
        /// <param name="msgTran"></param>
        private void ProcessReadTagISO18000(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length > 1)
            {
                var antId = msgTran.AryData[0];
                var data = new byte[msgTran.AryData.Length - 1];
                Array.Copy(msgTran.AryData, 1, data, 0, msgTran.AryData.Length - 1); // string strData = R600Method.ByteArrayToString(msgTran.AryData, 1, msgTran.AryData.Length - 1);

                // _config.IsoAntId = antId
                //_config.IsoReadData = data;
                _recall.ReadTagISO18000(msgTran, antId, data);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.ReadTagISO18000, code, nameof(ProcessReadTagISO18000), $"读取标签失败，失败原因：{message}", msgTran);
        }
        /// <summary>
        /// 写入标签
        /// </summary>
        /// <param name="msgTran"></param>
        private void ProcessWriteTagISO18000(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length > 1)
            {
                //_config.IsoAntId = msgTran.AryData[0];
                //_config.IsoWriteLength = msgTran.AryData[1];
                _recall.WriteTagISO18000(msgTran, msgTran.AryData[0], msgTran.AryData[1]);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.WriteTagISO18000, code, nameof(ProcessWriteTagISO18000), $"写入标签失败，失败原因：{message}", msgTran);
        }
        /// <summary>
        /// 永久写保护
        /// </summary>
        /// <param name="msgTran"></param>
        private void ProcessLockTagISO18000(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length > 1)
            {
                var antId = msgTran.AryData[0];
                var status = msgTran.AryData[1];
                //_config.IsoAntId = msgTran.AryData[0];
                //_config.IsoStatus = msgTran.AryData[1];
                _recall.LockTagISO18000(msgTran, antId, (ReadLockTagStatus)status);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(ReadCmdType.LockTagISO18000, code, nameof(ProcessLockTagISO18000), $"永久写保护失败，失败原因：{message}", msgTran);
        }
        /// <summary>
        /// 查询标签
        /// </summary>
        /// <param name="msgTran"></param>
        private void ProcessQueryTagISO18000(IReadMessage msgTran)
        {
            if (msgTran.AryData.Length > 1)
            {
                var antId = msgTran.AryData[0];
                var status = msgTran.AryData[1];
                //_config.IsoAntId = msgTran.AryData[0];
                //_config.IsoStatus = msgTran.AryData[1];
                _recall.QueryTagISO18000(msgTran, antId, (ReadLockTagStatus)status);
                return;
            }
            int code = 0;
            var message = msgTran.AryData.Length == 1 ? ReaderCaller.FormatErrorCode(msgTran.AryData[0], out code) : "未知原因";
            ProcessError(ReadCmdType.QueryTagISO18000, code, nameof(ProcessQueryTagISO18000), $"查询标签失败，失败原因：{message}", msgTran);
        }

        private void ProcessError(ReadCmdType cmd, int code, string method, string message, IReadMessage msgTran)
        {
            _recall.AlertError(new ReadAlertError(cmd, code, message, typeof(R600Reader).FullName, method, msgTran));
        }
        #endregion
        /// <summary>
        /// 读GPIO值
        /// </summary>
        /// <returns></returns>
        public virtual int ReadGpioValue(byte btReadId, Action<IReadMessage, byte, byte, bool, bool> ReadGpioValue)
        {
            if (ReadGpioValue != null) { _recall.ReadGpioValue = ReadGpioValue; }
            return SendMessage(btReadId, ReadCmdType.ReadGpioValue);
        }
        /// <summary>
        /// 写GPIO值
        /// </summary>
        /// <returns></returns>
        public virtual int WriteGpioValue(byte btReadId, byte btChooseGpio, byte btGpioValue, Action<IReadMessage> WriteGpioValue)
        {
            if (WriteGpioValue != null) { _recall.WriteGpioValue = WriteGpioValue; }
            return SendMessage(btReadId, ReadCmdType.WriteGpioValue, new byte[2] { btChooseGpio, btGpioValue });
        }
        /// <summary>
        /// 设置
        /// </summary>
        /// <returns></returns>
        public virtual int SetAntDetector(byte btReadId, byte btDetectorStatus, Action<IReadMessage> SetAntDetector)
        {
            if (SetAntDetector != null) { _recall.SetAntDetector = SetAntDetector; }
            return SendMessage(btReadId, ReadCmdType.SetAntDetector, new byte[1] { btDetectorStatus });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int GetAntDetector(byte btReadId, Action<IReadMessage, byte> GetAntDetector)
        {
            if (GetAntDetector != null) { _recall.GetAntDetector = GetAntDetector; }
            return SendMessage(btReadId, ReadCmdType.GetAntDetector);
        }
        /// <summary>
        /// 设置读ID
        /// </summary>
        /// <returns></returns>
        public virtual int SetReaderIdentifier(byte btReadId, byte[] identifier, Action<IReadMessage> SetReaderIdentifier)
        {
            if (SetReaderIdentifier != null) { _recall.SetReaderIdentifier = SetReaderIdentifier; }
            return SendMessage(btReadId, ReadCmdType.SetReaderIdentifier, identifier);
        }
        /// <summary>
        /// 获取读ID
        /// </summary>
        /// <returns></returns>
        public virtual int GetReaderIdentifier(byte btReadId, Action<IReadMessage, byte[]> GetReaderIdentifier)
        {
            if (GetReaderIdentifier != null) { _recall.GetReaderIdentifier = GetReaderIdentifier; }
            return SendMessage(btReadId, ReadCmdType.GetReaderIdentifier);
        }
        /// <summary>
        /// 设置配置
        /// </summary>
        /// <returns></returns>
        public virtual int SetLinkProfile(byte btReadId, byte btProfile, Action<IReadMessage, byte> SetLinkProfile)
        {
            if (SetLinkProfile != null) { _recall.SetLinkProfile = SetLinkProfile; }
            return SendMessage(btReadId, ReadCmdType.SetLinkProfile, new byte[1] { btProfile });
        }
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns></returns>
        public virtual int GetLinkProfile(byte btReadId, Action<IReadMessage, ReadLinkProfileType> GetLinkProfile)
        {
            if (GetLinkProfile != null) { _recall.GetLinkProfile = GetLinkProfile; }
            return SendMessage(btReadId, ReadCmdType.GetLinkProfile);
        }
        /// <summary>
        /// 复位读写器
        /// </summary>
        /// <returns></returns>
        public virtual int Reset(byte btReadId)
        {
            return SendMessage(btReadId, ReadCmdType.Reset);
        }
        /// <summary>
        /// 设置非同步收发传输器波特率
        /// </summary>
        /// <returns></returns>
        public virtual int SetUartBaudRate(byte btReadId, int nIndexBaudrate, Action<IReadMessage> SetUartBaudRate)
        {
            if (SetUartBaudRate != null) { _recall.SetUartBaudRate = SetUartBaudRate; }
            return SendMessage(btReadId, ReadCmdType.SetUartBaudRate, new byte[1] { Convert.ToByte(nIndexBaudrate) });
        }
        /// <summary>
        /// 获取固件版本
        /// </summary>
        /// <returns></returns>
        public virtual int GetFirmwareVersion(byte btReadId, Action<IReadMessage, byte, byte> GetFirmwareVersion)
        {
            if (GetFirmwareVersion != null) { _recall.GetFirmwareVersion = GetFirmwareVersion; }
            return SendMessage(btReadId, ReadCmdType.GetFirmwareVersion);
        }
        /// <summary>
        /// 设置读地址
        /// </summary>
        /// <returns></returns>
        public virtual int SetReaderAddress(byte btReadId, byte btNewReadId, Action<IReadMessage> SetReaderAddress)
        {
            if (SetReaderAddress != null) { _recall.SetReaderAddress = SetReaderAddress; }
            return SendMessage(btReadId, ReadCmdType.SetReaderAddress, new byte[1] { btNewReadId });
        }
        /// <summary>
        /// 设置工作天线
        /// </summary>
        /// <returns></returns>
        public virtual int SetWorkAntenna(byte btReadId, byte btWorkAntenna, Action<IReadMessage> SetWorkAntenna)
        {
            if (SetWorkAntenna != null) { _recall.SetWorkAntenna = SetWorkAntenna; }
            return SendMessage(btReadId, ReadCmdType.SetWorkAntenna, new byte[1] { btWorkAntenna });
        }
        /// <summary>
        /// 获取工作天线
        /// </summary>
        /// <returns></returns>
        public virtual int GetWorkAntenna(byte btReadId, Action<IReadMessage, ReadAntennaType> GetWorkAntenna)
        {
            if (GetWorkAntenna != null) { _recall.GetWorkAntenna = GetWorkAntenna; }
            return SendMessage(btReadId, ReadCmdType.GetWorkAntenna);
        }
        /// <summary>
        /// 设置输出性能
        /// </summary>
        /// <returns></returns>
        public virtual int SetOutputPower(byte btReadId, byte btOutputPower, Action<IReadMessage> SetOutputPower)
        {
            if (SetOutputPower != null) { _recall.SetOutputPower = SetOutputPower; }
            return SendMessage(btReadId, ReadCmdType.SetOutputPower, new byte[1] { btOutputPower });
        }
        /// <summary>
        /// 获取输出性能
        /// </summary>
        /// <returns></returns>
        public virtual int GetOutputPower(byte btReadId, Action<IReadMessage, byte> GetOutputPower)
        {
            if (GetOutputPower != null) { _recall.GetOutputPower = GetOutputPower; }
            return SendMessage(btReadId, ReadCmdType.GetOutputPower);
        }
        /// <summary>
        /// 设置频率区域
        /// </summary>
        /// <returns></returns>
        public virtual int SetFrequencyRegion(byte btReadId, ReadFreqRegionType btRegion, int btStart, byte btInterval, byte btChannelQuantity, Action<IReadMessage> SetFrequencyRegion)
        {
            if (SetFrequencyRegion != null) { _recall.SetFrequencyRegion = SetFrequencyRegion; }
            byte[] btAryData;
            switch (btRegion)
            {
                case ReadFreqRegionType.Custom:
                    btAryData = new byte[6];
                    btAryData[0] = 4;
                    btAryData[1] = btInterval;
                    btAryData[2] = btChannelQuantity;
                    byte[] btAryFreq = BitConverter.GetBytes(btStart);
                    btAryData[3] = btAryFreq[2];
                    btAryData[4] = btAryFreq[1];
                    btAryData[5] = btAryFreq[0];
                    break;
                case ReadFreqRegionType.FCC:
                case ReadFreqRegionType.ETSI:
                case ReadFreqRegionType.CHN:
                default:
                    btAryData = new byte[3] { (byte)btRegion, (byte)btStart, btInterval };
                    break;
            }
            return SendMessage(btReadId, ReadCmdType.SetFrequencyRegion, btAryData);
        }
        /// <summary>
        /// 得到频率区域
        /// </summary>
        /// <returns></returns>
        public virtual int GetFrequencyRegion(byte btReadId, Action<IReadMessage, ReadFreqRegionType, int, byte, byte> GetFrequencyRegion)
        {
            if (GetFrequencyRegion != null) { _recall.GetFrequencyRegion = GetFrequencyRegion; }
            return SendMessage(btReadId, ReadCmdType.GetFrequencyRegion);
        }
        /// <summary>
        /// 设置呼叫模式
        /// </summary>
        /// <returns></returns>
        public virtual int SetBeeperMode(byte btReadId, byte btMode, Action<IReadMessage> SetBeeperMode)
        {
            if (SetBeeperMode != null) { _recall.SetBeeperMode = SetBeeperMode; }
            return SendMessage(btReadId, ReadCmdType.SetBeeperMode, new byte[1] { btMode });
        }
        /// <summary>
        /// 得到工作温度
        /// </summary>
        /// <returns></returns>
        public virtual int GetReaderTemperature(byte btReadId, Action<IReadMessage, int> GetReaderTemperature)
        {
            if (GetReaderTemperature != null) { _recall.GetReaderTemperature = GetReaderTemperature; }
            return SendMessage(btReadId, ReadCmdType.GetReaderTemperature);
        }
        /// <summary>
        /// 设置DRM模式
        /// </summary>
        /// <returns></returns>
        public virtual int SetDrmMode(byte btReadId, byte btDrmMode, Action<IReadMessage> SetDrmMode)
        {
            if (SetDrmMode != null) { _recall.SetDrmMode = SetDrmMode; }
            return SendMessage(btReadId, ReadCmdType.SetDrmMode, new byte[1] { btDrmMode });
        }
        /// <summary>
        /// 获取DRM模式
        /// </summary>
        /// <returns></returns>
        public virtual int GetDrmMode(byte btReadId, Action<IReadMessage, bool> GetDrmMode)
        {
            if (GetDrmMode != null) { _recall.GetDrmMode = GetDrmMode; }
            return SendMessage(btReadId, ReadCmdType.GetDrmMode);
        }
        /// <summary>
        /// 回波损耗测量
        /// </summary>
        /// <returns></returns>
        [Obsolete("替代方案:GetAntImpedanceMatch")]
        public virtual int MeasureReturnLoss(byte btReadId, byte btFrequency, Action<IReadMessage, byte> GetImpedanceMatch)
        {
            if (GetImpedanceMatch != null) { _recall.GetImpedanceMatch = GetImpedanceMatch; }
            return SendMessage(btReadId, ReadCmdType.GetAntImpedanceMatch, new byte[1] { btFrequency });
        }
        /// <summary>
        /// 获得阻抗匹配
        /// </summary>
        /// <returns></returns>
        public virtual int GetImpedanceMatch(byte btReadId, byte btFrequency, Action<IReadMessage, byte> GetImpedanceMatch)
        {
            if (GetImpedanceMatch != null) { _recall.GetImpedanceMatch = GetImpedanceMatch; }
            return SendMessage(btReadId, ReadCmdType.GetAntImpedanceMatch, new byte[1] { btFrequency });
        }
        /// <summary>
        /// 盘存
        /// </summary>
        /// <returns></returns>
        public virtual int Inventory(byte btReadId, byte byRound, Action<IReadMessage, byte, int, int, int, int> Inventory)
        {
            if (Inventory != null) { _recall.Inventory = Inventory; }
            return SendMessage(btReadId, ReadCmdType.Inventory, new byte[1] { byRound });
        }
        /// <summary>
        /// 读标签
        /// </summary>
        /// <returns></returns>
        public virtual int ReadTag(byte btReadId, byte btMemBank, byte btWordAdd, byte btWordCnt, Action<IReadMessage, R600TagInfo> ReadTag)
        {
            if (ReadTag != null) { _recall.ReadTag = ReadTag; }
            return SendMessage(btReadId, ReadCmdType.ReadTag, new byte[3] { btMemBank, btWordAdd, btWordCnt });
        }
        /// <summary>
        /// 写标签
        /// </summary>
        /// <returns></returns>
        public virtual int WriteTag(byte btReadId, byte[] btAryPassWord, byte btMemBank, byte btWordAdd, byte btWordCnt, byte[] btAryData, Action<IReadMessage, R600TagInfo> WriteTag)
        {
            if (WriteTag != null) { _recall.WriteTag = WriteTag; }
            byte[] btAryBuffer = new byte[btAryData.Length + 7];
            btAryPassWord.CopyTo(btAryBuffer, 0);
            btAryBuffer[4] = btMemBank;
            btAryBuffer[5] = btWordAdd;
            btAryBuffer[6] = btWordCnt;
            btAryData.CopyTo(btAryBuffer, 7);
            return SendMessage(btReadId, ReadCmdType.WriteTag, btAryBuffer);
        }
        /// <summary>
        /// 锁定标签
        /// </summary>
        /// <returns></returns>
        public virtual int LockTag(byte btReadId, byte[] btAryPassWord, byte btMembank, byte btLockType, Action<IReadMessage, R600TagInfo> LockTag)
        {
            if (LockTag != null) { _recall.LockTag = LockTag; }
            byte[] btAryData = new byte[6];
            btAryPassWord.CopyTo(btAryData, 0);
            btAryData[4] = btMembank;
            btAryData[5] = btLockType;
            return SendMessage(btReadId, ReadCmdType.LockTag, btAryData);
        }
        /// <summary>
        /// 释放标记
        /// </summary>
        /// <returns></returns>
        public virtual int KillTag(byte btReadId, byte[] btAryPassWord, Action<IReadMessage, R600TagInfo> KillTag)
        {
            if (KillTag != null) { _recall.KillTag = KillTag; }
            byte[] btAryData = new byte[4];
            btAryPassWord.CopyTo(btAryData, 0);
            return SendMessage(btReadId, ReadCmdType.KillTag, btAryData);
        }
        /// <summary>
        /// 设置EPC(len=0为取消)
        /// </summary>
        /// <returns></returns>
        public virtual int SetAccessEpcMatch(byte btReadId, byte btMode, byte btEpcLen, byte[] btAryEpc, Action<IReadMessage> SetAccessEpcMatch)
        {
            if (SetAccessEpcMatch != null) { _recall.SetAccessEpcMatch = SetAccessEpcMatch; }
            if (btEpcLen == 0)
            {
                return SendMessage(btReadId, ReadCmdType.SetAccessEpcMatch, new byte[1] { btMode });
            }
            int nLen = Convert.ToInt32(btEpcLen) + 2;
            byte[] btAryData = new byte[nLen];
            btAryData[0] = btMode;
            btAryData[1] = btEpcLen;
            btAryEpc.CopyTo(btAryData, 2);
            return SendMessage(btReadId, ReadCmdType.SetAccessEpcMatch, btAryData);
        }
        /// <summary>
        /// 获取EPC
        /// </summary>
        /// <returns></returns>
        public virtual int GetAccessEpcMatch(byte btReadId, Action<IReadMessage, byte[]> GetAccessEpcMatch)
        {
            if (GetAccessEpcMatch != null) { _recall.GetAccessEpcMatch = GetAccessEpcMatch; }
            return SendMessage(btReadId, ReadCmdType.GetAccessEpcMatch);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int InventoryReal(byte btReadId, byte byRound, Action<IReadMessage, R600TagInfo> InventoryReal, Action<IReadMessage, int, int> InventoryRealEnd)
        {
            if (InventoryReal != null) { _recall.InventoryReal = InventoryReal; }
            if (InventoryRealEnd != null) { _recall.InventoryRealEnd = InventoryRealEnd; }
            return SendMessage(btReadId, ReadCmdType.InventoryReal, new byte[1] { byRound });
        }
        /// <summary>
        /// 快速存盘
        /// </summary>
        /// <returns></returns>
        public virtual int FastSwitchInventory(byte btReadId, byte[] btAryData, Action<IReadMessage, R600TagInfo> FastSwitchInventory, Action<IReadMessage, int, int> FastSwitchInventoryEnd)
        {
            if (FastSwitchInventory != null) { _recall.FastSwitchInventory = FastSwitchInventory; }
            if (FastSwitchInventoryEnd != null) { _recall.FastSwitchInventoryEnd = FastSwitchInventoryEnd; }
            return SendMessage(btReadId, ReadCmdType.FastSwitchInventory, btAryData);
        }
        /// <summary>
        /// 自定义存盘
        /// </summary>
        /// <returns></returns>
        public virtual int CustomizedInventory(byte btReadId, byte session, byte target, byte byRound)
        {
            return SendMessage(btReadId, ReadCmdType.CustomizedInventory, new byte[3] { session, target, byRound });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int GetMonzaStatus(byte btReadId, Action<IReadMessage, byte> GetMonzaStatus)
        {
            if (GetMonzaStatus != null) { _recall.GetMonzaStatus = GetMonzaStatus; }
            return SendMessage(btReadId, ReadCmdType.GetMonzaStatus);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int SetMonzaStatus(byte btReadId, byte btMonzaStatus, Action<IReadMessage, byte> SetMonzaStatus)
        {
            if (SetMonzaStatus != null) { _recall.SetMonzaStatus = SetMonzaStatus; }
            return SendMessage(btReadId, ReadCmdType.SetMonzaStatus, new byte[1] { btMonzaStatus });
        }
        /// <summary>
        /// 获取存盘
        /// </summary>
        /// <returns></returns>
        public virtual int GetInventoryBuffer(byte btReadId, Action<IReadMessage, R600TagInfo> GetInventoryBuffer)
        {
            if (GetInventoryBuffer != null) { _recall.GetInventoryBuffer = GetInventoryBuffer; }
            return SendMessage(btReadId, ReadCmdType.GetInventoryBuffer);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int GetAndResetInventoryBuffer(byte btReadId, Action<IReadMessage, R600TagInfo> GetAndResetInventoryBuffer)
        {
            if (GetAndResetInventoryBuffer != null) { _recall.GetAndResetInventoryBuffer = GetAndResetInventoryBuffer; }
            return SendMessage(btReadId, ReadCmdType.GetAndResetInventoryBuffer);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int GetInventoryBufferTagCount(byte btReadId, Action<IReadMessage, int> GetInventoryBufferTagCount)
        {
            if (GetInventoryBufferTagCount != null) { _recall.GetInventoryBufferTagCount = GetInventoryBufferTagCount; }
            return SendMessage(btReadId, ReadCmdType.GetInventoryBufferTagCount);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int ResetInventoryBuffer(byte btReadId, Action<IReadMessage> ResetInventoryBuffer)
        {
            if (ResetInventoryBuffer != null) { _recall.ResetInventoryBuffer = ResetInventoryBuffer; }
            return SendMessage(btReadId, ReadCmdType.ResetInventoryBuffer);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btInterval"></param>
        /// <returns></returns>
        public virtual int SetBufferDataFrameInterval(byte btReadId, byte btInterval)
        {
            return SendMessage(btReadId, ReadCmdType.SetBufferDataFrameInterval, new byte[1] { btInterval });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int GetBufferDataFrameInterval(byte btReadId)
        {
            return SendMessage(btReadId, ReadCmdType.GetBufferDataFrameInterval);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int InventoryISO18000(byte btReadId, Action<IReadMessage, R600TagInfoIso18000> InventoryISO18000, Action<IReadMessage, int> InventoryISO18000End)
        {
            if (InventoryISO18000 != null) { _recall.InventoryISO18000 = InventoryISO18000; }
            return SendMessage(btReadId, ReadCmdType.InventoryISO18000);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int ReadTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd, byte btWordCnt, Action<IReadMessage, byte, byte[]> ReadTagISO18000)
        {
            if (ReadTagISO18000 != null) { _recall.ReadTagISO18000 = ReadTagISO18000; }
            int nLen = btAryUID.Length + 2;
            byte[] btAryData = new byte[nLen];
            btAryUID.CopyTo(btAryData, 0);
            btAryData[nLen - 2] = btWordAdd;
            btAryData[nLen - 1] = btWordCnt;
            return SendMessage(btReadId, ReadCmdType.ReadTagISO18000, btAryData);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int WriteTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd, byte btWordCnt, byte[] btAryBuffer, Action<IReadMessage, byte, byte> WriteTagISO18000)
        {
            if (WriteTagISO18000 != null) { _recall.WriteTagISO18000 = WriteTagISO18000; }
            int nLen = btAryUID.Length + 2 + btAryBuffer.Length;
            byte[] btAryData = new byte[nLen];
            btAryUID.CopyTo(btAryData, 0);
            btAryData[btAryUID.Length] = btWordAdd;
            btAryData[btAryUID.Length + 1] = btWordCnt;
            btAryBuffer.CopyTo(btAryData, btAryUID.Length + 2);
            return SendMessage(btReadId, ReadCmdType.WriteTagISO18000, btAryData);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int LockTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd, Action<IReadMessage, byte, ReadLockTagStatus> LockTagISO18000)
        {
            if (LockTagISO18000 != null) { _recall.LockTagISO18000 = LockTagISO18000; }
            int nLen = btAryUID.Length + 1;
            byte[] btAryData = new byte[nLen];
            btAryUID.CopyTo(btAryData, 0);
            btAryData[nLen - 1] = btWordAdd;
            return SendMessage(btReadId, ReadCmdType.LockTagISO18000, btAryData);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual int QueryTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd, Action<IReadMessage, byte, ReadLockTagStatus> QueryTagISO18000)
        {
            if (QueryTagISO18000 != null) { _recall.QueryTagISO18000 = QueryTagISO18000; }
            int nLen = btAryUID.Length + 1;
            byte[] btAryData = new byte[nLen];
            btAryUID.CopyTo(btAryData, 0);
            btAryData[nLen - 1] = btWordAdd;
            return SendMessage(btReadId, ReadCmdType.QueryTagISO18000, btAryData);
        }
        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btCmd"></param>
        /// <param name="btAryData"></param>
        /// <returns></returns>
        public virtual int SendMessage(byte btReadId, ReadCmdType btCmd, byte[] btAryData = null)
        {
            return SendMessage(btReadId, (byte)btCmd, btAryData);
        }
        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btCmd"></param>
        /// <param name="btAryData"></param>
        /// <returns></returns>
        public virtual int SendMessage(byte btReadId, byte btCmd, byte[] btAryData = null)
        {
            byte[] data;
            if (btAryData == null)
            {
                data = new byte[5];
                data[0] = 0xA0;
                data[1] = 0x03;
                data[2] = btReadId;
                data[3] = btCmd;
                data[4] = ReaderCaller.CheckByte(data, 0, 4);
            }
            else
            {
                int nLen = btAryData.Length;
                data = new byte[nLen + 5];
                data[0] = 0xA0;
                data[1] = Convert.ToByte(nLen + 3);
                data[2] = btReadId;
                data[3] = btCmd;
                btAryData.CopyTo(data, 4);
                data[nLen + 4] = ReaderCaller.CheckByte(data, 0, nLen + 4);
            }
            if (_talker.Send(data))
            {
                SendCallback?.Invoke(data);
                return 0;
            }
            return -1;
        }
        /// <summary>
        /// 正在连接
        /// </summary>
        /// <returns></returns>
        public virtual bool IsConnecting()
        {
            return _talker.IsConnected;
        }
        /// <summary>
        /// 关闭
        /// </summary>
        public virtual void Close()
        {
            _talker.Dispose();
        }
        /// <summary>
        /// 释放
        /// 1.断开连接
        /// </summary>
        public virtual void Dispose()
        {
            Close();
        }
        /// <summary>
        /// 注册回调
        /// </summary>
        public virtual void RegistCallback(IR600CallMethod model)
        {
            if (model != null)
            {
                _recall = new R600CallAction(model);
                SendCallback = model.SendCallback;
                ReceiveCallback = model.ReceiveCallback;
            }
        }
        /// <summary>
        /// 注册回调
        /// </summary>
        public virtual void RegistCallback(IR600CallAction model)
        {
            if (model != null)
            {
                _recall = model;
                SendCallback = model.SendCallback;
                ReceiveCallback = model.ReceiveCallback;
            }
        }
    }
}
