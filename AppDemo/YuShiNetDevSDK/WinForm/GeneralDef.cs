using System;
using System.Collections.Generic;
using System.Data.YuShiNetDevSDK;
using System.Drawing;
using System.Runtime.InteropServices;

namespace GeneralDef
{
    public class PlayPanel : PanelEx
    {
        public int m_panelIndex = -1;
        public int m_deviceIndex = -1;
        public int m_channelID = -1;
        public bool m_playStatus = false;/*播放状态，默认未播放*/
        public bool m_recordStatus = false;/*luxiang*/
        public IntPtr m_playhandle = IntPtr.Zero;/*播放句柄*/

        /*playBack use*/
        public int m_curVideoSliderValue = 0;
        public int m_maxVideoSliderValue = 0;
        public long m_startTime = 0;
        public long m_endTime = 0;
        public int m_playSpeed = (int)NETDEV_VOD_PLAY_STATUS_E.NETDEV_PLAY_STATUS_1_FORWARD;
        public bool m_pauseStatus = true;/*暂停状态，默认暂停*/

        public bool m_trackStatus = false;/*巡航状态*/

        /*3D Position and Digital Zoom*/
        public int rectStartX = 0;
        public int rectStartY = 0;
        public int rectEndX = 0;
        public int rectEndY = 0;

        /*Two-way Audio*/
        public IntPtr m_talkHandle = IntPtr.Zero;

        public bool m_bShortDelayFlag = true;
        public bool m_bFluentFlag = false;
        public bool m_bDigitalZoomFlag = false;
        public bool m_bFirstZoomFlag = true;
        public bool m_3DPositionFlag = false;
        public bool m_twoWayAudioFlag = false;

        public int m_volume = 0;
        public bool m_soundStatus = false;
        public int m_micVolume = 0;
        public bool m_micStatus = false;

        public void initPlayPanel()
        {
            m_channelID = -1;
            m_deviceIndex = -1;
            m_playStatus = false;
            m_playhandle = IntPtr.Zero;
            m_recordStatus = false;

            m_curVideoSliderValue = 0;
            m_maxVideoSliderValue = 0;
            m_playSpeed = (int)NETDEV_VOD_PLAY_STATUS_E.NETDEV_PLAY_STATUS_1_FORWARD; ;
            m_startTime = 0;
            m_endTime = 0;
            m_pauseStatus = true;

            this.BackColor = Color.Black;
            //this.setBorderColor(Color.Red, 2);

            rectStartX = 0;
            rectStartY = 0;
            rectEndX = 0;
            rectEndY = 0;

            m_talkHandle = IntPtr.Zero;

            m_bShortDelayFlag = true;
            m_bFluentFlag = false;
            m_bDigitalZoomFlag = false;
            m_3DPositionFlag = false;
            m_twoWayAudioFlag = false;

            m_volume = 0;
            m_soundStatus = false;
            m_micVolume = 0;
            m_micStatus = false;

            this.Invalidate();
        }
    }
}