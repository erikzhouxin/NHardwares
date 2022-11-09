using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace VzClientSDKDemo
{
    public partial class Form1 : Form
    {
        private int m_hLPRClient    = 0;
        private int m_nPlayHandle   = 0;

        private VzClientSDK.VZLPRC_PLATE_INFO_CALLBACK m_PlateResultCB = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            VzClientSDK.VzLPRClient_Setup();

            txtPicPath.Text = "D:\\";
            checkBox1.Checked = true;

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            short nPort = Int16.Parse(txtPort.Text);

            if (m_hLPRClient > 0)
            {
                MessageBox.Show("当前窗口已打开设备！");
                return;
            }
            
            m_hLPRClient = VzClientSDK.VzLPRClient_Open(txtIP.Text, (ushort)nPort, txtUserName.Text, txtPwd.Text);
            if (m_hLPRClient == 0)
            {
                MessageBox.Show("打开设备失败！");
                return;
            }

            m_nPlayHandle = VzClientSDK.VzLPRClient_StartRealPlay(m_hLPRClient, pictureBox1.Handle);

            // 设置车牌识别结果回调
            m_PlateResultCB = new VzClientSDK.VZLPRC_PLATE_INFO_CALLBACK(OnPlateResult);
            // int iEnableImage = Convert.ToInt32(checkBox1.Checked);
            VzClientSDK.VzLPRClient_SetPlateInfoCallBack(m_hLPRClient, m_PlateResultCB, IntPtr.Zero, 1);
        }

        private int OnPlateResult(int handle, IntPtr pUserData,
                                                  IntPtr pResult, uint uNumPlates,
                                                  VzClientSDK.VZ_LPRC_RESULT_TYPE eResultType,
                                                  IntPtr pImgFull,
                                                  IntPtr pImgPlateClip)
        {
            VzClientSDK.TH_PlateResult result = (VzClientSDK.TH_PlateResult)Marshal.PtrToStructure(pResult, typeof(VzClientSDK.TH_PlateResult));
            if (eResultType != VzClientSDK.VZ_LPRC_RESULT_TYPE.VZ_LPRC_RESULT_REALTIME)
            {
                if( eResultType == VzClientSDK.VZ_LPRC_RESULT_TYPE.VZ_LPRC_RESULT_VLOOP_TRIGGER)
                {
                   
                }

                string strLicense = new string(result.license);
                ShowPlateResult(strLicense);

                bool bSavePic = checkBox1.Checked;
                if ( bSavePic )
                {
                    DateTime now = DateTime.Now;
                    string sTime = string.Format("{0:yyyyMMddHHmmssffff}", now); 
                    string path = txtPicPath.Text + sTime + ".jpg";

                    int ret = VzClientSDK.VzLPRClient_ImageSaveToJpeg(pImgFull, path, 100);

                    ShowPicResult(path);
                }
            }

            return 0;
        }

        private delegate void ShowResultCrossThread( );
        //触发结果显示
        public void ShowPlateResult(string license)
        {
            ShowResultCrossThread crossDelegate = delegate()
            {
                lblPlate.Text = license;
            };
            lblPlate.Invoke(crossDelegate);
        }

        private delegate void ShowResultPicThread();
        //触发结果显示
        public void ShowPicResult(string path)
        {
            ShowResultPicThread picDelegate = delegate()
            {
                pictureBox2.Image = Image.FromFile(path);
            };
            pictureBox2.Invoke(picDelegate);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            VzClientSDK.VzLPRClient_Cleanup();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if ( m_hLPRClient > 0 )
            {
                if (m_nPlayHandle > 0)
                {
                    int ret = VzClientSDK.VzLPRClient_StopRealPlay( m_nPlayHandle );
                    m_nPlayHandle = -1;
                }

                pictureBox1.Refresh( );

                VzClientSDK.VzLPRClient_Close(m_hLPRClient);
                m_hLPRClient = 0;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog(); 
            dialog.Description = "请选择存放车牌截图的文件夹"; 
            if (dialog.ShowDialog() == DialogResult.OK) 
            { 
                string foldPath = dialog.SelectedPath;
                txtPicPath.Text = foldPath;
            }
        }

        // 发送485数据
        private void btnSend_Click(object sender, EventArgs e)
        {
            if( m_hLPRClient > 0 )
            {
                // 开始485通道
                VzClientSDK.VZDEV_SERIAL_RECV_DATA_CALLBACK serialRECV = null;
                int nSerialHandle = VzClientSDK.VzLPRClient_SerialStart(m_hLPRClient, 0, serialRECV, IntPtr.Zero);
                if ( nSerialHandle > 0 )
                {
                    byte[] test = new byte[100];
                    GCHandle hObject = GCHandle.Alloc(test, GCHandleType.Pinned);
                    IntPtr pObject = hObject.AddrOfPinnedObject();

                    test[0] = 10;
                    test[1] = 20;
                    test[3] = 5;

                    // 发送485数据
                    int ret = VzClientSDK.VzLPRClient_SerialSend(nSerialHandle, pObject, 100);

                    if (hObject.IsAllocated)
                        hObject.Free();

                    // 停止485通道
                    VzClientSDK.VzLPRClient_SerialStop(nSerialHandle);
                    nSerialHandle = 0;
                }
            }
        }

        private void btnSerial_Click(object sender, EventArgs e)
        {
            // 获取设备的序列号
            if( m_hLPRClient > 0 )
            {
                int size=Marshal.SizeOf(typeof(VzClientSDK.VZ_DEV_SERIAL_NUM));
                IntPtr pBuff = Marshal.AllocHGlobal(size);

                VzClientSDK.VzLPRClient_GetSerialNumber(m_hLPRClient, pBuff);

                VzClientSDK.VZ_DEV_SERIAL_NUM vzDevSerialNum = (VzClientSDK.VZ_DEV_SERIAL_NUM)Marshal.PtrToStructure(pBuff, typeof(VzClientSDK.VZ_DEV_SERIAL_NUM));
                Marshal.FreeHGlobal(pBuff);
            }
           
        }

        // 手动触发识别
        private void btnManual_Click(object sender, EventArgs e)
        {
            if ( m_hLPRClient > 0 )
            {
                VzClientSDK.VzLPRClient_ForceTrigger(m_hLPRClient);
            }
        }

        // 抓图功能
        private void btnCap_Click(object sender, EventArgs e)
        {
            if ( m_nPlayHandle > 0 )
            {
                VzClientSDK.VzLPRClient_GetSnapShootToJpeg2( m_nPlayHandle, "D:\\test_1.jpg", 90);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( m_hLPRClient > 0 )
            {
                VzClientSDK.VzLPRClient_SetIOOutput(m_hLPRClient, 0, 1);
                Thread.Sleep(300);
                VzClientSDK.VzLPRClient_SetIOOutput(m_hLPRClient, 0, 0);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] test = new byte[1];
            GCHandle hObject = GCHandle.Alloc(test, GCHandleType.Pinned);
            IntPtr pObject = hObject.AddrOfPinnedObject();

            int ret = VzClientSDK.VzLPRClient_GetGPIOValue(m_hLPRClient, 0, pObject);

            if (hObject.IsAllocated)
                hObject.Free();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 fm2 = new Form2();
            fm2.Show();
        }

        private void textid_TextChanged(object sender, EventArgs e)
        {

        }

        private void btdown_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(textid.Text);
            
            int[] picsize = new int[1];
            picsize[0] = 1024 * 1024;
            GCHandle hObjectsize = GCHandle.Alloc(picsize, GCHandleType.Pinned);
            IntPtr pObjectsize = hObjectsize.AddrOfPinnedObject();

            byte[] picdata = new byte[1024 * 1024];
            GCHandle hObject = GCHandle.Alloc(picdata, GCHandleType.Pinned);
            IntPtr pObject = hObject.AddrOfPinnedObject();
            int ret = VzClientSDK.VzLPRClient_LoadImageById(m_hLPRClient, id, pObject, pObjectsize);

            if (ret == 0 && picsize[0] > 0 && picsize[0] < 1024 * 1024)
            {
                string path = txtPicPath.Text.ToString() + textid.Text.ToString() + ".jpg";
                FileStream aFile = new FileStream(path, FileMode.Create);
                // Move file pointer to beginning of file.
                aFile.Seek(0, SeekOrigin.Begin);
                aFile.Write(picdata, 0, picdata.Length);
                aFile.Close();
                MessageBox.Show("下载成功!");
            }
            else{
                MessageBox.Show("下载失败!");
            }
            if (hObjectsize.IsAllocated)
                hObjectsize.Free();
            if (hObject.IsAllocated)
                hObject.Free();
        }

        private void listbt_Click(object sender, EventArgs e)
        {
            Form2 listform = new Form2();
            listform.StartPosition = FormStartPosition.CenterScreen;
            listform.Show();
            listform.Setm_hLPRClient(m_hLPRClient);
        }
    }
}
