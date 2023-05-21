using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using System.Data.VzClientSDK;

namespace VzClientSDK.WinForm
{
    public partial class SerialControl_Form : Form
    {
        static IVzClientSdkProxy VzClientSDK = VzClientSdk.Create();
        private const int MSG_SERIAL_RECV = 0x913;

        private IntPtr lpr_handle_ = IntPtr.Zero;
        private IntPtr serial_handle_ = IntPtr.Zero;
        private VZDEV_SERIAL_RECV_DATA_CALLBACK serial_recv_ = null;
        private byte[] recv_data_ = new byte[10240];
        private int size_serial_recv_ = 0;

        public IntPtr hwndMain;

        public SerialControl_Form()
        {
            InitializeComponent();
        }

        public void SetLPRHandle(IntPtr handle)
        {
            lpr_handle_ = handle;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (lpr_handle_ != IntPtr.Zero)
            {
                int port = cmbPort.SelectedIndex;
                serial_handle_ = VzClientSDK.VzLPRClient_SerialStart(lpr_handle_, port, serial_recv_, IntPtr.Zero);
                if (serial_handle_ == IntPtr.Zero)
                {
                    MessageBox.Show("打开串口失败，请重试!");
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (serial_handle_ != IntPtr.Zero)
            {
                int ret = VzClientSDK.VzLPRClient_SerialStop(serial_handle_);
                if (ret == 0)
                {
                    serial_handle_ = IntPtr.Zero;
                }
            }
        }

        private void SerialControl_Form_Load(object sender, EventArgs e)
        {
            cmbPort.SelectedIndex = 0;

            serial_recv_ = new VZDEV_SERIAL_RECV_DATA_CALLBACK(OnserialRECV);


            hwndMain = this.Handle;
        }

        private void ShowSerialData()
        {
            if (size_serial_recv_ > 0)
            {
                byte[] buf_data = new byte[size_serial_recv_];
                System.Buffer.BlockCopy(recv_data_, 0, buf_data, 0, size_serial_recv_);

                string str = "";
                if (chkBoxHex.Checked)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < size_serial_recv_; i++)
                    {
                        int asc = (int)buf_data[i];
                        string strhex = asc.ToString("X2");
                        sb.Append(strhex);
                        sb.Append(" ");
                    }

                    str = sb.ToString();
                }
                else
                {
                    str = System.Text.Encoding.Default.GetString(buf_data);
                }

                txtRecv.Text = str;
            }
        }

        private int OnserialRECV(IntPtr nSerialHandle, IntPtr pRecvData, int uRecvSize, IntPtr pUserData)
        {
            if (nSerialHandle == serial_handle_ && pRecvData != IntPtr.Zero && uRecvSize > 0)
            {
                byte[] cur_recv = new byte[uRecvSize];
                Marshal.Copy(pRecvData, cur_recv, 0, uRecvSize);

                System.Buffer.BlockCopy(cur_recv, 0, recv_data_, size_serial_recv_, uRecvSize);
                size_serial_recv_ += uRecvSize;

                Win32API.PostMessage(hwndMain, MSG_SERIAL_RECV, 0, 0);
            }

            return 0;
        }

        private void SendTextSerial()
        {
            string text_content = txtSend.Text;
            char[] txt_buf = text_content.ToCharArray();
            int send_len = text_content.Length * 2;

            GCHandle hObject = GCHandle.Alloc(txt_buf, GCHandleType.Pinned);
            IntPtr pObject = hObject.AddrOfPinnedObject();

            VzClientSDK.VzLPRClient_SerialSend(serial_handle_, pObject, send_len);

            if (hObject.IsAllocated)
                hObject.Free();
        }

        private void SendHexSerial()
        {
            const int max_send_size = 1024;
            byte[] send_buf = new byte[max_send_size];

            string text_content = txtSend.Text;
            string new_content = text_content.Insert(text_content.Length, " ");
            int txt_len = new_content.Length;
            char[] txt_buf = new_content.ToCharArray();

            int index = 0;

            char[] strHex = new char[3];
            byte uc;
            for (int i = 0; i < txt_len - 2; i += 3)
            {
                if (txt_buf[i + 2] != ' ')
                {
                    MessageBox.Show("16 进制数据输入格式不正确");
                    return;
                }

                strHex[0] = txt_buf[i];
                strHex[1] = txt_buf[i + 1];
                strHex[2] = (char)0;

                for (int j = 0; j < 2; j++)
                {
                    if (strHex[j] < '0' || (strHex[j] > '9' && strHex[j] < 'A') || (strHex[j] > 'F' &&
                        strHex[j] < 'a') || strHex[j] > 'f')
                    {
                        MessageBox.Show("16 进制数据输入格式不正确");
                        return;
                    }
                }

                string hex_value = new string(strHex);
                uc = byte.Parse(hex_value, System.Globalization.NumberStyles.HexNumber);
                send_buf[index] = uc;
                index++;
            }

            GCHandle hObject = GCHandle.Alloc(send_buf, GCHandleType.Pinned);
            IntPtr pObject = hObject.AddrOfPinnedObject();

            VzClientSDK.VzLPRClient_SerialSend(serial_handle_, pObject, index);

            if (hObject.IsAllocated)
                hObject.Free();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (serial_handle_ != IntPtr.Zero)
            {
                if (chkSendHex.Checked)
                {
                    SendHexSerial();
                }
                else
                {
                    SendTextSerial();
                }

            }
            else
            {
                MessageBox.Show("请先打开串口通道!");
            }
        }

        private void SerialControl_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serial_handle_ != IntPtr.Zero)
            {
                int ret = VzClientSDK.VzLPRClient_SerialStop(serial_handle_);
                if (ret == 0)
                {
                    serial_handle_ = IntPtr.Zero;
                }
            }
        }

        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case MSG_SERIAL_RECV:
                    ShowSerialData();
                    break;

                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }


        private void btnClean_Click(object sender, EventArgs e)
        {
            size_serial_recv_ = 0;
            txtRecv.Text = "";
        }

        private void chkBoxHex_Click(object sender, EventArgs e)
        {
            ShowSerialData();
        }
    }
}
