using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.WeiGuangCodeBarSDK;

namespace Txq_csharp_sdk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static Thread DecodeThread = null;
        delegate void ShowRichTextBoxMsgRef(System.Windows.Forms.RichTextBox lpRichTextBox, string lpMsg);
        //循环是否启动标记
        public static bool bIsLoop = false;
        SimpleVBarApi Api = new SimpleVBarApi();

        public string Decoder()
        {
            byte[] result;
            string sResult = null;
            int size;
            if (Api.GetResultStr(out result, out size))
            {

                string msg = System.Text.Encoding.Default.GetString(result);
                byte[] buffer = Encoding.UTF8.GetBytes(msg);
                sResult = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
            }
            else
            {
                sResult = null;
            }
            return sResult;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            StopDecodeThread();

            Application.Exit();
        }

        private void btnLightOn_Click(object sender, EventArgs e)
        {
            Api.Backlight(true);

        }

        private void btnLightOff_Click(object sender, EventArgs e)
        {
            Api.Backlight(false);

        }



        private void btnOpenDevice_Click(object sender, EventArgs e)
        {

            if (Api.OpenDevice())
            {
                MessageBox.Show("连接设备成功");
                // 开启解码线程进行
                bIsLoop = true;
                DecodeThread = new Thread(new ThreadStart(DecodeThreadMethod));
                DecodeThread.IsBackground = true;
                DecodeThread.Start();
            }
            else
            {
                MessageBox.Show("连接设备失败");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.richTextBoxResult.Clear();
        }

        /// <summary>
        /// 方法：停止解码线程方法
        /// </summary>
        private void StopDecodeThread()
        {
            bIsLoop = false;
            if (DecodeThread != null)
            {
                DecodeThread.Abort();
                while (DecodeThread.ThreadState != ThreadState.Aborted)
                {
                    Thread.Sleep(50);
                }
            }
        }

        /// <summary>
        /// 方法：扫码线程方法
        /// </summary>
        private void DecodeThreadMethod()
        {
            string decoderesult = null;
            ShowRichTextBoxMsgRef ShowRichTextBoxMsgRef_Instance = new ShowRichTextBoxMsgRef(ShowRichTextBoxMsg);
            do
            {
                //+ Environment.NewLine
                decoderesult = Decoder();
                if (decoderesult != null)
                {
                    this.Invoke(ShowRichTextBoxMsgRef_Instance, new object[] { this.richTextBoxResult, decoderesult + Environment.NewLine });
                    decoderesult = null;
                }
            }
            while (bIsLoop);
        }
        /// <summary>
        /// 方法：显示文本信息
        /// </summary>
        /// <param name="lpRichTextBox"></param>
        /// <param name="lpMsg"></param>
        private void ShowRichTextBoxMsg(System.Windows.Forms.RichTextBox lpRichTextBox, string lpMsg)
        {
            lpRichTextBox.AppendText(lpMsg);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StopDecodeThread();

            Api.CloseDevice();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Api.ControlScan(true);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Api.ControlScan(false);
        }

    }
}

