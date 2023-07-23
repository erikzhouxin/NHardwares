using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Drawing.Drawing2D;
using System.Data.DeYaLpnrSDK;

namespace LPNRTest
{
    public partial class LPNRTester : Form
    {
        IRWLPNRSdkProxy sdkClient = RWLPNRSdk.Create(true);
        private string byteToString(byte[] data)
        {
            if (data.Length == 0)
                return "";
            int index = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == 0x00)
                    break;
                index++;
            }
            byte[] newdat = new byte[index];
            Array.Copy(data, newdat, index);
            return System.Text.Encoding.Default.GetString(newdat);
        }

        static byte[] ImageData;
        static readonly  object locker = new Object();

        private void lpnrcb(IntPtr ptr, int code)
        {
            if (code == 1)
                sdkClient.LPNR_EnableLiveFrame(lpnr, 1);

            if( 5 == code ) // live frame
            {
                Int32 len = sdkClient.LPNR_GetLiveFrameSize(lpnr);
                if( len > 0 )
                {
                    byte[] buf = new byte[len];
                    sdkClient.LPNR_GetLiveFrame(lpnr, buf);
                    // realShowImage(buf);
                    GuiShowImage(buf);
                    lock (locker)
                    {
                        ImageData = new byte[len];
                        Array.Copy(buf, ImageData, len);
                    }
                    return;
                }
            }
            if( code == 4 )
            {
                Int32 len = sdkClient.LPNR_GetCapturedImageSize(lpnr);
                byte[] plate = new byte[20];
                sdkClient.LPNR_GetPlateNumber(lpnr, plate);
                string rplate = byteToString(plate);
                string strplate = System.Text.Encoding.Default.GetString(plate);
                trace_log("获取到车牌号为：" + strplate + "\r\n");
                byte[] buf = new byte[len];
                sdkClient.LPNR_GetCapturedImage(lpnr, buf);
              
                GuiShowRecImage(buf);
            }
        }


        public delegate void ReportLog(string str);
        public ReportLog RunLog = null;
        private LPNRCallBack lpnr_cb = null;
        
        public delegate int GetIndex();
        public GetIndex getIndex = null;

        public int real_get_index()
        {
            if ( getIndex != null )
                return getIndex();
            return 0;
        }


        public delegate void TraceLog(string str);

        public void append_log(string str)
        {
            if (this.textBox2.Text.Length > 1024)
                this.textBox2.Text = "";

            if (str.EndsWith("\r\n"))
                this.textBox2.Text += str;
            else
                this.textBox2.Text += str + "\r\n";
        }

        public void trace_log(string str)
        {
            this.textBox2.BeginInvoke(new TraceLog(append_log), str);
        }

        public string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }

        public delegate void ShowImage(byte[] data);

        private static System.Drawing.Image resizeImage(System.Drawing.Image imgToResize, Size size)
        {
            //获取图片宽度
            int sourceWidth = imgToResize.Width;
            //获取图片高度
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            //计算宽度的缩放比例
            nPercentW = ((float)size.Width / (float)sourceWidth);
            //计算高度的缩放比例
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;
            //期望的宽度
            int destWidth = (int)(sourceWidth * nPercent);
            //期望的高度
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //绘制图像
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (System.Drawing.Image)b;
        }

        public void realShowRecoginzeImage(byte[] data)
        {
            DateTime dt1 = DateTime.Now;
            DateTime dt2;
            TimeSpan ts;
            MemoryStream ms = new MemoryStream(data);
            Image img = System.Drawing.Image.FromStream(ms);
            this.pictureBox2.Image = resizeImage( img, this.pictureBox2.Size );
        }
        public void realShowImage( byte[] data)
        {
            DateTime dt1 = DateTime.Now;
            DateTime dt2;
            TimeSpan ts;
            MemoryStream ms = new MemoryStream(data);
            Image img = System.Drawing.Image.FromStream(ms);
            Image imgc =
            this.pictureBox1.Image = resizeImage(img, this.pictureBox1.Size);
        }
        private void GuiShowImage( byte[] data)
        {
            this.pictureBox1.Invoke(new ShowImage(realShowImage), data);
        }

        private void GuiShowRecImage( byte[] data)
        {
            this.pictureBox2.Invoke(new ShowImage(realShowRecoginzeImage), data);
        }
    
        private IntPtr lpnr = IntPtr.Zero;

        public LPNRTester()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lpnr != IntPtr.Zero)
                return;
            IPAddress addr = IPAddress.Parse(this.textBox1.Text);

            lpnr_cb += lpnrcb;
            byte[] ipaddr = System.Text.Encoding.Default.GetBytes(this.textBox1.Text);
            byte[] ip = new byte[ipaddr.Length + 1];
            Array.Copy(ipaddr, ip, ipaddr.Length);
            ip[ipaddr.Length] = 0;
            lpnr = sdkClient.LPNR_Init(ip);
            if (lpnr == IntPtr.Zero)
            {
                trace_log("Init Failed!" + byteToHexStr(ipaddr));
                return;
            }

            sdkClient.LPNR_EnableLiveFrame(lpnr, 0);
            sdkClient.LPNR_SetCallBack(lpnr, lpnr_cb );
            trace_log("Init Ok! Ptr "+ lpnr +"\r\n" + byteToHexStr(ipaddr));
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // 单次触发
            sdkClient.LPNR_SoftTrigger(lpnr);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (lpnr != IntPtr.Zero)
                sdkClient.LPNR_Terminate(lpnr);
        }

        private Timer timer = new Timer();
        

        void EvnetHandle(object sender, EventArgs e )
        {
            if ( lpnr != IntPtr.Zero )
                sdkClient.LPNR_SoftTrigger(lpnr);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            if (box.Checked)
            {
                timer.Interval = int.Parse(this.textBox3.Text);
                timer.Tick += EvnetHandle;
                timer.Start();
            }
            else
                timer.Stop();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 单次触发
            if (lpnr != IntPtr.Zero)
                sdkClient.LPNR_SoftTrigger(lpnr);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ImageData == null) return;
            // 每次实时帧的回调函数中，需要对图片帧单独做保存
            lock (locker)
            {
                if( ImageData.Length > 0 )
                    GuiShowRecImage(ImageData);
            }
        }        
    }
}
