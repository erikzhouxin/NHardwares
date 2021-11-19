using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace System.Data.HDSSSESDK.WinForm
{
    public partial class MainForm : Form
    {
        public static StringBuilder DevName { get; } = new StringBuilder("USB1");
        public string CurrentCard { get; private set; }
        IHD100CardApi HD100CardApi;
        public MainForm()
        {
            InitializeComponent();
            // 启动计时监听读卡
            this.TmrReadCard.Start();
            HD100CardApi = HD100CardBuilder.Create();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }

        private void TmrReadCard_Tick(object sender, EventArgs e)
        {
            if (GetCardStatus(out string cardId))
            {
                if (cardId == CurrentCard)
                {
                    this.TxtTimeTick.Text = DateTime.Now.Ticks.ToString();
                    //this.TmrReadCard.Stop();
                    return;
                }
                CurrentCard = cardId;
                try
                {
                    ReadCardInfo();
                }
                catch (Exception ex)
                {
                    //CurrentCard = null;
                    this.status.Text = "读取数据集出错!";
                }
            }
            else
            {
                this.TxtCardInfo.Text = string.Empty;
                //this.TmrReadCard.Start();
                CurrentCard = null;
            }
        }

        private void ReadCardInfo()
        {
            //连接读卡器
            var Rhandle = HD100CardApi.ICC_Reader_Open(DevName);
            if (Rhandle < 0)
            {
                this.status.Text = "读卡器连接失败";
                CurrentCard = null;
                return;
            }
            byte mode = 0x60;//认证KeyA时为0x60，认证KeyB时为0x61，此处测试用了KeyA
            byte[] password = new byte[7];
            var Key = new StringBuilder(this.KeyABox.Text.ToString());
            HD100CardApi.StrToHex(Key, 12, password);
            var sector = (byte)this.TxtSector.SelectedIndex;
            var ret = HD100CardApi.PICC_Reader_Authentication_Pass(Rhandle, mode, sector, password);
            if (ret != 0)
            {
                Key.Clear();
                Key.Append(this.KeyBBox.Text.ToString());
                HD100CardApi.StrToHex(Key, 12, password);
                ret = HD100CardApi.PICC_Reader_Authentication_Pass(Rhandle, (byte)0x61, sector, password);
                if (ret != 0)
                {
                    this.status.Text = "秘钥认证失败";
                    CurrentCard = null;
                    return;
                }
            }
            var data4 = new string[4];
            for (int i = 0; i < 4; i++)
            {
                byte[] hexData = new byte[16];
                byte Addr = (byte)((sector * 4) + i);
                ret = HD100CardApi.PICC_Reader_Read(Rhandle, Addr, hexData);
                if (ret != 0)
                {
                    this.status.Text = "读卡失败";
                    CurrentCard = null;
                    return;
                }
                switch (i)
                {
                    case 0:
                        data4[i] = new Guid(hexData).ToString();
                        break;
                    case 2:
                        data4[i] = new DateTime(BitConverter.ToInt64(hexData, 0)).ToString("yyyy-MM-dd HH:mm:ss.fffff");
                        break;
                    default:
                        data4[i] = Encoding.UTF8.GetString(hexData, 0, 16).TrimEnd();
                        break;
                }
            }

            this.TxtCardInfo.Text = "读卡成功,数据集为:";
            this.TxtCardInfo.Text += "\r\n      ID:" + data4[0];
            this.TxtCardInfo.Text += "\r\n    Name:" + data4[1];
            this.TxtCardInfo.Text += "\r\n    Time:" + data4[2];
            this.TxtCardInfo.Text += "\r\nSecurity:" + data4[3];
        }

        private bool GetCardStatus(out string cardId)
        {
            cardId = string.Empty;
            //连接读卡器
            var Rhandle = HD100CardApi.ICC_Reader_Open(DevName);
            if (Rhandle < 0)
            {
                this.status.Text = "读卡器连接失败";
                return false;
            }
            //非接基本函数
            var ret = HD100CardApi.PICC_Reader_SetTypeA(Rhandle);
            if (ret != 0)
            {
                this.status.Text = "设置为A卡模式失败";
                return false;
            }
            ret = HD100CardApi.PICC_Reader_Request(Rhandle);
            if (ret != 0)
            {
                this.status.Text = "请求卡片失败";
                return false;
            }
            var uid = new Byte[4];
            ret = HD100CardApi.PICC_Reader_anticoll(Rhandle, uid);
            if (ret != 0)
            {
                this.status.Text = "防碰撞失败";
                return false;
            }
            cardId = ConvertToHexString(uid);
            if (cardId == CurrentCard)
            {
                return true;
            }
            ret = HD100CardApi.PICC_Reader_Select(Rhandle, 0x41);
            if (ret != 0)
            {
                this.status.Text = "选卡失败";
                return false;
            }
            this.status.Text = $"寻卡成功,{cardId}";
            return true;
        }
        public static string ConvertToHexString(byte[] bytes)
        {
            StringBuilder resBuilder = new StringBuilder();
            foreach (var item in bytes)
            {
                resBuilder.AppendFormat("{0:X2}", item);
            }
            return resBuilder.ToString();
        }
        private void btn_writecard_Click(object sender, EventArgs e)
        {
            if (this.TxtPiece.SelectedIndex == 3)
            {
                MessageBox.Show("秘钥认证区块读写后可能无法再次进行读写扇区", "秘钥认证区块");
                return;
            }
            //连接读卡器
            var Rhandle = HD100CardApi.ICC_Reader_Open(DevName);
            if (Rhandle < 0)
            {
                this.status.Text = "读卡器连接失败";
                CurrentCard = null;
                return;
            }
            byte mode = 0x60;//认证KeyA时为0x60，认证KeyB时为0x61，此处测试用了KeyA
            byte[] password = new byte[7];
            var Key = new StringBuilder(this.KeyABox.Text.ToString());
            HD100CardApi.StrToHex(Key, 12, password);
            var sector = (byte)this.TxtSector.SelectedIndex;
            var ret = HD100CardApi.PICC_Reader_Authentication_Pass(Rhandle, mode, sector, password);
            if (ret != 0)
            {
                Key.Clear();
                Key.Append(this.KeyBBox.Text.ToString());
                HD100CardApi.StrToHex(Key, 12, password);
                ret = HD100CardApi.PICC_Reader_Authentication_Pass(Rhandle, (byte)0x61, sector, password);
                if (ret != 0)
                {
                    this.status.Text = "秘钥认证失败";
                    CurrentCard = null;
                    return;
                }
            }
            byte Addr = (byte)((sector * 4) + this.TxtPiece.SelectedIndex);
            byte[] hexData = new byte[17];

            //以下两种方式根据自身需求选用
            String sData = this.TxtBlockInfo.Text.ToString();
            hexData = Encoding.ASCII.GetBytes(sData.ToCharArray());//2
            ret = HD100CardApi.PICC_Reader_Write(Rhandle, Addr, hexData);
            if (ret != 0)
            {
                this.status.Text = "写卡失败";
                return;
            }
            this.status.Text = "写卡成功";
        }

        private void btn_readcard_Click(object sender, EventArgs e)
        {
            //连接读卡器
            var Rhandle = HD100CardApi.ICC_Reader_Open(DevName);
            if (Rhandle < 0)
            {
                this.status.Text = "读卡器连接失败";
                return;
            }
            byte mode = 0x60;//认证KeyA时为0x60，认证KeyB时为0x61，此处测试用了KeyA
            byte[] password = new byte[7];

            var Key = new StringBuilder(this.KeyABox.Text.ToString());
            HD100CardApi.StrToHex(Key, 12, password);

            var secNr = (byte)this.TxtSector.SelectedIndex;

            var ret = HD100CardApi.PICC_Reader_Authentication_Pass(Rhandle, mode, secNr, password);
            if (ret != 0)
            {
                Key.Clear();
                Key.Append(this.KeyBBox.Text.ToString());
                HD100CardApi.StrToHex(Key, 12, password);

                ret = HD100CardApi.PICC_Reader_Authentication_Pass(Rhandle, (byte)0x61, secNr, password);
                if (ret != 0)
                {
                    this.status.Text = "秘钥认证失败";
                    return;
                }
            }
            byte Addr = (byte)((secNr * 4) + this.TxtPiece.SelectedIndex);

            byte[] hexData = new byte[17];
            StringBuilder sbData = new StringBuilder(50);

            ret = HD100CardApi.PICC_Reader_Read(Rhandle, Addr, hexData);
            if (ret != 0)
            {
                this.status.Text = "读卡失败";
                return;
            }
            HD100CardApi.HexToStr(hexData, 16, sbData);

            this.TxtBlockInfo.Text = "读卡成功";
            this.TxtBlockInfo.Text += "\r\nhexstr:" + sbData.ToString();
            this.TxtBlockInfo.Text += "\r\nASC:" + Encoding.UTF8.GetString(hexData);
        }

        private void btn_FindCard_Click(object sender, EventArgs e)
        {
            //M1卡操作示例
            //连接读卡器
            var Rhandle = HD100CardApi.ICC_Reader_Open(DevName);
            if (Rhandle < 0)
            {
                this.status.Text = "读卡器连接失败";
                return;
            }
            //非接基本函数
            var ret = HD100CardApi.PICC_Reader_SetTypeA(Rhandle);
            if (ret != 0)
            {
                this.status.Text = "设置为A卡模式失败";
                return;
            }
            ret = HD100CardApi.PICC_Reader_Request(Rhandle);
            if (ret != 0)
            {
                this.status.Text = "请求卡片失败";
                return;
            }
            var uid = new Byte[5];
            ret = HD100CardApi.PICC_Reader_anticoll(Rhandle, uid);
            if (ret != 0)
            {
                this.status.Text = "防碰撞失败";
                return;
            }
            ret = HD100CardApi.PICC_Reader_Select(Rhandle, 0x41);
            if (ret != 0)
            {
                this.status.Text = "选卡失败";
                return;
            }
            this.status.Text = "寻卡成功";
        }

        private void btn_VerifyKey_Click(object sender, EventArgs e)
        {
            var Rhandle = HD100CardApi.ICC_Reader_Open(DevName);
            if (Rhandle < 0)
            {
                this.status.Text = "读卡器连接失败";
                return;
            }
            byte mode = 0x60;//认证KeyA时为0x60，认证KeyB时为0x61，此处测试用了KeyA
            byte[] password = new byte[7];

            var Key = new StringBuilder(this.KeyABox.Text.ToString());
            HD100CardApi.StrToHex(Key, 12, password);

            var secNr = (byte)this.TxtSector.SelectedIndex;

            var ret = HD100CardApi.PICC_Reader_Authentication_Pass(Rhandle, mode, secNr, password);
            if (ret != 0)
            {
                Key.Clear();
                Key.Append(this.KeyBBox.Text.ToString());
                HD100CardApi.StrToHex(Key, 12, password);

                ret = HD100CardApi.PICC_Reader_Authentication_Pass(Rhandle, (byte)0x61, secNr, password);
                if (ret != 0)
                {
                    this.status.Text = "秘钥认证失败";
                    return;
                }
            }
            this.status.Text = "秘钥认证成功";
        }

        private void BtnWriteInfo_Click(object sender, EventArgs e)
        {
            var name = this.TxtInfoName.Text.Trim();
            var time = DateTime.Now;
            if (DateTime.TryParse(this.TxtTimeTick.Text, out DateTime newTime))
            {
                time = newTime;
            }
            if (!Guid.TryParse(this.TxtInfoID.Text, out Guid id))
            {
                id = Guid.NewGuid();
                this.TxtInfoID.Text = id.ToString("N");
            }

            //连接读卡器
            var Rhandle = HD100CardApi.ICC_Reader_Open(DevName);
            if (Rhandle < 0)
            {
                this.status.Text = "读卡器连接失败";
                CurrentCard = null;
                return;
            }
            byte mode = 0x60;//认证KeyA时为0x60，认证KeyB时为0x61，此处测试用了KeyA
            byte[] password = new byte[7];
            var Key = new StringBuilder(this.KeyABox.Text.ToString());
            HD100CardApi.StrToHex(Key, 12, password);
            var sector = (byte)this.TxtSector.SelectedIndex;
            var ret = HD100CardApi.PICC_Reader_Authentication_Pass(Rhandle, mode, sector, password);
            if (ret != 0)
            {
                Key.Clear();
                Key.Append(this.KeyBBox.Text.ToString());
                HD100CardApi.StrToHex(Key, 12, password);
                ret = HD100CardApi.PICC_Reader_Authentication_Pass(Rhandle, (byte)0x61, sector, password);
                if (ret != 0)
                {
                    this.status.Text = "秘钥认证失败";
                    CurrentCard = null;
                    return;
                }
            }
            var data3 = new List<Byte[]>()
            {
                { id.ToByteArray() },
                { Encoding.UTF8.GetBytes(name) },
                { BitConverter.GetBytes(time.Ticks) },
            };
            for (int i = 0; i < 3; i++)
            {
                byte Addr = (byte)((sector * 4) + i);
                var hexData = data3[i];
                ret = HD100CardApi.PICC_Reader_Write(Rhandle, Addr, hexData);
                if (ret != 0)
                {
                    this.status.Text = "写卡失败";
                    return;
                }
            }
            this.status.Text = "写卡成功";
        }

        private void BtnResetPass_Click(object sender, EventArgs e)
        {
            //连接读卡器
            var Rhandle = HD100CardApi.ICC_Reader_Open(DevName);
            if (Rhandle < 0)
            {
                this.status.Text = "读卡器连接失败";
                return;
            }
            byte mode = 0x60;//认证KeyA时为0x60，认证KeyB时为0x61，此处测试用了KeyA
            byte[] password = new byte[7];
            var Key = new StringBuilder(this.KeyABox.Text.ToString());
            HD100CardApi.StrToHex(Key, 12, password);
            var sector = (byte)this.TxtSector.SelectedIndex;
            var ret = HD100CardApi.PICC_Reader_Authentication_Pass(Rhandle, mode, sector, password);
            if (ret != 0)
            {
                Key.Clear();
                Key.Append(this.KeyBBox.Text.ToString());
                HD100CardApi.StrToHex(Key, 12, password);
                ret = HD100CardApi.PICC_Reader_Authentication_Pass(Rhandle, (byte)0x61, sector, password);
                if (ret != 0)
                {
                    this.status.Text = "秘钥认证失败";
                    return;
                }
            }
            byte Addr = (byte)((sector * 4) + 3);
            var hexData = new byte[16];
            HD100CardApi.StrToHex(new StringBuilder("000000000000FF078069FFFFFFFFFFFF"), 32, hexData);
            ret = HD100CardApi.PICC_Reader_Write(Rhandle, Addr, hexData);
            if (ret != 0)
            {
                this.status.Text = "重置扇区密钥写卡失败";
                return;
            }
            this.status.Text = "重置扇区密钥写卡成功";
        }
        private bool TestKeySecurityFormat()
        {
            var regex = new Regex("[0-9abcdefABCDEF]{12}");
            if (!regex.IsMatch(this.KeyABox.Text))
            {
                MessageBox.Show("KeyA密钥是十六进制(0-9A-Fa-f)组成的12位字符串.", "密钥格式错误");
                return false;
            }
            if (!regex.IsMatch(this.KeyBBox.Text))
            {
                MessageBox.Show("KeyB密钥是十六进制(0-9A-Fa-f)组成的12位字符串.", "密钥格式错误");
                return false;
            }
            return true;
        }
        private void BtnEidtPass_Click(object sender, EventArgs e)
        {
            if (!TestKeySecurityFormat()) { return; }
            var keyA = this.KeyABox.Text;
            var keyB = this.KeyBBox.Text;
            //连接读卡器
            var Rhandle = HD100CardApi.ICC_Reader_Open(DevName);
            if (Rhandle < 0)
            {
                this.status.Text = "读卡器连接失败";
                return;
            }
            byte[] password = new byte[7];
            HD100CardApi.StrToHex(new StringBuilder("000000000000"), 12, password);
            var sector = (byte)this.TxtSector.SelectedIndex;
            //认证KeyA时为0x60，认证KeyB时为0x61，此处测试用了KeyA
            var ret = HD100CardApi.PICC_Reader_Authentication_Pass(Rhandle, 0x60, sector, password);
            if (ret != 0)
            {
                HD100CardApi.StrToHex(new StringBuilder("ffffffffffff"), 12, password);
                ret = HD100CardApi.PICC_Reader_Authentication_Pass(Rhandle, (byte)0x61, sector, password);
                if (ret != 0)
                {
                    this.status.Text = "秘钥认证失败,请重置扇区密钥后操作";
                    return;
                }
            }
            var hexData = new byte[16];
            var keyABytes = new byte[12];
            HD100CardApi.StrToHex(new StringBuilder(keyA), 12, keyABytes);
            //keyABytes.CopyTo(hexData,)
            hexData[12] = 0xFF;
            hexData[13] = 0x07;
            hexData[14] = 0x80;
            hexData[15] = 0x69;
            byte Addr = (byte)((sector * 4) + 3);
            ret = HD100CardApi.PICC_Reader_Write(Rhandle, Addr, hexData);
            if (ret != 0)
            {
                this.status.Text = "修改扇区密码写卡失败";
                return;
            }
            this.status.Text = "修改扇区密码写卡成功";
        }
    }
}
