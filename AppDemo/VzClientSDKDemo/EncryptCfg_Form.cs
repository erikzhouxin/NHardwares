using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace VzClientSDKDemo
{
    public partial class EncryptCfg_Form : Form
    {
        private int m_hLPRClient = 0;

        public EncryptCfg_Form()
        {
            InitializeComponent();
        }

        public void SetLPRHandle(int hLPRClient)
        {
            m_hLPRClient = hLPRClient;
        }

        //添加加密方式
        private void LoadEncryptCfg()
        {
            if (m_hLPRClient > 0)
            {
                VzClientSDK.VZ_LPRC_ACTIVE_ENCRYPT data = new VzClientSDK.VZ_LPRC_ACTIVE_ENCRYPT();
                int ret = VzClientSDK.VzLPRClient_GetEMS(m_hLPRClient,ref data);//获取加密的信息

                if (data.uSize > 0)
                {
                    for (int i = 0; i < data.uSize; i++)
                    {
                        comboBox1.Items.Add(data.oEncrpty[i].sName.ToString());//向下拉框添加加密方式
                    }

                    comboBox1.Text = data.oEncrpty[data.uActiveID].sName.ToString(); //显示当前的加密方式               
                }
            }

            radioBtnUserWord.Checked = true;//默认选中"用户密码"按钮

        }
        
        private void EncryptCfg_Form_Load(object sender, EventArgs e)
        {

            LoadEncryptCfg();

        }
        //保存加密方式
        private void btnEncryptSave_Click(object sender, EventArgs e)
        {
            UInt32 nCurSel = (UInt32)comboBox1.SelectedIndex;

            //无密码
            if (textBoxUserword.TextLength == 0)
            {
                MessageBox.Show("请输入用户密码!","提示");
                return;
            }

            IntPtr PtrUserword = Marshal.StringToHGlobalAnsi(textBoxUserword.Text);//将textBox转化为IntPtr型
            int value = VzClientSDK.VzLPRClient_SetEncrypt(m_hLPRClient,PtrUserword,nCurSel);//设置加密方式
            if (value != 0)
            {
                MessageBox.Show("设置加密方式失败，请检查密码是否正确!","提示");

                Marshal.FreeHGlobal(PtrUserword);
                return;
            }

            MessageBox.Show("设置加密方式成功！","提示");
            return;
        }

        //密码校验
        private int PasswordCheck(string strNewWord, string strConfirmWord)
        {
            if (strNewWord.Length == 0)
            {
                MessageBox.Show("请输入新密码!", "提示");
                return -1;
            }

            if (strConfirmWord.Length == 0)
            {
                MessageBox.Show("请输入确认密码!", "提示");
                return -1;
            }

            if (strNewWord != strConfirmWord)
            {
                MessageBox.Show("两次输入密码不一致，请重新输入!", "提示");
                return -1;
            }
            return 0;
        }

        //保存修改密码
        private void btnChangeWordSave_Click(object sender, EventArgs e)
        {     
            IntPtr PtrUserPwd = Marshal.StringToHGlobalAnsi(textBoxUserword2.Text);
            IntPtr PtrNewPwd = Marshal.StringToHGlobalAnsi(textBoxNewWord.Text);

            //修改用户密码
            int value = -1;

            do 
            {

                if (radioBtnUserWord.Checked)
                {
                    if (textBoxUserword2.TextLength == 0)
                    {
                        MessageBox.Show("请输入用户密码！", "提示");
                       break;
                    }

                    //输入密码检查
                    int retUser = PasswordCheck(textBoxNewWord.Text, textBoxConfirmWord.Text);
                    if (retUser != 0)
                    {
                        break;
                    }

                    //修改密码
                    value = VzClientSDK.VzLPRClient_ChangeEncryptKey(m_hLPRClient, PtrUserPwd, PtrNewPwd);

                }
                //修改主密码
                else
                {
                    if (textBoxUserword2.TextLength == 0)
                    {
                        MessageBox.Show("请输入主密码！", "提示");
                        break;
                    }

                    //输入密码检查
                    int retKey = PasswordCheck(textBoxNewWord.Text, textBoxConfirmWord.Text);
                    if (retKey != 0)
                    {
                        break;
                    }

                    //重置密码
                    value = VzClientSDK.VzLPRClient_ResetEncryptKey(m_hLPRClient, PtrUserPwd, PtrNewPwd);
                }

                if (value != 0)
                {
                    MessageBox.Show("设置密码失败!", "提示");
                    break;
                }

                MessageBox.Show("设置密码成功！", "提示");
            } while (false);

            
            //释放内存
            Marshal.FreeHGlobal(PtrUserPwd);
            Marshal.FreeHGlobal(PtrNewPwd);

            if (value == 0)
            {
                this.Close();
            }
           
        }

        //选择"用户密码"按钮
        private void radioBtnUserWord_CheckedChanged(object sender, EventArgs e)
        {
            labelUserWord.Text = "用户密码:";
            textBoxUserword2.Text = "";
            textBoxNewWord.Text = "";
            textBoxConfirmWord.Text = "";
        }

        //选择"主密码"按钮
        private void radioBtnKeyWord_CheckedChanged(object sender, EventArgs e)
        {
            labelUserWord.Text = "主 密 码:";
            textBoxUserword2.Text = "";
            textBoxNewWord.Text = "";
            textBoxConfirmWord.Text = "";
        }

        //取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
