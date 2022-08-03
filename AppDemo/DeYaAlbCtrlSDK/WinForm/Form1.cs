using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.DeYaAlbCtrlSDK;

namespace ALBDLLTester
{
    public partial class Form1 : Form
    {
        IAlbCtrlSdkProxy ALBDLL = AlbCtrlSdk.Create();
        public Form1()
        {
            InitializeComponent();
        }
        IntPtr myPtr = new IntPtr(0);
        public IntPtr handle = new IntPtr(0);
        public const int USER = 0x400;
        public const int MYMESSAGE = USER + 2;
        public static int Sum = 0;
        private void Btn_open_Click(object sender, EventArgs e)
        {
            string ip = textBox1.Text.ToString();
            if (ip == "")
                return;
            handle = ALBDLL.DEV_Open(ip);
            if (handle == IntPtr.Zero)
            {
                MessageBox.Show("设备打开失败！");
                return;
            }
            else
            {
                MessageBox.Show("设备打开成功！");
            }
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            if (handle == IntPtr.Zero)
                return;
            ALBDLL.DEV_Close(handle);
        }
        private void eventcall(IntPtr h, int nEvent, int nParam)
        {
            myPtr = FindWindow(null, "ALBDLLTester");
            if (myPtr == IntPtr.Zero)
            {
                throw new Exception("Could not find Main window!");
            }
            //Console.WriteLine(" nEvent=" + nEvent + ",nParam=" + nParam+ ",myPtr=" + myPtr);
            int Lparam = ((nEvent & 0xff) << 8) | (nParam & 0xff);
            long result = SendMessage(myPtr, MYMESSAGE, handle, Lparam);
        }


        private void Btn_RegisEvent_Click(object sender, EventArgs e)
        {
            DEVEventCallBack callback = new DEVEventCallBack(eventcall);
            if (ALBDLL.DEV_SetEventHandle(handle, callback))
            {
                MessageBox.Show("注册回调成功！");
            }
            else
            {
                MessageBox.Show("注册回调失败！");
            }
        }

        private void Btn_Raise_Click(object sender, EventArgs e)
        {
            if (handle != IntPtr.Zero)
            {
                ALBDLL.DEV_ALB_Ctrl(handle, true);
            }
        }

        /// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message"/> to process.</param>
        protected override void DefWndProc(ref System.Windows.Forms.Message m)
        {

            if (m.Msg == MYMESSAGE)
            {
                this.listView1.BeginUpdate(); //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度          
                ListViewItem lvi = new ListViewItem();
                DateTime currentTime = System.DateTime.Now;
                lvi.Text = currentTime.ToString("HH:mm:ss.fff");
                int lparm = int.Parse(m.LParam.ToString());
                int lparm2 = ((lparm >> 8) & 0xFF);
                lparm = lparm & 0xFF;
                switch (lparm2)
                {
                    case 1:
                        {
                            switch (lparm)
                            {
                                case 0:
                                    //pdlg->m_listEvent.InsertItem(0, (LPCTSTR)pdlg->Gettime());
                                    lvi.SubItems.Add("未知状态！");
                                    break;
                                case 1:
                                    //pdlg->m_listEvent.InsertItem(0, (LPCTSTR)pdlg->Gettime());
                                    //pdlg->m_listEvent.SetItemText(0, 1, _T("落杆中！"));
                                    lvi.SubItems.Add("落杆中！");
                                    break;
                                case 2:
                                    //pdlg->m_listEvent.InsertItem(0, (LPCTSTR)pdlg->Gettime());
                                    //pdlg->m_listEvent.SetItemText(0, 1, _T("落到水平位置！"));
                                    lvi.SubItems.Add("落到水平位置！");
                                    break;
                                case 3:
                                    //pdlg->m_listEvent.InsertItem(0, (LPCTSTR)pdlg->Gettime());
                                    //pdlg->m_listEvent.SetItemText(0, 1, _T("抬杆中！"));
                                    lvi.SubItems.Add("抬杆中！");
                                    break;
                                case 4:
                                    //pdlg->m_listEvent.InsertItem(0, (LPCTSTR)pdlg->Gettime());
                                    //pdlg->m_listEvent.SetItemText(0, 1, _T("抬到竖直位置！"));
                                    lvi.SubItems.Add("抬到竖直位置！");
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case 2:
                        {
                            switch (lparm)
                            {
                                case 0:
                                    //pdlg->m_listEvent.InsertItem(0, (LPCTSTR)pdlg->Gettime());
                                    //pdlg->m_listEvent.SetItemText(0, 1, _T("抓拍线圈无车！"));
                                    lvi.SubItems.Add("抓拍线圈无车！");
                                    break;
                                case 1:
                                    //pdlg->m_listEvent.InsertItem(0, (LPCTSTR)pdlg->Gettime());
                                    //pdlg->m_listEvent.SetItemText(0, 1, _T("抓拍线圈有车！"));
                                    lvi.SubItems.Add("抓拍线圈有车！");
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case 3:
                        {
                            switch (lparm)
                            {
                                case 0:
                                    //pdlg->m_listEvent.InsertItem(0, (LPCTSTR)pdlg->Gettime());
                                    //pdlg->m_listEvent.SetItemText(0, 1, _T("防砸线圈无车！"));
                                    lvi.SubItems.Add("防砸线圈无车！");
                                    break;
                                case 1:
                                    //pdlg->m_listEvent.InsertItem(0, (LPCTSTR)pdlg->Gettime());
                                    //pdlg->m_listEvent.SetItemText(0, 1, _T("防砸线圈有车！"));
                                    lvi.SubItems.Add("防砸线圈有车！");
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case 4:
                        //pdlg->m_listEvent.InsertItem(0, (LPCTSTR)pdlg->Gettime());
                        //pdlg->m_listEvent.SetItemText(0, 1, _T("收到事件4消息！"));
                        lvi.SubItems.Add("收到事件！");
                        break;
                    case 96:
                        //pdlg->m_listEvent.InsertItem(0, (LPCTSTR)pdlg->Gettime());
                        //pdlg->m_listEvent.SetItemText(0, 1, _T("设备接受连接消息！"));
                        lvi.SubItems.Add("设备接受连接消息！");
                        break;
                    case 97:
                        //pdlg->m_listEvent.InsertItem(0, (LPCTSTR)pdlg->Gettime());
                        //pdlg->m_listEvent.SetItemText(0, 1, _T("设备拒绝连接消息！"));
                        lvi.SubItems.Add("设备拒绝连接消息！");
                        break;
                    case 98:
                        //pdlg->m_listEvent.InsertItem(0, (LPCTSTR)pdlg->Gettime());
                        //pdlg->m_listEvent.SetItemText(0, 1, _T("与设备建立连线消息！"));
                        lvi.SubItems.Add("与设备建立连线消息！");
                        break;
                    case 99:
                        //pdlg->m_listEvent.InsertItem(0, (LPCTSTR)pdlg->Gettime());
                        //pdlg->m_listEvent.SetItemText(0, 1, _T("与设备连线断开连接！"));
                        lvi.SubItems.Add("与设备连线断开连接！");
                        break;
                    default:
                        break;
                }
                this.listView1.Items.Add(lvi);
                this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。
            }
            base.DefWndProc(ref m);//调用基类函数处理非自定义消息。
        }

        private void Btn_Fall_Click(object sender, EventArgs e)
        {
            if (handle != IntPtr.Zero)
            {
                ALBDLL.DEV_ALB_Ctrl(handle, false);
            }
        }

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, Int32 wMsg, IntPtr wParam, int lParam);

        private void Btn_Getstate_Click(object sender, EventArgs e)
        {
            int status = 0;
            unsafe
            {
                int* dw = &status;

                if (handle == IntPtr.Zero)
                {
                    this.textBox2.Text = "离线";
                    //AppendText(_T("离线"));
                    return;
                }
                uint dwx;
                if (!ALBDLL.DEV_GetStatus(handle, out dwx))
                {
                    MessageBox.Show("获取状态失败！");
                }
                if (((0x01 << 6) & status) > 0)
                {
                    Console.WriteLine("status=" + status);
                    this.textBox2.Text = "在线";
                }
                else
                {
                    this.textBox2.Text = "离线";
                }
            }
        }

        private void Btn_ResgisMsg_Click(object sender, EventArgs e)
        {
            myPtr = FindWindow(null, "ALBDLLTester");
            if (myPtr == IntPtr.Zero)
            {
                throw new Exception("Could not find Main window!");
            }
            if (handle == IntPtr.Zero)
            {
                return;
            }
            IntPtr wind = this.Handle;
            Console.WriteLine("ptr：" + myPtr + "ptr" + wind);
            if (ALBDLL.DEV_EnableEventMessageEx(handle, wind, MYMESSAGE))
            {
                MessageBox.Show("注册消息成功！");
            }
            else
            {
                MessageBox.Show("注册消息失败！");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button_q_Click(object sender, EventArgs e)
        {
            if (handle != IntPtr.Zero)
            {
                ALBDLL.DEV_Queue(handle, true);
                string text = this.button_q.Text;
                ALBDLL.DEV_Queue(handle, text == "启动队列" ? true : false);
                this.button_q.Text = text == "启动队列" ? "关闭队列" : "启动队列";
            }
        }
    }
}
