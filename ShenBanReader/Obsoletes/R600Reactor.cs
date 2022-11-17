using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// 聚集接口
    /// </summary>
    public interface IR600Reactor : IR600Reader, IR600Queue { }
    /// <summary>
    /// 聚集实现类
    /// </summary>
    internal sealed class R600Reactor : AR600Reader, IR600Reactor, IR600Reader, IR600Queue
    {
        private ReadReceiveMessage _bufferMsg = new ReadReceiveMessage();
        #region // 构造及连接
        ///// <summary>
        ///// 配置信息
        ///// </summary>
        //private R600ConfigModel _config;
        /// <summary>
        /// 构造
        /// </summary>
        public R600Reactor()
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
            _talker.Received = RunReceiveDataCallback;
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
            _talker.Received = RunReceiveDataCallback;
            return _talker.Connect(ip, port, out exception);
        }
        #endregion
        #region // 接收及分析
        private void RunReceiveDataCallback(byte[] btAryReceiveData)
        {
            ReceiveCallback?.Invoke(btAryReceiveData);
            var res = _bufferMsg.GetOrAdd(btAryReceiveData);
            foreach (var btAryAnaly in res)
            {
                try
                {
                    AnalysisCallback?.Invoke(new R600Message(btAryAnaly));
                }
                catch (Exception ex)
                {
                    _recall.AlertCallbackError?.Invoke(ex);
                }
            }
            //ReaderCaller.RunReceiveDataCallback(_bufferMsg, btAryReceiveData, ReceiveCallback, AnalysisCallback, _recall.AlertCallbackError);
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
        #region // Queue实现
        /// <summary>
        /// 读GPIO值
        /// </summary>
        /// <returns></returns>
        public int ReadGpioValue(byte btReadId, Action<IReadMessage, byte, byte, bool, bool> ReadGpioValue)
        {
            if (ReadGpioValue != null) { _recall.ReadGpioValue = ReadGpioValue; }
            return SendMessage(btReadId, ReadCmdType.ReadGpioValue);
        }
        /// <summary>
        /// 写GPIO值
        /// </summary>
        /// <returns></returns>
        public int WriteGpioValue(byte btReadId, byte btChooseGpio, byte btGpioValue, Action<IReadMessage> WriteGpioValue)
        {
            if (WriteGpioValue != null) { _recall.WriteGpioValue = WriteGpioValue; }
            return SendMessage(btReadId, ReadCmdType.WriteGpioValue, new byte[2] { btChooseGpio, btGpioValue });
        }
        /// <summary>
        /// 设置
        /// </summary>
        /// <returns></returns>
        public int SetAntDetector(byte btReadId, byte btDetectorStatus, Action<IReadMessage> SetAntDetector)
        {
            if (SetAntDetector != null) { _recall.SetAntDetector = SetAntDetector; }
            return SendMessage(btReadId, ReadCmdType.SetAntDetector, new byte[1] { btDetectorStatus });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetAntDetector(byte btReadId, Action<IReadMessage, byte> GetAntDetector)
        {
            if (GetAntDetector != null) { _recall.GetAntDetector = GetAntDetector; }
            return SendMessage(btReadId, ReadCmdType.GetAntDetector);
        }
        /// <summary>
        /// 设置读ID
        /// </summary>
        /// <returns></returns>
        public int SetReaderIdentifier(byte btReadId, byte[] identifier, Action<IReadMessage> SetReaderIdentifier)
        {
            if (SetReaderIdentifier != null) { _recall.SetReaderIdentifier = SetReaderIdentifier; }
            return SendMessage(btReadId, ReadCmdType.SetReaderIdentifier, identifier);
        }
        /// <summary>
        /// 获取读ID
        /// </summary>
        /// <returns></returns>
        public int GetReaderIdentifier(byte btReadId, Action<IReadMessage, byte[]> GetReaderIdentifier)
        {
            if (GetReaderIdentifier != null) { _recall.GetReaderIdentifier = GetReaderIdentifier; }
            return SendMessage(btReadId, ReadCmdType.GetReaderIdentifier);
        }
        /// <summary>
        /// 设置配置
        /// </summary>
        /// <returns></returns>
        public int SetLinkProfile(byte btReadId, byte btProfile, Action<IReadMessage, byte> SetLinkProfile)
        {
            if (SetLinkProfile != null) { _recall.SetLinkProfile = SetLinkProfile; }
            return SendMessage(btReadId, ReadCmdType.SetLinkProfile, new byte[1] { btProfile });
        }
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns></returns>
        public int GetLinkProfile(byte btReadId, Action<IReadMessage, ReadLinkProfileType> GetLinkProfile)
        {
            if (GetLinkProfile != null) { _recall.GetLinkProfile = GetLinkProfile; }
            return SendMessage(btReadId, ReadCmdType.GetLinkProfile);
        }
        /// <summary>
        /// 设置非同步收发传输器波特率
        /// </summary>
        /// <returns></returns>
        public int SetUartBaudRate(byte btReadId, int nIndexBaudrate, Action<IReadMessage> SetUartBaudRate)
        {
            if (SetUartBaudRate != null) { _recall.SetUartBaudRate = SetUartBaudRate; }
            return SendMessage(btReadId, ReadCmdType.SetUartBaudRate, new byte[1] { Convert.ToByte(nIndexBaudrate) });
        }
        /// <summary>
        /// 获取固件版本
        /// </summary>
        /// <returns></returns>
        public int GetFirmwareVersion(byte btReadId, Action<IReadMessage, byte, byte> GetFirmwareVersion)
        {
            if (GetFirmwareVersion != null) { _recall.GetFirmwareVersion = GetFirmwareVersion; }
            return SendMessage(btReadId, ReadCmdType.GetFirmwareVersion);
        }
        /// <summary>
        /// 设置读地址
        /// </summary>
        /// <returns></returns>
        public int SetReaderAddress(byte btReadId, byte btNewReadId, Action<IReadMessage> SetReaderAddress)
        {
            if (SetReaderAddress != null) { _recall.SetReaderAddress = SetReaderAddress; }
            return SendMessage(btReadId, ReadCmdType.SetReaderAddress, new byte[1] { btNewReadId });
        }
        /// <summary>
        /// 设置工作天线
        /// </summary>
        /// <returns></returns>
        public int SetWorkAntenna(byte btReadId, byte btWorkAntenna, Action<IReadMessage> SetWorkAntenna)
        {
            if (SetWorkAntenna != null) { _recall.SetWorkAntenna = SetWorkAntenna; }
            return SendMessage(btReadId, ReadCmdType.SetWorkAntenna, new byte[1] { btWorkAntenna });
        }
        /// <summary>
        /// 获取工作天线
        /// </summary>
        /// <returns></returns>
        public int GetWorkAntenna(byte btReadId, Action<IReadMessage, ReadAntennaType> GetWorkAntenna)
        {
            if (GetWorkAntenna != null) { _recall.GetWorkAntenna = GetWorkAntenna; }
            return SendMessage(btReadId, ReadCmdType.GetWorkAntenna);
        }
        /// <summary>
        /// 设置输出性能
        /// </summary>
        /// <returns></returns>
        public int SetOutputPower(byte btReadId, byte btOutputPower, Action<IReadMessage> SetOutputPower)
        {
            if (SetOutputPower != null) { _recall.SetOutputPower = SetOutputPower; }
            return SendMessage(btReadId, ReadCmdType.SetOutputPower, new byte[1] { btOutputPower });
        }
        /// <summary>
        /// 获取输出性能
        /// </summary>
        /// <returns></returns>
        public int GetOutputPower(byte btReadId, Action<IReadMessage, byte> GetOutputPower)
        {
            if (GetOutputPower != null) { _recall.GetOutputPower = GetOutputPower; }
            return SendMessage(btReadId, ReadCmdType.GetOutputPower);
        }
        /// <summary>
        /// 设置频率区域
        /// </summary>
        /// <returns></returns>
        public int SetFrequencyRegion(byte btReadId, ReadFreqRegionType btRegion, int btStart, byte btInterval, byte btChannelQuantity, Action<IReadMessage> SetFrequencyRegion)
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
        public int GetFrequencyRegion(byte btReadId, Action<IReadMessage, ReadFreqRegionType, int, byte, byte> GetFrequencyRegion)
        {
            if (GetFrequencyRegion != null) { _recall.GetFrequencyRegion = GetFrequencyRegion; }
            return SendMessage(btReadId, ReadCmdType.GetFrequencyRegion);
        }
        /// <summary>
        /// 设置呼叫模式
        /// </summary>
        /// <returns></returns>
        public int SetBeeperMode(byte btReadId, byte btMode, Action<IReadMessage> SetBeeperMode)
        {
            if (SetBeeperMode != null) { _recall.SetBeeperMode = SetBeeperMode; }
            return SendMessage(btReadId, ReadCmdType.SetBeeperMode, new byte[1] { btMode });
        }
        /// <summary>
        /// 得到工作温度
        /// </summary>
        /// <returns></returns>
        public int GetReaderTemperature(byte btReadId, Action<IReadMessage, int> GetReaderTemperature)
        {
            if (GetReaderTemperature != null) { _recall.GetReaderTemperature = GetReaderTemperature; }
            return SendMessage(btReadId, ReadCmdType.GetReaderTemperature);
        }
        /// <summary>
        /// 设置DRM模式
        /// </summary>
        /// <returns></returns>
        public int SetDrmMode(byte btReadId, byte btDrmMode, Action<IReadMessage> SetDrmMode)
        {
            if (SetDrmMode != null) { _recall.SetDrmMode = SetDrmMode; }
            return SendMessage(btReadId, ReadCmdType.SetDrmMode, new byte[1] { btDrmMode });
        }
        /// <summary>
        /// 获取DRM模式
        /// </summary>
        /// <returns></returns>
        public int GetDrmMode(byte btReadId, Action<IReadMessage, bool> GetDrmMode)
        {
            if (GetDrmMode != null) { _recall.GetDrmMode = GetDrmMode; }
            return SendMessage(btReadId, ReadCmdType.GetDrmMode);
        }
        /// <summary>
        /// 回波损耗测量
        /// </summary>
        /// <returns></returns>
        [Obsolete("替代方案:GetAntImpedanceMatch")]
        public int MeasureReturnLoss(byte btReadId, byte btFrequency, Action<IReadMessage, byte> GetImpedanceMatch)
        {
            if (GetImpedanceMatch != null) { _recall.GetImpedanceMatch = GetImpedanceMatch; }
            return SendMessage(btReadId, ReadCmdType.GetAntImpedanceMatch, new byte[1] { btFrequency });
        }
        /// <summary>
        /// 获得阻抗匹配
        /// </summary>
        /// <returns></returns>
        public int GetImpedanceMatch(byte btReadId, byte btFrequency, Action<IReadMessage, byte> GetImpedanceMatch)
        {
            if (GetImpedanceMatch != null) { _recall.GetImpedanceMatch = GetImpedanceMatch; }
            return SendMessage(btReadId, ReadCmdType.GetAntImpedanceMatch, new byte[1] { btFrequency });
        }
        /// <summary>
        /// 盘存
        /// </summary>
        /// <returns></returns>
        public int Inventory(byte btReadId, byte byRound, Action<IReadMessage, byte, int, int, int, int> Inventory)
        {
            if (Inventory != null) { _recall.Inventory = Inventory; }
            return SendMessage(btReadId, ReadCmdType.Inventory, new byte[1] { byRound });
        }
        /// <summary>
        /// 读标签
        /// </summary>
        /// <returns></returns>
        public int ReadTag(byte btReadId, byte btMemBank, byte btWordAdd, byte btWordCnt, Action<IReadMessage, R600TagInfo> ReadTag)
        {
            if (ReadTag != null) { _recall.ReadTag = ReadTag; }
            return SendMessage(btReadId, ReadCmdType.ReadTag, new byte[3] { btMemBank, btWordAdd, btWordCnt });
        }
        /// <summary>
        /// 写标签
        /// </summary>
        /// <returns></returns>
        public int WriteTag(byte btReadId, byte[] btAryPassWord, byte btMemBank, byte btWordAdd, byte btWordCnt, byte[] btAryData, Action<IReadMessage, R600TagInfo> WriteTag)
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
        public int LockTag(byte btReadId, byte[] btAryPassWord, byte btMembank, byte btLockType, Action<IReadMessage, R600TagInfo> LockTag)
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
        public int KillTag(byte btReadId, byte[] btAryPassWord, Action<IReadMessage, R600TagInfo> KillTag)
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
        public int SetAccessEpcMatch(byte btReadId, byte btMode, byte btEpcLen, byte[] btAryEpc, Action<IReadMessage> SetAccessEpcMatch)
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
        public int GetAccessEpcMatch(byte btReadId, Action<IReadMessage, byte[]> GetAccessEpcMatch)
        {
            if (GetAccessEpcMatch != null) { _recall.GetAccessEpcMatch = GetAccessEpcMatch; }
            return SendMessage(btReadId, ReadCmdType.GetAccessEpcMatch);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int InventoryReal(byte btReadId, byte byRound, Action<IReadMessage, R600TagInfo> InventoryReal, Action<IReadMessage, int, int> InventoryRealEnd)
        {
            if (InventoryReal != null) { _recall.InventoryReal = InventoryReal; }
            if (InventoryRealEnd != null) { _recall.InventoryRealEnd = InventoryRealEnd; }
            return SendMessage(btReadId, ReadCmdType.InventoryReal, new byte[1] { byRound });
        }
        /// <summary>
        /// 快速存盘
        /// </summary>
        /// <returns></returns>
        public int FastSwitchInventory(byte btReadId, byte[] btAryData, Action<IReadMessage, R600TagInfo> FastSwitchInventory, Action<IReadMessage, int, int> FastSwitchInventoryEnd)
        {
            if (FastSwitchInventory != null) { _recall.FastSwitchInventory = FastSwitchInventory; }
            if (FastSwitchInventoryEnd != null) { _recall.FastSwitchInventoryEnd = FastSwitchInventoryEnd; }
            return SendMessage(btReadId, ReadCmdType.FastSwitchInventory, btAryData);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetMonzaStatus(byte btReadId, Action<IReadMessage, byte> GetMonzaStatus)
        {
            if (GetMonzaStatus != null) { _recall.GetMonzaStatus = GetMonzaStatus; }
            return SendMessage(btReadId, ReadCmdType.GetMonzaStatus);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int SetMonzaStatus(byte btReadId, byte btMonzaStatus, Action<IReadMessage, byte> SetMonzaStatus)
        {
            if (SetMonzaStatus != null) { _recall.SetMonzaStatus = SetMonzaStatus; }
            return SendMessage(btReadId, ReadCmdType.SetMonzaStatus, new byte[1] { btMonzaStatus });
        }
        /// <summary>
        /// 获取存盘
        /// </summary>
        /// <returns></returns>
        public int GetInventoryBuffer(byte btReadId, Action<IReadMessage, R600TagInfo> GetInventoryBuffer)
        {
            if (GetInventoryBuffer != null) { _recall.GetInventoryBuffer = GetInventoryBuffer; }
            return SendMessage(btReadId, ReadCmdType.GetInventoryBuffer);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetAndResetInventoryBuffer(byte btReadId, Action<IReadMessage, R600TagInfo> GetAndResetInventoryBuffer)
        {
            if (GetAndResetInventoryBuffer != null) { _recall.GetAndResetInventoryBuffer = GetAndResetInventoryBuffer; }
            return SendMessage(btReadId, ReadCmdType.GetAndResetInventoryBuffer);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetInventoryBufferTagCount(byte btReadId, Action<IReadMessage, int> GetInventoryBufferTagCount)
        {
            if (GetInventoryBufferTagCount != null) { _recall.GetInventoryBufferTagCount = GetInventoryBufferTagCount; }
            return SendMessage(btReadId, ReadCmdType.GetInventoryBufferTagCount);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ResetInventoryBuffer(byte btReadId, Action<IReadMessage> ResetInventoryBuffer)
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
        public override int SetBufferDataFrameInterval(byte btReadId, byte btInterval)
        {
            return SendMessage(btReadId, ReadCmdType.SetBufferDataFrameInterval, new byte[1] { btInterval });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public override int GetBufferDataFrameInterval(byte btReadId)
        {
            return SendMessage(btReadId, ReadCmdType.GetBufferDataFrameInterval);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int InventoryISO18000(byte btReadId, Action<IReadMessage, R600TagInfoIso18000> InventoryISO18000, Action<IReadMessage, int> InventoryISO18000End)
        {
            if (InventoryISO18000 != null) { _recall.InventoryISO18000 = InventoryISO18000; }
            return SendMessage(btReadId, ReadCmdType.InventoryISO18000);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ReadTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd, byte btWordCnt, Action<IReadMessage, byte, byte[]> ReadTagISO18000)
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
        public int WriteTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd, byte btWordCnt, byte[] btAryBuffer, Action<IReadMessage, byte, byte> WriteTagISO18000)
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
        public int LockTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd, Action<IReadMessage, byte, ReadLockTagStatus> LockTagISO18000)
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
        public int QueryTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd, Action<IReadMessage, byte, ReadLockTagStatus> QueryTagISO18000)
        {
            if (QueryTagISO18000 != null) { _recall.QueryTagISO18000 = QueryTagISO18000; }
            int nLen = btAryUID.Length + 1;
            byte[] btAryData = new byte[nLen];
            btAryUID.CopyTo(btAryData, 0);
            btAryData[nLen - 1] = btWordAdd;
            return SendMessage(btReadId, ReadCmdType.QueryTagISO18000, btAryData);
        }
        #endregion
    }
}
