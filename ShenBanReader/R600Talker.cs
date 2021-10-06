using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// 话事接口
    /// </summary>
    interface IR600Talker
    {
        /// <summary>
        /// 接收到发来的消息
        /// </summary>
        event R600ReceivedEventHandler MessageReceived;
        /// <summary>
        /// 连接到服务端
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="strException"></param>
        /// <returns></returns>
        bool Connect(IPAddress ip, int port, out string strException);
        /// <summary>
        /// 发送数据包
        /// </summary>
        /// <param name="btAryBuffer"></param>
        /// <returns></returns>
        bool SendMessage(byte[] btAryBuffer);
        /// <summary>
        /// 注销连接
        /// </summary>
        void SignOut();
        /// <summary>
        /// 校验是否连接服务器
        /// </summary>
        /// <returns></returns>
        bool IsConnect();
    }
    /// <summary>
    /// 话事类
    /// </summary>
    public class R600Talker : IR600Talker
    {
        /// <summary>
        /// 消息接收事件
        /// </summary>
        public event R600ReceivedEventHandler MessageReceived;

        TcpClient client;
        Stream streamToTran;
        private Thread waitThread;

        private bool bIsConnect = false;
        /// <summary>
        /// 连接
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="nPort"></param>
        /// <param name="strException"></param>
        /// <returns></returns>
        public bool Connect(IPAddress ipAddress, int nPort, out string strException)
        {
            strException = string.Empty;
            try
            {
                client = new TcpClient();
                client.Connect(ipAddress, nPort);
                streamToTran = client.GetStream();    // 获取连接至远程的流

                //建立线程收取服务器发送数据
                ThreadStart stThead = new ThreadStart(ReceivedData);
                waitThread = new Thread(stThead);
                waitThread.IsBackground = true;
                waitThread.Start();

                bIsConnect = true;
                return true;
            }
            catch (System.Exception ex)
            {
                strException = ex.Message;
                return false;
            }
        }

        private void ReceivedData()
        {
            while (true)
            {
                try
                {
                    byte[] btAryBuffer = new byte[4096];
                    int nLenRead = streamToTran.Read(btAryBuffer, 0, btAryBuffer.Length);
                    if (nLenRead == 0)
                    {
                        continue;
                    }

                    if (MessageReceived != null)
                    {
                        byte[] btAryReceiveData = new byte[nLenRead];

                        Array.Copy(btAryBuffer, btAryReceiveData, nLenRead);

                        MessageReceived(btAryReceiveData);
                    }
                }
                catch (System.Exception ex)
                {

                }
            }

        }
        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="btAryBuffer"></param>
        /// <returns></returns>
        public bool SendMessage(byte[] btAryBuffer)
        {
            try
            {
                lock (streamToTran)
                {
                    streamToTran.Write(btAryBuffer, 0, btAryBuffer.Length);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 退出
        /// </summary>
        public void SignOut()
        {
            if (streamToTran != null)
                streamToTran.Dispose();
            if (client != null)
                client.Close();

            waitThread.Abort();
            bIsConnect = false;
        }
        /// <summary>
        /// 是连接
        /// </summary>
        /// <returns></returns>
        public bool IsConnect()
        {
            return bIsConnect;
        }
    }
}
