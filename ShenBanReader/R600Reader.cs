﻿using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// 读写处理类
    /// </summary>
    public class R600Reader
    {
        private IR600Talker italker;
        private SerialPort iSerialPort;
        private int m_nType = -1;
        /// <summary>
        /// 接收回调
        /// </summary>
        public R600ReciveCallback ReceiveCallback;
        /// <summary>
        /// 发送回调
        /// </summary>
        public R600SendCallback SendCallback;
        /// <summary>
        /// 解析回调
        /// </summary>
        public R600AnalyCallback AnalyCallback;

        //记录未处理的接收数据，主要考虑接收数据分段
        byte[] m_btAryBuffer = new byte[4096];
        //记录未处理数据的有效长度
        int m_nLenth = 0;
        /// <summary>
        /// 构造
        /// </summary>
        public R600Reader()
        {
            this.italker = new R600Talker();

            italker.MessageReceived += new R600ReceivedEventHandler(ReceivedTcpData);

            iSerialPort = new SerialPort();

            iSerialPort.DataReceived += new SerialDataReceivedEventHandler(ReceivedComData);
        }
        /// <summary>
        /// 打开com口
        /// </summary>
        /// <param name="strPort"></param>
        /// <param name="nBaudrate"></param>
        /// <param name="strException"></param>
        /// <returns></returns>
        public int OpenCom(string strPort, int nBaudrate, out string strException)
        {
            strException = string.Empty;

            if (iSerialPort.IsOpen)
            {
                iSerialPort.Close();
            }

            try
            {
                iSerialPort.PortName = strPort;
                iSerialPort.BaudRate = nBaudrate;
                iSerialPort.ReadTimeout = 200;
                iSerialPort.Open();
            }
            catch (System.Exception ex)
            {
                strException = ex.Message;
                return -1;
            }

            m_nType = 0;
            return 0;
        }
        /// <summary>
        /// 关闭com口
        /// </summary>
        public void CloseCom()
        {
            if (iSerialPort.IsOpen)
            {
                iSerialPort.Close();
            }

            m_nType = -1;
        }
        /// <summary>
        /// 连接服务
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="nPort"></param>
        /// <param name="strException"></param>
        /// <returns></returns>
        public int ConnectServer(IPAddress ipAddress, int nPort, out string strException)
        {
            strException = string.Empty;

            if (!italker.Connect(ipAddress, nPort, out strException))
            {
                return -1;
            }

            m_nType = 1;
            return 0;
        }
        /// <summary>
        /// 退出
        /// </summary>
        public void SignOut()
        {
            italker.SignOut();
            m_nType = -1;
        }

        private void ReceivedTcpData(byte[] btAryBuffer)
        {
            RunReceiveDataCallback(btAryBuffer);
        }

        private void ReceivedComData(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int nCount = iSerialPort.BytesToRead;
                if (nCount == 0)
                {
                    return;
                }

                byte[] btAryBuffer = new byte[nCount];
                iSerialPort.Read(btAryBuffer, 0, nCount);

                RunReceiveDataCallback(btAryBuffer);
            }
            catch (System.Exception ex)
            {

            }
        }

        private void RunReceiveDataCallback(byte[] btAryReceiveData)
        {
            try
            {
                if (ReceiveCallback != null)
                {
                    ReceiveCallback(btAryReceiveData);
                }

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

                                R600MessageTran msgTran = new R600MessageTran(btAryAnaly);
                                if (AnalyCallback != null)
                                {
                                    AnalyCallback(msgTran);
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
            catch (System.Exception ex)
            {

            }
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="btArySenderData"></param>
        /// <returns></returns>
        public int SendMessage(byte[] btArySenderData)
        {
            //串口连接方式
            if (m_nType == 0)
            {
                if (!iSerialPort.IsOpen)
                {
                    return -1;
                }

                iSerialPort.Write(btArySenderData, 0, btArySenderData.Length);

                if (SendCallback != null)
                {
                    SendCallback(btArySenderData);
                }

                return 0;
            }
            //Tcp连接方式
            else if (m_nType == 1)
            {
                if (!italker.IsConnect())
                {
                    return -1;
                }

                if (italker.SendMessage(btArySenderData))
                {
                    if (SendCallback != null)
                    {
                        SendCallback(btArySenderData);
                    }

                    return 0;
                }
            }

            return -1;
        }

        private int SendMessage(byte btReadId, byte btCmd)
        {
            R600MessageTran msgTran = new R600MessageTran(btReadId, btCmd);

            return SendMessage(msgTran.AryTranData);
        }

        private int SendMessage(byte btReadId, byte btCmd, byte[] btAryData)
        {
            R600MessageTran msgTran = new R600MessageTran(btReadId, btCmd, btAryData);

            return SendMessage(msgTran.AryTranData);
        }
        /// <summary>
        /// 检查值
        /// </summary>
        /// <param name="btAryData"></param>
        /// <returns></returns>
        public byte CheckValue(byte[] btAryData)
        {
            R600MessageTran msgTran = new R600MessageTran();

            return msgTran.CheckSum(btAryData, 0, btAryData.Length);
        }
        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public int Reset(byte btReadId)
        {
            byte btCmd = 0x70;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }
        /// <summary>
        /// 设置非同步收发传输器波特率
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="nIndexBaudrate"></param>
        /// <returns></returns>
        public int SetUartBaudrate(byte btReadId, int nIndexBaudrate)
        {
            byte btCmd = 0x71;
            byte[] btAryData = new byte[1];
            btAryData[0] = Convert.ToByte(nIndexBaudrate);

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }
        /// <summary>
        /// 获取固件版本
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public int GetFirmwareVersion(byte btReadId)
        {
            byte btCmd = 0x72;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }
        /// <summary>
        /// 设置读地址
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btNewReadId"></param>
        /// <returns></returns>
        public int SetReaderAddress(byte btReadId, byte btNewReadId)
        {
            byte btCmd = 0x73;
            byte[] btAryData = new byte[1];
            btAryData[0] = btNewReadId;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }
        /// <summary>
        /// 设置工作天线
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btWorkAntenna"></param>
        /// <returns></returns>
        public int SetWorkAntenna(byte btReadId, byte btWorkAntenna)
        {
            byte btCmd = 0x74;
            byte[] btAryData = new byte[1];
            btAryData[0] = btWorkAntenna;
            int nResult = SendMessage(btReadId, btCmd, btAryData);
            return nResult;
        }
        /// <summary>
        /// 获取工作天线
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public int GetWorkAntenna(byte btReadId)
        {
            byte btCmd = 0x75;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }
        /// <summary>
        /// 设置输出性能
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btOutputPower"></param>
        /// <returns></returns>
        public int SetOutputPower(byte btReadId, byte btOutputPower)
        {
            byte btCmd = 0x76;
            byte[] btAryData = new byte[1];
            btAryData[0] = btOutputPower;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }
        /// <summary>
        /// 获取输出性能
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public int GetOutputPower(byte btReadId)
        {
            byte btCmd = 0x77;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }
        /// <summary>
        /// 回波损耗测量
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btFrequency"></param>
        /// <returns></returns>
        public int MeasureReturnLoss(byte btReadId, byte btFrequency)
        {
            byte btCmd = 0x7E;
            byte[] btAryData = new byte[1];
            btAryData[0] = btFrequency;
            int nResult = SendMessage(btReadId, btCmd, btAryData);
            return nResult;
        }
        /// <summary>
        /// 设置频率区域
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btRegion"></param>
        /// <param name="btStartRegion"></param>
        /// <param name="btEndRegion"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 用户自定义频率
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="nStartFreq"></param>
        /// <param name="btFreqInterval"></param>
        /// <param name="btChannelQuantity"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 得到频率区域
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public int GetFrequencyRegion(byte btReadId)
        {
            byte btCmd = 0x79;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }
        /// <summary>
        /// 设置呼叫模式
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btMode"></param>
        /// <returns></returns>
        public int SetBeeperMode(byte btReadId, byte btMode)
        {
            byte btCmd = 0x7A;
            byte[] btAryData = new byte[1];
            btAryData[0] = btMode;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }
        /// <summary>
        /// 得到工作温度
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public int GetReaderTemperature(byte btReadId)
        {
            byte btCmd = 0x7B;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }
        /// <summary>
        /// 获得阻抗匹配
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btFrequency"></param>
        /// <returns></returns>
        public int GetAntImpedanceMatch(byte btReadId, byte btFrequency)
        {
            byte btCmd = 0x7E;
            byte[] btAryData = new byte[1];
            btAryData[0] = btFrequency;
            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }
        /// <summary>
        /// 设置DRM模式
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btDrmMode"></param>
        /// <returns></returns>
        public int SetDrmMode(byte btReadId, byte btDrmMode)
        {
            byte btCmd = 0x7C;
            byte[] btAryData = new byte[1];
            btAryData[0] = btDrmMode;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }
        /// <summary>
        /// 获取DRM模式
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public int GetDrmMode(byte btReadId)
        {
            byte btCmd = 0x7D;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }
        /// <summary>
        /// 读GPIO值
        /// </summary>
        /// <param name="btReadId"></param>
        /// <returns></returns>
        public int ReadGpioValue(byte btReadId)
        {
            byte btCmd = 0x60;

            int nResult = SendMessage(btReadId, btCmd);

            return nResult;
        }
        /// <summary>
        /// 写GPIO值
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btChooseGpio"></param>
        /// <param name="btGpioValue"></param>
        /// <returns></returns>
        public int WriteGpioValue(byte btReadId, byte btChooseGpio, byte btGpioValue)
        {
            byte btCmd = 0x61;
            byte[] btAryData = new byte[2];
            btAryData[0] = btChooseGpio;
            btAryData[1] = btGpioValue;

            int nResult = SendMessage(btReadId, btCmd, btAryData);

            return nResult;
        }
        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btDetectorStatus"></param>
        /// <returns></returns>
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
