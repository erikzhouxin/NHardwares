using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.YuShiNetDevSDK;

namespace YuShiNetDevSDK.WinForm
{
    public partial class PTZExtend : Form
    {
        static INetDevSdkProxy NETDEVSDK = NetDevSdk.Create();
        PTZControl m_oPtzControl = null;
        NetDemo m_oNetDemo = null;
        IntPtr m_lpDevHandle = IntPtr.Zero;
        int m_iChannelID = -1;
        GeneralDef.PlayPanel m_curRealPlayPanel = null;
        Int32 m_curSelectedTreeDeviceIndex = -1;
        Int32 m_curSelectedTreeChannelIndex = -1;
        List<NETDEMO_DeviceInfo> m_deviceInfoList = null;

        public PTZExtend(NetDemo netDemo)
        {
            this.m_oNetDemo = netDemo;
            m_deviceInfoList = netDemo.getDeviceInfoList();
            m_lpDevHandle = m_deviceInfoList[netDemo.getCurRealPanel().m_deviceIndex].m_lpDevHandle;
            m_iChannelID = netDemo.getCurRealPanel().m_channelID;
            m_curRealPlayPanel = netDemo.getCurRealPanel();
            m_curSelectedTreeDeviceIndex = netDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex;
            m_curSelectedTreeChannelIndex = netDemo.getChannelIndex();

            InitializeComponent();
            m_oPtzControl = new PTZControl();
        }

        private void WiperOnBtn_Click(object sender, EventArgs e)
        {
            m_oPtzControl.control_Other(m_lpDevHandle, m_iChannelID, (int)NETDEV_PTZ_E.NETDEV_PTZ_BRUSHON);
        }

        private void WiperOffBtn_Click(object sender, EventArgs e)
        {
            m_oPtzControl.control_Other(m_lpDevHandle, m_iChannelID, (int)NETDEV_PTZ_E.NETDEV_PTZ_BRUSHOFF);
        }

        private void HeaterOnBtn_Click(object sender, EventArgs e)
        {
            m_oPtzControl.control_Other(m_lpDevHandle, m_iChannelID, (int)NETDEV_PTZ_E.NETDEV_PTZ_HEATON);
        }

        private void HeaterOffBtn_Click(object sender, EventArgs e)
        {
            m_oPtzControl.control_Other(m_lpDevHandle, m_iChannelID, (int)NETDEV_PTZ_E.NETDEV_PTZ_HEATOFF);
        }

        private void LightOnBtn_Click(object sender, EventArgs e)
        {
            m_oPtzControl.control_Other(m_lpDevHandle, m_iChannelID, (int)NETDEV_PTZ_E.NETDEV_PTZ_LIGHTON);
        }

        private void LightOffBtn_Click(object sender, EventArgs e)
        {
            m_oPtzControl.control_Other(m_lpDevHandle, m_iChannelID, (int)NETDEV_PTZ_E.NETDEV_PTZ_LIGHTOFF);
        }

        private void SnowRemovalOnBtn_Click(object sender, EventArgs e)
        {
            m_oPtzControl.control_Other(m_lpDevHandle, m_iChannelID, (int)NETDEV_PTZ_E.NETDEV_PTZ_SNOWREMOINGON);
        }

        private void SnowRemovalOffBtn_Click(object sender, EventArgs e)
        {
            m_oPtzControl.control_Other(m_lpDevHandle, m_iChannelID, (int)NETDEV_PTZ_E.NETDEV_PTZ_SNOWREMOINGOFF);
        }

        private void GetRoutePatrolsBtn_Click(object sender, EventArgs e)
        {
            NETDEV_PTZ_TRACK_INFO_S stTrackCruiseInfo = new NETDEV_PTZ_TRACK_INFO_S();

            Int32 iRet = NETDEVSDK.NETDEV_PTZGetTrackCruise(m_lpDevHandle, m_iChannelID, ref stTrackCruiseInfo);
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Get Route fail", NETDEVSDK.NETDEV_GetLastError());
                return;
            }

            m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Get Route");
            this.routePatrolsNameText.Text = stTrackCruiseInfo.TrackName;
            return;
        }

        private void RunRoutePatrolsBtn_Click(object sender, EventArgs e)
        {
            NETDEV_PTZ_TRACK_INFO_S stTrackCruiseInfo = new NETDEV_PTZ_TRACK_INFO_S();

            Int32 iRet = NETDEVSDK.NETDEV_PTZGetTrackCruise(m_lpDevHandle, m_iChannelID, ref stTrackCruiseInfo);
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Get Route", NETDEVSDK.NETDEV_GetLastError());
                return;
            }

            m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Get Route");

            iRet = NETDEVSDK.NETDEV_PTZTrackCruise(m_lpDevHandle, m_iChannelID, (int)NETDEV_PTZ_E.NETDEV_PTZ_TRACKCRUISE, stTrackCruiseInfo.TrackName);
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Start Route patrol", NETDEVSDK.NETDEV_GetLastError());
            }
            else
            {
                this.m_curRealPlayPanel.m_trackStatus = true;
                m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Start Route patrol");
            }

            return;
        }

        private void StopPatrolsBtn_Click(object sender, EventArgs e)
        {
            if (false == this.m_curRealPlayPanel.m_trackStatus)
            {
                MessageBox.Show("Connot Tracking","warning");
                return;
            }

            NETDEV_PTZ_TRACK_INFO_S stTrackCruiseInfo = new NETDEV_PTZ_TRACK_INFO_S();

            int iRet = NETDEVSDK.NETDEV_PTZGetTrackCruise(m_lpDevHandle, m_iChannelID, ref stTrackCruiseInfo);
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Get Route", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Get Route");

            iRet = NETDEVSDK.NETDEV_PTZTrackCruise(m_lpDevHandle, m_iChannelID, (int)NETDEV_PTZ_E.NETDEV_PTZ_TRACKCRUISESTOP, stTrackCruiseInfo.TrackName);
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Stop Route patrol fail", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            else
            {
                this.m_curRealPlayPanel.m_trackStatus = false;
                m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Stop Route patrol");
            }

            return;
        }

        private void RecordStartBtn_Click(object sender, EventArgs e)
        {
            NETDEV_PTZ_TRACK_INFO_S stTrackCruiseInfo = new NETDEV_PTZ_TRACK_INFO_S();
            int iRet = NETDEVSDK.NETDEV_PTZGetTrackCruise(m_lpDevHandle, m_iChannelID, ref stTrackCruiseInfo);
            if (NetDevSdk.TRUE != iRet)
            {
                /* Get error codes */
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Get Route", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Get Route");

            if (0 == stTrackCruiseInfo.dwTrackNum)
            {
                /* Use PTZ to record route */
                iRet = NETDEVSDK.NETDEV_PTZTrackCruise(m_lpDevHandle, m_iChannelID, (int)NETDEV_PTZ_E.NETDEV_PTZ_TRACKCRUISEADD, stTrackCruiseInfo.TrackName);
                if (NetDevSdk.TRUE != iRet)
                {
                    m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Creat Route", NETDEVSDK.NETDEV_GetLastError());
                    return;
                }
                m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Creat Route");

                stTrackCruiseInfo.dwTrackNum++;
            }

            iRet = NETDEVSDK.NETDEV_PTZTrackCruise(m_lpDevHandle, m_iChannelID, (int)NETDEV_PTZ_E.NETDEV_PTZ_TRACKCRUISEREC, stTrackCruiseInfo.TrackName);
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Start Recording Route", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Start Recording Route");

            return;
        }

        private void RecordEndBtn_Click(object sender, EventArgs e)
        {
            NETDEV_PTZ_TRACK_INFO_S stTrackCruiseInfo = new NETDEV_PTZ_TRACK_INFO_S();

            int iRet = NETDEVSDK.NETDEV_PTZGetTrackCruise(m_lpDevHandle, m_iChannelID, ref stTrackCruiseInfo);
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Get Route", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Get Route");

            iRet = NETDEVSDK.NETDEV_PTZTrackCruise(m_lpDevHandle, m_iChannelID, (int)NETDEV_PTZ_E.NETDEV_PTZ_TRACKCRUISERECSTOP, stTrackCruiseInfo.TrackName);
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Stop Recording Route", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Stop Recording Route");

            return;
        }

        private void presetPatrolsAddBtn_Click(object sender, EventArgs e)
        {
            if (((m_curSelectedTreeChannelIndex + 1) <= 0) || (m_curSelectedTreeDeviceIndex < 0))
            {
                MessageBox.Show("Please select device","warning");
                return;
            }

            String strPreSetID = (String)this.PresetIDcobBox.SelectedItem;
            String strStayTime = this.StayTimeText.Text;

            int strSpeed = -1;
            try
            {
                strSpeed = Convert.ToInt32(this.SpeedText.Text);
            }
            catch (FormatException)
            {
                return;
            }

            if ("" == strStayTime || (strSpeed > 40 || strSpeed < 0))
            {
                MessageBox.Show("Invalid staytime or speed","warning");
                return;
            }

            Int32 dwCount = this.cruiseListView.Items.Count;
            if ((NetDevSdk.NETDEV_MAX_CRUISEPOINT_NUM <= dwCount))
            {
                MessageBox.Show("No more cruise point available","warning");
                return;
            }

            ListViewItem item = new ListViewItem(strPreSetID);
            item.SubItems.Add(strStayTime);
            item.SubItems.Add(Convert.ToString(strSpeed));
            this.cruiseListView.Items.Add(item);
            item.EnsureVisible();

            return;
        }

        private void presetPatrolsModifyBtn_Click(object sender, EventArgs e)
        {
            String strPreSetID = (String)this.PresetIDcobBox.SelectedItem;
            String strStayTime = this.StayTimeText.Text;

            int Speed = -1;
            try
            {
                Speed = Convert.ToInt32(this.SpeedText.Text);
            }
            catch (FormatException)
            {
                return;
            }

            if ("" == strStayTime || (Speed > 40 || Speed < 0))
            {
                MessageBox.Show("Invalid staytime or speed","warning");
                return;
            }

            if (this.cruiseListView.SelectedItems.Count > 0)
            {
                ((ListViewItem)this.cruiseListView.SelectedItems[0]).SubItems[0].Text = strPreSetID;
                ((ListViewItem)this.cruiseListView.SelectedItems[0]).SubItems[1].Text = strStayTime;
                ((ListViewItem)this.cruiseListView.SelectedItems[0]).SubItems[2].Text = Convert.ToString(Speed);
            }
            return;
        }

        private void PresetDeleteBtn_Click(object sender, EventArgs e)
        {
            if (this.cruiseListView.SelectedItems.Count > 0)
            {
                cruiseListView.Items.Remove((ListViewItem)this.cruiseListView.SelectedItems[0]);
            }
        }

        private void presetPatrolsRefreshBtn_Click(object sender, EventArgs e)
        {
            NETDEV_CRUISE_LIST_S stCuriseList = new NETDEV_CRUISE_LIST_S();

            Int32 iRet = NETDEVSDK.NETDEV_PTZGetCruise(m_lpDevHandle, m_iChannelID, ref stCuriseList);
            if (NetDevSdk.TRUE != iRet)
            {
                this.cruiseListView.Items.Clear();
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Get cruise", NETDEVSDK.NETDEV_GetLastError());
            }
            else
            {
                m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Get cruise");
                this.m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_channelInfoList[m_curSelectedTreeChannelIndex].m_CruiseInfoList = stCuriseList;
            }

            m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_channelInfoList[m_curSelectedTreeChannelIndex].m_CruiseInfoList = stCuriseList;

            PresetPatrolsIDCobBox_SelectedIndexChanged(null,null);
            GetPresetID();
        }

        private void GetPresetID()
        {
            PresetIDcobBox.Items.Clear();
            NETDEV_PTZ_ALLPRESETS_S stPtzPresets = new NETDEV_PTZ_ALLPRESETS_S();

            int iRet = NETDEVSDK.NETDEV_GetPTZPresetList(m_lpDevHandle, m_iChannelID, ref stPtzPresets);
            if(NetDevSdk.TRUE != iRet)
            {
                if (NetDevSdk.NETDEV_E_NO_RESULT == NETDEVSDK.NETDEV_GetLastError())
                {
                    m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Preset list is emtpy.", NETDEVSDK.NETDEV_GetLastError());
                    return;
                }

                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Get presets", NETDEVSDK.NETDEV_GetLastError());
            }
            else
            {
                m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Get presets");
                for(Int32 i = 0; i < stPtzPresets.dwSize; i++)
                {
                    PresetIDcobBox.Items.Add(Convert.ToString(stPtzPresets.astPreset[i].dwPresetID));
                }

                PresetIDcobBox.SelectedIndex = 0;

                PresetNameText.Text = GetDefaultString(stPtzPresets.astPreset[0].szPresetName);
            }

            return;
        }

        private void PresetPatrolsIDCobBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nSplit = PresetPatrolsIDCobBox.SelectedIndex;

            if (( m_iChannelID <= 0 )|| (m_curSelectedTreeChannelIndex < 0 ))
            {
                MessageBox.Show("Please select device","warning");
                return;
            }
            this.cruiseListView.Items.Clear();

            NETDEMO_DeviceInfo deviceInfo = m_deviceInfoList[m_curSelectedTreeDeviceIndex];
            if ((int)NETDEV_DEVICETYPE_E.NETDEV_DTYPE_IPC == deviceInfo.m_stDevInfo.dwDevType ||
                (int)NETDEV_DEVICETYPE_E.NETDEV_DTYPE_IPC_FISHEYE == deviceInfo.m_stDevInfo.dwDevType ||
                (int)NETDEV_DEVICETYPE_E.NETDEV_DTYPE_IPC_ECONOMIC_FISHEYE == deviceInfo.m_stDevInfo.dwDevType)
            {
                nSplit += 1;
            }

            NETDEMO_ChannelInfo channelInfo = deviceInfo.m_channelInfoList[m_curSelectedTreeChannelIndex];

            if (channelInfo.m_CruiseInfoList.dwSize <= 0)
            {
                this.PresetPatrolsNameText.Text = "";
            }

            for (Int32 i = 0; i < channelInfo.m_CruiseInfoList.dwSize; i++)
            {
                if (channelInfo.m_CruiseInfoList.astCruiseInfo[i].dwCuriseID == nSplit)
                {
                    NETDEV_CRUISE_INFO_S strCruiseInfo = channelInfo.m_CruiseInfoList.astCruiseInfo[i];
                    this.PresetPatrolsNameText.Text = strCruiseInfo.szCuriseName;
                    for (Int32 j = 0; j < strCruiseInfo.dwSize; j++)
                    {
                        ListViewItem item = new ListViewItem(Convert.ToString(strCruiseInfo.astCruisePoint[j].dwPresetID));
                        item.SubItems.Add(Convert.ToString(strCruiseInfo.astCruisePoint[j].dwStayTime/1000));
                        item.SubItems.Add(Convert.ToString(strCruiseInfo.astCruisePoint[j].dwSpeed));
                        cruiseListView.Items.Add(item);
                    }
                    break;
                }
                else
                {
                    this.PresetPatrolsNameText.Text = "";
                }
            }

            return;
        }

        private void PresetIDcobBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            NETDEV_PTZ_ALLPRESETS_S stPtzPresets = new NETDEV_PTZ_ALLPRESETS_S();

            int iRet = NETDEVSDK.NETDEV_GetPTZPresetList(m_lpDevHandle, m_iChannelID, ref stPtzPresets);
            if (NetDevSdk.TRUE != iRet)
            {
                if (NetDevSdk.NETDEV_E_NO_RESULT == NETDEVSDK.NETDEV_GetLastError())
                {
                    m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Presets list is emtpy.", NETDEVSDK.NETDEV_GetLastError());
                    return;
                }

                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Get presets", NETDEVSDK.NETDEV_GetLastError());
            }
            else
            {
                m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Get presets");

                String strPreSetID = (string)PresetIDcobBox.SelectedItem;
                for (Int32 i = 0; i < stPtzPresets.dwSize; i++)
                {
                    if (stPtzPresets.astPreset[i].dwPresetID == Convert.ToInt32(strPreSetID))
                    {
                        PresetNameText.Text = GetDefaultString(stPtzPresets.astPreset[i].szPresetName);
                        return;
                    }
                }
            }

            return;
        }

        private void presetPatrolsStartBtn_Click(object sender, EventArgs e)
        {
            bool iRet = handleCruise(NETDEV_PTZ_CRUISECMD_E.NETDEV_PTZ_RUN_CRUISE);
            if (true != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Start cruise", NETDEVSDK.NETDEV_GetLastError());
            }
            else
            {
                m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Start cruise"); 
            }
        }

        private void PresetPatrolsStopBtn_Click(object sender, EventArgs e)
        {
            bool iRet = handleCruise(NETDEV_PTZ_CRUISECMD_E.NETDEV_PTZ_STOP_CRUISE);
            if (true != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Stop cruise", NETDEVSDK.NETDEV_GetLastError());
            }
            else
            {
                m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Stop cruise"); 
            }
        }

        private void PresetPatrolsSaveBtn_Click(object sender, EventArgs e)
        {
            String StrCruiseName = PresetPatrolsNameText.Text;
            if ("" == StrCruiseName)
            {
                MessageBox.Show("Please entry cruise name","warning");
                return;
            }

            if (( m_curSelectedTreeChannelIndex < 0 )|| (m_curSelectedTreeDeviceIndex < 0 ))
            {
                MessageBox.Show("Please select Device","warning");
                return;
            }
            
            if(PresetPatrolsIDCobBox.SelectedIndex >= 0)
            {
                NETDEMO_ChannelInfo channelInfo = m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_channelInfoList[m_curSelectedTreeChannelIndex];
                NETDEV_CRUISE_INFO_S strCruiseInfo = channelInfo.m_CruiseInfoList.astCruiseInfo[PresetPatrolsIDCobBox.SelectedIndex];
                strCruiseInfo.dwCuriseID = PresetPatrolsIDCobBox.SelectedIndex + 1;
                strCruiseInfo.szCuriseName = StrCruiseName;

                Int32 dwSize = strCruiseInfo.dwSize;
                strCruiseInfo.dwSize = cruiseListView.Items.Count;

                if (strCruiseInfo.dwSize <= 0)
                {
                    MessageBox.Show("Please add one item","warning");
                    return;
                }

                for (Int32 i = 0; i < strCruiseInfo.dwSize; i++)
                {
                    strCruiseInfo.astCruisePoint[i].dwPresetID = Convert.ToInt32(cruiseListView.Items[i].SubItems[0].Text);
                    strCruiseInfo.astCruisePoint[i].dwStayTime = Convert.ToInt32(cruiseListView.Items[i].SubItems[1].Text) * 1000;
                    strCruiseInfo.astCruisePoint[i].dwSpeed = Convert.ToInt32(cruiseListView.Items[i].SubItems[2].Text);
                }

                if (dwSize > 0)
                {
                    int iRet = NETDEVSDK.NETDEV_PTZCruise_Other(m_lpDevHandle, m_iChannelID, (int)NETDEV_PTZ_CRUISECMD_E.NETDEV_PTZ_MODIFY_CRUISE, ref strCruiseInfo);
                    if (NetDevSdk.TRUE != iRet)
                    {
                        m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Modify cruise", NETDEVSDK.NETDEV_GetLastError());
                    }
                    else
                    {
                        m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Modify cruise");                        
                    }
                }
                else
                {
                    int iRet = NETDEVSDK.NETDEV_PTZCruise_Other(m_lpDevHandle, m_iChannelID, (int)NETDEV_PTZ_CRUISECMD_E.NETDEV_PTZ_ADD_CRUISE, ref strCruiseInfo);
                    if (NetDevSdk.TRUE != iRet)
                    {
                        m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Add cruise", NETDEVSDK.NETDEV_GetLastError());
                    }
                    else
                    {
                        m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_ip + " chl:" + (m_curSelectedTreeChannelIndex + 1), "Add cruise");                        
                    }
                }

                presetPatrolsRefreshBtn_Click(null,null);
            }

            

            return;
        }

        private void PresetPatrolsDeleteBtn_Click(object sender, EventArgs e)
        {
            bool iRet = handleCruise(NETDEV_PTZ_CRUISECMD_E.NETDEV_PTZ_DEL_CRUISE);
            if(true != iRet)
            {
                return;
            }

            if (( m_curSelectedTreeChannelIndex < 0 )|| (m_curSelectedTreeDeviceIndex < 0 ))
            {
                MessageBox.Show("Please select a device","warning");
                return;
            }

            if(PresetPatrolsIDCobBox.SelectedIndex >= 0)
            {
                NETDEMO_ChannelInfo channelInfo = m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_channelInfoList[m_curSelectedTreeChannelIndex];
                channelInfo.m_CruiseInfoList.astCruiseInfo[PresetPatrolsIDCobBox.SelectedIndex].astCruisePoint = new NETDEV_CRUISE_POINT_S[NetDevSdk.NETDEV_MAX_CRUISEPOINT_NUM];

                channelInfo.m_CruiseInfoList.astCruiseInfo[PresetPatrolsIDCobBox.SelectedIndex].dwCuriseID = 0;
                channelInfo.m_CruiseInfoList.astCruiseInfo[PresetPatrolsIDCobBox.SelectedIndex].dwSize = 0;
                channelInfo.m_CruiseInfoList.astCruiseInfo[PresetPatrolsIDCobBox.SelectedIndex].szCuriseName = "";

                PresetPatrolsIDCobBox.SelectedIndex = 0;
                PresetPatrolsIDCobBox_SelectedIndexChanged(null,null);
            }
        }

        bool handleCruise(NETDEV_PTZ_CRUISECMD_E eCruisecmd)
        {
            if (( m_curSelectedTreeChannelIndex < 0 )|| (m_curSelectedTreeDeviceIndex < 0 ))
            {
                MessageBox.Show("Please select device","warning");
                return false;
            }

            if(PresetPatrolsIDCobBox.SelectedIndex >= 0)
            {
                NETDEMO_ChannelInfo channelInfo = m_deviceInfoList[m_curSelectedTreeDeviceIndex].m_channelInfoList[m_curSelectedTreeChannelIndex];
                NETDEV_CRUISE_INFO_S strCruiseInfo = channelInfo.m_CruiseInfoList.astCruiseInfo[PresetPatrolsIDCobBox.SelectedIndex];

                int ret = NETDEVSDK.NETDEV_PTZCruise_Other(m_lpDevHandle, m_iChannelID, (int)eCruisecmd, ref strCruiseInfo);
                if (NetDevSdk.TRUE == ret)
                {
                    return true;
                }
            }

            return false;
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

    }
}
