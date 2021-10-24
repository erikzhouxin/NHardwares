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
    /// 读写处理类
    /// </summary>
    internal sealed class R600Reader : AR600Reader, IR600Reader, IDisposable
    {
        ///// <summary>
        ///// 配置信息
        ///// </summary>
        //private R600ConfigModel _config;
        /// <summary>
        /// 构造
        /// </summary>
        public R600Reader()
        {
            this._talker = new TalkModel();
            this.AnalysisCallback = AnalyData;
            //_config = new R600ConfigModel();
        }
        /// <summary>
        /// 串口构造
        /// </summary>
        /// <param name="portName"></param>
        /// <param name="baudRate"></param>
        public R600Reader(string portName, int baudRate)
        {
            if (Connect(portName, baudRate, out string exception) == -1)
            {
                throw new Exception(exception);
            }
            this.AnalysisCallback = AnalyData;
        }
        /// <summary>
        /// 网口构造
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="baudRate"></param>
        public R600Reader(IPAddress ip, int baudRate)
        {
            if (Connect(ip, baudRate, out string exception) == -1)
            {
                throw new Exception(exception);
            }
            this.AnalysisCallback = AnalyData;
        }
        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="portName"></param>
        /// <param name="baudRate"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override int Connect(string portName, int baudRate, out string exception)
        {
            _talker?.Dispose();
            _talker = new SerialTalkModel();
            _talker.Received += RunReceiveDataCallback;
            return _talker.Connect(portName, baudRate, out exception) ? 0 : -1;
        }
        /// <summary>
        /// 连接网口
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override int Connect(IPAddress ip, int port, out string exception)
        {
            _talker?.Dispose();
            _talker = new TcpTalkModel();
            _talker.Received += RunReceiveDataCallback;
            return _talker.Connect(ip, port, out exception) ? 0 : -1;
        }
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
        private void AnalyData(IR600Message msgTran)
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
        private void ProcessReadGpioValue(IR600Message msgTran)
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
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.ReadGpioValue, code, nameof(ProcessReadGpioValue), $"读取GPIO状态失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 设置GPIO状态
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessWriteGpioValue(IR600Message msgTran)
        {
            if (msgTran.AryData.Length == 1 && msgTran.AryData[0] == 0x10)
            {
                //_config.ReadId = msgTran.ReadId;
                _recall.WriteGpioValue(msgTran);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.WriteGpioValue, code, nameof(ProcessWriteGpioValue), $"设置GPIO状态失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 设置天线连接检测阈值
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessSetAntDetector(IR600Message msgTran)
        {
            if (msgTran.AryData.Length == 1 && msgTran.AryData[0] == 0x10)
            {
                //_config.ReadId = msgTran.ReadId;
                _recall.SetAntDetector(msgTran);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.SetAntDetector, code, nameof(ProcessSetAntDetector), $"设置天线连接检测阈值失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 读取天线连接检测阈值
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessGetAntDetector(IR600Message msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                //_config.ReadId = msgTran.ReadId;
                //_config.AntDetector = msgTran.AryData[0];
                _recall.GetAntDetector(msgTran, msgTran.AryData[0]);
                return;
            }
            ProcessError(R600CmdType.GetAntDetector, 0, nameof(ProcessGetAntDetector), "失败，失败原因：未知错误", msgTran);
        }

        /// <summary>
        /// 设置读写器识别标记
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessSetReaderIdentifier(IR600Message msgTran)
        {
            if (msgTran.AryData.Length == 1 && msgTran.AryData[0] == 0x10)
            {
                //_config.ReadId = msgTran.ReadId;
                _recall.SetReaderIdentifier(msgTran);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.SetReaderIdentifier, 0, nameof(ProcessSetReaderIdentifier), $"设置读写器识别标记失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 读取读写器识别标记
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessGetReaderIdentifier(IR600Message msgTran)
        {
            if (msgTran.AryData.Length == 12)
            {
                //_config.ReadId = msgTran.ReadId;
                //_config.ReaderIdentifier = msgTran.AryData.GetHexString();
                _recall.GetReaderIdentifier(msgTran, msgTran.AryData);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.GetReaderIdentifier, code, nameof(ProcessGetReaderIdentifier), $"读取读写器识别标记失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 设置射频通讯链路配置
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessSetLinkProfile(IR600Message msgTran)
        {
            if (msgTran.AryData.Length == 1 && msgTran.AryData[0] == 0x10)
            {
                //_config.ReadId = msgTran.ReadId;
                //_config.LinkProfile = msgTran.AryData[0];
                _recall.SetProfile(msgTran, msgTran.AryData[0]);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.SetLinkProfile, code, nameof(ProcessSetLinkProfile), $"设置射频通讯链路配置失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 读取射频通讯链路配置
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessGetLinkProfile(IR600Message msgTran)
        {
            if (msgTran.AryData.Length == 1 && (msgTran.AryData[0] >= 0xd0) && (msgTran.AryData[0] <= 0xd3))
            {
                //_config.ReadId = msgTran.ReadId;
                //_config.LinkProfile = msgTran.AryData[0];
                //_config.R600LinkProfileType = (R600LinkProfileType)_config.LinkProfile;
                _recall.GetProfile(msgTran, (R600LinkProfileType)msgTran.AryData[0]);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.GetLinkProfile, code, nameof(ProcessGetLinkProfile), $"读取射频通讯链路配置失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 复位读写器(可以不需要返回)
        /// </summary>
        /// <param name="msgTran"></param>
        private void ProcessReset(IR600Message msgTran)
        {

        }

        /// <summary>
        /// 设置波特率
        /// </summary>
        /// <param name="msgTran"></param>
        private void ProcessSetUartBaudRate(IR600Message msgTran)
        {
            if (msgTran.AryData.Length == 1 && msgTran.AryData[0] == 0x10)
            {
                //_config.ReadId = msgTran.ReadId;
                _recall.SetUartBaudRate(msgTran);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.SetUartBaudRate, code, nameof(ProcessSetUartBaudRate), $"设置波特率失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 取得读写器版本号
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessGetFirmwareVersion(IR600Message msgTran)
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
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.GetFirmwareVersion, code, nameof(ProcessGetFirmwareVersion), $"取得读写器版本号失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 设置读写器地址
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessSetReaderAddress(IR600Message msgTran)
        {
            if (msgTran.AryData.Length == 1 && msgTran.AryData[0] == 0x10)
            {
                //_config.ReadId = msgTran.ReadId;
                _recall.SetReaderAddress(msgTran);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.SetReaderAddress, code, nameof(ProcessSetReaderAddress), $"设置读写器地址失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 设置工作天线
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessSetWorkAntenna(IR600Message msgTran)
        {
            if (msgTran.AryData.Length == 1 && msgTran.AryData[0] == 0x10)
            {
                //_config.ReadId = msgTran.ReadId;
                _recall.SetWorkAntenna(msgTran);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.SetWorkAntenna, code, nameof(ProcessSetWorkAntenna), $"设置工作天线失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 取得工作天线
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessGetWorkAntenna(IR600Message msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                if (msgTran.AryData[0] == 0x00 || msgTran.AryData[0] == 0x01 || msgTran.AryData[0] == 0x02 || msgTran.AryData[0] == 0x03)
                {
                    //_config.ReadId = msgTran.ReadId;
                    //_config.WorkAntenna = msgTran.AryData[0];
                    _recall.GetWorkAntenna(msgTran, (R600AntennaType)msgTran.AryData[0]);
                    return;
                }
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.GetWorkAntenna, code, nameof(ProcessGetWorkAntenna), $"取得工作天线失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 设置输出功率
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessSetOutputPower(IR600Message msgTran)
        {
            if (msgTran.AryData.Length == 1 && msgTran.AryData[0] == 0x10)
            {
                //_config.ReadId = msgTran.ReadId;
                _recall.SetOutputPower(msgTran);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.SetOutputPower, code, nameof(ProcessSetOutputPower), $"设置输出功率失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 取得输出功率
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessGetOutputPower(IR600Message msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                //_config.ReadId = msgTran.ReadId;
                //_config.OutputPower = msgTran.AryData[0];
                _recall.GetOutputPower(msgTran, msgTran.AryData[0]);
                return;
            }
            ProcessError(R600CmdType.GetOutputPower, 0, nameof(ProcessGetOutputPower), "取得输出功率失败，失败原因：未知错误", msgTran);
        }

        /// <summary>
        /// 设置射频规范
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessSetFrequencyRegion(IR600Message msgTran)
        {
            if (msgTran.AryData.Length == 1 && msgTran.AryData[0] == 0x10)
            {
                //_config.ReadId = msgTran.ReadId;
                _recall.SetFrequencyRegion(msgTran);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.SetFrequencyRegion, code, nameof(ProcessSetFrequencyRegion), $"设置射频规范失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 取得射频规范
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessGetFrequencyRegion(IR600Message msgTran)
        {
            if (msgTran.AryData.Length == 3)
            {
                //_config.ReadId = msgTran.ReadId;
                //_config.FrequencyRegion = msgTran.AryData[0];
                //_config.FrequencyStart = msgTran.AryData[1];
                //_config.FrequencyEnd = msgTran.AryData[2];
                _recall.GetFrequencyRegion(msgTran, (R600FreqRegionType)msgTran.AryData[0], msgTran.AryData[1], msgTran.AryData[2]);
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
                _recall.GetUserDefineFrequencyRegion(msgTran, (R600FreqRegionType)msgTran.AryData[0], msgTran.AryData[1], msgTran.AryData[2], start);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.GetFrequencyRegion, code, nameof(ProcessGetFrequencyRegion), $"取得射频规范失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 设置蜂鸣器模式
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessSetBeeperMode(IR600Message msgTran)
        {
            if (msgTran.AryData.Length == 1 && msgTran.AryData[0] == 0x10)
            {
                //_config.ReadId = msgTran.ReadId;
                _recall.SetBeeperMode(msgTran);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.SetBeeperMode, code, nameof(ProcessSetBeeperMode), $"设置蜂鸣器模式失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 取得读写器温度
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessGetReaderTemperature(IR600Message msgTran)
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
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.GetReaderTemperature, code, nameof(ProcessGetReaderTemperature), $"取得读写器温度失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 设置DRM模式
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessSetDrmMode(IR600Message msgTran)
        {
            if (msgTran.AryData.Length == 1 && msgTran.AryData[0] == 0x10)
            {
                //_config.ReadId = msgTran.ReadId;
                _recall.SetDrmMode(msgTran);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.SetDrmMode, code, nameof(ProcessSetDrmMode), $"设置DRM模式失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 取得DRM模式
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessGetDrmMode(IR600Message msgTran)
        {
            if (msgTran.AryData.Length == 1 && (msgTran.AryData[0] == 0x00 || msgTran.AryData[0] == 0x01))
            {
                //_config.ReadId = msgTran.ReadId;
                //_config.DrmMode = msgTran.AryData[0];
                _recall.GetDrmMode(msgTran, msgTran.AryData[0] == 0x00);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.GetDrmMode, code, nameof(ProcessGetDrmMode), $"取得DRM模式失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 测量天线端口阻抗匹配
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessGetImpedanceMatch(IR600Message msgTran)
        {
            if (msgTran.AryData.Length == 1)
            {
                //_config.ReadId = msgTran.ReadId;
                //_config.AntImpedance = msgTran.AryData[0];
                _recall.GetImpedanceMatch(msgTran, msgTran.AryData[0]);
                return;
            }
            ProcessError(R600CmdType.GetAntImpedanceMatch, 0, nameof(ProcessGetImpedanceMatch), $"测量天线端口阻抗匹配失败，失败原因：未知错误", msgTran);
        }

        /// <summary>
        /// 盘存标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessInventory(IR600Message msgTran)
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
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.Inventory, code, nameof(ProcessInventory), $"盘存标签失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 读标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessReadTag(IR600Message msgTran)
        {
            if (msgTran.AryData.Length > 1)
            {
                //var model = R600TagModel.Read(msgTran.AryData);
                //_config.InvTags[model.Key] = model;
                _recall.ReadTag(msgTran, new R600TagInfo(R600TagInfo.InitType.Read, msgTran.AryData));
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.ReadTag, code, nameof(ProcessReadTag), $"读标签失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 写标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessWriteTag(IR600Message msgTran)
        {
            if (msgTran.AryData.Length > 1 && msgTran.AryData[msgTran.AryData.Length - 3] == 0x10)
            {
                //var model = R600TagModel.Write(msgTran.AryData);
                //_config.InvTags[model.Key] = model;
                _recall.WriteTag(msgTran, new R600TagInfo(R600TagInfo.InitType.Write, msgTran.AryData));
                return;
            }
            var code = 0;
            string message = msgTran.AryData.Length > 1 ? R600Builder.FormatErrorCode(msgTran.AryData[msgTran.AryData.Length - 3], out code) : (msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误");
            ProcessError(R600CmdType.WriteTag, code, nameof(ProcessWriteTag), $"写标签失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 锁定标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessLockTag(IR600Message msgTran)
        {
            if (msgTran.AryData.Length > 1 && msgTran.AryData[msgTran.AryData.Length - 3] == 0x10)
            {
                //var model = R600TagModel.Lock(msgTran.AryData);
                //_config.InvTags[model.Key] = model;
                _recall.LockTag(msgTran, new R600TagInfo(R600TagInfo.InitType.Lock, msgTran.AryData));
                return;
            }
            int code = 0;
            var message = msgTran.AryData.Length > 1 ? R600Builder.FormatErrorCode(msgTran.AryData[msgTran.AryData.Length - 3], out code) : (msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误");
            ProcessError(R600CmdType.LockTag, code, nameof(ProcessLockTag), $"锁定标签失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 销毁标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessKillTag(IR600Message msgTran)
        {
            if (msgTran.AryData.Length != 1 && msgTran.AryData[msgTran.AryData.Length - 3] == 0x10)
            {
                //var model = R600TagModel.Kill(msgTran.AryData);
                //_config.InvTags[model.Key] = model;
                _recall.KillTag(msgTran, new R600TagInfo(R600TagInfo.InitType.Kill, msgTran.TranData));
                return;
            }
            int code = 0;
            var message = msgTran.AryData.Length > 1 ? R600Builder.FormatErrorCode(msgTran.AryData[msgTran.AryData.Length - 3], out code) : (msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误");
            ProcessError(R600CmdType.KillTag, code, nameof(ProcessKillTag), $"销毁标签失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 选定/取消选定标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessSetAccessEpcMatch(IR600Message msgTran)
        {
            if (msgTran.AryData.Length == 1 && msgTran.AryData[0] == 0x10)
            {
                _recall.SetAccessEpcMatch(msgTran);
                return;
            }
            var code = 0;
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.SetAccessEpcMatch, code, nameof(ProcessSetAccessEpcMatch), $"选定/取消选定标签失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 取得选定标签
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessGetAccessEpcMatch(IR600Message msgTran)
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
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.GetAccessEpcMatch, code, nameof(ProcessGetAccessEpcMatch), $"取得选定标签失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 实时盘存/自定义Session和Inventoried Flag盘存
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessInventoryReal(IR600Message msgTran)
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
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError((R600CmdType)msgTran.Cmd, code, nameof(ProcessInventoryReal), $"盘存失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 快速4天线盘存
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessFastSwitchInventory(IR600Message msgTran)
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
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : (msgTran.AryData.Length == 2 ? $"{R600Builder.FormatErrorCode(msgTran.AryData[1], out code)}--天线{(msgTran.AryData[0] + 1)}" : "未知错误");
            ProcessError(R600CmdType.FastSwitchInventory, code, nameof(ProcessFastSwitchInventory), $"快速4天线盘存失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 设置Impinj Monza快速读TID功能
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessSetMonzaStatus(IR600Message msgTran)
        {
            if (msgTran.AryData.Length == 1 && msgTran.AryData[0] == 0x10)
            {
                //_config.ReadId = msgTran.ReadId;
                //_config.AntDetector = msgTran.AryData[0];
                _recall.SetMonzaStatus(msgTran, msgTran.AryData[0]);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.SetMonzaStatus, code, nameof(ProcessSetMonzaStatus), $"设置快速读TID功能失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 读取Impinj Monza快速读TID功能
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessGetMonzaStatus(IR600Message msgTran)
        {
            if (msgTran.AryData.Length == 1 && (msgTran.AryData[0] == 0x00 || msgTran.AryData[0] == 0x8D))
            {
                //_config.ReadId = msgTran.ReadId;
                //_config.AntDetector = msgTran.AryData[0];
                _recall.GetMonzaStatus(msgTran, msgTran.AryData[0]);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.GetMonzaStatus, code, nameof(ProcessGetMonzaStatus), $"读取快速读TID功能失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessGetInventoryBuffer(IR600Message msgTran)
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
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.GetInventoryBuffer, code, nameof(ProcessGetInventoryBuffer), $"读取缓存失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 读取清空缓存
        /// </summary>
        /// <param name="msgTran"></param>
        /// <returns></returns>
        private void ProcessGetAndResetInventoryBuffer(IR600Message msgTran)
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
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.GetAndResetInventoryBuffer, code, nameof(ProcessGetAndResetInventoryBuffer), $"读取清空缓存失败，失败原因：{message}", msgTran);
        }

        /// <summary>
        /// 读取缓存标签数量
        /// </summary>
        /// <param name="msgTran"></param>
        private void ProcessGetInventoryBufferTagCount(IR600Message msgTran)
        {
            if (msgTran.AryData.Length == 2)
            {
                //_config.InvTagCount = Convert.ToInt32(msgTran.AryData[0]) * 256 + Convert.ToInt32(msgTran.AryData[1]);
                _recall.GetInventoryBufferTagCount(msgTran, msgTran.AryData.ConvertInt32());
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.GetInventoryBufferTagCount, code, nameof(ProcessGetInventoryBufferTagCount), $"读取缓存标签数量失败，失败原因：{message}", msgTran);
        }
        /// <summary>
        /// 清空缓存
        /// </summary>
        /// <param name="msgTran"></param>
        private void ProcessResetInventoryBuffer(IR600Message msgTran)
        {
            if (msgTran.AryData.Length == 1 && msgTran.AryData[0] == 0x10)
            {
                _recall.ResetInventoryBuffer(msgTran);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.ResetInventoryBuffer, code, nameof(ProcessResetInventoryBuffer), $"清空缓存失败，失败原因：{message}", msgTran);
        }

        private void ProcessSetBufferDataFrameInterval(IR600Message msgTran)
        {

        }

        private void ProcessGetBufferDataFrameInterval(IR600Message msgTran)
        {

        }
        /// <summary>
        /// 盘存标签
        /// </summary>
        /// <param name="msgTran"></param>
        private void ProcessInventoryISO18000(IR600Message msgTran)
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
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.InventoryISO18000, code, nameof(ProcessInventoryISO18000), $"盘存标签失败，失败原因：{message}", msgTran);
        }
        /// <summary>
        /// 读取标签
        /// </summary>
        /// <param name="msgTran"></param>
        private void ProcessReadTagISO18000(IR600Message msgTran)
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
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.ReadTagISO18000, code, nameof(ProcessReadTagISO18000), $"读取标签失败，失败原因：{message}", msgTran);
        }
        /// <summary>
        /// 写入标签
        /// </summary>
        /// <param name="msgTran"></param>
        private void ProcessWriteTagISO18000(IR600Message msgTran)
        {
            if (msgTran.AryData.Length > 1)
            {
                //_config.IsoAntId = msgTran.AryData[0];
                //_config.IsoWriteLength = msgTran.AryData[1];
                _recall.WriteTagISO18000(msgTran, msgTran.AryData[0], msgTran.AryData[1]);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.WriteTagISO18000, code, nameof(ProcessWriteTagISO18000), $"写入标签失败，失败原因：{message}", msgTran);
        }
        /// <summary>
        /// 永久写保护
        /// </summary>
        /// <param name="msgTran"></param>
        private void ProcessLockTagISO18000(IR600Message msgTran)
        {
            if (msgTran.AryData.Length > 1)
            {
                var antId = msgTran.AryData[0];
                var status = msgTran.AryData[1];
                //_config.IsoAntId = msgTran.AryData[0];
                //_config.IsoStatus = msgTran.AryData[1];
                _recall.LockTagISO18000(msgTran, antId, (R600LockTagStatus)status);
                return;
            }
            int code = 0;
            string message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知错误";
            ProcessError(R600CmdType.LockTagISO18000, code, nameof(ProcessLockTagISO18000), $"永久写保护失败，失败原因：{message}", msgTran);
        }
        /// <summary>
        /// 查询标签
        /// </summary>
        /// <param name="msgTran"></param>
        private void ProcessQueryTagISO18000(IR600Message msgTran)
        {
            if (msgTran.AryData.Length > 1)
            {
                var antId = msgTran.AryData[0];
                var status = msgTran.AryData[1];
                //_config.IsoAntId = msgTran.AryData[0];
                //_config.IsoStatus = msgTran.AryData[1];
                _recall.QueryTagISO18000(msgTran, antId, (R600LockTagStatus)status);
                return;
            }
            int code = 0;
            var message = msgTran.AryData.Length == 1 ? R600Builder.FormatErrorCode(msgTran.AryData[0], out code) : "未知原因";
            ProcessError(R600CmdType.QueryTagISO18000, code, nameof(ProcessQueryTagISO18000), $"查询标签失败，失败原因：{message}", msgTran);
        }

        private void ProcessError(R600CmdType cmd, int code, string method, string message, IR600Message msgTran)
        {
            _recall.AlertError(new R600AlertError(cmd, code, message, typeof(R600Reader).FullName, method, msgTran));
        }
    }
}
