using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// 消息传送
    /// </summary>
    public class R600Message
    {
        private readonly byte btDataLen;        //数据包长度，数据包从‘长度’字节后面开始的字节数，不包含‘长度’字节本身
        private readonly byte btCheck;          //校验和，除校验和本身外所有字节的校验和

        /// <summary>
        /// 完整数据包
        /// </summary>
        public byte[] AryTranData { get; private set; }
        /// <summary>
        /// 数据包命令参数，部分命令无参数
        /// </summary>
        public byte[] AryData { get; private set; }
        /// <summary>
        /// 读写器地址
        /// </summary>
        public byte ReadId { get; private set; }
        /// <summary>
        /// 数据包命令代码
        /// </summary>
        public byte Cmd { get; private set; }
        /// <summary>
        /// 数据包头，默认为0xA0
        /// </summary>
        public byte PacketType { get; private set; }
        /// <summary>
        /// 构造
        /// </summary>
        public R600Message() { }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btCmd"></param>
        /// <param name="btAryData"></param>
        public R600Message(byte btReadId, byte btCmd, byte[] btAryData)
        {
            int nLen = btAryData.Length;

            this.PacketType = 0xA0;
            this.btDataLen = Convert.ToByte(nLen + 3);
            this.ReadId = btReadId;
            this.Cmd = btCmd;

            this.AryData = new byte[nLen];
            btAryData.CopyTo(this.AryData, 0);

            this.AryTranData = new byte[nLen + 5];
            this.AryTranData[0] = this.PacketType;
            this.AryTranData[1] = this.btDataLen;
            this.AryTranData[2] = this.ReadId;
            this.AryTranData[3] = this.Cmd;
            this.AryData.CopyTo(this.AryTranData, 4);

            this.btCheck = CheckSum(this.AryTranData, 0, nLen + 4);
            this.AryTranData[nLen + 4] = this.btCheck;
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="btReadId"></param>
        /// <param name="btCmd"></param>
        public R600Message(byte btReadId, byte btCmd)
        {
            this.PacketType = 0xA0;
            this.btDataLen = 0x03;
            this.ReadId = btReadId;
            this.Cmd = btCmd;

            this.AryTranData = new byte[5];
            this.AryTranData[0] = this.PacketType;
            this.AryTranData[1] = this.btDataLen;
            this.AryTranData[2] = this.ReadId;
            this.AryTranData[3] = this.Cmd;

            this.btCheck = CheckSum(this.AryTranData, 0, 4);
            this.AryTranData[4] = this.btCheck;
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="btAryTranData"></param>
        public R600Message(byte[] btAryTranData)
        {
            int nLen = btAryTranData.Length;

            this.AryTranData = new byte[nLen];
            btAryTranData.CopyTo(this.AryTranData, 0);


            byte btCK = CheckSum(this.AryTranData, 0, this.AryTranData.Length - 1);
            if (btCK != btAryTranData[nLen - 1])
            {
                return;
            }

            this.PacketType = btAryTranData[0];
            this.btDataLen = btAryTranData[1];
            this.ReadId = btAryTranData[2];
            this.Cmd = btAryTranData[3];
            this.btCheck = btAryTranData[nLen - 1];

            if (nLen > 5)
            {
                this.AryData = new byte[nLen - 5];
                for (int nloop = 0; nloop < nLen - 5; nloop++)
                {
                    this.AryData[nloop] = btAryTranData[4 + nloop];
                }
            }
        }
        /// <summary>
        /// 检查和
        /// </summary>
        /// <param name="btAryBuffer"></param>
        /// <param name="nStartPos"></param>
        /// <param name="nLen"></param>
        /// <returns></returns>
        public byte CheckSum(byte[] btAryBuffer, int nStartPos, int nLen)
        {
            byte btSum = 0x00;

            for (int nloop = nStartPos; nloop < nStartPos + nLen; nloop++)
            {
                btSum += btAryBuffer[nloop];
            }

            return Convert.ToByte(((~btSum) + 1) & 0xFF);
        }
    }
}
