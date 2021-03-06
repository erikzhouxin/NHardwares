using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// R600读写器接口
    /// </summary>
    public interface IR600Reader : IDisposable
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
        /// 是连接
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
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int ReadGpioValue(byte btReadId);
        /// <summary>
        /// 写GPIO值
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btChooseGpio"></param>
        /// <param name="btGpioValue"></param>
        /// <returns></returns>
        int WriteGpioValue(byte btReadId, byte btChooseGpio, byte btGpioValue);
        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btDetectorStatus"></param>
        /// <returns></returns>
        int SetAntDetector(byte btReadId, byte btDetectorStatus);
        /// <summary>
        /// 读取天线连接检测阈值
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetAntDetector(byte btReadId);
        /// <summary>
        /// 设置读ID
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="identifier"></param>
        /// <returns></returns>
        int SetReaderIdentifier(byte btReadId, byte[] identifier);
        /// <summary>
        /// 获取读ID
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetReaderIdentifier(byte btReadId);
        /// <summary>
        /// 设置配置
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btProfile"></param>
        /// <returns></returns>
        int SetLinkProfile(byte btReadId, byte btProfile);
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetLinkProfile(byte btReadId);
        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int Reset(byte btReadId);
        /// <summary>
        /// 设置非同步收发传输器波特率
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="nIndexBaudrate"></param>
        /// <returns></returns>
        int SetUartBaudRate(byte btReadId, int nIndexBaudrate);
        /// <summary>
        /// 获取固件版本
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetFirmwareVersion(byte btReadId);
        /// <summary>
        /// 设置读地址
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btNewReadId"></param>
        /// <returns></returns>
        int SetReaderAddress(byte btReadId, byte btNewReadId);
        /// <summary>
        /// 设置工作天线
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btWorkAntenna"></param>
        /// <returns></returns>
        int SetWorkAntenna(byte btReadId, byte btWorkAntenna);
        /// <summary>
        /// 获取工作天线
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetWorkAntenna(byte btReadId);
        /// <summary>
        /// 设置输出性能
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btOutputPower"></param>
        /// <returns></returns>
        int SetOutputPower(byte btReadId, byte btOutputPower);
        /// <summary>
        /// 获取输出性能
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetOutputPower(byte btReadId);
        /// <summary>
        /// 设置频率区域
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btRegion"></param>
        /// <param name="btStart"></param>
        /// <param name="btInterval"></param>
        /// <param name="btChannelQuantity"></param>
        /// <returns></returns>
        int SetFrequencyRegion(byte btReadId, ReadFreqRegionType btRegion, int btStart, byte btInterval, byte btChannelQuantity);
        /// <summary>
        /// 得到频率区域
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetFrequencyRegion(byte btReadId);
        /// <summary>
        /// 设置呼叫模式
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btMode"></param>
        /// <returns></returns>
        int SetBeeperMode(byte btReadId, byte btMode);
        /// <summary>
        /// 得到工作温度
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetReaderTemperature(byte btReadId);
        /// <summary>
        /// 设置DRM模式
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btDrmMode"></param>
        /// <returns></returns>
        int SetDrmMode(byte btReadId, byte btDrmMode);
        /// <summary>
        /// 获取DRM模式
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetDrmMode(byte btReadId);
        /// <summary>
        /// 回波损耗测量
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btFrequency"></param>
        /// <returns></returns>
        [Obsolete("替代方案:GetImpedanceMatch")]
        int MeasureReturnLoss(byte btReadId, byte btFrequency);
        /// <summary>
        /// 获得阻抗匹配
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btFrequency"></param>
        /// <returns></returns>
        int GetImpedanceMatch(byte btReadId, byte btFrequency);
        /// <summary>
        /// 盘存
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="byRound"></param>
        /// <returns></returns>
        int Inventory(byte btReadId, byte byRound);
        /// <summary>
        /// 读标签
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btMemBank"></param>
        /// <param name="btWordAdd"></param>
        /// <param name="btWordCnt"></param>
        /// <returns></returns>
        int ReadTag(byte btReadId, byte btMemBank, byte btWordAdd, byte btWordCnt);
        /// <summary>
        /// 写标签
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btAryPassWord"></param>
        /// <param name="btMemBank"></param>
        /// <param name="btWordAdd"></param>
        /// <param name="btWordCnt"></param>
        /// <param name="btAryData"></param>
        /// <returns></returns>
        int WriteTag(byte btReadId, byte[] btAryPassWord, byte btMemBank, byte btWordAdd, byte btWordCnt, byte[] btAryData);
        /// <summary>
        /// 锁定标签
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btAryPassWord"></param>
        /// <param name="btMembank"></param>
        /// <param name="btLockType"></param>
        /// <returns></returns>
        int LockTag(byte btReadId, byte[] btAryPassWord, byte btMembank, byte btLockType);
        /// <summary>
        /// 释放标记
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btAryPassWord"></param>
        /// <returns></returns>
        int KillTag(byte btReadId, byte[] btAryPassWord);
        /// <summary>
        /// 设置EPC(len = 0为1取消)
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btMode"></param>
        /// <param name="btEpcLen"></param>
        /// <param name="btAryEpc"></param>
        /// <returns></returns>
        int SetAccessEpcMatch(byte btReadId, byte btMode, byte btEpcLen, byte[] btAryEpc);
        /// <summary>
        /// 获取EPC
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetAccessEpcMatch(byte btReadId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="byRound"></param>
        /// <returns></returns>
        int InventoryReal(byte btReadId, byte byRound);
        /// <summary>
        /// 快速存盘
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btAryData"></param>
        /// <returns></returns>
        int FastSwitchInventory(byte btReadId, byte[] btAryData);
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
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetMonzaStatus(byte btReadId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btMonzaStatus"></param>
        /// <returns></returns>
        int SetMonzaStatus(byte btReadId, byte btMonzaStatus);
        /// <summary>
        /// 获取存盘
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetInventoryBuffer(byte btReadId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetAndResetInventoryBuffer(byte btReadId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetInventoryBufferTagCount(byte btReadId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int ResetInventoryBuffer(byte btReadId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btInterval"></param>
        /// <returns></returns>
        int SetBufferDataFrameInterval(byte btReadId, byte btInterval);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetBufferDataFrameInterval(byte btReadId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int InventoryISO18000(byte btReadId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btAryUID"></param>
        /// <param name="btWordAdd"></param>
        /// <param name="btWordCnt"></param>
        /// <returns></returns>
        int ReadTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd, byte btWordCnt);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btAryUID"></param>
        /// <param name="btWordAdd"></param>
        /// <param name="btWordCnt"></param>
        /// <param name="btAryBuffer"></param>
        /// <returns></returns>
        int WriteTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd, byte btWordCnt, byte[] btAryBuffer);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btAryUID"></param>
        /// <param name="btWordAdd"></param>
        /// <returns></returns>
        int LockTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btAryUID"></param>
        /// <param name="btWordAdd"></param>
        /// <returns></returns>
        int QueryTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd);
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
    /// 读写处理类
    /// </summary>
    internal sealed class R600Reader : AR600Reader, IR600Reader, IDisposable
    {
        private ReadReceiveMessage _bufferMsg = new ReadReceiveMessage();
        ///// <summary>
        ///// 配置信息
        ///// </summary>
        //private R600ConfigModel _config;
        /// <summary>
        /// 构造
        /// </summary>
        public R600Reader()
        {
            this._talker = new TalkReadModel();
            this.AnalysisCallback = AnalyData;
            //_config = new R600ConfigModel();
        }
        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="portName"></param>
        /// <param name="baudRate"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override bool Connect(string portName, int baudRate, out string exception)
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
        public override bool Connect(IPAddress ip, int port, out string exception)
        {
            _talker?.Dispose();
            _talker = new TcpTalkReadModel();
            _talker.Received += RunReceiveDataCallback;
            return _talker.Connect(ip, port, out exception);
        }
        private void RunReceiveDataCallback(byte[] btAryReceiveData)
        {
            ReaderCaller.RunReceiveDataCallback(_bufferMsg, btAryReceiveData, ReceiveCallback, AnalysisCallback, _recall.AlertCallbackError);
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
                    var dataCount = msgTran.AryData[0] * 255 * 255 + msgTran.AryData[1] * 255 + msgTran.AryData[2];
                    var cmdDuration = msgTran.AryData[3] * 255 * 255 * 255 + msgTran.AryData[4] * 255 * 255 + msgTran.AryData[5] * 255 + msgTran.AryData[6];
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
    }
    /// <summary>
    /// 阅读器
    /// </summary>
    internal abstract class AR600Reader : IR600Reader
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
        protected IR600CallAction _recall = new R600CallAction();
        /// <summary>
        /// 内部链接模型
        /// </summary>
        protected ITalkReadModel _talker;
        /// <summary>
        /// 是连接
        /// </summary>
        public virtual bool IsConnected { get => _talker.IsConnected; }
        public abstract bool Connect(string portName, int baudRate, out string exception);
        public abstract bool Connect(IPAddress ip, int port, out string exception);
        /// <summary>
        /// 检查字节
        /// </summary>
        /// <param name="aryBuffer"></param>
        /// <param name="index"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static byte CheckByte(byte[] aryBuffer, int index, int len)
        {
            byte btSum = 0x00;
            for (int nloop = index; nloop < index + len; nloop++)
            {
                btSum += aryBuffer[nloop];
            }
            return Convert.ToByte(((~btSum) + 1) & 0xFF);
        }
        /// <summary>
        /// 读GPIO值
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int ReadGpioValue(byte btReadId)
        {
            return SendMessage(btReadId, ReadCmdType.ReadGpioValue);
        }
        /// <summary>
        /// 写GPIO值
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btChooseGpio"></param>
        /// <param name="btGpioValue"></param>
        /// <returns></returns>
        public virtual int WriteGpioValue(byte btReadId, byte btChooseGpio, byte btGpioValue)
        {
            return SendMessage(btReadId, ReadCmdType.WriteGpioValue, new byte[2] { btChooseGpio, btGpioValue });
        }
        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btDetectorStatus"></param>
        /// <returns></returns>
        public virtual int SetAntDetector(byte btReadId, byte btDetectorStatus)
        {
            return SendMessage(btReadId, ReadCmdType.SetAntDetector, new byte[1] { btDetectorStatus });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int GetAntDetector(byte btReadId)
        {
            return SendMessage(btReadId, ReadCmdType.GetAntDetector);
        }
        /// <summary>
        /// 设置读ID
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public virtual int SetReaderIdentifier(byte btReadId, byte[] identifier)
        {
            return SendMessage(btReadId, ReadCmdType.SetReaderIdentifier, identifier);
        }
        /// <summary>
        /// 获取读ID
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int GetReaderIdentifier(byte btReadId)
        {
            return SendMessage(btReadId, ReadCmdType.GetReaderIdentifier);
        }
        /// <summary>
        /// 设置配置
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btProfile"></param>
        /// <returns></returns>
        public virtual int SetLinkProfile(byte btReadId, byte btProfile)
        {
            return SendMessage(btReadId, ReadCmdType.SetLinkProfile, new byte[1] { btProfile });
        }
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int GetLinkProfile(byte btReadId)
        {
            return SendMessage(btReadId, ReadCmdType.GetLinkProfile);
        }
        /// <summary>
        /// 复位读写器
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int Reset(byte btReadId)
        {
            return SendMessage(btReadId, ReadCmdType.Reset);
        }
        /// <summary>
        /// 设置非同步收发传输器波特率
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="nIndexBaudrate"></param>
        /// <returns></returns>
        public virtual int SetUartBaudRate(byte btReadId, int nIndexBaudrate)
        {
            return SendMessage(btReadId, ReadCmdType.SetUartBaudRate, new byte[1] { Convert.ToByte(nIndexBaudrate) });
        }
        /// <summary>
        /// 获取固件版本
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int GetFirmwareVersion(byte btReadId)
        {
            return SendMessage(btReadId, ReadCmdType.GetFirmwareVersion);
        }
        /// <summary>
        /// 设置读地址
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btNewReadId"></param>
        /// <returns></returns>
        public virtual int SetReaderAddress(byte btReadId, byte btNewReadId)
        {
            return SendMessage(btReadId, ReadCmdType.SetReaderAddress, new byte[1] { btNewReadId });
        }
        /// <summary>
        /// 设置工作天线
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btWorkAntenna"></param>
        /// <returns></returns>
        public virtual int SetWorkAntenna(byte btReadId, byte btWorkAntenna)
        {
            return SendMessage(btReadId, ReadCmdType.SetWorkAntenna, new byte[1] { btWorkAntenna });
        }
        /// <summary>
        /// 获取工作天线
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int GetWorkAntenna(byte btReadId)
        {
            return SendMessage(btReadId, ReadCmdType.GetWorkAntenna);
        }
        /// <summary>
        /// 设置输出性能
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btOutputPower"></param>
        /// <returns></returns>
        public virtual int SetOutputPower(byte btReadId, byte btOutputPower)
        {
            return SendMessage(btReadId, ReadCmdType.SetOutputPower, new byte[1] { btOutputPower });
        }
        /// <summary>
        /// 获取输出性能
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int GetOutputPower(byte btReadId)
        {
            return SendMessage(btReadId, ReadCmdType.GetOutputPower);
        }
        /// <summary>
        /// 设置频率区域
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btRegion"></param>
        /// <param name="btStart"></param>
        /// <param name="btInterval"></param>
        /// <param name="btChannelQuantity"></param>
        /// <returns></returns>
        public virtual int SetFrequencyRegion(byte btReadId, ReadFreqRegionType btRegion, int btStart, byte btInterval, byte btChannelQuantity)
        {
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
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int GetFrequencyRegion(byte btReadId)
        {
            return SendMessage(btReadId, ReadCmdType.GetFrequencyRegion);
        }
        /// <summary>
        /// 设置呼叫模式
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btMode"></param>
        /// <returns></returns>
        public virtual int SetBeeperMode(byte btReadId, byte btMode)
        {
            return SendMessage(btReadId, ReadCmdType.SetBeeperMode, new byte[1] { btMode });
        }
        /// <summary>
        /// 得到工作温度
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int GetReaderTemperature(byte btReadId)
        {
            return SendMessage(btReadId, ReadCmdType.GetReaderTemperature);
        }
        /// <summary>
        /// 设置DRM模式
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btDrmMode"></param>
        /// <returns></returns>
        public virtual int SetDrmMode(byte btReadId, byte btDrmMode)
        {
            return SendMessage(btReadId, ReadCmdType.SetDrmMode, new byte[1] { btDrmMode });
        }
        /// <summary>
        /// 获取DRM模式
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int GetDrmMode(byte btReadId)
        {
            return SendMessage(btReadId, ReadCmdType.GetDrmMode);
        }
        /// <summary>
        /// 回波损耗测量
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btFrequency"></param>
        /// <returns></returns>
        [Obsolete("替代方案:GetAntImpedanceMatch")]
        public virtual int MeasureReturnLoss(byte btReadId, byte btFrequency)
        {
            return SendMessage(btReadId, ReadCmdType.GetAntImpedanceMatch, new byte[1] { btFrequency });
        }
        /// <summary>
        /// 获得阻抗匹配
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btFrequency"></param>
        /// <returns></returns>
        public virtual int GetImpedanceMatch(byte btReadId, byte btFrequency)
        {
            return SendMessage(btReadId, ReadCmdType.GetAntImpedanceMatch, new byte[1] { btFrequency });
        }
        /// <summary>
        /// 盘存
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="byRound"></param>
        /// <returns></returns>
        public virtual int Inventory(byte btReadId, byte byRound)
        {
            return SendMessage(btReadId, ReadCmdType.Inventory, new byte[1] { byRound });
        }
        /// <summary>
        /// 读标签
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btMemBank"></param>
        /// <param name="btWordAdd"></param>
        /// <param name="btWordCnt"></param>
        /// <returns></returns>
        public virtual int ReadTag(byte btReadId, byte btMemBank, byte btWordAdd, byte btWordCnt)
        {
            return SendMessage(btReadId, ReadCmdType.ReadTag, new byte[3] { btMemBank, btWordAdd, btWordCnt });
        }
        /// <summary>
        /// 写标签
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btAryPassWord"></param>
        /// <param name="btMemBank"></param>
        /// <param name="btWordAdd"></param>
        /// <param name="btWordCnt"></param>
        /// <param name="btAryData"></param>
        /// <returns></returns>
        public virtual int WriteTag(byte btReadId, byte[] btAryPassWord, byte btMemBank, byte btWordAdd, byte btWordCnt, byte[] btAryData)
        {
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
        /// <param name="btReadId"></param>
        /// <param name="btAryPassWord"></param>
        /// <param name="btMembank"></param>
        /// <param name="btLockType"></param>
        /// <returns></returns>
        public virtual int LockTag(byte btReadId, byte[] btAryPassWord, byte btMembank, byte btLockType)
        {
            byte[] btAryData = new byte[6];
            btAryPassWord.CopyTo(btAryData, 0);
            btAryData[4] = btMembank;
            btAryData[5] = btLockType;
            return SendMessage(btReadId, ReadCmdType.LockTag, btAryData);
        }
        /// <summary>
        /// 释放标记
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btAryPassWord"></param>
        /// <returns></returns>
        public virtual int KillTag(byte btReadId, byte[] btAryPassWord)
        {
            byte[] btAryData = new byte[4];
            btAryPassWord.CopyTo(btAryData, 0);
            return SendMessage(btReadId, ReadCmdType.KillTag, btAryData);
        }
        /// <summary>
        /// 设置EPC(btEpcLen=0为取消)
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btMode"></param>
        /// <param name="btEpcLen"></param>
        /// <param name="btAryEpc"></param>
        /// <returns></returns>
        public virtual int SetAccessEpcMatch(byte btReadId, byte btMode, byte btEpcLen, byte[] btAryEpc)
        {
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
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int GetAccessEpcMatch(byte btReadId)
        {
            return SendMessage(btReadId, ReadCmdType.GetAccessEpcMatch);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="byRound"></param>
        /// <returns></returns>
        public virtual int InventoryReal(byte btReadId, byte byRound)
        {
            return SendMessage(btReadId, ReadCmdType.InventoryReal, new byte[1] { byRound });
        }
        /// <summary>
        /// 快速存盘
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btAryData"></param>
        /// <returns></returns>
        public virtual int FastSwitchInventory(byte btReadId, byte[] btAryData)
        {
            return SendMessage(btReadId, ReadCmdType.FastSwitchInventory, btAryData);
        }
        /// <summary>
        /// 自定义存盘
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="session"></param>
        /// <param name="target"></param>
        /// <param name="byRound"></param>
        /// <returns></returns>
        public virtual int CustomizedInventory(byte btReadId, byte session, byte target, byte byRound)
        {
            return SendMessage(btReadId, ReadCmdType.CustomizedInventory, new byte[3] { session, target, byRound });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int GetMonzaStatus(byte btReadId)
        {
            return SendMessage(btReadId, ReadCmdType.GetMonzaStatus);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btMonzaStatus"></param>
        /// <returns></returns>
        public virtual int SetMonzaStatus(byte btReadId, byte btMonzaStatus)
        {
            return SendMessage(btReadId, ReadCmdType.SetMonzaStatus, new byte[1] { btMonzaStatus });
        }
        /// <summary>
        /// 获取存盘
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int GetInventoryBuffer(byte btReadId)
        {
            return SendMessage(btReadId, ReadCmdType.GetInventoryBuffer);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int GetAndResetInventoryBuffer(byte btReadId)
        {
            return SendMessage(btReadId, ReadCmdType.GetAndResetInventoryBuffer);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int GetInventoryBufferTagCount(byte btReadId)
        {
            return SendMessage(btReadId, ReadCmdType.GetInventoryBufferTagCount);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int ResetInventoryBuffer(byte btReadId)
        {
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
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public virtual int InventoryISO18000(byte btReadId)
        {
            return SendMessage(btReadId, ReadCmdType.InventoryISO18000);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btAryUID"></param>
        /// <param name="btWordAdd"></param>
        /// <param name="btWordCnt"></param>
        /// <returns></returns>
        public virtual int ReadTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd, byte btWordCnt)
        {
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
        /// <param name="btReadId"></param>
        /// <param name="btAryUID"></param>
        /// <param name="btWordAdd"></param>
        /// <param name="btWordCnt"></param>
        /// <param name="btAryBuffer"></param>
        /// <returns></returns>
        public virtual int WriteTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd, byte btWordCnt, byte[] btAryBuffer)
        {
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
        /// <param name="btReadId"></param>
        /// <param name="btAryUID"></param>
        /// <param name="btWordAdd"></param>
        /// <returns></returns>
        public virtual int LockTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd)
        {
            int nLen = btAryUID.Length + 1;
            byte[] btAryData = new byte[nLen];
            btAryUID.CopyTo(btAryData, 0);
            btAryData[nLen - 1] = btWordAdd;
            return SendMessage(btReadId, ReadCmdType.LockTagISO18000, btAryData);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btAryUID"></param>
        /// <param name="btWordAdd"></param>
        /// <returns></returns>
        public virtual int QueryTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd)
        {
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
                data[4] = CheckByte(data, 0, 4);
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
                data[nLen + 4] = CheckByte(data, 0, nLen + 4);
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
