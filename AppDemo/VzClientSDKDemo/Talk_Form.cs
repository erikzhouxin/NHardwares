using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;   

namespace VzClientSDKDemo
{
    public partial class Talk_Form : Form
    {
        public class DeviceVoice
        {
            public   int handle;
            public   String ip;
            public   bool talking;
            public bool recording;
            public TreeNode node;
            public bool calling;
            public long callingtime;    //呼叫时间，单位:s
        };
        Dictionary<String, int> m_deviceInfo=null;
        public int m_talkHandle=0;
        public DeviceVoice m_currentVoice=null;
        public SoundPlayer sound = null;
        private VzClientSDK.VZLPRC_REQUEST_TALK_CALLBACK talk_requstCB = null;
        public static int CALLING_TIME = 10;    //单位:s
        public static int playNum = 0;
        public Talk_Form()
        {
            InitializeComponent();
        }

        private void Talk_Form_Load(object sender, EventArgs e)
        {
            sound = new SoundPlayer(Application.StartupPath+"\\testring.wav");
            timer_call.Start();
            EnableControl(false);
            
        }
        public  void  REQUEST_TALK_CALLBACK(int handle, int state, string error_msg, IntPtr pUserData)
        {
            DeviceVoice dv = GetDeviceVoice(handle);
            if (dv != null)
            {
                dv.calling = true;
                dv.callingtime = Environment.TickCount;
            }

        }
        private DeviceVoice GetDeviceVoice(int handle)
        {
            DeviceVoice dv=null;
             TreeNode node;
            int rowcount = treeView_Talk.Nodes.Count;
            for (int i = 0; i < rowcount; i++)
            {
              node  = treeView_Talk.Nodes[i];

              DeviceVoice item = (DeviceVoice)node.Tag;
              if ((item != null) && (item.handle == handle))
              { 
                  dv = item;
                  break;
               }
            }
            return dv;
        }
        public void SetDeviceInfo(Dictionary<String, int> deviceInfo)
        {
            talk_requstCB = new VzClientSDK.VZLPRC_REQUEST_TALK_CALLBACK(REQUEST_TALK_CALLBACK);

            m_deviceInfo = deviceInfo;
            TreeNode node = null;
            for (int i = 0; i < m_deviceInfo.Count; i++)
            {
                var item = m_deviceInfo.ElementAt(i);

                node = new TreeNode(item.Key);
                DeviceVoice dv = new DeviceVoice();
                dv.handle = item.Value;
                dv.ip = item.Key;
                dv.calling = false;
                dv.talking = false;
                dv.recording = false;
                dv.node = node;
                node.Tag = dv;

                treeView_Talk.Nodes.Add(node);

                VzClientSDK.VzLPRClient_SetRequestTalkCallBack(dv.handle, talk_requstCB, IntPtr.Zero);
            }
            treeView_Talk.SelectedNode = node;
 
        }

        private void button_TalkRecive_Click(object sender, EventArgs e)
        {
             TreeNode node = treeView_Talk.SelectedNode;
             if (node == null)
             {
                 MessageBox.Show("请先选中一个设备");
                 return;
             }

             DeviceVoice dv = (DeviceVoice)node.Tag;
               
            if(dv != null)
            {
                m_talkHandle = dv.handle;
                int ret = VzClientSDK.VzLPRClient_StartTalk(m_talkHandle, 640);

                if (ret == -2)
                {
                    m_talkHandle = 0;
                    MessageBox.Show("开始通话失败");
                    return;
                }
                else
                {
                    node.Text = dv.ip + "  通话中";
                    m_currentVoice = dv;
                    m_currentVoice.node = node;
                    m_currentVoice.talking = true;
                    EnableControl(true);
                }
            }
            
        }

        private void button_TalkClose_Click(object sender, EventArgs e)
        {
            if (m_talkHandle == 0)
            {
                MessageBox.Show("请先选中一个设备");
                return;
            }

            int ret = VzClientSDK.VzLPRClient_StopTalk(m_talkHandle);
            

            if (m_currentVoice.node != null)
            { 
                m_currentVoice.node.Text = m_currentVoice.ip;
            }
            if (m_currentVoice.recording)
            {
                VzClientSDK.VzLPRClient_StopRecordAudio(m_talkHandle);
                m_currentVoice.recording = false;
                button_Record.Text = "开始录音";
            }
            m_currentVoice.node = null;
            m_currentVoice.talking = false;
            m_currentVoice.calling = false;
            m_currentVoice = null;
            m_talkHandle = 0;
            EnableControl(false);

        }

        private void button_Record_Click(object sender, EventArgs e)
        {
            if (m_talkHandle == 0)
            {
                MessageBox.Show("请先选中一个设备");
                return;
            }

            if (button_Record.Text == "开始录音")
            {
                VzClientSDK.VzLPRClient_StartRecordAudio(m_talkHandle, "./testrecord.wav");
                m_currentVoice.recording = true;
                button_Record.Text = "停止录音";
            }
            else
            {

                VzClientSDK.VzLPRClient_StopRecordAudio(m_talkHandle);
                m_currentVoice.recording = false;
                button_Record.Text = "开始录音";
            }
        }
        private void EnableControl(bool talking)
        {
            if (talking)
            {
                button_TalkRecive.Enabled=false;
                button_TalkClose.Enabled=true ;
                button_Record.Enabled = true ;
            }
            else
            {
                button_TalkRecive.Enabled = true ;
                button_TalkClose.Enabled = false ;
                button_Record.Enabled  = false ;
            }
        }
        private int GetCallingCount()
        {
            int callingcount = 0;
            TreeNode node;
            int rowcount = treeView_Talk.Nodes.Count;
            for (int i = 0; i < rowcount; i++)
            {
                node = treeView_Talk.Nodes[i];

                DeviceVoice item = (DeviceVoice)node.Tag;
                if ((item != null) && (item.calling) && (!item.talking))
                {
                    callingcount++;
                }
            }

            return callingcount;

        }
         private void UpdateCalingFlag()
        {
            int now = Environment.TickCount;
            TreeNode node;
            int rowcount = treeView_Talk.Nodes.Count;
            for (int i = 0; i < rowcount; i++)
            {
                node = treeView_Talk.Nodes[i];

                DeviceVoice item = (DeviceVoice)node.Tag;
                if ((item != null) )
                {
                    if ((((now - item.callingtime) / 1000) > CALLING_TIME))
                      item.calling = false;

                     if (!item.talking)
                    {
                        if (item.calling)
                        {
                            node.Text = item.ip + "  呼叫中";

                        }
                        else
                        {
                            node.Text = item.ip;
                        }

                    }
                }
                
            }
 
         }

        private void timer_call_Tick(object sender, EventArgs e)
        {
            int callingcount = GetCallingCount();

            if (callingcount > 0)
            {
                //3s播放一次
                if (playNum == 0)
                {
                    try
                    {
                        sound.Play();
                    }
                    catch (System.IO.FileNotFoundException exp)
                    {

                    }
                    
                }
                playNum++;
                if (playNum > 2)
                    playNum = 0;
            }
               
            UpdateCalingFlag();
        }

        private void Talk_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_talkHandle != 0)
            {

                VzClientSDK.VzLPRClient_StopTalk(m_talkHandle);


                if (m_currentVoice.node != null)
                {
                    m_currentVoice.node.Text = m_currentVoice.ip;
                }
                if (m_currentVoice.recording)
                {
                    VzClientSDK.VzLPRClient_StopRecordAudio(m_talkHandle);
                    m_currentVoice.recording = false;
                    button_Record.Text = "开始录音";
                }
                m_currentVoice.node = null;
                m_currentVoice.talking = false;
                m_currentVoice.calling = false;
                m_currentVoice = null;
                m_talkHandle = 0;
            }
           
        }
    }
}
