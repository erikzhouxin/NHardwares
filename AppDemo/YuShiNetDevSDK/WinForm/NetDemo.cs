using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Threading;
using GeneralDef;
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Data.YuShiNetDevSDK;

namespace YuShiNetDevSDK.WinForm
{
    public partial class NetDemo : Form
    {
        static INetDevSdkProxy NETDEVSDK = NetDevSdk.Create();
        /******************* Define member variables start *******************************/

        PlayPanel[] arrayRealPanel = new PlayPanel[NetDevSdk.REAL_PANEL_MAX_SIZE];

        static readonly object locker = new object();
        private List<NETDEMO_DeviceInfo> m_deviceInfoList = new List<NETDEMO_DeviceInfo>();

        static readonly object m_notLoggeddeviceInfoListlocker = new object();
        private List<NETDEMO_DeviceInfo> m_notLoggeddeviceInfoList = new List<NETDEMO_DeviceInfo>();

        PlayPanel m_curRealPanel;
        IntPtr m_lpNoPreviewRealPlayHandle = IntPtr.Zero;
        IntPtr m_lpNoPreviewTalkHandle = IntPtr.Zero;

        PlayPanel m_mourseRightSelectedPanel;/*panel*/
        TreeNode m_mourseRightDeviceNode = null;

        public NETDEMO_TreeNodeInfo m_CurSelectTreeNodeInfo = new NETDEMO_TreeNodeInfo();

        Int32 m_curRealPanelIndex = 0;


        bool realMaxFlag = false;
        bool playBackMaxFlag = false;


        int m_layoutPanelWidth = 0;
        int m_layoutPanelHeight = 0;

        PTZControl m_oPtzControl = null;
        Discovery objDiscovery = null;


        public PlayPanel[] arrayPlayBackPanel = new PlayPanel[NetDevSdk.PLAYBACK_PANEL_MAX_SIZE];

        public PlayPanel m_curPlayBackPanel;
        NETDEMO_PlayBackInfo m_playBackInfo = new NETDEMO_PlayBackInfo();
        List<NETDEMO_UPDATE_TIME_INFO> m_downloadInfoList = new List<NETDEMO_UPDATE_TIME_INFO>();
        DownloadInfo m_downloadInfo = new DownloadInfo();

        public PlayPanel m_curFaceRecognitionRealPlayPanel;
        public PlayPanel m_curLPRRealPlayPanel;

        string m_strfacePicPath = "";
        Dictionary<UInt32, NETDEV_LIB_INFO_S> mapPersonLib = new Dictionary<UInt32, NETDEV_LIB_INFO_S>();
        Dictionary<UInt32, NETDEV_PERSON_INFO_S> m_faceLibMemberInfoList = new Dictionary<UInt32, NETDEV_PERSON_INFO_S>();
        Dictionary<UInt32, NETDEV_MONITION_INFO_S> m_faceMonitorTaskList = new Dictionary<UInt32, NETDEV_MONITION_INFO_S>();
        UInt32 m_dwFindFaceLibMemberOffset = 0;
        UInt32 m_dwFindFaceAlarmRecordOffset = 0;
        UInt32 m_dwFindFacePassThruRecordOffset = 0;

        Dictionary<UInt32, NETDEV_LIB_INFO_S> m_vehicleLibInfoList = new Dictionary<UInt32, NETDEV_LIB_INFO_S>();
        Dictionary<UInt32, NETDEV_VEHICLE_DETAIL_INFO_S> m_vehicleLibMemberInfoList = new Dictionary<UInt32, NETDEV_VEHICLE_DETAIL_INFO_S>();
        Dictionary<UInt32, NETDEV_MONITION_INFO_S> m_vehicleMonitorTaskList = new Dictionary<UInt32, NETDEV_MONITION_INFO_S>();
        UInt32 m_dwFindVehicleLibMemberOffset = 0;
        UInt32 m_dwFindVehicleAlarmRecordOffset = 0;

        public NETDEMO_CycleMonitorInfo m_cycleMonitorInfo = null;
        private Thread m_cycleMonitorThread = null;
        private Thread m_keepAliveDeviceThread = null;

        /*callback function*/
        NETDEV_AlarmMessCallBack_PF alarmCB = null;
        NETDEV_AlarmMessCallBack_PF_V30 alarmCBV30 = null;
        NETDEV_ExceptionCallBack_PF excepCB = null;
        NETDEV_FaceSnapshotCallBack_PF faceSnapCB = null;
        NETDEV_CarPlateCallBack_PF CarPlateCB = null;
        public NETDEV_DISCOVERY_CALLBACK_PF discoveryCB = null;
        NETDEV_PassengerFlowStatisticCallBack_PF passengerCB = null;
        NETDEV_PersonAlarmMessCallBack_PF personAlarmCB = null;
        NETDEV_StructAlarmMessCallBack_PF structAlarmCB = null;
        NETDEV_VehicleAlarmMessCallBack_PF vehicleAlarmCB = null;
        NETDEV_DECODE_VIDEO_DATA_CALLBACK_PF playDecodeVideoCB = null;
        NETDEV_ConflagrationAlarmMessCallBack_PF conflagrationAlarmCB = null;


        Config m_config = null;

        /* privacy Mask Cfg*/
        String strSubItemName = "";
        int iItemIndex = -1;

        public static bool m_getCenterRecord = false;

        /******************* Define member variables end *******************************/

        public NetDemo()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            InitPanel();
            InitNetDemo();
        }

        //init panel
        private void InitPanel()
        {

            for (int i = 0; i < NetDevSdk.REAL_PANEL_MAX_SIZE; i++)
            {
                arrayRealPanel[i] = new PlayPanel();
                arrayRealPanel[i].Padding = new Padding(0);
                arrayRealPanel[i].Margin = new Padding(0);
                arrayRealPanel[i].BackColor = Color.Black;
                arrayRealPanel[i].Name = "realPanel " + i.ToString();
                arrayRealPanel[i].setBorderColor(Color.White, 1);
                arrayRealPanel[i].m_panelIndex = i;
                this.LayoutPanel.Controls.Add(arrayRealPanel[i]);
                arrayRealPanel[i].ContextMenuStrip = this.PannelContextMenuStrip;
                arrayRealPanel[i].Click += new EventHandler(realPanel_Click);
                arrayRealPanel[i].DoubleClick += new EventHandler(realPanel_DoubleClick);
                arrayRealPanel[i].MouseDown += new MouseEventHandler(realPanel_MouseDown);
                arrayRealPanel[i].MouseUp += new MouseEventHandler(realPanel_MouseUp);
                arrayRealPanel[i].MouseMove += new MouseEventHandler(realPanel_MouseMove);
            }

            m_curRealPanel = arrayRealPanel[0];
            m_curRealPanel.setBorderColor(Color.Red, 2);
            m_curRealPanel.Invalidate();


            for (int i = 0; i < NetDevSdk.PLAYBACK_PANEL_MAX_SIZE; i++)
            {
                arrayPlayBackPanel[i] = new PlayPanel();
                arrayPlayBackPanel[i].Padding = new Padding(0);
                arrayPlayBackPanel[i].Margin = new Padding(0);
                arrayPlayBackPanel[i].BackColor = Color.Black;
                arrayPlayBackPanel[i].Name = "playBackPanel " + i.ToString();
                arrayPlayBackPanel[i].m_panelIndex = i;
                arrayPlayBackPanel[i].setBorderColor(Color.White, 1);
                this.playBackLayoutPanel.Controls.Add(arrayPlayBackPanel[i]);
                arrayPlayBackPanel[i].Click += new EventHandler(playBackPanel_Click);
                arrayPlayBackPanel[i].DoubleClick += new EventHandler(playBackPanel_DoubleClick);
            }

            int nSqrt = (int)Math.Sqrt(NetDevSdk.PLAYBACK_PANEL_MAX_SIZE);
            int nHeight = this.playBackLayoutPanel.Height / nSqrt - 5;
            int nWidth = this.playBackLayoutPanel.Width / nSqrt - 5;
            for (int i = 0; i < NetDevSdk.PLAYBACK_PANEL_MAX_SIZE; i++)
            {
                arrayPlayBackPanel[i].Height = nHeight;
                arrayPlayBackPanel[i].Width = nWidth;
                this.playBackLayoutPanel.Controls.Add(arrayPlayBackPanel[i]);
            }

            m_curPlayBackPanel = arrayPlayBackPanel[0];
            m_curPlayBackPanel.setBorderColor(Color.Red, 2);
            m_curPlayBackPanel.Invalidate();

            m_curFaceRecognitionRealPlayPanel = new PlayPanel();
            m_curFaceRecognitionRealPlayPanel.Padding = new Padding(0);
            m_curFaceRecognitionRealPlayPanel.Margin = new Padding(0);
            m_curFaceRecognitionRealPlayPanel.BackColor = Color.Black;
            m_curFaceRecognitionRealPlayPanel.Name = "FaceRecognitionRealPlayPanel";
            m_curFaceRecognitionRealPlayPanel.m_panelIndex = 0;
            m_curFaceRecognitionRealPlayPanel.setBorderColor(Color.White, 1);
            m_curFaceRecognitionRealPlayPanel.Height = this.faceRecogRealPlayFLayoutPanel.Height;
            m_curFaceRecognitionRealPlayPanel.Width = this.faceRecogRealPlayFLayoutPanel.Width;
            this.faceRecogRealPlayFLayoutPanel.Controls.Add(m_curFaceRecognitionRealPlayPanel);

            m_curFaceRecognitionRealPlayPanel.Invalidate();

            m_curPlayBackPanel = arrayPlayBackPanel[0];
            m_curPlayBackPanel.setBorderColor(Color.Red, 2);
            m_curPlayBackPanel.Invalidate();

            m_curLPRRealPlayPanel = new PlayPanel();
            m_curLPRRealPlayPanel.Padding = new Padding(0);
            m_curLPRRealPlayPanel.Margin = new Padding(0);
            m_curLPRRealPlayPanel.BackColor = Color.Black;
            m_curLPRRealPlayPanel.Name = "FaceRecognitionRealPlayPanel";
            m_curLPRRealPlayPanel.m_panelIndex = 0;
            m_curLPRRealPlayPanel.setBorderColor(Color.White, 1);
            m_curLPRRealPlayPanel.Height = this.LPRRealPlayFLayoutPanel.Height;
            m_curLPRRealPlayPanel.Width = this.LPRRealPlayFLayoutPanel.Width;
            this.LPRRealPlayFLayoutPanel.Controls.Add(m_curLPRRealPlayPanel);

            m_curLPRRealPlayPanel.Invalidate();
        }

        //inie demo app
        private void InitNetDemo()
        {
            this.DeviceTree.ExpandAll();

            this.comboBoxMultiScreen.SelectedIndex = 3;//16

            BindDataForm();

            int iRet = NETDEVSDK.NETDEV_Init();
            if (NetDevSdk.TRUE != iRet)
            {
                MessageBox.Show("it is not a admin oper");
            }

            m_oPtzControl = new PTZControl();
            m_config = new Config(this);

            alarmCB = new NETDEV_AlarmMessCallBack_PF(alarmMessCallBack);
            alarmCBV30 = new NETDEV_AlarmMessCallBack_PF_V30(alarmMessCallBackV30);
            excepCB = new NETDEV_ExceptionCallBack_PF(exceptionCallBack);
            faceSnapCB = new NETDEV_FaceSnapshotCallBack_PF(FaceSnapshotCallBack);
            CarPlateCB = new NETDEV_CarPlateCallBack_PF(CarPlateCallBack);
            personAlarmCB = new NETDEV_PersonAlarmMessCallBack_PF(PersonAlarmCallBack);
            structAlarmCB = new NETDEV_StructAlarmMessCallBack_PF(StructAlarmCallBack);
            vehicleAlarmCB = new NETDEV_VehicleAlarmMessCallBack_PF(VehicleAlarmCallBack);
            playDecodeVideoCB = new NETDEV_DECODE_VIDEO_DATA_CALLBACK_PF(cbPlayDecodeVideoCALLBACK);
            conflagrationAlarmCB = new NETDEV_ConflagrationAlarmMessCallBack_PF(NETDEV_ConflagrationAlarmMessCallBack);

            NETDEVSDK.NETDEV_SetFaceSnapshotCallBack(IntPtr.Zero, faceSnapCB, IntPtr.Zero);
            NETDEVSDK.NETDEV_SetCarPlateCallBack(IntPtr.Zero, CarPlateCB, IntPtr.Zero);

            setSavePath();
            setSaveKeepLiveTime();
            setSaveTimeOut();
            setSaveOperLog();
            startKeepAliveDeviceThread();
            /* Playback module registration timer handler function */
            m_playBackInfo.m_timer.Elapsed += timer_Elapsed;
        }

        //set save path
        private void setSavePath()
        {
            String m_currentPath = System.Windows.Forms.Application.StartupPath;
            string pictureSavePath = m_currentPath + "\\Pic\\";
            string localRecordPath = m_currentPath + "\\Record\\";
            string logPath = m_currentPath + "\\log\\";

            LocalSetting.setPath(pictureSavePath, localRecordPath, logPath);
        }

        //set save keep live time
        private void setSaveKeepLiveTime()
        {
            Int32 iWaitTime = Convert.ToInt32(15);
            Int32 iTryTime = Convert.ToInt32(3);
            LocalSetting.setKeepLiveTime(iWaitTime, iTryTime);
        }

        //set save Time Out
        private void setSaveTimeOut()
        {
            Int32 iRevTimeOut = Convert.ToInt32(5);
            Int32 iFileReportTimeOut = Convert.ToInt32(60);
            LocalSetting.setTimeOut(iRevTimeOut, iFileReportTimeOut);
        }

        //set save oper log
        private void setSaveOperLog()
        {
            bool bAutoSaveCkBox = true;
            bool bFailureLogCkBox = true;
            bool bSuccessLogCkBox = true;
            LocalSetting.setOperLog(bAutoSaveCkBox, bFailureLogCkBox, bSuccessLogCkBox);
        }

        private void BindDataForm()
        {
            this.LayoutPanel.Controls.Clear();

            string strScreenNumber = this.comboBoxMultiScreen.SelectedItem.ToString();
            int nScreenNumber = int.Parse(strScreenNumber);
            int nSqrt = (int)Math.Sqrt(nScreenNumber);
            int nHeight = this.LayoutPanel.Height / nSqrt - 5;
            int nWidth = this.LayoutPanel.Width / nSqrt - 5;
            for (int i = 0; i < nScreenNumber; i++)
            {
                arrayRealPanel[i].Height = nHeight;
                arrayRealPanel[i].Width = nWidth;
                this.LayoutPanel.Controls.Add(arrayRealPanel[i]);
            }
        }


        //discovery dialog
        private void Discovery_Click(object sender, EventArgs e)
        {
            if (null == objDiscovery)
            {
                objDiscovery = new Discovery(this);
            }

            objDiscovery.ShowDialog();
        }

        // set real panel border color
        private void setRealPanelBorderColor()
        {
            for (int i = 0; i < NetDevSdk.REAL_PANEL_MAX_SIZE; i++)
            {
                arrayRealPanel[i].setBorderColor(Color.White, 1);
                arrayRealPanel[i].Invalidate();
            }
            m_curRealPanel.setBorderColor(Color.Red, 2);
            m_curRealPanel.Invalidate();
        }

        //live view panel
        private void realPanel_Click(object sender, EventArgs e)
        {
            m_curRealPanel = sender as PlayPanel;
            setDeviceTreeSelectNode();

            if (true == m_curRealPanel.m_recordStatus)
            {
                LocalRecodBtn.Text = "Stop";
            }
            else
            {
                LocalRecodBtn.Text = "Record";
            }

            if (true == m_curRealPanel.m_micStatus)
            {
                MicVolumeBtn.BackgroundImage = Properties.Resources.Mic123;
                //MicVolumeBtn.Enabled = true;
                //SliMicVolume.Enabled = true;
                SliMicVolume.Value = m_curRealPanel.m_micVolume;
            }
            else
            {
                MicVolumeBtn.BackgroundImage = Properties.Resources._222;
                //MicVolumeBtn.Enabled = false;
                //SliMicVolume.Enabled = false;
                SliMicVolume.Value = 0;
            }

            if (true == m_curRealPanel.m_soundStatus)
            {
                SoundBtn.BackgroundImage = Properties.Resources.ico00008;
                //SoundBtn.Enabled = true;
                //SliSoundVolume.Enabled = true;
                SliSoundVolume.Value = m_curRealPanel.m_volume;
            }
            else
            {
                SoundBtn.BackgroundImage = Properties.Resources.ico00009;
                //SoundBtn.Enabled = false;
                //SliSoundVolume.Enabled = false;
                SliSoundVolume.Value = 0;
            }

            this.m_curRealPanelIndex = m_curRealPanel.m_panelIndex + 1;
            setRealPanelBorderColor();
            setPTZControlBtnStatus();
        }

        public TreeNode FindNode(TreeNode tnParent, int dwDeviceIndex, int dwID, NETDEMO_FIND_TREE_NODE_TYPE_E dwFindType)
        {
            if (tnParent == null) return null;
            NETDEMO_TreeNodeInfo treeNodeInfo = (NETDEMO_TreeNodeInfo)tnParent.Tag;

            if (NETDEMO_FIND_TREE_NODE_TYPE_E.NETDEMO_FIND_TREE_NODE_CHN_ID == dwFindType)
            {
                if (null != treeNodeInfo && treeNodeInfo.dwDeviceIndex == dwDeviceIndex &&
                treeNodeInfo.dwChannelID == dwID)
                {
                    return tnParent;
                }
            }
            else if (NETDEMO_FIND_TREE_NODE_TYPE_E.NETDEMO_FIND_TREE_NODE_SUB_DEVICE_ID == dwFindType)
            {
                if (null != treeNodeInfo
                    && treeNodeInfo.dwDeviceIndex == dwDeviceIndex
                    && treeNodeInfo.dwSubDeviceID == dwID
                    && (tnParent.ImageIndex == NetDevSdk.NETDEV_TREEVIEW_IMAGE_VMS_SUB_DEVICE_ON || tnParent.ImageIndex == NetDevSdk.NETDEV_TREEVIEW_IMAGE_VMS_SUB_DEVICE_OFF))
                {
                    return tnParent;
                }
            }
            else if (NETDEMO_FIND_TREE_NODE_TYPE_E.NETDEMO_FIND_TREE_NODE_ORG_ID == dwFindType)
            {
                if (null != treeNodeInfo
                    && treeNodeInfo.dwDeviceIndex == dwDeviceIndex
                    && treeNodeInfo.dwOrgID == dwID
                    && tnParent.ImageIndex == NetDevSdk.NETDEV_TREEVIEW_IMAGE_ORG)
                {
                    return tnParent;
                }
            }
            else if (NETDEMO_FIND_TREE_NODE_TYPE_E.NETDEMO_FIND_TREE_NODE_DEVICE_INDEX == dwFindType)
            {
                if (null != treeNodeInfo
                    && treeNodeInfo.dwDeviceIndex == dwDeviceIndex
                    && (tnParent.ImageIndex == NetDevSdk.NETDEV_TREEVIEW_IMAGE_LOCAL_DEVICE_ON
                        || tnParent.ImageIndex == NetDevSdk.NETDEV_TREEVIEW_IMAGE_LOCAL_DEVICE_OFF))
                {
                    return tnParent;
                }
            }

            TreeNode tnRet = null;
            foreach (TreeNode tn in tnParent.Nodes)
            {
                tnRet = FindNode(tn, dwDeviceIndex, dwID, dwFindType);
                if (tnRet != null) break;
            }
            return tnRet;
        }

        public TreeNode TreeViewFindNode(TreeView tv, int dwDeviceIndex, int dwChannelID, NETDEMO_FIND_TREE_NODE_TYPE_E dwFindType)
        {
            TreeNode tnRet = null;
            foreach (TreeNode tn in tv.Nodes)
            {
                tnRet = FindNode(tn, dwDeviceIndex, dwChannelID, dwFindType);
                if (tnRet != null)
                    return tnRet;
            }
            return null;
        }

        private void setDeviceTreeSelectNode()
        {
            if (IntPtr.Zero == m_curRealPanel.m_playhandle)
            {
                DeviceTree.SelectedNode = DeviceTree.Nodes[0];
                if (null != (NETDEMO_TreeNodeInfo)DeviceTree.SelectedNode.Tag)
                {
                    m_CurSelectTreeNodeInfo = (NETDEMO_TreeNodeInfo)DeviceTree.SelectedNode.Tag;
                }
            }
            else
            {
                TreeNode treeNode = TreeViewFindNode(DeviceTree, m_curRealPanel.m_deviceIndex, m_curRealPanel.m_channelID, NETDEMO_FIND_TREE_NODE_TYPE_E.NETDEMO_FIND_TREE_NODE_CHN_ID);
                if (null != treeNode)
                {
                    DeviceTree.SelectedNode = treeNode;
                    if (null != (NETDEMO_TreeNodeInfo)DeviceTree.SelectedNode.Tag)
                    {
                        m_CurSelectTreeNodeInfo = (NETDEMO_TreeNodeInfo)DeviceTree.SelectedNode.Tag;
                    }
                }
            }
        }


        private void switchRealScreen(PlayPanel curSelectedPanel)
        {
            m_curRealPanel = curSelectedPanel;
            this.LayoutPanel.Controls.Clear();
            if (realMaxFlag == true)
            {
                string strScreenNumber = this.comboBoxMultiScreen.SelectedItem.ToString();
                int nScreenNumber = int.Parse(strScreenNumber);
                int nSqrt = (int)Math.Sqrt(nScreenNumber);
                int nHeight = this.LayoutPanel.Height / nSqrt - 6;
                int nWidth = this.LayoutPanel.Width / nSqrt - 6;
                for (int i = 0; i < nScreenNumber; i++)
                {
                    arrayRealPanel[i].Height = nHeight;
                    arrayRealPanel[i].Width = nWidth;
                    this.LayoutPanel.Controls.Add(arrayRealPanel[i]);
                }
                realMaxFlag = false;
            }
            else
            {
                m_curRealPanel.Height = this.LayoutPanel.Height;
                m_curRealPanel.Width = this.LayoutPanel.Width;
                this.LayoutPanel.Controls.Add(m_curRealPanel);
                realMaxFlag = true;
            }
        }


        private void realPanel_DoubleClick(object sender, EventArgs e)
        {

            switchRealScreen(sender as PlayPanel);
            if (MultiScreen.Checked == false)
            {
                MultiScreen.Checked = true;
            }
            else
            {
                MultiScreen.Checked = false;
            }
            setPTZControlBtnStatus();
        }

        private void comboBoxMultiScreen_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDataForm();
        }

        private void LocalDevice_Click(object sender, EventArgs e)
        {
            AddDevice addDevice = new AddDevice(this);
            addDevice.ShowDialog();
        }

        private void DeviceTree_MouseUp(object sender, MouseEventArgs e)
        {
            TreeView oTreeView = sender as TreeView;
            if (null == oTreeView)
            {
                return;
            }
            Point oPoint = oTreeView.PointToClient(Cursor.Position);
            TreeViewHitTestInfo info = oTreeView.HitTest(oPoint.X, oPoint.Y);
            TreeNode oNode = info.Node;// 
            if (null == oNode)
            {
                return;
            }
            if (null == oNode.Parent && MouseButtons.Right == e.Button)
            {
                rootOper.Show(MousePosition);
            }
            else if (oNode.Name == "level2" && MouseButtons.Right == e.Button)
            {
                deviceOper.Show(MousePosition);
            }
        }


        private void DeviceTree_Click(object sender, EventArgs e)
        {
            TreeView oTreeView = sender as TreeView;
            if (null == oTreeView)
            {
                return;
            }
            TreeNode selectedNode = oTreeView.SelectedNode;
            if (null != (NETDEMO_TreeNodeInfo)selectedNode.Tag)
            {
                m_CurSelectTreeNodeInfo = (NETDEMO_TreeNodeInfo)DeviceTree.SelectedNode.Tag;
            }

            if (null == selectedNode
                || selectedNode.ImageIndex == NetDevSdk.NETDEV_TREEVIEW_IMAGE_ROOT
                || selectedNode.ImageIndex == NetDevSdk.NETDEV_TREEVIEW_IMAGE_ORG)
            {
                return;
            }

            if (selectedNode.ImageIndex == NetDevSdk.NETDEV_TREEVIEW_IMAGE_LOCAL_DEVICE_ON ||
                selectedNode.ImageIndex == NetDevSdk.NETDEV_TREEVIEW_IMAGE_LOCAL_DEVICE_OFF)
            {
                /** 2017-09-13  start **/
                if (m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle != IntPtr.Zero)//offline
                {
                    if (this.mainTabCtrl.SelectedTab.Name == "Configure")
                    {
                        m_config.cfgTabSwitch(cfgTabControl.SelectedIndex);
                    }
                }

                /** 2017-09-13  end **/
                return;
            }
            else if (selectedNode.ImageIndex == NetDevSdk.NETDEV_TREEVIEW_IMAGE_CHL_DEVICE_ON ||
                selectedNode.ImageIndex == NetDevSdk.NETDEV_TREEVIEW_IMAGE_CHL_DEVICE_OFF)
            {
                if (m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle != IntPtr.Zero)//offline
                {
                    if (this.mainTabCtrl.SelectedTab.Name == "Configure")
                    {
                        m_config.cfgTabSwitch(cfgTabControl.SelectedIndex);
                    }
                }

                setPTZControlBtnStatus();
            }
        }

        private void DeviceTree_DoubleClick(object sender, EventArgs e)
        {
            TreeView oTreeView = sender as TreeView;
            if (null == oTreeView)
            {
                return;
            }
            TreeNode selectedNode = oTreeView.SelectedNode;
            if (null != (NETDEMO_TreeNodeInfo)selectedNode.Tag)
            {
                m_CurSelectTreeNodeInfo = (NETDEMO_TreeNodeInfo)DeviceTree.SelectedNode.Tag;
            }

            if (null == selectedNode ||
                selectedNode.ImageIndex == NetDevSdk.NETDEV_TREEVIEW_IMAGE_ROOT ||
                selectedNode.ImageIndex == NetDevSdk.NETDEV_TREEVIEW_IMAGE_ORG ||
                selectedNode.ImageIndex == NetDevSdk.NETDEV_TREEVIEW_IMAGE_VMS_SUB_DEVICE_ON ||
                selectedNode.ImageIndex == NetDevSdk.NETDEV_TREEVIEW_IMAGE_VMS_SUB_DEVICE_OFF ||
                selectedNode.ImageIndex == NetDevSdk.NETDEV_TREEVIEW_IMAGE_LOCAL_DEVICE_ON ||
                selectedNode.ImageIndex == NetDevSdk.NETDEV_TREEVIEW_IMAGE_LOCAL_DEVICE_OFF ||
                selectedNode.ImageIndex == NetDevSdk.NETDEV_TREEVIEW_IMAGE_CHL_DEVICE_OFF)
            {
                return;
            }

            if (m_curRealPanel.m_playStatus == false)
            {
                startRealPlay();
            }
            else
            {
                stopRealPlay(m_curRealPanel, true);
                startRealPlay();
            }

            string strScreenNumber = this.comboBoxMultiScreen.SelectedItem.ToString();
            int nScreenNumber = int.Parse(strScreenNumber);

            m_curRealPanelIndex = m_curRealPanel.m_panelIndex + 1;
            if (m_curRealPanelIndex >= nScreenNumber)
            {
                m_curRealPanelIndex = 0;
            }

            m_curRealPanel = arrayRealPanel[m_curRealPanelIndex];
            this.setRealPanelBorderColor();
        }

        private void DeviceTree_MouseDown(object sender, MouseEventArgs e)
        {
            TreeView oTreeView = sender as TreeView;
            if (null == oTreeView)
            {
                return;
            }

            oTreeView.SelectedNode = oTreeView.GetNodeAt(e.X, e.Y);
        }

        private void LayoutPanel_MouseUp(object sender, MouseEventArgs e)
        {
            PanelEx oLayoutPanel = sender as PanelEx;
            if (oLayoutPanel == null)
                return;
            for (int i = 0; i < NetDevSdk.REAL_PANEL_MAX_SIZE; i++)
            {
                arrayRealPanel[i].setBorderColor(Color.White, 1);
                arrayRealPanel[i].Invalidate();
            }
            oLayoutPanel.setBorderColor(Color.Red, 2);
            oLayoutPanel.Invalidate();
        }

        private void MoreBtn_Click(object sender, EventArgs e)
        {
            if (m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_eDeviceType == NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_VMS)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "not support", NetDevSdk.NETDEV_E_NONSUPPORT);
                return;
            }

            if (m_curRealPanel.m_deviceIndex >= m_deviceInfoList.Count || m_curRealPanel.m_deviceIndex < 0)
            {
                return;
            }
            PTZExtend ptzExtend = new PTZExtend(this);
            ptzExtend.Show();
        }

        private void settingLogBtn_Click(object sender, EventArgs e)
        {
            LocalSetting localSetting = new LocalSetting();
            localSetting.ShowDialog();
        }

        private void LocalRecodBtn_Click(object sender, EventArgs e)
        {
            if (m_curRealPanel.m_playStatus == false)
            {
                return;
            }

            if (m_curRealPanel.m_recordStatus == false)
            {
                String temp = string.Copy(LocalSetting.m_strLocalRecordPath);
                DateTime date = DateTime.Now;
                String curTime = date.ToString("yyMMddHHmmss", DateTimeFormatInfo.InvariantInfo);
                LocalSetting.m_strLocalRecordPath += "\\";
                LocalSetting.m_strLocalRecordPath += m_deviceInfoList[m_curRealPanel.m_deviceIndex].m_ip;
                LocalSetting.m_strLocalRecordPath += "_";
                LocalSetting.m_strLocalRecordPath += m_curRealPanel.m_channelID;
                LocalSetting.m_strLocalRecordPath += "_";
                LocalSetting.m_strLocalRecordPath += curTime;

                byte[] localRecordPath;
                GetUTF8Buffer(LocalSetting.m_strLocalRecordPath, NetDevSdk.NETDEV_LEN_260, out localRecordPath);
                int iRet = NETDEVSDK.NETDEV_SaveRealData(m_curRealPanel.m_playhandle, localRecordPath, (int)NETDEV_MEDIA_FILE_FORMAT_E.NETDEV_MEDIA_FILE_MP4);
                if (NetDevSdk.FALSE == iRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "start Record", NETDEVSDK.NETDEV_GetLastError());
                    return;
                }
                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "start Record");

                m_curRealPanel.m_recordStatus = true;
                this.LocalRecodBtn.Text = "Stop";
                LocalSetting.m_strLocalRecordPath = temp;
            }
            else
            {
                int iRet = NETDEVSDK.NETDEV_StopSaveRealData(m_curRealPanel.m_playhandle);
                if (NetDevSdk.FALSE == iRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "stop Record", NETDEVSDK.NETDEV_GetLastError());
                    return;
                }
                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "stop Record");

                m_curRealPanel.m_recordStatus = false;
                this.LocalRecodBtn.Text = "Record";
            }
        }


        private void mainTabCtrlSelectedChanged(object sender, EventArgs e)
        {
            if (this.mainTabCtrl.SelectedTab.Name == "LiveView")
            {
                //initLiveViewPage();
            }
            else if (this.mainTabCtrl.SelectedTab.Name == "Playback")
            {
                //initPlaybackPage();
            }
            else if (this.mainTabCtrl.SelectedTab.Name == "Configure")
            {
                if (m_CurSelectTreeNodeInfo.dwDeviceIndex >= 0 && m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle != IntPtr.Zero)
                {
                    m_config.cfgTabSwitch(0);/*basic0*/
                }
            }
            else if (this.mainTabCtrl.SelectedTab.Name == "AlarmRecords")
            {
                //initAlarmRecordsPage();
            }
            else if (this.mainTabCtrl.SelectedTab.Name == "VCA")
            {
                //initVCAPage();
            }
            else if (this.mainTabCtrl.SelectedTab.Name == "Maintenance")
            {
                //initMaintenancePage();
            }
        }

        private void updateChnTreeNode(TreeNode orgTreeNode, NETDEV_DEV_CHN_ENCODE_INFO_S stChnInfo)
        {
            NETDEMO_TreeNodeInfo treeOrgNodeInfo = (NETDEMO_TreeNodeInfo)orgTreeNode.Tag;

            TreeNode treeNodeChn = null;
            if (-1 != treeOrgNodeInfo.dwChannelID) //已存在
            {
                treeNodeChn = orgTreeNode;
            }
            else
            {
                treeNodeChn = new TreeNode(GetDefaultString(stChnInfo.stChnBaseInfo.szChnName));
            }

            if (NETDEV_CHN_STATUS_E.NETDEV_CHN_STATUS_ONLINE == (NETDEV_CHN_STATUS_E)stChnInfo.stChnBaseInfo.dwChnStatus)
            {
                treeNodeChn.ImageIndex = NetDevSdk.NETDEV_TREEVIEW_IMAGE_CHL_DEVICE_ON;
                treeNodeChn.SelectedImageIndex = NetDevSdk.NETDEV_TREEVIEW_IMAGE_CHL_DEVICE_ON;
            }
            else
            {
                treeNodeChn.ImageIndex = NetDevSdk.NETDEV_TREEVIEW_IMAGE_CHL_DEVICE_OFF;
                treeNodeChn.SelectedImageIndex = NetDevSdk.NETDEV_TREEVIEW_IMAGE_CHL_DEVICE_OFF;
            }

            if (-1 != treeOrgNodeInfo.dwChannelID) //已存在
            {
                Invoke((EventHandler)delegate { orgTreeNode.Text = GetDefaultString(stChnInfo.stChnBaseInfo.szChnName); });
            }
            else
            {
                NETDEMO_TreeNodeInfo treeNodeInfoChn = new NETDEMO_TreeNodeInfo();
                treeNodeInfoChn.dwDeviceIndex = treeOrgNodeInfo.dwDeviceIndex;
                treeNodeInfoChn.dwOrgID = stChnInfo.stChnBaseInfo.dwOrgID;
                treeNodeInfoChn.dwSubDeviceID = stChnInfo.stChnBaseInfo.dwDevID;
                treeNodeInfoChn.dwChannelID = stChnInfo.stChnBaseInfo.dwChannelID;
                treeNodeChn.Tag = treeNodeInfoChn;

                Invoke((EventHandler)delegate { orgTreeNode.Nodes.Add(treeNodeChn); });
            }
        }

        private void updateSubDeviceTreeNode(TreeNode orgTreeNode, NETDEMO_VMS_DEV_BASIC_INFO_S stVmsSubDevInfo)
        {
            NETDEMO_TreeNodeInfo treeOrgNodeInfo = (NETDEMO_TreeNodeInfo)orgTreeNode.Tag;
            TreeNode treeNodeDev = null;
            if (-1 != treeOrgNodeInfo.dwSubDeviceID)//已存在
            {
                treeNodeDev = orgTreeNode;
            }
            else
            {
                treeNodeDev = new TreeNode(GetDefaultString(stVmsSubDevInfo.stDevBasicInfo.szDevName));
                NETDEMO_TreeNodeInfo treeNodeInfo = new NETDEMO_TreeNodeInfo();
                treeNodeInfo.dwDeviceIndex = treeOrgNodeInfo.dwDeviceIndex;
                treeNodeInfo.dwOrgID = stVmsSubDevInfo.stDevBasicInfo.dwOrgID;
                treeNodeInfo.dwSubDeviceID = stVmsSubDevInfo.stDevBasicInfo.dwDevID;
                treeNodeDev.Tag = treeNodeInfo;
            }

            /* 无论是新增还是修改，均删除子设备下所有通道 */
            Invoke((EventHandler)delegate { treeNodeDev.Nodes.Clear(); });

            if (NETDEV_DEVICE_STATUS_E.NETDEV_DEV_STATUS_ONLINE == (NETDEV_DEVICE_STATUS_E)stVmsSubDevInfo.stDevBasicInfo.dwDevStatus)
            {
                treeNodeDev.ImageIndex = NetDevSdk.NETDEV_TREEVIEW_IMAGE_VMS_SUB_DEVICE_ON;
                treeNodeDev.SelectedImageIndex = NetDevSdk.NETDEV_TREEVIEW_IMAGE_VMS_SUB_DEVICE_ON;

                for (int n = 0; n < stVmsSubDevInfo.stChnInfoList.Count; n++)
                {
                    updateChnTreeNode(treeNodeDev, stVmsSubDevInfo.stChnInfoList[n].stChnInfo);
                }
            }
            else
            {
                treeNodeDev.ImageIndex = NetDevSdk.NETDEV_TREEVIEW_IMAGE_VMS_SUB_DEVICE_OFF;
                treeNodeDev.SelectedImageIndex = NetDevSdk.NETDEV_TREEVIEW_IMAGE_VMS_SUB_DEVICE_OFF;
            }

            if (-1 != treeOrgNodeInfo.dwSubDeviceID)//已存在
            {

                Invoke((EventHandler)delegate { treeNodeDev.Text = GetDefaultString(stVmsSubDevInfo.stDevBasicInfo.szDevName); });
            }
            else
            {
                Invoke((EventHandler)delegate { orgTreeNode.Nodes.Add(treeNodeDev); });
            }
        }

        private void deleteDeviceTreeNode(int treeNodeIndex)
        {
            TreeNode treeNode = TreeViewFindNode(DeviceTree, treeNodeIndex, 0, NETDEMO_FIND_TREE_NODE_TYPE_E.NETDEMO_FIND_TREE_NODE_DEVICE_INDEX);
            if (null != treeNode)
            {
                treeNode.Nodes.Clear();

                if (treeNode.ImageIndex == NetDevSdk.NETDEV_TREEVIEW_IMAGE_LOCAL_DEVICE_ON)
                {
                    treeNode.ImageIndex = NetDevSdk.NETDEV_TREEVIEW_IMAGE_LOCAL_DEVICE_OFF;
                    treeNode.SelectedImageIndex = NetDevSdk.NETDEV_TREEVIEW_IMAGE_LOCAL_DEVICE_OFF;
                }
            }
        }

        private void setDeviceTreeNode(TreeNode deviceTreeNode, int DeviceIndex, NETDEMO_DeviceInfo deviceInfoTemp)
        {
            deviceTreeNode.ImageIndex = NetDevSdk.NETDEV_TREEVIEW_IMAGE_LOCAL_DEVICE_ON;
            deviceTreeNode.SelectedImageIndex = NetDevSdk.NETDEV_TREEVIEW_IMAGE_LOCAL_DEVICE_ON;

            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_VMS == deviceInfoTemp.m_eDeviceType)
            {
                TreeNode treeNodeOrgRoot = null;
                TreeNode[] treeNodeOrg = new TreeNode[deviceInfoTemp.stVmsDevInfo.stOrgInfoList.Count];
                for (int i = 0; i < deviceInfoTemp.stVmsDevInfo.stOrgInfoList.Count; i++)
                {
                    treeNodeOrg[i] = new TreeNode(GetDefaultString(deviceInfoTemp.stVmsDevInfo.stOrgInfoList[i].stOrgInfo.szNodeName));
                    treeNodeOrg[i].ImageIndex = NetDevSdk.NETDEV_TREEVIEW_IMAGE_ORG;
                    treeNodeOrg[i].SelectedImageIndex = NetDevSdk.NETDEV_TREEVIEW_IMAGE_ORG;

                    NETDEMO_TreeNodeInfo treeNodeInfo = new NETDEMO_TreeNodeInfo();
                    treeNodeInfo.dwOrgID = deviceInfoTemp.stVmsDevInfo.stOrgInfoList[i].stOrgInfo.dwOrgID;
                    treeNodeInfo.dwDeviceIndex = DeviceIndex;
                    treeNodeOrg[i].Tag = treeNodeInfo;
                }

                for (int i = 0; i < deviceInfoTemp.stVmsDevInfo.stOrgInfoList.Count; i++)
                {
                    for (int j = 0; j < deviceInfoTemp.stVmsDevInfo.stOrgInfoList.Count; j++)
                    {
                        if (deviceInfoTemp.stVmsDevInfo.stOrgInfoList[i].stOrgInfo.dwOrgID == deviceInfoTemp.stVmsDevInfo.stOrgInfoList[j].stOrgInfo.dwParentID)
                        {
                            treeNodeOrg[i].Nodes.Add(treeNodeOrg[j]);
                        }
                    }

                    if (0 == deviceInfoTemp.stVmsDevInfo.stOrgInfoList[i].stOrgInfo.dwParentID)
                    {
                        treeNodeOrgRoot = treeNodeOrg[i];
                    }

                    /* device and channel */
                    for (int k = 0; k < deviceInfoTemp.stVmsDevInfo.stOrgInfoList[i].stVmsDevBasicInfoList.Count; k++)
                    {
                        updateSubDeviceTreeNode(treeNodeOrg[i], deviceInfoTemp.stVmsDevInfo.stOrgInfoList[i].stVmsDevBasicInfoList[k]);
                    }
                }

                Invoke((EventHandler)delegate { deviceTreeNode.Nodes.Add(treeNodeOrgRoot); });
            }
            else
            {
                for (int i = 0; i < deviceInfoTemp.m_channelNumber; i++)
                {

                    TreeNode treeNodeChl = new TreeNode("channel " + Convert.ToString(i + 1));
                    if (deviceInfoTemp.m_channelInfoList[i].m_devVideoChlInfo.enStatus == (int)NETDEV_CHANNEL_STATUS_E.NETDEV_CHL_STATUS_ONLINE)
                    {
                        treeNodeChl.ImageIndex = NetDevSdk.NETDEV_TREEVIEW_IMAGE_CHL_DEVICE_ON;
                        treeNodeChl.SelectedImageIndex = NetDevSdk.NETDEV_TREEVIEW_IMAGE_CHL_DEVICE_ON;
                    }
                    else
                    {
                        treeNodeChl.ImageIndex = NetDevSdk.NETDEV_TREEVIEW_IMAGE_CHL_DEVICE_OFF;
                        treeNodeChl.SelectedImageIndex = NetDevSdk.NETDEV_TREEVIEW_IMAGE_CHL_DEVICE_OFF;
                    }

                    NETDEMO_TreeNodeInfo treeNodeInfo = new NETDEMO_TreeNodeInfo();
                    treeNodeInfo.dwDeviceIndex = DeviceIndex;
                    treeNodeInfo.dwChannelID = deviceInfoTemp.m_channelInfoList[i].m_devVideoChlInfo.dwChannelID;
                    treeNodeChl.Tag = treeNodeInfo;
                    Invoke((EventHandler)delegate { deviceTreeNode.Nodes.AddRange(new TreeNode[] { treeNodeChl }); });
                }
            }
        }

        //TreeView
        private void setTreeView(NETDEMO_DeviceInfo deviceInfoTemp)
        {
            int DeviceIndex = m_deviceInfoList.Count;
            TreeNode treeNode = null;

            treeNode = new TreeNode(deviceInfoTemp.m_ip);

            treeNode.Name = "level2";
            NETDEMO_TreeNodeInfo treeNodeInfoDevice = new NETDEMO_TreeNodeInfo();
            treeNodeInfoDevice.dwDeviceIndex = DeviceIndex;
            treeNode.Tag = treeNodeInfoDevice;

            setDeviceTreeNode(treeNode, DeviceIndex, deviceInfoTemp);

            if (null == this.DeviceTree.Nodes)
            {
                return;
            }
            Invoke((EventHandler)delegate { this.DeviceTree.Nodes[0].Nodes.Add(treeNode); });
            this.DeviceTree.SelectedNode = DeviceTree.Nodes[0].Nodes[0];//
            m_CurSelectTreeNodeInfo = (NETDEMO_TreeNodeInfo)this.DeviceTree.SelectedNode.Tag;
        }

        //add local device
        public void AddLocalDevice(String ipAddr, Int32 port, String userName, String password, NETDEMO_DEVICE_TYPE_E eDeviceType)
        {
            lock (m_notLoggeddeviceInfoListlocker)
            {
                NETDEMO_DeviceInfo deviceInfoTemp = new NETDEMO_DeviceInfo();
                deviceInfoTemp.m_ip = ipAddr;
                deviceInfoTemp.m_port = port;
                deviceInfoTemp.m_userName = userName;
                deviceInfoTemp.m_password = password;
                deviceInfoTemp.m_eDeviceType = eDeviceType;

                m_notLoggeddeviceInfoList.Add(deviceInfoTemp);
            }
        }

        //login local device
        public void LoginLocalDevice(NETDEMO_DeviceInfo deviceInfo)
        {
            NETDEV_LOGIN_TYPE_E loginFlag = NETDEV_LOGIN_TYPE_E.NETDEV_NEW_LOGIN;
            int DeviceNodeIndex = 0;
            for (int i = 0; i < m_deviceInfoList.Count(); i++)
            {
                if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_INVALID == m_deviceInfoList[i].m_eDeviceType)
                {
                    continue;
                }

                if (deviceInfo.m_ip == m_deviceInfoList[i].m_ip
                    && deviceInfo.m_port == m_deviceInfoList[i].m_port
                    && m_deviceInfoList[i].m_lpDevHandle != IntPtr.Zero)
                {
                    MessageBox.Show("The device already exists!");
                    return;
                }

                if (deviceInfo.m_ip == m_deviceInfoList[i].m_ip
                    && deviceInfo.m_port == m_deviceInfoList[i].m_port
                    && m_deviceInfoList[i].m_lpDevHandle == IntPtr.Zero)//again login
                {
                    loginFlag = NETDEV_LOGIN_TYPE_E.NETDEV_AGAIN_LOGIN;
                    DeviceNodeIndex = i;
                }
            }

            NETDEV_DEVICE_LOGIN_INFO_S pstDevLoginInfo = new NETDEV_DEVICE_LOGIN_INFO_S();
            NETDEV_SELOG_INFO_S pstSELogInfo = new NETDEV_SELOG_INFO_S();
            pstDevLoginInfo.szIPAddr = deviceInfo.m_ip;
            pstDevLoginInfo.dwPort = deviceInfo.m_port;
            pstDevLoginInfo.szUserName = deviceInfo.m_userName;
            pstDevLoginInfo.szPassword = deviceInfo.m_password;
            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_VMS == deviceInfo.m_eDeviceType)
            {
                pstDevLoginInfo.dwLoginProto = (int)NETDEV_LOGIN_PROTO_E.NETDEV_LOGIN_PROTO_PRIVATE;
            }
            else
            {
                pstDevLoginInfo.dwLoginProto = (int)NETDEV_LOGIN_PROTO_E.NETDEV_LOGIN_PROTO_ONVIF;
            }

            IntPtr lpDevHandle = NETDEVSDK.NETDEV_Login_V30(ref pstDevLoginInfo, ref pstSELogInfo);

            if (lpDevHandle == IntPtr.Zero)
            {
                showFailLogInfo(deviceInfo.m_ip + " : " + deviceInfo.m_port, "login", NETDEVSDK.NETDEV_GetLastError());
                return;
            }

            if (loginFlag == NETDEV_LOGIN_TYPE_E.NETDEV_AGAIN_LOGIN)
            {
                m_deviceInfoList[DeviceNodeIndex].m_lpDevHandle = lpDevHandle;
            }
            showSuccessLogInfo(deviceInfo.m_ip + " : " + deviceInfo.m_port, "login");

            NETDEMO_DeviceInfo deviceInfoTemp = new NETDEMO_DeviceInfo();
            deviceInfoTemp.m_lpDevHandle = lpDevHandle;
            deviceInfoTemp.m_ip = deviceInfo.m_ip;
            deviceInfoTemp.m_port = deviceInfo.m_port;
            deviceInfoTemp.m_userName = deviceInfo.m_userName;
            deviceInfoTemp.m_password = deviceInfo.m_password;
            deviceInfoTemp.m_eDeviceType = deviceInfo.m_eDeviceType;
            int iRet = 0;
            //get the channel list
            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_VMS == deviceInfo.m_eDeviceType)
            {
                deviceInfoTemp.stVmsDevInfo = new NETDEMO_VMS_DEVICE_INFO_S();

                NETDEV_ORG_FIND_COND_S stFindCond = new NETDEV_ORG_FIND_COND_S();
                stFindCond.udwRootOrgID = 0;
                IntPtr lpFindOrgHandle = NETDEVSDK.NETDEV_FindOrgInfoList(lpDevHandle, ref stFindCond);
                if (IntPtr.Zero == lpFindOrgHandle)
                {
                    showFailLogInfo(deviceInfo.m_ip + " : " + deviceInfo.m_port, "find org list", NETDEVSDK.NETDEV_GetLastError());
                    return;
                }

                while (true)
                {
                    NETDEMO_VMS_ORG_INFO_S stDemoOrgInfo = new NETDEMO_VMS_ORG_INFO_S();
                    NETDEV_ORG_INFO_S stOrgInfo = new NETDEV_ORG_INFO_S();
                    iRet = NETDEVSDK.NETDEV_FindNextOrgInfo(lpFindOrgHandle, ref stOrgInfo);
                    if (NetDevSdk.FALSE == iRet)
                    {
                        break;
                    }

                    stDemoOrgInfo.stOrgInfo = stOrgInfo;
                    deviceInfoTemp.stVmsDevInfo.stOrgInfoList.Add(stDemoOrgInfo);
                }

                NETDEVSDK.NETDEV_FindCloseOrgInfo(lpFindOrgHandle);

                for (int i = 0; i < NetDevSdk.gaENETDemoVMSMainDevType.Length; i++)
                {
                    IntPtr lpFindDevHandle = NETDEVSDK.NETDEV_FindDevList(lpDevHandle, (int)NetDevSdk.gaENETDemoVMSMainDevType[i]);
                    if (IntPtr.Zero == lpFindDevHandle)
                    {
                        showFailLogInfo(deviceInfo.m_ip + " : " + deviceInfo.m_port, "NETDEV_FindDevList", NETDEVSDK.NETDEV_GetLastError());
                        //return;
                    }

                    while (true)
                    {
                        NETDEMO_VMS_DEV_BASIC_INFO_S stDemoVmsBasicInfo = new NETDEMO_VMS_DEV_BASIC_INFO_S();

                        NETDEV_DEV_BASIC_INFO_S pstDevBasicInfo = new NETDEV_DEV_BASIC_INFO_S();
                        iRet = NETDEVSDK.NETDEV_FindNextDevInfo(lpFindDevHandle, ref pstDevBasicInfo);
                        if (NetDevSdk.FALSE == iRet)
                        {
                            break;
                        }

                        stDemoVmsBasicInfo.stDevBasicInfo = pstDevBasicInfo;
                        int dwChlType = (int)NETDEV_CHN_TYPE_E.NETDEV_CHN_TYPE_ENCODE;
                        IntPtr lpFindDevChnHandle = NETDEVSDK.NETDEV_FindDevChnList(lpDevHandle, pstDevBasicInfo.dwDevID, dwChlType);
                        if (IntPtr.Zero == lpFindDevChnHandle)
                        {
                            showFailLogInfo(deviceInfo.m_ip + " : " + deviceInfo.m_port, "NETDEV_FindDevChnList", NETDEVSDK.NETDEV_GetLastError());
                            break;
                        }

                        while (true)
                        {
                            NETDEMO_VMS_DEV_CHANNEL_INFO_S stDemoVmsChnInfo = new NETDEMO_VMS_DEV_CHANNEL_INFO_S();

                            int pdwBytesReturned = 0;
                            NETDEV_DEV_CHN_ENCODE_INFO_S stDevChnInfo = new NETDEV_DEV_CHN_ENCODE_INFO_S();
                            IntPtr lpOutBuffer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETDEV_DEV_CHN_ENCODE_INFO_S)));
                            Marshal.StructureToPtr(stDevChnInfo, lpOutBuffer, true);
                            iRet = NETDEVSDK.NETDEV_FindNextDevChn(lpFindDevChnHandle, lpOutBuffer, Marshal.SizeOf(typeof(NETDEV_DEV_CHN_ENCODE_INFO_S)), ref pdwBytesReturned);
                            if (NetDevSdk.FALSE == iRet)
                            {
                                Marshal.FreeHGlobal(lpOutBuffer);
                                break;
                            }
                            else
                            {
                                stDevChnInfo = (NETDEV_DEV_CHN_ENCODE_INFO_S)Marshal.PtrToStructure(lpOutBuffer, typeof(NETDEV_DEV_CHN_ENCODE_INFO_S));
                                stDemoVmsChnInfo.stChnInfo = stDevChnInfo;
                                stDemoVmsBasicInfo.stChnInfoList.Add(stDemoVmsChnInfo);

                                Marshal.FreeHGlobal(lpOutBuffer);
                            }


                        }

                        NETDEVSDK.NETDEV_FindCloseDevChn(lpFindDevChnHandle);

                        for (int k = 0; k < deviceInfoTemp.stVmsDevInfo.stOrgInfoList.Count; k++)
                        {
                            if (stDemoVmsBasicInfo.stDevBasicInfo.dwOrgID == deviceInfoTemp.stVmsDevInfo.stOrgInfoList[k].stOrgInfo.dwOrgID)
                            {
                                deviceInfoTemp.stVmsDevInfo.stOrgInfoList[k].stVmsDevBasicInfoList.Add(stDemoVmsBasicInfo);
                            }
                        }
                    }

                    NETDEVSDK.NETDEV_FindCloseDevInfo(lpFindDevHandle);
                }

                if (loginFlag == NETDEV_LOGIN_TYPE_E.NETDEV_AGAIN_LOGIN)//again login
                {
                    m_deviceInfoList[DeviceNodeIndex] = deviceInfoTemp;
                    TreeNode treeNode = TreeViewFindNode(DeviceTree, DeviceNodeIndex, 0, NETDEMO_FIND_TREE_NODE_TYPE_E.NETDEMO_FIND_TREE_NODE_DEVICE_INDEX);
                    if (null != treeNode)
                    {
                        setDeviceTreeNode(treeNode, DeviceNodeIndex, deviceInfoTemp);
                        //updatedeviceTreeStatus(DeviceNodeIndex);

                        for (int j = 0; j < deviceInfo.m_RealPlayInfoList.Count; j++)
                        {
                            m_CurSelectTreeNodeInfo = new NETDEMO_TreeNodeInfo();
                            m_CurSelectTreeNodeInfo.dwDeviceIndex = DeviceNodeIndex;
                            m_CurSelectTreeNodeInfo.dwChannelID = deviceInfo.m_RealPlayInfoList[j].m_channel;
                            m_curRealPanel = arrayRealPanel[deviceInfo.m_RealPlayInfoList[j].m_panelIndex];
                            startRealPlay();
                        }
                    }
                }
                else
                {
                    setTreeView(deviceInfoTemp);
                    m_deviceInfoList.Add(deviceInfoTemp);
                }
            }
            else
            {
                int pdwChlCount = 256;
                IntPtr pstVideoChlList = new IntPtr();
                //pstVideoChlList = Marshal.AllocHGlobal(NETDEVSDK.NETDEV_LEN_32 * Marshal.SizeOf(typeof(NETDEV_VIDEO_CHL_DETAIL_INFO_S)));
                pstVideoChlList = Marshal.AllocHGlobal(256 * Marshal.SizeOf(typeof(NETDEV_VIDEO_CHL_DETAIL_INFO_S)));
                iRet = NETDEVSDK.NETDEV_QueryVideoChlDetailList(deviceInfoTemp.m_lpDevHandle, ref pdwChlCount, pstVideoChlList);
                if (NetDevSdk.TRUE == iRet)
                {
                    deviceInfoTemp.m_channelNumber = pdwChlCount;
                    NETDEV_VIDEO_CHL_DETAIL_INFO_S stCHLItem = new NETDEV_VIDEO_CHL_DETAIL_INFO_S();
                    for (int i = 0; i < pdwChlCount; i++)
                    {
                        IntPtr ptrTemp = new IntPtr(pstVideoChlList.ToInt64() + Marshal.SizeOf(typeof(NETDEV_VIDEO_CHL_DETAIL_INFO_S)) * i);
                        stCHLItem = (NETDEV_VIDEO_CHL_DETAIL_INFO_S)Marshal.PtrToStructure(ptrTemp, typeof(NETDEV_VIDEO_CHL_DETAIL_INFO_S));

                        NETDEMO_ChannelInfo channelInfo = new NETDEMO_ChannelInfo();
                        channelInfo.m_devVideoChlInfo = stCHLItem;
                        deviceInfoTemp.m_channelInfoList.Add(channelInfo);
                    }
                    if (loginFlag == NETDEV_LOGIN_TYPE_E.NETDEV_AGAIN_LOGIN)//again login
                    {
                        m_deviceInfoList[DeviceNodeIndex] = deviceInfoTemp;
                        TreeNode treeNode = TreeViewFindNode(DeviceTree, DeviceNodeIndex, 0, NETDEMO_FIND_TREE_NODE_TYPE_E.NETDEMO_FIND_TREE_NODE_DEVICE_INDEX);
                        if (null != treeNode)
                        {
                            setDeviceTreeNode(treeNode, DeviceNodeIndex, deviceInfoTemp);
                            //updatedeviceTreeStatus(DeviceNodeIndex);

                            for (int j = 0; j < deviceInfo.m_RealPlayInfoList.Count; j++)
                            {
                                m_CurSelectTreeNodeInfo = new NETDEMO_TreeNodeInfo();
                                m_CurSelectTreeNodeInfo.dwDeviceIndex = DeviceNodeIndex;
                                m_CurSelectTreeNodeInfo.dwChannelID = deviceInfo.m_RealPlayInfoList[j].m_channel;
                                m_curRealPanel = arrayRealPanel[deviceInfo.m_RealPlayInfoList[j].m_panelIndex];
                                startRealPlay();
                            }
                        }
                    }
                    else
                    {
                        setTreeView(deviceInfoTemp);
                        m_deviceInfoList.Add(deviceInfoTemp);
                    }
                }
                Marshal.FreeHGlobal(pstVideoChlList);

                NETDEV_DEVICE_INFO_S pstDevInfo = new NETDEV_DEVICE_INFO_S();
                NETDEVSDK.NETDEV_GetDeviceInfo(deviceInfoTemp.m_lpDevHandle, ref pstDevInfo);
                deviceInfoTemp.m_stDevInfo = pstDevInfo;
            }

            //set alarm exception callback
            iRet = NETDEVSDK.NETDEV_SetAlarmCallBack_V30(deviceInfoTemp.m_lpDevHandle, alarmCBV30, IntPtr.Zero);
            if (NetDevSdk.FALSE == iRet)
            {
                showFailLogInfo(deviceInfo.m_ip + " : " + deviceInfo.m_port, "register AlarmCallBack", NETDEVSDK.NETDEV_GetLastError());
            }
            else
            {
                showSuccessLogInfo(deviceInfo.m_ip + " : " + deviceInfo.m_port, "register AlarmCallBack");
            }

            iRet = NETDEVSDK.NETDEV_SetConflagrationAlarmCallBack(deviceInfoTemp.m_lpDevHandle, conflagrationAlarmCB, deviceInfoTemp.m_lpDevHandle);
            if (NetDevSdk.FALSE == iRet)
            {
                showFailLogInfo(deviceInfo.m_ip + " : " + deviceInfo.m_port, "register ConflagrationAlarm", NETDEVSDK.NETDEV_GetLastError());
            }
            else
            {
                showSuccessLogInfo(deviceInfo.m_ip + " : " + deviceInfo.m_port, "register ConflagrationAlarm");
            }


            iRet = NETDEVSDK.NETDEV_SetExceptionCallBack(excepCB, IntPtr.Zero);
            if (NetDevSdk.FALSE == iRet)
            {
                showFailLogInfo(deviceInfo.m_ip + " : " + deviceInfo.m_port, "register ExceptionCallBack", NETDEVSDK.NETDEV_GetLastError());
            }
            else
            {
                showSuccessLogInfo(deviceInfo.m_ip + " : " + deviceInfo.m_port, "register ExceptionCallBack");
            }
        }

        /************************realPlay control start ************************************/
        //realplay
        private void RealPlay_Click(object sender, EventArgs e)
        {
            if (DeviceTree.SelectedNode == null)
            {
                return;
            }
            if (DeviceTree.SelectedNode.ImageIndex != NetDevSdk.NETDEV_TREEVIEW_IMAGE_CHL_DEVICE_ON)
            {
                return;
            }
            if (m_curRealPanel.m_playStatus == false)
            {
                startRealPlay();
            }
            else
            {
                stopRealPlay(m_curRealPanel, true);
                startRealPlay();
            }
        }

        private void Sequence_Click(object sender, EventArgs e)
        {
            CycleMonitor cycleMonitor = new CycleMonitor(this);
            cycleMonitor.ShowDialog();
        }

        public int getChannelID()
        {
            return m_CurSelectTreeNodeInfo.dwChannelID;
        }

        public int getDeviceIndex()
        {
            return m_CurSelectTreeNodeInfo.dwDeviceIndex;
        }

        public int getOrgIndexByID(Int32 dwDeviceIndex, Int32 dwOrgID)
        {
            if (-1 == dwDeviceIndex)
            {
                return -1;
            }

            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_VMS == m_deviceInfoList[dwDeviceIndex].m_eDeviceType)
            {
                for (int i = 0; i < m_deviceInfoList[dwDeviceIndex].stVmsDevInfo.stOrgInfoList.Count; i++)
                {
                    if (dwOrgID == m_deviceInfoList[dwDeviceIndex].stVmsDevInfo.stOrgInfoList[i].stOrgInfo.dwOrgID)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        public int getOrgIndex()
        {
            if (-1 == m_CurSelectTreeNodeInfo.dwDeviceIndex ||
                m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle == IntPtr.Zero)
            {
                return -1;
            }

            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_VMS == m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_eDeviceType)
            {
                for (int i = 0; i < m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].stVmsDevInfo.stOrgInfoList.Count; i++)
                {
                    if (m_CurSelectTreeNodeInfo.dwOrgID == m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].stVmsDevInfo.stOrgInfoList[i].stOrgInfo.dwOrgID)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        public int getSubDeviceIndexByID(Int32 dwDeviceIndex, Int32 dwOrgIndex, Int32 dwSubDevID)
        {
            if (-1 != dwOrgIndex)
            {
                for (int i = 0; i < m_deviceInfoList[dwDeviceIndex].stVmsDevInfo.stOrgInfoList[dwOrgIndex].stVmsDevBasicInfoList.Count; i++)
                {
                    if (dwSubDevID == m_deviceInfoList[dwDeviceIndex].stVmsDevInfo.stOrgInfoList[dwOrgIndex].stVmsDevBasicInfoList[i].stDevBasicInfo.dwDevID)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        public int getSubDeviceID()
        {
            return m_CurSelectTreeNodeInfo.dwSubDeviceID;
        }

        public int getSubDeviceIndex()
        {
            int dwOrgIndex = getOrgIndex();
            if (-1 != dwOrgIndex)
            {
                for (int i = 0; i < m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].stVmsDevInfo.stOrgInfoList[dwOrgIndex].stVmsDevBasicInfoList.Count; i++)
                {
                    if (m_CurSelectTreeNodeInfo.dwSubDeviceID == m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].stVmsDevInfo.stOrgInfoList[dwOrgIndex].stVmsDevBasicInfoList[i].stDevBasicInfo.dwDevID)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        public int getChannelIndexByID(Int32 dwDeviceIndex, Int32 dwOrgIndex, Int32 dwSubDevIndex, Int32 dwChannelID)
        {
            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_VMS == m_deviceInfoList[dwDeviceIndex].m_eDeviceType)
            {
                if (-1 != dwOrgIndex && -1 != dwSubDevIndex)
                {
                    for (int i = 0; i < m_deviceInfoList[dwDeviceIndex].stVmsDevInfo.stOrgInfoList[dwOrgIndex].stVmsDevBasicInfoList[dwSubDevIndex].stChnInfoList.Count; i++)
                    {
                        if (dwChannelID == m_deviceInfoList[dwDeviceIndex].stVmsDevInfo.stOrgInfoList[dwOrgIndex].stVmsDevBasicInfoList[dwSubDevIndex].stChnInfoList[i].stChnInfo.stChnBaseInfo.dwChannelID)
                        {
                            return i;
                        }
                    }
                }

                return -1;
            }
            else
            {
                /* NVR和IPC设备本身信息存储在通道1中，所以应该返回通道1的索引下标0 */
                if (-1 == dwChannelID)
                {
                    return 0;
                }

                return dwChannelID - 1;
            }
        }

        public int getChannelIndex()
        {
            if (-1 == m_CurSelectTreeNodeInfo.dwDeviceIndex ||
                m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle == IntPtr.Zero)
            {
                return -1;
            }

            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_VMS == m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_eDeviceType)
            {
                int dwOrgIndex = getOrgIndex();
                int dwSubDeviceIndex = getSubDeviceIndex();

                if (-1 != dwOrgIndex && -1 != dwSubDeviceIndex)
                {
                    for (int i = 0; i < m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].stVmsDevInfo.stOrgInfoList[dwOrgIndex].stVmsDevBasicInfoList[dwSubDeviceIndex].stChnInfoList.Count; i++)
                    {
                        if (m_CurSelectTreeNodeInfo.dwChannelID == m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].stVmsDevInfo.stOrgInfoList[dwOrgIndex].stVmsDevBasicInfoList[dwSubDeviceIndex].stChnInfoList[i].stChnInfo.stChnBaseInfo.dwChannelID)
                        {
                            return i;
                        }
                    }
                }

                return -1;
            }
            else
            {
                /* NVR和IPC设备本身信息存储在通道1中，所以应该返回通道1的索引下标0 */
                if (-1 == m_CurSelectTreeNodeInfo.dwChannelID)
                {
                    return 0;
                }

                return m_CurSelectTreeNodeInfo.dwChannelID - 1;
            }
        }

        public void startRealPlay()
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0 || getChannelID() < 0)
            {
                return;
            }

            m_curRealPanel.initPlayPanel();
            m_curRealPanel.m_deviceIndex = m_CurSelectTreeNodeInfo.dwDeviceIndex;
            m_curRealPanel.m_channelID = getChannelID();

            NETDEV_PREVIEWINFO_S stPreviewInfo = new NETDEV_PREVIEWINFO_S();
            stPreviewInfo.dwChannelID = getChannelID();
            //stPreviewInfo.dwFluency = 
            stPreviewInfo.dwLinkMode = (int)NETDEV_PROTOCAL_E.NETDEV_TRANSPROTOCAL_RTPTCP;
            stPreviewInfo.dwStreamType = Helper.m_dwStreamType;
            stPreviewInfo.hPlayWnd = m_curRealPanel.Handle;
            IntPtr Handle = NETDEVSDK.NETDEV_RealPlay(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle, ref stPreviewInfo, IntPtr.Zero, IntPtr.Zero);
            if (Handle == IntPtr.Zero)
            {
                return;
            }
            m_curRealPanel.m_playStatus = true;
            m_curRealPanel.m_playhandle = Handle;

            NETDEMO_RealPlayInfo objRealPlayInfo = new NETDEMO_RealPlayInfo();
            objRealPlayInfo.m_channel = getChannelID();
            objRealPlayInfo.m_panelIndex = m_curRealPanel.m_panelIndex;
            m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].addRealPlayInfo(objRealPlayInfo);

            NETDEVSDK.NETDEV_SetIVAEnable(Handle, 1);
            NETDEVSDK.NETDEV_SetIVAShowParam(7);

            realPlayOpenSound();
        }

        private void realPlayOpenSound()
        {
            int iRet = NETDEVSDK.NETDEV_OpenSound(m_curRealPanel.m_playhandle);
            if (NetDevSdk.TRUE != iRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Open sound", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Open sound");

            m_curRealPanel.m_soundStatus = true;
            this.SoundBtn.BackgroundImage = Properties.Resources.ico00008;
            this.SoundBtn.Enabled = true;

            int volumeTemp = 0;
            iRet = NETDEVSDK.NETDEV_GetSoundVolume(m_curRealPanel.m_playhandle, ref volumeTemp);
            if (NetDevSdk.FALSE == iRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Get sound volume", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Get sound volume");

            m_curRealPanel.m_volume = volumeTemp;

            this.SliSoundVolume.Value = m_curRealPanel.m_volume;
            this.SliSoundVolume.Enabled = true;
        }

        private void realPlayOpenMic()
        {
            int iRet = NETDEVSDK.NETDEV_OpenMic(m_curRealPanel.m_playhandle);
            if (NetDevSdk.FALSE == iRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Open Mic", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Open Mic");

            this.MicVolumeBtn.BackgroundImage = Properties.Resources._222;
            m_curRealPanel.m_micStatus = true;

            int volumeTemp = 0;
            iRet = NETDEVSDK.NETDEV_GetMicVolume(m_curRealPanel.m_playhandle, ref volumeTemp);
            if (NetDevSdk.FALSE == iRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Get Mic volume fail", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Get Mic volume");

            m_curRealPanel.m_micVolume = volumeTemp;
            this.SliMicVolume.Value = m_curRealPanel.m_micVolume;
            this.SliMicVolume.Enabled = true;
        }

        //stop realplay
        public bool stopRealPlay(PlayPanel selectRealPanel, bool flag)
        {
            if (IntPtr.Zero == selectRealPanel.m_playhandle)
            {
                return false;
            }

            if (NetDevSdk.FALSE == NETDEVSDK.NETDEV_StopRealPlay(selectRealPanel.m_playhandle))
            {
                showFailLogInfo(m_deviceInfoList[selectRealPanel.m_deviceIndex].m_ip + " chl:" + (selectRealPanel.m_channelID), "stop real play", NETDEVSDK.NETDEV_GetLastError());
                return false;
            }

            if (true == flag)
            {
                NETDEMO_RealPlayInfo objRealPlayInfo = new NETDEMO_RealPlayInfo();
                objRealPlayInfo.m_channel = selectRealPanel.m_channelID;
                objRealPlayInfo.m_panelIndex = selectRealPanel.m_panelIndex;
                m_deviceInfoList[selectRealPanel.m_deviceIndex].removeRealPlayInfo(objRealPlayInfo);
            }

            showSuccessLogInfo(m_deviceInfoList[selectRealPanel.m_deviceIndex].m_ip + " chl:" + (selectRealPanel.m_channelID), "stop real play");

            if (true == selectRealPanel.m_twoWayAudioFlag)
            {
                TwoWayAudio_Click(null, null);
            }
            if (true == selectRealPanel.m_micStatus)
            {
                MicVolumeBtn_Click(null, null);
            }
            if (true == selectRealPanel.m_bDigitalZoomFlag)
            {
                DigitalZoom_Click(null, null);
            }

            return true;
        }


        private void StopRealPlay_Click(object sender, EventArgs e)
        {
            if (false == stopRealPlay(m_curRealPanel, true))
            {
                return;
            }

            m_curRealPanel.initPlayPanel();
        }

        /*mic*/
        private void SliMicVolume_Scroll(object sender, EventArgs e)
        {
            if (IntPtr.Zero == m_curRealPanel.m_playhandle)
            {
                return;
            }

            int iRet = NETDEVSDK.NETDEV_MicVolumeControl(m_curRealPanel.m_playhandle, (sender as TrackBar).Value);
            if (NetDevSdk.FALSE == iRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Control Mic volume", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Control Mic volume");

            m_curRealPanel.m_micVolume = (sender as TrackBar).Value;
        }

        /*Mic*/
        private void MicVolumeBtn_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == m_curRealPanel.m_playhandle)
            {
                return;
            }

            if (true == m_curRealPanel.m_micStatus)
            {
                int iRet = NETDEVSDK.NETDEV_CloseMic(m_curRealPanel.m_playhandle);
                if (NetDevSdk.FALSE == iRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Close Mic fail", NETDEVSDK.NETDEV_GetLastError());
                    return;
                }
                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Close Mic");

                this.MicVolumeBtn.BackgroundImage = Properties.Resources._222;
                m_curRealPanel.m_micStatus = false;
                this.SliMicVolume.Enabled = false;
            }
            else
            {
                realPlayOpenMic();
            }
        }

        private void SoundBtn_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == m_curRealPanel.m_playhandle)
            {
                return;
            }

            if (true == m_curRealPanel.m_soundStatus)
            {
                int iRet = NETDEVSDK.NETDEV_CloseSound(m_curRealPanel.m_playhandle);
                if (NetDevSdk.FALSE == iRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Close volume fail", NETDEVSDK.NETDEV_GetLastError());
                    return;
                }
                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Close volume");

                this.SoundBtn.BackgroundImage = Properties.Resources.ico00009;
                this.SliSoundVolume.Enabled = false;
                m_curRealPanel.m_soundStatus = false;
            }
            else
            {
                realPlayOpenSound();
            }
        }

        private void SliSoundVolume_Scroll(object sender, EventArgs e)
        {
            if (IntPtr.Zero == m_curRealPanel.m_playhandle)
            {
                return;
            }

            int iRet = NETDEVSDK.NETDEV_SoundVolumeControl(m_curRealPanel.m_playhandle, (sender as TrackBar).Value);
            if (NetDevSdk.FALSE == iRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Control volume", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Control volume");

            m_curRealPanel.m_volume = (sender as TrackBar).Value;
        }

        /************************realPlay control end ************************************/

        private void PannelContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            String panelName = (sender as ContextMenuStrip).SourceControl.Name;
            int panelIndex = int.Parse(panelName.Split(' ')[1]);
            m_mourseRightSelectedPanel = arrayRealPanel[panelIndex];

            ShowDelay.Checked = m_mourseRightSelectedPanel.m_bShortDelayFlag;
            Fluent.Checked = m_mourseRightSelectedPanel.m_bFluentFlag;
            DigitalZoom.Checked = m_mourseRightSelectedPanel.m_bDigitalZoomFlag;
            ThreeDPosition.Checked = m_mourseRightSelectedPanel.m_3DPositionFlag;
            TwoWayAudio.Checked = m_mourseRightSelectedPanel.m_twoWayAudioFlag;

            realPanel_Click(m_mourseRightSelectedPanel, null);
        }

        private void closeAllChannel()
        {
            foreach (PlayPanel panel in arrayRealPanel)
            {
                m_curRealPanel = panel;
                stopRealPlay(m_curRealPanel, true);
                m_curRealPanel.initPlayPanel();
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            PBCloseAllPlayBack();
            faceRecogRealPlayStopBtn_Click(null, null);
            LPRRealPlayStopBtn_Click(null, null);
            closeSelectedDeviceRealPlay(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex], m_CurSelectTreeNodeInfo.dwDeviceIndex, true);

            for (int j = 0; j < arrayRealPanel.Length; j++)
            {
                if (arrayRealPanel[j].m_deviceIndex > m_CurSelectTreeNodeInfo.dwDeviceIndex)
                {
                    arrayRealPanel[j].m_deviceIndex--;
                }
            }

            m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_eDeviceType = NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_INVALID;

            this.DeviceTree.SelectedNode.Nodes.Clear();
            this.DeviceTree.SelectedNode.Remove();

            m_CurSelectTreeNodeInfo = new NETDEMO_TreeNodeInfo();
        }


        private void Logout_Click(object sender, EventArgs e)
        {
            PBCloseAllPlayBack();
            faceRecogRealPlayStopBtn_Click(null, null);
            LPRRealPlayStopBtn_Click(null, null);
            closeSelectedDeviceRealPlay(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex], m_CurSelectTreeNodeInfo.dwDeviceIndex, true);
        }

        private void closeSelectedDeviceRealPlay(NETDEMO_DeviceInfo deviceInfo, int DeviceIndex, bool flag)
        {
            for (int j = 0; j < arrayRealPanel.Length; j++)
            {
                if (arrayRealPanel[j].m_deviceIndex == DeviceIndex)
                {
                    m_curRealPanel = arrayRealPanel[j];
                    stopRealPlay(m_curRealPanel, flag);
                    arrayRealPanel[j].initPlayPanel();
                }
            }

            /* Logout */
            if (NetDevSdk.FALSE == NETDEVSDK.NETDEV_Logout(deviceInfo.m_lpDevHandle))
            {
                return;
            }
            deviceInfo.initDeviceInfo();
            deleteDeviceTreeNode(DeviceIndex);
            //updatedeviceTreeStatus(m_mourseRightDeviceNode.Index);
        }

        private void updatedeviceTreeStatus(int treeNodeIndex)
        {
            TreeNode treeNode = TreeViewFindNode(DeviceTree, treeNodeIndex, 0, NETDEMO_FIND_TREE_NODE_TYPE_E.NETDEMO_FIND_TREE_NODE_DEVICE_INDEX);
            if (null == treeNode)
            {
                return;
            }

            if (m_deviceInfoList[treeNodeIndex].m_lpDevHandle == IntPtr.Zero)
            {
                if (treeNode.ImageIndex == NetDevSdk.NETDEV_TREEVIEW_IMAGE_LOCAL_DEVICE_ON)
                {
                    treeNode.ImageIndex = NetDevSdk.NETDEV_TREEVIEW_IMAGE_LOCAL_DEVICE_OFF;
                    treeNode.SelectedImageIndex = NetDevSdk.NETDEV_TREEVIEW_IMAGE_LOCAL_DEVICE_OFF;
                    for (int i = 0; i < treeNode.Nodes.Count; i++)
                    {
                        treeNode.Nodes[i].ImageIndex = NetDevSdk.NETDEV_TREEVIEW_IMAGE_CHL_DEVICE_OFF;
                        treeNode.Nodes[i].SelectedImageIndex = NetDevSdk.NETDEV_TREEVIEW_IMAGE_CHL_DEVICE_OFF;
                    }
                }
            }

            else
            {
                if (treeNode.ImageIndex == NetDevSdk.NETDEV_TREEVIEW_IMAGE_LOCAL_DEVICE_OFF)
                {
                    treeNode.ImageIndex = NetDevSdk.NETDEV_TREEVIEW_IMAGE_LOCAL_DEVICE_ON;
                    treeNode.SelectedImageIndex = NetDevSdk.NETDEV_TREEVIEW_IMAGE_LOCAL_DEVICE_ON;
                    for (int i = 0; i < treeNode.Nodes.Count; i++)
                    {
                        if (m_deviceInfoList[treeNodeIndex].m_channelInfoList[i].m_devVideoChlInfo.enStatus == (int)NETDEV_CHANNEL_STATUS_E.NETDEV_CHL_STATUS_ONLINE)
                        {
                            treeNode.Nodes[i].ImageIndex = NetDevSdk.NETDEV_TREEVIEW_IMAGE_CHL_DEVICE_ON;
                            treeNode.Nodes[i].SelectedImageIndex = NetDevSdk.NETDEV_TREEVIEW_IMAGE_CHL_DEVICE_ON;
                        }
                        else
                        {
                            treeNode.Nodes[i].ImageIndex = NetDevSdk.NETDEV_TREEVIEW_IMAGE_CHL_DEVICE_OFF;
                            treeNode.Nodes[i].SelectedImageIndex = NetDevSdk.NETDEV_TREEVIEW_IMAGE_CHL_DEVICE_OFF;
                        }

                    }
                }
            }
        }


        private void Login_Click(object sender, EventArgs e)
        {
            /*add login fail log tip */
            switch (this.DeviceTree.SelectedNode.ImageIndex)
            {
                case NetDevSdk.NETDEV_TREEVIEW_IMAGE_LOCAL_DEVICE_OFF:
                    {
                        String strIPAddr = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip;
                        Int32 udwPort = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_port;
                        String strUserName = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_userName;
                        String strPassword = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_password;
                        NETDEMO_DEVICE_TYPE_E eDeviceType = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_eDeviceType;

                        AddLocalDevice(strIPAddr, udwPort, strUserName, strPassword, eDeviceType);
                        break;
                    }
                case NetDevSdk.NETDEV_TREEVIEW_IMAGE_LOCAL_DEVICE_ON:
                    {
                        String strIPAddr = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip;
                        Int32 udwPort = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_port;
                        showFailLogInfo(strIPAddr + " : " + udwPort, "login", NETDEVSDK.NETDEV_GetLastError());
                        MessageBox.Show("The device already exists!");
                        return;
                    }
                default:
                    return;
            }

        }


        private void Property_Click(object sender, EventArgs e)
        {
            if (this.DeviceTree.SelectedNode.ImageIndex == NetDevSdk.NETDEV_TREEVIEW_IMAGE_LOCAL_DEVICE_ON)
            {
                LocalDeviceAttribute localDeviceAttribute = new LocalDeviceAttribute(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex]);
                localDeviceAttribute.ShowDialog();
            }
        }


        /******************** PTZ Control start by 2017-08-30 ********************/


        private void setPTZControlBtnStatus()
        {
            int dwChannelIndex = getChannelIndex();
            int dwSubDeviceIndex = getSubDeviceIndex();
            int dwOrgIndex = getOrgIndex();

            if (dwChannelIndex == -1)
            {
                return;
            }

            bool bPtzSupported = false;
            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_VMS == m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_eDeviceType)
            {
                if (-1 == dwOrgIndex || -1 == dwSubDeviceIndex)
                {
                    return;
                }

                if (NetDevSdk.TRUE == m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].stVmsDevInfo.stOrgInfoList[dwOrgIndex].stVmsDevBasicInfoList[dwSubDeviceIndex].stChnInfoList[dwChannelIndex].stChnInfo.bSupportPTZ)
                {
                    bPtzSupported = true;
                }
            }
            else
            {
                if (m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[dwChannelIndex].m_devVideoChlInfo.bPtzSupported == NetDevSdk.TRUE)
                {
                    bPtzSupported = true;
                }
            }

            if (m_curRealPanel.m_playStatus == true && true == bPtzSupported)
            {
                this.ptzLUBtn.Enabled = true;
                this.PTZUBtn.Enabled = true;
                this.PTZRUBtn.Enabled = true;
                this.PTZLBtn.Enabled = true;
                this.PTZStopBtn.Enabled = true;
                this.PTZRBtn.Enabled = true;
                this.PTZLDBtn.Enabled = true;
                this.PTZDBtn.Enabled = true;
                this.PTZRDBtn.Enabled = true;

                this.zoomTeleBtn.Enabled = true;
                this.zoomWideBtn.Enabled = true;
                this.focusFarBtn.Enabled = true;
                this.focusNearBtn.Enabled = true;

                this.MoreBtn.Enabled = true;
            }
            else
            {
                this.ptzLUBtn.Enabled = false;
                this.PTZUBtn.Enabled = false;
                this.PTZRUBtn.Enabled = false;
                this.PTZLBtn.Enabled = false;
                this.PTZStopBtn.Enabled = false;
                this.PTZRBtn.Enabled = false;
                this.PTZLDBtn.Enabled = false;
                this.PTZDBtn.Enabled = false;
                this.PTZRDBtn.Enabled = false;

                this.zoomTeleBtn.Enabled = false;
                this.zoomWideBtn.Enabled = false;
                this.focusFarBtn.Enabled = false;
                this.focusNearBtn.Enabled = false;

                this.MoreBtn.Enabled = false;
            }
        }


        private void PTZSpeedTrackBar_Scroll(object sender, EventArgs e)
        {
            m_oPtzControl.setPTZSpeed((sender as TrackBar).Value);
        }


        private void PTZStopBtn_Click(object sender, EventArgs e)
        {
            m_oPtzControl.control(m_curRealPanel.m_playhandle, (int)NETDEV_PTZ_E.NETDEV_PTZ_ALLSTOP);
        }


        private void ptzLUBtn_MouseDown(object sender, MouseEventArgs e)
        {
            m_oPtzControl.control(m_curRealPanel.m_playhandle, (int)NETDEV_PTZ_E.NETDEV_PTZ_LEFTUP);
        }

        private void ptzLUBtn_MouseUp(object sender, MouseEventArgs e)
        {
            m_oPtzControl.control(m_curRealPanel.m_playhandle, (int)NETDEV_PTZ_E.NETDEV_PTZ_ALLSTOP);
        }


        private void PTZUBtn_MouseDown(object sender, MouseEventArgs e)
        {
            m_oPtzControl.control(m_curRealPanel.m_playhandle, (int)NETDEV_PTZ_E.NETDEV_PTZ_TILTUP);
        }

        private void PTZUBtn_MouseUp(object sender, MouseEventArgs e)
        {
            m_oPtzControl.control(m_curRealPanel.m_playhandle, (int)NETDEV_PTZ_E.NETDEV_PTZ_ALLSTOP);
        }


        private void PTZRUBtn_MouseDown(object sender, MouseEventArgs e)
        {
            m_oPtzControl.control(m_curRealPanel.m_playhandle, (int)NETDEV_PTZ_E.NETDEV_PTZ_RIGHTUP);
        }

        private void PTZRUBtn_MouseUp(object sender, MouseEventArgs e)
        {
            m_oPtzControl.control(m_curRealPanel.m_playhandle, (int)NETDEV_PTZ_E.NETDEV_PTZ_ALLSTOP);
        }


        private void PTZLBtn_MouseDown(object sender, MouseEventArgs e)
        {
            m_oPtzControl.control(m_curRealPanel.m_playhandle, (int)NETDEV_PTZ_E.NETDEV_PTZ_PANLEFT);
        }

        private void PTZLBtn_MouseUp(object sender, MouseEventArgs e)
        {
            m_oPtzControl.control(m_curRealPanel.m_playhandle, (int)NETDEV_PTZ_E.NETDEV_PTZ_ALLSTOP);
        }


        private void PTZRBtn_MouseDown(object sender, MouseEventArgs e)
        {
            m_oPtzControl.control(m_curRealPanel.m_playhandle, (int)NETDEV_PTZ_E.NETDEV_PTZ_PANRIGHT);
        }

        private void PTZRBtn_MouseUp(object sender, MouseEventArgs e)
        {
            m_oPtzControl.control(m_curRealPanel.m_playhandle, (int)NETDEV_PTZ_E.NETDEV_PTZ_ALLSTOP);
        }


        private void PTZLDBtn_MouseDown(object sender, MouseEventArgs e)
        {
            m_oPtzControl.control(m_curRealPanel.m_playhandle, (int)NETDEV_PTZ_E.NETDEV_PTZ_LEFTDOWN);
        }

        private void PTZLDBtn_MouseUp(object sender, MouseEventArgs e)
        {
            m_oPtzControl.control(m_curRealPanel.m_playhandle, (int)NETDEV_PTZ_E.NETDEV_PTZ_ALLSTOP);
        }


        private void PTZDBtn_MouseDown(object sender, MouseEventArgs e)
        {
            m_oPtzControl.control(m_curRealPanel.m_playhandle, (int)NETDEV_PTZ_E.NETDEV_PTZ_TILTDOWN);
        }

        private void PTZDBtn_MouseUp(object sender, MouseEventArgs e)
        {
            m_oPtzControl.control(m_curRealPanel.m_playhandle, (int)NETDEV_PTZ_E.NETDEV_PTZ_ALLSTOP);
        }


        private void PTZRDBtn_MouseDown(object sender, MouseEventArgs e)
        {
            m_oPtzControl.control(m_curRealPanel.m_playhandle, (int)NETDEV_PTZ_E.NETDEV_PTZ_RIGHTDOWN);
        }

        private void PTZRDBtn_MouseUp(object sender, MouseEventArgs e)
        {
            m_oPtzControl.control(m_curRealPanel.m_playhandle, (int)NETDEV_PTZ_E.NETDEV_PTZ_ALLSTOP);
        }


        private void zoomWideBtn_MouseDown(object sender, MouseEventArgs e)
        {
            m_oPtzControl.control(m_curRealPanel.m_playhandle, (int)NETDEV_PTZ_E.NETDEV_PTZ_ZOOMWIDE);
        }

        private void zoomWideBtn_MouseUp(object sender, MouseEventArgs e)
        {
            m_oPtzControl.control(m_curRealPanel.m_playhandle, (int)NETDEV_PTZ_E.NETDEV_PTZ_ZOOMWIDE_STOP);
        }

        private void zoomTeleBtn_MouseDown(object sender, MouseEventArgs e)
        {
            m_oPtzControl.control(m_curRealPanel.m_playhandle, (int)NETDEV_PTZ_E.NETDEV_PTZ_ZOOMTELE);
        }

        private void zoomTeleBtn_MouseUp(object sender, MouseEventArgs e)
        {
            m_oPtzControl.control(m_curRealPanel.m_playhandle, (int)NETDEV_PTZ_E.NETDEV_PTZ_ZOOMTELE_STOP);
        }

        private void focusNearBtn_MouseDown(object sender, MouseEventArgs e)
        {
            m_oPtzControl.control(m_curRealPanel.m_playhandle, (int)NETDEV_PTZ_E.NETDEV_PTZ_FOCUSNEAR);
        }

        private void focusNearBtn_MouseUp(object sender, MouseEventArgs e)
        {
            m_oPtzControl.control(m_curRealPanel.m_playhandle, (int)NETDEV_PTZ_E.NETDEV_PTZ_FOCUSNEAR_STOP);
        }

        private void focusFarBtn_MouseDown(object sender, MouseEventArgs e)
        {
            m_oPtzControl.control(m_curRealPanel.m_playhandle, (int)NETDEV_PTZ_E.NETDEV_PTZ_FOCUSFAR);
        }

        private void focusFarBtn_MouseUp(object sender, MouseEventArgs e)
        {
            m_oPtzControl.control(m_curRealPanel.m_playhandle, (int)NETDEV_PTZ_E.NETDEV_PTZ_FOCUSFAR_STOP);
        }


        public void presetGetBtn_Click(object sender, EventArgs e)
        {
            if (getChannelID() == -1)
            {
                return;
            }

            int dwChannelID = getChannelID();
            IntPtr lpHandle = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;


            if (IntPtr.Zero == lpHandle)
            {
                MessageBox.Show("Device Handle is 0 ", "warning");
                return;
            }

            this.presetIDCobBox.Items.Clear();

            NETDEV_PTZ_ALLPRESETS_S stPtzPresets = new NETDEV_PTZ_ALLPRESETS_S();

            int iRet = NETDEVSDK.NETDEV_GetPTZPresetList(lpHandle, dwChannelID, ref stPtzPresets);
            if (NetDevSdk.TRUE != iRet)
            {
                if (NetDevSdk.NETDEV_E_NO_RESULT == NETDEVSDK.NETDEV_GetLastError())
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Preset list is emtpy.", NETDEVSDK.NETDEV_GetLastError());
                }
                else
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "get Preset", NETDEVSDK.NETDEV_GetLastError());
                }
                return;
            }
            else
            {
                Int32 i = 0;
                for (; i < stPtzPresets.dwSize; i++)
                {
                    this.presetIDCobBox.Items.Add(Convert.ToString(stPtzPresets.astPreset[i].dwPresetID));
                }

                if (i > 0)
                {
                    presetIDCobBox.SelectedIndex = 0;
                    presetNameText.Text = GetDefaultString(stPtzPresets.astPreset[0].szPresetName);
                }
                else
                {
                    presetNameText.Text = "";
                }
                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "get Preset");
            }
        }


        private void presetGoToBtn_Click(object sender, EventArgs e)
        {
            if (getChannelID() == -1)
            {
                return;
            }

            int dwChannelID = getChannelID();
            IntPtr lpHandle = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;


            if (IntPtr.Zero == lpHandle)
            {
                MessageBox.Show("Device Handle is 0 ", "warning");
                return;
            }

            int presetID = Convert.ToInt32(this.presetIDCobBox.SelectedItem);

            string PresetNameTemp = "";

            byte[] byPresetName;
            GetUTF8Buffer(PresetNameTemp, NetDevSdk.NETDEV_LEN_32, out byPresetName);

            int iRet = NETDEVSDK.NETDEV_PTZPreset_Other(lpHandle, dwChannelID, (int)NETDEV_PTZ_PRESETCMD_E.NETDEV_PTZ_GOTO_PRESET, byPresetName, presetID);
            if (NetDevSdk.TRUE != iRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Go to preset fail", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Go to preset");

        }

        private void presetIDCobBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (getChannelID() == -1)
            {
                return;
            }

            int dwChannelID = getChannelID();
            IntPtr lpHandle = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            if (IntPtr.Zero == lpHandle)
            {
                MessageBox.Show("Device Handle is 0 ", "warning");
                return;
            }

            NETDEV_PTZ_ALLPRESETS_S stPtzPresets = new NETDEV_PTZ_ALLPRESETS_S();
            int iRet = NETDEVSDK.NETDEV_GetPTZPresetList(lpHandle, dwChannelID, ref stPtzPresets);
            if (NetDevSdk.TRUE != iRet)
            {
                if (NetDevSdk.NETDEV_E_NO_RESULT == NETDEVSDK.NETDEV_GetLastError())
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Preset list is emtpy.", NETDEVSDK.NETDEV_GetLastError());
                }
                else
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "get Preset", NETDEVSDK.NETDEV_GetLastError());
                }
                return;
            }
            else
            {
                for (Int32 i = 0; i < stPtzPresets.dwSize; i++)
                {
                    if (Convert.ToInt32(this.presetIDCobBox.SelectedItem) == stPtzPresets.astPreset[i].dwPresetID)
                    {
                        presetNameText.Text = GetDefaultString(stPtzPresets.astPreset[i].szPresetName);
                        return;
                    }
                }

                presetNameText.Text = "";
                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "get Preset");
            }
        }

        private void presetSetBtn_Click(object sender, EventArgs e)
        {
            Preset oPreset = new Preset(this);
            oPreset.ShowDialog();
        }

        private void presetDeleteBtn_Click(object sender, EventArgs e)
        {
            if (this.getChannelID() == -1)
            {
                return;
            }

            int dwChannelID = this.getChannelID();
            IntPtr lpHandle = this.getDeviceInfoList()[this.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            if (IntPtr.Zero == lpHandle)
            {
                MessageBox.Show("Device Handle is 0 ", "warning");
                return;
            }

            String strPresetName = "";
            Int32 lPresetID = Convert.ToInt32(this.presetIDCobBox.SelectedItem);

            byte[] byPresetName;
            GetUTF8Buffer(strPresetName, NetDevSdk.NETDEV_LEN_32, out byPresetName);

            int iRet = NETDEVSDK.NETDEV_PTZPreset_Other(lpHandle, dwChannelID, (int)NETDEV_PTZ_PRESETCMD_E.NETDEV_PTZ_CLE_PRESET, byPresetName, lPresetID);
            if (NetDevSdk.TRUE != iRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Delete preset fail", NETDEVSDK.NETDEV_GetLastError());
            }
            else
            {
                this.presetGetBtn_Click(null, null);
                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Delete preset");
            }
        }

        /******************** PTZ Control end ********************/

        public PlayPanel getCurRealPanel()
        {
            return m_curRealPanel;
        }

        public List<NETDEMO_DeviceInfo> getDeviceInfoList()
        {
            return m_deviceInfoList;
        }

        public NETDEMO_CycleMonitorInfo getCycleMonitorInfo()
        {
            return this.m_cycleMonitorInfo;
        }

        private void CapturePicture_Click(object sender, EventArgs e)
        {
            if (m_curRealPanel.m_playhandle == IntPtr.Zero)
            {
                if (m_CurSelectTreeNodeInfo.dwDeviceIndex > m_deviceInfoList.Count() || m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
                {
                    return;
                }

                String strNoPreviewTemp = string.Copy(LocalSetting.m_strPicSavePath);
                DateTime oNoPreviewDate = DateTime.Now;
                String strNoPreviewCurTime = oNoPreviewDate.ToString("yyMMddHHmmss", DateTimeFormatInfo.InvariantInfo);
                LocalSetting.m_strPicSavePath += "\\";
                LocalSetting.m_strPicSavePath += m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip;
                LocalSetting.m_strPicSavePath += "_";
                LocalSetting.m_strPicSavePath += (getChannelID());
                LocalSetting.m_strPicSavePath += "_";
                LocalSetting.m_strPicSavePath += strNoPreviewCurTime;

                byte[] picNoPreviewSavePath;
                GetUTF8Buffer(LocalSetting.m_strPicSavePath, NetDevSdk.NETDEV_LEN_260, out picNoPreviewSavePath);

                int iiRet = NETDEVSDK.NETDEV_CaptureNoPreview(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle, getChannelID(), (int)NETDEV_LIVE_STREAM_INDEX_E.NETDEV_LIVE_STREAM_INDEX_MAIN, LocalSetting.m_strPicSavePath, (int)NETDEV_PICTURE_FORMAT_E.NETDEV_PICTURE_BMP);
                if (NetDevSdk.FALSE == iiRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "CaptureNoPreview", NETDEVSDK.NETDEV_GetLastError());
                    LocalSetting.m_strPicSavePath = strNoPreviewTemp;
                    return;
                }
                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "CaptureNoPreview");
                LocalSetting.m_strPicSavePath = strNoPreviewTemp;
                return;
            }

            String strTemp = string.Copy(LocalSetting.m_strPicSavePath);
            DateTime oDate = DateTime.Now;
            String strCurTime = oDate.ToString("yyMMddHHmmss", DateTimeFormatInfo.InvariantInfo);
            LocalSetting.m_strPicSavePath += "\\";
            LocalSetting.m_strPicSavePath += m_deviceInfoList[m_curRealPanel.m_deviceIndex].m_ip;
            LocalSetting.m_strPicSavePath += "_";
            LocalSetting.m_strPicSavePath += (m_curRealPanel.m_channelID);
            LocalSetting.m_strPicSavePath += "_";
            LocalSetting.m_strPicSavePath += strCurTime;

            byte[] picSavePath;
            GetUTF8Buffer(LocalSetting.m_strPicSavePath, NetDevSdk.NETDEV_LEN_260, out picSavePath);

            int iRet = NETDEVSDK.NETDEV_CapturePicture(m_curRealPanel.m_playhandle, picSavePath, (int)NETDEV_PICTURE_FORMAT_E.NETDEV_PICTURE_BMP);
            if (NetDevSdk.FALSE == iRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "CapturePicture", NETDEVSDK.NETDEV_GetLastError());
                //return;
            }

            showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "CapturePicture");

            LocalSetting.m_strPicSavePath = strTemp;
        }


        public void startCycleMonitorThread()
        {
            m_cycleMonitorThread = new Thread(new ThreadStart(cycleMonitorRun));
            m_cycleMonitorThread.Start();
        }

        public void startKeepAliveDeviceThread()
        {
            m_keepAliveDeviceThread = new Thread(new ThreadStart(keepAliveRun));
            m_keepAliveDeviceThread.Start();
        }

        //add local device
        public void AddLocalDevice(NETDEMO_DeviceInfo deviceInfo)
        {
            lock (m_notLoggeddeviceInfoListlocker)
            {
                m_notLoggeddeviceInfoList.Add(deviceInfo);
            }
        }

        private void keepAliveRun()
        {
            while (true)
            {
                //login device
                List<NETDEMO_DeviceInfo> oList = new List<NETDEMO_DeviceInfo>();
                lock (m_notLoggeddeviceInfoListlocker)
                {
                    for (int i = 0; i < m_notLoggeddeviceInfoList.Count; ++i)
                    {
                        oList.Add(m_notLoggeddeviceInfoList[i]);
                    }
                    m_notLoggeddeviceInfoList.Clear();
                }

                for (int i = 0; i < oList.Count;)
                {

                    LoginLocalDevice(oList[i]);

                    oList.Remove(oList[i]);
                }

                Thread.Sleep(2 * 1000);
            }
        }

        private void cycleMonitorRun()
        {
            int panelIndex = 0;
            int monitorIndex = 0;
            while (true)
            {
                while (monitorIndex < m_cycleMonitorInfo.monitorCount)
                {
                    NETDEV_PREVIEWINFO_S stPreviewInfo = new NETDEV_PREVIEWINFO_S();
                    stPreviewInfo.dwChannelID = m_cycleMonitorInfo.channelInfoList[monitorIndex].channelID;
                    stPreviewInfo.dwLinkMode = (int)NETDEV_PROTOCAL_E.NETDEV_TRANSPROTOCAL_RTPTCP;
                    stPreviewInfo.dwStreamType = (int)NETDEV_LIVE_STREAM_INDEX_E.NETDEV_LIVE_STREAM_INDEX_AUX;
                    if (this.m_cycleMonitorInfo.monitorType == NETDEMO_MONITOR_TYPE_E.NETDEMO_MONITOR_SINGLE_SCREEN)
                    {
                        stPreviewInfo.hPlayWnd = arrayRealPanel[m_cycleMonitorInfo.panelNo].Handle;

                        if (arrayRealPanel[m_cycleMonitorInfo.panelNo].m_playStatus == true)
                        {
                            stopRealPlay(arrayRealPanel[m_cycleMonitorInfo.panelNo], true);
                            arrayRealPanel[m_cycleMonitorInfo.panelNo].initPlayPanel();
                        }

                        IntPtr Handle = NETDEVSDK.NETDEV_RealPlay(m_cycleMonitorInfo.channelInfoList[monitorIndex].devhandle, ref stPreviewInfo, IntPtr.Zero, IntPtr.Zero);
                        if (Handle == IntPtr.Zero)
                        {
                            monitorIndex++;
                            continue;
                        }

                        arrayRealPanel[m_cycleMonitorInfo.panelNo].m_playStatus = true;
                        arrayRealPanel[m_cycleMonitorInfo.panelNo].m_playhandle = Handle;
                        arrayRealPanel[m_cycleMonitorInfo.panelNo].m_deviceIndex = m_cycleMonitorInfo.channelInfoList[monitorIndex].deviceIndex;
                        arrayRealPanel[m_cycleMonitorInfo.panelNo].m_channelID = m_cycleMonitorInfo.channelInfoList[monitorIndex].channelID;

                        monitorIndex++;
                        if (monitorIndex == m_cycleMonitorInfo.monitorCount)
                        {
                            monitorIndex = 0;
                        }
                        break;
                    }
                    else
                    {
                        stPreviewInfo.hPlayWnd = arrayRealPanel[panelIndex].Handle;

                        if (arrayRealPanel[panelIndex].m_playStatus == true)
                        {
                            stopRealPlay(arrayRealPanel[panelIndex], true);
                            arrayRealPanel[panelIndex].initPlayPanel();
                        }

                        IntPtr Handle = NETDEVSDK.NETDEV_RealPlay(m_cycleMonitorInfo.channelInfoList[monitorIndex].devhandle, ref stPreviewInfo, IntPtr.Zero, IntPtr.Zero);
                        if (Handle == IntPtr.Zero)
                        {
                            monitorIndex++;
                            if (monitorIndex == m_cycleMonitorInfo.monitorCount)
                            {
                                monitorIndex = 0;
                                if (m_cycleMonitorInfo.monitorCount <= arrayRealPanel.Length)
                                {
                                    panelIndex = monitorIndex;
                                }
                                break;
                            }
                            continue;
                        }

                        arrayRealPanel[panelIndex].m_playStatus = true;
                        arrayRealPanel[panelIndex].m_playhandle = Handle;
                        arrayRealPanel[panelIndex].m_deviceIndex = m_cycleMonitorInfo.channelInfoList[monitorIndex].deviceIndex;
                        arrayRealPanel[panelIndex].m_channelID = m_cycleMonitorInfo.channelInfoList[monitorIndex].channelID;

                        panelIndex++;
                        monitorIndex++;

                        if (panelIndex == arrayRealPanel.Length)
                        {
                            panelIndex = 0;
                            if (monitorIndex == m_cycleMonitorInfo.monitorCount)
                            {
                                monitorIndex = 0;
                            }
                            break;
                        }

                        if (monitorIndex == m_cycleMonitorInfo.monitorCount)
                        {
                            monitorIndex = 0;
                            if (m_cycleMonitorInfo.monitorCount <= arrayRealPanel.Length)
                            {
                                panelIndex = monitorIndex;
                                break;
                            }
                        }
                    }
                }

                Thread.Sleep(m_cycleMonitorInfo.intervalTime * 1000);
            }
        }

        public void stopKeepAliveDeviceThread()
        {
            try
            {
                if (m_keepAliveDeviceThread != null)
                {
                    this.m_keepAliveDeviceThread.Abort();
                    this.m_keepAliveDeviceThread = null;
                }
            }
            catch (ThreadAbortException)
            {
                MessageBox.Show("Stop keep alive thread abort");
            }
        }

        public void stopCycleMonitorThread()
        {
            try
            {
                if (m_cycleMonitorThread != null)
                {
                    this.m_cycleMonitorThread.Abort();
                    this.m_cycleMonitorThread = null;
                    this.closeAllChannel();
                }
            }
            catch (ThreadAbortException)
            {
                MessageBox.Show("Cycle monitor thread abort");
            }
        }

        private void NetDemo_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                e.Cancel = false;  //OK
                this.stopCycleMonitorThread();
                this.stopKeepAliveDeviceThread();
                NETDEVSDK.NETDEV_Cleanup();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void PBQueryBtn_Click(object sender, EventArgs e)
        {
            int dwChannelIndex = getChannelIndex();
            int dwSubDeviceIndex = getSubDeviceIndex();
            int dwOrgIndex = getOrgIndex();

            if (dwChannelIndex == -1)
            {
                return;
            }

            PBVideoTimeListView.Items.Clear();
            m_playBackInfo.m_findPlayBackDataList.Clear();

            NETDEV_FILECOND_S stFileCond = new NETDEV_FILECOND_S();

            String beginDateTimeStr = getInputStartDataTime();
            String endDateTimeStr = getInputEndDataTime();

            stFileCond.tBeginTime = this.getLongTime(beginDateTimeStr);
            stFileCond.tEndTime = this.getLongTime(endDateTimeStr);

            if (stFileCond.tBeginTime >= stFileCond.tEndTime)
            {
                return;
            }

            if (0 == BoxPositionList.SelectedIndex)
            {
                stFileCond.dwRecordLocation = (int)NETDEV_RECORD_LOCATION_E.NETDEV_RECORD_LOCATION_VMS;
                m_getCenterRecord = true;
            }
            else
            {
                stFileCond.dwRecordLocation = (int)NETDEV_RECORD_LOCATION_E.NETDEV_RECORD_LOCATION_NVR;
                m_getCenterRecord = false;
            }

            switch (PBEventType.SelectedIndex)
            {
                case 0:
                    {
                        stFileCond.dwFileType = (int)NETDEV_PLAN_STORE_TYPE_E.NETDEV_TYPE_STORE_TYPE_ALL;
                    }
                    break;
                case 1:
                    {
                        stFileCond.dwFileType = (int)NETDEV_PLAN_STORE_TYPE_E.NETDEV_EVENT_STORE_TYPE_MOTIONDETECTION;
                    }
                    break;
                case 2:
                    {
                        stFileCond.dwFileType = (int)NETDEV_PLAN_STORE_TYPE_E.NETDEV_EVENT_STORE_TYPE_DIGITALINPUT;
                    }
                    break;
                case 3:
                    {
                        stFileCond.dwFileType = (int)NETDEV_PLAN_STORE_TYPE_E.NETDEV_EVENT_STORE_TYPE_VIDEOLOSS;
                    }
                    break;
                default:
                    break;
            }

            stFileCond.dwChannelID = getChannelID();
            m_playBackInfo.m_devHandle = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            IntPtr dwFileHandle = NETDEVSDK.NETDEV_FindFile(m_playBackInfo.m_devHandle, ref stFileCond);

            if (dwFileHandle == IntPtr.Zero)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "find playBack record File fail", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "find playBack record File");

            m_playBackInfo.m_curSelectedChannelID = stFileCond.dwChannelID;
            m_playBackInfo.m_curSelectedDeviceIndex = m_CurSelectTreeNodeInfo.dwDeviceIndex;
            NETDEV_FINDDATA_S findData = new NETDEV_FINDDATA_S();
            while (NetDevSdk.TRUE == NETDEVSDK.NETDEV_FindNextFile(dwFileHandle, ref findData))
            {
                m_playBackInfo.m_findPlayBackDataList.Add(findData);
            }

            if (NetDevSdk.FALSE == NETDEVSDK.NETDEV_FindClose(dwFileHandle))
            {
                showFailLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "close find playBack record File fail", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            showSuccessLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "close find playBack record File");

            showPlayBackData();
            startTimer();
        }


        private string getInputStartDataTime()
        {
            String beginDateTimeStr = this.PBBeginDate.Value.Year.ToString();
            beginDateTimeStr += ("-" + this.PBBeginDate.Value.Month.ToString());
            beginDateTimeStr += ("-" + this.PBBeginDate.Value.Day.ToString());

            beginDateTimeStr += (" " + this.PBBeginTime.Value.Hour.ToString());
            beginDateTimeStr += (":" + this.PBBeginTime.Value.Minute.ToString());
            beginDateTimeStr += (":" + this.PBBeginTime.Value.Second.ToString());

            return beginDateTimeStr;
        }

        private string getInputEndDataTime()
        {
            String endDateTimeStr = this.PBEndDate.Value.Year.ToString();
            endDateTimeStr += ("-" + this.PBEndDate.Value.Month.ToString());
            endDateTimeStr += ("-" + this.PBEndDate.Value.Day.ToString());

            endDateTimeStr += (" " + this.PBEndTime.Value.Hour.ToString());
            endDateTimeStr += (":" + this.PBEndTime.Value.Minute.ToString());
            endDateTimeStr += (":" + this.PBEndTime.Value.Second.ToString());
            return endDateTimeStr;
        }

        /* long -> string */
        private string convertRemainTime(long remainTime)
        {
            String timeTemp = "";
            timeTemp += Convert.ToString(remainTime / 3600);
            timeTemp += ":";
            timeTemp += Convert.ToString((remainTime % 3600) / 60);
            timeTemp += ":";
            timeTemp += Convert.ToString((remainTime % 3600) % 60);
            return timeTemp;
        }


        private void showPlayBackData()
        {
            foreach (NETDEV_FINDDATA_S findData in m_playBackInfo.m_findPlayBackDataList)
            {
                DateTime startDateTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 
                DateTime beginDateTime = startDateTime.AddSeconds(findData.tBeginTime);
                DateTime endDateTime = startDateTime.AddSeconds(findData.tEndTime);

                ListViewItem listViewItem = new ListViewItem(beginDateTime.ToString("yyyy/MM/dd HH:mm:ss"));
                listViewItem.SubItems.Add(endDateTime.ToString("yyyy/MM/dd HH:mm:ss"));
                this.PBVideoTimeListView.Items.Add(listViewItem);
                listViewItem.EnsureVisible();
            }

            if (m_playBackInfo.m_findPlayBackDataList.Count > 0)
            {
                setPlayBackControlEnable(true);
            }
            else
            {
                setPlayBackControlEnable(false);
            }
        }


        private void setPlayBackControlEnable(bool flag)
        {
            if (true == flag)
            {
                PBStartBtn.Enabled = true;
                PBPauseBtn.Enabled = true;
                PBStopBtn.Enabled = true;
                PBFastBackwardBtn.Enabled = true;
                PBFastForwardBtn.Enabled = true;
                PBCaptureBtn.Enabled = true;
                PBRestartBtn.Enabled = true;
                PBFrameBtn.Enabled = true;
                PBVolBtn.Enabled = true;
                PBVolTrackBar.Enabled = true;
                PBVideoTrackBar.Enabled = true;
            }
            else
            {
                PBStartBtn.Enabled = false;
                PBPauseBtn.Enabled = false;
                PBStopBtn.Enabled = false;
                PBFastBackwardBtn.Enabled = false;
                PBFastForwardBtn.Enabled = false;
                PBCaptureBtn.Enabled = false;
                PBRestartBtn.Enabled = false;
                PBFrameBtn.Enabled = false;
                PBVolBtn.Enabled = false;
                PBVolTrackBar.Enabled = false;
                PBVideoTrackBar.Enabled = false;
            }
        }


        private void PBVideoTimeListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PBVideoTimeListView.SelectedItems.Count == 0)
            {
                return;
            }
            int selectedIndex = this.PBVideoTimeListView.SelectedIndices[0];
            String startDateTime = PBVideoTimeListView.Items[selectedIndex].SubItems[0].Text;
            String endDateTime = PBVideoTimeListView.Items[selectedIndex].SubItems[1].Text;
            this.PBBeginDate.Text = startDateTime.Split(' ')[0];
            this.PBBeginTime.Text = startDateTime.Split(' ')[1];

            this.PBEndDate.Text = endDateTime.Split(' ')[0];
            this.PBEndTime.Text = endDateTime.Split(' ')[1];
        }


        private void PBStartBtn_Click(object sender, EventArgs e)
        {
            if (PBVideoTimeListView.SelectedItems.Count == 0)
            {
                return;
            }

            if (m_curPlayBackPanel.m_playStatus == true && m_curPlayBackPanel.m_pauseStatus == true)
            {
                pausePlayBack(false);
                return;
            }
            m_curPlayBackPanel = arrayPlayBackPanel[m_playBackInfo.m_nextPlayBackPanelIndex];
            m_curPlayBackPanel.m_panelIndex = m_playBackInfo.m_nextPlayBackPanelIndex;
            m_playBackInfo.m_nextPlayBackPanelIndex++;
            this.setPlayBackPanelBorderColor();

            if (m_curPlayBackPanel.m_playStatus == true)
            {
                stopPlayBack();
            }

            if (m_playBackInfo.m_nextPlayBackPanelIndex == arrayPlayBackPanel.Length)
            {
                m_playBackInfo.m_nextPlayBackPanelIndex = 0;
            }

            NETDEV_PLAYBACKCOND_S playBackByTimeInfo = new NETDEV_PLAYBACKCOND_S();

            String beginDateTimeStr = getInputStartDataTime();
            String endDateTimeStr = getInputEndDataTime();

            playBackByTimeInfo.tBeginTime = this.getLongTime(beginDateTimeStr);
            playBackByTimeInfo.tEndTime = this.getLongTime(endDateTimeStr);

            playBackByTimeInfo.dwChannelID = m_playBackInfo.m_curSelectedChannelID;
            playBackByTimeInfo.dwLinkMode = (int)NETDEV_PROTOCAL_E.NETDEV_TRANSPROTOCAL_RTPTCP;
            playBackByTimeInfo.dwPlaySpeed = (int)NETDEV_VOD_PLAY_STATUS_E.NETDEV_PLAY_STATUS_1_FORWARD;
            playBackByTimeInfo.hPlayWnd = m_curPlayBackPanel.Handle;

            if (true == m_getCenterRecord)
            {
                playBackByTimeInfo.dwRecordLocation = (int)NETDEV_RECORD_LOCATION_E.NETDEV_RECORD_LOCATION_VMS;
            }
            else
            {
                playBackByTimeInfo.dwRecordLocation = (int)NETDEV_RECORD_LOCATION_E.NETDEV_RECORD_LOCATION_NVR;
            }

            m_curPlayBackPanel.m_maxVideoSliderValue = (int)(playBackByTimeInfo.tEndTime - playBackByTimeInfo.tBeginTime);
            m_curPlayBackPanel.m_startTime = playBackByTimeInfo.tBeginTime;
            m_curPlayBackPanel.m_endTime = playBackByTimeInfo.tEndTime;

            PBVideoTrackBar.SetRange(0, m_curPlayBackPanel.m_maxVideoSliderValue);

            IntPtr playBackHandle = NETDEVSDK.NETDEV_PlayBackByTime(m_playBackInfo.m_devHandle, ref playBackByTimeInfo);
            if (playBackHandle == IntPtr.Zero)
            {
                showFailLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "Playback by time", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            showSuccessLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "Playback by time");

            m_curPlayBackPanel.m_playStatus = true;
            m_curPlayBackPanel.m_pauseStatus = false;
            m_curPlayBackPanel.m_playhandle = playBackHandle;

            playBackOpenSound();
        }


        private void PBCloseAllPlayBack()
        {
            m_playBackInfo.m_timer.Enabled = false;//pause timer


            for (int i = 0; i < arrayPlayBackPanel.Length; i++)
            {
                m_curPlayBackPanel = arrayPlayBackPanel[i];
                PBStopBtn_Click(null, null);
            }

            PBDownLoadStopBtn_Click(null, null);


            PBVideoTimeListView.Items.Clear();
            m_playBackInfo.m_findPlayBackDataList.Clear();

            m_playBackInfo.m_timer.Enabled = true;//start timer
        }


        private void playBackOpenSound()
        {
            int iRet = NETDEVSDK.NETDEV_OpenSound(m_curPlayBackPanel.m_playhandle);
            if (NetDevSdk.TRUE != iRet)
            {
                showFailLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "Open sound fail", NETDEVSDK.NETDEV_GetLastError());
            }

            m_curPlayBackPanel.m_soundStatus = true;
            PBVolBtn.BackgroundImage = Properties.Resources.ico00008;
            PBVolBtn.Enabled = true;
            int volumeTemp = 0;
            iRet = NETDEVSDK.NETDEV_GetSoundVolume(m_curPlayBackPanel.m_playhandle, ref volumeTemp);
            if (NetDevSdk.FALSE == iRet)
            {
                showFailLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "Get sound volume fail", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            showSuccessLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "Get sound volume");

            m_curPlayBackPanel.m_volume = volumeTemp;

            PBVolTrackBar.Value = m_curPlayBackPanel.m_volume;
            PBVolTrackBar.Enabled = true;
        }


        private void PBPauseBtn_Click(object sender, EventArgs e)
        {
            if (m_curPlayBackPanel.m_playStatus == true && m_curPlayBackPanel.m_pauseStatus == false)
            {
                pausePlayBack(true);
            }
        }


        private void PBStopBtn_Click(object sender, EventArgs e)
        {
            if (m_curPlayBackPanel.m_playStatus == true)
            {
                stopPlayBack();
            }
        }


        private void PBFastBackwardBtn_Click(object sender, EventArgs e)
        {
            if (m_curPlayBackPanel.m_playStatus == false || m_curPlayBackPanel.m_pauseStatus == true)
            {
                return;
            }

            long enSpeed = 0;
            if (NetDevSdk.FALSE == NETDEVSDK.NETDEV_PlayBackControl(m_curPlayBackPanel.m_playhandle, (int)NETDEV_VOD_PLAY_CTRL_E.NETDEV_PLAY_CTRL_GETPLAYSPEED, ref enSpeed))
            {
                showFailLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "Get play speed", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            showSuccessLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "Get play speed");

            enSpeed = enSpeed - 1 >= (long)NETDEV_VOD_PLAY_STATUS_E.NETDEV_PLAY_STATUS_16_BACKWARD ? (enSpeed - 1) : enSpeed;
            while ((enSpeed <= (long)NETDEV_VOD_PLAY_STATUS_E.NETDEV_PLAY_STATUS_QUARTER_BACKWARD) && (enSpeed >= (long)NETDEV_VOD_PLAY_STATUS_E.NETDEV_PLAY_STATUS_HALF_BACKWARD))
            {
                enSpeed--;
            }

            m_curPlayBackPanel.m_playSpeed = (int)enSpeed;
            if (NetDevSdk.FALSE == NETDEVSDK.NETDEV_PlayBackControl(m_curPlayBackPanel.m_playhandle, (int)NETDEV_VOD_PLAY_CTRL_E.NETDEV_PLAY_CTRL_SETPLAYSPEED, ref enSpeed))
            {
                showFailLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "Set play speed", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            showSuccessLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID + "Speed:" + enSpeed, "Set play speed");

            if (enSpeed < (long)NETDEV_VOD_PLAY_STATUS_E.NETDEV_PLAY_STATUS_QUARTER_BACKWARD)
            {
                PBShowFBSpeedLabel.Text = "-" + Convert.ToString(Math.Pow(2, Math.Abs(enSpeed - (int)NETDEV_VOD_PLAY_STATUS_E.NETDEV_PLAY_STATUS_1_BACKWARD))) + "x";
            }
            else if (enSpeed == (long)NETDEV_VOD_PLAY_STATUS_E.NETDEV_PLAY_STATUS_QUARTER_FORWARD)
            {
                PBShowFBSpeedLabel.Text = "0.25";
            }
            else if (enSpeed == (long)NETDEV_VOD_PLAY_STATUS_E.NETDEV_PLAY_STATUS_HALF_FORWARD)
            {
                PBShowFBSpeedLabel.Text = "0.5";
            }
            else
            {
                PBShowFBSpeedLabel.Text = Convert.ToString(Math.Pow(2, enSpeed - (int)NETDEV_VOD_PLAY_STATUS_E.NETDEV_PLAY_STATUS_1_FORWARD)) + "x";
            }
        }


        private void PBFastForwardBtn_Click(object sender, EventArgs e)
        {
            if (m_curPlayBackPanel.m_playStatus == false || m_curPlayBackPanel.m_pauseStatus == true)
            {
                return;
            }

            long enSpeed = 0;
            if (NetDevSdk.FALSE == NETDEVSDK.NETDEV_PlayBackControl(m_curPlayBackPanel.m_playhandle, (int)NETDEV_VOD_PLAY_CTRL_E.NETDEV_PLAY_CTRL_GETPLAYSPEED, ref enSpeed))
            {
                showFailLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "Get play speed", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            showSuccessLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "Get play speed");

            enSpeed = enSpeed + 1 <= (long)NETDEV_VOD_PLAY_STATUS_E.NETDEV_PLAY_STATUS_16_FORWARD ? (enSpeed + 1) : enSpeed;
            while ((enSpeed <= (long)NETDEV_VOD_PLAY_STATUS_E.NETDEV_PLAY_STATUS_QUARTER_BACKWARD) && (enSpeed >= (long)NETDEV_VOD_PLAY_STATUS_E.NETDEV_PLAY_STATUS_HALF_BACKWARD))
            {
                enSpeed++;
            }

            m_curPlayBackPanel.m_playSpeed = (int)enSpeed;
            if (NetDevSdk.FALSE == NETDEVSDK.NETDEV_PlayBackControl(m_curPlayBackPanel.m_playhandle, (int)NETDEV_VOD_PLAY_CTRL_E.NETDEV_PLAY_CTRL_SETPLAYSPEED, ref enSpeed))
            {
                showFailLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "Set play speed", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            showSuccessLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID + "speed" + enSpeed, "Set play speed");

            if (enSpeed < (long)NETDEV_VOD_PLAY_STATUS_E.NETDEV_PLAY_STATUS_QUARTER_FORWARD)
            {
                PBShowFBSpeedLabel.Text = "-" + Convert.ToString(Math.Pow(2, Math.Abs(enSpeed - (int)NETDEV_VOD_PLAY_STATUS_E.NETDEV_PLAY_STATUS_1_BACKWARD))) + "x";
            }
            else if (enSpeed == (long)NETDEV_VOD_PLAY_STATUS_E.NETDEV_PLAY_STATUS_QUARTER_FORWARD)
            {
                PBShowFBSpeedLabel.Text = "0.25";
            }
            else if (enSpeed == (long)NETDEV_VOD_PLAY_STATUS_E.NETDEV_PLAY_STATUS_HALF_FORWARD)
            {
                PBShowFBSpeedLabel.Text = "0.5";
            }
            else
            {
                PBShowFBSpeedLabel.Text = Convert.ToString(Math.Pow(2, enSpeed - (int)NETDEV_VOD_PLAY_STATUS_E.NETDEV_PLAY_STATUS_1_FORWARD)) + "x";
            }
        }


        private void PBVideoTrackBar_Scroll(object sender, EventArgs e)
        {
            if (m_curPlayBackPanel.m_playhandle == IntPtr.Zero)
            {
                return;
            }

            long curTime = PBVideoTrackBar.Value + m_curPlayBackPanel.m_startTime;
            if (NetDevSdk.FALSE == NETDEVSDK.NETDEV_PlayBackControl(m_curPlayBackPanel.m_playhandle, (int)NETDEV_VOD_PLAY_CTRL_E.NETDEV_PLAY_CTRL_SETPLAYTIME, ref curTime))
            {
                showFailLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "Set play time", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            m_curPlayBackPanel.m_pauseStatus = false;
            showSuccessLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "Set play time");

        }


        private void PBCaptureBtn_Click(object sender, EventArgs e)
        {
            if (m_curPlayBackPanel.m_playhandle == IntPtr.Zero)
            {
                return;
            }

            String temp = string.Copy(LocalSetting.m_strPicSavePath);
            DateTime date = DateTime.Now;
            String curTime = date.ToString("yyMMddHHmmss", DateTimeFormatInfo.InvariantInfo);
            LocalSetting.m_strPicSavePath += "\\";
            LocalSetting.m_strPicSavePath += m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip;
            LocalSetting.m_strPicSavePath += "_";
            LocalSetting.m_strPicSavePath += m_playBackInfo.m_curSelectedChannelID;
            LocalSetting.m_strPicSavePath += "_";
            LocalSetting.m_strPicSavePath += curTime;

            byte[] picSavePath;
            GetUTF8Buffer(LocalSetting.m_strPicSavePath, NetDevSdk.NETDEV_LEN_260, out picSavePath);
            int iRet = NETDEVSDK.NETDEV_CapturePicture(m_curPlayBackPanel.m_playhandle, picSavePath, (int)NETDEV_PICTURE_FORMAT_E.NETDEV_PICTURE_BMP);
            if (NetDevSdk.FALSE == iRet)
            {
                showFailLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "playBack Capture Picture", NETDEVSDK.NETDEV_GetLastError());
                //return;
            }
            else
            {
                showSuccessLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "playBack Capture Picture");
            }

            LocalSetting.m_strPicSavePath = temp;
        }


        private void startTimer()
        {
            m_playBackInfo.m_timer.AutoReset = true;
            m_playBackInfo.m_timer.Enabled = true;//start timer
        }


        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (m_curPlayBackPanel.m_playStatus == true)
            {
                Int64 curTime = 0;
                if (NetDevSdk.FALSE == NETDEVSDK.NETDEV_PlayBackControl(m_curPlayBackPanel.m_playhandle, (int)NETDEV_VOD_PLAY_CTRL_E.NETDEV_PLAY_CTRL_GETPLAYTIME, ref curTime))
                {
                    showFailLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "get play time", NETDEVSDK.NETDEV_GetLastError());
                    return;
                }

                m_curPlayBackPanel.m_curVideoSliderValue = (int)(curTime - m_curPlayBackPanel.m_startTime);
                PBVideoTrackBar.SetRange(0, m_curPlayBackPanel.m_maxVideoSliderValue);
                if (m_curPlayBackPanel.m_curVideoSliderValue >= m_curPlayBackPanel.m_maxVideoSliderValue || m_curPlayBackPanel.m_curVideoSliderValue < 0)//
                {
                    this.stopPlayBack();
                }
                else
                {
                    PBVideoTrackBar.Value = m_curPlayBackPanel.m_curVideoSliderValue;
                    PBVideoDateTimeLabel.Text = getStrTime(curTime);
                    PBRemainingTimeLabel.Text = convertRemainTime(m_curPlayBackPanel.m_endTime - curTime);
                }
            }

            // updatedownload porcess
            if (NetDevSdk.NETDEMO_DOWNLOAD_TIMER_MUX_FLAG == true || NetDevSdk.NETDEMO_DOWNLOAD_TIMER_STOP_ALL == true)
            {
                return;
            }

            for (int i = 0; i < m_downloadInfoList.Count; i++)
            {
                if (m_downloadInfoList[i].downLoad_status == true)
                {
                    long iPlayTime = 0;
                    int iRet = NETDEVSDK.NETDEV_PlayBackControl(m_downloadInfoList[i].lpHandle, (int)NETDEV_VOD_PLAY_CTRL_E.NETDEV_PLAY_CTRL_GETPLAYTIME, ref iPlayTime);
                    if (NetDevSdk.TRUE != iRet)
                    {
                        //NETDEMO_LOG_ERROR(NULL, "play back control get play time");
                    }

                    if (NetDevSdk.NETDEMO_DOWNLOAD_TIME_COUNT < m_downloadInfoList[i].dwCount || iPlayTime >= m_downloadInfoList[i].tEndTime)
                    {
                        NETDEVSDK.NETDEV_StopGetFile(m_downloadInfoList[i].lpHandle);
                        m_downloadInfoList[i].downLoad_status = false;
                        //m_downloadInfoList.Remove(m_downloadInfoList[i]);
                        //update porcess 100%
                        if (m_downloadInfoList.Count < m_downloadInfo.getListViewItemCount())
                        {
                            m_downloadInfo.updateProgress(i + m_downloadInfo.getListViewItemLastCount(), 100);
                        }
                        else
                        {
                            m_downloadInfo.updateProgress(i, 100);
                        }
                    }
                    else
                    {

                        if (m_downloadInfoList[i].tCurTime == iPlayTime)
                        {
                            m_downloadInfoList[i].dwCount++;
                        }
                        else
                        {
                            m_downloadInfoList[i].dwCount = 0;
                            m_downloadInfoList[i].tCurTime = iPlayTime;
                            //update porcess
                            if (m_downloadInfoList.Count < m_downloadInfo.getListViewItemCount())
                            {
                                m_downloadInfo.updateProgress(i + m_downloadInfo.getListViewItemLastCount(), (int)(((float)(iPlayTime - m_downloadInfoList[i].tBeginTime) / (m_downloadInfoList[i].tEndTime - m_downloadInfoList[i].tBeginTime)) * 100));
                            }
                            else
                            {
                                m_downloadInfo.updateProgress(i, (int)(((float)(iPlayTime - m_downloadInfoList[i].tBeginTime) / (m_downloadInfoList[i].tEndTime - m_downloadInfoList[i].tBeginTime)) * 100));
                            }
                        }
                    }
                }
            }

            NetDevSdk.NETDEMO_DOWNLOAD_TIMER_MUX_FLAG = false;
        }


        private void stopPlayBack()
        {
            if (m_curPlayBackPanel.m_playhandle == IntPtr.Zero)
            {
                return;
            }

            if (NetDevSdk.FALSE == NETDEVSDK.NETDEV_StopPlayBack(m_curPlayBackPanel.m_playhandle))
            {
                showFailLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "close playBack", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            showSuccessLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "close playBack");

            m_curPlayBackPanel.initPlayPanel();

            PBVideoTrackBar.Value = 0;
            PBVideoDateTimeLabel.Text = "0000/00/00 00:00:00";
            PBRemainingTimeLabel.Text = "00:00:00";
            PBVolTrackBar.Value = 0;
            PBVolTrackBar.Enabled = false;
            PBVolBtn.BackgroundImage = Properties.Resources.ico00009;
            PBVolBtn.Enabled = false;
        }


        private void pausePlayBack(bool flag)
        {
            if (m_curPlayBackPanel.m_playhandle == IntPtr.Zero)
            {
                return;
            }

            if (flag == true)
            {
                long temp = 0;
                if (NetDevSdk.FALSE == NETDEVSDK.NETDEV_PlayBackControl(m_curPlayBackPanel.m_playhandle, (int)NETDEV_VOD_PLAY_CTRL_E.NETDEV_PLAY_CTRL_PAUSE, ref temp))
                {
                    showFailLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "pause playBack", NETDEVSDK.NETDEV_GetLastError());
                    return;
                }
                showSuccessLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "pause playBack");

                m_curPlayBackPanel.m_pauseStatus = true;
            }
            else
            {
                long temp = 0;
                if (NetDevSdk.FALSE == NETDEVSDK.NETDEV_PlayBackControl(m_curPlayBackPanel.m_playhandle, (int)NETDEV_VOD_PLAY_CTRL_E.NETDEV_PLAY_CTRL_RESUME, ref temp))
                {
                    showFailLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "resume playBack fail", NETDEVSDK.NETDEV_GetLastError());
                    return;
                }
                showSuccessLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "resume playBack");

                m_curPlayBackPanel.m_pauseStatus = false;
            }
        }

        private void playBackPanel_Click(object sender, EventArgs e)
        {
            this.m_curPlayBackPanel = sender as PlayPanel;
            //this.m_playBackInfo.m_nextPlayBackPanelIndex = m_curPlayBackPanel.m_panelIndex + 1;
            this.m_playBackInfo.m_nextPlayBackPanelIndex = m_curPlayBackPanel.m_panelIndex;
            if (m_playBackInfo.m_nextPlayBackPanelIndex == arrayPlayBackPanel.Length)
            {
                m_playBackInfo.m_nextPlayBackPanelIndex = 0;
            }

            updatePlayBackControl();
            this.setPlayBackPanelBorderColor();
        }

        private void updatePlayBackControl()
        {
            if (m_curPlayBackPanel.m_playStatus == false)
            {
                PBVideoTrackBar.Value = 0;
                PBVolTrackBar.Value = 0;
                PBVideoDateTimeLabel.Text = "0000/00/00 00:00:00";
                PBRemainingTimeLabel.Text = "00:00:00";
                PBVolBtn.BackgroundImage = Properties.Resources.ico00009;
                PBVolBtn.Enabled = false;
                PBVolTrackBar.Enabled = false;
                PBShowFBSpeedLabel.Text = "1x";
            }
            else
            {
                PBVolBtn.Enabled = true;
                PBVolTrackBar.Enabled = true;
                PBVolTrackBar.Value = m_curPlayBackPanel.m_volume;
                if (m_curPlayBackPanel.m_soundStatus == true)
                {
                    PBVolBtn.BackgroundImage = Properties.Resources.ico00008;
                }
                else
                {
                    PBVolBtn.BackgroundImage = Properties.Resources.ico00009;
                }

                if (m_curPlayBackPanel.m_playSpeed < (int)NETDEV_VOD_PLAY_STATUS_E.NETDEV_PLAY_STATUS_1_FORWARD)
                {
                    PBShowFBSpeedLabel.Text = "-" + Convert.ToString(Math.Pow(2, Math.Abs(m_curPlayBackPanel.m_playSpeed - (int)NETDEV_VOD_PLAY_STATUS_E.NETDEV_PLAY_STATUS_1_BACKWARD))) + "x";
                }
                else
                {
                    PBShowFBSpeedLabel.Text = Convert.ToString(Math.Pow(2, m_curPlayBackPanel.m_playSpeed - (int)NETDEV_VOD_PLAY_STATUS_E.NETDEV_PLAY_STATUS_1_FORWARD)) + "x";
                }

            }
        }

        private void playBackPanel_DoubleClick(object sender, EventArgs e)
        {
            this.m_curPlayBackPanel = sender as PlayPanel;
            this.playBackLayoutPanel.Controls.Clear();
            if (playBackMaxFlag == true)
            {
                int nSqrt = (int)Math.Sqrt(NetDevSdk.PLAYBACK_PANEL_MAX_SIZE);
                int nHeight = this.playBackLayoutPanel.Height / nSqrt - 5;
                int nWidth = this.playBackLayoutPanel.Width / nSqrt - 5;
                for (int i = 0; i < NetDevSdk.PLAYBACK_PANEL_MAX_SIZE; i++)
                {
                    this.arrayPlayBackPanel[i].Height = nHeight;
                    this.arrayPlayBackPanel[i].Width = nWidth;
                    this.playBackLayoutPanel.Controls.Add(this.arrayPlayBackPanel[i]);
                }
                playBackMaxFlag = false;
            }
            else
            {
                this.m_curPlayBackPanel.Height = this.playBackLayoutPanel.Height;
                this.m_curPlayBackPanel.Width = this.playBackLayoutPanel.Width;
                this.playBackLayoutPanel.Controls.Add(this.m_curPlayBackPanel);
                playBackMaxFlag = true;
            }
        }

        public void setPlayBackPanelBorderColor()
        {
            for (int i = 0; i < NetDevSdk.PLAYBACK_PANEL_MAX_SIZE; i++)
            {
                arrayPlayBackPanel[i].setBorderColor(Color.White, 1);
                arrayPlayBackPanel[i].Invalidate();
            }
            m_curPlayBackPanel.setBorderColor(Color.Red, 2);
            m_curPlayBackPanel.Invalidate();
        }


        private void PBRestartBtn_Click(object sender, EventArgs e)
        {
            if (m_curPlayBackPanel.m_playhandle == IntPtr.Zero)
            {
                return;
            }

            this.PBVideoTrackBar.Value = 0;
            PBStopBtn_Click(null, null);

            if (m_curPlayBackPanel.m_playStatus == true && m_curPlayBackPanel.m_pauseStatus == true)
            {
                pausePlayBack(false);
                return;
            }
            m_curPlayBackPanel = arrayPlayBackPanel[m_playBackInfo.m_nextPlayBackPanelIndex];
            m_curPlayBackPanel.m_panelIndex = m_playBackInfo.m_nextPlayBackPanelIndex;
            //m_playBackInfo.m_nextPlayBackPanelIndex++;
            this.setPlayBackPanelBorderColor();

            if (m_curPlayBackPanel.m_playStatus == true)
            {
                stopPlayBack();
            }

            if (m_playBackInfo.m_nextPlayBackPanelIndex == arrayPlayBackPanel.Length)
            {
                m_playBackInfo.m_nextPlayBackPanelIndex = 0;
            }

            NETDEV_PLAYBACKCOND_S playBackByTimeInfo = new NETDEV_PLAYBACKCOND_S();

            String beginDateTimeStr = getInputStartDataTime();
            String endDateTimeStr = getInputEndDataTime();

            playBackByTimeInfo.tBeginTime = this.getLongTime(beginDateTimeStr);
            playBackByTimeInfo.tEndTime = this.getLongTime(endDateTimeStr);

            playBackByTimeInfo.dwChannelID = m_playBackInfo.m_curSelectedChannelID;
            playBackByTimeInfo.dwLinkMode = (int)NETDEV_PROTOCAL_E.NETDEV_TRANSPROTOCAL_RTPTCP;
            playBackByTimeInfo.dwPlaySpeed = (int)NETDEV_VOD_PLAY_STATUS_E.NETDEV_PLAY_STATUS_1_FORWARD;
            playBackByTimeInfo.hPlayWnd = m_curPlayBackPanel.Handle;
            m_curPlayBackPanel.m_maxVideoSliderValue = (int)(playBackByTimeInfo.tEndTime - playBackByTimeInfo.tBeginTime);
            m_curPlayBackPanel.m_startTime = playBackByTimeInfo.tBeginTime;
            m_curPlayBackPanel.m_endTime = playBackByTimeInfo.tEndTime;

            PBVideoTrackBar.SetRange(0, m_curPlayBackPanel.m_maxVideoSliderValue);

            IntPtr playBackHandle = NETDEVSDK.NETDEV_PlayBackByTime(m_playBackInfo.m_devHandle, ref playBackByTimeInfo);
            if (playBackHandle == IntPtr.Zero)
            {
                showFailLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "reset Playback by time", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            showSuccessLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "reset Playback by time");

            m_curPlayBackPanel.m_playStatus = true;
            m_curPlayBackPanel.m_pauseStatus = false;
            m_curPlayBackPanel.m_playhandle = playBackHandle;

            playBackOpenSound();

            startTimer();
        }


        private void PBFrameBtn_Click(object sender, EventArgs e)
        {
            //if(m_curPlayBackPanel)
            long enSpeed = (long)NETDEV_VOD_PLAY_STATUS_E.NETDEV_PLAY_STATUS_1_FRAME_FORWD;
            int iRet = NETDEVSDK.NETDEV_PlayBackControl(m_curPlayBackPanel.m_playhandle, (int)NETDEV_VOD_PLAY_CTRL_E.NETDEV_PLAY_CTRL_SINGLE_FRAME, ref enSpeed);
            if (NetDevSdk.TRUE != iRet)
            {
                showFailLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "Playback control single frame fail", NETDEVSDK.NETDEV_GetLastError());
            }
            else
            {
                showSuccessLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "Playback control single frame");
            }
        }


        private void PBDownLoadStartBtn_Click(object sender, EventArgs e)
        {
            if (PBVideoTimeListView.SelectedItems.Count == 0)
            {
                return;
            }

            NETDEV_PLAYBACKCOND_S stPlayBackInfo = new NETDEV_PLAYBACKCOND_S();
            String beginDateTimeStr = getInputStartDataTime();
            String endDateTimeStr = getInputEndDataTime();

            stPlayBackInfo.tBeginTime = this.getLongTime(beginDateTimeStr);
            stPlayBackInfo.tEndTime = this.getLongTime(endDateTimeStr);

            stPlayBackInfo.hPlayWnd = IntPtr.Zero;
            stPlayBackInfo.dwDownloadSpeed = (int)NETDEV_E_DOWNLOAD_SPEED_E.NETDEV_DOWNLOAD_SPEED_EIGHT;
            stPlayBackInfo.dwChannelID = m_playBackInfo.m_curSelectedChannelID;

            IntPtr lpDevHandle = m_playBackInfo.m_devHandle;
            if (IntPtr.Zero == lpDevHandle)
            {
                return;
            }

            String temp = string.Copy(LocalSetting.m_strLocalRecordPath);
            DateTime date = DateTime.Now;
            String curTime = date.ToString("yyyyMMddHHmmss", DateTimeFormatInfo.InvariantInfo);
            LocalSetting.m_strLocalRecordPath += "\\";
            LocalSetting.m_strLocalRecordPath += m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip;
            LocalSetting.m_strLocalRecordPath += "_";
            LocalSetting.m_strLocalRecordPath += m_playBackInfo.m_curSelectedChannelID;
            LocalSetting.m_strLocalRecordPath += "_";
            LocalSetting.m_strLocalRecordPath += curTime;

            byte[] localRecordPath;
            GetUTF8Buffer(LocalSetting.m_strLocalRecordPath, NetDevSdk.NETDEV_LEN_260, out localRecordPath);
            IntPtr pHandle = NETDEVSDK.NETDEV_GetFileByTime(lpDevHandle, ref stPlayBackInfo, localRecordPath, (int)NETDEV_MEDIA_FILE_FORMAT_E.NETDEV_MEDIA_FILE_MP4);
            if (IntPtr.Zero == pHandle)
            {
                showFailLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "Get file by time", NETDEVSDK.NETDEV_GetLastError());
            }
            else
            {
                showSuccessLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "Get file by time");
                String strOut;
                strOut = "Download succeed, Path: ";
                strOut += LocalSetting.m_strLocalRecordPath;
                NETDEMO_UPDATE_TIME_INFO stUpdateInfo = new NETDEMO_UPDATE_TIME_INFO();
                stUpdateInfo.lpHandle = pHandle;
                stUpdateInfo.tBeginTime = stPlayBackInfo.tBeginTime;
                stUpdateInfo.tEndTime = stPlayBackInfo.tEndTime;
                stUpdateInfo.strFileName = LocalSetting.m_strLocalRecordPath;
                stUpdateInfo.strFilePath = temp;
                stUpdateInfo.dwCount = 0;
                stUpdateInfo.tCurTime = 0;
                stUpdateInfo.downLoad_status = true;

                m_downloadInfoList.Add(stUpdateInfo);
                m_downloadInfo.setListView(stUpdateInfo);
                NetDevSdk.NETDEMO_DOWNLOAD_TIMER_STOP_ALL = false;
                MessageBox.Show(strOut, "Download");
            }

            LocalSetting.m_strLocalRecordPath = temp;
            return;
        }


        private void PBDownLoadInfoBtn_Click(object sender, EventArgs e)
        {
            this.m_downloadInfo.Show();
        }


        private void PBDownLoadStopBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < m_downloadInfoList.Count; i++)
            {
                if (m_downloadInfoList[i].downLoad_status == false)
                {
                    continue;
                }

                m_downloadInfoList[i].downLoad_status = false;
                NetDevSdk.NETDEMO_DOWNLOAD_TIMER_STOP_ALL = true;

                int iRet = NETDEVSDK.NETDEV_StopGetFile(m_downloadInfoList[i].lpHandle);
                if (NetDevSdk.TRUE != iRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "Stop get file fail", NETDEVSDK.NETDEV_GetLastError());
                }
                else
                {
                    showSuccessLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "Stop get file");
                }
            }

            int count = m_downloadInfo.getListViewItemCount();
            for (int j = 0; j < count; j++)
            {
                m_downloadInfo.updateProgress(j, 100);
            }
            m_downloadInfo.setListViewItemLastCount();
            m_downloadInfoList.Clear();
        }

        /* vol */
        private void PBVolBtn_Click(object sender, EventArgs e)
        {
            if (m_curPlayBackPanel.m_playhandle == IntPtr.Zero)
            {
                return;
            }

            if (m_curPlayBackPanel.m_soundStatus == false)
            {
                playBackOpenSound();
            }
            else
            {
                int iRet = NETDEVSDK.NETDEV_CloseSound(m_curPlayBackPanel.m_playhandle);
                if (NetDevSdk.TRUE != iRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "Close sound", NETDEVSDK.NETDEV_GetLastError());
                }
                else
                {
                    showSuccessLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "Close sound");
                }

                m_curPlayBackPanel.m_soundStatus = false;
                PBVolBtn.BackgroundImage = Properties.Resources.ico00009;
            }
        }


        private void PBVolTrackBar_Scroll(object sender, EventArgs e)
        {
            if (m_curPlayBackPanel == null || m_curPlayBackPanel.m_playhandle == IntPtr.Zero)
            {
                return;
            }

            int iRet = NETDEVSDK.NETDEV_SoundVolumeControl(m_curPlayBackPanel.m_playhandle, (sender as TrackBar).Value);
            if (NetDevSdk.TRUE != iRet)
            {
                showFailLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "Sound volume control", NETDEVSDK.NETDEV_GetLastError());
            }
            else
            {
                showSuccessLogInfo(m_deviceInfoList[m_playBackInfo.m_curSelectedDeviceIndex].m_ip + " chl:" + m_playBackInfo.m_curSelectedChannelID, "Sound volume control");
            }
            m_curPlayBackPanel.m_volume = (sender as TrackBar).Value;
        }

        private void cfgTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex >= 0 && m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle != IntPtr.Zero)
            {
                m_config.cfgTabSwitch((sender as TabControl).SelectedIndex);
            }
        }

        public void showSystemTime(NETDEV_TIME_CFG_S stTimeCfg)
        {
            this.BasicGMTCobBox.SelectedIndex = (int)stTimeCfg.dwTimeZone;

            this.BasicDate.Text = Convert.ToString(stTimeCfg.stTime.dwYear) + "/" + Convert.ToString(stTimeCfg.stTime.dwMonth) + "/" + Convert.ToString(stTimeCfg.stTime.dwDay);
            this.BasicTime.Text = Convert.ToString(stTimeCfg.stTime.dwHour) + ":" + Convert.ToString(stTimeCfg.stTime.dwMinute) + ":" + Convert.ToString(stTimeCfg.stTime.dwSecond);
        }

        public void showDeviceName(string deviceName)
        {
            BasicDeviceNameText.Text = deviceName;
        }

        public void showDiskInfoList(NETDEV_DISK_INFO_LIST_S stDiskInfoList)
        {
            this.BasicHDInfoListView.Items.Clear();
            for (int i = 0; i < stDiskInfoList.dwSize; i++)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(stDiskInfoList.astDisksInfo[i].dwSlotIndex));
                item.SubItems.Add(Convert.ToString(stDiskInfoList.astDisksInfo[i].dwTotalCapacity / 1024));
                item.SubItems.Add(Convert.ToString((stDiskInfoList.astDisksInfo[i].dwTotalCapacity - stDiskInfoList.astDisksInfo[i].dwUsedCapacity) / 1024));

                String str;
                switch (stDiskInfoList.astDisksInfo[i].enStatus)
                {
                    case NETDEV_DISK_WORK_STATUS_E.NETDEV_DISK_WORK_STATUS_EMPTY:             /*  Empty/No Disk */
                        str = "No Disk";
                        break;
                    case NETDEV_DISK_WORK_STATUS_E.NETDEV_DISK_WORK_STATUS_UNFORMAT:          /*  Unformat */
                        str = "Unformat";
                        break;
                    case NETDEV_DISK_WORK_STATUS_E.NETDEV_DISK_WORK_STATUS_FORMATING:         /*  Formating */
                        str = "Formating";
                        break;
                    case NETDEV_DISK_WORK_STATUS_E.NETDEV_DISK_WORK_STATUS_RUNNING:           /*  Running/Normal */
                        str = "Normal";
                        break;
                    case NETDEV_DISK_WORK_STATUS_E.NETDEV_DISK_WORK_STATUS_HIBERNATE:         /*  Hibernate */
                        str = "Hibernate";
                        break;
                    case NETDEV_DISK_WORK_STATUS_E.NETDEV_DISK_WORK_STATUS_ABNORMAL:          /*  Abnormal */
                        str = "Abnormal";
                        break;
                    default:                                        /*  Unknown */
                        str = "Unknown";
                        break;
                }
                item.SubItems.Add(str);
                item.SubItems.Add(stDiskInfoList.astDisksInfo[i].szManufacturer);
                this.BasicHDInfoListView.Items.Add(item);
            }
        }

        private void BasicSysTimeSaveBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex >= 0 && m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle != IntPtr.Zero)
            {
                m_config.saveStstemTime(this.BasicGMTCobBox.SelectedIndex, this.BasicDate.Text, this.BasicTime.Text);
            }
        }

        private void BasicDeviceNameSaveBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex >= 0 && m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle != IntPtr.Zero)
            {
                m_config.saveDeviceName(BasicDeviceNameText.Text);
            }
        }

        private void BaiscRefreshBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex >= 0 && m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle != IntPtr.Zero)
            {
                m_config.refreshBasicInfo();
            }
        }

        // network Info
        private void NetSaveBtn_Click(object sender, EventArgs e)
        {
            NETDEV_NETWORKCFG_S stNetworkSetcfg = new NETDEV_NETWORKCFG_S();

            /* IP address */
            if ("" != this.NetIPAddText.Text)
            {
                stNetworkSetcfg.Ipv4AddressStr = NetIPAddText.Text;
            }

            /* Gate way */
            if ("" != NetGatwayText.Text)
            {
                stNetworkSetcfg.szIPv4GateWay = NetGatwayText.Text;
            }

            /* sub netmask */
            if ("" != NetSubMaskText.Text)
            {
                stNetworkSetcfg.szIPv4SubnetMask = NetSubMaskText.Text;
            }

            /* MTU */
            stNetworkSetcfg.dwMTU = Convert.ToInt32(NetMTUText.Text);

            /* DHCP */
            if (NetDHCPCkBox.Checked == true)
            {
                stNetworkSetcfg.dwIPv4DHCP = NetDevSdk.TRUE;
            }
            else
            {
                stNetworkSetcfg.dwIPv4DHCP = NetDevSdk.FALSE;
            }

            if (m_CurSelectTreeNodeInfo.dwDeviceIndex >= 0 && m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle != IntPtr.Zero)
            {
                m_config.saveBaseNetworkInfo(stNetworkSetcfg);
            }
        }

        // network Info
        private void NetPortSaveBtn_Click(object sender, EventArgs e)
        {

            NETDEV_UPNP_NAT_STATE_S stNatState = new NETDEV_UPNP_NAT_STATE_S();
            stNatState.astUpnpPort = new NETDEV_UPNP_PORT_STATE_S[NetDevSdk.NETDEV_LEN_16];

            stNatState.dwSize = 3;

            stNatState.astUpnpPort[0].dwPort = Convert.ToInt32(NetPortHTTPText.Text);
            stNatState.astUpnpPort[0].eType = NETDEV_PROTOCOL_TYPE_E.NETDEV_PROTOCOL_TYPE_HTTP;
            stNatState.astUpnpPort[0].bEnbale = NetPortHTTPCobBox.SelectedIndex;


            stNatState.astUpnpPort[1].dwPort = Convert.ToInt32(NetPortHTTPSText.Text);
            stNatState.astUpnpPort[1].eType = NETDEV_PROTOCOL_TYPE_E.NETDEV_PROTOCOL_TYPE_HTTPS;
            stNatState.astUpnpPort[1].bEnbale = NetPortHTTPSCobBox.SelectedIndex;


            stNatState.astUpnpPort[2].dwPort = Convert.ToInt32(NetPortRTSPText.Text);
            stNatState.astUpnpPort[2].eType = NETDEV_PROTOCOL_TYPE_E.NETDEV_PROTOCOL_TYPE_RTSP;
            stNatState.astUpnpPort[2].bEnbale = NetPortRTSPCobBox.SelectedIndex;
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex >= 0 && m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle != IntPtr.Zero)
            {
                m_config.savePortNetworkInfo(stNatState);
            }
        }

        private bool IsIP(string ip)
        {
            //清除要验证字符串中的空格
            ip = ip.Trim();
            //模式字符串
            string pattern = @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$";

            //验证
            return System.Text.RegularExpressions.Regex.IsMatch(ip, pattern);
        }
        /* network Info
         * NTP
         */
        private void NetNTPSaveBtn_Click(object sender, EventArgs e)
        {
            NETDEV_SYSTEM_NTP_INFO_S stNTPInfo = new NETDEV_SYSTEM_NTP_INFO_S();

            if (NetNTPDHCPCkBox.CheckState == CheckState.Checked)
            {
                stNTPInfo.bSupportDHCP = NetDevSdk.TRUE;
            }
            else
            {
                stNTPInfo.bSupportDHCP = NetDevSdk.FALSE;
            }

            stNTPInfo.stAddr.eIPType = NetNTPIPTypeCobBox.SelectedIndex;
            if (0 == stNTPInfo.stAddr.eIPType)
            {
                if (true == IsIP(NetNTPServerIPText.Text))
                {
                    stNTPInfo.stAddr.szIPAddr = NetNTPServerIPText.Text;
                }
                else
                {
                    showFailLogInfo(null, "The IP address is invalid", NETDEVSDK.NETDEV_GetLastError());
                    return;
                }
            }
            else
            {
                stNTPInfo.stAddr.szIPAddr = NetNTPServerIPText.Text;
            }

            if (m_CurSelectTreeNodeInfo.dwDeviceIndex >= 0 && m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle != IntPtr.Zero)
            {
                m_config.saveNTPNetworkInfo(stNTPInfo);
            }
        }

        /* network Info
         * 
         */
        private void NetworkRefreshBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex >= 0 && m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle != IntPtr.Zero)
            {
                m_config.refreshNetworkInfo();
            }
        }

        /*network Info
         * DHCP CheckedChanged
         */
        private void NetDHCPCkBox_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).CheckState == CheckState.Checked)
            {
                DHCPEnable(false);
            }
            else
            {
                DHCPEnable(true);
            }
        }

        public void DHCPEnable(bool flag)
        {

            NetIPAddText.Enabled = flag;
            NetSubMaskText.Enabled = flag;
            NetGatwayText.Enabled = flag;
        }

        /*network Info
         * 
         */
        public void showBaseNetworkInfo(NETDEV_NETWORKCFG_S stNetworkcfg)
        {
            if (stNetworkcfg.dwIPv4DHCP == NetDevSdk.TRUE)
            {
                this.NetDHCPCkBox.Checked = true;
            }
            else
            {
                this.NetDHCPCkBox.Checked = false;
            }

            NetIPAddText.Text = stNetworkcfg.Ipv4AddressStr;
            NetSubMaskText.Text = stNetworkcfg.szIPv4SubnetMask;
            NetGatwayText.Text = stNetworkcfg.szIPv4GateWay;
            NetMTUText.Text = Convert.ToString(stNetworkcfg.dwMTU);

            DHCPEnable(!this.NetDHCPCkBox.Checked);
        }

        /*network Info
         * port
         */
        public void showPortNetworkInfo(NETDEV_UPNP_NAT_STATE_S stNatState)
        {
            for (Int32 i = 0; i < stNatState.dwSize; i++)
            {
                switch ((int)(stNatState.astUpnpPort[i].eType))
                {
                    case (int)NETDEV_PROTOCOL_TYPE_E.NETDEV_PROTOCOL_TYPE_HTTP:
                        {
                            NetPortHTTPText.Text = Convert.ToString(stNatState.astUpnpPort[i].dwPort);
                            Int32 index = stNatState.astUpnpPort[i].bEnbale;
                            NetPortHTTPCobBox.SelectedIndex = index;
                        }
                        break;
                    case (int)NETDEV_PROTOCOL_TYPE_E.NETDEV_PROTOCOL_TYPE_HTTPS:
                        {
                            NetPortHTTPSText.Text = Convert.ToString(stNatState.astUpnpPort[i].dwPort);
                            Int32 index = stNatState.astUpnpPort[i].bEnbale;
                            NetPortHTTPSCobBox.SelectedIndex = index;
                        }
                        break;
                    case (int)NETDEV_PROTOCOL_TYPE_E.NETDEV_PROTOCOL_TYPE_RTSP:
                        {
                            NetPortRTSPText.Text = Convert.ToString(stNatState.astUpnpPort[i].dwPort);
                            Int32 index = stNatState.astUpnpPort[i].bEnbale;
                            NetPortRTSPCobBox.SelectedIndex = index;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        /*network Info
         * NTP
         */
        public void showNTPNetworkInfo(NETDEV_SYSTEM_NTP_INFO_S stNTPInfo)
        {
            /* Support DHCP */
            if (NetDevSdk.TRUE == stNTPInfo.bSupportDHCP)
            {
                NetNTPDHCPCkBox.Checked = true;
            }
            else
            {
                NetNTPDHCPCkBox.Checked = false;
            }

            /* IP type */
            NetNTPIPTypeCobBox.SelectedIndex = stNTPInfo.stAddr.eIPType;

            /* Ntp Server IP address */
            NetNTPServerIPText.Text = stNTPInfo.stAddr.szIPAddr;


        }

        private void NetNTPDHCPCkBox_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).CheckState == CheckState.Checked)
            {
                NTPDHCPEnable(false);
            }
            else
            {
                NTPDHCPEnable(true);
            }
        }

        private void NTPDHCPEnable(bool flag)
        {
            NetNTPIPTypeCobBox.Enabled = flag;

            /* Ntp Server IP address */
            NetNTPServerIPText.Enabled = flag;
        }

        /*video Info
         * video
         */
        private void VideoSaveBtn_Click(object sender, EventArgs e)
        {
            int dwChannelIndex = getChannelIndex();
            int dwDeviceIndex = getDeviceIndex();

            if (dwDeviceIndex < 0 || dwChannelIndex < 0)
            {
                return;
            }

            Int32 dwIndex = VideoStreamIndexCobBox.SelectedIndex;
            if (dwIndex < 0 || dwIndex > 2)
            {
                return;
            }

            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_VMS != m_deviceInfoList[dwDeviceIndex].m_eDeviceType)
            {
                NETDEV_VIDEO_STREAM_INFO_S stStreamInfo = m_deviceInfoList[dwDeviceIndex].m_channelInfoList[dwChannelIndex].m_videoStreamInfo.videoStreamInfoList[dwIndex];

                stStreamInfo.enStreamType = (NETDEV_LIVE_STREAM_INDEX_E)dwIndex;
                stStreamInfo.dwBitRate = Convert.ToInt32(VideoBitRateText.Text);
                stStreamInfo.dwFrameRate = Convert.ToInt32(VideoFrameRateText.Text);
                stStreamInfo.dwGop = Convert.ToInt32(VideoGopText.Text);

                stStreamInfo.enQuality = (NETDEV_VIDEO_QUALITY_E)getVideoQualityEnmu(VideoQualityCobBox.SelectedIndex);
                stStreamInfo.dwHeight = Convert.ToInt32(VideoResolutionHText.Text);
                stStreamInfo.dwWidth = Convert.ToInt32(VideoResolutionWText.Text);
                stStreamInfo.enCodeType = (NETDEV_VIDEO_CODE_TYPE_E)Convert.ToInt32(VideoEncodeFormatCobBox.SelectedIndex);

                m_config.saveVideoInfo(stStreamInfo);
                m_deviceInfoList[dwDeviceIndex].m_channelInfoList[dwChannelIndex].m_videoStreamInfo.videoStreamInfoList[dwIndex] = stStreamInfo;
            }
        }

        /*video Info
         * Video
         */
        private void VideoRefreshBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex >= 0 && m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle != IntPtr.Zero)
            {
                m_config.refreshVideoInfo();
            }
        }

        /*video Info
         * Stream Index SelectedIndexChanged
         */
        private void VideoStreamIndexCobBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[getChannelIndex()].m_videoStreamInfo.existFlag == true)
            {
                showVideoInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[getChannelIndex()].m_videoStreamInfo.videoStreamInfoList[(sender as ComboBox).SelectedIndex]);
            }
        }

        /* video Info
         * Video
         */
        public void showVideoInfo(NETDEV_VIDEO_STREAM_INFO_S videoStreamInfo)
        {
            VideoBitRateText.Text = Convert.ToString(videoStreamInfo.dwBitRate);
            VideoFrameRateText.Text = Convert.ToString(videoStreamInfo.dwFrameRate);
            VideoGopText.Text = Convert.ToString(videoStreamInfo.dwGop);
            VideoResolutionHText.Text = Convert.ToString(videoStreamInfo.dwHeight);
            VideoResolutionWText.Text = Convert.ToString(videoStreamInfo.dwWidth);
            VideoQualityCobBox.SelectedIndex = getVideoQualityComboIndex(videoStreamInfo.enQuality);
            VideoEncodeFormatCobBox.SelectedIndex = (int)videoStreamInfo.enCodeType;
            VideoStreamIndexCobBox.SelectedIndex = (int)videoStreamInfo.enStreamType;
        }

        /* video Info
         * enQualityenQuality
         */
        private int getVideoQualityComboIndex(NETDEV_VIDEO_QUALITY_E enQuality)
        {
            for (int i = 0; i < NetDevSdk.gastVideoQualityMap.Length; i++)
            {
                if (enQuality == NetDevSdk.gastVideoQualityMap[i])
                {
                    return i;
                }
            }
            return 0;
        }

        /* video Info
         * enQualityenQuality
         */
        private NETDEV_VIDEO_QUALITY_E getVideoQualityEnmu(int enQualityindex)
        {
            return NetDevSdk.gastVideoQualityMap[enQualityindex];
        }


        /*Image Info
         * Image
         */
        private void ImageSaveBtn_Click(object sender, EventArgs e)
        {
            NETDEV_IMAGE_SETTING_S stImageInfo = new NETDEV_IMAGE_SETTING_S();
            stImageInfo.dwBrightness = BrightnessTrackBar.Value;
            stImageInfo.dwContrast = ContrastTrackBar.Value;
            stImageInfo.dwSaturation = SaturationTrackBar.Value;
            stImageInfo.dwSharpness = SharpnessTrackBar.Value;

            if (m_CurSelectTreeNodeInfo.dwDeviceIndex >= 0 && m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle != IntPtr.Zero)
            {
                m_config.saveImageInfo(stImageInfo);
            }
        }

        /*Image Info
         * Image
         */
        private void ImageRefreshBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex >= 0 && m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle != IntPtr.Zero)
            {
                m_config.refreshImageInfo();
            }
        }

        /* Image Info
         * Image
         */
        public void showImageInfo(NETDEV_IMAGE_SETTING_S stImageInfo)
        {
            BrightnessText.Text = Convert.ToString(stImageInfo.dwBrightness);
            ContrastText.Text = Convert.ToString(stImageInfo.dwContrast);
            SaturationText.Text = Convert.ToString(stImageInfo.dwSaturation);
            SharpnessText.Text = Convert.ToString(stImageInfo.dwSharpness);

            BrightnessTrackBar.Value = stImageInfo.dwBrightness;
            ContrastTrackBar.Value = stImageInfo.dwContrast;
            SaturationTrackBar.Value = stImageInfo.dwSaturation;
            SharpnessTrackBar.Value = stImageInfo.dwSharpness;
        }

        private void BrightnessTrackBar_Scroll(object sender, EventArgs e)
        {
            this.BrightnessText.Text = Convert.ToString((sender as TrackBar).Value);
        }

        private void SaturationTrackBar_Scroll(object sender, EventArgs e)
        {
            this.SaturationText.Text = Convert.ToString((sender as TrackBar).Value);
        }

        private void ContrastTrackBar_Scroll(object sender, EventArgs e)
        {
            this.ContrastText.Text = Convert.ToString((sender as TrackBar).Value);
        }

        private void SharpnessTrackBar_Scroll(object sender, EventArgs e)
        {
            this.SharpnessText.Text = Convert.ToString((sender as TrackBar).Value);
        }

        private void BrightnessText_TextChanged(object sender, EventArgs e)
        {
            int value = 0;
            try
            {
                value = Convert.ToInt32(this.BrightnessText.Text);
            }
            catch (FormatException)
            {
                return;
            }

            if (value < 0 || value > 255)
            {
                return;
            }

            this.BrightnessTrackBar.Value = value;
        }

        private void SaturationText_TextChanged(object sender, EventArgs e)
        {
            int value = 0;
            try
            {
                value = Convert.ToInt32(this.SaturationText.Text);
            }
            catch (FormatException)
            {
                return;
            }

            if (value < 0 || value > 255)
            {
                return;
            }

            this.SaturationTrackBar.Value = value;
        }

        private void ContrastText_TextChanged(object sender, EventArgs e)
        {
            int value = 0;
            try
            {
                value = Convert.ToInt32(this.ContrastText.Text);
            }
            catch (FormatException)
            {
                return;
            }

            if (value < 0 || value > 255)
            {
                return;
            }

            this.ContrastTrackBar.Value = value;
        }

        private void SharpnessText_TextChanged(object sender, EventArgs e)
        {
            int value = 0;
            try
            {
                value = Convert.ToInt32(this.SharpnessText.Text);
            }
            catch (FormatException)
            {
                return;
            }

            if (value < 0 || value > 255)
            {
                return;
            }

            this.SharpnessTrackBar.Value = value;
        }

        /*OSD Info
         * OSD
         */
        private void OSDSaveBtn_Click(object sender, EventArgs e)
        {
            NETDEV_VIDEO_OSD_CFG_S stOSDInfo = new NETDEV_VIDEO_OSD_CFG_S();
            stOSDInfo.astTextOverlay = new NETDEV_OSD_TEXT_OVERLAY_S[NetDevSdk.NETDEV_OSD_TEXTOVERLAY_NUM];

            /* Time */
            stOSDInfo.stTimeOSD.bEnableFlag = 1;//Convert.ToInt32(this.OSDTimeCheckBox.Checked);
            stOSDInfo.stTimeOSD.stAreaScope.dwLocateX = Convert.ToInt32(this.OSDTimePointXText.Text);
            stOSDInfo.stTimeOSD.stAreaScope.dwLocateY = Convert.ToInt32(this.OSDTimePointYText.Text);
            stOSDInfo.stTimeOSD.udwDateFormat = (UInt32)this.OSDDateCobBox.SelectedIndex;
            stOSDInfo.stTimeOSD.udwTimeFormat = (UInt32)this.OSDTimeCobBox.SelectedIndex;

            /* NAME */
            stOSDInfo.stNameOSD.bEnableFlag = 1;//Convert.ToInt32(OSDNameCheckBox.Checked);
            GetUTF8Buffer(OSDNameText.Text, NetDevSdk.NETDEV_OSD_TEXT_MAX_LEN, out stOSDInfo.stNameOSD.OSDText);
            stOSDInfo.stNameOSD.stAreaScope.dwLocateX = Convert.ToInt32(OSDNamePointXText.Text);
            stOSDInfo.stNameOSD.stAreaScope.dwLocateY = Convert.ToInt32(OSDNamePointYText.Text);

            /* Text */
            stOSDInfo.astTextOverlay[0].bEnableFlag = 1;// Convert.ToInt32(OSDText1CheckBox.Checked);
            GetUTF8Buffer(OSDText1.Text, NetDevSdk.NETDEV_OSD_TEXT_MAX_LEN, out stOSDInfo.astTextOverlay[0].OSDText);
            stOSDInfo.astTextOverlay[0].stAreaScope.dwLocateX = Convert.ToInt32(OSDText1PointX.Text);
            stOSDInfo.astTextOverlay[0].stAreaScope.dwLocateY = Convert.ToInt32(OSDText1PointY.Text);

            stOSDInfo.astTextOverlay[1].bEnableFlag = 1;// Convert.ToInt32(OSDText2CheckBox.Checked);
            GetUTF8Buffer(OSDText2.Text, NetDevSdk.NETDEV_OSD_TEXT_MAX_LEN, out stOSDInfo.astTextOverlay[1].OSDText);
            stOSDInfo.astTextOverlay[1].stAreaScope.dwLocateX = Convert.ToInt32(OSDText2PointX.Text);
            stOSDInfo.astTextOverlay[1].stAreaScope.dwLocateY = Convert.ToInt32(OSDText2PointY.Text);

            stOSDInfo.astTextOverlay[2].bEnableFlag = 1;// Convert.ToInt32(OSDText3CheckBox.Checked);
            GetUTF8Buffer(OSDText3.Text, NetDevSdk.NETDEV_OSD_TEXT_MAX_LEN, out stOSDInfo.astTextOverlay[2].OSDText);
            stOSDInfo.astTextOverlay[2].stAreaScope.dwLocateX = Convert.ToInt32(OSDText3PointX.Text);
            stOSDInfo.astTextOverlay[2].stAreaScope.dwLocateY = Convert.ToInt32(OSDText3PointY.Text);

            stOSDInfo.astTextOverlay[3].bEnableFlag = 1;// Convert.ToInt32(OSDText4CheckBox.Checked);
            GetUTF8Buffer(OSDText4.Text, NetDevSdk.NETDEV_OSD_TEXT_MAX_LEN, out stOSDInfo.astTextOverlay[3].OSDText);
            stOSDInfo.astTextOverlay[3].stAreaScope.dwLocateX = Convert.ToInt32(OSDText4PointX.Text);
            stOSDInfo.astTextOverlay[3].stAreaScope.dwLocateY = Convert.ToInt32(OSDText4PointY.Text);

            stOSDInfo.astTextOverlay[4].bEnableFlag = 1;// Convert.ToInt32(OSDText5CheckBox.Checked);
            GetUTF8Buffer(OSDText5.Text, NetDevSdk.NETDEV_OSD_TEXT_MAX_LEN, out stOSDInfo.astTextOverlay[4].OSDText);
            stOSDInfo.astTextOverlay[4].stAreaScope.dwLocateX = Convert.ToInt32(OSDText5PointX.Text);
            stOSDInfo.astTextOverlay[4].stAreaScope.dwLocateY = Convert.ToInt32(OSDText5PointY.Text);

            stOSDInfo.astTextOverlay[5].bEnableFlag = 1;// Convert.ToInt32(OSDText6CheckBox.Checked);
            GetUTF8Buffer(OSDText6.Text, NetDevSdk.NETDEV_OSD_TEXT_MAX_LEN, out stOSDInfo.astTextOverlay[5].OSDText);
            stOSDInfo.astTextOverlay[5].stAreaScope.dwLocateX = Convert.ToInt32(OSDText6PointX.Text);
            stOSDInfo.astTextOverlay[5].stAreaScope.dwLocateY = Convert.ToInt32(OSDText6PointY.Text);

            stOSDInfo.wTextNum = 6;
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex >= 0 && m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle != IntPtr.Zero)
            {
                m_config.saveOSDInfo(stOSDInfo);
            }
        }

        /*OSD Info
         * OSD
         */
        private void OSDRefreshBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex >= 0 && m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle != IntPtr.Zero)
            {
                m_config.refreshOSDInfo();
            }
        }

        /*OSD Info
         * OSD
         */
        public void showOSDInfo(NETDEV_VIDEO_OSD_CFG_S stOSDInfo)
        {
            /* Time */
            this.OSDTimeCheckBox.Checked = Convert.ToBoolean(stOSDInfo.stTimeOSD.bEnableFlag);
            this.OSDTimePointXText.Text = Convert.ToString(stOSDInfo.stTimeOSD.stAreaScope.dwLocateX);
            this.OSDTimePointYText.Text = Convert.ToString(stOSDInfo.stTimeOSD.stAreaScope.dwLocateY);
            this.OSDDateCobBox.SelectedIndex = (int)stOSDInfo.stTimeOSD.udwDateFormat;
            this.OSDTimeCobBox.SelectedIndex = (int)stOSDInfo.stTimeOSD.udwTimeFormat;

            /* NAME */
            OSDNameCheckBox.Checked = Convert.ToBoolean(stOSDInfo.stNameOSD.bEnableFlag);
            OSDNameText.Text = GetDefaultString(stOSDInfo.stNameOSD.OSDText);
            OSDNamePointXText.Text = Convert.ToString(stOSDInfo.stNameOSD.stAreaScope.dwLocateX);
            OSDNamePointYText.Text = Convert.ToString(stOSDInfo.stNameOSD.stAreaScope.dwLocateY);

            /* Text */
            OSDText1CheckBox.Checked = Convert.ToBoolean(stOSDInfo.astTextOverlay[0].bEnableFlag);
            OSDText1.Text = GetDefaultString(stOSDInfo.astTextOverlay[0].OSDText);
            OSDText1PointX.Text = Convert.ToString(stOSDInfo.astTextOverlay[0].stAreaScope.dwLocateX);
            OSDText1PointY.Text = Convert.ToString(stOSDInfo.astTextOverlay[0].stAreaScope.dwLocateY);

            OSDText2CheckBox.Checked = Convert.ToBoolean(stOSDInfo.astTextOverlay[1].bEnableFlag);
            OSDText2.Text = GetDefaultString(stOSDInfo.astTextOverlay[1].OSDText);
            OSDText2PointX.Text = Convert.ToString(stOSDInfo.astTextOverlay[1].stAreaScope.dwLocateX);
            OSDText2PointY.Text = Convert.ToString(stOSDInfo.astTextOverlay[1].stAreaScope.dwLocateY);

            OSDText3CheckBox.Checked = Convert.ToBoolean(stOSDInfo.astTextOverlay[2].bEnableFlag);
            OSDText3.Text = GetDefaultString(stOSDInfo.astTextOverlay[2].OSDText);
            OSDText3PointX.Text = Convert.ToString(stOSDInfo.astTextOverlay[2].stAreaScope.dwLocateX);
            OSDText3PointY.Text = Convert.ToString(stOSDInfo.astTextOverlay[2].stAreaScope.dwLocateY);

            OSDText4CheckBox.Checked = Convert.ToBoolean(stOSDInfo.astTextOverlay[3].bEnableFlag);
            OSDText4.Text = GetDefaultString(stOSDInfo.astTextOverlay[3].OSDText);
            OSDText4PointX.Text = Convert.ToString(stOSDInfo.astTextOverlay[3].stAreaScope.dwLocateX);
            OSDText4PointY.Text = Convert.ToString(stOSDInfo.astTextOverlay[3].stAreaScope.dwLocateY);

            OSDText5CheckBox.Checked = Convert.ToBoolean(stOSDInfo.astTextOverlay[4].bEnableFlag);
            OSDText5.Text = GetDefaultString(stOSDInfo.astTextOverlay[4].OSDText);
            OSDText5PointX.Text = Convert.ToString(stOSDInfo.astTextOverlay[4].stAreaScope.dwLocateX);
            OSDText5PointY.Text = Convert.ToString(stOSDInfo.astTextOverlay[4].stAreaScope.dwLocateY);

            OSDText6CheckBox.Checked = Convert.ToBoolean(stOSDInfo.astTextOverlay[5].bEnableFlag);
            OSDText6.Text = GetDefaultString(stOSDInfo.astTextOverlay[5].OSDText);
            OSDText6PointX.Text = Convert.ToString(stOSDInfo.astTextOverlay[5].stAreaScope.dwLocateX);
            OSDText6PointY.Text = Convert.ToString(stOSDInfo.astTextOverlay[5].stAreaScope.dwLocateY);
        }

        //Alarm out
        private void IOAlarmOutputTriggerBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0 || m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle == IntPtr.Zero)
            {
                return;
            }

            Int32 dwIndex = IOAlarmOutputIndexCobBox.SelectedIndex;
            if (dwIndex < 0 || dwIndex > NetDevSdk.NETDEV_MAX_ALARM_OUT_NUM)
            {
                return;
            }

            NETDEV_TRIGGER_ALARM_OUTPUT_S stTriggerAlarmOutput = new NETDEV_TRIGGER_ALARM_OUTPUT_S();
            stTriggerAlarmOutput.szName = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[getChannelIndex()].m_IOInfo.stOutPutInfo.astAlarmOutputInfo[dwIndex].szName;

            stTriggerAlarmOutput.enOutputState = NETDEV_RELAYOUTPUT_STATE_E.NETDEV_BOOLEAN_STATUS_ACTIVE;

            int iRet = NETDEVSDK.NETDEV_SetDevConfig(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle, getChannelID(), (int)NETDEV_CONFIG_COMMAND_E.NETDEV_TRIGGER_ALARM_OUTPUT, ref stTriggerAlarmOutput, Marshal.SizeOf(stTriggerAlarmOutput));
            if (NetDevSdk.TRUE != iRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Trigger alarm out", NETDEVSDK.NETDEV_GetLastError());
                return;
            }

            showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Trigger alarm out");
        }

        //Alarm out
        private void IOAlarmOutputSaveBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0 || m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle == IntPtr.Zero)
            {
                return;
            }

            Int32 dwIndex = IOAlarmOutputIndexCobBox.SelectedIndex;
            if (dwIndex < 0 || dwIndex > NetDevSdk.NETDEV_MAX_ALARM_OUT_NUM)
            {
                return;
            }

            NETDEV_ALARM_OUTPUT_INFO_S stAlarmOutputInfo = new NETDEV_ALARM_OUTPUT_INFO_S();

            stAlarmOutputInfo.dwChancelId = Convert.ToInt32(this.IOAlarmOutputChannelID.Text);
            stAlarmOutputInfo.dwDurationSec = Convert.ToInt32(IOAlarmOutputDelayText.Text);
            if ((int)NETDEV_BOOLEAN_MODE_E.NETDEV_BOOLEAN_MODE_OPEN - 1 == IOAlarmOutputStatusCobBox.SelectedIndex)
            {
                stAlarmOutputInfo.enDefaultStatus = (int)NETDEV_BOOLEAN_MODE_E.NETDEV_BOOLEAN_MODE_OPEN;
            }
            else
            {
                stAlarmOutputInfo.enDefaultStatus = (int)NETDEV_BOOLEAN_MODE_E.NETDEV_BOOLEAN_MODE_CLOSE;
            }

            stAlarmOutputInfo.szName = this.IOAlarmOutputNameText.Text;
            if (true == m_config.saveAlarmOutputInfo(stAlarmOutputInfo))
            {

                m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[getChannelIndex()].m_IOInfo.stOutPutInfo.astAlarmOutputInfo[dwIndex] = stAlarmOutputInfo;
            }
        }

        //Refreash
        private void IORefreshBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex >= 0 && m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle != IntPtr.Zero)
            {
                m_config.refreshIOInfo();
            }
        }

        //Alarm input
        public void showAlarmInputInfo(NETDEV_ALARM_INPUT_LIST_S stAlarmInputList)
        {
            IOAlarmInputListView.Items.Clear();
            for (Int32 i = 0; i < stAlarmInputList.dwSize; i++)
            {
                ListViewItem item = new ListViewItem(stAlarmInputList.astAlarmInputInfo[i].szName);
                this.IOAlarmInputListView.Items.Add(item);
            }
        }

        //Alarm output
        public void showAlarmOutputInfo(int index)
        {
            if (this.m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[getChannelIndex()].m_IOInfo.stOutPutInfo.dwSize <= 0)
            {
                initIOAlarmOutputCfgTab();
                return;
            }

            IOAlarmOutputIndexCobBox.Items.Clear();
            for (Int32 i = 0; i < this.m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[getChannelIndex()].m_IOInfo.stOutPutInfo.dwSize; i++)
            {
                IOAlarmOutputIndexCobBox.Items.Add(i);
            }

            IOAlarmOutputIndexCobBox.SelectedIndex = 0;
        }

        public void initIOCfgTab()
        {
            IOAlarmInputListView.Items.Clear();
            IOAlarmOutputIndexCobBox.Items.Clear();
            this.IOAlarmOutputNameText.Text = "";
            IOAlarmOutputStatusCobBox.SelectedIndex = 1;
            IOAlarmOutputChannelID.Text = "0";
            IOAlarmOutputDelayText.Text = "0";

        }

        public void initIOAlarmOutputCfgTab()
        {
            IOAlarmOutputIndexCobBox.Items.Clear();
            this.IOAlarmOutputNameText.Text = "";
            IOAlarmOutputStatusCobBox.SelectedIndex = 1;
            IOAlarmOutputChannelID.Text = "0";
            IOAlarmOutputDelayText.Text = "0";
        }

        private void IOAlarmOutputIndexCobBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 dwIndex = IOAlarmOutputIndexCobBox.SelectedIndex;

            showAlarmOutputInfoByIndex(dwIndex);
        }

        private void showAlarmOutputInfoByIndex(int index)
        {
            if (index < 0 || index > NetDevSdk.NETDEV_MAX_ALARM_OUT_NUM)
            {
                return;
            }

            IOAlarmOutputDelayText.Text = Convert.ToString(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[getChannelIndex()].m_IOInfo.stOutPutInfo.astAlarmOutputInfo[index].dwDurationSec);
            IOAlarmOutputChannelID.Text = Convert.ToString(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[getChannelIndex()].m_IOInfo.stOutPutInfo.astAlarmOutputInfo[index].dwChancelId);

            if ((int)NETDEV_BOOLEAN_MODE_E.NETDEV_BOOLEAN_MODE_OPEN == m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[getChannelIndex()].m_IOInfo.stOutPutInfo.astAlarmOutputInfo[index].enDefaultStatus)
            {
                IOAlarmOutputStatusCobBox.SelectedIndex = (int)NETDEV_BOOLEAN_MODE_E.NETDEV_BOOLEAN_MODE_OPEN - 1;
            }
            else
            {
                IOAlarmOutputStatusCobBox.SelectedIndex = (int)NETDEV_BOOLEAN_MODE_E.NETDEV_BOOLEAN_MODE_CLOSE - 1;
            }

            this.IOAlarmOutputNameText.Text = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[getChannelIndex()].m_IOInfo.stOutPutInfo.astAlarmOutputInfo[index].szName;
        }

        // Privacy Mask Info
        private void PrivacyMaskAddBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0 || m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle == IntPtr.Zero)
            {
                return;
            }

            if (privacyMaskInfoListView.Items.Count >= NetDevSdk.NETDEV_MAX_PRIVACY_MASK_AREA_NUM)
            {
                MessageBox.Show("No more mask area is allowed", "warning");
                return;
            }

            Int32 dwIndex = 0;
            Int32 dwInsertIndex = 0;
            for (Int32 i = 0; i < NetDevSdk.NETDEV_MAX_PRIVACY_MASK_AREA_NUM; i++)
            {
                dwInsertIndex = i + 1;
                if (i < privacyMaskInfoListView.Items.Count)
                {
                    dwIndex = Convert.ToInt32(privacyMaskInfoListView.Items[i].SubItems[0].Text);

                    if (dwInsertIndex >= dwIndex)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            ListViewItem item = new ListViewItem(Convert.ToString(dwInsertIndex));
            item.SubItems.Add("0");
            item.SubItems.Add("0");
            item.SubItems.Add("1000");
            item.SubItems.Add("1000");

            this.privacyMaskInfoListView.Items.Add(item);

            PrivacyMaskSaveBtn_Click(null, null);
            PrivacyMaskRefreshBtn_Click(null, null);
        }

        // Del Privacy Mask Info
        private void PrivacyMaskDelBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0 || m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle == IntPtr.Zero)
            {
                return;
            }

            if (0 == privacyMaskInfoListView.SelectedIndices.Count)
            {
                return;
            }

            int count = privacyMaskInfoListView.SelectedIndices.Count;
            while (count > 0)
            {
                m_config.deletePrivacyMaskInfo(Convert.ToInt32(privacyMaskInfoListView.SelectedItems[count - 1].SubItems[0].Text));
                privacyMaskInfoListView.Items.Remove(privacyMaskInfoListView.Items[privacyMaskInfoListView.SelectedIndices[count - 1]]);
                count--;
            }

            PrivacyMaskSaveBtn_Click(null, null);
        }

        //Save Privacy Mask Info
        private void PrivacyMaskSaveBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0 || m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle == IntPtr.Zero)
            {
                return;
            }

            NETDEV_PRIVACY_MASK_CFG_S stPrivacyMaskInfo = new NETDEV_PRIVACY_MASK_CFG_S();
            stPrivacyMaskInfo.astArea = new NETDEV_PRIVACY_MASK_AREA_INFO_S[NetDevSdk.NETDEV_MAX_PRIVACY_MASK_AREA_NUM];

            getListViewData(ref stPrivacyMaskInfo);
            m_config.savePrivacyMaskInfo(stPrivacyMaskInfo);

        }

        private void getListViewData(ref NETDEV_PRIVACY_MASK_CFG_S stPrivacyMaskInfo)
        {
            for (Int32 i = 0; i < this.privacyMaskInfoListView.Items.Count; i++)
            {
                stPrivacyMaskInfo.astArea[i].dwIndex = Convert.ToInt32(this.privacyMaskInfoListView.Items[i].SubItems[0].Text);
                Regex rx = new Regex("^[0-9]*$");
                if (rx.Match(this.privacyMaskInfoListView.Items[i].SubItems[1].Text).Success && rx.Match(this.privacyMaskInfoListView.Items[i].SubItems[2].Text).Success && rx.Match(this.privacyMaskInfoListView.Items[i].SubItems[3].Text).Success && rx.Match(this.privacyMaskInfoListView.Items[i].SubItems[4].Text).Success)
                {
                    stPrivacyMaskInfo.astArea[i].dwTopLeftX = Convert.ToInt32(this.privacyMaskInfoListView.Items[i].SubItems[1].Text);
                    stPrivacyMaskInfo.astArea[i].dwTopLeftY = Convert.ToInt32(this.privacyMaskInfoListView.Items[i].SubItems[2].Text);
                    stPrivacyMaskInfo.astArea[i].dwBottomRightX = Convert.ToInt32(this.privacyMaskInfoListView.Items[i].SubItems[3].Text);
                    stPrivacyMaskInfo.astArea[i].dwBottomRightY = Convert.ToInt32(this.privacyMaskInfoListView.Items[i].SubItems[4].Text);
                    stPrivacyMaskInfo.astArea[i].bIsEanbled = NetDevSdk.TRUE;
                }
                else
                {
                    MessageBox.Show("Must be a positive integer ");
                }
            }

            stPrivacyMaskInfo.dwSize = this.privacyMaskInfoListView.Items.Count;
        }

        //refreash Privacy Mask Info
        private void PrivacyMaskRefreshBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex >= 0 && m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle != IntPtr.Zero)
            {
                m_config.refreshPrivacyMaskInfo();
            }
        }

        //show Privacy Mask Info
        public void showPrivacyMaskInfo(NETDEV_PRIVACY_MASK_CFG_S stPrivacyMaskInfo)
        {
            privacyMaskInfoListView.Items.Clear();
            for (Int32 i = 0; i < stPrivacyMaskInfo.dwSize; i++)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(stPrivacyMaskInfo.astArea[i].dwIndex));
                item.SubItems.Add(Convert.ToString(stPrivacyMaskInfo.astArea[i].dwTopLeftX));
                item.SubItems.Add(Convert.ToString(stPrivacyMaskInfo.astArea[i].dwTopLeftY));
                item.SubItems.Add(Convert.ToString(stPrivacyMaskInfo.astArea[i].dwBottomRightX));
                item.SubItems.Add(Convert.ToString(stPrivacyMaskInfo.astArea[i].dwBottomRightY));
                item.SubItems[0].Name = "index";
                item.SubItems[1].Name = "TopLeftX";
                item.SubItems[2].Name = "TopLeftY";
                item.SubItems[3].Name = "BottomRightX";
                item.SubItems[4].Name = "BottomRightY";
                this.privacyMaskInfoListView.Items.Add(item);
            }
        }

        private void privacyMaskInfoListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Point tmpPoint = privacyMaskInfoListView.PointToClient(Cursor.Position);
            ListViewItem.ListViewSubItem subitem = privacyMaskInfoListView.HitTest(tmpPoint).SubItem;

            if (subitem != null && subitem.Name != "index")
            {
                this.privacyMaskSubItemText.Text = subitem.Text;
                this.strSubItemName = subitem.Name;
                this.iItemIndex = privacyMaskInfoListView.SelectedIndices[0];
                this.privacyMaskSubItemText.Enabled = true;
                this.privacyMaskModifyBtn.Enabled = true;
            }
            else
            {
                this.privacyMaskSubItemText.Enabled = false;
                this.privacyMaskModifyBtn.Enabled = false;
            }

        }

        // Modify Privacy Mask Info
        private void privacyMaskModifyBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < privacyMaskInfoListView.Items[this.iItemIndex].SubItems.Count; i++)
            {
                if (this.strSubItemName == privacyMaskInfoListView.Items[this.iItemIndex].SubItems[i].Name)
                {
                    privacyMaskInfoListView.Items[this.iItemIndex].SubItems[i].Text = privacyMaskSubItemText.Text;
                    this.privacyMaskSubItemText.Enabled = false;
                    this.privacyMaskModifyBtn.Enabled = false;
                }
            }
        }

        private void MotionSensitivityTrackBar_Scroll(object sender, EventArgs e)
        {
            if (MotionSensitivityTrackBar.Value > 100 || MotionSensitivityTrackBar.Value < 1)
            {
                MotionSensitivityTrackBar.Value = 50;
            }
            MotionSensitivityText.Text = Convert.ToString(MotionSensitivityTrackBar.Value);
        }

        private void MotionObjectSizeTrackBar_Scroll(object sender, EventArgs e)
        {
            if (MotionObjectSizeTrackBar.Value > 100 || MotionObjectSizeTrackBar.Value < 1)
            {
                MotionObjectSizeTrackBar.Value = 50;
            }
            MotionObjectSizeText.Text = Convert.ToString(MotionObjectSizeTrackBar.Value);
        }

        private void MotionHistoryTrackBar_Scroll(object sender, EventArgs e)
        {
            if (MotionHistoryTrackBar.Value > 100 || MotionHistoryTrackBar.Value < 1)
            {
                MotionHistoryTrackBar.Value = 50;
            }
            MotionHistoryText.Text = Convert.ToString(MotionHistoryTrackBar.Value);
        }

        private void MotionSensitivityText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(MotionSensitivityText.Text) > 100 || Convert.ToInt32(MotionSensitivityText.Text) < 1)
                {
                    MotionSensitivityText.Text = "50";
                }
            }
            catch (FormatException)
            {
                return;
            }

            MotionSensitivityTrackBar.Value = Convert.ToInt32(MotionSensitivityText.Text);
        }

        private void MotionObjectSizeText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(MotionObjectSizeText.Text) > 100 || Convert.ToInt32(MotionObjectSizeText.Text) < 1)
                {
                    MotionObjectSizeText.Text = "50";
                }
            }
            catch (FormatException)
            {
                return;
            }

            MotionObjectSizeTrackBar.Value = Convert.ToInt32(MotionObjectSizeText.Text);
        }

        private void MotionHistoryText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(MotionHistoryText.Text) > 100 || Convert.ToInt32(MotionHistoryText.Text) < 1)
                {
                    MotionHistoryText.Text = "50";
                }
            }
            catch (FormatException)
            {
                return;
            }
            MotionHistoryTrackBar.Value = Convert.ToInt32(MotionHistoryText.Text);
        }

        private void MotionSaveBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0 || m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle == IntPtr.Zero)
            {
                return;
            }

            NETDEV_MOTION_ALARM_INFO_S stMotionAlarmInfo = new NETDEV_MOTION_ALARM_INFO_S();
            stMotionAlarmInfo.awScreenInfo = new NETDEV_Int16Array[NetDevSdk.NETDEV_SCREEN_INFO_ROW];

            for (int i = 0; i < NetDevSdk.NETDEV_SCREEN_INFO_ROW; i++)
            {
                stMotionAlarmInfo.awScreenInfo[i].data = new short[NetDevSdk.NETDEV_SCREEN_INFO_COLUMN];
                for (int j = 0; j < NetDevSdk.NETDEV_SCREEN_INFO_COLUMN; j++)
                {
                    stMotionAlarmInfo.awScreenInfo[i].data[j] = 1;
                }
            }


            stMotionAlarmInfo.dwSensitivity = MotionSensitivityTrackBar.Value;
            stMotionAlarmInfo.dwObjectSize = MotionObjectSizeTrackBar.Value;
            stMotionAlarmInfo.dwHistory = MotionHistoryTrackBar.Value;
            m_config.saveMotionInfo(ref stMotionAlarmInfo);
        }

        private void MotionRefreshBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex >= 0 && m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle != IntPtr.Zero)
            {
                m_config.refreshMotionInfo();
            }
        }

        public void showMotionInfo(ref NETDEV_MOTION_ALARM_INFO_S stMotionAlarmInfo)
        {
            if (stMotionAlarmInfo.dwSensitivity > 100 || stMotionAlarmInfo.dwSensitivity < 1 ||
                stMotionAlarmInfo.dwObjectSize > 100 || stMotionAlarmInfo.dwObjectSize < 1 ||
                stMotionAlarmInfo.dwHistory > 100 || stMotionAlarmInfo.dwHistory < 1)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Get motion cfg", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            else
            {
                MotionSensitivityTrackBar.Value = stMotionAlarmInfo.dwSensitivity;
                MotionObjectSizeTrackBar.Value = stMotionAlarmInfo.dwObjectSize;
                MotionHistoryTrackBar.Value = stMotionAlarmInfo.dwHistory;

                MotionSensitivityText.Text = Convert.ToString(stMotionAlarmInfo.dwSensitivity);
                MotionObjectSizeText.Text = Convert.ToString(stMotionAlarmInfo.dwObjectSize);
                MotionHistoryText.Text = Convert.ToString(stMotionAlarmInfo.dwHistory);
            }
        }

        private void TemperSensitivityTrackBar_Scroll(object sender, EventArgs e)
        {
            if (TemperSensitivityTrackBar.Value > 100 || TemperSensitivityTrackBar.Value < 0)
            {
                TemperSensitivityTrackBar.Value = 50;
            }
            TemperSensitivityText.Text = Convert.ToString(TemperSensitivityTrackBar.Value);
        }

        private void TemperSensitivityText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(TemperSensitivityText.Text) > 100 || Convert.ToInt32(TemperSensitivityText.Text) < 0)
                {
                    TemperSensitivityText.Text = "50";
                }
            }
            catch (FormatException)
            {
                return;
            }

            TemperSensitivityTrackBar.Value = Convert.ToInt32(TemperSensitivityText.Text);
        }

        public void showTemperInfo(ref NETDEV_TAMPER_ALARM_INFO_S stTamperAlarmInfo)
        {
            TemperSensitivityText.Text = Convert.ToString(stTamperAlarmInfo.dwSensitivity);
            TemperSensitivityTrackBar.Value = stTamperAlarmInfo.dwSensitivity;
        }

        private void TemperSaveBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0 || m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle == IntPtr.Zero)
            {
                return;
            }

            NETDEV_TAMPER_ALARM_INFO_S stTamperAlarmInfo = new NETDEV_TAMPER_ALARM_INFO_S();

            stTamperAlarmInfo.dwSensitivity = TemperSensitivityTrackBar.Value;
            m_config.saveTemperInfo(stTamperAlarmInfo);
        }

        private void TemperRefreshBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex >= 0 && m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle != IntPtr.Zero)
            {
                m_config.refreshTemperInfo();
            }
        }

        public void alarmMessCallBack(IntPtr lpUserID, Int32 dwChannelID, NETDEV_ALARM_INFO_S stAlarmInfo, IntPtr lpBuf, Int32 dwBufLen, IntPtr lpUserData)
        {
            String strAlarmTime = getStrTime(stAlarmInfo.tAlarmTime);
            ListViewItem item = new ListViewItem(strAlarmTime);

            String strDeviceIP = getDeviceIP(lpUserID);
            item.SubItems.Add(strDeviceIP);

            item.SubItems.Add(Convert.ToString(dwChannelID));

            String strAlarmInfo = getAlarmInfo(stAlarmInfo.dwAlarmType);

            item.SubItems.Add(strAlarmInfo);
            AlarmRecordsListView.Items.Add(item);
        }

        public void alarmMessCallBackV30(IntPtr lpUserID, ref NETDEV_REPORT_INFO_S pstReportInfo, IntPtr lpBuf, Int32 dwBufLen, IntPtr lpUserData)
        {
            if ((int)NETDEV_REPORT_TYPE_E.NETDEV_REPORT_TYPE_EVENT == pstReportInfo.dwReportType)
            {
                for (int i = 0; i < pstReportInfo.stEventInfo.dwSize; i++)
                {
                    switch (pstReportInfo.stEventInfo.astEventRes[i].dwResType)
                    {
                        case (int)NETDEV_EVENT_RES_TYPE_E.NETDEV_EVENT_RES_TYPE_DEVICE:
                            {
                                switch (pstReportInfo.stEventInfo.dwEventActionType)
                                {
                                    case (int)NETDEV_EVENT_ACTION_TYPE_E.NETDEV_EVENT_ACTION_TYPE_ADD:
                                    case (int)NETDEV_EVENT_ACTION_TYPE_E.NETDEV_EVENT_ACTION_TYPE_MODIFY:
                                    case (int)NETDEV_EVENT_ACTION_TYPE_E.NETDEV_EVENT_ACTION_TYPE_OFFLINE:
                                    case (int)NETDEV_EVENT_ACTION_TYPE_E.NETDEV_EVENT_ACTION_TYPE_ONLINE:
                                        {
                                            updateSubDevice(lpUserID, pstReportInfo.stEventInfo.astEventRes[i].dwResID);
                                            break;
                                        }
                                    case (int)NETDEV_EVENT_ACTION_TYPE_E.NETDEV_EVENT_ACTION_TYPE_DELETE:
                                        {
                                            deleteSubDevice(lpUserID, pstReportInfo.stEventInfo.astEventRes[i].dwResID);
                                            break;
                                        }
                                    default:
                                        break;
                                }
                                break;
                            }
                        case (int)NETDEV_EVENT_RES_TYPE_E.NETDEV_EVENT_RES_TYPE_CHANNEL:
                            {
                                switch (pstReportInfo.stEventInfo.dwEventActionType)
                                {
                                    case (int)NETDEV_EVENT_ACTION_TYPE_E.NETDEV_EVENT_ACTION_TYPE_ADD:
                                    case (int)NETDEV_EVENT_ACTION_TYPE_E.NETDEV_EVENT_ACTION_TYPE_MODIFY:
                                    case (int)NETDEV_EVENT_ACTION_TYPE_E.NETDEV_EVENT_ACTION_TYPE_OFFLINE:
                                    case (int)NETDEV_EVENT_ACTION_TYPE_E.NETDEV_EVENT_ACTION_TYPE_ONLINE:
                                        {
                                            updateDeviceChannel(lpUserID, pstReportInfo.stEventInfo.astEventRes[i].dwResID);
                                            break;
                                        }
                                    case (int)NETDEV_EVENT_ACTION_TYPE_E.NETDEV_EVENT_ACTION_TYPE_DELETE:
                                        {
                                            deleteDeviceChannel(lpUserID, pstReportInfo.stEventInfo.astEventRes[i].dwResID);
                                            break;
                                        }
                                    default:
                                        break;
                                }
                                break;
                            }

                        default:
                            break;
                    }
                }
            }
            else if ((int)NETDEV_REPORT_TYPE_E.NETDEV_REPORT_TYPE_ALARM == pstReportInfo.dwReportType)
            {
                String strAlarmTime = getStrTime(pstReportInfo.stAlarmInfo.tAlarmTimeStamp);
                ListViewItem item = new ListViewItem(strAlarmTime);

                String strDeviceIP = getDeviceIP(lpUserID);
                item.SubItems.Add(strDeviceIP);

                item.SubItems.Add(Convert.ToString(pstReportInfo.stAlarmInfo.dwChannelID));

                String strAlarmInfo = getAlarmInfo(pstReportInfo.stAlarmInfo.dwAlarmType);

                item.SubItems.Add(strAlarmInfo);
                this.BeginInvoke(new Action(() =>
                {
                    AlarmRecordsListView.Items.Add(item);
                }));
            }
        }

        public void exceptionCallBack(IntPtr lpUserID, Int32 dwType, IntPtr lpExpHandle, IntPtr lpUserData)
        {
            String strAlarmTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            ListViewItem item = new ListViewItem(strAlarmTime);

            String strDeviceIP = getDeviceIP(lpUserID);
            item.SubItems.Add(strDeviceIP);

            item.SubItems.Add("");
            String strAlarmInfo = getAlarmInfo(dwType);
            item.SubItems.Add(strAlarmInfo);
            AlarmRecordsListView.Items.Add(item);

            if ((int)NETDEV_EXCEPTION_TYPE_E.NETDEV_EXCEPTION_EXCHANGE == dwType)
            {
                for (int dwIndex = 0; dwIndex < m_deviceInfoList.Count; dwIndex++)
                {
                    if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_INVALID == m_deviceInfoList[dwIndex].m_eDeviceType)
                    {
                        continue;
                    }

                    if (m_deviceInfoList[dwIndex].m_lpDevHandle == lpUserID)
                    {
                        closeSelectedDeviceRealPlay(m_deviceInfoList[dwIndex], dwIndex, false);
                    }
                }
            }
        }

        private void NETDEV_ConflagrationAlarmMessCallBack(IntPtr lpHandle, ref NETDEV_CONFLAGRATION_ALARM_INFO_S pstAlarmInfo, IntPtr lpUserParam)
        {

        }

        private void FaceSnapshotCallBack(IntPtr lpUserID, ref NETDEV_TMS_FACE_SNAPSHOT_PIC_INFO_S pstFaceSnapShotData, IntPtr lpUserParam)
        {
            String strNowTime = DateTime.Now.ToString("HH-mm-ss-ms");
            String strFileName = strNowTime + "_" + pstFaceSnapShotData.udwFaceId.ToString() + "face.jpg";

            byte[] array = new byte[pstFaceSnapShotData.udwPicBuffLen];
            NETDEVSDK.MemCopy(array, pstFaceSnapShotData.pcPicBuff, pstFaceSnapShotData.udwPicBuffLen);

            FileStream fs = new FileStream(strFileName, FileMode.Create);
            //将byte数组写入文件中
            fs.Write(array, 0, array.Length);
            //所有流类型都要关闭流，否则会出现内存泄露问题
            fs.Close();
        }

        private void CarPlateCallBack(IntPtr lpHandle, ref NETDEV_TMS_CAR_PLATE_INFO_S pstCarPlateData, IntPtr lpUserParam)
        {
            for (Int32 i = 0; i < pstCarPlateData.udwPicNum; i++)
            {
                String strRecordID = Encoding.Default.GetString(pstCarPlateData.stTmsXmlInfo.szRecordID);
                strRecordID = strRecordID.Replace("\0".ToString(), String.Empty);
                Int32 dwRecordID = Convert.ToInt32(strRecordID);
                String strPassTime = Encoding.Default.GetString(pstCarPlateData.stTmsXmlInfo.szPassTime);
                strPassTime = strPassTime.Replace("\0".ToString(), String.Empty);
                String strCarPlate = GetDefaultString(pstCarPlateData.stTmsXmlInfo.szCarPlate);
                String strFileName = strPassTime + "_" + dwRecordID.ToString() + "_" + i.ToString() + "_" + pstCarPlateData.stTmsXmlInfo.dwCarPlateColor.ToString() + "_" + strCarPlate + ".jpg";

                byte[] array = new byte[pstCarPlateData.stTmsPicInfo[i].udwPicSize];
                NETDEVSDK.MemCopy(array, pstCarPlateData.stTmsPicInfo[i].pcPicData, pstCarPlateData.stTmsPicInfo[i].udwPicSize);

                FileStream fs = new FileStream(strFileName, FileMode.Create);
                fs.Write(array, 0, array.Length);
                fs.Close();
            }
        }

        private void PersonAlarmCallBack(IntPtr lpUserID, ref NETDEV_PERSON_EVENT_INFO_S pstAlarmData, IntPtr lpUserData)
        {
            if (pstAlarmData.udwFaceInfoNum > 0)
            {
                snapshotPictureBox.Image = null;
                snapshotPictureBox.Refresh();
                personLibPictureBox.Image = null;
                personLibPictureBox.Refresh();

                string strAlarmTime = getStrTime(pstAlarmData.stCtrlFaceInfo[0].tPassingTime);
                string strPersonName = GetDefaultString(pstAlarmData.stCtrlFaceInfo[0].stCompareInfo.stPersonInfo.szPersonName);
                string strIDNo = pstAlarmData.stCtrlFaceInfo[0].stCompareInfo.stPersonInfo.stIdentificationInfo[0].szNumber;
                string strMatch = "";
                if ((uint)NETDEV_FACE_PASS_RECORD_TYPE_E.NETDEV_TYPE_FACE_PASS_COM_SUCCESS == pstAlarmData.stCtrlFaceInfo[0].udwType)
                {
                    strMatch = "Match";
                }
                else
                {
                    strMatch = "No Match";
                }
                string strAlarmSource = "Chl_" + Convert.ToString(pstAlarmData.stCtrlFaceInfo[0].udwChannelID) + "_" + GetDefaultString(pstAlarmData.stCtrlFaceInfo[0].szChlName);

                string strSimilarity = Convert.ToString(pstAlarmData.stCtrlFaceInfo[0].stCompareInfo.udwSimilarity);

                if (pstAlarmData.stCtrlFaceInfo[0].stCompareInfo.stPersonInfo.stImageInfo[0].stFileInfo.udwSize > 0
                    && pstAlarmData.stCtrlFaceInfo[0].stCompareInfo.stPersonInfo.stImageInfo[0].stFileInfo.pcData != IntPtr.Zero)
                {
                    byte[] szLibFacePicInfo = new byte[pstAlarmData.stCtrlFaceInfo[0].stCompareInfo.stPersonInfo.stImageInfo[0].stFileInfo.udwSize];
                    if (pstAlarmData.stCtrlFaceInfo[0].stCompareInfo.stPersonInfo.udwImageNum > 0)
                    {
                        Marshal.Copy(pstAlarmData.stCtrlFaceInfo[0].stCompareInfo.stPersonInfo.stImageInfo[0].stFileInfo.pcData, szLibFacePicInfo, 0, (int)pstAlarmData.stCtrlFaceInfo[0].stCompareInfo.stPersonInfo.stImageInfo[0].stFileInfo.udwSize);
                    }

                    this.BeginInvoke(new Action(() =>
                    {
                        using (MemoryStream stream = new MemoryStream(szLibFacePicInfo))
                        {
                            try
                            {
                                Image libFaceImage = Image.FromStream(stream);
                                personLibPictureBox.Image = libFaceImage;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                        }
                    }));
                }

                if (pstAlarmData.stCtrlFaceInfo[0].stCompareInfo.stFaceImage.udwSize > 0
                    && pstAlarmData.stCtrlFaceInfo[0].stCompareInfo.stFaceImage.pcData != IntPtr.Zero)
                {
                    byte[] szSnapshotFacePicInfo = new byte[pstAlarmData.stCtrlFaceInfo[0].stCompareInfo.stFaceImage.udwSize];
                    Marshal.Copy(pstAlarmData.stCtrlFaceInfo[0].stCompareInfo.stFaceImage.pcData, szSnapshotFacePicInfo, 0, (int)pstAlarmData.stCtrlFaceInfo[0].stCompareInfo.stFaceImage.udwSize);

                    this.BeginInvoke(new Action(() =>
                    {
                        using (MemoryStream stream = new MemoryStream(szSnapshotFacePicInfo))
                        {
                            try
                            {
                                Image snapshotFaceImage = Image.FromStream(stream);
                                snapshotPictureBox.Image = snapshotFaceImage;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                        }

                    }));
                }


                this.BeginInvoke(new Action(() =>
                {
                    ListViewItem item = new ListViewItem(strAlarmTime);
                    item.SubItems.Add(strPersonName);
                    item.SubItems.Add(strIDNo);
                    item.SubItems.Add(strMatch);
                    item.SubItems.Add(strAlarmSource);

                    this.faceRecogAlarmRecordsListView.Items.Insert(0, item);

                    similarityLab.Text = strSimilarity + "%";
                }));
            }
        }

        private void VehicleAlarmCallBack(IntPtr lpUserID, ref NETDEV_VEH_RECOGNITION_EVENT_S pstVehicleAlarmInfo, IntPtr lpBuf, Int32 dwBufLen, IntPtr lpUserData)
        {
            Int32 bRet = NetDevSdk.FALSE;

            if (pstVehicleAlarmInfo.stVehicleEventInfo.udwVehicleInfoNum > 0)
            {
                vehiclePanoRecogPicBox.Image = null;
                vehiclePanoRecogPicBox.Refresh();
                plateRecogPicBox.Image = null;
                plateRecogPicBox.Refresh();

                string strPlateNo = "";
                string strPlateColor = "";
                string strMatch = "";
                string strPlateType = "";
                string strVehicleColor = "";
                string strCamreaName = "";
                string strSnapshotTime = "";
                string strCause = "";

                NETDEV_VEHICLE_RECORD_INFO_S[] stVehicleRecordInfoList = new NETDEV_VEHICLE_RECORD_INFO_S[pstVehicleAlarmInfo.stVehicleEventInfo.udwVehicleInfoNum];
                for (int i = 0; i < pstVehicleAlarmInfo.stVehicleEventInfo.udwVehicleInfoNum; i++)
                {
                    IntPtr pstVehicleRecordInfoTemp = new IntPtr(pstVehicleAlarmInfo.stVehicleEventInfo.pstVehicleRecordInfo.ToInt32() + Marshal.SizeOf(typeof(NETDEV_VEHICLE_RECORD_INFO_S)) * i);
                    stVehicleRecordInfoList[i] = (NETDEV_VEHICLE_RECORD_INFO_S)Marshal.PtrToStructure(pstVehicleRecordInfoTemp, typeof(NETDEV_VEHICLE_RECORD_INFO_S));
                }

                strPlateNo = GetDefaultString(stVehicleRecordInfoList[0].stPlateAttr.szPlateNo);
                for (int i = 0; i < NetDevSdk.gastNETDemoPlateColor.Length; i++)
                {
                    if (stVehicleRecordInfoList[0].stPlateAttr.udwColor == NetDevSdk.gastNETDemoPlateColor[i].dwPlateColor)
                    {
                        strPlateColor = NetDevSdk.gastNETDemoPlateColor[i].strPlateColor;
                        break;
                    }
                }

                if (0 == stVehicleRecordInfoList[0].stMonitorAlarmInfo.udwMonitorAlarmType)
                {
                    strMatch = "Match Alarm";
                    strCause = vehicleCauseCmbBox.Items[(int)stVehicleRecordInfoList[0].stMonitorAlarmInfo.udwMonitorReason].ToString();
                }
                else
                {
                    strMatch = "Not Match Alarm";
                }

                for (int i = 0; i < NetDevSdk.gastNETDemoPlateType.Length; i++)
                {
                    if (stVehicleRecordInfoList[0].stPlateAttr.udwType == NetDevSdk.gastNETDemoPlateType[i].dwPlateType)
                    {
                        strPlateType = NetDevSdk.gastNETDemoPlateType[i].strPlateType;
                        break;
                    }
                }

                for (int i = 0; i < NetDevSdk.gastNETDemoPlateColor.Length; i++)
                {
                    if (stVehicleRecordInfoList[0].stVehAttr.udwColor == NetDevSdk.gastNETDemoPlateColor[i].dwPlateColor)
                    {
                        strVehicleColor = NetDevSdk.gastNETDemoPlateColor[i].strPlateColor;
                        break;
                    }
                }

                strCamreaName = GetDefaultString(stVehicleRecordInfoList[0].szChannelName);
                strSnapshotTime = getStrTime(stVehicleRecordInfoList[0].udwPassingTime);

                /* Vehicle picture */
                if (stVehicleRecordInfoList[0].stVehicleImage.udwSize > 0
                    && stVehicleRecordInfoList[0].stVehicleImage.pcData != IntPtr.Zero)
                {
                    byte[] szVehiclePicInfo = new byte[stVehicleRecordInfoList[0].stVehicleImage.udwSize];
                    Marshal.Copy(stVehicleRecordInfoList[0].stVehicleImage.pcData, szVehiclePicInfo, 0, (int)stVehicleRecordInfoList[0].stVehicleImage.udwSize);
                }

                /* License plate picture */
                if (stVehicleRecordInfoList[0].stPlateImage.udwSize > 0
                    && stVehicleRecordInfoList[0].stPlateImage.pcData != IntPtr.Zero)
                {
                    byte[] szPlatePicInfo = new byte[stVehicleRecordInfoList[0].stPlateImage.udwSize];
                    Marshal.Copy(stVehicleRecordInfoList[0].stPlateImage.pcData, szPlatePicInfo, 0, (int)stVehicleRecordInfoList[0].stPlateImage.udwSize);

                    this.BeginInvoke(new Action(() =>
                    {
                        using (MemoryStream stream = new MemoryStream(szPlatePicInfo))
                        {
                            try
                            {
                                plateRecogPicBox.Image = Image.FromStream(stream);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                        }
                    }));
                }

                /* Panoramic Image */
                if (stVehicleRecordInfoList[0].stPanoImage.udwSize > 0
                    && stVehicleRecordInfoList[0].stPanoImage.pcData != IntPtr.Zero)
                {
                    byte[] szVehiclePanoPicInfo = new byte[stVehicleRecordInfoList[0].stPanoImage.udwSize];
                    Marshal.Copy(stVehicleRecordInfoList[0].stPanoImage.pcData, szVehiclePanoPicInfo, 0, (int)stVehicleRecordInfoList[0].stPanoImage.udwSize);

                    this.BeginInvoke(new Action(() =>
                    {
                        using (MemoryStream stream = new MemoryStream(szVehiclePanoPicInfo))
                        {
                            try
                            {
                                vehiclePanoRecogPicBox.Image = Image.FromStream(stream);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                        }
                    }));
                }
                else
                {
                    NETDEV_FILE_INFO_S stFileInfo = new NETDEV_FILE_INFO_S();
                    stFileInfo.pcData = Marshal.AllocHGlobal(NetDevSdk.NETDEMO_SMALL_IMAGE_SIZE);
                    stFileInfo.udwSize = NetDevSdk.NETDEMO_SMALL_IMAGE_SIZE;
                    bRet = NETDEVSDK.NETDEV_GetVehicleRecordImageInfo(lpUserID, stVehicleRecordInfoList[0].udwRecordID, ref stFileInfo);
                    if (bRet == NetDevSdk.TRUE)
                    {
                        if (stFileInfo.udwSize > 0
                            && stFileInfo.pcData != IntPtr.Zero)
                        {
                            byte[] szVehiclePanoPicInfo = new byte[stFileInfo.udwSize];
                            Marshal.Copy(stFileInfo.pcData, szVehiclePanoPicInfo, 0, (int)stFileInfo.udwSize);

                            this.BeginInvoke(new Action(() =>
                            {
                                using (MemoryStream stream = new MemoryStream(szVehiclePanoPicInfo))
                                {
                                    try
                                    {
                                        vehiclePanoRecogPicBox.Image = Image.FromStream(stream);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex);
                                    }
                                }
                            }));
                        }
                    }
                    Marshal.FreeHGlobal(stFileInfo.pcData);
                }

                this.BeginInvoke(new Action(() =>
                {
                    ListViewItem item = new ListViewItem(strPlateNo);
                    item.SubItems.Add(strSnapshotTime);
                    item.SubItems.Add(strPlateColor);
                    item.SubItems.Add(strMatch);
                    item.SubItems.Add(strPlateType);
                    item.SubItems.Add(strVehicleColor);
                    item.SubItems.Add(strCamreaName);
                    item.SubItems.Add(strCause);

                    this.LPRAlarmRecordsListView.Items.Insert(0, item);

                    plateNoRecogLab.Text = strPlateNo;
                }));
            }
        }

        private void StructAlarmCallBack(IntPtr lpUserID, ref NETDEV_STRUCT_ALARM_INFO_S pstAlarmInfo, ref NETDEV_STRUCT_DATA_INFO_S pstAlarmData, IntPtr lpUserData)
        {
            Int32 bRet = NetDevSdk.FALSE;

            /* Image Info */
            NETDEV_STRUCT_IMAGE_INFO_S[] stImageInfoList = new NETDEV_STRUCT_IMAGE_INFO_S[pstAlarmData.udwImageNum];
            for (int i = 0; i < pstAlarmData.udwImageNum; i++)
            {
                IntPtr pstImageInfoTemp = new IntPtr(pstAlarmData.pstImageInfo.ToInt32() + Marshal.SizeOf(typeof(NETDEV_STRUCT_IMAGE_INFO_S)) * i);
                stImageInfoList[i] = (NETDEV_STRUCT_IMAGE_INFO_S)Marshal.PtrToStructure(pstImageInfoTemp, typeof(NETDEV_STRUCT_IMAGE_INFO_S));
            }

            /* face info */
            if (0 < pstAlarmData.stObjectInfo.udwFaceNum && 0 < pstAlarmData.udwImageNum)
            {
                string strTime = getStrTime(pstAlarmInfo.udwTimeStamp);
                this.BeginInvoke(new Action(() =>
                {
                    faceSnapshotPicTimeLab.Text = strTime;
                }));

                NETDEV_FACE_STRUCT_INFO_S[] stFaceInfoList = new NETDEV_FACE_STRUCT_INFO_S[pstAlarmData.stObjectInfo.udwFaceNum];
                for (int dwFaceInfoIndex = 0; dwFaceInfoIndex < pstAlarmData.stObjectInfo.udwFaceNum; dwFaceInfoIndex++)
                {
                    IntPtr pstFaceInfoTemp = new IntPtr(pstAlarmData.stObjectInfo.pstFaceInfo.ToInt32() + Marshal.SizeOf(typeof(NETDEV_FACE_STRUCT_INFO_S)) * dwFaceInfoIndex);
                    stFaceInfoList[dwFaceInfoIndex] = (NETDEV_FACE_STRUCT_INFO_S)Marshal.PtrToStructure(pstFaceInfoTemp, typeof(NETDEV_FACE_STRUCT_INFO_S));
                }

                for (int i = 0; i < pstAlarmData.stObjectInfo.udwFaceNum; i++)
                {
                    for (int j = 0; j < pstAlarmData.udwImageNum; j++)
                    {
                        if (stFaceInfoList[i].udwLargePicAttachIndex == stImageInfoList[j].udwIndex)
                        {
                            String strPicUrl = GetDefaultString(stImageInfoList[j].szUrl);
                            if (stImageInfoList[j].udwSize > 0 || strPicUrl != "")
                            {
                                byte[] szFaceLargePicInfo = new byte[stImageInfoList[j].udwSize];
                                if (strPicUrl != "")
                                {
                                    IntPtr pszData = Marshal.AllocHGlobal((int)stImageInfoList[j].udwSize);
                                    bRet = NETDEVSDK.NETDEV_GetSystemPicture(lpUserID, strPicUrl, stImageInfoList[j].udwSize, pszData);
                                    if (NetDevSdk.TRUE == bRet)
                                    {
                                        Marshal.Copy(pszData, szFaceLargePicInfo, 0, (int)stImageInfoList[j].udwSize);
                                    }
                                    else
                                    {
                                        Marshal.Copy(stImageInfoList[j].pszData, szFaceLargePicInfo, 0, (int)stImageInfoList[j].udwSize);
                                    }

                                    Marshal.FreeHGlobal(pszData);
                                }
                                else
                                {
                                    Marshal.Copy(stImageInfoList[j].pszData, szFaceLargePicInfo, 0, (int)stImageInfoList[j].udwSize);
                                }

                                this.BeginInvoke(new Action(() =>
                                {
                                    using (MemoryStream stream = new MemoryStream(szFaceLargePicInfo))
                                    {
                                        try
                                        {
                                            faceSnapshotLargePictureBox.Image = Image.FromStream(stream);
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex);
                                        }
                                    }
                                }));
                            }
                        }
                        else if (stFaceInfoList[i].udwSmallPicAttachIndex == stImageInfoList[j].udwIndex)
                        {
                            if (stImageInfoList[j].udwSize > 0
                                && stImageInfoList[j].pszData != IntPtr.Zero)
                            {
                                byte[] szFaceSmallPicInfo = new byte[stImageInfoList[j].udwSize];
                                Marshal.Copy(stImageInfoList[j].pszData, szFaceSmallPicInfo, 0, (int)stImageInfoList[j].udwSize);

                                this.BeginInvoke(new Action(() =>
                                {
                                    using (MemoryStream stream = new MemoryStream(szFaceSmallPicInfo))
                                    {
                                        try
                                        {
                                            faceSnapshotSmallPictureBox.Image = Image.FromStream(stream);
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex);
                                        }
                                    }
                                }));
                            }
                        }
                    }
                }
            }

            /* person Info */
            if (0 < pstAlarmData.stObjectInfo.udwPersonNum && 0 < pstAlarmData.udwImageNum)
            {
                NETDEV_PERSON_STRUCT_INFO_S[] stPersonInfoList = new NETDEV_PERSON_STRUCT_INFO_S[pstAlarmData.stObjectInfo.udwPersonNum];
                for (int dwPersonInfoIndex = 0; dwPersonInfoIndex < pstAlarmData.stObjectInfo.udwPersonNum; dwPersonInfoIndex++)
                {
                    IntPtr pstPersonInfoTemp = new IntPtr(pstAlarmData.stObjectInfo.pstPersonInfo.ToInt32() + Marshal.SizeOf(typeof(NETDEV_PERSON_STRUCT_INFO_S)) * dwPersonInfoIndex);
                    stPersonInfoList[dwPersonInfoIndex] = (NETDEV_PERSON_STRUCT_INFO_S)Marshal.PtrToStructure(pstPersonInfoTemp, typeof(NETDEV_PERSON_STRUCT_INFO_S));
                }

                for (int i = 0; i < pstAlarmData.stObjectInfo.udwPersonNum; i++)
                {
                    for (int j = 0; j < pstAlarmData.udwImageNum; j++)
                    {
                        if (stPersonInfoList[i].udwLargePicAttachIndex == stImageInfoList[j].udwIndex)
                        {
                            if (stImageInfoList[j].udwSize > 0
                                && stImageInfoList[j].pszData != IntPtr.Zero)
                            {
                                byte[] szPersonLargePicInfo = new byte[stImageInfoList[j].udwSize];
                                Marshal.Copy(stImageInfoList[j].pszData, szPersonLargePicInfo, 0, (int)stImageInfoList[j].udwSize);
                            }
                        }
                        else if (stPersonInfoList[i].udwSmallPicAttachIndex == stImageInfoList[j].udwIndex)
                        {
                            if (stImageInfoList[j].udwSize > 0
                                && stImageInfoList[j].pszData != IntPtr.Zero)
                            {
                                byte[] szPersonSmallPicInfo = new byte[stImageInfoList[j].udwSize];
                                Marshal.Copy(stImageInfoList[j].pszData, szPersonSmallPicInfo, 0, (int)stImageInfoList[j].udwSize);
                            }
                        }
                    }
                }
            }

            /* Non-Motor Vehicle */
            if (0 < pstAlarmData.stObjectInfo.udwNonMotorVehNum && 0 < pstAlarmData.udwImageNum)
            {
                NETDEV_NON_MOTOR_VEH_INFO_S[] stNonMotorVehInfoList = new NETDEV_NON_MOTOR_VEH_INFO_S[pstAlarmData.stObjectInfo.udwNonMotorVehNum];
                for (int dwNonMotorVehInfoIndex = 0; dwNonMotorVehInfoIndex < pstAlarmData.stObjectInfo.udwNonMotorVehNum; dwNonMotorVehInfoIndex++)
                {
                    IntPtr pstNonMotorVehInfoTemp = new IntPtr(pstAlarmData.stObjectInfo.pstNonMotorVehInfo.ToInt32() + Marshal.SizeOf(typeof(NETDEV_NON_MOTOR_VEH_INFO_S)) * dwNonMotorVehInfoIndex);
                    stNonMotorVehInfoList[dwNonMotorVehInfoIndex] = (NETDEV_NON_MOTOR_VEH_INFO_S)Marshal.PtrToStructure(pstNonMotorVehInfoTemp, typeof(NETDEV_NON_MOTOR_VEH_INFO_S));
                }

                for (int i = 0; i < pstAlarmData.stObjectInfo.udwNonMotorVehNum; i++)
                {
                    for (int j = 0; j < pstAlarmData.udwImageNum; j++)
                    {
                        if (stNonMotorVehInfoList[i].udwLargePicAttachIndex == stImageInfoList[j].udwIndex)
                        {
                            if (stImageInfoList[j].udwSize > 0
                                && stImageInfoList[j].pszData != IntPtr.Zero)
                            {
                                byte[] szNonMotorVehLargePicInfo = new byte[stImageInfoList[j].udwSize];
                                Marshal.Copy(stImageInfoList[j].pszData, szNonMotorVehLargePicInfo, 0, (int)stImageInfoList[j].udwSize);
                            }
                        }
                        else if (stNonMotorVehInfoList[i].udwSmallPicAttachIndex == stImageInfoList[j].udwIndex)
                        {
                            if (stImageInfoList[j].udwSize > 0
                                && stImageInfoList[j].pszData != IntPtr.Zero)
                            {
                                byte[] szNonMotorVehSmallPicInfo = new byte[stImageInfoList[j].udwSize];
                                Marshal.Copy(stImageInfoList[j].pszData, szNonMotorVehSmallPicInfo, 0, (int)stImageInfoList[j].udwSize);
                            }
                        }
                    }
                }
            }

            /* Vehicle */
            if (0 < pstAlarmData.stObjectInfo.udwVehicleNum && 0 < pstAlarmData.udwImageNum)
            {
                string strTime = getStrTime(pstAlarmInfo.udwTimeStamp);
                this.BeginInvoke(new Action(() =>
                {
                    vehicleSnapshotPicTimeLab.Text = strTime;
                    vehicleSnapshotLargePictureBox.Image = null;
                    vehicleSnapshotLargePictureBox.Refresh();
                    plateSnapshotSmallPictureBox.Image = null;
                    vehicleSnapshotLargePictureBox.Refresh();
                }));

                NETDEV_VEH_INFO_S[] stVehInfoList = new NETDEV_VEH_INFO_S[pstAlarmData.stObjectInfo.udwVehicleNum];
                for (int dwVehInfoIndex = 0; dwVehInfoIndex < pstAlarmData.stObjectInfo.udwVehicleNum; dwVehInfoIndex++)
                {
                    IntPtr pstVehInfoTemp = new IntPtr(pstAlarmData.stObjectInfo.pstVehInfo.ToInt32() + Marshal.SizeOf(typeof(NETDEV_VEH_INFO_S)) * dwVehInfoIndex);
                    stVehInfoList[dwVehInfoIndex] = (NETDEV_VEH_INFO_S)Marshal.PtrToStructure(pstVehInfoTemp, typeof(NETDEV_VEH_INFO_S));
                }

                for (int i = 0; i < pstAlarmData.stObjectInfo.udwVehicleNum; i++)
                {
                    for (int j = 0; j < pstAlarmData.udwImageNum; j++)
                    {
                        if (stVehInfoList[i].udwLargePicAttachIndex == stImageInfoList[j].udwIndex)
                        {
                            if (stImageInfoList[j].udwSize > 0)
                            {
                                byte[] szVehicleLargePicInfo = new byte[stImageInfoList[j].udwSize];
                                String strPicUrl = GetDefaultString(stImageInfoList[j].szUrl);
                                if (strPicUrl != "")
                                {
                                    IntPtr pszData = Marshal.AllocHGlobal((int)stImageInfoList[j].udwSize);
                                    bRet = NETDEVSDK.NETDEV_GetSystemPicture(lpUserID, strPicUrl, stImageInfoList[j].udwSize, pszData);
                                    if (NetDevSdk.TRUE == bRet)
                                    {
                                        Marshal.Copy(pszData, szVehicleLargePicInfo, 0, (int)stImageInfoList[j].udwSize);
                                    }

                                    Marshal.FreeHGlobal(pszData);
                                }
                                else
                                {
                                    Marshal.Copy(stImageInfoList[j].pszData, szVehicleLargePicInfo, 0, (int)stImageInfoList[j].udwSize);
                                }

                                this.BeginInvoke(new Action(() =>
                                {
                                    using (MemoryStream stream = new MemoryStream(szVehicleLargePicInfo))
                                    {
                                        try
                                        {
                                            vehicleSnapshotLargePictureBox.Image = Image.FromStream(stream);
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex);
                                        }
                                    }
                                }));
                            }
                        }
                        else if (stVehInfoList[i].udwSmallPicAttachIndex == stImageInfoList[j].udwIndex)
                        {
                            if (stImageInfoList[j].udwSize > 0
                                && stImageInfoList[j].pszData != IntPtr.Zero)
                            {
                                byte[] szVehicleSmallPicInfo = new byte[stImageInfoList[j].udwSize];
                                Marshal.Copy(stImageInfoList[j].pszData, szVehicleSmallPicInfo, 0, (int)stImageInfoList[j].udwSize);
                            }
                        }
                        else if (stVehInfoList[i].udwPlatePicAttachIndex == stImageInfoList[j].udwIndex)
                        {
                            if (stImageInfoList[j].udwSize > 0
                                && stImageInfoList[j].pszData != IntPtr.Zero)
                            {
                                byte[] szPlateSmallPicInfo = new byte[stImageInfoList[j].udwSize];
                                Marshal.Copy(stImageInfoList[j].pszData, szPlateSmallPicInfo, 0, (int)stImageInfoList[j].udwSize);
                                this.BeginInvoke(new Action(() =>
                                {
                                    using (MemoryStream stream = new MemoryStream(szPlateSmallPicInfo))
                                    {
                                        try
                                        {
                                            plateSnapshotSmallPictureBox.Image = Image.FromStream(stream);
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex);
                                        }
                                    }
                                }));
                            }
                        }
                    }
                }
            }
        }

        private void cbPlayDecodeVideoCALLBACK(IntPtr lpUserID, ref NETDEV_PICTURE_DATA_S pstPictureData, IntPtr lpUserData)
        {
            if (0 == pstPictureData.dwPicHeight || 0 == pstPictureData.dwPicWidth)
            {
                return;
            }

            /* 取出YUV数据，跨距和高不一样，如720*576帧，Y平面跨距768，也就是说768大小的内存中,只有720是有效的，同理，U,V也一样 */
            byte[] YData = new byte[pstPictureData.dwPicHeight * pstPictureData.dwPicWidth];
            byte[] UData = new byte[pstPictureData.dwPicHeight * pstPictureData.dwPicWidth / 4];
            byte[] VData = new byte[pstPictureData.dwPicHeight * pstPictureData.dwPicWidth / 4];

            List<byte> YUVData = new List<byte>();

            byte[] YAllData = new byte[pstPictureData.dwPicHeight * pstPictureData.dwLineSize[0]];
            Marshal.Copy(pstPictureData.pucData[0], YAllData, 0, pstPictureData.dwPicHeight * pstPictureData.dwLineSize[0]);
            for (int i = 0; i < pstPictureData.dwPicHeight; i++)
            {
                Array.Copy(YAllData, i * pstPictureData.dwLineSize[0], YData, i * pstPictureData.dwPicWidth, pstPictureData.dwPicWidth);
            }

            byte[] UAllData = new byte[pstPictureData.dwPicHeight / 2 * pstPictureData.dwLineSize[1]];
            Marshal.Copy(pstPictureData.pucData[1], UAllData, 0, pstPictureData.dwPicHeight / 2 * pstPictureData.dwLineSize[1]);
            for (int i = 0; i < pstPictureData.dwPicHeight / 2; i++)
            {
                Array.Copy(UAllData, i * pstPictureData.dwLineSize[1], UData, i * pstPictureData.dwPicWidth / 2, pstPictureData.dwPicWidth / 2);
            }

            byte[] VAllData = new byte[pstPictureData.dwPicHeight / 2 * pstPictureData.dwLineSize[2]];
            Marshal.Copy(pstPictureData.pucData[2], VAllData, 0, pstPictureData.dwPicHeight / 2 * pstPictureData.dwLineSize[2]);
            for (int i = 0; i < pstPictureData.dwPicHeight / 2; i++)
            {
                Array.Copy(VAllData, i * pstPictureData.dwLineSize[2], VData, i * pstPictureData.dwPicWidth / 2, pstPictureData.dwPicWidth / 2);
            }

            YUVData.AddRange(YData);
            YUVData.AddRange(UData);
            YUVData.AddRange(VData);

            String strFileName = "test.yuv";
            FileStream fs = new FileStream(strFileName, FileMode.Create);
            fs.Write(YUVData.ToArray(), 0, YUVData.ToArray().Length);
            fs.Close();

            return;
        }

        private void updateDeviceChannel(IntPtr lpUserID, int dwChannelID)
        {
            int pdwChnType = 0;
            Int32 iRet = NETDEVSDK.NETDEV_GetChnType(lpUserID, dwChannelID, ref pdwChnType);
            if (NetDevSdk.FALSE == iRet)
            {
                return;
            }

            if ((int)NETDEV_CHN_TYPE_E.NETDEV_CHN_TYPE_ENCODE == pdwChnType)
            {
                int pdwBytesReturned = 0;
                NETDEV_DEV_CHN_ENCODE_INFO_S stDevChnInfo = new NETDEV_DEV_CHN_ENCODE_INFO_S();
                IntPtr lpOutBuffer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETDEV_DEV_CHN_ENCODE_INFO_S)));
                Marshal.StructureToPtr(stDevChnInfo, lpOutBuffer, true);
                iRet = NETDEVSDK.NETDEV_GetChnDetailByChnType(lpUserID, dwChannelID, pdwChnType, lpOutBuffer, Marshal.SizeOf(typeof(NETDEV_DEV_CHN_ENCODE_INFO_S)), ref pdwBytesReturned);
                if (NetDevSdk.FALSE == iRet)
                {
                    Marshal.FreeHGlobal(lpOutBuffer);
                    return;
                }
                else
                {
                    stDevChnInfo = (NETDEV_DEV_CHN_ENCODE_INFO_S)Marshal.PtrToStructure(lpOutBuffer, typeof(NETDEV_DEV_CHN_ENCODE_INFO_S));
                    Marshal.FreeHGlobal(lpOutBuffer);
                }

                int dwDeviceIndex = -1;
                int dwOrgIndex = -1;
                int dwSubDeviceIndex = -1;
                int dwChannelIndex = -1;

                for (int i = 0; i < m_deviceInfoList.Count; i++)
                {
                    if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_INVALID == m_deviceInfoList[i].m_eDeviceType)
                    {
                        continue;
                    }

                    if (lpUserID == m_deviceInfoList[i].m_lpDevHandle)
                    {
                        dwDeviceIndex = i;
                        break;
                    }
                }

                dwOrgIndex = getOrgIndexByID(dwDeviceIndex, stDevChnInfo.stChnBaseInfo.dwOrgID);
                dwSubDeviceIndex = getSubDeviceIndexByID(dwDeviceIndex, dwOrgIndex, stDevChnInfo.stChnBaseInfo.dwDevID);
                dwChannelIndex = getChannelIndexByID(dwDeviceIndex, dwOrgIndex, dwSubDeviceIndex, dwChannelID);

                if (-1 == dwSubDeviceIndex)
                {
                    return;
                }

                NETDEMO_VMS_DEV_CHANNEL_INFO_S stDemoVmsChnInfo = new NETDEMO_VMS_DEV_CHANNEL_INFO_S();
                stDemoVmsChnInfo.stChnInfo = stDevChnInfo;

                /* 已经存在 */
                TreeNode treeNode = TreeViewFindNode(DeviceTree, dwDeviceIndex, stDevChnInfo.stChnBaseInfo.dwChannelID, NETDEMO_FIND_TREE_NODE_TYPE_E.NETDEMO_FIND_TREE_NODE_CHN_ID);
                if (null != treeNode)
                {
                    m_deviceInfoList[dwDeviceIndex].stVmsDevInfo.stOrgInfoList[dwOrgIndex].stVmsDevBasicInfoList[dwSubDeviceIndex].stChnInfoList[dwChannelIndex] = stDemoVmsChnInfo;
                    updateChnTreeNode(treeNode, stDevChnInfo);
                    return;
                }

                m_deviceInfoList[dwDeviceIndex].stVmsDevInfo.stOrgInfoList[dwOrgIndex].stVmsDevBasicInfoList[dwSubDeviceIndex].stChnInfoList.Add(stDemoVmsChnInfo);

                treeNode = TreeViewFindNode(DeviceTree, dwDeviceIndex, stDevChnInfo.stChnBaseInfo.dwDevID, NETDEMO_FIND_TREE_NODE_TYPE_E.NETDEMO_FIND_TREE_NODE_SUB_DEVICE_ID);
                if (null != treeNode)
                {
                    updateChnTreeNode(treeNode, stDevChnInfo);
                }
            }
        }

        private void deleteDeviceChannel(IntPtr lpUserID, int dwChannelID)
        {
            int dwDeviceIndex = -1;
            int dwOrgIndex = -1;
            int dwSubDeviceIndex = -1;
            int dwChannelIndex = -1;

            for (int i = 0; i < m_deviceInfoList.Count; i++)
            {
                if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_INVALID == m_deviceInfoList[i].m_eDeviceType)
                {
                    continue;
                }

                if (lpUserID == m_deviceInfoList[i].m_lpDevHandle)
                {
                    dwDeviceIndex = i;
                    break;
                }
            }

            TreeNode treeNode = TreeViewFindNode(DeviceTree, dwDeviceIndex, dwChannelID, NETDEMO_FIND_TREE_NODE_TYPE_E.NETDEMO_FIND_TREE_NODE_CHN_ID);
            if (null != treeNode)
            {
                NETDEMO_TreeNodeInfo treeNodeInfo = (NETDEMO_TreeNodeInfo)treeNode.Tag;
                dwOrgIndex = getOrgIndexByID(dwDeviceIndex, treeNodeInfo.dwOrgID);
                dwSubDeviceIndex = getSubDeviceIndexByID(dwDeviceIndex, dwOrgIndex, treeNodeInfo.dwSubDeviceID);
                dwChannelIndex = getChannelIndexByID(dwDeviceIndex, dwOrgIndex, dwSubDeviceIndex, dwChannelID);

                m_deviceInfoList[dwDeviceIndex].stVmsDevInfo.stOrgInfoList[dwOrgIndex].stVmsDevBasicInfoList[dwSubDeviceIndex].stChnInfoList.Remove(m_deviceInfoList[dwDeviceIndex].stVmsDevInfo.stOrgInfoList[dwOrgIndex].stVmsDevBasicInfoList[dwSubDeviceIndex].stChnInfoList[dwChannelIndex]);
                treeNode.Nodes.Clear();
                treeNode.Remove();
            }
        }

        private void deleteSubDevice(IntPtr lpUserID, int dwDeviceID)
        {
            int dwDeviceIndex = -1;
            int dwOrgIndex = -1;
            int dwSubDeviceIndex = -1;

            for (int i = 0; i < m_deviceInfoList.Count; i++)
            {
                if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_INVALID == m_deviceInfoList[i].m_eDeviceType)
                {
                    continue;
                }

                if (lpUserID == m_deviceInfoList[i].m_lpDevHandle)
                {
                    dwDeviceIndex = i;
                    break;
                }
            }

            TreeNode treeNode = TreeViewFindNode(DeviceTree, dwDeviceIndex, dwDeviceID, NETDEMO_FIND_TREE_NODE_TYPE_E.NETDEMO_FIND_TREE_NODE_SUB_DEVICE_ID);
            if (null != treeNode)
            {
                NETDEMO_TreeNodeInfo treeNodeInfo = (NETDEMO_TreeNodeInfo)treeNode.Tag;
                dwOrgIndex = getOrgIndexByID(dwDeviceIndex, treeNodeInfo.dwOrgID);
                dwSubDeviceIndex = getSubDeviceIndexByID(dwDeviceIndex, dwOrgIndex, dwDeviceID);

                m_deviceInfoList[treeNodeInfo.dwDeviceIndex].stVmsDevInfo.stOrgInfoList[dwOrgIndex].stVmsDevBasicInfoList.Remove(m_deviceInfoList[dwDeviceIndex].stVmsDevInfo.stOrgInfoList[dwOrgIndex].stVmsDevBasicInfoList[dwSubDeviceIndex]);
                treeNode.Nodes.Clear();
                treeNode.Remove();
            }
        }

        private void updateSubDevice(IntPtr lpUserID, int dwDeviceID)
        {
            NETDEMO_VMS_DEV_BASIC_INFO_S stDemoVmsBasicInfo = new NETDEMO_VMS_DEV_BASIC_INFO_S();
            NETDEV_DEV_INFO_V30_S stDevInfo = new NETDEV_DEV_INFO_V30_S();
            Int32 iRet = NETDEVSDK.NETDEV_GetDeviceInfo_V30(lpUserID, dwDeviceID, ref stDevInfo);
            if (NetDevSdk.FALSE == iRet)
            {
                return;
            }

            if ((int)NETDEV_DEVICE_MAIN_TYPE_E.NETDEV_DTYPE_MAIN_ENCODE != stDevInfo.stDevBasicInfo.dwDevType)
            {
                return;
            }

            stDemoVmsBasicInfo.stDevBasicInfo = stDevInfo.stDevBasicInfo;

            IntPtr lpFindDevChnHandle = NETDEVSDK.NETDEV_FindDevChnList(lpUserID, stDevInfo.stDevBasicInfo.dwDevID, 0);
            if (IntPtr.Zero == lpFindDevChnHandle)
            {
                return;
            }

            while (true)
            {
                NETDEMO_VMS_DEV_CHANNEL_INFO_S stDemoVmsChnInfo = new NETDEMO_VMS_DEV_CHANNEL_INFO_S();

                int pdwBytesReturned = 0;
                NETDEV_DEV_CHN_ENCODE_INFO_S stDevChnInfo = new NETDEV_DEV_CHN_ENCODE_INFO_S();
                IntPtr lpOutBuffer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETDEV_DEV_CHN_ENCODE_INFO_S)));
                Marshal.StructureToPtr(stDevChnInfo, lpOutBuffer, true);
                iRet = NETDEVSDK.NETDEV_FindNextDevChn(lpFindDevChnHandle, lpOutBuffer, Marshal.SizeOf(typeof(NETDEV_DEV_CHN_ENCODE_INFO_S)), ref pdwBytesReturned);
                if (NetDevSdk.FALSE == iRet)
                {
                    Marshal.FreeHGlobal(lpOutBuffer);
                    break;
                }
                else
                {
                    stDevChnInfo = (NETDEV_DEV_CHN_ENCODE_INFO_S)Marshal.PtrToStructure(lpOutBuffer, typeof(NETDEV_DEV_CHN_ENCODE_INFO_S));
                    stDemoVmsChnInfo.stChnInfo = stDevChnInfo;
                    stDemoVmsBasicInfo.stChnInfoList.Add(stDemoVmsChnInfo);

                    Marshal.FreeHGlobal(lpOutBuffer);
                }
            }

            NETDEVSDK.NETDEV_FindCloseDevChn(lpFindDevChnHandle);

            int dwDeviceIndex = -1;
            int dwOrgIndex = -1;
            int dwSubDeviceIndex = -1;

            for (int i = 0; i < m_deviceInfoList.Count; i++)
            {
                if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_INVALID == m_deviceInfoList[i].m_eDeviceType)
                {
                    continue;
                }

                if (lpUserID == m_deviceInfoList[i].m_lpDevHandle)
                {
                    dwDeviceIndex = i;
                    break;
                }
            }

            if (-1 == dwDeviceIndex)
            {
                return;
            }

            dwOrgIndex = getOrgIndexByID(dwDeviceIndex, stDevInfo.stDevBasicInfo.dwOrgID);
            if (-1 == dwOrgIndex)
            {
                return;
            }

            dwSubDeviceIndex = getSubDeviceIndexByID(dwDeviceIndex, dwOrgIndex, stDevInfo.stDevBasicInfo.dwDevID);
            if (-1 == dwSubDeviceIndex)
            {
                return;
            }

            TreeNode treeNode = TreeViewFindNode(DeviceTree, dwDeviceIndex, stDevInfo.stDevBasicInfo.dwDevID, NETDEMO_FIND_TREE_NODE_TYPE_E.NETDEMO_FIND_TREE_NODE_SUB_DEVICE_ID);

            /* 已经存在 */
            if (null != treeNode)
            {
                m_deviceInfoList[dwDeviceIndex].stVmsDevInfo.stOrgInfoList[dwOrgIndex].stVmsDevBasicInfoList[dwSubDeviceIndex] = stDemoVmsBasicInfo;
                updateSubDeviceTreeNode(treeNode, stDemoVmsBasicInfo);
                return;
            }

            m_deviceInfoList[dwDeviceIndex].stVmsDevInfo.stOrgInfoList[dwOrgIndex].stVmsDevBasicInfoList.Add(stDemoVmsBasicInfo);

            treeNode = TreeViewFindNode(DeviceTree, dwDeviceIndex, stDevInfo.stDevBasicInfo.dwOrgID, NETDEMO_FIND_TREE_NODE_TYPE_E.NETDEMO_FIND_TREE_NODE_ORG_ID);
            if (null != treeNode)
            {
                updateSubDeviceTreeNode(treeNode, stDemoVmsBasicInfo);
            }
        }

        private string getDeviceIP(IntPtr lpUserID)
        {
            String strDeviceIP = null;
            for (int i = 0; i < arrayRealPanel.Length; i++)
            {
                if (lpUserID == arrayRealPanel[i].m_playhandle && arrayRealPanel[i].m_playStatus == true)
                {
                    strDeviceIP = m_deviceInfoList[arrayRealPanel[i].m_deviceIndex].m_ip;
                    break;
                }
            }

            for (int i = 0; i < m_deviceInfoList.Count; i++)
            {
                if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_INVALID == m_deviceInfoList[i].m_eDeviceType)
                {
                    continue;
                }

                if (m_deviceInfoList[i].m_lpDevHandle == lpUserID)
                {
                    strDeviceIP = m_deviceInfoList[i].m_ip;
                    break;
                }
            }

            if (strDeviceIP == null)
            {
                strDeviceIP = "Unknown ip";
            }

            return strDeviceIP;
        }

        private void AlarmRecordsClearBtn_Click(object sender, EventArgs e)
        {
            AlarmRecordsListView.Items.Clear();
        }

        private String getAlarmInfo(int dwAlarmType)
        {
            String strAlarmInfo = null;

            for (int i = 0; i < NetDevSdk.gastNETDemoAlarmInfo.Length; i++)
            {
                if (dwAlarmType == NetDevSdk.gastNETDemoAlarmInfo[i].alarmType)
                {
                    strAlarmInfo = NetDevSdk.gastNETDemoAlarmInfo[i].reportAlarm;
                    break;
                }
            }
            if (NetDevSdk.NETDEV_E_VIDEO_RESOLUTION_CHANGE == dwAlarmType)
            {
                strAlarmInfo = "Resolution changed";
            }
            if (strAlarmInfo == null)
            {
                strAlarmInfo = "Unknown alarm";
            }

            return strAlarmInfo;
        }

        private void RebootBtn_Click(object sender, EventArgs e)
        {
            if (m_deviceInfoList.Count == 0)
            {
                return;
            }

            if ((DeviceTree.SelectedNode.ImageIndex == NetDevSdk.NETDEV_TREEVIEW_IMAGE_LOCAL_DEVICE_ON)
            && m_deviceInfoList[DeviceTree.SelectedNode.Index].m_lpDevHandle != IntPtr.Zero)
            {
                DialogResult result = MessageBox.Show("Do you want to restart the device?", "Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    int iRet = NETDEVSDK.NETDEV_Reboot(m_deviceInfoList[DeviceTree.SelectedNode.Index].m_lpDevHandle);
                    if (NetDevSdk.TRUE != iRet)
                    {
                        showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Reboot", NETDEVSDK.NETDEV_GetLastError());
                    }
                    else
                    {
                        showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Reboot");
                        Logout_Click(null, null);
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("Cannot reboot channel", "warning");
            }
        }

        private void factoryDefaultBtn_Click(object sender, EventArgs e)
        {
            if (m_deviceInfoList.Count == 0)
            {
                return;
            }

            if ((DeviceTree.SelectedNode.ImageIndex == NetDevSdk.NETDEV_TREEVIEW_IMAGE_LOCAL_DEVICE_ON)
                && m_deviceInfoList[DeviceTree.SelectedNode.Index].m_lpDevHandle != IntPtr.Zero)
            {
                DialogResult result = MessageBox.Show("Restoring the default will restart the device. Do you want to continue?", "Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    int iRet = NETDEVSDK.NETDEV_RestoreConfig(m_deviceInfoList[DeviceTree.SelectedNode.Index].m_lpDevHandle);
                    if (NetDevSdk.TRUE != iRet)
                    {
                        showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Restore Config fail", NETDEVSDK.NETDEV_GetLastError());
                    }
                    else
                    {
                        showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Restore Config");
                        Logout_Click(null, null);
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("Cannot restore channel config", "warning");
            }
        }

        private void passengerFlowStatisticCallBackFunc(IntPtr lpUserID, IntPtr pstPassengerFlowData, IntPtr lpUserData)
        {
            NETDEV_PASSENGER_FLOW_STATISTIC_DATA_S passengerFlowData = (NETDEV_PASSENGER_FLOW_STATISTIC_DATA_S)Marshal.PtrToStructure(pstPassengerFlowData, typeof(NETDEV_PASSENGER_FLOW_STATISTIC_DATA_S));

            String strIP = GetDevIPByDevHandle(lpUserID);
            String strReportTime = getStrTime(passengerFlowData.tReportTime);

            ListViewItem item = new ListViewItem(strIP);
            item.SubItems.Add(Convert.ToString(passengerFlowData.dwChannelID));
            item.SubItems.Add(strReportTime);
            item.SubItems.Add(Convert.ToString(passengerFlowData.tInterval));
            item.SubItems.Add(Convert.ToString(passengerFlowData.dwEnterNum));
            item.SubItems.Add(Convert.ToString(passengerFlowData.dwExitNum));
            item.SubItems.Add(Convert.ToString(passengerFlowData.dwTotalEnterNum));
            item.SubItems.Add(Convert.ToString(passengerFlowData.dwTotalExitNum));
            VCAReportDataListView.Items.Add(item);
        }

        private String GetDevIPByDevHandle(IntPtr handle)
        {
            String strDeviceIP = null;
            for (int i = 0; i < m_deviceInfoList.Count; i++)
            {
                if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_INVALID == m_deviceInfoList[i].m_eDeviceType)
                {
                    continue;
                }

                if (m_deviceInfoList[i].m_lpDevHandle == handle)
                {
                    strDeviceIP = m_deviceInfoList[i].m_ip;
                    break;
                }
            }

            if (strDeviceIP == null)
            {
                strDeviceIP = "Unknown ip";
            }

            return strDeviceIP;
        }

        private void VCARegCallBackBtn_Click(object sender, EventArgs e)
        {
            if (m_deviceInfoList.Count == 0)
            {
                return;
            }

            if ((DeviceTree.SelectedNode.ImageIndex == NetDevSdk.NETDEV_TREEVIEW_IMAGE_LOCAL_DEVICE_ON)
                && m_deviceInfoList[DeviceTree.SelectedNode.Index].m_lpDevHandle != IntPtr.Zero)
            {
                if (null == passengerCB)
                {
                    passengerCB = new NETDEV_PassengerFlowStatisticCallBack_PF(passengerFlowStatisticCallBackFunc);
                }
                int iRet = NETDEVSDK.NETDEV_SetPassengerFlowStatisticCallBack(m_deviceInfoList[DeviceTree.SelectedNode.Index].m_lpDevHandle, passengerCB, IntPtr.Zero);
                if (NetDevSdk.TRUE != iRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Set Passenger Flow Statistic Call Back fail", NETDEVSDK.NETDEV_GetLastError());
                    return;
                }

                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Set Passenger Flow Statistic Call Back");
            }
            else
            {
                MessageBox.Show("Cannot Set Passenger Flow Statistic Call Back", "warning");
            }
        }

        private void VCACloseCallBackBtn_Click(object sender, EventArgs e)
        {
            if (m_deviceInfoList.Count == 0)
            {
                return;
            }

            if ((DeviceTree.SelectedNode.ImageIndex == NetDevSdk.NETDEV_TREEVIEW_IMAGE_LOCAL_DEVICE_ON)
                && m_deviceInfoList[DeviceTree.SelectedNode.Index].m_lpDevHandle != IntPtr.Zero)
            {
                int iRet = NETDEVSDK.NETDEV_SetPassengerFlowStatisticCallBack(m_deviceInfoList[DeviceTree.SelectedNode.Index].m_lpDevHandle, null, IntPtr.Zero);
                if (NetDevSdk.TRUE != iRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "UnRegister Passenger Flow Statistic Call back", NETDEVSDK.NETDEV_GetLastError());
                    return;
                }
                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "UnRegister Passenger Flow Statistic Call back");
            }
            else
            {
                MessageBox.Show("UnRegister Passenger Flow Statistic Call back fail", "warning");
            }
        }

        private void VCAClearDataBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Clear the PeopleCounting list?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                VCAReportDataListView.Items.Clear();
            }
        }


        private void VCACountBtn_Click(object sender, EventArgs e)
        {
            if (m_deviceInfoList.Count == 0)
            {
                return;
            }

            if (DeviceTree.SelectedNode.ImageIndex == NetDevSdk.NETDEV_TREEVIEW_IMAGE_CHL_DEVICE_ON && m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle != IntPtr.Zero)
            {
                if (m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelNumber == 0)
                {
                    return;
                }
                NETDEV_TRAFFIC_STATISTICS_COND_S stStatisticCond = new NETDEV_TRAFFIC_STATISTICS_COND_S();
                NETDEV_TRAFFIC_STATISTICS_DATA_S stTrafficStatistic = new NETDEV_TRAFFIC_STATISTICS_DATA_S();
                stTrafficStatistic.adwEnterCount = new Int32[NetDevSdk.NETDEV_PEOPLE_CNT_MAX_NUM];
                stTrafficStatistic.adwExitCount = new Int32[NetDevSdk.NETDEV_PEOPLE_CNT_MAX_NUM];

                stStatisticCond.dwChannelID = getChannelID();

                getTimeInfo(ref stStatisticCond.tBeginTime, ref stStatisticCond.tEndTime);
                stStatisticCond.dwFormType = VCAReportType.SelectedIndex;
                stStatisticCond.dwStatisticsType = VCACountingType.SelectedIndex;

                int iRet = NETDEVSDK.NETDEV_GetTrafficStatistic(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle, ref stStatisticCond, ref stTrafficStatistic);
                if (NetDevSdk.TRUE != iRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Get Traffic Statistic", NETDEVSDK.NETDEV_GetLastError());
                    VCAStatisticDataListView.Items.Clear();
                    return;
                }
                else
                {
                    showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Get Traffic Statistic");
                    displaytheStatistics(ref stTrafficStatistic);
                }
            }
            else
            {
                MessageBox.Show("Cannot Get Traffic Statistic", "warning");
            }
        }


        private void getTimeInfo(ref Int64 beginTime, ref Int64 endTime)
        {
            Int32 dwYear = VCAStatisticalTime.Value.Year;
            Int32 dwMonth = VCAStatisticalTime.Value.Month;
            Int32 dwDay = VCAStatisticalTime.Value.Day;
            Int32 dwDayOfWeek = 0;
            if (0 == (int)VCAStatisticalTime.Value.DayOfWeek)
            {
                dwDayOfWeek = 7;
            }
            else
            {
                dwDayOfWeek = (int)VCAStatisticalTime.Value.DayOfWeek;
            }

            switch (VCAReportType.SelectedIndex)
            {
                case (int)NETDEV_FORM_TYPE_E.NETDEV_FORM_TYPE_DAY:
                    beginTime = getLongTime("" + dwYear + "/" + dwMonth + "/" + dwDay);
                    endTime = beginTime + (3600 * 24 - 1);
                    break;

                case (int)NETDEV_FORM_TYPE_E.NETDEV_FORM_TYPE_WEEK:
                    if (dwDay - dwDayOfWeek >= 0)
                    {
                        beginTime = getLongTime("" + dwYear + "/" + dwMonth + "/" + (dwDay - dwDayOfWeek + 1));
                        endTime = beginTime + (3600 * 24 * 7 - 1);
                    }
                    else
                    {
                        dwDay = dwDay - dwDayOfWeek + 1 + DateNumOfMonth(dwYear, dwMonth);
                        beginTime = getLongTime("" + dwYear + "/" + (dwMonth - 1) + "/" + dwDay);
                        endTime = beginTime + (3600 * 24 * 7 - 1);
                    }
                    break;

                case (int)NETDEV_FORM_TYPE_E.NETDEV_FORM_TYPE_MONTH:
                    beginTime = getLongTime("" + dwYear + "/" + dwMonth + "/1");
                    endTime = getLongTime("" + (dwYear + (dwMonth + 1) / 12) + "/" + (dwMonth + 1) % 12 + "/1") - 1;
                    break;

                case (int)NETDEV_FORM_TYPE_E.NETDEV_FORM_TYPE_YEAR:
                    beginTime = getLongTime("" + dwYear + "/1" + "/1");
                    endTime = getLongTime("" + (dwYear + 1) + "/1" + "/1") - 1;
                    break;

                default:
                    break;
            }
        }

        private int DateNumOfMonth(int dwYear, int dwMonth)
        {
            Int32[] aDays = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (((dwYear % 4 == 0) && (dwYear % 100 != 0)) || dwYear % 400 == 0)
            {
                aDays[1] = 29;
            }

            return aDays[dwMonth - 1];
        }

        private void displaytheStatistics(ref NETDEV_TRAFFIC_STATISTICS_DATA_S stTrafficStatistic)
        {
            string[] szWeekly = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
            string[] szYearly = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

            VCAStatisticDataListView.Items.Clear();

            for (Int32 i = 0; i < stTrafficStatistic.dwSize; i++)
            {
                ListViewItem item = null;
                if ((0 != stTrafficStatistic.adwEnterCount[i]) || (0 != stTrafficStatistic.adwExitCount[i]))
                {
                    switch (VCAReportType.SelectedIndex)
                    {
                        case (int)NETDEV_FORM_TYPE_E.NETDEV_FORM_TYPE_DAY:
                            item = new ListViewItem("" + i + ":00 - " + (i + 1) + ":00");
                            break;

                        case (int)NETDEV_FORM_TYPE_E.NETDEV_FORM_TYPE_WEEK:
                            item = new ListViewItem("" + szWeekly[i]);
                            break;

                        case (int)NETDEV_FORM_TYPE_E.NETDEV_FORM_TYPE_MONTH:
                            item = new ListViewItem("" + (i + 1));
                            break;

                        case (int)NETDEV_FORM_TYPE_E.NETDEV_FORM_TYPE_YEAR:
                            item = new ListViewItem("" + szYearly[i]);
                            break;

                        default:
                            break;
                    }

                    item.SubItems.Add(Convert.ToString(stTrafficStatistic.adwEnterCount[i]));
                    item.SubItems.Add(Convert.ToString(stTrafficStatistic.adwExitCount[i]));
                    VCAStatisticDataListView.Items.Add(item);
                }
            }

            return;
        }

        public void showFailLogInfo(string deviceInfo, string logInfo, int errorCode)
        {
            ListViewItem item = new ListViewItem(DateTime.Now.ToString());
            item.SubItems.Add(deviceInfo);
            item.SubItems.Add(logInfo);
            item.SubItems.Add("Fail");
            item.SubItems.Add(Convert.ToString(errorCode));
            this.logListView.Items.Insert(0, item);
            item.EnsureVisible();

            LogMessage.failLog(deviceInfo, logInfo, errorCode);
        }

        public void showSuccessLogInfo(string deviceInfo, string logInfo)
        {
            ListViewItem item = new ListViewItem(DateTime.Now.ToString());
            item.SubItems.Add(deviceInfo);
            item.SubItems.Add(logInfo);
            item.SubItems.Add("Success");
            item.SubItems.Add("");
            this.logListView.Items.Insert(0, item);
            item.EnsureVisible();

            LogMessage.sucessLog(deviceInfo, logInfo);
        }

        private void cleanLogBtn_Click(object sender, EventArgs e)
        {
            logListView.Items.Clear();
        }


        private void FullScreen_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
            if (toolStripMenuItem.Checked == false)
            {

                this.m_layoutPanelWidth = this.LayoutPanel.Width;
                this.m_layoutPanelHeight = this.LayoutPanel.Height;

                Form form = new Form();
                form.WindowState = FormWindowState.Maximized;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Controls.Add(this.LayoutPanel);
                form.Width = Screen.PrimaryScreen.Bounds.Width - 10;
                form.Height = Screen.PrimaryScreen.Bounds.Height - 10;
                this.LayoutPanel.Width = form.Width;
                this.LayoutPanel.Height = form.Height;
                if (realMaxFlag == true)
                {
                    realMaxFlag = false;
                }
                else
                {
                    realMaxFlag = true;
                }
                switchRealScreen(m_mourseRightSelectedPanel);
                toolStripMenuItem.Checked = true;
                form.ShowDialog();
            }
            else
            {
                toolStripMenuItem.Checked = false;
                Form form = (Form)this.LayoutPanel.Parent;
                this.LayoutPanel.Width = this.m_layoutPanelWidth;
                this.LayoutPanel.Height = this.m_layoutPanelHeight;
                if (realMaxFlag == true)
                {
                    realMaxFlag = false;
                }
                else
                {
                    realMaxFlag = true;
                }
                switchRealScreen(m_mourseRightSelectedPanel);
                this.LiveView.Controls.Add(this.LayoutPanel);

                form.Close();
            }
        }


        private void MultiScreen_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
            if (toolStripMenuItem.Checked == false)
            {
                switchRealScreen(m_mourseRightSelectedPanel);
                toolStripMenuItem.Checked = true;
            }
            else
            {
                toolStripMenuItem.Checked = false;
                switchRealScreen(m_mourseRightSelectedPanel);
            }
        }


        private void CameraInfo_Click(object sender, EventArgs e)
        {
            if (m_mourseRightSelectedPanel.m_playhandle == IntPtr.Zero)
            {
                return;
            }

            string strCameraInfo = "";

            int bitRate = -1;
            int iRet = NETDEVSDK.NETDEV_GetBitRate(m_mourseRightSelectedPanel.m_playhandle, ref bitRate);
            if (NetDevSdk.FALSE == iRet)
            {
                //
            }
            strCameraInfo += "Bit Rate         " + bitRate + "\n";

            int frameRate = -1;
            iRet = NETDEVSDK.NETDEV_GetFrameRate(m_mourseRightSelectedPanel.m_playhandle, ref frameRate);
            if (NetDevSdk.FALSE == iRet)
            {
                //
            }
            strCameraInfo += "Frame Rate       " + frameRate + "\n";

            int format = -1;
            iRet = NETDEVSDK.NETDEV_GetVideoEncodeFmt(m_mourseRightSelectedPanel.m_playhandle, ref format);
            if (NetDevSdk.FALSE == iRet)
            {
                //
            }
            strCameraInfo += "Format           " + format + "\n";

            int resolutionWidth = -1;
            int resolutionHeight = -1;
            iRet = NETDEVSDK.NETDEV_GetResolution(m_mourseRightSelectedPanel.m_playhandle, ref resolutionWidth, ref resolutionHeight);
            if (NetDevSdk.FALSE == iRet)
            {
                //
            }
            strCameraInfo += "Resolution       " + resolutionWidth + " x " + resolutionHeight + "\n";

            int ulRecvPktNum = -1;
            int ulLostPktNum = -1;
            iRet = NETDEVSDK.NETDEV_GetLostPacketRate(m_mourseRightSelectedPanel.m_playhandle, ref ulRecvPktNum, ref ulLostPktNum);
            if (NetDevSdk.FALSE == iRet)
            {
                //
            }
            strCameraInfo += "Lost Packet Rate " + "(" + ulLostPktNum + "/" + ulRecvPktNum + ")\n";

            MessageBox.Show(strCameraInfo, "Camera Info");
        }


        private void CloseAll_Click(object sender, EventArgs e)
        {
            closeAllChannel();
        }


        private void Close_Click(object sender, EventArgs e)
        {
            stopRealPlay(m_mourseRightSelectedPanel, true);
            m_mourseRightSelectedPanel.initPlayPanel();
        }


        private void ShowDelay_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == m_curRealPanel.m_playhandle)
            {
                MessageBox.Show("Set picture fluency, Handle is NULL", "warning");
                return;
            }

            SetNetPlayMode(NETDEV_PICTURE_FLUENCY_E.NETDEV_PICTURE_REAL);

            m_curRealPanel.m_bShortDelayFlag = true;
            m_curRealPanel.m_bFluentFlag = false;
        }


        private void Fluent_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == m_curRealPanel.m_playhandle)
            {
                MessageBox.Show("Set picture fluency, Handle is NULL", "warning");
                return;
            }

            SetNetPlayMode(NETDEV_PICTURE_FLUENCY_E.NETDEV_PICTURE_FLUENCY);

            m_curRealPanel.m_bShortDelayFlag = false;
            m_curRealPanel.m_bFluentFlag = true;
        }

        private void SetNetPlayMode(NETDEV_PICTURE_FLUENCY_E type)
        {
            if (NetDevSdk.FALSE == NETDEVSDK.NETDEV_SetPictureFluency(m_curRealPanel.m_playhandle, (Int32)type))
            {
                showFailLogInfo(m_deviceInfoList[m_curRealPanel.m_deviceIndex].m_ip + " chl:" + (m_curRealPanel.m_channelID), "Set picture fluency, type : " + type, NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            showSuccessLogInfo(m_deviceInfoList[m_curRealPanel.m_deviceIndex].m_ip + " chl:" + (m_curRealPanel.m_channelID), "Set picture fluency, type : " + type);
        }


        private void MakeKeyFrame_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == m_curRealPanel.m_playhandle)
            {
                MessageBox.Show("make keyFrame, Handle is NULL", "warning");
                return;
            }

            makeKeyFrame();
        }

        private void makeKeyFrame()
        {
            Int32 dwBytesReturned = 0;
            NETDEV_VIDEO_STREAM_INFO_S stStreamInfo = new NETDEV_VIDEO_STREAM_INFO_S();

            stStreamInfo.enStreamType = NETDEV_LIVE_STREAM_INDEX_E.NETDEV_LIVE_STREAM_INDEX_MAIN;

            if (NetDevSdk.FALSE == NETDEVSDK.NETDEV_GetDevConfig(m_deviceInfoList[m_curRealPanel.m_deviceIndex].m_lpDevHandle, (m_curRealPanel.m_channelID), (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_STREAMCFG, ref stStreamInfo, Marshal.SizeOf(stStreamInfo), ref dwBytesReturned))
            {
                showFailLogInfo(m_deviceInfoList[m_curRealPanel.m_deviceIndex].m_ip + " chl:" + (m_curRealPanel.m_channelID), "Get Video Stream Info", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            showSuccessLogInfo(m_deviceInfoList[m_curRealPanel.m_deviceIndex].m_ip + " chl:" + (m_curRealPanel.m_channelID), "Get Video Stream Info");

            if (NetDevSdk.FALSE == NETDEVSDK.NETDEV_MakeKeyFrame(m_deviceInfoList[m_curRealPanel.m_deviceIndex].m_lpDevHandle, (m_curRealPanel.m_channelID), (int)stStreamInfo.enStreamType))
            {
                showFailLogInfo(m_deviceInfoList[m_curRealPanel.m_deviceIndex].m_ip + " chl:" + (m_curRealPanel.m_channelID), "Make keyframe", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            showSuccessLogInfo(m_deviceInfoList[m_curRealPanel.m_deviceIndex].m_ip + " chl:" + (m_curRealPanel.m_channelID), "Make keyframe");

            return;
        }


        private void DigitalZoom_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == m_curRealPanel.m_playhandle)
            {
                MessageBox.Show("Set Digital zoom, Handle is NULL", "warning");
                return;
            }

            if (true == m_curRealPanel.m_bDigitalZoomFlag)
            {
                m_curRealPanel.m_bDigitalZoomFlag = false;
                m_curRealPanel.m_bFirstZoomFlag = true;
                SetActiveWndDZ(new NETDEV_RECT_S(), false);
            }
            else
            {
                m_curRealPanel.m_bDigitalZoomFlag = true;
            }
        }

        private void SetActiveWndDZ(NETDEV_RECT_S stRect, bool bAction)
        {
            if (true == m_curRealPanel.m_bDigitalZoomFlag && false == m_curRealPanel.m_bFirstZoomFlag)
            {
                return;
            }

            int iRet = NetDevSdk.FALSE;
            if (true == bAction)
            {
                IntPtr intptrRect = Marshal.AllocHGlobal(Marshal.SizeOf(stRect));
                Marshal.StructureToPtr(stRect, intptrRect, true);

                iRet = NETDEVSDK.NETDEV_SetDigitalZoom(m_curRealPanel.m_playhandle, m_curRealPanel.Handle, intptrRect);
                if (NetDevSdk.TRUE != iRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_curRealPanel.m_deviceIndex].m_ip + " chl:" + (m_curRealPanel.m_channelID), "Set digital zoom", NETDEVSDK.NETDEV_GetLastError());
                }
                else
                {
                    showSuccessLogInfo(m_deviceInfoList[m_curRealPanel.m_deviceIndex].m_ip + " chl:" + (m_curRealPanel.m_channelID), "Set digital zoom");
                }
                Marshal.FreeHGlobal(intptrRect);
            }
            else
            {
                iRet = NETDEVSDK.NETDEV_SetDigitalZoom(m_curRealPanel.m_playhandle, m_curRealPanel.Handle, IntPtr.Zero);
                if (NetDevSdk.TRUE != iRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_curRealPanel.m_deviceIndex].m_ip + " chl:" + (m_curRealPanel.m_channelID), "Set digital zoom", NETDEVSDK.NETDEV_GetLastError());
                    return;
                }
                showSuccessLogInfo(m_deviceInfoList[m_curRealPanel.m_deviceIndex].m_ip + " chl:" + (m_curRealPanel.m_channelID), "Set digital zoom");
            }
        }

        private bool convertRect(ref NETDEV_RECT_S dstRect)
        {
            if (m_curRealPanel.rectStartX < m_curRealPanel.rectEndX)
            {
                dstRect.dwLeft = m_curRealPanel.rectStartX;
                dstRect.dwRight = m_curRealPanel.rectEndX;
            }
            else
            {
                dstRect.dwLeft = m_curRealPanel.rectEndX;
                dstRect.dwRight = m_curRealPanel.rectStartX;
            }

            if (m_curRealPanel.rectStartY < m_curRealPanel.rectEndY)
            {
                dstRect.dwTop = m_curRealPanel.rectStartY;
                dstRect.dwBottom = m_curRealPanel.rectEndY;
            }
            else
            {
                dstRect.dwTop = m_curRealPanel.rectEndY;
                dstRect.dwBottom = m_curRealPanel.rectStartY;
            }

            dstRect.dwLeft = (dstRect.dwLeft * 10000) / m_curRealPanel.Width;
            dstRect.dwRight = (dstRect.dwRight * 10000) / m_curRealPanel.Width;
            dstRect.dwTop = (dstRect.dwTop * 10000) / m_curRealPanel.Height;
            dstRect.dwBottom = (dstRect.dwBottom * 10000) / m_curRealPanel.Height;

            int nIntervalX = m_curRealPanel.rectStartX < m_curRealPanel.rectEndX ? (m_curRealPanel.rectEndX - m_curRealPanel.rectStartX) : (m_curRealPanel.rectStartX - m_curRealPanel.rectEndX);
            int nIntervalY = m_curRealPanel.rectStartY < m_curRealPanel.rectEndY ? (m_curRealPanel.rectEndY - m_curRealPanel.rectStartY) : (m_curRealPanel.rectStartY - m_curRealPanel.rectEndY);
            if (nIntervalX < 20 || nIntervalY < 20)
            {
                return false;
            }

            return true;
        }

        private void realPanel_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as PlayPanel).rectStartX = e.X;
            (sender as PlayPanel).rectStartY = e.Y;
        }

        private void realPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (m_curRealPanel.m_playhandle == IntPtr.Zero)
            {
                return;
            }

            PlayPanel panel = sender as PlayPanel;
            panel.rectEndX = e.X;
            panel.rectEndY = e.Y;
            Graphics g = m_curRealPanel.CreateGraphics();
            g.DrawRectangle(new Pen(Color.Red), panel.rectStartX, panel.rectStartY, panel.rectEndX - panel.rectStartX, panel.rectEndY - panel.rectStartY);

            NETDEV_RECT_S rect = new NETDEV_RECT_S();
            if (false == convertRect(ref rect))
            {
                return;
            }

            if (m_curRealPanel.m_bDigitalZoomFlag == true)
            {
                SetActiveWndDZ(rect, true);
                m_curRealPanel.m_bFirstZoomFlag = false;
            }

            setActive3DPostion(rect);
        }

        private void realPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            PlayPanel panel = sender as PlayPanel;
            panel.rectEndX = e.X;
            panel.rectEndY = e.Y;

            Graphics g = m_curRealPanel.CreateGraphics();
            g.DrawRectangle(new Pen(Color.Red), panel.rectStartX, panel.rectStartY, panel.rectEndX - panel.rectStartX, panel.rectEndY - panel.rectStartY);
        }

        /*3D Position*/
        private void ThreeDPosition_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == m_curRealPanel.m_playhandle)
            {
                MessageBox.Show("3D Position, Handle is NULL", "warning");
                return;
            }

            if (true == m_curRealPanel.m_3DPositionFlag)
            {
                //ThreeDPosition.Checked = false;
                m_curRealPanel.m_3DPositionFlag = false;
            }
            else
            {
                //ThreeDPosition.Checked = true;
                m_curRealPanel.m_3DPositionFlag = true;
            }
        }

        private void setActive3DPostion(NETDEV_RECT_S oRect)
        {
            if (true != m_curRealPanel.m_3DPositionFlag)
            {
                return;
            }

            NETDEV_PTZ_OPERATEAREA_S stPtzAreaOperate = new NETDEV_PTZ_OPERATEAREA_S();

            /* Take the upper left corner of the window for playing as a start point, and the parameter value range from 0 to 10000. */
            stPtzAreaOperate.dwBeginPointX = oRect.dwLeft;
            stPtzAreaOperate.dwBeginPointY = oRect.dwTop;
            stPtzAreaOperate.dwEndPointX = oRect.dwRight;
            stPtzAreaOperate.dwEndPointY = oRect.dwBottom;

            int iRet = NETDEVSDK.NETDEV_PTZSelZoomIn_Other(m_deviceInfoList[m_curRealPanel.m_deviceIndex].m_lpDevHandle, m_curRealPanel.m_channelID, ref stPtzAreaOperate);
            if (NetDevSdk.TRUE != iRet)
            {
                showFailLogInfo(m_deviceInfoList[m_curRealPanel.m_deviceIndex].m_ip + " chl:" + (m_curRealPanel.m_channelID), "Operate area", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            showSuccessLogInfo(m_deviceInfoList[m_curRealPanel.m_deviceIndex].m_ip + " chl:" + (m_curRealPanel.m_channelID), "Operate area");
        }


        private void TwoWayAudio_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == m_curRealPanel.m_playhandle)
            {
                MessageBox.Show("Two-way Audio, Handle is NULL", "warning");
                return;
            }

            if (true == m_curRealPanel.m_twoWayAudioFlag)
            {
                if (true == stopTalk())
                {
                    //TwoWayAudio.Checked = false;
                    m_curRealPanel.m_twoWayAudioFlag = false;
                }
                else
                {
                    //TwoWayAudio.Checked = true;
                    m_curRealPanel.m_twoWayAudioFlag = true;
                }
            }
            else
            {
                if (true == startTwoWayAudio())
                {
                    //TwoWayAudio.Checked = true;
                    m_curRealPanel.m_twoWayAudioFlag = true;
                }
                else
                {
                    //TwoWayAudio.Checked = false;
                    m_curRealPanel.m_twoWayAudioFlag = false;
                }
            }
        }

        private bool stopTalk()
        {
            if (IntPtr.Zero == m_curRealPanel.m_talkHandle)
            {
                MessageBox.Show("Stop two way audio, Handle is NULL", "warning");
                return false;
            }
            int iRet = NETDEVSDK.NETDEV_StopVoiceCom(m_curRealPanel.m_talkHandle);
            if (NetDevSdk.TRUE != iRet)
            {
                showFailLogInfo(m_deviceInfoList[m_curRealPanel.m_deviceIndex].m_ip + " chl:" + (m_curRealPanel.m_channelID), "Stop two way audio", NETDEVSDK.NETDEV_GetLastError());
                return false;
            }
            else
            {
                showSuccessLogInfo(m_deviceInfoList[m_curRealPanel.m_deviceIndex].m_ip + " chl:" + (m_curRealPanel.m_channelID), "Stop two way audio");
                m_curRealPanel.m_talkHandle = IntPtr.Zero;
                return true;
            }
        }

        private bool startTwoWayAudio()
        {
            IntPtr handle = m_deviceInfoList[m_curRealPanel.m_deviceIndex].m_lpDevHandle;
            m_curRealPanel.m_talkHandle = NETDEVSDK.NETDEV_StartVoiceCom(handle, m_curRealPanel.m_channelID, IntPtr.Zero, IntPtr.Zero);
            if (IntPtr.Zero == m_curRealPanel.m_talkHandle)
            {
                showFailLogInfo(m_deviceInfoList[m_curRealPanel.m_deviceIndex].m_ip + " chl:" + (m_curRealPanel.m_channelID), "Start two way audio", NETDEVSDK.NETDEV_GetLastError());
                return false;
            }
            else
            {
                showSuccessLogInfo(m_deviceInfoList[m_curRealPanel.m_deviceIndex].m_ip + " chl:" + (m_curRealPanel.m_channelID), "Start two way audio");
                return true;
            }
        }

        private long getLongTime(String strTime)
        {
            DateTime dateTime = Convert.ToDateTime(strTime);
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 
            return (long)(dateTime - startTime).TotalSeconds; // 
        }

        private string getStrTime(long time)
        {
            DateTime startDateTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 
            return startDateTime.AddSeconds(time).ToString("yyyy/MM/dd HH:mm:ss");

        }

        public string GetDefaultString(byte[] utf8String)
        {
            utf8String = Encoding.Convert(Encoding.GetEncoding("UTF-8"), Encoding.Unicode, utf8String);
            string strUnicode = Encoding.Unicode.GetString(utf8String);
            strUnicode = strUnicode.Substring(0, strUnicode.IndexOf('\0'));
            return strUnicode;
        }

        public void GetUTF8Buffer(string inputString, int bufferLen, out byte[] utf8Buffer)
        {
            utf8Buffer = new byte[bufferLen];
            byte[] tempBuffer = System.Text.Encoding.UTF8.GetBytes(inputString);
            for (int i = 0; i < tempBuffer.Length; ++i)
            {
                utf8Buffer[i] = tempBuffer[i];
            }
        }

        private void inputPcmBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex == -1)
            {
                return;
            }

            int dwChannelID = m_CurSelectTreeNodeInfo.dwChannelID;
            IntPtr lpHandle = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;


            if (IntPtr.Zero == lpHandle)
            {
                MessageBox.Show("Device Handle is 0 ", "warning");
                return;
            }

            IntPtr lpPlayHandle = IntPtr.Zero;
            Int32 bRet = 0;
            lpPlayHandle = NETDEVSDK.NETDEV_StartInputVoiceSrv(lpHandle, dwChannelID);
            if (IntPtr.Zero == lpPlayHandle)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + dwChannelID, "Start Input Voice failed", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            else
            {
                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + dwChannelID, "Start Input Voice success");
            }
            if (!System.IO.File.Exists(@"..\demo\C#\NetDemo\8k16bits.pcm"))
            {
                return;
            }
            FileStream fs = new FileStream(@"..\demo\C#\NetDemo\8k16bits.pcm", FileMode.Open);//文件路径写死为相对路径
            BinaryReader sr = new BinaryReader(fs);
            int dwBufLen = 640; //单次发送长度，160的倍数
            NETDEV_AUDIO_SAMPLE_PARAM_S stVoiceParam = new NETDEV_AUDIO_SAMPLE_PARAM_S(); //NETDEV_InputVoiceData第四个参数可以传NULL，为通过C#入参校验，声明一个临时变量
            byte[] szBuf = new byte[dwBufLen];
            while (0 != sr.Read(szBuf, 0, dwBufLen))
            {
                bRet = NETDEVSDK.NETDEV_InputVoiceData(lpPlayHandle, szBuf, dwBufLen, ref stVoiceParam);
                if (0 == bRet)
                {
                    sr.Close();
                    showFailLogInfo(m_deviceInfoList[m_curRealPanel.m_deviceIndex].m_ip + " chl:" + dwChannelID, "NETDEV_InputVoiceData failed", NETDEVSDK.NETDEV_GetLastError());
                    return;
                }
                Thread.Sleep(40);// 根据采样频率，位宽，单次发送长度，计算延时时间
                Array.Clear(szBuf, 0, dwBufLen);
            }

            sr.Close();
            bRet = NETDEVSDK.NETDEV_StopInputVoiceSrv(lpPlayHandle);
            if (0 == bRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + dwChannelID, "NETDEV_StopInputVoiceSrv failed", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            else
            {
                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + dwChannelID, "NETDEV_StopInputVoiceSrv success");
            }

            return;
        }

        private void findPersonLibInfo()
        {
            personLibCmb.Items.Clear();
            faceMonitorObjectCmbBox.Items.Clear();
            mapPersonLib.Clear();
            PersonLibNameText.Text = "";

            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            Int32 bRet = 0;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;
            IntPtr pPersonLibHandle = NETDEVSDK.NETDEV_FindPersonLibList(lpUserID);
            if (IntPtr.Zero == pPersonLibHandle)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_FindPersonLibList failed", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            else
            {
                while (true)
                {
                    NETDEV_LIB_INFO_S stPersonLibInfo = new NETDEV_LIB_INFO_S();
                    bRet = NETDEVSDK.NETDEV_FindNextPersonLibInfo(pPersonLibHandle, ref stPersonLibInfo);
                    if (NetDevSdk.FALSE == bRet)
                    {
                        break;
                    }
                    mapPersonLib.Add(stPersonLibInfo.udwID, stPersonLibInfo);
                    personLibCmb.Items.Add(Convert.ToString(stPersonLibInfo.udwID));
                    faceMonitorObjectCmbBox.Items.Add(Convert.ToString(stPersonLibInfo.udwID));

                    personLibCmb.SelectedIndex = 0;
                    faceMonitorObjectCmbBox.SelectedIndex = 0;
                }
                bRet = NETDEVSDK.NETDEV_FindClosePersonLibList(pPersonLibHandle);
                if (NetDevSdk.FALSE == bRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_FindPersonLibList failed", NETDEVSDK.NETDEV_GetLastError());
                    return;
                }
                else
                {
                    showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_FindPersonLibList success");
                    return;
                }
            }
        }

        private void findPersonLibBtn_Click(object sender, EventArgs e)
        {
            findPersonLibInfo();
        }

        private void personLibCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UInt32 udwPersonLibID = Convert.ToUInt32(this.personLibCmb.SelectedItem);
            if (mapPersonLib.ContainsKey(udwPersonLibID))
            {
                PersonLibNameText.Text = GetDefaultString(mapPersonLib[udwPersonLibID].szName);
            }
        }

        private void addPersonLibBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            Int32 bRet = 0;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            NETDEV_LIB_INFO_S stPersonLibInfo = new NETDEV_LIB_INFO_S();
            GetUTF8Buffer(PersonLibNameText.Text, NetDevSdk.NETDEV_LEN_260, out stPersonLibInfo.szName);
            UInt32 udwLibID = 0;
            bRet = NETDEVSDK.NETDEV_CreatePersonLibInfo(lpUserID, ref stPersonLibInfo, ref udwLibID);
            if (NetDevSdk.FALSE == bRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_CreatePersonLibInfo failed", NETDEVSDK.NETDEV_GetLastError());
                return;
            }

            showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_CreatePersonLibInfo success");

            findPersonLibInfo();
        }

        private void modifyPersonLibBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            Int32 bRet = 0;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            NETDEV_PERSON_LIB_LIST_S stPersonLibList = new NETDEV_PERSON_LIB_LIST_S();
            stPersonLibList.udwNum = 1;
            stPersonLibList.pstLibInfo = IntPtr.Zero;

            NETDEV_LIB_INFO_S[] stPersonLibInfoList = new NETDEV_LIB_INFO_S[stPersonLibList.udwNum];
            UInt32 udwPersonLibID = Convert.ToUInt32(this.personLibCmb.SelectedItem);
            if (mapPersonLib.ContainsKey(udwPersonLibID))
            {
                stPersonLibInfoList[0] = mapPersonLib[udwPersonLibID];
                GetUTF8Buffer(PersonLibNameText.Text, NetDevSdk.NETDEV_LEN_260, out stPersonLibInfoList[0].szName);
            }
            else
            {
                return;
            }

            try
            {
                stPersonLibList.pstLibInfo = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETDEV_LIB_INFO_S)) * (int)stPersonLibList.udwNum);
                for (int i = 0; i < stPersonLibList.udwNum; i++)
                {
                    //IntPtr pstLibInfoListTemp = IntPtr.Add(stPersonLibList.pstLibInfo,Marshal.SizeOf(typeof(NETDEV_LIB_INFO_S)) * i);//.NET Framework 4.0
                    IntPtr pstLibInfoListTemp = new IntPtr(stPersonLibList.pstLibInfo.ToInt32() + Marshal.SizeOf(typeof(NETDEV_LIB_INFO_S)) * i);
                    Marshal.StructureToPtr(stPersonLibInfoList[i], pstLibInfoListTemp, true);
                }

                bRet = NETDEVSDK.NETDEV_ModifyPersonLibInfo(lpUserID, ref stPersonLibList);
                if (NetDevSdk.FALSE == bRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_ModifyPersonLibInfo failed", NETDEVSDK.NETDEV_GetLastError());
                }
                else
                {
                    showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_ModifyPersonLibInfo success");
                    findPersonLibInfo();
                }
            }
            finally
            {
                Marshal.FreeHGlobal(stPersonLibList.pstLibInfo);
            }
        }

        private void delPersonLibBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            Int32 bRet = 0;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            UInt32 udwPersonLibID = Convert.ToUInt32(this.personLibCmb.SelectedItem);
            if (mapPersonLib.ContainsKey(udwPersonLibID))
            {
                NETDEV_DELETE_DB_FLAG_INFO_S stFlagInfo = new NETDEV_DELETE_DB_FLAG_INFO_S();
                stFlagInfo.bIsDeleteMember = 1;
                bRet = NETDEVSDK.NETDEV_DeletePersonLibInfo(lpUserID, mapPersonLib[udwPersonLibID].udwID, ref stFlagInfo);
                if (NetDevSdk.FALSE == bRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_DeletePersonLibInfo failed", NETDEVSDK.NETDEV_GetLastError());
                    return;
                }

                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_DeletePersonLibInfo success");
                findPersonLibInfo();
            }
            else
            {
                return;
            }
        }

        private void clearPersonInfoTabWgt()
        {
            this.personInfoListView.Items.Clear();
            foreach (KeyValuePair<uint, NETDEV_PERSON_INFO_S> kvp in m_faceLibMemberInfoList)
            {
                NETDEV_PERSON_INFO_S stPersonInfo = kvp.Value;
                for (int j = 0; j < NetDevSdk.NETDEV_LEN_8; j++)
                {
                    Marshal.FreeHGlobal(stPersonInfo.stImageInfo[j].stFileInfo.pcData);
                }
            }

            m_faceLibMemberInfoList.Clear();
        }

        private void findPersonInfo(UInt32 udwPersonLibID, uint dwOffset)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            clearPersonInfoTabWgt();

            Int32 bRet = NetDevSdk.TRUE;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            NETDEV_PERSON_QUERY_INFO_S stQueryInfo = new NETDEV_PERSON_QUERY_INFO_S();
            stQueryInfo.udwLimit = NetDevSdk.NETDEMO_FIND_FACE_LIB_MEM_COUNT;
            stQueryInfo.udwOffset = dwOffset;
            NETDEV_BATCH_OPERATE_BASIC_S stQueryResultInfo = new NETDEV_BATCH_OPERATE_BASIC_S();

            IntPtr lpFindPersonHandle = NETDEVSDK.NETDEV_FindPersonInfoList(lpUserID, udwPersonLibID, ref stQueryInfo, ref stQueryResultInfo);
            if (IntPtr.Zero == lpFindPersonHandle || stQueryResultInfo.udwNum <= 0)
            {
                return;
            }

            while (NetDevSdk.TRUE == bRet)
            {
                NETDEV_PERSON_INFO_S stPersonInfo = new NETDEV_PERSON_INFO_S();

                stPersonInfo.stImageInfo = new NETDEV_IMAGE_INFO_S[NetDevSdk.NETDEV_LEN_8];
                for (int i = 0; i < NetDevSdk.NETDEV_LEN_8; i++)
                {
                    stPersonInfo.stImageInfo[i].stFileInfo.pcData = Marshal.AllocHGlobal(NetDevSdk.NETDEMO_SMALL_IMAGE_SIZE);
                    stPersonInfo.stImageInfo[i].stFileInfo.udwSize = NetDevSdk.NETDEMO_SMALL_IMAGE_SIZE;
                }

                bRet = NETDEVSDK.NETDEV_FindNextPersonInfo(lpFindPersonHandle, ref stPersonInfo);
                if (NetDevSdk.FALSE == bRet)
                {
                    NETDEVSDK.NETDEV_FindClosePersonInfoList(lpFindPersonHandle);
                    for (int j = 0; j < NetDevSdk.NETDEV_LEN_8; j++)
                    {
                        Marshal.FreeHGlobal(stPersonInfo.stImageInfo[j].stFileInfo.pcData);
                    }
                    break;
                }
                else
                {
                    m_faceLibMemberInfoList.Add(stPersonInfo.udwPersonID, stPersonInfo);
                }
            }

            showPersonInfo();
        }


        private void showPersonInfo()
        {
            foreach (KeyValuePair<uint, NETDEV_PERSON_INFO_S> kvp in m_faceLibMemberInfoList)
            {
                NETDEV_PERSON_INFO_S stPersonInfo = kvp.Value;

                string strGender;
                if ((int)NETDEV_GENDER_TYPE_E.NETDEV_GENDER_TYPE_MAN == stPersonInfo.udwGender)
                {
                    strGender = "Male";
                }
                else if ((int)NETDEV_GENDER_TYPE_E.NETDEV_GENDER_TYPE_WOMAN == stPersonInfo.udwGender)
                {
                    strGender = "Female";
                }
                else
                {
                    strGender = "Unidentified";
                }

                string strIdentificationType;
                switch (stPersonInfo.stIdentificationInfo[0].udwType)
                {
                    case (int)NETDEV_ID_TYPE_E.NETDEV_CERTIFICATE_TYPE_ID:
                        {
                            strIdentificationType = "ID Card";
                            break;
                        }
                    case (int)NETDEV_ID_TYPE_E.NETDEV_CERTIFICATE_TYPE_IC:
                        {
                            strIdentificationType = "IC Card";
                            break;
                        }
                    case (int)NETDEV_ID_TYPE_E.NETDEV_CERTIFICATE_TYPE_PASSPORT:
                        {
                            strIdentificationType = "Passport";
                            break;
                        }
                    case (int)NETDEV_ID_TYPE_E.NETDEV_CERTIFICATE_TYPE_DRIVING_LICENSE:
                        {
                            strIdentificationType = "Driver's License";
                            break;
                        }
                    case (int)NETDEV_ID_TYPE_E.NETDEV_CERTIFICATE_TYPE_OTHER:
                        {
                            strIdentificationType = "Other";
                            break;
                        }
                    default:
                        strIdentificationType = "unknown";
                        break;
                }

                ListViewItem item = new ListViewItem(Convert.ToString(stPersonInfo.udwPersonID));
                item.SubItems.Add(GetDefaultString(stPersonInfo.szPersonName));
                item.SubItems.Add(strGender);
                item.SubItems.Add(stPersonInfo.szBirthday);
                item.SubItems.Add(GetDefaultString(stPersonInfo.stRegionInfo.szNation));
                item.SubItems.Add(GetDefaultString(stPersonInfo.stRegionInfo.szProvince));
                item.SubItems.Add(GetDefaultString(stPersonInfo.stRegionInfo.szCity));
                item.SubItems.Add(strIdentificationType);
                item.SubItems.Add(stPersonInfo.stIdentificationInfo[0].szNumber);

                this.personInfoListView.Items.Add(item);
            }
        }

        private void findPersonInfoBtn_Click(object sender, EventArgs e)
        {
            UInt32 udwPersonLibID = Convert.ToUInt32(this.personLibCmb.SelectedItem);
            if (mapPersonLib.ContainsKey(udwPersonLibID))
            {
                m_dwFindFaceLibMemberOffset = 0;
                findPersonInfo(udwPersonLibID, m_dwFindFaceLibMemberOffset);
            }
            else
            {
                return;
            }
        }

        private void personInfoImagePictureBox_DoubleClick(object sender, EventArgs e)
        {
            m_strfacePicPath = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG|*.jpg";
            var ret = openFileDialog.ShowDialog();
            if (ret == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    m_strfacePicPath = openFileDialog.FileName;
                    Image image = Image.FromFile(m_strfacePicPath);
                    this.personInfoImagePictureBox.Image = image;
                    this.personInfoImagePictureBox.Refresh();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                this.personInfoImagePictureBox.Image = null;
            }
            openFileDialog.Dispose();
        }

        private void addPersonInfoBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            Int32 bRet = NetDevSdk.TRUE;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            if ("" == m_strfacePicPath || false == File.Exists(m_strfacePicPath))
            {
                MessageBox.Show("Picture path error");
                return;
            }

            UInt32 udwPersonLibID = Convert.ToUInt32(this.personLibCmb.SelectedItem);
            if (false == mapPersonLib.ContainsKey(udwPersonLibID))
            {
                return;
            }

            NETDEV_PERSON_INFO_LIST_S stPersonInfoList = new NETDEV_PERSON_INFO_LIST_S();
            stPersonInfoList.udwNum = 1;

            NETDEV_PERSON_INFO_S[] stPersonInfoListTemp = new NETDEV_PERSON_INFO_S[stPersonInfoList.udwNum];
            for (int i = 0; i < stPersonInfoList.udwNum; i++)
            {
                stPersonInfoListTemp[i] = new NETDEV_PERSON_INFO_S();
            }

            GetUTF8Buffer(personInfoNameText.Text, NetDevSdk.NETDEV_LEN_256, out stPersonInfoListTemp[0].szPersonName);
            stPersonInfoListTemp[0].udwGender = (uint)personInfoGenderCmb.SelectedIndex;
            GetUTF8Buffer(personInfoNationalityText.Text, NetDevSdk.NETDEV_LEN_128, out stPersonInfoListTemp[0].stRegionInfo.szNation);
            GetUTF8Buffer(personInfoProvinceText.Text, NetDevSdk.NETDEV_LEN_128, out stPersonInfoListTemp[0].stRegionInfo.szProvince);
            GetUTF8Buffer(personInfoCityText.Text, NetDevSdk.NETDEV_LEN_128, out stPersonInfoListTemp[0].stRegionInfo.szCity);
            stPersonInfoListTemp[0].szBirthday = personInfoBirthText.Text;

            stPersonInfoListTemp[0].udwIdentificationNum = 1;
            stPersonInfoListTemp[0].stIdentificationInfo = new NETDEV_IDENTIFICATION_INFO_S[NetDevSdk.NETDEV_LEN_8];
            for (int i = 0; i < NetDevSdk.NETDEV_LEN_8; i++)
            {
                stPersonInfoListTemp[0].stIdentificationInfo[i] = new NETDEV_IDENTIFICATION_INFO_S();
            }
            stPersonInfoListTemp[0].stIdentificationInfo[0].udwType = (uint)personInfoIDTypeCmb.SelectedIndex;
            stPersonInfoListTemp[0].stIdentificationInfo[0].szNumber = personInfoIDNoText.Text;

            stPersonInfoListTemp[0].stImageInfo = new NETDEV_IMAGE_INFO_S[NetDevSdk.NETDEV_LEN_8];
            for (int i = 0; i < NetDevSdk.NETDEV_LEN_8; i++)
            {
                stPersonInfoListTemp[0].stImageInfo[i] = new NETDEV_IMAGE_INFO_S();
            }
            stPersonInfoListTemp[0].udwImageNum = 1;

            byte[] data = File.ReadAllBytes(m_strfacePicPath);

            GetUTF8Buffer(m_strfacePicPath.Substring(m_strfacePicPath.LastIndexOf('\\') + 1), NetDevSdk.NETDEV_LEN_64, out stPersonInfoListTemp[0].stImageInfo[0].stFileInfo.szName);
            stPersonInfoListTemp[0].stImageInfo[0].stFileInfo.dwFileType = (int)NETDEV_FILE_TYPE_E.NETDEV_TYPE_FILE;
            stPersonInfoListTemp[0].stImageInfo[0].stFileInfo.pcData = Marshal.AllocHGlobal(data.Length);
            stPersonInfoListTemp[0].stImageInfo[0].stFileInfo.udwSize = (uint)data.Length;
            Marshal.Copy(data, 0, stPersonInfoListTemp[0].stImageInfo[0].stFileInfo.pcData, (int)stPersonInfoListTemp[0].stImageInfo[0].stFileInfo.udwSize);

            stPersonInfoList.pstPersonInfo = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETDEV_PERSON_INFO_S)) * (int)stPersonInfoList.udwNum);
            for (int i = 0; i < stPersonInfoList.udwNum; i++)
            {
                //IntPtr pstPersonInfoListTemp = IntPtr.Add(stPersonInfoList.pstPersonInfo,Marshal.SizeOf(typeof(NETDEV_PERSON_INFO_S)) * i);//.NET Framework 4.0
                IntPtr pstPersonInfoListTemp = new IntPtr(stPersonInfoList.pstPersonInfo.ToInt32() + Marshal.SizeOf(typeof(NETDEV_PERSON_INFO_S)) * i);
                Marshal.StructureToPtr(stPersonInfoListTemp[i], pstPersonInfoListTemp, true);
            }

            NETDEV_PERSON_RESULT_LIST_S stPersonResultList = new NETDEV_PERSON_RESULT_LIST_S();
            stPersonResultList.udwNum = stPersonInfoList.udwNum;
            stPersonResultList.pstPersonList = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETDEV_PERSON_LIST_S)) * (int)stPersonResultList.udwNum);

            NETDEV_PERSON_LIST_S[] stPersonResultListTemp = new NETDEV_PERSON_LIST_S[stPersonResultList.udwNum];
            for (int i = 0; i < stPersonResultList.udwNum; i++)
            {
                stPersonResultListTemp[i] = new NETDEV_PERSON_LIST_S();
            }

            for (int i = 0; i < stPersonResultList.udwNum; i++)
            {
                //IntPtr pPersonResultListTemp = IntPtr.Add(stPersonResultList.pstPersonList,Marshal.SizeOf(typeof(NETDEV_PERSON_LIST_S)) * i);//.NET Framework 4.0
                IntPtr pPersonResultListTemp = new IntPtr(stPersonResultList.pstPersonList.ToInt32() + Marshal.SizeOf(typeof(NETDEV_PERSON_LIST_S)) * i);
                Marshal.StructureToPtr(stPersonResultListTemp[i], pPersonResultListTemp, true);
            }

            bRet = NETDEVSDK.NETDEV_AddPersonInfo(lpUserID, udwPersonLibID, ref stPersonInfoList, ref stPersonResultList);
            if (NetDevSdk.FALSE == bRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_AddPersonInfo failed", NETDEVSDK.NETDEV_GetLastError());
            }
            else
            {
                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_AddPersonInfo success");
            }

            Marshal.FreeHGlobal(stPersonInfoListTemp[0].stImageInfo[0].stFileInfo.pcData);
            Marshal.FreeHGlobal(stPersonInfoList.pstPersonInfo);
            Marshal.FreeHGlobal(stPersonResultList.pstPersonList);

            m_dwFindFaceLibMemberOffset = 0;
            findPersonInfo(udwPersonLibID, m_dwFindFaceLibMemberOffset);
        }

        private void modifyPersonInfoBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            if (personInfoListView.SelectedItems.Count == 0)
            {
                return;
            }

            Int32 bRet = NetDevSdk.TRUE;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            if (null == personInfoImagePictureBox.Image &&
                ("" == m_strfacePicPath || false == File.Exists(m_strfacePicPath)))
            {
                MessageBox.Show("Picture path error");
                return;
            }

            UInt32 udwPersonLibID = Convert.ToUInt32(this.personLibCmb.SelectedItem);
            if (false == mapPersonLib.ContainsKey(udwPersonLibID))
            {
                return;
            }

            NETDEV_PERSON_INFO_LIST_S stPersonInfoList = new NETDEV_PERSON_INFO_LIST_S();
            stPersonInfoList.udwNum = 1;

            NETDEV_PERSON_INFO_S[] stPersonInfoListTemp = new NETDEV_PERSON_INFO_S[stPersonInfoList.udwNum];
            for (int i = 0; i < stPersonInfoList.udwNum; i++)
            {
                stPersonInfoListTemp[i] = new NETDEV_PERSON_INFO_S();
            }

            UInt32 udwPersonID = Convert.ToUInt32(personInfoListView.SelectedItems[0].SubItems[0].Text);//ID
            if (m_faceLibMemberInfoList.ContainsKey(udwPersonID))
            {
                stPersonInfoListTemp[0] = m_faceLibMemberInfoList[udwPersonID];
            }
            else
            {
                return;
            }

            stPersonInfoListTemp[0].udwPersonID = udwPersonID;
            GetUTF8Buffer(personInfoNameText.Text, NetDevSdk.NETDEV_LEN_256, out stPersonInfoListTemp[0].szPersonName);
            stPersonInfoListTemp[0].udwGender = (uint)personInfoGenderCmb.SelectedIndex;
            GetUTF8Buffer(personInfoNationalityText.Text, NetDevSdk.NETDEV_LEN_128, out stPersonInfoListTemp[0].stRegionInfo.szNation);
            GetUTF8Buffer(personInfoProvinceText.Text, NetDevSdk.NETDEV_LEN_128, out stPersonInfoListTemp[0].stRegionInfo.szProvince);
            GetUTF8Buffer(personInfoCityText.Text, NetDevSdk.NETDEV_LEN_128, out stPersonInfoListTemp[0].stRegionInfo.szCity);
            stPersonInfoListTemp[0].szBirthday = personInfoBirthText.Text;

            stPersonInfoListTemp[0].stIdentificationInfo[0].udwType = (uint)personInfoIDTypeCmb.SelectedIndex;
            stPersonInfoListTemp[0].stIdentificationInfo[0].szNumber = personInfoIDNoText.Text;

            if ("" != m_strfacePicPath)
            {
                byte[] data = File.ReadAllBytes(m_strfacePicPath);
                Marshal.FreeHGlobal(stPersonInfoListTemp[0].stImageInfo[0].stFileInfo.pcData);
                stPersonInfoListTemp[0].stImageInfo[0].stFileInfo.pcData = Marshal.AllocHGlobal(data.Length);
                stPersonInfoListTemp[0].stImageInfo[0].stFileInfo.udwSize = (uint)data.Length;
                Marshal.Copy(data, 0, stPersonInfoListTemp[0].stImageInfo[0].stFileInfo.pcData, (int)stPersonInfoListTemp[0].stImageInfo[0].stFileInfo.udwSize);
            }

            stPersonInfoList.pstPersonInfo = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETDEV_PERSON_INFO_S)) * (int)stPersonInfoList.udwNum);
            for (int i = 0; i < stPersonInfoList.udwNum; i++)
            {
                //IntPtr pstPersonInfoListTemp = IntPtr.Add(stPersonInfoList.pstPersonInfo,Marshal.SizeOf(typeof(NETDEV_PERSON_INFO_S)) * i);//.NET Framework 4.0
                IntPtr pstPersonInfoListTemp = new IntPtr(stPersonInfoList.pstPersonInfo.ToInt32() + Marshal.SizeOf(typeof(NETDEV_PERSON_INFO_S)) * i);
                Marshal.StructureToPtr(stPersonInfoListTemp[i], pstPersonInfoListTemp, true);
            }

            NETDEV_PERSON_RESULT_LIST_S stPersonResultList = new NETDEV_PERSON_RESULT_LIST_S();
            stPersonResultList.udwNum = stPersonInfoList.udwNum;
            stPersonResultList.pstPersonList = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETDEV_PERSON_LIST_S)) * (int)stPersonResultList.udwNum);

            NETDEV_PERSON_LIST_S[] stPersonResultListTemp = new NETDEV_PERSON_LIST_S[stPersonResultList.udwNum];
            for (int i = 0; i < stPersonResultList.udwNum; i++)
            {
                stPersonResultListTemp[i] = new NETDEV_PERSON_LIST_S();
            }

            for (int i = 0; i < stPersonResultList.udwNum; i++)
            {
                //IntPtr pPersonResultListTemp = IntPtr.Add(stPersonResultList.pstPersonList,Marshal.SizeOf(typeof(NETDEV_PERSON_LIST_S)) * i);//.NET Framework 4.0
                IntPtr pPersonResultListTemp = new IntPtr(stPersonResultList.pstPersonList.ToInt32() + Marshal.SizeOf(typeof(NETDEV_PERSON_LIST_S)) * i);
                Marshal.StructureToPtr(stPersonResultListTemp[i], pPersonResultListTemp, true);
            }

            bRet = NETDEVSDK.NETDEV_ModifyPersonInfo(lpUserID, udwPersonLibID, ref stPersonInfoList, ref stPersonResultList);
            if (NetDevSdk.FALSE == bRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_ModifyPersonInfo failed", NETDEVSDK.NETDEV_GetLastError());
            }
            else
            {
                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_ModifyPersonInfo success");
            }

            Marshal.FreeHGlobal(stPersonInfoList.pstPersonInfo);
            Marshal.FreeHGlobal(stPersonResultList.pstPersonList);

            m_dwFindFaceLibMemberOffset = 0;
            findPersonInfo(udwPersonLibID, m_dwFindFaceLibMemberOffset);
        }

        private void delPersonInfoBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            if (personInfoListView.SelectedItems.Count == 0)
            {
                return;
            }

            Int32 bRet = NetDevSdk.TRUE;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            UInt32 udwPersonLibID = Convert.ToUInt32(this.personLibCmb.SelectedItem);
            if (false == mapPersonLib.ContainsKey(udwPersonLibID))
            {
                return;
            }

            UInt32 udwPersonID = Convert.ToUInt32(personInfoListView.SelectedItems[0].SubItems[0].Text);//ID
            if (false == m_faceLibMemberInfoList.ContainsKey(udwPersonID))
            {
                return;
            }

            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_IPC_OR_NVR == m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_eDeviceType)
            {
                uint udwLastChange = 0;
                bRet = NETDEVSDK.NETDEV_DeletePersonInfo(lpUserID, udwPersonLibID, udwPersonID, udwLastChange);
                if (NetDevSdk.FALSE == bRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_DeletePersonInfo failed", NETDEVSDK.NETDEV_GetLastError());
                }
                else
                {
                    showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_DeletePersonInfo success");
                }
            }
            else
            {
                NETDEV_BATCH_OPERATE_MEMBER_LIST_S stIDList = new NETDEV_BATCH_OPERATE_MEMBER_LIST_S();
                stIDList.udwMemberNum = 1;

                uint[] iTmp = new uint[stIDList.udwMemberNum];
                iTmp[0] = udwPersonID;
                stIDList.pstMemberIDList = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(uint)) * (int)stIDList.udwMemberNum);
                for (int i = 0; i < stIDList.udwMemberNum; ++i)
                {
                    IntPtr pstMemberIDListTemp = new IntPtr(stIDList.pstMemberIDList.ToInt32() + Marshal.SizeOf(typeof(uint)) * i);
                    Marshal.StructureToPtr(iTmp[i], pstMemberIDListTemp, true);
                }

                NETDEV_BATCH_OPERATOR_LIST_S stResutList = new NETDEV_BATCH_OPERATOR_LIST_S();
                stResutList.udwNum = 1;

                NETDEV_BATCH_OPERATOR_INFO_S[] stBatchOperInfoListTmp = new NETDEV_BATCH_OPERATOR_INFO_S[stIDList.udwMemberNum];
                stResutList.pstBatchList = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETDEV_BATCH_OPERATOR_INFO_S)) * (int)stResutList.udwNum);
                for (int i = 0; i < stResutList.udwNum; ++i)
                {
                    IntPtr pstBatchListTemp = new IntPtr(stResutList.pstBatchList.ToInt32() + Marshal.SizeOf(typeof(NETDEV_BATCH_OPERATOR_INFO_S)) * i);
                    Marshal.StructureToPtr(stBatchOperInfoListTmp[i], pstBatchListTemp, true);
                }

                bRet = NETDEVSDK.NETDEV_DeletePersonInfoList(lpUserID, udwPersonLibID, ref stIDList, ref stResutList);
                if (NetDevSdk.FALSE == bRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_DeletePersonInfoList failed", NETDEVSDK.NETDEV_GetLastError());
                }
                else
                {
                    showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_DeletePersonInfoList success");
                }

                Marshal.FreeHGlobal(stIDList.pstMemberIDList);
                Marshal.FreeHGlobal(stResutList.pstBatchList);
            }

            m_dwFindFaceLibMemberOffset = 0;
            findPersonInfo(udwPersonLibID, m_dwFindFaceLibMemberOffset);
        }

        private void personInfoListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (personInfoListView.SelectedItems.Count == 0)
            {
                return;
            }

            setListViewSelectedColor(((ListView)sender));

            UInt32 udwPersonID = Convert.ToUInt32(personInfoListView.SelectedItems[0].SubItems[0].Text);//ID
            if (m_faceLibMemberInfoList.ContainsKey(udwPersonID))
            {
                if (m_faceLibMemberInfoList[udwPersonID].udwImageNum > 0)
                {
                    byte[] personFaceImageInfo = new byte[m_faceLibMemberInfoList[udwPersonID].stImageInfo[0].stFileInfo.udwSize];
                    Marshal.Copy(m_faceLibMemberInfoList[udwPersonID].stImageInfo[0].stFileInfo.pcData, personFaceImageInfo, 0, (int)m_faceLibMemberInfoList[udwPersonID].stImageInfo[0].stFileInfo.udwSize);
                    using (MemoryStream stream = new MemoryStream(personFaceImageInfo))
                    {
                        try
                        {
                            Image faceImage = Image.FromStream(stream);
                            this.personInfoImagePictureBox.Image = faceImage;
                            this.personInfoImagePictureBox.Refresh();

                            m_strfacePicPath = "";
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                }
                else
                {
                    this.personInfoImagePictureBox.Image = null;
                }
            }


            personInfoNameText.Text = personInfoListView.SelectedItems[0].SubItems[1].Text;//name
            personInfoGenderCmb.Text = personInfoListView.SelectedItems[0].SubItems[2].Text;//Gender
            personInfoBirthText.Text = personInfoListView.SelectedItems[0].SubItems[3].Text;//birth
            personInfoNationalityText.Text = personInfoListView.SelectedItems[0].SubItems[4].Text;//Nation
            personInfoProvinceText.Text = personInfoListView.SelectedItems[0].SubItems[5].Text;//province
            personInfoCityText.Text = personInfoListView.SelectedItems[0].SubItems[6].Text;//city
            personInfoIDTypeCmb.Text = personInfoListView.SelectedItems[0].SubItems[7].Text;//ID Type
            personInfoIDNoText.Text = personInfoListView.SelectedItems[0].SubItems[8].Text;//ID No.
        }

        private void previousPersonInfoBtn_Click(object sender, EventArgs e)
        {
            UInt32 udwPersonLibID = Convert.ToUInt32(this.personLibCmb.SelectedItem);
            if (false == mapPersonLib.ContainsKey(udwPersonLibID))
            {
                return;
            }

            if (m_dwFindFaceLibMemberOffset > NetDevSdk.NETDEMO_FIND_FACE_LIB_MEM_COUNT)
            {
                m_dwFindFaceLibMemberOffset -= NetDevSdk.NETDEMO_FIND_FACE_LIB_MEM_COUNT;
            }
            else
            {
                m_dwFindFaceLibMemberOffset = 0;
            }

            findPersonInfo(udwPersonLibID, m_dwFindFaceLibMemberOffset);
        }

        private void nextPersonInfoBtn_Click(object sender, EventArgs e)
        {
            UInt32 udwPersonLibID = Convert.ToUInt32(this.personLibCmb.SelectedItem);
            if (false == mapPersonLib.ContainsKey(udwPersonLibID))
            {
                return;
            }

            m_dwFindFaceLibMemberOffset += NetDevSdk.NETDEMO_FIND_FACE_LIB_MEM_COUNT;

            findPersonInfo(udwPersonLibID, m_dwFindFaceLibMemberOffset);
        }

        private void showFaceMonitorTaskInfo()
        {
            faceMonitorInfoListView.Items.Clear();

            foreach (KeyValuePair<uint, NETDEV_MONITION_INFO_S> kvp in m_faceMonitorTaskList)
            {
                NETDEV_MONITION_INFO_S stFaceMonitorTaskInfo = kvp.Value;

                string strStatus;
                if (NetDevSdk.FALSE == stFaceMonitorTaskInfo.stMonitorRuleInfo.bEnabled)
                {
                    strStatus = "Disable";
                }
                else
                {
                    strStatus = "Enable";
                }

                string strPersonLibName = "";
                if (stFaceMonitorTaskInfo.stMonitorRuleInfo.udwLibNum > 0)
                {
                    UInt32 udwPersonLibID = stFaceMonitorTaskInfo.stMonitorRuleInfo.audwLibList[0];//ID
                    if (mapPersonLib.ContainsKey(udwPersonLibID))
                    {
                        strPersonLibName += GetDefaultString(mapPersonLib[udwPersonLibID].szName);
                    }
                }

                ListViewItem item = new ListViewItem(Convert.ToString(stFaceMonitorTaskInfo.udwID));
                item.SubItems.Add(GetDefaultString(stFaceMonitorTaskInfo.stMonitorRuleInfo.szName));
                item.SubItems.Add(GetDefaultString(stFaceMonitorTaskInfo.stMonitorRuleInfo.szReason));
                item.SubItems.Add(Convert.ToString(stFaceMonitorTaskInfo.stMonitorRuleInfo.udwMultipleValue));
                item.SubItems.Add(strPersonLibName);
                item.SubItems.Add(strStatus);

                this.faceMonitorInfoListView.Items.Add(item);
            }
        }

        private void clearFaceMonitorTaskInfo()
        {
            faceMonitorInfoListView.Items.Clear();
            foreach (KeyValuePair<uint, NETDEV_MONITION_INFO_S> kvp in m_faceMonitorTaskList)
            {
                NETDEV_MONITION_INFO_S stFaceMonitorTaskInfo = kvp.Value;
                Marshal.FreeHGlobal(stFaceMonitorTaskInfo.stMonitorRuleInfo.pudwMonitorChlIDList);
                Marshal.FreeHGlobal(stFaceMonitorTaskInfo.pstLinkStrategyList);
            }

            m_faceMonitorTaskList.Clear();
        }

        private void findFaceMonitorTaskInfo()
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            Int32 bRet = NetDevSdk.TRUE;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            clearFaceMonitorTaskInfo();

            uint udwChannelID = (uint)getChannelID();

            NETDEV_MONITOR_QUERY_INFO_S stQueryInfo = new NETDEV_MONITOR_QUERY_INFO_S();
            stQueryInfo.udwLimit = 20;
            IntPtr lpPersonMonitorHandle = NETDEVSDK.NETDEV_FindPersonMonitorList(lpUserID, udwChannelID, ref stQueryInfo);
            if (IntPtr.Zero == lpPersonMonitorHandle)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_FindPersonMonitorList failed", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            else
            {
                while (true)
                {
                    NETDEV_MONITION_INFO_S stMonitorInfo = new NETDEV_MONITION_INFO_S();

                    stMonitorInfo.stMonitorRuleInfo.udwChannelNum = 1;
                    uint[] iTmp = new uint[stMonitorInfo.stMonitorRuleInfo.udwChannelNum];
                    stMonitorInfo.stMonitorRuleInfo.pudwMonitorChlIDList = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(uint)) * (int)stMonitorInfo.stMonitorRuleInfo.udwChannelNum);
                    for (int i = 0; i < stMonitorInfo.stMonitorRuleInfo.udwChannelNum; ++i)
                    {
                        IntPtr pudwMonitorChlIDListTemp = new IntPtr(stMonitorInfo.stMonitorRuleInfo.pudwMonitorChlIDList.ToInt32() + Marshal.SizeOf(typeof(uint)) * i);
                        Marshal.StructureToPtr(iTmp[i], pudwMonitorChlIDListTemp, true);
                    }

                    stMonitorInfo.udwLinkStrategyNum = 10;
                    NETDEV_LINKAGE_STRATEGY_S[] stLinkStrategyListTmp = new NETDEV_LINKAGE_STRATEGY_S[stMonitorInfo.udwLinkStrategyNum];
                    stMonitorInfo.pstLinkStrategyList = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETDEV_LINKAGE_STRATEGY_S)) * (int)stMonitorInfo.udwLinkStrategyNum);
                    for (int i = 0; i < stMonitorInfo.udwLinkStrategyNum; ++i)
                    {
                        IntPtr pstLinkStrategyListTmp = new IntPtr(stMonitorInfo.pstLinkStrategyList.ToInt32() + Marshal.SizeOf(typeof(NETDEV_LINKAGE_STRATEGY_S)) * i);
                        Marshal.StructureToPtr(stLinkStrategyListTmp[i], pstLinkStrategyListTmp, true);
                    }

                    bRet = NETDEVSDK.NETDEV_FindNextPersonMonitorInfo(lpPersonMonitorHandle, ref stMonitorInfo);
                    if (NetDevSdk.FALSE == bRet)
                    {
                        Marshal.FreeHGlobal(stMonitorInfo.stMonitorRuleInfo.pudwMonitorChlIDList);
                        Marshal.FreeHGlobal(stMonitorInfo.pstLinkStrategyList);
                        break;
                    }
                    else
                    {
                        NETDEVSDK.NETDEV_GetPersonMonitorRuleInfo(lpUserID, ref stMonitorInfo);
                        m_faceMonitorTaskList.Add(stMonitorInfo.udwID, stMonitorInfo);
                    }
                }

                NETDEVSDK.NETDEV_FindClosePersonMonitorList(lpPersonMonitorHandle);
                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_FindPersonMonitorList success");
                findPersonLibInfo();
                showFaceMonitorTaskInfo();
            }
        }

        private void FindFaceMonitorBtn_Click(object sender, EventArgs e)
        {
            findFaceMonitorTaskInfo();
        }

        private void addFaceMonitorBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            Int32 bRet = NetDevSdk.TRUE;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            NETDEV_MONITION_INFO_S stMonitorInfo = new NETDEV_MONITION_INFO_S();
            stMonitorInfo.stMonitorRuleInfo.bEnabled = 1;
            GetUTF8Buffer(faceMonitorTaskNameTextBox.Text, NetDevSdk.NETDEV_FACE_MONITOR_RULE_NAME_LEN, out stMonitorInfo.stMonitorRuleInfo.szName);
            GetUTF8Buffer(faceMonitorRemarksTextBox.Text, NetDevSdk.NETDEV_FACE_MONITOR_RULE_REASON_LEN, out stMonitorInfo.stMonitorRuleInfo.szReason);
            stMonitorInfo.stMonitorRuleInfo.udwMonitorType = (UInt32)faceMonitorTypeCmbBox.SelectedIndex;

            stMonitorInfo.stMonitorRuleInfo.udwLibNum = 1;
            stMonitorInfo.stMonitorRuleInfo.audwLibList = new UInt32[NetDevSdk.NETDEV_LEN_32];
            stMonitorInfo.stMonitorRuleInfo.audwLibList[0] = Convert.ToUInt32(faceMonitorObjectCmbBox.Text);

            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_IPC_OR_NVR == m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_eDeviceType)
            {
                if (getChannelID() < 0)
                {
                    MessageBox.Show("Please select a channel");
                    return;
                }

                stMonitorInfo.stMonitorRuleInfo.udwMultipleValue = Convert.ToUInt32(faceMonitorThresholdTextBox.Text);

                stMonitorInfo.stMonitorRuleInfo.udwChannelNum = 1;
                uint[] iTmp = new uint[stMonitorInfo.stMonitorRuleInfo.udwChannelNum];
                iTmp[0] = (UInt32)getChannelID();
                stMonitorInfo.stMonitorRuleInfo.pudwMonitorChlIDList = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(uint)) * (int)stMonitorInfo.stMonitorRuleInfo.udwChannelNum);
                for (int i = 0; i < stMonitorInfo.stMonitorRuleInfo.udwChannelNum; ++i)
                {
                    IntPtr pudwMonitorChlIDListTemp = new IntPtr(stMonitorInfo.stMonitorRuleInfo.pudwMonitorChlIDList.ToInt32() + Marshal.SizeOf(typeof(uint)) * i);
                    Marshal.StructureToPtr(iTmp[i], pudwMonitorChlIDListTemp, true);
                }

                stMonitorInfo.stWeekPlan.bEnabled = 1;
                stMonitorInfo.stWeekPlan.udwDayNum = 8;
                stMonitorInfo.stWeekPlan.astDayPlan = new NETDEV_VIDEO_DAY_PLAN_S[NetDevSdk.NETDEV_PLAN_NUM_AWEEK];
                for (int i = 0; i < stMonitorInfo.stWeekPlan.udwDayNum; i++)
                {
                    stMonitorInfo.stWeekPlan.astDayPlan[i].udwIndex = i + 1;
                    stMonitorInfo.stWeekPlan.astDayPlan[i].udwSectionNum = 1;
                    stMonitorInfo.stWeekPlan.astDayPlan[i].astTimeSection = new NETDEV_VIDEO_TIME_SECTION_S[NetDevSdk.NETDEV_PLAN_NUM_AWEEK];
                    for (int j = 0; j < stMonitorInfo.stWeekPlan.astDayPlan[i].udwSectionNum; j++)
                    {
                        stMonitorInfo.stWeekPlan.astDayPlan[i].astTimeSection[j].szBeginTime = "00:00:00";
                        stMonitorInfo.stWeekPlan.astDayPlan[i].astTimeSection[j].szEndTime = "23:59:59";
                        stMonitorInfo.stWeekPlan.astDayPlan[i].astTimeSection[j].udArmingType = (UInt32)NETDEV_ARMING_TYPE_E.NETDEV_ARMING_TYPE_TIMING;
                    }
                }
            }
            else
            {
                if (getSubDeviceID() < 0)
                {
                    MessageBox.Show("Please select a device");
                    return;
                }

                stMonitorInfo.stMonitorRuleInfo.udwDevNum = 1;
                stMonitorInfo.stMonitorRuleInfo.audwMonitorDevIDList = new UInt32[NetDevSdk.NETDEV_LEN_32];
                stMonitorInfo.stMonitorRuleInfo.audwMonitorDevIDList[0] = (UInt32)getSubDeviceID();

            }

            NETDEV_MONITOR_RESULT_INFO_S stMonitorResultInfo = new NETDEV_MONITOR_RESULT_INFO_S();
            stMonitorResultInfo.udwChannelNum = 1;
            NETDEV_MONITION_CHL_INFO_S[] stMonitorChlInfosTmp = new NETDEV_MONITION_CHL_INFO_S[stMonitorResultInfo.udwChannelNum];
            stMonitorResultInfo.pstMonitorChlInfos = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETDEV_MONITION_CHL_INFO_S)) * (int)stMonitorResultInfo.udwChannelNum);
            for (int i = 0; i < stMonitorInfo.udwLinkStrategyNum; ++i)
            {
                IntPtr pstMonitorChlInfosTemp = new IntPtr(stMonitorResultInfo.pstMonitorChlInfos.ToInt32() + Marshal.SizeOf(typeof(NETDEV_MONITION_CHL_INFO_S)) * i);
                Marshal.StructureToPtr(stMonitorChlInfosTmp[i], pstMonitorChlInfosTemp, true);
            }

            bRet = NETDEVSDK.NETDEV_AddPersonMonitorInfo(lpUserID, ref stMonitorInfo, ref stMonitorResultInfo);
            if (NetDevSdk.FALSE == bRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_AddPersonMonitorInfo failed", NETDEVSDK.NETDEV_GetLastError());
            }
            else
            {
                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_AddPersonMonitorInfo success");
            }

            Marshal.FreeHGlobal(stMonitorResultInfo.pstMonitorChlInfos);
            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_IPC_OR_NVR == m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_eDeviceType)
            {
                Marshal.FreeHGlobal(stMonitorInfo.stMonitorRuleInfo.pudwMonitorChlIDList);
            }
            findFaceMonitorTaskInfo();
        }

        private void modifyFaceMonitorBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            if (faceMonitorInfoListView.SelectedItems.Count == 0)
            {
                return;
            }

            Int32 bRet = NetDevSdk.TRUE;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            NETDEV_MONITION_INFO_S stMonitorInfo = new NETDEV_MONITION_INFO_S();

            UInt32 udwMonitorTaskID = Convert.ToUInt32(faceMonitorInfoListView.SelectedItems[0].SubItems[0].Text);//ID
            if (m_faceMonitorTaskList.ContainsKey(udwMonitorTaskID))
            {
                stMonitorInfo.udwID = udwMonitorTaskID;
                stMonitorInfo = m_faceMonitorTaskList[udwMonitorTaskID];
            }
            else
            {
                return;
            }

            GetUTF8Buffer(faceMonitorTaskNameTextBox.Text, NetDevSdk.NETDEV_FACE_MONITOR_RULE_NAME_LEN, out stMonitorInfo.stMonitorRuleInfo.szName);
            GetUTF8Buffer(faceMonitorRemarksTextBox.Text, NetDevSdk.NETDEV_FACE_MONITOR_RULE_REASON_LEN, out stMonitorInfo.stMonitorRuleInfo.szReason);
            stMonitorInfo.stMonitorRuleInfo.udwMonitorType = (UInt32)faceMonitorTypeCmbBox.SelectedIndex;

            stMonitorInfo.stMonitorRuleInfo.audwLibList[0] = Convert.ToUInt32(faceMonitorObjectCmbBox.Text);

            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_IPC_OR_NVR == m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_eDeviceType)
            {
                if (getChannelID() < 0)
                {
                    MessageBox.Show("Please select a channel");
                    return;
                }

                stMonitorInfo.stMonitorRuleInfo.udwMultipleValue = Convert.ToUInt32(faceMonitorThresholdTextBox.Text);
            }
            else
            {
                if (getSubDeviceID() < 0)
                {
                    MessageBox.Show("Please select a device");
                    return;
                }
            }

            bRet = NETDEVSDK.NETDEV_SetPersonMonitorRuleInfo(lpUserID, ref stMonitorInfo);
            if (NetDevSdk.FALSE == bRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_SetPersonMonitorRuleInfo failed", NETDEVSDK.NETDEV_GetLastError());
            }
            else
            {
                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_SetPersonMonitorRuleInfo success");
            }

            findFaceMonitorTaskInfo();
        }

        private void delFaceMonitorBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            if (faceMonitorInfoListView.SelectedItems.Count == 0)
            {
                return;
            }

            Int32 bRet = NetDevSdk.TRUE;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            UInt32 udwMonitorTaskID = Convert.ToUInt32(faceMonitorInfoListView.SelectedItems[0].SubItems[0].Text);//ID

            NETDEV_BATCH_OPERATOR_LIST_S stBatchList = new NETDEV_BATCH_OPERATOR_LIST_S();
            stBatchList.udwNum = 1;

            NETDEV_BATCH_OPERATOR_INFO_S[] stOperTorInfoArr = new NETDEV_BATCH_OPERATOR_INFO_S[stBatchList.udwNum];
            stOperTorInfoArr[0].udwID = udwMonitorTaskID;
            stBatchList.pstBatchList = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETDEV_BATCH_OPERATOR_INFO_S)) * (int)stBatchList.udwNum);
            for (int i = 0; i < stBatchList.udwNum; ++i)
            {
                IntPtr pstBatchListTemp = new IntPtr(stBatchList.pstBatchList.ToInt32() + Marshal.SizeOf(typeof(NETDEV_BATCH_OPERATOR_INFO_S)) * i);
                Marshal.StructureToPtr(stOperTorInfoArr[i], pstBatchListTemp, true);
            }

            bRet = NETDEVSDK.NETDEV_BatchDeletePersonMonitorInfo(lpUserID, ref stBatchList);
            if (NetDevSdk.FALSE == bRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_BatchDeletePersonMonitorInfo failed", NETDEVSDK.NETDEV_GetLastError());
            }
            else
            {
                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_BatchDeletePersonMonitorInfo success");
            }

            Marshal.FreeHGlobal(stBatchList.pstBatchList);
            findFaceMonitorTaskInfo();
        }

        private void enableFaceMonitorBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            if (faceMonitorInfoListView.SelectedItems.Count == 0)
            {
                return;
            }

            Int32 bRet = NetDevSdk.TRUE;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            UInt32 udwMonitorTaskID = Convert.ToUInt32(faceMonitorInfoListView.SelectedItems[0].SubItems[0].Text);//ID
            if (m_faceMonitorTaskList.ContainsKey(udwMonitorTaskID))
            {
                NETDEV_MONITION_INFO_S stPersonMonitorInfo = new NETDEV_MONITION_INFO_S();
                stPersonMonitorInfo = m_faceMonitorTaskList[udwMonitorTaskID];
                bRet = NETDEVSDK.NETDEV_GetPersonMonitorRuleInfo(lpUserID, ref stPersonMonitorInfo);
                if (NetDevSdk.FALSE == bRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_GetPersonMonitorRuleInfo failed", NETDEVSDK.NETDEV_GetLastError());
                    return;
                }

                stPersonMonitorInfo.stMonitorRuleInfo.bEnabled = 1;
                bRet = NETDEVSDK.NETDEV_SetPersonMonitorRuleInfo(lpUserID, ref stPersonMonitorInfo);
                if (NetDevSdk.FALSE == bRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_SetMonitorEnableInfo failed", NETDEVSDK.NETDEV_GetLastError());
                    return;
                }
                else
                {
                    showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_SetMonitorEnableInfo success");
                }

                findFaceMonitorTaskInfo();
            }
        }

        private void disableFaceMonitorBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            if (faceMonitorInfoListView.SelectedItems.Count == 0)
            {
                return;
            }

            Int32 bRet = NetDevSdk.TRUE;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            UInt32 udwMonitorTaskID = Convert.ToUInt32(faceMonitorInfoListView.SelectedItems[0].SubItems[0].Text);//ID
            if (m_faceMonitorTaskList.ContainsKey(udwMonitorTaskID))
            {
                NETDEV_MONITION_INFO_S stPersonMonitorInfo = new NETDEV_MONITION_INFO_S();
                stPersonMonitorInfo = m_faceMonitorTaskList[udwMonitorTaskID];
                bRet = NETDEVSDK.NETDEV_GetPersonMonitorRuleInfo(lpUserID, ref stPersonMonitorInfo);
                if (NetDevSdk.FALSE == bRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_GetPersonMonitorRuleInfo failed", NETDEVSDK.NETDEV_GetLastError());
                    return;
                }

                stPersonMonitorInfo.stMonitorRuleInfo.bEnabled = 0;
                bRet = NETDEVSDK.NETDEV_SetPersonMonitorRuleInfo(lpUserID, ref stPersonMonitorInfo);
                if (NetDevSdk.FALSE == bRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_SetMonitorEnableInfo failed", NETDEVSDK.NETDEV_GetLastError());
                    return;
                }
                else
                {
                    showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_SetMonitorEnableInfo success");
                }

                findFaceMonitorTaskInfo();
            }
        }

        private void faceMonitorInfoListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (faceMonitorInfoListView.SelectedItems.Count == 0)
            {
                return;
            }

            setListViewSelectedColor(((ListView)sender));

            UInt32 udwMonitorTaskID = Convert.ToUInt32(faceMonitorInfoListView.SelectedItems[0].SubItems[0].Text);//ID
            if (m_faceMonitorTaskList.ContainsKey(udwMonitorTaskID))
            {
                faceMonitorTaskNameTextBox.Text = faceMonitorInfoListView.SelectedItems[0].SubItems[1].Text;//name
                faceMonitorRemarksTextBox.Text = faceMonitorInfoListView.SelectedItems[0].SubItems[2].Text;//remarks
                faceMonitorThresholdTextBox.Text = faceMonitorInfoListView.SelectedItems[0].SubItems[3].Text;//threshold
                faceMonitorTaskLibNameText.Text = faceMonitorInfoListView.SelectedItems[0].SubItems[4].Text;//monitoring object
                faceMonitorObjectCmbBox.Text = Convert.ToString(m_faceMonitorTaskList[udwMonitorTaskID].stMonitorRuleInfo.audwLibList[0]);
                faceMonitorTypeCmbBox.SelectedIndex = (int)m_faceMonitorTaskList[udwMonitorTaskID].stMonitorRuleInfo.udwMonitorType;//monitoring Type
            }
        }

        private void faceMonitorObjectCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UInt32 udwPersonLibID = Convert.ToUInt32(this.faceMonitorObjectCmbBox.SelectedItem);
            if (mapPersonLib.ContainsKey(udwPersonLibID))
            {
                faceMonitorTaskLibNameText.Text = GetDefaultString(mapPersonLib[udwPersonLibID].szName);
            }
        }

        public void startRealPlay(PlayPanel curRealPanel)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0 || getChannelID() < 0)
            {
                return;
            }

            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            curRealPanel.initPlayPanel();
            curRealPanel.m_deviceIndex = m_CurSelectTreeNodeInfo.dwDeviceIndex;
            curRealPanel.m_channelID = getChannelID();

            NETDEV_PREVIEWINFO_S stPreviewInfo = new NETDEV_PREVIEWINFO_S();
            stPreviewInfo.dwChannelID = getChannelID();
            //stPreviewInfo.dwFluency = 
            stPreviewInfo.dwLinkMode = (int)NETDEV_PROTOCAL_E.NETDEV_TRANSPROTOCAL_RTPTCP;
            stPreviewInfo.dwStreamType = Helper.m_dwStreamType;
            stPreviewInfo.hPlayWnd = curRealPanel.Handle;
            IntPtr Handle = NETDEVSDK.NETDEV_RealPlay(lpUserID, ref stPreviewInfo, IntPtr.Zero, IntPtr.Zero);
            if (Handle == IntPtr.Zero)
            {
                return;
            }
            curRealPanel.m_playStatus = true;
            curRealPanel.m_playhandle = Handle;

            NETDEVSDK.NETDEV_SetIVAEnable(Handle, 1);
            NETDEVSDK.NETDEV_SetIVAShowParam(7);
        }

        private void faceRecogRealPlayStartBtn_Click(object sender, EventArgs e)
        {
            if (DeviceTree.SelectedNode == null
                || DeviceTree.SelectedNode.ImageIndex != NetDevSdk.NETDEV_TREEVIEW_IMAGE_CHL_DEVICE_ON)
            {
                return;
            }
            if (m_curFaceRecognitionRealPlayPanel.m_playStatus == false)
            {
                startRealPlay(m_curFaceRecognitionRealPlayPanel);
            }
            else
            {
                stopRealPlay(m_curFaceRecognitionRealPlayPanel, false);
                startRealPlay(m_curFaceRecognitionRealPlayPanel);
            }
        }

        private void faceRecogRealPlayStopBtn_Click(object sender, EventArgs e)
        {
            if (false == stopRealPlay(m_curFaceRecognitionRealPlayPanel, false))
            {
                return;
            }

            m_curFaceRecognitionRealPlayPanel.initPlayPanel();
        }

        private void faceRecogSubBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            Int32 bRet = NetDevSdk.TRUE;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            bRet = NETDEVSDK.NETDEV_SetPersonAlarmCallBack(lpUserID, personAlarmCB, lpUserID);
            if (NetDevSdk.FALSE == bRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_SetPersonAlarmCallBack failed", NETDEVSDK.NETDEV_GetLastError());
                return;
            }

            if (-1 == m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_dwSubFaceRecogAlarmID)
            {
                NETDEV_LAPI_SUB_INFO_S stSubInfo = new NETDEV_LAPI_SUB_INFO_S();
                stSubInfo.udwType = 16;
                stSubInfo.udwLibIDNum = 0xffff;
                stSubInfo.audwLibIDList = new UInt32[NetDevSdk.NETDEV_LEN_32];

                NETDEV_SUBSCRIBE_SUCC_INFO_S stSubSuccInfo = new NETDEV_SUBSCRIBE_SUCC_INFO_S();
                bRet = NETDEVSDK.NETDEV_SubscibeLapiAlarm(lpUserID, ref stSubInfo, ref stSubSuccInfo);
                if (NetDevSdk.FALSE == bRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_SubscibeLapiAlarm failed", NETDEVSDK.NETDEV_GetLastError());
                    return;
                }
                else
                {
                    m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_dwSubFaceRecogAlarmID = (Int32)stSubSuccInfo.udwID;
                    showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_SubscibeLapiAlarm success");
                }
            }
            else
            {
                MessageBox.Show("already subscribed to this alarm");
                return;
            }
        }

        private void faceRecogUnSubBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            Int32 bRet = NetDevSdk.TRUE;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            NETDEVSDK.NETDEV_SetPersonAlarmCallBack(lpUserID, null, lpUserID);

            if (-1 != m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_dwSubFaceRecogAlarmID)
            {
                bRet = NETDEVSDK.NETDEV_UnSubLapiAlarm(lpUserID, (uint)m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_dwSubFaceRecogAlarmID);
                if (NetDevSdk.FALSE == bRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_UnSubLapiAlarm failed", NETDEVSDK.NETDEV_GetLastError());
                }
                else
                {
                    showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_UnSubLapiAlarm success");
                }

                m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_dwSubFaceRecogAlarmID = -1;
            }
        }

        private void faceSnapshotSubBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            Int32 bRet = NetDevSdk.TRUE;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            NETDEVSDK.NETDEV_SetStructAlarmCallBack(lpUserID, structAlarmCB, lpUserID);
            if (NetDevSdk.FALSE == bRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_SetStructAlarmCallBack failed", NETDEVSDK.NETDEV_GetLastError());
                return;
            }

            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_IPC_OR_NVR == m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_eDeviceType)
            {
                if (-1 == m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_dwSubFaceStructAlarmID)
                {
                    NETDEV_LAPI_SUB_INFO_S stSubInfo = new NETDEV_LAPI_SUB_INFO_S();
                    stSubInfo.udwType = 32;
                    stSubInfo.udwLibIDNum = 0xffff;
                    stSubInfo.audwLibIDList = new UInt32[NetDevSdk.NETDEV_LEN_32];

                    NETDEV_SUBSCRIBE_SUCC_INFO_S stSubSuccInfo = new NETDEV_SUBSCRIBE_SUCC_INFO_S();
                    bRet = NETDEVSDK.NETDEV_SubscibeLapiAlarm(lpUserID, ref stSubInfo, ref stSubSuccInfo);
                    if (NetDevSdk.FALSE == bRet)
                    {
                        showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_SubscibeLapiAlarm failed", NETDEVSDK.NETDEV_GetLastError());
                        return;
                    }
                    else
                    {
                        m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_dwSubFaceStructAlarmID = (Int32)stSubSuccInfo.udwID;
                        showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_SubscibeLapiAlarm success");
                    }
                }
                else
                {
                    MessageBox.Show("already subscribed to this alarm");
                    return;
                }
            }
            else
            {
                if (getChannelID() < 0)
                {
                    MessageBox.Show("Please select a channel");
                    return;
                }

                int dwChannelIndex = getChannelIndex();
                int dwSubDeviceIndex = getSubDeviceIndex();
                int dwOrgIndex = getOrgIndex();

                if (dwChannelIndex == -1)
                {
                    return;
                }

                if (-1 != m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].stVmsDevInfo.stOrgInfoList[dwOrgIndex].stVmsDevBasicInfoList[dwSubDeviceIndex].stChnInfoList[dwChannelIndex].m_dwSubFaceStructAlarmID)
                {
                    MessageBox.Show("already subscribed to this alarm");
                    return;
                }

                NETDEV_SUBSCRIBE_SMART_INFO_S stSubscribeInfo = new NETDEV_SUBSCRIBE_SMART_INFO_S();
                stSubscribeInfo.udwNum = 1;

                uint[] iTmp = new uint[stSubscribeInfo.udwNum];
                iTmp[0] = (UInt32)NETDEV_SMART_ALARM_TYPE_E.NETDEV_SMART_ALARM_TYPE_FACE_SNAP;
                stSubscribeInfo.pudwSmartType = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(uint)) * (int)stSubscribeInfo.udwNum);
                for (int i = 0; i < stSubscribeInfo.udwNum; ++i)
                {
                    IntPtr pudwSmartTypeTemp = new IntPtr(stSubscribeInfo.pudwSmartType.ToInt32() + Marshal.SizeOf(typeof(uint)) * i);
                    Marshal.StructureToPtr(iTmp[i], pudwSmartTypeTemp, true);
                }

                NETDEV_SMART_INFO_S stSmartInfo = new NETDEV_SMART_INFO_S();
                stSmartInfo.dwChannelID = getChannelID();

                bRet = NETDEVSDK.NETDEV_SubscribeSmart(lpUserID, ref stSubscribeInfo, ref stSmartInfo);
                if (NetDevSdk.FALSE == bRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_SubscribeSmart failed", NETDEVSDK.NETDEV_GetLastError());
                }
                else
                {
                    m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].stVmsDevInfo.stOrgInfoList[dwOrgIndex].stVmsDevBasicInfoList[dwSubDeviceIndex].stChnInfoList[dwChannelIndex].m_dwSubFaceStructAlarmID = (Int32)stSmartInfo.udwSubscribeID;
                    showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_SubscribeSmart success");
                }

                Marshal.FreeHGlobal(stSubscribeInfo.pudwSmartType);
            }
        }

        private void faceSnapshotUnSubBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            Int32 bRet = NetDevSdk.TRUE;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_IPC_OR_NVR == m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_eDeviceType)
            {
                if (-1 != m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_dwSubFaceStructAlarmID)
                {
                    bRet = NETDEVSDK.NETDEV_UnSubLapiAlarm(lpUserID, (uint)m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_dwSubFaceStructAlarmID);
                    if (NetDevSdk.FALSE == bRet)
                    {
                        showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_UnSubLapiAlarm failed", NETDEVSDK.NETDEV_GetLastError());
                    }
                    else
                    {
                        showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_UnSubLapiAlarm success");
                    }

                    m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_dwSubFaceStructAlarmID = -1;
                }
            }
            else
            {
                if (getChannelID() < 0)
                {
                    MessageBox.Show("Please select a channel");
                    return;
                }

                int dwChannelIndex = getChannelIndex();
                int dwSubDeviceIndex = getSubDeviceIndex();
                int dwOrgIndex = getOrgIndex();

                if (dwChannelIndex == -1)
                {
                    return;
                }

                if (-1 != m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].stVmsDevInfo.stOrgInfoList[dwOrgIndex].stVmsDevBasicInfoList[dwSubDeviceIndex].stChnInfoList[dwChannelIndex].m_dwSubFaceStructAlarmID)
                {
                    NETDEV_SMART_INFO_S stSmartInfo = new NETDEV_SMART_INFO_S();
                    stSmartInfo.dwChannelID = getChannelID();
                    stSmartInfo.udwSubscribeID = (UInt32)m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].stVmsDevInfo.stOrgInfoList[dwOrgIndex].stVmsDevBasicInfoList[dwSubDeviceIndex].stChnInfoList[dwChannelIndex].m_dwSubFaceStructAlarmID;
                    bRet = NETDEVSDK.NETDEV_UnsubscribeSmart(lpUserID, ref stSmartInfo);
                    if (NetDevSdk.FALSE == bRet)
                    {
                        showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_UnsubscribeSmart failed", NETDEVSDK.NETDEV_GetLastError());
                    }
                    else
                    {
                        showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_UnsubscribeSmart success");
                    }

                    m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].stVmsDevInfo.stOrgInfoList[dwOrgIndex].stVmsDevBasicInfoList[dwSubDeviceIndex].stChnInfoList[dwChannelIndex].m_dwSubFaceStructAlarmID = -1;
                }
            }
        }

        private void findVehicleLibInfo()
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            vehicleLibCmb.Items.Clear();
            vehicleMonitorObjectCmbBox.Items.Clear();
            m_vehicleLibInfoList.Clear();
            vehicleLibNameText.Text = "";

            Int32 bRet = 0;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;
            IntPtr pVehicleLibHandle = NETDEVSDK.NETDEV_FindVehicleLibList(lpUserID);
            if (IntPtr.Zero == pVehicleLibHandle)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_FindVehicleLibList failed", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            else
            {
                while (true)
                {
                    NETDEV_LIB_INFO_S stVehicleLibInfo = new NETDEV_LIB_INFO_S();
                    bRet = NETDEVSDK.NETDEV_FindNextVehicleLibInfo(pVehicleLibHandle, ref stVehicleLibInfo);
                    if (NetDevSdk.FALSE == bRet)
                    {
                        break;
                    }
                    m_vehicleLibInfoList.Add(stVehicleLibInfo.udwID, stVehicleLibInfo);
                    vehicleLibCmb.Items.Add(Convert.ToString(stVehicleLibInfo.udwID));
                    vehicleMonitorObjectCmbBox.Items.Add(Convert.ToString(stVehicleLibInfo.udwID));

                    vehicleLibCmb.SelectedIndex = 0;
                    vehicleMonitorObjectCmbBox.SelectedIndex = 0;
                }
                bRet = NETDEVSDK.NETDEV_FindCloseVehicleLibList(pVehicleLibHandle);
                if (NetDevSdk.FALSE == bRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_FindCloseVehicleLibList failed", NETDEVSDK.NETDEV_GetLastError());
                    return;
                }
                else
                {
                    showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_FindVehicleLibList success");
                    return;
                }
            }
        }

        private void FindVehicleLibBtn_Click(object sender, EventArgs e)
        {
            findVehicleLibInfo();
        }

        private void addVehicleLibBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            Int32 bRet = 0;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            NETDEV_LIB_INFO_S stVehicleLibInfo = new NETDEV_LIB_INFO_S();
            GetUTF8Buffer(vehicleLibNameText.Text, NetDevSdk.NETDEV_LEN_260, out stVehicleLibInfo.szName);
            bRet = NETDEVSDK.NETDEV_AddVehicleLibInfo(lpUserID, ref stVehicleLibInfo);
            if (NetDevSdk.FALSE == bRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_AddVehicleLibInfo failed", NETDEVSDK.NETDEV_GetLastError());
                return;
            }

            showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_AddVehicleLibInfo success");

            findVehicleLibInfo();
        }

        private void modifyVehicleLibBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            Int32 bRet = 0;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            NETDEV_PERSON_LIB_LIST_S stVehicleLibList = new NETDEV_PERSON_LIB_LIST_S();
            stVehicleLibList.udwNum = 1;
            stVehicleLibList.pstLibInfo = IntPtr.Zero;

            NETDEV_LIB_INFO_S[] stVehicleLibInfoList = new NETDEV_LIB_INFO_S[stVehicleLibList.udwNum];
            UInt32 udwVehicleLibID = Convert.ToUInt32(this.vehicleLibCmb.SelectedItem);
            if (m_vehicleLibInfoList.ContainsKey(udwVehicleLibID))
            {
                stVehicleLibInfoList[0] = m_vehicleLibInfoList[udwVehicleLibID];
                GetUTF8Buffer(vehicleLibNameText.Text, NetDevSdk.NETDEV_LEN_260, out stVehicleLibInfoList[0].szName);
            }
            else
            {
                return;
            }

            try
            {
                stVehicleLibList.pstLibInfo = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETDEV_LIB_INFO_S)) * (int)stVehicleLibList.udwNum);
                for (int i = 0; i < stVehicleLibList.udwNum; i++)
                {
                    IntPtr pstLibInfoListTemp = new IntPtr(stVehicleLibList.pstLibInfo.ToInt32() + Marshal.SizeOf(typeof(NETDEV_LIB_INFO_S)) * i);
                    Marshal.StructureToPtr(stVehicleLibInfoList[i], pstLibInfoListTemp, true);
                }

                bRet = NETDEVSDK.NETDEV_ModifyVehicleLibInfo(lpUserID, ref stVehicleLibList);
                if (NetDevSdk.FALSE == bRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_ModifyVehicleLibInfo failed", NETDEVSDK.NETDEV_GetLastError());
                }
                else
                {
                    showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_ModifyVehicleLibInfo success");
                    findVehicleLibInfo();
                }
            }
            finally
            {
                Marshal.FreeHGlobal(stVehicleLibList.pstLibInfo);
            }
        }

        private void delVehicleLibBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            Int32 bRet = 0;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            UInt32 udwVehicleLibID = Convert.ToUInt32(this.vehicleLibCmb.SelectedItem);
            if (m_vehicleLibInfoList.ContainsKey(udwVehicleLibID))
            {
                NETDEV_DELETE_DB_FLAG_INFO_S stFlagInfo = new NETDEV_DELETE_DB_FLAG_INFO_S();
                stFlagInfo.bIsDeleteMember = NetDevSdk.TRUE;
                bRet = NETDEVSDK.NETDEV_DeleteVehicleLibInfo(lpUserID, m_vehicleLibInfoList[udwVehicleLibID].udwID, ref stFlagInfo);
                if (NetDevSdk.FALSE == bRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_DeleteVehicleLibInfo failed", NETDEVSDK.NETDEV_GetLastError());
                    return;
                }

                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_DeleteVehicleLibInfo success");
                findVehicleLibInfo();
            }
            else
            {
                return;
            }
        }

        private void vehicleLibCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UInt32 udwVehicleLibID = Convert.ToUInt32(this.vehicleLibCmb.SelectedItem);
            if (m_vehicleLibInfoList.ContainsKey(udwVehicleLibID))
            {
                vehicleLibNameText.Text = GetDefaultString(m_vehicleLibInfoList[udwVehicleLibID].szName);
            }
        }

        private void vehicleMonitorObjectCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UInt32 udwVehicleLibID = Convert.ToUInt32(this.vehicleMonitorObjectCmbBox.SelectedItem);
            if (m_vehicleLibInfoList.ContainsKey(udwVehicleLibID))
            {
                vehicleMonitorTaskLibNameText.Text = GetDefaultString(m_vehicleLibInfoList[udwVehicleLibID].szName);
            }
        }

        private void clearVehicleInfoTabWgt()
        {
            this.vehicleInfoListView.Items.Clear();
            foreach (KeyValuePair<uint, NETDEV_VEHICLE_DETAIL_INFO_S> kvp in m_vehicleLibMemberInfoList)
            {
                NETDEV_VEHICLE_DETAIL_INFO_S stVehicleInfo = kvp.Value;
                Marshal.FreeHGlobal(stVehicleInfo.stVehicleAttr.stVehicleImage.pcData);
            }

            m_vehicleLibMemberInfoList.Clear();
        }

        private void findVehicleInfo(UInt32 udwVehicleLibID, uint dwOffset)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            clearVehicleInfoTabWgt();

            Int32 bRet = NetDevSdk.TRUE;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            NETDEV_PERSON_QUERY_INFO_S stQueryInfo = new NETDEV_PERSON_QUERY_INFO_S();
            stQueryInfo.udwNum = 0;
            stQueryInfo.udwLimit = NetDevSdk.NETDEMO_FIND_VEHICLE_LIB_MEM_COUNT;
            stQueryInfo.udwOffset = dwOffset;
            NETDEV_BATCH_OPERATE_BASIC_S stQueryResultInfo = new NETDEV_BATCH_OPERATE_BASIC_S();

            IntPtr lpFindVehicleHandle = NETDEVSDK.NETDEV_FindVehicleMemberDetailList(lpUserID, udwVehicleLibID, ref stQueryInfo, ref stQueryResultInfo);
            if (IntPtr.Zero == lpFindVehicleHandle || stQueryResultInfo.udwNum <= 0)
            {
                return;
            }

            while (NetDevSdk.TRUE == bRet)
            {
                NETDEV_VEHICLE_DETAIL_INFO_S stVehicleInfo = new NETDEV_VEHICLE_DETAIL_INFO_S();

                stVehicleInfo.stVehicleAttr.stVehicleImage.pcData = Marshal.AllocHGlobal(NetDevSdk.NETDEMO_SMALL_IMAGE_SIZE);
                stVehicleInfo.stVehicleAttr.stVehicleImage.udwSize = NetDevSdk.NETDEMO_SMALL_IMAGE_SIZE;

                bRet = NETDEVSDK.NETDEV_FindNextVehicleMemberDetail(lpFindVehicleHandle, ref stVehicleInfo);
                if (NetDevSdk.FALSE == bRet)
                {
                    NETDEVSDK.NETDEV_FindCloseVehicleMemberDetail(lpFindVehicleHandle);
                    showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_FindVehicleMemberDetailList success");
                    Marshal.FreeHGlobal(stVehicleInfo.stVehicleAttr.stVehicleImage.pcData);
                    break;
                }
                else
                {
                    m_vehicleLibMemberInfoList.Add(stVehicleInfo.udwMemberID, stVehicleInfo);
                }
            }

            showVehicleInfo();
        }


        private void showVehicleInfo()
        {
            foreach (KeyValuePair<uint, NETDEV_VEHICLE_DETAIL_INFO_S> kvp in m_vehicleLibMemberInfoList)
            {
                NETDEV_VEHICLE_DETAIL_INFO_S stVehicleInfo = kvp.Value;

                string strPlateColor = "";
                for (int i = 0; i < NetDevSdk.gastNETDemoPlateColor.Length; i++)
                {
                    if (stVehicleInfo.stPlateAttr.udwColor == NetDevSdk.gastNETDemoPlateColor[i].dwPlateColor)
                    {
                        strPlateColor = NetDevSdk.gastNETDemoPlateColor[i].strPlateColor;
                        break;
                    }
                }

                string strPlateType = "";
                for (int i = 0; i < NetDevSdk.gastNETDemoPlateType.Length; i++)
                {
                    if (stVehicleInfo.stPlateAttr.udwType == NetDevSdk.gastNETDemoPlateType[i].dwPlateType)
                    {
                        strPlateType = NetDevSdk.gastNETDemoPlateType[i].strPlateType;
                        break;
                    }
                }
                string strVehicleColor = "";
                for (int i = 0; i < NetDevSdk.gastNETDemoPlateColor.Length; i++)
                {
                    if (stVehicleInfo.stVehicleAttr.udwColor == NetDevSdk.gastNETDemoPlateColor[i].dwPlateColor)
                    {
                        strVehicleColor = NetDevSdk.gastNETDemoPlateColor[i].strPlateColor;
                        break;
                    }
                }

                string strStatus = "";
                if (NetDevSdk.FALSE == stVehicleInfo.bIsMonitored)
                {
                    strStatus = "Not In Use";
                }
                else
                {
                    strStatus = "In Use";
                }

                ListViewItem item = new ListViewItem(Convert.ToString(stVehicleInfo.udwMemberID));
                item.SubItems.Add(GetDefaultString(stVehicleInfo.stPlateAttr.szPlateNo));
                item.SubItems.Add(strPlateColor);
                item.SubItems.Add(strPlateType);
                item.SubItems.Add(strVehicleColor);
                item.SubItems.Add(strStatus);

                this.vehicleInfoListView.Items.Add(item);
            }
        }

        private void FindVehicleInfoBtn_Click(object sender, EventArgs e)
        {
            UInt32 udwVehicleLibID = Convert.ToUInt32(this.vehicleLibCmb.SelectedItem);
            if (m_vehicleLibInfoList.ContainsKey(udwVehicleLibID))
            {
                m_dwFindVehicleLibMemberOffset = 0;
                findVehicleInfo(udwVehicleLibID, m_dwFindVehicleLibMemberOffset);
            }
            else
            {
                return;
            }
        }

        private void showVehicleMonitorTaskInfo()
        {
            vehicleMonitorInfoListView.Items.Clear();

            foreach (KeyValuePair<uint, NETDEV_MONITION_INFO_S> kvp in m_vehicleMonitorTaskList)
            {
                NETDEV_MONITION_INFO_S stVehicleMonitorTaskInfo = kvp.Value;

                string strStatus;
                if (NetDevSdk.FALSE == stVehicleMonitorTaskInfo.stMonitorRuleInfo.bEnabled)
                {
                    strStatus = "Not In Use";
                }
                else
                {
                    strStatus = "In Use";
                }

                string StrAlarmType = "";
                if (0 == stVehicleMonitorTaskInfo.stMonitorRuleInfo.udwMonitorType)
                {
                    StrAlarmType = "Match Alarm";
                }
                else
                {
                    StrAlarmType = "Not Match Alarm";
                }

                ListViewItem item = new ListViewItem(Convert.ToString(stVehicleMonitorTaskInfo.udwID));
                item.SubItems.Add(GetDefaultString(stVehicleMonitorTaskInfo.stMonitorRuleInfo.szName));
                item.SubItems.Add(GetDefaultString(stVehicleMonitorTaskInfo.stMonitorRuleInfo.szReason));
                item.SubItems.Add(StrAlarmType);
                item.SubItems.Add(strStatus);

                this.vehicleMonitorInfoListView.Items.Add(item);
            }
        }

        private void clearVehicleMonitorTaskInfo()
        {
            vehicleMonitorInfoListView.Items.Clear();
            foreach (KeyValuePair<uint, NETDEV_MONITION_INFO_S> kvp in m_vehicleMonitorTaskList)
            {
                NETDEV_MONITION_INFO_S stVehicleMonitorTaskInfo = kvp.Value;
                Marshal.FreeHGlobal(stVehicleMonitorTaskInfo.stMonitorRuleInfo.pudwMonitorChlIDList);
                Marshal.FreeHGlobal(stVehicleMonitorTaskInfo.pstLinkStrategyList);
            }

            m_vehicleMonitorTaskList.Clear();
        }

        private void findVehicleMonitorTaskInfo()
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            Int32 bRet = NetDevSdk.TRUE;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            clearVehicleMonitorTaskInfo();
            IntPtr lpVehicleMonitorHandle = NETDEVSDK.NETDEV_FindVehicleMonitorList(lpUserID);
            if (IntPtr.Zero == lpVehicleMonitorHandle)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_FindVehicleMonitorList failed", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            else
            {
                while (true)
                {
                    NETDEV_MONITION_INFO_S stMonitorInfo = new NETDEV_MONITION_INFO_S();

                    stMonitorInfo.stMonitorRuleInfo.udwChannelNum = 1;
                    uint[] iTmp = new uint[stMonitorInfo.stMonitorRuleInfo.udwChannelNum];
                    stMonitorInfo.stMonitorRuleInfo.pudwMonitorChlIDList = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(uint)) * (int)stMonitorInfo.stMonitorRuleInfo.udwChannelNum);
                    for (int i = 0; i < stMonitorInfo.stMonitorRuleInfo.udwChannelNum; ++i)
                    {
                        IntPtr pudwMonitorChlIDListTemp = new IntPtr(stMonitorInfo.stMonitorRuleInfo.pudwMonitorChlIDList.ToInt32() + Marshal.SizeOf(typeof(uint)) * i);
                        Marshal.StructureToPtr(iTmp[i], pudwMonitorChlIDListTemp, true);
                    }

                    stMonitorInfo.udwLinkStrategyNum = 10;
                    NETDEV_LINKAGE_STRATEGY_S[] stLinkStrategyListTmp = new NETDEV_LINKAGE_STRATEGY_S[stMonitorInfo.udwLinkStrategyNum];
                    stMonitorInfo.pstLinkStrategyList = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETDEV_LINKAGE_STRATEGY_S)) * (int)stMonitorInfo.udwLinkStrategyNum);
                    for (int i = 0; i < stMonitorInfo.udwLinkStrategyNum; ++i)
                    {
                        IntPtr pstLinkStrategyListTmp = new IntPtr(stMonitorInfo.pstLinkStrategyList.ToInt32() + Marshal.SizeOf(typeof(NETDEV_LINKAGE_STRATEGY_S)) * i);
                        Marshal.StructureToPtr(stLinkStrategyListTmp[i], pstLinkStrategyListTmp, true);
                    }

                    bRet = NETDEVSDK.NETDEV_FindNextVehicleMonitorInfo(lpVehicleMonitorHandle, ref stMonitorInfo);
                    if (NetDevSdk.FALSE == bRet)
                    {
                        Marshal.FreeHGlobal(stMonitorInfo.stMonitorRuleInfo.pudwMonitorChlIDList);
                        Marshal.FreeHGlobal(stMonitorInfo.pstLinkStrategyList);
                        break;
                    }
                    else
                    {
                        NETDEVSDK.NETDEV_GetVehicleMonitorInfo(lpUserID, stMonitorInfo.udwID, ref stMonitorInfo.stMonitorRuleInfo);
                        m_vehicleMonitorTaskList.Add(stMonitorInfo.udwID, stMonitorInfo);
                    }
                }

                NETDEVSDK.NETDEV_FindCloseVehicleMonitorList(lpVehicleMonitorHandle);
                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_FindVehicleMonitorList success");
                findVehicleLibInfo();
                showVehicleMonitorTaskInfo();
            }
        }

        private void FindVehicleMonitorBtn_Click(object sender, EventArgs e)
        {
            findVehicleMonitorTaskInfo();
        }

        private void vehicleInfoListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (vehicleInfoListView.SelectedItems.Count == 0)
            {
                return;
            }

            setListViewSelectedColor(((ListView)sender));

            plateAreaCmb.Text = vehicleInfoListView.SelectedItems[0].SubItems[1].Text.Substring(0, 1);
            plateNoText.Text = vehicleInfoListView.SelectedItems[0].SubItems[1].Text.Substring(1);//plate No.
            plateColorCmb.Text = vehicleInfoListView.SelectedItems[0].SubItems[2].Text;//plate Color
            PlateTypeCmb.Text = vehicleInfoListView.SelectedItems[0].SubItems[3].Text;//plate Type
            vehicleColorCmb.Text = vehicleInfoListView.SelectedItems[0].SubItems[4].Text;//vehicle Color
        }

        private void setListViewSelectedColor(ListView listView)
        {
            foreach (ListViewItem item in listView.Items)
            {
                item.BackColor = Color.White;
                item.ForeColor = Color.Black;
            }

            listView.SelectedItems[0].BackColor = Color.FromArgb(51, 153, 255);
            listView.SelectedItems[0].ForeColor = Color.White;
        }

        private void vehicleMonitorInfoListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (((ListView)sender).SelectedItems.Count == 0)
            {
                return;
            }

            setListViewSelectedColor(((ListView)sender));

            UInt32 udwMonitorTaskID = Convert.ToUInt32(vehicleMonitorInfoListView.SelectedItems[0].SubItems[0].Text);//ID
            if (m_vehicleMonitorTaskList.ContainsKey(udwMonitorTaskID))
            {
                NETDEV_MONITION_INFO_S stMonitorInfo = m_vehicleMonitorTaskList[udwMonitorTaskID];

                vehicleMonitorTaskNameText.Text = vehicleMonitorInfoListView.SelectedItems[0].SubItems[1].Text;//name
                vehicleMonitorRemarksText.Text = vehicleMonitorInfoListView.SelectedItems[0].SubItems[2].Text;//remarks
                vehicleMonitorTypeCmbBox.Text = vehicleMonitorInfoListView.SelectedItems[0].SubItems[3].Text;//Monitoring Type
                vehicleMonitorObjectCmbBox.Text = Convert.ToString(stMonitorInfo.stMonitorRuleInfo.audwLibList[0]);//monitoring object
                vehicleCauseCmbBox.SelectedIndex = (int)stMonitorInfo.stMonitorRuleInfo.udwMonitorReason;//Cause
            }
        }

        private void addVehicleMonitorBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            Int32 bRet = NetDevSdk.TRUE;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            NETDEV_MONITION_INFO_S stMonitorInfo = new NETDEV_MONITION_INFO_S();
            stMonitorInfo.stMonitorRuleInfo.bEnabled = 1;
            GetUTF8Buffer(vehicleMonitorTaskNameText.Text, NetDevSdk.NETDEV_FACE_MONITOR_RULE_NAME_LEN, out stMonitorInfo.stMonitorRuleInfo.szName);
            GetUTF8Buffer(vehicleMonitorRemarksText.Text, NetDevSdk.NETDEV_FACE_MONITOR_RULE_REASON_LEN, out stMonitorInfo.stMonitorRuleInfo.szReason);
            stMonitorInfo.stMonitorRuleInfo.udwMonitorType = (UInt32)vehicleMonitorTypeCmbBox.SelectedIndex;
            stMonitorInfo.stMonitorRuleInfo.udwMonitorReason = (UInt32)vehicleCauseCmbBox.SelectedIndex;

            stMonitorInfo.stMonitorRuleInfo.udwLibNum = 1;
            stMonitorInfo.stMonitorRuleInfo.audwLibList = new UInt32[NetDevSdk.NETDEV_LEN_32];
            stMonitorInfo.stMonitorRuleInfo.audwLibList[0] = Convert.ToUInt32(vehicleMonitorObjectCmbBox.Text);

            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_IPC_OR_NVR == m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_eDeviceType)
            {
                MessageBox.Show("Not Supported");
                return;
            }

            bRet = NETDEVSDK.NETDEV_AddVehicleMonitorInfo(lpUserID, ref stMonitorInfo);
            if (NetDevSdk.FALSE == bRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_AddVehicleMonitorInfo failed", NETDEVSDK.NETDEV_GetLastError());
            }
            else
            {
                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_AddVehicleMonitorInfo success");
            }

            findVehicleMonitorTaskInfo();
        }

        private void modifyVehicleMonitorBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            if (vehicleMonitorInfoListView.SelectedItems.Count == 0)
            {
                return;
            }

            Int32 bRet = NetDevSdk.TRUE;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            UInt32 udwMonitorTaskID = Convert.ToUInt32(vehicleMonitorInfoListView.SelectedItems[0].SubItems[0].Text);//ID

            NETDEV_MONITION_RULE_INFO_S stMonitorRuleInfo = new NETDEV_MONITION_RULE_INFO_S();

            stMonitorRuleInfo.udwChannelNum = 1;
            uint[] iTmp = new uint[stMonitorRuleInfo.udwChannelNum];
            stMonitorRuleInfo.pudwMonitorChlIDList = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(uint)) * (int)stMonitorRuleInfo.udwChannelNum);
            for (int i = 0; i < stMonitorRuleInfo.udwChannelNum; ++i)
            {
                IntPtr pudwMonitorChlIDListTemp = new IntPtr(stMonitorRuleInfo.pudwMonitorChlIDList.ToInt32() + Marshal.SizeOf(typeof(uint)) * i);
                Marshal.StructureToPtr(iTmp[i], pudwMonitorChlIDListTemp, true);
            }

            bRet = NETDEVSDK.NETDEV_GetVehicleMonitorInfo(lpUserID, udwMonitorTaskID, ref stMonitorRuleInfo);
            if (NetDevSdk.FALSE == bRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_GetVehicleMonitorInfo failed", NETDEVSDK.NETDEV_GetLastError());
                Marshal.FreeHGlobal(stMonitorRuleInfo.pudwMonitorChlIDList);
                return;
            }

            GetUTF8Buffer(vehicleMonitorTaskNameText.Text, NetDevSdk.NETDEV_FACE_MONITOR_RULE_NAME_LEN, out stMonitorRuleInfo.szName);
            GetUTF8Buffer(vehicleMonitorRemarksText.Text, NetDevSdk.NETDEV_FACE_MONITOR_RULE_REASON_LEN, out stMonitorRuleInfo.szReason);
            stMonitorRuleInfo.udwMonitorType = (UInt32)vehicleMonitorTypeCmbBox.SelectedIndex;
            stMonitorRuleInfo.udwMonitorReason = (UInt32)vehicleCauseCmbBox.SelectedIndex;
            stMonitorRuleInfo.audwLibList[0] = Convert.ToUInt32(vehicleMonitorObjectCmbBox.Text);

            bRet = NETDEVSDK.NETDEV_SetVehicleMonitorInfo(lpUserID, udwMonitorTaskID, ref stMonitorRuleInfo);
            if (NetDevSdk.FALSE == bRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_SetVehicleMonitorInfo failed", NETDEVSDK.NETDEV_GetLastError());
            }
            else
            {
                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_SetVehicleMonitorInfo success");
            }

            Marshal.FreeHGlobal(stMonitorRuleInfo.pudwMonitorChlIDList);
            findVehicleMonitorTaskInfo();
        }

        private void DelVehicleMonitorBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            if (vehicleMonitorInfoListView.SelectedItems.Count == 0)
            {
                return;
            }

            Int32 bRet = NetDevSdk.TRUE;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            UInt32 udwMonitorTaskID = Convert.ToUInt32(vehicleMonitorInfoListView.SelectedItems[0].SubItems[0].Text);//ID

            NETDEV_BATCH_OPERATOR_LIST_S stBatchList = new NETDEV_BATCH_OPERATOR_LIST_S();
            stBatchList.udwNum = 1;

            NETDEV_BATCH_OPERATOR_INFO_S[] stOperatorInfoArr = new NETDEV_BATCH_OPERATOR_INFO_S[stBatchList.udwNum];
            stOperatorInfoArr[0].udwID = udwMonitorTaskID;
            stBatchList.pstBatchList = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETDEV_BATCH_OPERATOR_INFO_S)) * (int)stBatchList.udwNum);
            for (int i = 0; i < stBatchList.udwNum; ++i)
            {
                IntPtr pstBatchListTemp = new IntPtr(stBatchList.pstBatchList.ToInt32() + Marshal.SizeOf(typeof(NETDEV_BATCH_OPERATOR_INFO_S)) * i);
                Marshal.StructureToPtr(stOperatorInfoArr[i], pstBatchListTemp, true);
            }

            bRet = NETDEVSDK.NETDEV_DeleteVehicleMonitorInfo(lpUserID, ref stBatchList);
            if (NetDevSdk.FALSE == bRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_DeleteVehicleMonitorInfo failed", NETDEVSDK.NETDEV_GetLastError());
            }
            else
            {
                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_DeleteVehicleMonitorInfo success");
            }

            Marshal.FreeHGlobal(stBatchList.pstBatchList);
            findVehicleMonitorTaskInfo();
        }

        private void enableVehicleMonitorBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            if (vehicleMonitorInfoListView.SelectedItems.Count == 0)
            {
                return;
            }

            Int32 bRet = NetDevSdk.TRUE;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            UInt32 udwMonitorTaskID = Convert.ToUInt32(vehicleMonitorInfoListView.SelectedItems[0].SubItems[0].Text);//ID

            NETDEV_MONITION_RULE_INFO_S stMonitorRuleInfo = new NETDEV_MONITION_RULE_INFO_S();

            stMonitorRuleInfo.udwChannelNum = 1;
            uint[] iTmp = new uint[stMonitorRuleInfo.udwChannelNum];
            stMonitorRuleInfo.pudwMonitorChlIDList = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(uint)) * (int)stMonitorRuleInfo.udwChannelNum);
            for (int i = 0; i < stMonitorRuleInfo.udwChannelNum; ++i)
            {
                IntPtr pudwMonitorChlIDListTemp = new IntPtr(stMonitorRuleInfo.pudwMonitorChlIDList.ToInt32() + Marshal.SizeOf(typeof(uint)) * i);
                Marshal.StructureToPtr(iTmp[i], pudwMonitorChlIDListTemp, true);
            }

            bRet = NETDEVSDK.NETDEV_GetVehicleMonitorInfo(lpUserID, udwMonitorTaskID, ref stMonitorRuleInfo);
            if (NetDevSdk.FALSE == bRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_GetVehicleMonitorInfo failed", NETDEVSDK.NETDEV_GetLastError());
                Marshal.FreeHGlobal(stMonitorRuleInfo.pudwMonitorChlIDList);
                return;
            }

            stMonitorRuleInfo.bEnabled = NetDevSdk.TRUE;

            bRet = NETDEVSDK.NETDEV_SetVehicleMonitorInfo(lpUserID, udwMonitorTaskID, ref stMonitorRuleInfo);
            if (NetDevSdk.FALSE == bRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_SetVehicleMonitorInfo failed", NETDEVSDK.NETDEV_GetLastError());
            }
            else
            {
                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_SetVehicleMonitorInfo success");
            }

            Marshal.FreeHGlobal(stMonitorRuleInfo.pudwMonitorChlIDList);
            findVehicleMonitorTaskInfo();
        }

        private void disableVehicleMonitorBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            if (vehicleMonitorInfoListView.SelectedItems.Count == 0)
            {
                return;
            }

            Int32 bRet = NetDevSdk.TRUE;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            UInt32 udwMonitorTaskID = Convert.ToUInt32(vehicleMonitorInfoListView.SelectedItems[0].SubItems[0].Text);//ID

            NETDEV_MONITION_RULE_INFO_S stMonitorRuleInfo = new NETDEV_MONITION_RULE_INFO_S();

            stMonitorRuleInfo.udwChannelNum = 1;
            uint[] iTmp = new uint[stMonitorRuleInfo.udwChannelNum];
            stMonitorRuleInfo.pudwMonitorChlIDList = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(uint)) * (int)stMonitorRuleInfo.udwChannelNum);
            for (int i = 0; i < stMonitorRuleInfo.udwChannelNum; ++i)
            {
                IntPtr pudwMonitorChlIDListTemp = new IntPtr(stMonitorRuleInfo.pudwMonitorChlIDList.ToInt32() + Marshal.SizeOf(typeof(uint)) * i);
                Marshal.StructureToPtr(iTmp[i], pudwMonitorChlIDListTemp, true);
            }

            bRet = NETDEVSDK.NETDEV_GetVehicleMonitorInfo(lpUserID, udwMonitorTaskID, ref stMonitorRuleInfo);
            if (NetDevSdk.FALSE == bRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_GetVehicleMonitorInfo failed", NETDEVSDK.NETDEV_GetLastError());
                Marshal.FreeHGlobal(stMonitorRuleInfo.pudwMonitorChlIDList);
                return;
            }

            stMonitorRuleInfo.bEnabled = NetDevSdk.FALSE;

            bRet = NETDEVSDK.NETDEV_SetVehicleMonitorInfo(lpUserID, udwMonitorTaskID, ref stMonitorRuleInfo);
            if (NetDevSdk.FALSE == bRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_SetVehicleMonitorInfo failed", NETDEVSDK.NETDEV_GetLastError());
            }
            else
            {
                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_SetVehicleMonitorInfo success");
            }

            Marshal.FreeHGlobal(stMonitorRuleInfo.pudwMonitorChlIDList);
            findVehicleMonitorTaskInfo();
        }

        private void addVehicleInfoBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            Int32 bRet = NetDevSdk.TRUE;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            UInt32 udwVehicleLibID = Convert.ToUInt32(this.vehicleLibCmb.SelectedItem);
            if (false == m_vehicleLibInfoList.ContainsKey(udwVehicleLibID))
            {
                return;
            }

            NETDEV_VEHICLE_INFO_LIST_S stVehicleMemberList = new NETDEV_VEHICLE_INFO_LIST_S();
            stVehicleMemberList.udwVehicleNum = 1;
            stVehicleMemberList.pstMemberInfoList = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETDEV_VEHICLE_DETAIL_INFO_S)) * (int)stVehicleMemberList.udwVehicleNum);

            NETDEV_VEHICLE_DETAIL_INFO_S[] stVehicleMemberListTemp = new NETDEV_VEHICLE_DETAIL_INFO_S[stVehicleMemberList.udwVehicleNum];
            for (int i = 0; i < stVehicleMemberList.udwVehicleNum; i++)
            {
                stVehicleMemberListTemp[i] = new NETDEV_VEHICLE_DETAIL_INFO_S();
            }

            GetUTF8Buffer(plateAreaCmb.Text + plateNoText.Text, NetDevSdk.NETDEV_LEN_16, out stVehicleMemberListTemp[0].stPlateAttr.szPlateNo);
            for (int i = 0; i < NetDevSdk.gastNETDemoPlateColor.Length; i++)
            {
                if (plateColorCmb.Text == NetDevSdk.gastNETDemoPlateColor[i].strPlateColor)
                {
                    stVehicleMemberListTemp[0].stPlateAttr.udwColor = (uint)NetDevSdk.gastNETDemoPlateColor[i].dwPlateColor;
                    break;
                }
            }

            for (int i = 0; i < NetDevSdk.gastNETDemoPlateType.Length; i++)
            {
                if (PlateTypeCmb.Text == NetDevSdk.gastNETDemoPlateType[i].strPlateType)
                {
                    stVehicleMemberListTemp[0].stPlateAttr.udwType = (uint)NetDevSdk.gastNETDemoPlateType[i].dwPlateType;
                    break;
                }
            }

            for (int i = 0; i < NetDevSdk.gastNETDemoPlateColor.Length; i++)
            {
                if (vehicleColorCmb.Text == NetDevSdk.gastNETDemoPlateColor[i].strPlateColor)
                {
                    stVehicleMemberListTemp[0].stVehicleAttr.udwColor = (uint)NetDevSdk.gastNETDemoPlateColor[i].dwPlateColor;
                    break;
                }
            }

            stVehicleMemberListTemp[0].stVehicleAttr.stVehicleImage.pcData = IntPtr.Zero;
            stVehicleMemberListTemp[0].stVehicleAttr.stVehicleImage.udwSize = 0;

            for (int i = 0; i < stVehicleMemberList.udwVehicleNum; i++)
            {
                IntPtr pstVehicleMemberListTemp = new IntPtr(stVehicleMemberList.pstMemberInfoList.ToInt32() + Marshal.SizeOf(typeof(NETDEV_VEHICLE_DETAIL_INFO_S)) * i);
                Marshal.StructureToPtr(stVehicleMemberListTemp[i], pstVehicleMemberListTemp, true);
            }

            NETDEV_BATCH_OPERATOR_LIST_S stResultList = new NETDEV_BATCH_OPERATOR_LIST_S();
            stResultList.udwNum = stVehicleMemberList.udwVehicleNum;
            stResultList.pstBatchList = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETDEV_BATCH_OPERATOR_INFO_S)) * (int)stResultList.udwNum);

            NETDEV_BATCH_OPERATOR_INFO_S[] stResultListTemp = new NETDEV_BATCH_OPERATOR_INFO_S[stResultList.udwNum];
            for (int i = 0; i < stResultList.udwNum; i++)
            {
                stResultListTemp[i] = new NETDEV_BATCH_OPERATOR_INFO_S();
            }

            for (int i = 0; i < stResultList.udwNum; i++)
            {
                IntPtr pstResultListTemp = new IntPtr(stResultList.pstBatchList.ToInt32() + Marshal.SizeOf(typeof(NETDEV_BATCH_OPERATOR_INFO_S)) * i);
                Marshal.StructureToPtr(stResultListTemp[i], pstResultListTemp, true);
            }

            bRet = NETDEVSDK.NETDEV_AddVehicleMemberList(lpUserID, udwVehicleLibID, ref stVehicleMemberList, ref stResultList);
            if (NetDevSdk.FALSE == bRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_AddVehicleMemberList failed", NETDEVSDK.NETDEV_GetLastError());
            }
            else
            {
                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_AddVehicleMemberList success");
            }

            Marshal.FreeHGlobal(stVehicleMemberList.pstMemberInfoList);
            Marshal.FreeHGlobal(stResultList.pstBatchList);

            m_dwFindVehicleLibMemberOffset = 0;
            findVehicleInfo(udwVehicleLibID, m_dwFindVehicleLibMemberOffset);
        }

        private void modifyVehicleInfoBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            if (vehicleInfoListView.SelectedItems.Count == 0)
            {
                return;
            }

            Int32 bRet = NetDevSdk.TRUE;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            UInt32 udwVehicleLibID = Convert.ToUInt32(this.vehicleLibCmb.SelectedItem);
            if (false == m_vehicleLibInfoList.ContainsKey(udwVehicleLibID))
            {
                return;
            }

            NETDEV_VEHICLE_INFO_LIST_S stVehicleMemberList = new NETDEV_VEHICLE_INFO_LIST_S();
            stVehicleMemberList.udwVehicleNum = 1;

            NETDEV_VEHICLE_DETAIL_INFO_S[] stVehicleMemberListTemp = new NETDEV_VEHICLE_DETAIL_INFO_S[stVehicleMemberList.udwVehicleNum];
            for (int i = 0; i < stVehicleMemberList.udwVehicleNum; i++)
            {
                stVehicleMemberListTemp[i] = new NETDEV_VEHICLE_DETAIL_INFO_S();
            }

            UInt32 udwVehicleID = Convert.ToUInt32(vehicleInfoListView.SelectedItems[0].SubItems[0].Text);//ID
            if (m_vehicleLibMemberInfoList.ContainsKey(udwVehicleID))
            {
                stVehicleMemberListTemp[0] = m_vehicleLibMemberInfoList[udwVehicleID];
            }
            else
            {
                return;
            }

            GetUTF8Buffer(plateAreaCmb.Text + plateNoText.Text, NetDevSdk.NETDEV_LEN_16, out stVehicleMemberListTemp[0].stPlateAttr.szPlateNo);
            for (int i = 0; i < NetDevSdk.gastNETDemoPlateColor.Length; i++)
            {
                if (plateColorCmb.Text == NetDevSdk.gastNETDemoPlateColor[i].strPlateColor)
                {
                    stVehicleMemberListTemp[0].stPlateAttr.udwColor = (uint)NetDevSdk.gastNETDemoPlateColor[i].dwPlateColor;
                    break;
                }
            }

            for (int i = 0; i < NetDevSdk.gastNETDemoPlateType.Length; i++)
            {
                if (PlateTypeCmb.Text == NetDevSdk.gastNETDemoPlateType[i].strPlateType)
                {
                    stVehicleMemberListTemp[0].stPlateAttr.udwType = (uint)NetDevSdk.gastNETDemoPlateType[i].dwPlateType;
                    break;
                }
            }

            for (int i = 0; i < NetDevSdk.gastNETDemoPlateColor.Length; i++)
            {
                if (vehicleColorCmb.Text == NetDevSdk.gastNETDemoPlateColor[i].strPlateColor)
                {
                    stVehicleMemberListTemp[0].stVehicleAttr.udwColor = (uint)NetDevSdk.gastNETDemoPlateColor[i].dwPlateColor;
                    break;
                }
            }

            stVehicleMemberList.pstMemberInfoList = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETDEV_VEHICLE_DETAIL_INFO_S)) * (int)stVehicleMemberList.udwVehicleNum);
            for (int i = 0; i < stVehicleMemberList.udwVehicleNum; i++)
            {
                IntPtr pstVehicleMemberListTemp = new IntPtr(stVehicleMemberList.pstMemberInfoList.ToInt32() + Marshal.SizeOf(typeof(NETDEV_VEHICLE_DETAIL_INFO_S)) * i);
                Marshal.StructureToPtr(stVehicleMemberListTemp[i], pstVehicleMemberListTemp, true);
            }

            NETDEV_BATCH_OPERATOR_LIST_S stResultList = new NETDEV_BATCH_OPERATOR_LIST_S();
            stResultList.udwNum = stVehicleMemberList.udwVehicleNum;
            stResultList.pstBatchList = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETDEV_BATCH_OPERATOR_INFO_S)) * (int)stResultList.udwNum);

            NETDEV_BATCH_OPERATOR_INFO_S[] stResultListTemp = new NETDEV_BATCH_OPERATOR_INFO_S[stResultList.udwNum];
            for (int i = 0; i < stResultList.udwNum; i++)
            {
                stResultListTemp[i] = new NETDEV_BATCH_OPERATOR_INFO_S();
            }

            for (int i = 0; i < stResultList.udwNum; i++)
            {
                IntPtr pstResultListTemp = new IntPtr(stResultList.pstBatchList.ToInt32() + Marshal.SizeOf(typeof(NETDEV_BATCH_OPERATOR_INFO_S)) * i);
                Marshal.StructureToPtr(stResultListTemp[i], pstResultListTemp, true);
            }

            bRet = NETDEVSDK.NETDEV_ModifyVehicleMemberInfo(lpUserID, udwVehicleLibID, ref stVehicleMemberList, ref stResultList);
            if (NetDevSdk.FALSE == bRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_ModifyVehicleMemberInfo failed", NETDEVSDK.NETDEV_GetLastError());
            }
            else
            {
                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_ModifyVehicleMemberInfo success");
            }

            Marshal.FreeHGlobal(stVehicleMemberList.pstMemberInfoList);
            Marshal.FreeHGlobal(stResultList.pstBatchList);

            m_dwFindVehicleLibMemberOffset = 0;
            findVehicleInfo(udwVehicleLibID, m_dwFindVehicleLibMemberOffset);
        }

        private void delVehicleInfoBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            if (vehicleInfoListView.SelectedItems.Count == 0)
            {
                return;
            }

            Int32 bRet = NetDevSdk.TRUE;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            UInt32 udwVehicleLibID = Convert.ToUInt32(this.vehicleLibCmb.SelectedItem);
            if (false == m_vehicleLibInfoList.ContainsKey(udwVehicleLibID))
            {
                return;
            }

            UInt32 udwVehicleID = Convert.ToUInt32(vehicleInfoListView.SelectedItems[0].SubItems[0].Text);//ID
            if (false == m_vehicleLibMemberInfoList.ContainsKey(udwVehicleID))
            {
                return;
            }

            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_IPC_OR_NVR == m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_eDeviceType)
            {
                MessageBox.Show("Not Supported");
                return;
            }
            else
            {
                NETDEV_VEHICLE_INFO_LIST_S stVehicleMemberList = new NETDEV_VEHICLE_INFO_LIST_S();
                stVehicleMemberList.udwVehicleNum = 1;
                stVehicleMemberList.pstMemberInfoList = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETDEV_VEHICLE_DETAIL_INFO_S)) * (int)stVehicleMemberList.udwVehicleNum);

                NETDEV_VEHICLE_DETAIL_INFO_S[] stVehicleMemberListTmp = new NETDEV_VEHICLE_DETAIL_INFO_S[stVehicleMemberList.udwVehicleNum];
                stVehicleMemberListTmp[0] = m_vehicleLibMemberInfoList[udwVehicleID];
                for (int i = 0; i < stVehicleMemberList.udwVehicleNum; i++)
                {
                    IntPtr pstVehicleMemberListTemp = new IntPtr(stVehicleMemberList.pstMemberInfoList.ToInt32() + Marshal.SizeOf(typeof(NETDEV_BATCH_OPERATOR_INFO_S)) * i);
                    Marshal.StructureToPtr(stVehicleMemberListTmp[i], pstVehicleMemberListTemp, true);
                }

                NETDEV_BATCH_OPERATOR_LIST_S stResutList = new NETDEV_BATCH_OPERATOR_LIST_S();
                stResutList.udwNum = 1;

                NETDEV_BATCH_OPERATOR_INFO_S[] stBatchOperInfoListTmp = new NETDEV_BATCH_OPERATOR_INFO_S[stResutList.udwNum];
                stResutList.pstBatchList = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETDEV_BATCH_OPERATOR_INFO_S)) * (int)stResutList.udwNum);
                for (int i = 0; i < stResutList.udwNum; ++i)
                {
                    IntPtr pstBatchListTemp = new IntPtr(stResutList.pstBatchList.ToInt32() + Marshal.SizeOf(typeof(NETDEV_BATCH_OPERATOR_INFO_S)) * i);
                    Marshal.StructureToPtr(stBatchOperInfoListTmp[i], pstBatchListTemp, true);
                }

                bRet = NETDEVSDK.NETDEV_DelVehicleMemberList(lpUserID, 0, ref stVehicleMemberList, ref stResutList);
                if (NetDevSdk.FALSE == bRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_DelVehicleMemberList failed", NETDEVSDK.NETDEV_GetLastError());
                }
                else
                {
                    showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_DelVehicleMemberList success");
                }

                Marshal.FreeHGlobal(stResutList.pstBatchList);
            }

            m_dwFindVehicleLibMemberOffset = 0;
            findVehicleInfo(udwVehicleLibID, m_dwFindVehicleLibMemberOffset);
        }

        private void LPRRealPlayStartBtn_Click(object sender, EventArgs e)
        {
            if (DeviceTree.SelectedNode == null
                || DeviceTree.SelectedNode.ImageIndex != NetDevSdk.NETDEV_TREEVIEW_IMAGE_CHL_DEVICE_ON)
            {
                return;
            }
            if (m_curLPRRealPlayPanel.m_playStatus == false)
            {
                startRealPlay(m_curLPRRealPlayPanel);
            }
            else
            {
                stopRealPlay(m_curLPRRealPlayPanel, false);
                startRealPlay(m_curLPRRealPlayPanel);
            }
        }

        private void LPRRealPlayStopBtn_Click(object sender, EventArgs e)
        {
            if (false == stopRealPlay(m_curLPRRealPlayPanel, false))
            {
                return;
            }

            m_curLPRRealPlayPanel.initPlayPanel();
        }

        private void LPRRecogSubBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            Int32 bRet = NetDevSdk.TRUE;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            bRet = NETDEVSDK.NETDEV_SetVehicleAlarmCallBack(lpUserID, vehicleAlarmCB, lpUserID);
            if (NetDevSdk.FALSE == bRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_SetVehicleAlarmCallBack failed", NETDEVSDK.NETDEV_GetLastError());
                return;
            }

            if (-1 == m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_dwSubVehicleRecogAlarmID)
            {
                NETDEV_LAPI_SUB_INFO_S stSubInfo = new NETDEV_LAPI_SUB_INFO_S();
                stSubInfo.udwType = 64;
                stSubInfo.udwLibIDNum = 0xffff;
                stSubInfo.audwLibIDList = new UInt32[NetDevSdk.NETDEV_LEN_32];

                NETDEV_SUBSCRIBE_SUCC_INFO_S stSubSuccInfo = new NETDEV_SUBSCRIBE_SUCC_INFO_S();
                bRet = NETDEVSDK.NETDEV_SubscibeLapiAlarm(lpUserID, ref stSubInfo, ref stSubSuccInfo);
                if (NetDevSdk.FALSE == bRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_SubscibeLapiAlarm failed", NETDEVSDK.NETDEV_GetLastError());
                    return;
                }
                else
                {
                    m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_dwSubVehicleRecogAlarmID = (Int32)stSubSuccInfo.udwID;
                    showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_SubscibeLapiAlarm Success");
                }
            }
            else
            {
                MessageBox.Show("already subscribed to this alarm");
                return;
            }
        }

        private void LPRRecogUnSubBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            Int32 bRet = NetDevSdk.TRUE;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            NETDEVSDK.NETDEV_SetVehicleAlarmCallBack(lpUserID, null, lpUserID);

            if (-1 != m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_dwSubVehicleRecogAlarmID)
            {
                bRet = NETDEVSDK.NETDEV_UnSubLapiAlarm(lpUserID, (uint)m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_dwSubVehicleRecogAlarmID);
                if (NetDevSdk.FALSE == bRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_UnSubLapiAlarm failed", NETDEVSDK.NETDEV_GetLastError());
                }
                else
                {
                    showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_UnSubLapiAlarm Success");
                }

                m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_dwSubVehicleRecogAlarmID = -1;
            }
        }

        private void LPRSnapshotSubBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            Int32 bRet = NetDevSdk.TRUE;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            NETDEVSDK.NETDEV_SetStructAlarmCallBack(lpUserID, structAlarmCB, lpUserID);
            if (NetDevSdk.FALSE == bRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_SetStructAlarmCallBack failed", NETDEVSDK.NETDEV_GetLastError());
                return;
            }

            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_IPC_OR_NVR == m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_eDeviceType)
            {
                if (-1 == m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_dwSubVehicleStructAlarmID)
                {
                    NETDEV_LAPI_SUB_INFO_S stSubInfo = new NETDEV_LAPI_SUB_INFO_S();
                    stSubInfo.udwType = 32;
                    stSubInfo.udwLibIDNum = 0xffff;
                    stSubInfo.audwLibIDList = new UInt32[NetDevSdk.NETDEV_LEN_32];

                    NETDEV_SUBSCRIBE_SUCC_INFO_S stSubSuccInfo = new NETDEV_SUBSCRIBE_SUCC_INFO_S();
                    bRet = NETDEVSDK.NETDEV_SubscibeLapiAlarm(lpUserID, ref stSubInfo, ref stSubSuccInfo);
                    if (NetDevSdk.FALSE == bRet)
                    {
                        showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_SubscibeLapiAlarm failed", NETDEVSDK.NETDEV_GetLastError());
                        return;
                    }
                    else
                    {
                        m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_dwSubVehicleStructAlarmID = (Int32)stSubSuccInfo.udwID;
                        showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_SubscibeLapiAlarm Success");
                    }
                }
                else
                {
                    MessageBox.Show("already subscribed to this alarm");
                    return;
                }
            }
            else
            {
                if (getChannelID() < 0)
                {
                    MessageBox.Show("Please select a channel");
                    return;
                }

                int dwChannelIndex = getChannelIndex();
                int dwSubDeviceIndex = getSubDeviceIndex();
                int dwOrgIndex = getOrgIndex();

                if (dwChannelIndex == -1)
                {
                    return;
                }

                if (-1 != m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].stVmsDevInfo.stOrgInfoList[dwOrgIndex].stVmsDevBasicInfoList[dwSubDeviceIndex].stChnInfoList[dwChannelIndex].m_dwSubVehicleStructAlarmID)
                {
                    MessageBox.Show("already subscribed to this alarm");
                    return;
                }

                NETDEV_SUBSCRIBE_SMART_INFO_S stSubscribeInfo = new NETDEV_SUBSCRIBE_SMART_INFO_S();
                stSubscribeInfo.udwNum = 1;

                uint[] iTmp = new uint[stSubscribeInfo.udwNum];
                iTmp[0] = (UInt32)NETDEV_SMART_ALARM_TYPE_E.NETDEV_SMART_ALARM_TYPE_VEHICLE_SNAP;
                stSubscribeInfo.pudwSmartType = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(uint)) * (int)stSubscribeInfo.udwNum);
                for (int i = 0; i < stSubscribeInfo.udwNum; ++i)
                {
                    IntPtr pudwSmartTypeTemp = new IntPtr(stSubscribeInfo.pudwSmartType.ToInt32() + Marshal.SizeOf(typeof(uint)) * i);
                    Marshal.StructureToPtr(iTmp[i], pudwSmartTypeTemp, true);
                }

                NETDEV_SMART_INFO_S stSmartInfo = new NETDEV_SMART_INFO_S();
                stSmartInfo.dwChannelID = getChannelID();

                bRet = NETDEVSDK.NETDEV_SubscribeSmart(lpUserID, ref stSubscribeInfo, ref stSmartInfo);
                if (NetDevSdk.FALSE == bRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_SubscribeSmart failed", NETDEVSDK.NETDEV_GetLastError());
                }
                else
                {
                    m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].stVmsDevInfo.stOrgInfoList[dwOrgIndex].stVmsDevBasicInfoList[dwSubDeviceIndex].stChnInfoList[dwChannelIndex].m_dwSubVehicleStructAlarmID = (Int32)stSmartInfo.udwSubscribeID;
                    showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_SubscribeSmart success");
                }

                Marshal.FreeHGlobal(stSubscribeInfo.pudwSmartType);
            }
        }

        private void LPRSnapshotUnSubBtn_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            Int32 bRet = NetDevSdk.TRUE;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_IPC_OR_NVR == m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_eDeviceType)
            {
                if (-1 != m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_dwSubVehicleStructAlarmID)
                {
                    bRet = NETDEVSDK.NETDEV_UnSubLapiAlarm(lpUserID, (uint)m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_dwSubVehicleStructAlarmID);
                    if (NetDevSdk.FALSE == bRet)
                    {
                        showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_UnSubLapiAlarm failed", NETDEVSDK.NETDEV_GetLastError());
                    }
                    else
                    {
                        showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_UnSubLapiAlarm success");
                    }

                    m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_dwSubVehicleStructAlarmID = -1;
                }
            }
            else
            {
                if (getChannelID() < 0)
                {
                    MessageBox.Show("Please select a channel");
                    return;
                }

                int dwChannelIndex = getChannelIndex();
                int dwSubDeviceIndex = getSubDeviceIndex();
                int dwOrgIndex = getOrgIndex();

                if (dwChannelIndex == -1)
                {
                    return;
                }

                if (-1 != m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].stVmsDevInfo.stOrgInfoList[dwOrgIndex].stVmsDevBasicInfoList[dwSubDeviceIndex].stChnInfoList[dwChannelIndex].m_dwSubVehicleStructAlarmID)
                {
                    NETDEV_SMART_INFO_S stSmartInfo = new NETDEV_SMART_INFO_S();
                    stSmartInfo.dwChannelID = getChannelID();
                    stSmartInfo.udwSubscribeID = (UInt32)m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].stVmsDevInfo.stOrgInfoList[dwOrgIndex].stVmsDevBasicInfoList[dwSubDeviceIndex].stChnInfoList[dwChannelIndex].m_dwSubVehicleStructAlarmID;
                    bRet = NETDEVSDK.NETDEV_UnsubscribeSmart(lpUserID, ref stSmartInfo);
                    if (NetDevSdk.FALSE == bRet)
                    {
                        showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_UnsubscribeSmart failed", NETDEVSDK.NETDEV_GetLastError());
                    }
                    else
                    {
                        showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_UnsubscribeSmart success");
                    }

                    m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].stVmsDevInfo.stOrgInfoList[dwOrgIndex].stVmsDevBasicInfoList[dwSubDeviceIndex].stChnInfoList[dwChannelIndex].m_dwSubVehicleStructAlarmID = -1;
                }
            }
        }

        private void showFaceAlarmRecordInfo(NETDEMO_FIND_FACE_ALARM_RECORD_TYPE_E eFindType, NETDEV_FACE_RECORD_SNAPSHOT_INFO_S stRecordInfo)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            byte[] szSnapshotSmallImageInfo = new byte[stRecordInfo.stCompareInfo.stSnapshotImage.stSmallImage.udwSize];
            Marshal.Copy(stRecordInfo.stCompareInfo.stSnapshotImage.stSmallImage.pcData, szSnapshotSmallImageInfo, 0, (int)stRecordInfo.stCompareInfo.stSnapshotImage.stSmallImage.udwSize);

            if (NETDEMO_FIND_FACE_ALARM_RECORD_TYPE_E.NETDEMO_FIND_FACE_ALARM_RECORD_MATCH == eFindType)
            {
                int index = this.faceAlarmRecordDataGridView.Rows.Add();

                using (MemoryStream stream = new MemoryStream(szSnapshotSmallImageInfo))
                {
                    try
                    {
                        this.faceAlarmRecordDataGridView.Rows[index].Cells[0].Value = Image.FromStream(stream);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }

                byte[] szMemberImageInfo = new byte[stRecordInfo.stCompareInfo.stMemberInfo.stMemberImageInfo.udwSize];
                Marshal.Copy(stRecordInfo.stCompareInfo.stMemberInfo.stMemberImageInfo.pcData, szMemberImageInfo, 0, (int)stRecordInfo.stCompareInfo.stMemberInfo.stMemberImageInfo.udwSize);

                using (MemoryStream stream = new MemoryStream(szMemberImageInfo))
                {
                    try
                    {
                        this.faceAlarmRecordDataGridView.Rows[index].Cells[1].Value = Image.FromStream(stream);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }

                this.faceAlarmRecordDataGridView.Rows[index].Cells[2].Value = getStrTime(stRecordInfo.udwPassTime);
                this.faceAlarmRecordDataGridView.Rows[index].Cells[3].Value = GetDefaultString(stRecordInfo.szChannelName);
                this.faceAlarmRecordDataGridView.Rows[index].Cells[4].Value = GetDefaultString(stRecordInfo.stCompareInfo.stMemberInfo.szMemberName);
                this.faceAlarmRecordDataGridView.Rows[index].Cells[5].Value = stRecordInfo.stCompareInfo.stMemberInfo.stMemberIDInfo.szNumber;
                this.faceAlarmRecordDataGridView.Rows[index].Cells[6].Value = Convert.ToString(stRecordInfo.stCompareInfo.udwSimilarity) + "%";
            }
            else
            {
                int index = this.facePassThruRecordDataGridView.Rows.Add();

                using (MemoryStream stream = new MemoryStream(szSnapshotSmallImageInfo))
                {
                    try
                    {
                        this.facePassThruRecordDataGridView.Rows[index].Cells[1].Value = Image.FromStream(stream);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }

                Int32 bRet = NETDEVSDK.NETDEV_GetFaceRecordImageInfo(lpUserID, stRecordInfo.udwRecordID, 0, ref stRecordInfo.stCompareInfo.stSnapshotImage.stBigImage);
                if (NetDevSdk.TRUE == bRet)
                {
                    byte[] szSnapshotBigImageInfo = new byte[stRecordInfo.stCompareInfo.stSnapshotImage.stBigImage.udwSize];
                    Marshal.Copy(stRecordInfo.stCompareInfo.stSnapshotImage.stBigImage.pcData, szSnapshotBigImageInfo, 0, (int)stRecordInfo.stCompareInfo.stSnapshotImage.stBigImage.udwSize);
                    using (MemoryStream stream = new MemoryStream(szSnapshotBigImageInfo))
                    {
                        try
                        {
                            this.facePassThruRecordDataGridView.Rows[index].Cells[0].Value = Image.FromStream(stream);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }

                    this.facePassThruRecordDataGridView.Rows[index].Cells[2].Value = getStrTime(stRecordInfo.udwPassTime);
                    this.facePassThruRecordDataGridView.Rows[index].Cells[3].Value = GetDefaultString(stRecordInfo.szChannelName);
                }
            }
        }

        private void findFaceAlarmRecordInfo(NETDEMO_FIND_FACE_ALARM_RECORD_TYPE_E eFindType, uint udwOffset)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            Int32 bRet = NetDevSdk.TRUE;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            NETDEV_ALARM_LOG_COND_LIST_S stFindCond = new NETDEV_ALARM_LOG_COND_LIST_S();
            stFindCond.dwPageRow = NetDevSdk.NETDEMO_FIND_SMART_ALARM_RECORD_COUNT;
            stFindCond.dwFirstRow = (int)udwOffset;
            stFindCond.dwCondSize = 3;
            stFindCond.astCondition = new NETDEV_QUERY_INFO_S[NetDevSdk.NETDEV_LOG_QUERY_COND_NUM];

            stFindCond.astCondition[0].dwQueryType = (int)NETDEV_QUERYCOND_TYPE_E.NETDEV_QUERYCOND_TIME;
            stFindCond.astCondition[0].dwLogicFlag = (int)NETDEV_QUERYCOND_LOGICTYPE_E.NETDEV_QUERYCOND_LOGIC_NO_LESS;

            stFindCond.astCondition[1].dwQueryType = (int)NETDEV_QUERYCOND_TYPE_E.NETDEV_QUERYCOND_TIME;
            stFindCond.astCondition[1].dwLogicFlag = (int)NETDEV_QUERYCOND_LOGICTYPE_E.NETDEV_QUERYCOND_LOGIC_NO_GREATER;

            stFindCond.astCondition[2].dwQueryType = (int)NETDEV_QUERYCOND_TYPE_E.NETDEV_QUERYCOND_TIME;
            stFindCond.astCondition[2].dwLogicFlag = (int)NETDEV_QUERYCOND_LOGICTYPE_E.NETDEV_QUERYCOND_LOGIC_DESC_ORDER;
            GetUTF8Buffer("", NetDevSdk.NETDEV_CODE_STR_MAX_LEN, out stFindCond.astCondition[2].szConditionData);

            if (NETDEMO_FIND_FACE_ALARM_RECORD_TYPE_E.NETDEMO_FIND_FACE_ALARM_RECORD_MATCH == eFindType)
            {
                faceAlarmRecordDataGridView.Rows.Clear();

                GetUTF8Buffer(Convert.ToString(getLongTime(faceAlarmRecordBeginTimeDT.Value.ToString())), NetDevSdk.NETDEV_CODE_STR_MAX_LEN, out stFindCond.astCondition[0].szConditionData);
                GetUTF8Buffer(Convert.ToString(getLongTime(faceAlarmRecordEndTimeDT.Value.ToString())), NetDevSdk.NETDEV_CODE_STR_MAX_LEN, out stFindCond.astCondition[1].szConditionData);

                stFindCond.astCondition[stFindCond.dwCondSize].dwQueryType = (int)NETDEV_QUERYCOND_TYPE_E.NETDEV_QUERYCOND_ALARMTYPE;
                stFindCond.astCondition[stFindCond.dwCondSize].dwLogicFlag = (int)NETDEV_QUERYCOND_LOGICTYPE_E.NETDEV_QUERYCOND_LOGIC_EQUAL;
                if (0 == faceAlarmRecordMonitorTypeCmbBox.SelectedIndex)
                {
                    GetUTF8Buffer(Convert.ToString((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_FACE_MATCH_LIST), NetDevSdk.NETDEV_CODE_STR_MAX_LEN, out stFindCond.astCondition[stFindCond.dwCondSize].szConditionData);
                }
                else
                {
                    GetUTF8Buffer(Convert.ToString((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_FACE_MISMATCH_LIST), NetDevSdk.NETDEV_CODE_STR_MAX_LEN, out stFindCond.astCondition[stFindCond.dwCondSize].szConditionData);
                }
                stFindCond.dwCondSize += 1;
            }
            else
            {
                facePassThruRecordDataGridView.Rows.Clear();

                GetUTF8Buffer(Convert.ToString(getLongTime(facePassThruRecordBeginTimeDT.Value.ToString())), NetDevSdk.NETDEV_CODE_STR_MAX_LEN, out stFindCond.astCondition[0].szConditionData);
                GetUTF8Buffer(Convert.ToString(getLongTime(facePassThruRecordEndTimeDT.Value.ToString())), NetDevSdk.NETDEV_CODE_STR_MAX_LEN, out stFindCond.astCondition[1].szConditionData);

                if ("" != facePassThruRecordAlarmSourceText.Text)
                {
                    stFindCond.astCondition[stFindCond.dwCondSize].dwQueryType = (int)NETDEV_QUERYCOND_TYPE_E.NETDEV_QUERYCOND_ALARMSRCNAME;
                    stFindCond.astCondition[stFindCond.dwCondSize].dwLogicFlag = (int)NETDEV_QUERYCOND_LOGICTYPE_E.NETDEV_QUERYCOND_LOGIC_DIM_QUERY;
                    GetUTF8Buffer(facePassThruRecordAlarmSourceText.Text, NetDevSdk.NETDEV_CODE_STR_MAX_LEN, out stFindCond.astCondition[stFindCond.dwCondSize].szConditionData);
                    stFindCond.dwCondSize += 1;
                }
            }

            NETDEV_SMART_ALARM_LOG_RESULT_INFO_S stResultInfo = new NETDEV_SMART_ALARM_LOG_RESULT_INFO_S();
            IntPtr lpFindHandle = NETDEVSDK.NETDEV_FindFaceRecordDetailList(lpUserID, ref stFindCond, ref stResultInfo);
            if (IntPtr.Zero != lpFindHandle)
            {
                while (true)
                {
                    NETDEV_FACE_RECORD_SNAPSHOT_INFO_S stRecordInfo = new NETDEV_FACE_RECORD_SNAPSHOT_INFO_S();
                    stRecordInfo.stCompareInfo.stMemberInfo.stMemberSemiInfo.pcData = Marshal.AllocHGlobal(NetDevSdk.NETDEMO_SMALL_IMAGE_SIZE);
                    stRecordInfo.stCompareInfo.stMemberInfo.stMemberSemiInfo.udwSize = NetDevSdk.NETDEMO_SMALL_IMAGE_SIZE;
                    stRecordInfo.stCompareInfo.stMemberInfo.stMemberImageInfo.pcData = Marshal.AllocHGlobal(NetDevSdk.NETDEMO_SMALL_IMAGE_SIZE);
                    stRecordInfo.stCompareInfo.stMemberInfo.stMemberImageInfo.udwSize = NetDevSdk.NETDEMO_SMALL_IMAGE_SIZE;
                    stRecordInfo.stCompareInfo.stSnapshotImage.stBigImage.pcData = Marshal.AllocHGlobal(NetDevSdk.NETDEMO_SMALL_IMAGE_SIZE);
                    stRecordInfo.stCompareInfo.stSnapshotImage.stBigImage.udwSize = NetDevSdk.NETDEMO_SMALL_IMAGE_SIZE;
                    stRecordInfo.stCompareInfo.stSnapshotImage.stSmallImage.pcData = Marshal.AllocHGlobal(NetDevSdk.NETDEMO_SMALL_IMAGE_SIZE);
                    stRecordInfo.stCompareInfo.stSnapshotImage.stSmallImage.udwSize = NetDevSdk.NETDEMO_SMALL_IMAGE_SIZE;
                    bRet = NETDEVSDK.NETDEV_FindNextFaceRecordDetail(lpFindHandle, ref stRecordInfo);
                    if (NetDevSdk.FALSE == bRet)
                    {
                        Marshal.FreeHGlobal(stRecordInfo.stCompareInfo.stMemberInfo.stMemberSemiInfo.pcData);
                        Marshal.FreeHGlobal(stRecordInfo.stCompareInfo.stMemberInfo.stMemberImageInfo.pcData);
                        Marshal.FreeHGlobal(stRecordInfo.stCompareInfo.stSnapshotImage.stBigImage.pcData);
                        Marshal.FreeHGlobal(stRecordInfo.stCompareInfo.stSnapshotImage.stSmallImage.pcData);
                        break;
                    }
                    else
                    {
                        showFaceAlarmRecordInfo(eFindType, stRecordInfo);

                        Marshal.FreeHGlobal(stRecordInfo.stCompareInfo.stMemberInfo.stMemberSemiInfo.pcData);
                        Marshal.FreeHGlobal(stRecordInfo.stCompareInfo.stMemberInfo.stMemberImageInfo.pcData);
                        Marshal.FreeHGlobal(stRecordInfo.stCompareInfo.stSnapshotImage.stBigImage.pcData);
                        Marshal.FreeHGlobal(stRecordInfo.stCompareInfo.stSnapshotImage.stSmallImage.pcData);
                    }


                }
            }

            NETDEVSDK.NETDEV_FindCloseFaceRecordDetail(lpFindHandle);
        }

        private void faceAlarmRecordSearchBtn_Click(object sender, EventArgs e)
        {
            m_dwFindFaceAlarmRecordOffset = 0;
            findFaceAlarmRecordInfo(NETDEMO_FIND_FACE_ALARM_RECORD_TYPE_E.NETDEMO_FIND_FACE_ALARM_RECORD_MATCH, m_dwFindFaceAlarmRecordOffset);
        }

        private void faceAlarmRecordPreviousBtn_Click(object sender, EventArgs e)
        {
            if (m_dwFindFaceAlarmRecordOffset > NetDevSdk.NETDEMO_FIND_SMART_ALARM_RECORD_COUNT)
            {
                m_dwFindFaceAlarmRecordOffset -= NetDevSdk.NETDEMO_FIND_SMART_ALARM_RECORD_COUNT;
            }
            else
            {
                m_dwFindFaceAlarmRecordOffset = 0;
            }

            findFaceAlarmRecordInfo(NETDEMO_FIND_FACE_ALARM_RECORD_TYPE_E.NETDEMO_FIND_FACE_ALARM_RECORD_MATCH, m_dwFindFaceAlarmRecordOffset);
        }

        private void faceAlarmRecordNextBtn_Click(object sender, EventArgs e)
        {
            m_dwFindFaceAlarmRecordOffset += NetDevSdk.NETDEMO_FIND_SMART_ALARM_RECORD_COUNT;
            findFaceAlarmRecordInfo(NETDEMO_FIND_FACE_ALARM_RECORD_TYPE_E.NETDEMO_FIND_FACE_ALARM_RECORD_MATCH, m_dwFindFaceAlarmRecordOffset);
        }

        private void facePassThruRecordSearchBtn_Click(object sender, EventArgs e)
        {
            m_dwFindFacePassThruRecordOffset = 0;
            findFaceAlarmRecordInfo(NETDEMO_FIND_FACE_ALARM_RECORD_TYPE_E.NETDEMO_FIND_FACE_ALARM_RECORD_PASS_THRU, m_dwFindFacePassThruRecordOffset);
        }

        private void facePassThruRecordPreviousBtn_Click(object sender, EventArgs e)
        {
            if (m_dwFindFacePassThruRecordOffset > NetDevSdk.NETDEMO_FIND_SMART_ALARM_RECORD_COUNT)
            {
                m_dwFindFacePassThruRecordOffset -= NetDevSdk.NETDEMO_FIND_SMART_ALARM_RECORD_COUNT;
            }
            else
            {
                m_dwFindFacePassThruRecordOffset = 0;
            }

            findFaceAlarmRecordInfo(NETDEMO_FIND_FACE_ALARM_RECORD_TYPE_E.NETDEMO_FIND_FACE_ALARM_RECORD_PASS_THRU, m_dwFindFacePassThruRecordOffset);
        }

        private void facePassThruRecordNextBtn_Click(object sender, EventArgs e)
        {
            m_dwFindFacePassThruRecordOffset += NetDevSdk.NETDEMO_FIND_SMART_ALARM_RECORD_COUNT;
            findFaceAlarmRecordInfo(NETDEMO_FIND_FACE_ALARM_RECORD_TYPE_E.NETDEMO_FIND_FACE_ALARM_RECORD_PASS_THRU, m_dwFindFacePassThruRecordOffset);
        }

        private void showVehicleAlarmRecordInfo(NETDEV_VEHICLE_RECORD_INFO_S stVehicleRecordInfo)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            int index = this.LPRAlarmRecordDataGridView.Rows.Add();

            byte[] szPlateImageInfo = new byte[stVehicleRecordInfo.stPlateImage.udwSize];
            Marshal.Copy(stVehicleRecordInfo.stPlateImage.pcData, szPlateImageInfo, 0, (int)stVehicleRecordInfo.stPlateImage.udwSize);
            using (MemoryStream stream = new MemoryStream(szPlateImageInfo))
            {
                try
                {
                    this.LPRAlarmRecordDataGridView.Rows[index].Cells[0].Value = Image.FromStream(stream);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            Int32 bRet = NETDEVSDK.NETDEV_GetVehicleRecordImageInfo(lpUserID, stVehicleRecordInfo.udwRecordID, ref stVehicleRecordInfo.stPanoImage);
            if (NetDevSdk.TRUE == bRet)
            {
                byte[] szSnapshotPanoImageInfo = new byte[stVehicleRecordInfo.stPanoImage.udwSize];
                Marshal.Copy(stVehicleRecordInfo.stPanoImage.pcData, szSnapshotPanoImageInfo, 0, (int)stVehicleRecordInfo.stPanoImage.udwSize);
            }

            this.LPRAlarmRecordDataGridView.Rows[index].Cells[1].Value = GetDefaultString(stVehicleRecordInfo.stPlateAttr.szPlateNo);

            for (int i = 0; i < NetDevSdk.gastNETDemoPlateColor.Length; i++)
            {
                if (stVehicleRecordInfo.stPlateAttr.udwColor == NetDevSdk.gastNETDemoPlateColor[i].dwPlateColor)
                {
                    this.LPRAlarmRecordDataGridView.Rows[index].Cells[2].Value = NetDevSdk.gastNETDemoPlateColor[i].strPlateColor;
                    break;
                }
            }

            for (int i = 0; i < NetDevSdk.gastNETDemoPlateType.Length; i++)
            {
                if (stVehicleRecordInfo.stPlateAttr.udwType == NetDevSdk.gastNETDemoPlateType[i].dwPlateType)
                {
                    this.LPRAlarmRecordDataGridView.Rows[index].Cells[3].Value = NetDevSdk.gastNETDemoPlateType[i].strPlateType;
                    break;
                }
            }

            for (int i = 0; i < NetDevSdk.gastNETDemoPlateColor.Length; i++)
            {
                if (stVehicleRecordInfo.stVehAttr.udwColor == NetDevSdk.gastNETDemoPlateColor[i].dwPlateColor)
                {
                    this.LPRAlarmRecordDataGridView.Rows[index].Cells[4].Value = NetDevSdk.gastNETDemoPlateColor[i].strPlateColor;
                    break;
                }
            }

            this.LPRAlarmRecordDataGridView.Rows[index].Cells[5].Value = GetDefaultString(stVehicleRecordInfo.szChannelName);
            this.LPRAlarmRecordDataGridView.Rows[index].Cells[6].Value = getStrTime(stVehicleRecordInfo.udwPassingTime);
        }

        private void findVehicleAlarmRecordInfo(NETDEMO_FIND_VEHICLE_ALARM_RECORD_TYPE_E eFindType, uint udwOffset)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            LPRAlarmRecordDataGridView.Rows.Clear();

            Int32 bRet = NetDevSdk.TRUE;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

            NETDEV_ALARM_LOG_COND_LIST_S stFindCond = new NETDEV_ALARM_LOG_COND_LIST_S();
            stFindCond.dwPageRow = NetDevSdk.NETDEMO_FIND_SMART_ALARM_RECORD_COUNT;
            stFindCond.dwFirstRow = (int)udwOffset;
            stFindCond.dwCondSize = 0;
            stFindCond.astCondition = new NETDEV_QUERY_INFO_S[NetDevSdk.NETDEV_LOG_QUERY_COND_NUM];

            stFindCond.astCondition[stFindCond.dwCondSize].dwQueryType = (int)NETDEV_QUERYCOND_TYPE_E.NETDEV_QUERYCOND_VEH_DATA_TYPE;
            stFindCond.astCondition[stFindCond.dwCondSize].dwLogicFlag = (int)NETDEV_QUERYCOND_LOGICTYPE_E.NETDEV_QUERYCOND_LOGIC_DIM_QUERY;
            GetUTF8Buffer("0", NetDevSdk.NETDEV_CODE_STR_MAX_LEN, out stFindCond.astCondition[stFindCond.dwCondSize].szConditionData);
            stFindCond.dwCondSize++;

            stFindCond.astCondition[stFindCond.dwCondSize].dwQueryType = (int)NETDEV_QUERYCOND_TYPE_E.NETDEV_QUERYCOND_TIME;
            stFindCond.astCondition[stFindCond.dwCondSize].dwLogicFlag = (int)NETDEV_QUERYCOND_LOGICTYPE_E.NETDEV_QUERYCOND_LOGIC_NO_LESS;
            GetUTF8Buffer(Convert.ToString(getLongTime(LPRAlarmRecordSearchBeginTimeDT.Value.ToString())), NetDevSdk.NETDEV_CODE_STR_MAX_LEN, out stFindCond.astCondition[stFindCond.dwCondSize].szConditionData);
            stFindCond.dwCondSize++;

            stFindCond.astCondition[stFindCond.dwCondSize].dwQueryType = (int)NETDEV_QUERYCOND_TYPE_E.NETDEV_QUERYCOND_TIME;
            stFindCond.astCondition[stFindCond.dwCondSize].dwLogicFlag = (int)NETDEV_QUERYCOND_LOGICTYPE_E.NETDEV_QUERYCOND_LOGIC_NO_GREATER;
            GetUTF8Buffer(Convert.ToString(getLongTime(LPRAlarmRecordSearchEndTimeDT.Value.ToString())), NetDevSdk.NETDEV_CODE_STR_MAX_LEN, out stFindCond.astCondition[stFindCond.dwCondSize].szConditionData);
            stFindCond.dwCondSize++;

            stFindCond.astCondition[stFindCond.dwCondSize].dwQueryType = (int)NETDEV_QUERYCOND_TYPE_E.NETDEV_QUERYCOND_TIME;
            stFindCond.astCondition[stFindCond.dwCondSize].dwLogicFlag = (int)NETDEV_QUERYCOND_LOGICTYPE_E.NETDEV_QUERYCOND_LOGIC_DESC_ORDER;
            GetUTF8Buffer("", NetDevSdk.NETDEV_CODE_STR_MAX_LEN, out stFindCond.astCondition[stFindCond.dwCondSize].szConditionData);
            stFindCond.dwCondSize++;

            if ("" != LPRAlarmRecordSearchCameraNameText.Text)
            {
                stFindCond.astCondition[stFindCond.dwCondSize].dwQueryType = (int)NETDEV_QUERYCOND_TYPE_E.NETDEV_QUERYCOND_CHNNAME;
                stFindCond.astCondition[stFindCond.dwCondSize].dwLogicFlag = (int)NETDEV_QUERYCOND_LOGICTYPE_E.NETDEV_QUERYCOND_LOGIC_DIM_QUERY;
                GetUTF8Buffer(LPRAlarmRecordSearchCameraNameText.Text, NetDevSdk.NETDEV_CODE_STR_MAX_LEN, out stFindCond.astCondition[stFindCond.dwCondSize].szConditionData);
                stFindCond.dwCondSize += 1;
            }

            if ("" != LPRAlarmRecordSearchPlateNoText.Text)
            {
                stFindCond.astCondition[stFindCond.dwCondSize].dwQueryType = (int)NETDEV_QUERYCOND_TYPE_E.NETDEV_QUERYCOND_PLATE_NUM;
                stFindCond.astCondition[stFindCond.dwCondSize].dwLogicFlag = (int)NETDEV_QUERYCOND_LOGICTYPE_E.NETDEV_QUERYCOND_LOGIC_DIM_QUERY;
                GetUTF8Buffer(LPRAlarmRecordSearchPlateNoText.Text, NetDevSdk.NETDEV_CODE_STR_MAX_LEN, out stFindCond.astCondition[stFindCond.dwCondSize].szConditionData);
                stFindCond.dwCondSize += 1;
            }

            if ("All" != LPRAlarmRecordSearchPlateColorCmbBox.Text)
            {
                stFindCond.astCondition[stFindCond.dwCondSize].dwQueryType = (int)NETDEV_QUERYCOND_TYPE_E.NETDEV_QUERYCOND_PLATE_COLOR;
                stFindCond.astCondition[stFindCond.dwCondSize].dwLogicFlag = (int)NETDEV_QUERYCOND_LOGICTYPE_E.NETDEV_QUERYCOND_LOGIC_EQUAL;

                for (int i = 0; i < NetDevSdk.gastNETDemoPlateColor.Length; i++)
                {
                    if (LPRAlarmRecordSearchPlateNoText.Text == NetDevSdk.gastNETDemoPlateColor[i].strPlateColor)
                    {
                        GetUTF8Buffer(Convert.ToString((uint)NetDevSdk.gastNETDemoPlateColor[i].dwPlateColor), NetDevSdk.NETDEV_CODE_STR_MAX_LEN, out stFindCond.astCondition[stFindCond.dwCondSize].szConditionData);
                        break;
                    }
                }
                stFindCond.dwCondSize += 1;
            }

            if ("All" != LPRAlarmRecordSearchVehicleColorCmbBox.Text)
            {
                stFindCond.astCondition[stFindCond.dwCondSize].dwQueryType = (int)NETDEV_QUERYCOND_TYPE_E.NETDEV_QUERYCOND_VEHICLE_COLOR;
                stFindCond.astCondition[stFindCond.dwCondSize].dwLogicFlag = (int)NETDEV_QUERYCOND_LOGICTYPE_E.NETDEV_QUERYCOND_LOGIC_EQUAL;

                for (int i = 0; i < NetDevSdk.gastNETDemoPlateColor.Length; i++)
                {
                    if (LPRAlarmRecordSearchVehicleColorCmbBox.Text == NetDevSdk.gastNETDemoPlateColor[i].strPlateColor)
                    {
                        GetUTF8Buffer(Convert.ToString((uint)NetDevSdk.gastNETDemoPlateColor[i].dwPlateColor), NetDevSdk.NETDEV_CODE_STR_MAX_LEN, out stFindCond.astCondition[stFindCond.dwCondSize].szConditionData);
                        break;
                    }
                }
                stFindCond.dwCondSize += 1;
            }

            if (NETDEMO_FIND_VEHICLE_ALARM_RECORD_TYPE_E.NETDEMO_FIND_VEHICLE_ALARM_RECORD_MATCH == eFindType)
            {
                stFindCond.astCondition[stFindCond.dwCondSize].dwQueryType = (int)NETDEV_QUERYCOND_TYPE_E.NETDEV_QUERYCOND_ALARMTYPE;
                stFindCond.astCondition[stFindCond.dwCondSize].dwLogicFlag = (int)NETDEV_QUERYCOND_LOGICTYPE_E.NETDEV_QUERYCOND_LOGIC_EQUAL;
                if (0 == LPRAlarmRecordMonitoringTypeCmbBox.SelectedIndex)/* Match Alarm */
                {
                    GetUTF8Buffer(Convert.ToString((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_VEHICLE_MATCH_LIST), NetDevSdk.NETDEV_CODE_STR_MAX_LEN, out stFindCond.astCondition[stFindCond.dwCondSize].szConditionData);
                }
                else
                {
                    GetUTF8Buffer(Convert.ToString((int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SMART_VEHICLE_MISMATCH_LIST), NetDevSdk.NETDEV_CODE_STR_MAX_LEN, out stFindCond.astCondition[stFindCond.dwCondSize].szConditionData);
                }
                stFindCond.dwCondSize += 1;

                if ("All" != LPRAlarmRecordMonitoringCauseCmbBox.Text
                    && 0 == LPRAlarmRecordMonitoringTypeCmbBox.SelectedIndex)/* Match Alarm */
                {
                    stFindCond.astCondition[stFindCond.dwCondSize].dwQueryType = (int)NETDEV_QUERYCOND_TYPE_E.NETDEV_QUERYCOND_MONITOY_REASON;
                    stFindCond.astCondition[stFindCond.dwCondSize].dwLogicFlag = (int)NETDEV_QUERYCOND_LOGICTYPE_E.NETDEV_QUERYCOND_LOGIC_EQUAL;
                    GetUTF8Buffer(Convert.ToString(LPRAlarmRecordMonitoringCauseCmbBox.SelectedIndex), NetDevSdk.NETDEV_CODE_STR_MAX_LEN, out stFindCond.astCondition[stFindCond.dwCondSize].szConditionData);
                    stFindCond.dwCondSize += 1;
                }
            }

            NETDEV_SMART_ALARM_LOG_RESULT_INFO_S stResultInfo = new NETDEV_SMART_ALARM_LOG_RESULT_INFO_S();
            IntPtr lpFindHandle = NETDEVSDK.NETDEV_FindVehicleRecordInfoList(lpUserID, ref stFindCond, ref stResultInfo);
            if (IntPtr.Zero != lpFindHandle)
            {
                while (true)
                {
                    NETDEV_VEHICLE_RECORD_INFO_S stVehicleRecordInfo = new NETDEV_VEHICLE_RECORD_INFO_S();
                    stVehicleRecordInfo.stPlateImage.pcData = Marshal.AllocHGlobal(NetDevSdk.NETDEMO_SMALL_IMAGE_SIZE);
                    stVehicleRecordInfo.stPlateImage.udwSize = NetDevSdk.NETDEMO_SMALL_IMAGE_SIZE;
                    stVehicleRecordInfo.stVehicleImage.pcData = Marshal.AllocHGlobal(NetDevSdk.NETDEMO_SMALL_IMAGE_SIZE);
                    stVehicleRecordInfo.stVehicleImage.udwSize = NetDevSdk.NETDEMO_SMALL_IMAGE_SIZE;
                    stVehicleRecordInfo.stPanoImage.pcData = Marshal.AllocHGlobal(NetDevSdk.NETDEMO_SMALL_IMAGE_SIZE);
                    stVehicleRecordInfo.stPanoImage.udwSize = NetDevSdk.NETDEMO_SMALL_IMAGE_SIZE;
                    bRet = NETDEVSDK.NETDEV_FindNextVehicleRecordInfo(lpFindHandle, ref stVehicleRecordInfo);
                    if (NetDevSdk.FALSE == bRet)
                    {
                        Marshal.FreeHGlobal(stVehicleRecordInfo.stPlateImage.pcData);
                        Marshal.FreeHGlobal(stVehicleRecordInfo.stVehicleImage.pcData);
                        Marshal.FreeHGlobal(stVehicleRecordInfo.stPanoImage.pcData);
                        break;
                    }
                    else
                    {
                        showVehicleAlarmRecordInfo(stVehicleRecordInfo);
                        Marshal.FreeHGlobal(stVehicleRecordInfo.stPlateImage.pcData);
                        Marshal.FreeHGlobal(stVehicleRecordInfo.stVehicleImage.pcData);
                        Marshal.FreeHGlobal(stVehicleRecordInfo.stPanoImage.pcData);
                    }
                }
            }

            NETDEVSDK.NETDEV_FindCloseVehicleRecordList(lpFindHandle);
        }

        private void LPRAlarmRecordSearchBtn_Click(object sender, EventArgs e)
        {
            NETDEMO_FIND_VEHICLE_ALARM_RECORD_TYPE_E eSearchType = (NETDEMO_FIND_VEHICLE_ALARM_RECORD_TYPE_E)LPRAlarmRecordSearchTypeCmbBox.SelectedIndex;

            m_dwFindVehicleAlarmRecordOffset = 0;
            findVehicleAlarmRecordInfo(eSearchType, m_dwFindVehicleAlarmRecordOffset);
        }

        private void LPRAlarmRecordPreviousBtn_Click(object sender, EventArgs e)
        {
            NETDEMO_FIND_VEHICLE_ALARM_RECORD_TYPE_E eSearchType = (NETDEMO_FIND_VEHICLE_ALARM_RECORD_TYPE_E)LPRAlarmRecordSearchTypeCmbBox.SelectedIndex;

            if (m_dwFindVehicleAlarmRecordOffset > NetDevSdk.NETDEMO_FIND_SMART_ALARM_RECORD_COUNT)
            {
                m_dwFindVehicleAlarmRecordOffset -= NetDevSdk.NETDEMO_FIND_SMART_ALARM_RECORD_COUNT;
            }
            else
            {
                m_dwFindVehicleAlarmRecordOffset = 0;
            }

            findVehicleAlarmRecordInfo(eSearchType, m_dwFindVehicleAlarmRecordOffset);
        }

        private void LPRAlarmRecordNextBtn_Click(object sender, EventArgs e)
        {
            NETDEMO_FIND_VEHICLE_ALARM_RECORD_TYPE_E eSearchType = (NETDEMO_FIND_VEHICLE_ALARM_RECORD_TYPE_E)LPRAlarmRecordSearchTypeCmbBox.SelectedIndex;

            m_dwFindVehicleAlarmRecordOffset += NetDevSdk.NETDEMO_FIND_SMART_ALARM_RECORD_COUNT;
            findVehicleAlarmRecordInfo(eSearchType, m_dwFindVehicleAlarmRecordOffset);
        }

        private int getRoleInfoList(IntPtr lpUserID)
        {
            IntPtr lpFindHandle = (IntPtr)NETDEVSDK.NETDEV_FindRoleInfoList(lpUserID);
            NETDEV_ROLE_INFO_S pstRoleInfo = new NETDEV_ROLE_INFO_S();
            String strRoleName = "";
            String strDesc = "";
            String strTimeTemplateName = "";
            String strTimeTemplateDesc = "";
            String strUserName = "";
            String strRoleIDList1 = "";

            if (IntPtr.Zero != lpFindHandle)
            {
                while (true)
                {
                    Int32 bRet = NETDEVSDK.NETDEV_FindNextRoleInfo(lpFindHandle, ref pstRoleInfo);
                    if (NetDevSdk.FALSE == bRet)
                    {
                        break;
                    }
                    else
                    {
                        ListViewItem item = new ListViewItem(Convert.ToString(pstRoleInfo.udwRoleID));
                        strRoleName = GetDefaultString(pstRoleInfo.szRoleName);
                        item.SubItems.Add(strRoleName);
                        item.SubItems.Add(Convert.ToString(pstRoleInfo.udwLevel));
                        strDesc = GetDefaultString(pstRoleInfo.szDesc);
                        item.SubItems.Add(Convert.ToString(strDesc));
                        listView1.Items.Add(item);

                        comboBox1.Items.AddRange(new object[] { Convert.ToString(pstRoleInfo.udwRoleID), });
                    }
                }
            }
            else
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "Find Role Info List", NETDEVSDK.NETDEV_GetLastError());
                return 1;
            }

            NETDEVSDK.NETDEV_FindCloseRoleInfoList(lpFindHandle);
            showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "Find Role Info List");
            return 0;
        }

        private int getTimeTemplateList(IntPtr lpUserID)
        {
            String strRoleName = "";
            String strDesc = "";
            String strTimeTemplateName = "";
            String strTimeTemplateDesc = "";
            String strUserName = "";
            String strRoleIDList1 = "";

            IntPtr lpFindHandle = (IntPtr)NETDEVSDK.NETDEV_FindTimeTemplateByTypeList(lpUserID, 2);
            NETDEV_TIME_TEMPLATE_BASE_INFO_S pstTimeTemplateInfo = new NETDEV_TIME_TEMPLATE_BASE_INFO_S();
            if (IntPtr.Zero != lpFindHandle)
            {
                while (true)
                {
                    Int32 bRet = NETDEVSDK.NETDEV_FindNextTimeTemplateByTypeInfo(lpFindHandle, ref pstTimeTemplateInfo);
                    if (NetDevSdk.FALSE == bRet)
                    {
                        break;
                    }
                    else
                    {

                        NETDEV_SYSTEM_TIME_TEMPLATE_S pstTimeTemplate = new NETDEV_SYSTEM_TIME_TEMPLATE_S();
                        pstTimeTemplate.udwTemplateID = pstTimeTemplateInfo.udwTemplateID;
                        bRet = NETDEVSDK.NETDEV_GetTimeTemplate(lpUserID, ref pstTimeTemplate);
                        if (NetDevSdk.FALSE == bRet)
                        {
                            showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "GetTimeTemplate", NETDEVSDK.NETDEV_GetLastError());
                        }

                        ListViewItem item = new ListViewItem(Convert.ToString(pstTimeTemplateInfo.udwTemplateID));
                        strTimeTemplateName = GetDefaultString(pstTimeTemplateInfo.szTemplateName);
                        item.SubItems.Add(strTimeTemplateName);
                        item.SubItems.Add(Convert.ToString(pstTimeTemplate.bIsBuiltin));
                        strTimeTemplateDesc = GetDefaultString(pstTimeTemplate.szTemplateDesc);
                        item.SubItems.Add(Convert.ToString(strTimeTemplateDesc));
                        listView2.Items.Add(item);

                        comboBox2.Items.AddRange(new object[] { Convert.ToString(pstTimeTemplateInfo.udwTemplateID), });
                    }
                }
            }
            else
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "Time Template By TypeList", NETDEVSDK.NETDEV_GetLastError());
                return 1;
            }

            NETDEVSDK.NETDEV_FindCloseTimeTemplateByTypeList(lpFindHandle);
            showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "Time Template By TypeList");

            return 0;
        }

        private int getUserInfoList(IntPtr lpUserID)
        {
            String strRoleName = "";
            String strDesc = "";
            String strTimeTemplateName = "";
            String strTimeTemplateDesc = "";
            String strUserName = "";
            String strRoleIDList1 = "";

            IntPtr lpUserDetailFindHandle = (IntPtr)NETDEVSDK.NETDEV_FindUserDetailInfoListV30(lpUserID);
            NETDEV_USER_DETAIL_INFO_V30_S pstUserDetailInfo = new NETDEV_USER_DETAIL_INFO_V30_S();
            if (IntPtr.Zero != lpUserDetailFindHandle)
            {
                while (true)
                {
                    Int32 bRet = NETDEVSDK.NETDEV_FindNextUserDetailInfoV30(lpUserDetailFindHandle, ref pstUserDetailInfo);
                    if (NetDevSdk.FALSE == bRet)
                    {
                        break;
                    }
                    else
                    {
                        IntPtr lpFindHandle = (IntPtr)NETDEVSDK.NETDEV_FindRoleBaseInfoOfUserList(lpUserID, pstUserDetailInfo.udwUserID);
                        String strRoleID;
                        UInt32 udwRoleID = 0;
                        NETDEV_ROLE_BASE_INFO_S stRoleBaseInfo = new NETDEV_ROLE_BASE_INFO_S();
                        if (IntPtr.Zero != lpFindHandle)
                        {
                            while (true)
                            {
                                bRet = NETDEVSDK.NETDEV_FindNextRoleBaseInfoOfUser(lpFindHandle, ref stRoleBaseInfo);
                                if (NetDevSdk.FALSE == bRet)
                                {
                                    break;
                                }
                                else
                                {
                                    udwRoleID = stRoleBaseInfo.udwRoleID; ;
                                }
                            }
                        }
                        NETDEVSDK.NETDEV_FindCloseRoleBaseInfoOfUserList(lpFindHandle);

                        ListViewItem item = new ListViewItem(Convert.ToString(pstUserDetailInfo.udwUserID));
                        strUserName = GetDefaultString(pstUserDetailInfo.szUserName);
                        item.SubItems.Add(strUserName);
                        item.SubItems.Add(Convert.ToString(udwRoleID));
                        item.SubItems.Add(Convert.ToString(pstUserDetailInfo.stTimeTemplateInfo.dwTamplateID));
                        listView3.Items.Add(item);
                    }
                }
            }
            else
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "Find User Detail Info List", NETDEVSDK.NETDEV_GetLastError());
                return 1;
            }

            NETDEVSDK.NETDEV_FindCloseUserDetailInfoListV30(lpUserDetailFindHandle);
            showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "Find User Detail Info List");
            return 0;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int dwDeviceIndex = getDeviceIndex();
            if (dwDeviceIndex == -1)
            {
                return;
            }
            IntPtr lpUserIDD = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;
            comboBox1.Items.Clear();
            comboBox1.Text = "";
            comboBox2.Items.Clear();
            comboBox2.Text = "";

            listView1.Items.Clear();
            getRoleInfoList(lpUserIDD);
            listView2.Items.Clear();
            getTimeTemplateList(lpUserIDD);
            listView3.Items.Clear();
            getUserInfoList(lpUserIDD);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView3.SelectedIndices != null && listView3.SelectedIndices.Count > 0)
            {
                String strUserName = listView3.SelectedItems[0].SubItems[1].Text;

                if ("admin" == strUserName)
                {
                    return;
                }
                IntPtr lpUserIDD = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;
                NETDEV_USER_NAME_INFO_LIST_S stUserNameList = new NETDEV_USER_NAME_INFO_LIST_S();
                NETDEV_BATCH_OPERATOR_LIST_S stResultList = new NETDEV_BATCH_OPERATOR_LIST_S();

                GetUTF8Buffer(strUserName, NetDevSdk.NETDEV_LEN_256, out stUserNameList.szUserName);
                stResultList.udwNum = 1;
                stResultList.pstBatchList = Marshal.AllocHGlobal(1 * Marshal.SizeOf(typeof(NETDEV_BATCH_OPERATOR_INFO_S)));
                UInt32 udwUserNum = 1;
                Int32 bRet = NETDEVSDK.NETDEV_DeleteUserV30(lpUserIDD, udwUserNum, ref stUserNameList, ref stResultList);
                if (NetDevSdk.FALSE == bRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "delete User fail", NETDEVSDK.NETDEV_GetLastError());
                }
                else
                {
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    comboBox1.Items.Clear();
                    comboBox1.Text = "";
                    comboBox2.Items.Clear();
                    comboBox2.Text = "";
                    listView1.Items.Clear();
                    getRoleInfoList(lpUserIDD);
                    listView2.Items.Clear();
                    getTimeTemplateList(lpUserIDD);

                    listView3.Items.Clear();
                    getUserInfoList(lpUserIDD);
                    showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "delete User Success");
                }

                Marshal.FreeHGlobal(stResultList.pstBatchList);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Int32 bRet = 0;
            int dwDeviceIndex = getDeviceIndex();
            if (dwDeviceIndex == -1)
            {
                return;
            }
            IntPtr lpUserIDD = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;
            if (string.IsNullOrEmpty(comboBox1.Text) == true)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "Role ID is NULL", -1);
                return;
            }

            if (string.IsNullOrEmpty(comboBox2.Text) == true)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "Time Template  ID is NULL", -1);
                return;
            }
            comboBox1.Text = comboBox1.SelectedItem.ToString();
            comboBox2.Text = comboBox2.SelectedItem.ToString();

            String beginDateTimeStr = this.dateTimePicker1.Text;
            String endDateTimeStr = this.dateTimePicker2.Text;

            NETDEV_USER_DETAIL_INFO_V30_S stUserDetailInfo = new NETDEV_USER_DETAIL_INFO_V30_S();

            stUserDetailInfo.udwUserID = Convert.ToUInt32(textBox1.Text);
            stUserDetailInfo.stTimeTemplateInfo.dwTamplateID = Convert.ToInt32(comboBox2.Text);

            GetUTF8Buffer(textBox2.Text, NetDevSdk.NETDEV_LEN_256, out stUserDetailInfo.szUserName);
            GetUTF8Buffer(textBox3.Text, NetDevSdk.NETDEV_LEN_256, out stUserDetailInfo.szPassword);

            stUserDetailInfo.stValidBeginTime.dwYear = Convert.ToInt32(beginDateTimeStr.Split('/')[0]);
            stUserDetailInfo.stValidBeginTime.dwMonth = Convert.ToInt32(beginDateTimeStr.Split('/')[1]);
            stUserDetailInfo.stValidBeginTime.dwDay = Convert.ToInt32(beginDateTimeStr.Split('/')[2]);

            stUserDetailInfo.stValidEndTime.dwYear = Convert.ToInt32(endDateTimeStr.Split('/')[0]);
            stUserDetailInfo.stValidEndTime.dwMonth = Convert.ToInt32(endDateTimeStr.Split('/')[1]);
            stUserDetailInfo.stValidEndTime.dwDay = Convert.ToInt32(endDateTimeStr.Split('/')[2]);

            {
                NETDEV_USER_DETAIL_INFO_V30_S pstUserDetailInfo = new NETDEV_USER_DETAIL_INFO_V30_S();
                GetUTF8Buffer(textBox2.Text, NetDevSdk.NETDEV_LEN_256, out pstUserDetailInfo.szUserName);
                bRet = NETDEVSDK.NETDEV_GetUserDetailInfoV30(lpUserIDD, ref pstUserDetailInfo);
                if (NetDevSdk.TRUE == bRet)
                {
                    stUserDetailInfo.szOldPassword = pstUserDetailInfo.szOldPassword;
                }
            }


            bRet = NETDEVSDK.NETDEV_ModifyUserV30(lpUserIDD, ref stUserDetailInfo);
            if (NetDevSdk.FALSE == bRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "Modify User fail", NETDEVSDK.NETDEV_GetLastError());
            }
            else
            {
                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "Modify User  Success");
                NETDEV_ID_LIST_S stRoleList = new NETDEV_ID_LIST_S();
                stRoleList.udwNum = 1;

                uint[] iTmp = new uint[stRoleList.udwNum];
                iTmp[0] = Convert.ToUInt32(comboBox1.Text);
                stRoleList.pudwIDs = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(uint)) * (int)stRoleList.udwNum);
                for (int i = 0; i < stRoleList.udwNum; ++i)
                {
                    IntPtr pudwIDListTemp = new IntPtr(stRoleList.pudwIDs.ToInt32() + Marshal.SizeOf(typeof(uint)) * i);
                    Marshal.StructureToPtr(iTmp[i], pudwIDListTemp, true);
                }

                bRet = NETDEVSDK.NETDEV_ModifyRoleInfoOfUser(lpUserIDD, stUserDetailInfo.udwUserID, ref stRoleList);
                if (NetDevSdk.FALSE == bRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "Modify Role Info fail", NETDEVSDK.NETDEV_GetLastError());
                }
                else
                {
                    showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "Modify Role Info  Success");
                    listView3.Items.Clear();
                    getUserInfoList(lpUserIDD);
                    Marshal.FreeHGlobal(stRoleList.pudwIDs);
                }
            }
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView3.SelectedIndices != null && listView3.SelectedIndices.Count > 0)
            {
                textBox1.Text = listView3.SelectedItems[0].Text;
                textBox2.Text = listView3.SelectedItems[0].SubItems[1].Text;
                IntPtr lpUserIDD = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;

                {
                    IntPtr lpFindHandle = (IntPtr)NETDEVSDK.NETDEV_FindRoleBaseInfoOfUserList(lpUserIDD, Convert.ToUInt32(textBox1.Text));
                    NETDEV_ROLE_BASE_INFO_S stRoleBaseInfo = new NETDEV_ROLE_BASE_INFO_S();
                    if (IntPtr.Zero != lpFindHandle)
                    {
                        while (true)
                        {
                            Int32 bRet = NETDEVSDK.NETDEV_FindNextRoleBaseInfoOfUser(lpFindHandle, ref stRoleBaseInfo);
                            if (NetDevSdk.FALSE == bRet)
                            {
                                break;
                            }
                            else
                            {
                                comboBox1.Text = Convert.ToString(stRoleBaseInfo.udwRoleID);
                            }
                        }
                    }
                    NETDEVSDK.NETDEV_FindCloseRoleBaseInfoOfUserList(lpFindHandle);
                }

                {
                    NETDEV_USER_DETAIL_INFO_V30_S pstUserDetailInfo = new NETDEV_USER_DETAIL_INFO_V30_S();
                    GetUTF8Buffer(textBox2.Text, NetDevSdk.NETDEV_LEN_256, out pstUserDetailInfo.szUserName);
                    Int32 bRet = NETDEVSDK.NETDEV_GetUserDetailInfoV30(lpUserIDD, ref pstUserDetailInfo);
                    if (NetDevSdk.TRUE == bRet)
                    {
                        comboBox2.Text = Convert.ToString(pstUserDetailInfo.stTimeTemplateInfo.dwTamplateID);
                    }
                }

            }
        }

        private void ModifyCurPwd_Click(object sender, EventArgs e)
        {
            int dwDeviceIndex = getDeviceIndex();
            if (dwDeviceIndex == -1)
            {
                return;
            }
            IntPtr lpUserIDD = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;
            String strNewPassword = textBox4.Text;
            if ("" == textBox4.Text)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "Modify Current Pin fail ,new password is null", -1);
                return;
            }

            Int32 bRet = NETDEVSDK.NETDEV_ModifyCurrentPin(lpUserIDD, m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_password, strNewPassword);
            if (NetDevSdk.FALSE == bRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "Modify Current Pin fail", NETDEVSDK.NETDEV_GetLastError());
            }
            else
            {
                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "Modify Current Pin Success");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            int dwDeviceIndex = getDeviceIndex();
            if (dwDeviceIndex == -1)
            {
                return;
            }
            IntPtr lpUserIDD = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;
            if (string.IsNullOrEmpty(comboBox1.Text) == true)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "Role ID is NULL", -1);
                return;
            }

            if (string.IsNullOrEmpty(comboBox2.Text) == true)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "Time Template  ID is NULL", -1);
                return;
            }

            comboBox1.Text = comboBox1.SelectedItem.ToString();
            comboBox2.Text = comboBox2.SelectedItem.ToString();

            String beginDateTimeStr = this.dateTimePicker1.Text;
            String endDateTimeStr = this.dateTimePicker2.Text;


            NETDEV_USER_DETAIL_INFO_V30_S stUserDetailInfo = new NETDEV_USER_DETAIL_INFO_V30_S();

            stUserDetailInfo.stTimeTemplateInfo.dwTamplateID = Convert.ToInt32(comboBox2.Text);

            GetUTF8Buffer(textBox2.Text, NetDevSdk.NETDEV_LEN_256, out stUserDetailInfo.szUserName);
            GetUTF8Buffer(textBox3.Text, NetDevSdk.NETDEV_LEN_256, out stUserDetailInfo.szPassword);

            stUserDetailInfo.stValidBeginTime.dwYear = Convert.ToInt32(beginDateTimeStr.Split('/')[0]);
            stUserDetailInfo.stValidBeginTime.dwMonth = Convert.ToInt32(beginDateTimeStr.Split('/')[1]);
            stUserDetailInfo.stValidBeginTime.dwDay = Convert.ToInt32(beginDateTimeStr.Split('/')[2]);

            stUserDetailInfo.stValidEndTime.dwYear = Convert.ToInt32(endDateTimeStr.Split('/')[0]);
            stUserDetailInfo.stValidEndTime.dwMonth = Convert.ToInt32(endDateTimeStr.Split('/')[1]);
            stUserDetailInfo.stValidEndTime.dwDay = Convert.ToInt32(endDateTimeStr.Split('/')[2]);


            Int32 bRet = NETDEVSDK.NETDEV_AddUserV30(lpUserIDD, ref stUserDetailInfo);
            if (NetDevSdk.FALSE == bRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "Add User fail", NETDEVSDK.NETDEV_GetLastError());
            }
            else
            {
                {
                    NETDEV_USER_DETAIL_INFO_V30_S pstUserDetailInfo = new NETDEV_USER_DETAIL_INFO_V30_S();
                    pstUserDetailInfo.szUserName = stUserDetailInfo.szUserName;
                    bRet = NETDEVSDK.NETDEV_GetUserDetailInfoV30(lpUserIDD, ref pstUserDetailInfo);
                    if (NetDevSdk.TRUE != bRet)
                    {
                        showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "Get User Detail Info fail", NETDEVSDK.NETDEV_GetLastError());
                    }
                    else
                    {
                        NETDEV_ID_LIST_S stRoleList = new NETDEV_ID_LIST_S();
                        stRoleList.udwNum = 1;

                        uint[] iTmp = new uint[stRoleList.udwNum];
                        iTmp[0] = Convert.ToUInt32(comboBox1.Text);
                        stRoleList.pudwIDs = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(uint)) * (int)stRoleList.udwNum);
                        for (int i = 0; i < stRoleList.udwNum; ++i)
                        {
                            IntPtr pudwIDListTemp = new IntPtr(stRoleList.pudwIDs.ToInt32() + Marshal.SizeOf(typeof(uint)) * i);
                            Marshal.StructureToPtr(iTmp[i], pudwIDListTemp, true);
                        }

                        bRet = NETDEVSDK.NETDEV_ModifyRoleInfoOfUser(lpUserIDD, pstUserDetailInfo.udwUserID, ref stRoleList);
                        if (NetDevSdk.FALSE == bRet)
                        {
                            showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "Modify Role Info fail", NETDEVSDK.NETDEV_GetLastError());
                        }
                        else
                        {
                            showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "Add User Info  Success");
                            listView3.Items.Clear();
                            getUserInfoList(lpUserIDD);
                            Marshal.FreeHGlobal(stRoleList.pudwIDs);
                        }
                    }
                }
            }
        }

        private void ButtonStartrecrod_Click(object sender, EventArgs e)
        {
            if (getChannelID() == -1)
            {
                return;
            }
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex > m_deviceInfoList.Count() || m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }
            if (true == m_curRealPanel.m_recordStatus)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Only allow a channel", -1);
                return;
            }
            m_curRealPanel.m_deviceIndex = m_CurSelectTreeNodeInfo.dwDeviceIndex;
            IntPtr lpHandle = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;


            if (IntPtr.Zero == lpHandle)
            {
                MessageBox.Show("Device Handle is 0 ", "warning");
                return;
            }

            NETDEV_PREVIEWINFO_S stPreviewInfo = new NETDEV_PREVIEWINFO_S();
            stPreviewInfo.dwChannelID = getChannelID();
            stPreviewInfo.dwLinkMode = (int)NETDEV_PROTOCAL_E.NETDEV_TRANSPROTOCAL_RTPTCP;
            stPreviewInfo.dwStreamType = Helper.m_dwStreamType;
            stPreviewInfo.hPlayWnd = IntPtr.Zero;
            IntPtr Handle = NETDEVSDK.NETDEV_RealPlay(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle, ref stPreviewInfo, IntPtr.Zero, IntPtr.Zero);
            if (Handle == IntPtr.Zero)
            {
                return;
            }

            m_lpNoPreviewRealPlayHandle = Handle;

            NETDEMO_RealPlayInfo objRealPlayInfo = new NETDEMO_RealPlayInfo();
            objRealPlayInfo.m_channel = getChannelID();
            m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].addRealPlayInfo(objRealPlayInfo);

            {
                String temp = string.Copy(LocalSetting.m_strLocalRecordPath);
                DateTime date = DateTime.Now;
                String curTime = date.ToString("yyMMddHHmmss", DateTimeFormatInfo.InvariantInfo);
                LocalSetting.m_strLocalRecordPath += "\\";
                LocalSetting.m_strLocalRecordPath += m_deviceInfoList[m_curRealPanel.m_deviceIndex].m_ip;
                LocalSetting.m_strLocalRecordPath += "_";
                LocalSetting.m_strLocalRecordPath += m_curRealPanel.m_channelID;
                LocalSetting.m_strLocalRecordPath += "_";
                LocalSetting.m_strLocalRecordPath += curTime;

                byte[] localRecordPath;
                GetUTF8Buffer(LocalSetting.m_strLocalRecordPath, NetDevSdk.NETDEV_LEN_260, out localRecordPath);
                int iRet = NETDEVSDK.NETDEV_SaveRealData(m_lpNoPreviewRealPlayHandle, localRecordPath, (int)NETDEV_MEDIA_FILE_FORMAT_E.NETDEV_MEDIA_FILE_MP4);
                if (NetDevSdk.FALSE == iRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "No preview start record", NETDEVSDK.NETDEV_GetLastError());
                    return;
                }
                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "No preview start record");

                m_curRealPanel.m_recordStatus = true;
                LocalSetting.m_strLocalRecordPath = temp;
            }

        }

        private void ButtonStoprecord_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex > m_deviceInfoList.Count() || m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }
            if (IntPtr.Zero != m_lpNoPreviewRealPlayHandle)
            {
                NETDEVSDK.NETDEV_StopSaveRealData(m_lpNoPreviewRealPlayHandle);
                NETDEVSDK.NETDEV_StopRealPlay(m_lpNoPreviewRealPlayHandle);
                m_lpNoPreviewRealPlayHandle = IntPtr.Zero;
                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "No preview stop record");
                return;
            }
        }

        private void ButtonStartVoice_Click(object sender, EventArgs e)
        {
            if (getChannelID() == -1)
            {
                return;
            }
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex > m_deviceInfoList.Count() || m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }
            if (IntPtr.Zero == m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle)
            {
                return;
            }

            m_lpNoPreviewTalkHandle = NETDEVSDK.NETDEV_StartVoiceCom(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle, getChannelID(), IntPtr.Zero, IntPtr.Zero);
            if (IntPtr.Zero == m_lpNoPreviewTalkHandle)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Start two way audio", -1);
            }
            else
            {
                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Start two way audio");
                return;
            }

        }

        private void ButtonStopVoice_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex > m_deviceInfoList.Count() || m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }
            if (IntPtr.Zero != m_lpNoPreviewTalkHandle)
            {
                NETDEVSDK.NETDEV_StopVoiceCom(m_lpNoPreviewTalkHandle);
                m_lpNoPreviewRealPlayHandle = IntPtr.Zero;
                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "Stop two way audio");
                return;
            }
        }

        private void ButtoncaptureNoPreview_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex > m_deviceInfoList.Count() || m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            String strNoPreviewTemp = string.Copy(LocalSetting.m_strPicSavePath);
            DateTime oNoPreviewDate = DateTime.Now;
            String strNoPreviewCurTime = oNoPreviewDate.ToString("yyMMddHHmmss", DateTimeFormatInfo.InvariantInfo);
            LocalSetting.m_strPicSavePath += "\\";
            LocalSetting.m_strPicSavePath += m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip;
            LocalSetting.m_strPicSavePath += "_";
            LocalSetting.m_strPicSavePath += (getChannelID());
            LocalSetting.m_strPicSavePath += "_";
            LocalSetting.m_strPicSavePath += strNoPreviewCurTime;

            byte[] picNoPreviewSavePath;
            GetUTF8Buffer(LocalSetting.m_strPicSavePath, NetDevSdk.NETDEV_LEN_260, out picNoPreviewSavePath);

            int iiRet = NETDEVSDK.NETDEV_CaptureNoPreview(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle, getChannelID(), Helper.m_dwStreamType, LocalSetting.m_strPicSavePath, (int)NETDEV_PICTURE_FORMAT_E.NETDEV_PICTURE_JPG);
            if (NetDevSdk.FALSE == iiRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "CaptureNoPreview", NETDEVSDK.NETDEV_GetLastError());
                LocalSetting.m_strPicSavePath = strNoPreviewTemp;
                return;
            }
            showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (getChannelID()), "CaptureNoPreview");
            LocalSetting.m_strPicSavePath = strNoPreviewTemp;
            return;
        }

        private void GetRecordDays_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0 || getChannelID() < 0)
            {
                return;
            }

            Int32 bRet = NetDevSdk.TRUE;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;
            Int32 dwDayNums = 0;
            bRet = NETDEVSDK.NETDEV_GetVideoDayNums(lpUserID, getChannelID(), ref dwDayNums);

            if (NetDevSdk.FALSE == bRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_GetVideoDayNums failed", NETDEVSDK.NETDEV_GetLastError());
            }
            else
            {
                showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "NETDEV_GetVideoDayNums success");
                MessageBox.Show("RecordDays [" + dwDayNums.ToString() + "]");
            }
        }

        private void GetHDDSmartInfo_Click(object sender, EventArgs e)
        {
            if (m_CurSelectTreeNodeInfo.dwDeviceIndex < 0)
            {
                return;
            }

            Int32 bRet = NetDevSdk.TRUE;
            IntPtr lpUserID = m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle;
            Int32 dwBytesReturned = 0;

            NETDEV_RAID_STATUS_S RAIDStatus = new NETDEV_RAID_STATUS_S();
            IntPtr lpOutBuffer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETDEV_RAID_STATUS_S)));
            Marshal.StructureToPtr(RAIDStatus, lpOutBuffer, true);
            bRet = NETDEVSDK.NETDEV_GetDevConfig(lpUserID, 0, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_RAID_STATUS, lpOutBuffer, Marshal.SizeOf(typeof(NETDEV_RAID_STATUS_S)), ref dwBytesReturned);
            if (NetDevSdk.FALSE == bRet)
            {
                showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "GetRAIDStatus failed", NETDEVSDK.NETDEV_GetLastError());
            }
            RAIDStatus = (NETDEV_RAID_STATUS_S)Marshal.PtrToStructure(lpOutBuffer, typeof(NETDEV_RAID_STATUS_S));
            Marshal.FreeHGlobal(lpOutBuffer);

            if (1 == RAIDStatus.bEnabled)
            {
                NETDEV_HDD_INFO_LIST_S HDDInfoList = new NETDEV_HDD_INFO_LIST_S();
                lpOutBuffer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETDEV_HDD_INFO_LIST_S)));
                Marshal.StructureToPtr(HDDInfoList, lpOutBuffer, true);
                bRet = NETDEVSDK.NETDEV_GetDevConfig(lpUserID, 0, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_RAID_STORAGE_CONTAINER_INFO_LIST, lpOutBuffer, Marshal.SizeOf(typeof(NETDEV_HDD_INFO_LIST_S)), ref dwBytesReturned);
                if (NetDevSdk.FALSE == bRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "GetHDDInfoList failed", NETDEVSDK.NETDEV_GetLastError());
                }
                HDDInfoList = (NETDEV_HDD_INFO_LIST_S)Marshal.PtrToStructure(lpOutBuffer, typeof(NETDEV_HDD_INFO_LIST_S));
                Marshal.FreeHGlobal(lpOutBuffer);

                for (int j = 0; j < HDDInfoList.dwSize; j++)
                {
                    if ((Int32)NETDEV_HDD_STATUS_E.NETDEV_HDD_STATUS_NORMAL == (Int32)HDDInfoList.astHDDInfo[j].udwStatus)
                    {
                        NETDEV_HDD_SMART_INFO_S HDDSmartInfo = new NETDEV_HDD_SMART_INFO_S();
                        HDDSmartInfo.udwID = HDDInfoList.astHDDInfo[j].udwID;
                        lpOutBuffer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETDEV_HDD_SMART_INFO_S)));
                        Marshal.StructureToPtr(HDDSmartInfo, lpOutBuffer, true);
                        bRet = NETDEVSDK.NETDEV_GetDevConfig(lpUserID, 0, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_HDD_SMART_INFO, lpOutBuffer, Marshal.SizeOf(typeof(NETDEV_HDD_SMART_INFO_S)), ref dwBytesReturned);
                        if (NetDevSdk.FALSE == bRet)
                        {
                            Marshal.FreeHGlobal(lpOutBuffer);
                            showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "GetHDDSmartInfo failed", NETDEVSDK.NETDEV_GetLastError());
                        }
                        else
                        {
                            HDDSmartInfo = (NETDEV_HDD_SMART_INFO_S)Marshal.PtrToStructure(lpOutBuffer, typeof(NETDEV_HDD_SMART_INFO_S));
                            Marshal.FreeHGlobal(lpOutBuffer);
                            showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "GetHDDSmartInfo success");
                            string strHDDSmartInfo = "";
                            strHDDSmartInfo += "ID:";
                            strHDDSmartInfo += HDDSmartInfo.udwID;
                            strHDDSmartInfo += "    Manufacturer:";
                            strHDDSmartInfo += GetDefaultString(HDDSmartInfo.szManufacturer);
                            strHDDSmartInfo += "    Temperature:";
                            strHDDSmartInfo += HDDSmartInfo.udwTemperature;
                            strHDDSmartInfo += "    DeviceModel:";
                            strHDDSmartInfo += GetDefaultString(HDDSmartInfo.szDeviceModel);
                            strHDDSmartInfo += "    UsedDays:";
                            strHDDSmartInfo += HDDSmartInfo.udwUsedDays;
                            strHDDSmartInfo += "    HealthAssessment:";
                            strHDDSmartInfo += HDDSmartInfo.udwHealthAssessment;
                            strHDDSmartInfo += "    Firmware:";
                            strHDDSmartInfo += GetDefaultString(HDDSmartInfo.szFirmware);
                            strHDDSmartInfo += "    CheckResult:";
                            strHDDSmartInfo += HDDSmartInfo.bCheckResult;
                            strHDDSmartInfo += "    CheckPrograss:";
                            strHDDSmartInfo += HDDSmartInfo.udwCheckPrograss;
                            strHDDSmartInfo += "    CheckStatus:";
                            strHDDSmartInfo += HDDSmartInfo.udwCheckStatus;
                            strHDDSmartInfo += "    CheckType:";
                            strHDDSmartInfo += HDDSmartInfo.udwCheckType;
                            strHDDSmartInfo += "\n";
                            for (Int32 i = 0; i < HDDSmartInfo.udwSmartNum; i++)
                            {
                                strHDDSmartInfo += "    AttributeID:";
                                strHDDSmartInfo += HDDSmartInfo.SmartDetailsInfoList[i].udwAttributeID;
                                strHDDSmartInfo += "    AttributeName:";
                                strHDDSmartInfo += GetDefaultString(HDDSmartInfo.SmartDetailsInfoList[i].szAttributeName);
                                strHDDSmartInfo += "    Status:";
                                strHDDSmartInfo += HDDSmartInfo.SmartDetailsInfoList[i].udwStatus;
                                strHDDSmartInfo += "    Hex:";
                                strHDDSmartInfo += HDDSmartInfo.SmartDetailsInfoList[i].udwHex;
                                strHDDSmartInfo += "    Thresh:";
                                strHDDSmartInfo += HDDSmartInfo.SmartDetailsInfoList[i].udwThresh;
                                strHDDSmartInfo += "    CurrentValue:";
                                strHDDSmartInfo += HDDSmartInfo.SmartDetailsInfoList[i].udwCurrentValue;
                                strHDDSmartInfo += "    WorstValue:";
                                strHDDSmartInfo += HDDSmartInfo.SmartDetailsInfoList[i].udwWorstValue;
                                strHDDSmartInfo += "    ActualValue:";
                                strHDDSmartInfo += HDDSmartInfo.SmartDetailsInfoList[i].udwActualValue;
                                strHDDSmartInfo += "\n";
                            }
                            MessageBox.Show(strHDDSmartInfo);
                        }
                    }
                }
            }
            else
            {
                NETDEV_STORAGE_CONTAINER_INFO_LIST_S StorageContainerInfoList = new NETDEV_STORAGE_CONTAINER_INFO_LIST_S();
                lpOutBuffer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETDEV_STORAGE_CONTAINER_INFO_LIST_S)));
                Marshal.StructureToPtr(StorageContainerInfoList, lpOutBuffer, true);
                bRet = NETDEVSDK.NETDEV_GetDevConfig(lpUserID, 0, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_STORAGE_CONTAINER_INFO_LIST, lpOutBuffer, Marshal.SizeOf(typeof(NETDEV_STORAGE_CONTAINER_INFO_LIST_S)), ref dwBytesReturned);
                if (NetDevSdk.FALSE == bRet)
                {
                    showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "GetStorageContainerInfoList failed", NETDEVSDK.NETDEV_GetLastError());
                }
                StorageContainerInfoList = (NETDEV_STORAGE_CONTAINER_INFO_LIST_S)Marshal.PtrToStructure(lpOutBuffer, typeof(NETDEV_STORAGE_CONTAINER_INFO_LIST_S));
                Marshal.FreeHGlobal(lpOutBuffer);

                for (int j = 0; j < StorageContainerInfoList.udwLocalHDDNum; j++)
                {
                    if ((Int32)NETDEV_STORAGE_CONTAINER_STATUS_E.NETDEV_STORAGE_CONTAINER_STATUS_NORMAL == (Int32)StorageContainerInfoList.astLocalHDDList[j].udwStatus)
                    {
                        NETDEV_HDD_SMART_INFO_S HDDSmartInfo = new NETDEV_HDD_SMART_INFO_S();
                        HDDSmartInfo.udwID = StorageContainerInfoList.astLocalHDDList[j].udwID;
                        lpOutBuffer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETDEV_HDD_SMART_INFO_S)));
                        Marshal.StructureToPtr(HDDSmartInfo, lpOutBuffer, true);
                        bRet = NETDEVSDK.NETDEV_GetDevConfig(lpUserID, 0, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_HDD_SMART_INFO, lpOutBuffer, Marshal.SizeOf(typeof(NETDEV_HDD_SMART_INFO_S)), ref dwBytesReturned);
                        if (NetDevSdk.FALSE == bRet)
                        {
                            Marshal.FreeHGlobal(lpOutBuffer);
                            showFailLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "GetHDDSmartInfo failed", NETDEVSDK.NETDEV_GetLastError());
                        }
                        else
                        {
                            HDDSmartInfo = (NETDEV_HDD_SMART_INFO_S)Marshal.PtrToStructure(lpOutBuffer, typeof(NETDEV_HDD_SMART_INFO_S));
                            Marshal.FreeHGlobal(lpOutBuffer);
                            showSuccessLogInfo(m_deviceInfoList[m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip, "GetHDDSmartInfo success");
                            string strHDDSmartInfo = "";
                            strHDDSmartInfo += "ID:";
                            strHDDSmartInfo += HDDSmartInfo.udwID;
                            strHDDSmartInfo += "    Manufacturer:";
                            strHDDSmartInfo += GetDefaultString(HDDSmartInfo.szManufacturer);
                            strHDDSmartInfo += "    Temperature:";
                            strHDDSmartInfo += HDDSmartInfo.udwTemperature;
                            strHDDSmartInfo += "    DeviceModel:";
                            strHDDSmartInfo += GetDefaultString(HDDSmartInfo.szDeviceModel);
                            strHDDSmartInfo += "    UsedDays:";
                            strHDDSmartInfo += HDDSmartInfo.udwUsedDays;
                            strHDDSmartInfo += "    HealthAssessment:";
                            strHDDSmartInfo += HDDSmartInfo.udwHealthAssessment;
                            strHDDSmartInfo += "    Firmware:";
                            strHDDSmartInfo += GetDefaultString(HDDSmartInfo.szFirmware);
                            strHDDSmartInfo += "    CheckResult:";
                            strHDDSmartInfo += HDDSmartInfo.bCheckResult;
                            strHDDSmartInfo += "    CheckPrograss:";
                            strHDDSmartInfo += HDDSmartInfo.udwCheckPrograss;
                            strHDDSmartInfo += "    CheckStatus:";
                            strHDDSmartInfo += HDDSmartInfo.udwCheckStatus;
                            strHDDSmartInfo += "    CheckType:";
                            strHDDSmartInfo += HDDSmartInfo.udwCheckType;
                            strHDDSmartInfo += "\n";
                            for (Int32 i = 0; i < HDDSmartInfo.udwSmartNum; i++)
                            {
                                strHDDSmartInfo += "    AttributeID:";
                                strHDDSmartInfo += HDDSmartInfo.SmartDetailsInfoList[i].udwAttributeID;
                                strHDDSmartInfo += "    AttributeName:";
                                strHDDSmartInfo += GetDefaultString(HDDSmartInfo.SmartDetailsInfoList[i].szAttributeName);
                                strHDDSmartInfo += "    Status:";
                                strHDDSmartInfo += HDDSmartInfo.SmartDetailsInfoList[i].udwStatus;
                                strHDDSmartInfo += "    Hex:";
                                strHDDSmartInfo += HDDSmartInfo.SmartDetailsInfoList[i].udwHex;
                                strHDDSmartInfo += "    Thresh:";
                                strHDDSmartInfo += HDDSmartInfo.SmartDetailsInfoList[i].udwThresh;
                                strHDDSmartInfo += "    CurrentValue:";
                                strHDDSmartInfo += HDDSmartInfo.SmartDetailsInfoList[i].udwCurrentValue;
                                strHDDSmartInfo += "    WorstValue:";
                                strHDDSmartInfo += HDDSmartInfo.SmartDetailsInfoList[i].udwWorstValue;
                                strHDDSmartInfo += "    ActualValue:";
                                strHDDSmartInfo += HDDSmartInfo.SmartDetailsInfoList[i].udwActualValue;
                                strHDDSmartInfo += "\n";
                            }
                            MessageBox.Show(strHDDSmartInfo);
                        }
                    }
                }
            }
        }
    }
}
