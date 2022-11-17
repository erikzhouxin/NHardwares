using System;
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
    /// 消息传送模型
    /// </summary>
    [Obsolete("替代方案:IReadMessage")]
    public class MessageTran : ReadMessage, IReadMessage
    {
        internal MessageTran(byte btReadId, byte btCmd, byte[] btAryData)
        {
            int nLen = btAryData.Length;

            this.PacketType = 0xA0;
            this.DataLen = Convert.ToByte(nLen + 3);
            this.ReadId = btReadId;
            this.Cmd = btCmd;

            this.AryData = new byte[nLen];
            btAryData.CopyTo(this.AryData, 0);

            this.TranData = new byte[nLen + 5];
            this.TranData[0] = this.PacketType;
            this.TranData[1] = this.DataLen;
            this.TranData[2] = this.ReadId;
            this.TranData[3] = this.Cmd;
            this.AryData.CopyTo(this.TranData, 4);

            this.Check = ReaderCaller.CheckByte(this.TranData, 0, nLen + 4);
            this.TranData[nLen + 4] = this.Check;
        }

        internal MessageTran(byte btReadId, byte btCmd)
        {
            this.PacketType = 0xA0;
            this.DataLen = 0x03;
            this.ReadId = btReadId;
            this.Cmd = btCmd;

            this.TranData = new byte[5];
            this.TranData[0] = this.PacketType;
            this.TranData[1] = this.DataLen;
            this.TranData[2] = this.ReadId;
            this.TranData[3] = this.Cmd;

            this.Check = ReaderCaller.CheckByte(this.TranData, 0, 4);
            this.TranData[4] = this.Check;
        }

        internal MessageTran(byte[] btAryTranData)
        {
            int nLen = btAryTranData.Length;
            this.TranData = new byte[nLen];
            btAryTranData.CopyTo(this.TranData, 0);

            byte btCK = ReaderCaller.CheckByte(this.TranData, 0, this.TranData.Length - 1);
            if (btCK != btAryTranData[nLen - 1]) { return; }

            this.PacketType = btAryTranData[0];
            this.DataLen = btAryTranData[1];
            this.ReadId = btAryTranData[2];
            this.Cmd = btAryTranData[3];
            this.Check = btAryTranData[nLen - 1];

            if (nLen > 5)
            {
                this.AryData = new byte[nLen - 5];
                for (int nloop = 0; nloop < nLen - 5; nloop++)
                {
                    this.AryData[nloop] = btAryTranData[4 + nloop];
                }
            }
        }
    }
    /// <summary>
    /// 原始响应模型
    /// </summary>
    [Obsolete("方案:IR600Reader")]
    public interface IR2000Reactor
    {
        /// <summary>
        /// 接收回调
        /// </summary>
        Action<byte[]> ReceiveCallback { get; set; }
        /// <summary>
        /// 发送回调
        /// </summary>
        Action<byte[]> SendCallback { get; set; }
        /// <summary>
        /// 分析回调
        /// </summary>
        Action<MessageTran> AnalyCallback { get; set; }
        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="strPort"></param>
        /// <param name="nBaudrate"></param>
        /// <param name="strException"></param>
        /// <returns></returns>
        int OpenCom(string strPort, int nBaudrate, out string strException);
        /// <summary>
        /// 关闭串口
        /// </summary>
        void CloseCom();
        /// <summary>
        /// 连接网口
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="nPort"></param>
        /// <param name="strException"></param>
        /// <returns></returns>
        int ConnectServer(IPAddress ipAddress, int nPort, out string strException);
        /// <summary>
        /// 退出
        /// </summary>
        void SignOut();
        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="btArySenderData"></param>
        /// <returns></returns>
        int SendMessage(byte[] btArySenderData);
        /// <summary>
        /// 检查值
        /// </summary>
        /// <param name="btAryData"></param>
        /// <returns></returns>
        byte CheckValue(byte[] btAryData);
        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int Reset(byte btReadId);
        /// <summary>
        /// 设置波特率
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="nIndexBaudrate"></param>
        /// <returns></returns>
        int SetUartBaudrate(byte btReadId, int nIndexBaudrate);
        /// <summary>
        /// 取得读写器版本号
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetFirmwareVersion(byte btReadId);
        /// <summary>
        /// 设置读写器地址
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
        /// 设置输出功率
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btOutputPower"></param>
        /// <returns></returns>
        int SetOutputPower(byte btReadId, byte btOutputPower);
        /// <summary>
        /// 获取输出功率
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetOutputPower(byte btReadId);
        /// <summary>
        /// 回波损耗
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btFrequency"></param>
        /// <returns></returns>
        int MeasureReturnLoss(byte btReadId, byte btFrequency);
        /// <summary>
        /// 设置射频规范
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btRegion"></param>
        /// <param name="btStartRegion"></param>
        /// <param name="btEndRegion"></param>
        /// <returns></returns>
        int SetFrequencyRegion(byte btReadId, byte btRegion, byte btStartRegion, byte btEndRegion);
        /// <summary>
        /// 设置射频规范
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="nStartFreq"></param>
        /// <param name="btFreqInterval"></param>
        /// <param name="btChannelQuantity"></param>
        /// <returns></returns>
        int SetUserDefineFrequency(byte btReadId, int nStartFreq, byte btFreqInterval, byte btChannelQuantity);
        /// <summary>
        /// 取得射频规范
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetFrequencyRegion(byte btReadId);
        /// <summary>
        /// 设置蜂鸣器模式
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btMode"></param>
        /// <returns></returns>
        int SetBeeperMode(byte btReadId, byte btMode);
        /// <summary>
        /// 取得读写器温度
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetReaderTemperature(byte btReadId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btFrequency"></param>
        /// <returns></returns>
        int GetAntImpedanceMatch(byte btReadId, byte btFrequency);
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
        /// 读取GPIO状态
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int ReadGpioValue(byte btReadId);
        /// <summary>
        /// 设置GPIO状态
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btChooseGpio"></param>
        /// <param name="btGpioValue"></param>
        /// <returns></returns>
        int WriteGpioValue(byte btReadId, byte btChooseGpio, byte btGpioValue);
        /// <summary>
        /// 设置天线连接检测阈值
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btDetectorStatus"></param>
        /// <returns></returns>
        int SetAntDetector(byte btReadId, byte btDetectorStatus);
        /// <summary>
        /// 获取天线连接检测阈值
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetAntDetector(byte btReadId);
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
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btProfile"></param>
        /// <returns></returns>
        int SetRadioProfile(byte btReadId, byte btProfile);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetRadioProfile(byte btReadId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        int GetReaderIdentifier(byte btReadId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="identifier"></param>
        /// <returns></returns>
        int SetReaderIdentifier(byte btReadId, byte[] identifier);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="byRound"></param>
        /// <returns></returns>
        int Inventory(byte btReadId, byte byRound);
        /// <summary>
        /// 
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
        /// <param name="btMemBank"></param>
        /// <param name="btWordAdd"></param>
        /// <param name="btWordCnt"></param>
        /// <returns></returns>
        int ReadTag(byte btReadId, byte btMemBank, byte btWordAdd, byte btWordCnt);
        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btAryPassWord"></param>
        /// <param name="btMembank"></param>
        /// <param name="btLockType"></param>
        /// <returns></returns>
        int LockTag(byte btReadId, byte[] btAryPassWord, byte btMembank, byte btLockType);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btAryPassWord"></param>
        /// <returns></returns>
        int KillTag(byte btReadId, byte[] btAryPassWord);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btMode"></param>
        /// <param name="btEpcLen"></param>
        /// <param name="btAryEpc"></param>
        /// <returns></returns>
        int SetAccessEpcMatch(byte btReadId, byte btMode, byte btEpcLen, byte[] btAryEpc);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btMode"></param>
        /// <returns></returns>
        int CancelAccessEpcMatch(byte btReadId, byte btMode);
        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btAryData"></param>
        /// <returns></returns>
        int FastSwitchInventory(byte btReadId, byte[] btAryData);
        /// <summary>
        /// 
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
    }
    /// <summary>
    /// 原始响应模型
    /// </summary>
    [Obsolete("替代方案:R600Reader")]
    internal class R2000Reactor : IR2000Reactor
    {
        private ITalkReadModel italker;
        /// <summary>
        /// 接收回调
        /// </summary>
        public Action<byte[]> ReceiveCallback { get; set; }
        /// <summary>
        /// 发送回调
        /// </summary>
        public Action<byte[]> SendCallback { get; set; }
        /// <summary>
        /// 分析回调
        /// </summary>
        public Action<MessageTran> AnalyCallback { get; set; }

        ReadReceiveMessage _bufferMsg = new ReadReceiveMessage();
        internal R2000Reactor()
        {
            this.italker = new TalkReadModel();
        }

        public int OpenCom(string strPort, int nBaudrate, out string strException)
        {
            this.italker.Dispose();
            italker = new SerialTalkReadModel();
            italker.Received = RunReceiveDataCallback;
            if (italker.Connect(strPort, nBaudrate, out strException))
            {
                return 0;
            }
            return -1;
        }

        public void CloseCom()
        {
            this.italker.Disconnect();
        }

        public int ConnectServer(IPAddress ipAddress, int nPort, out string strException)
        {
            this.italker.Dispose();
            this.italker = new TcpTalkReadModel();
            italker.Received = RunReceiveDataCallback;
            if (!italker.Connect(ipAddress, nPort, out strException))
            {
                return -1;
            }
            return 0;
        }

        public void SignOut()
        {
            italker.Disconnect();
        }

        private void RunReceiveDataCallback(byte[] btAryReceiveData)
        {
            ReceiveCallback?.Invoke(btAryReceiveData);
            var res = _bufferMsg.GetOrAdd(btAryReceiveData);
            foreach (var btAryAnaly in res)
            {
                try
                {
                    AnalyCallback?.Invoke(new MessageTran(btAryAnaly));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        public int SendMessage(byte[] btArySenderData)
        {
            if (!italker.IsConnected)
            {
                return -1;
            }
            if (italker.Send(btArySenderData))
            {
                SendCallback?.Invoke(btArySenderData);
                return 0;
            }
            return -1;
        }

        private int SendMessage(byte btReadId, byte btCmd)
        {
            MessageTran msgTran = new MessageTran(btReadId, btCmd);

            return SendMessage(msgTran.TranData);
        }

        private int SendMessage(byte btReadId, byte btCmd, byte[] btAryData)
        {
            MessageTran msgTran = new MessageTran(btReadId, btCmd, btAryData);

            return SendMessage(msgTran.TranData);
        }

        public byte CheckValue(byte[] btAryData)
        {
            return ReaderCaller.CheckByte(btAryData, 0, btAryData.Length);
        }

        public int Reset(byte btReadId)
        {
            byte btCmd = 0x70;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int SetUartBaudrate(byte btReadId, int nIndexBaudrate)
        {
            byte btCmd = 0x71;
            byte[] btAryData = new byte[1];
            btAryData[0] = Convert.ToByte(nIndexBaudrate);

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int GetFirmwareVersion(byte btReadId)
        {
            byte btCmd = 0x72;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int SetReaderAddress(byte btReadId, byte btNewReadId)
        {
            byte btCmd = 0x73;
            byte[] btAryData = new byte[1];
            btAryData[0] = btNewReadId;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int SetWorkAntenna(byte btReadId, byte btWorkAntenna)
        {
            byte btCmd = 0x74;
            byte[] btAryData = new byte[1];
            btAryData[0] = btWorkAntenna;
            int nResult = SendMessage(btReadId, btCmd, btAryData);
            return nResult;
        }

        public int GetWorkAntenna(byte btReadId)
        {
            byte btCmd = 0x75;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int SetOutputPower(byte btReadId, byte btOutputPower)
        {
            byte btCmd = 0x76;
            byte[] btAryData = new byte[1];
            btAryData[0] = btOutputPower;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int GetOutputPower(byte btReadId)
        {
            byte btCmd = 0x77;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int MeasureReturnLoss(byte btReadId, byte btFrequency)
        {
            byte btCmd = 0x7E;
            byte[] btAryData = new byte[1];
            btAryData[0] = btFrequency;
            int nResult = SendMessage(btReadId, btCmd, btAryData);
            return nResult;
        }

        public int SetFrequencyRegion(byte btReadId, byte btRegion, byte btStartRegion, byte btEndRegion)
        {
            byte btCmd = 0x78;
            byte[] btAryData = new byte[3];
            btAryData[0] = btRegion;
            btAryData[1] = btStartRegion;
            btAryData[2] = btEndRegion;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }
        public int SetUserDefineFrequency(byte btReadId, int nStartFreq, byte btFreqInterval, byte btChannelQuantity)
        {
            byte btCmd = 0x78;
            byte[] btAryFreq = new byte[3];
            byte[] btAryData = new byte[6];
            btAryFreq = BitConverter.GetBytes(nStartFreq);

            btAryData[0] = 4;
            btAryData[1] = btFreqInterval;
            btAryData[2] = btChannelQuantity;
            btAryData[3] = btAryFreq[2];
            btAryData[4] = btAryFreq[1];
            btAryData[5] = btAryFreq[0];

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int GetFrequencyRegion(byte btReadId)
        {
            byte btCmd = 0x79;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int SetBeeperMode(byte btReadId, byte btMode)
        {
            byte btCmd = 0x7A;
            byte[] btAryData = new byte[1];
            btAryData[0] = btMode;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int GetReaderTemperature(byte btReadId)
        {
            byte btCmd = 0x7B;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int GetAntImpedanceMatch(byte btReadId, byte btFrequency)
        {
            byte btCmd = 0x7E;
            byte[] btAryData = new byte[1];
            btAryData[0] = btFrequency;
            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int SetDrmMode(byte btReadId, byte btDrmMode)
        {
            byte btCmd = 0x7C;
            byte[] btAryData = new byte[1];
            btAryData[0] = btDrmMode;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int GetDrmMode(byte btReadId)
        {
            byte btCmd = 0x7D;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int ReadGpioValue(byte btReadId)
        {
            byte btCmd = 0x60;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int WriteGpioValue(byte btReadId, byte btChooseGpio, byte btGpioValue)
        {
            byte btCmd = 0x61;
            byte[] btAryData = new byte[2];
            btAryData[0] = btChooseGpio;
            btAryData[1] = btGpioValue;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int SetAntDetector(byte btReadId, byte btDetectorStatus)
        {
            byte btCmd = 0x62;
            byte[] btAryData = new byte[1];
            btAryData[0] = btDetectorStatus;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int GetAntDetector(byte btReadId)
        {
            byte btCmd = 0x63;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int GetMonzaStatus(byte btReadId)
        {
            byte btCmd = 0x8e;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int SetMonzaStatus(byte btReadId, byte btMonzaStatus)
        {
            byte btCmd = 0x8D;
            byte[] btAryData = new byte[1];
            btAryData[0] = btMonzaStatus;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int SetRadioProfile(byte btReadId, byte btProfile)
        {
            byte btCmd = 0x69;
            byte[] btAryData = new byte[1];
            btAryData[0] = btProfile;
            int nResult = SendMessage(btReadId, btCmd, btAryData);
            return nResult;
        }
        public int GetRadioProfile(byte btReadId)
        {
            byte btCmd = 0x6A;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int GetReaderIdentifier(byte btReadId)
        {
            byte btCmd = 0x68;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int SetReaderIdentifier(byte btReadId, byte[] identifier)
        {
            byte btCmd = 0x67;

            int nResult = SendMessage(btReadId, btCmd, identifier);

            return nResult;
        }


        public int Inventory(byte btReadId, byte byRound)
        {
            byte btCmd = 0x80;
            byte[] btAryData = new byte[1];
            btAryData[0] = byRound;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int CustomizedInventory(byte btReadId, byte session, byte target, byte byRound)
        {
            byte btCmd = 0x8B;
            byte[] btAryData = new byte[3];
            btAryData[0] = session;
            btAryData[1] = target;
            btAryData[2] = byRound;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int ReadTag(byte btReadId, byte btMemBank, byte btWordAdd, byte btWordCnt)
        {
            byte btCmd = 0x81;
            byte[] btAryData = new byte[3];
            btAryData[0] = btMemBank;
            btAryData[1] = btWordAdd;
            btAryData[2] = btWordCnt;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int WriteTag(byte btReadId, byte[] btAryPassWord, byte btMemBank, byte btWordAdd, byte btWordCnt, byte[] btAryData)
        {
            byte btCmd = 0x82;
            byte[] btAryBuffer = new byte[btAryData.Length + 7];
            btAryPassWord.CopyTo(btAryBuffer, 0);
            btAryBuffer[4] = btMemBank;
            btAryBuffer[5] = btWordAdd;
            btAryBuffer[6] = btWordCnt;
            btAryData.CopyTo(btAryBuffer, 7);

            int nResult = SendMessage(btReadId, btCmd, btAryBuffer);

            return nResult;
        }

        public int LockTag(byte btReadId, byte[] btAryPassWord, byte btMembank, byte btLockType)
        {
            byte btCmd = 0x83;
            byte[] btAryData = new byte[6];
            btAryPassWord.CopyTo(btAryData, 0);
            btAryData[4] = btMembank;
            btAryData[5] = btLockType;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int KillTag(byte btReadId, byte[] btAryPassWord)
        {
            byte btCmd = 0x84;
            byte[] btAryData = new byte[4];
            btAryPassWord.CopyTo(btAryData, 0);

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int SetAccessEpcMatch(byte btReadId, byte btMode, byte btEpcLen, byte[] btAryEpc)
        {
            byte btCmd = 0x85;
            int nLen = Convert.ToInt32(btEpcLen) + 2;
            byte[] btAryData = new byte[nLen];
            btAryData[0] = btMode;
            btAryData[1] = btEpcLen;
            btAryEpc.CopyTo(btAryData, 2);

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int CancelAccessEpcMatch(byte btReadId, byte btMode)
        {
            byte btCmd = 0x85;
            byte[] btAryData = new byte[1];
            btAryData[0] = btMode;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int GetAccessEpcMatch(byte btReadId)
        {
            byte btCmd = 0x86;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int InventoryReal(byte btReadId, byte byRound)
        {
            byte btCmd = 0x89;
            byte[] btAryData = new byte[1];
            btAryData[0] = byRound;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int FastSwitchInventory(byte btReadId, byte[] btAryData)
        {
            byte btCmd = 0x8A;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int GetInventoryBuffer(byte btReadId)
        {
            byte btCmd = 0x90;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int GetAndResetInventoryBuffer(byte btReadId)
        {
            byte btCmd = 0x91;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int GetInventoryBufferTagCount(byte btReadId)
        {
            byte btCmd = 0x92;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int ResetInventoryBuffer(byte btReadId)
        {
            byte btCmd = 0x93;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int SetBufferDataFrameInterval(byte btReadId, byte btInterval)
        {
            byte btCmd = 0x94;
            byte[] btAryData = new byte[1];
            btAryData[0] = btInterval;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int GetBufferDataFrameInterval(byte btReadId)
        {
            byte btCmd = 0x95;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int InventoryISO18000(byte btReadId)
        {
            byte btCmd = 0xb0;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }

        public int ReadTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd, byte btWordCnt)
        {
            byte btCmd = 0xb1;
            int nLen = btAryUID.Length + 2;
            byte[] btAryData = new byte[nLen];
            btAryUID.CopyTo(btAryData, 0);
            btAryData[nLen - 2] = btWordAdd;
            btAryData[nLen - 1] = btWordCnt;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int WriteTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd, byte btWordCnt, byte[] btAryBuffer)
        {
            byte btCmd = 0xb2;
            int nLen = btAryUID.Length + 2 + btAryBuffer.Length;
            byte[] btAryData = new byte[nLen];
            btAryUID.CopyTo(btAryData, 0);
            btAryData[btAryUID.Length] = btWordAdd;
            btAryData[btAryUID.Length + 1] = btWordCnt;
            btAryBuffer.CopyTo(btAryData, btAryUID.Length + 2);

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int LockTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd)
        {
            byte btCmd = 0xb3;
            int nLen = btAryUID.Length + 1;
            byte[] btAryData = new byte[nLen];
            btAryUID.CopyTo(btAryData, 0);
            btAryData[nLen - 1] = btWordAdd;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }

        public int QueryTagISO18000(byte btReadId, byte[] btAryUID, byte btWordAdd)
        {
            byte btCmd = 0xb4;
            int nLen = btAryUID.Length + 1;
            byte[] btAryData = new byte[nLen];
            btAryUID.CopyTo(btAryData, 0);
            btAryData[nLen - 1] = btWordAdd;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }
    }
}
