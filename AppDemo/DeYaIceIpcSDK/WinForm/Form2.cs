using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace TestDll
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public string m_strStorePath = "";
        public int m_bOpenGate = 0;
        public int m_bTrigger = 0;
        public int m_bOpenGate2 = 0;
        public int m_bRS485 = 0;
        public int m_bRS232 = 0;

        public int m_nOpenInterval = 0;
        public int m_nTriggerInterval = 0;
        public int m_nRecordInterval = 0;
        public int m_nOpenInterval2 = 0;
        public int m_nRS485Interval = 0;
        public int m_nRS232Interval = 0;

        public uint m_nVideoOsd = 0;
        public string m_nVideoColor = "000000";
        public uint m_bVideoDate = 0;
        public uint m_bVideoLicense = 0;
        public uint m_bVideoCustom = 0;
        public string m_strVideoCustom = "";
        public uint m_nJpegOsd = 0;
        public string m_nJpegColor = "000000";
        public uint m_bJpegDate = 0;
        public uint m_bJpegAlgo = 0;
        public uint m_bJpegCustom = 0;
        public string m_strJpegCustom = "";

        private int nMaxOsdText = 64;

        public string m_strLogPath = "";
        public int m_bEnableLog = 0;

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDlg = new FolderBrowserDialog();
            folderBrowserDlg.Description = "请选择保存输出图片的文件夹";
            folderBrowserDlg.ShowNewFolderButton = true;
            folderBrowserDlg.RootFolder = Environment.SpecialFolder.MyComputer;
            DialogResult result = folderBrowserDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDlg.SelectedPath;
                if (folderName != "")
                {
                    textBoxPath.Text = folderName;
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            m_strJpegCustom = "";
            m_strStorePath = "";
            m_strVideoCustom = "";
            m_strLogPath = "";

            m_strStorePath = textBoxPath.Text;
            m_strLogPath = textBox_logPath.Text;
            m_bEnableLog = Convert.ToInt32(checkBox_EnableLog.Checked);
            m_bOpenGate = Convert.ToInt32(checkBoxOpenGate.Checked);
            m_bTrigger = Convert.ToInt32(checkBoxTrigger.Checked);
            m_bOpenGate2 = Convert.ToInt32(checkBoxOpenGate2.Checked);
            m_bRS232 = Convert.ToInt32(checkBoxRS232.Checked);
            m_bRS485 = Convert.ToInt32(checkBoxRS485.Checked);

            if (textBoxIntervalOpen.Text == "")
                m_nOpenInterval = 0;
            else
                m_nOpenInterval = Convert.ToInt32(textBoxIntervalOpen.Text);

            if (textBoxIntervalTrigger.Text == "")
                m_nTriggerInterval = 0;
            else
                m_nTriggerInterval = Convert.ToInt32(textBoxIntervalTrigger.Text);

            if (textBoxRecordTime.Text == "")
                m_nRecordInterval = 0;
            else
                m_nRecordInterval = Convert.ToInt32(textBoxRecordTime.Text);

            if (textBoxIntervalOpen2.Text == "")
                m_nOpenInterval2 = 0;
            else
                m_nOpenInterval2 = Convert.ToInt32(textBoxIntervalOpen2.Text);

            if (textBoxIntervalRS485.Text == "")
                m_nRS485Interval = 0;
            else
                m_nRS485Interval = Convert.ToInt32(textBoxIntervalRS485.Text);

            if (textBoxIntervalRS232.Text == "")
                m_nRS232Interval = 0;
            else
                m_nRS232Interval = Convert.ToInt32(textBoxIntervalRS232.Text);

            m_nVideoOsd = Convert.ToUInt32(comboBoxVideoOSD.SelectedIndex);
            m_bVideoDate = Convert.ToUInt32(checkBoxVideoDate.Checked);
            m_bVideoLicense = Convert.ToUInt32(checkBoxVideoLicense.Checked);
            m_bVideoCustom = Convert.ToUInt32(checkBoxVideoCustom.Checked);
            m_strVideoCustom = textBoxVideoCustomInfo.Text;

            m_nJpegOsd = Convert.ToUInt32(comboBoxJpegOSD.SelectedIndex);
            m_bJpegDate = Convert.ToUInt32(checkBoxJpegDate.Checked);
            m_bJpegAlgo = Convert.ToUInt32(checkBoxJpegAlgo.Checked);
            m_bJpegCustom = Convert.ToUInt32(checkBoxJpegCustom.Checked);
            m_strJpegCustom = textBoxJpegCustomInfo.Text;

            

            try
            {
                //读取设置
                FileStream fs = new FileStream("param.dat", FileMode.OpenOrCreate, FileAccess.Write);
                if (fs != null)
                {
                    BinaryWriter bw = new BinaryWriter(fs);
                    if (bw != null)
                    {
                        bw.Write(m_strStorePath);
                        bw.Write(m_strLogPath);
                        bw.Write(m_bEnableLog);
                        bw.Write(m_bOpenGate);
                        bw.Write(m_bTrigger);
                        bw.Write(m_nOpenInterval);
                        bw.Write(m_nTriggerInterval);
                        bw.Write(m_nRecordInterval);

                        bw.Write(m_nVideoOsd);
                        bw.Write(m_nVideoColor);
                        bw.Write(m_bVideoDate);
                        bw.Write(m_bVideoLicense);
                        bw.Write(m_bVideoCustom);
                        bw.Write(m_strVideoCustom);

                        bw.Write(m_nJpegOsd);
                        bw.Write(m_nJpegColor);
                        bw.Write(m_bJpegDate);
                        bw.Write(m_bJpegAlgo);
                        bw.Write(m_bJpegCustom);
                        bw.Write(m_strJpegCustom);

                        bw.Write(m_bOpenGate2);
                        bw.Write(m_bRS485);
                        bw.Write(m_bRS232);
                        bw.Write(m_nOpenInterval2);
                        bw.Write(m_nRS485Interval);
                        bw.Write(m_nRS232Interval);

                        bw.Close();
                    }
                    fs.Close();
                }
            }
            catch (System.Exception ex)
            {

            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBoxVideoCustomInfo.MaxLength = 6 * (nMaxOsdText - 2);
            textBoxJpegCustomInfo.MaxLength = 6 * (nMaxOsdText - 2);

            string[] strOsd = new string[6] { "左上", "右上", "左下", "右下", "上居中", "下居中" };
            for (int i = 0; i < 6; i++)
            {
                comboBoxVideoOSD.Items.Add(strOsd[i]);
                comboBoxJpegOSD.Items.Add(strOsd[i]);
            } 

            if (File.Exists(@"./param.dat"))
            {
                FileStream fs = new FileStream("param.dat", FileMode.Open, FileAccess.Read);
                if (fs != null)
                {
                    try
                    {
                        BinaryReader br = new BinaryReader(fs);
                        if (br != null)
                        {
                            textBoxPath.Text = br.ReadString();
                            textBox_logPath.Text = br.ReadString();
                            checkBox_EnableLog.Checked = Convert.ToBoolean(br.ReadInt32());
                            checkBoxOpenGate.Checked = Convert.ToBoolean(br.ReadInt32());
                            checkBoxTrigger.Checked = Convert.ToBoolean(br.ReadInt32());
                            textBoxIntervalOpen.Text = br.ReadInt32().ToString();
                            textBoxIntervalTrigger.Text = br.ReadInt32().ToString();
                            textBoxRecordTime.Text = br.ReadInt32().ToString();

                            comboBoxVideoOSD.SelectedIndex = Convert.ToInt32(br.ReadUInt32());
                            m_nVideoColor = br.ReadString();
                            checkBoxVideoDate.Checked = Convert.ToBoolean(br.ReadUInt32());
                            checkBoxVideoLicense.Checked = Convert.ToBoolean(br.ReadUInt32());
                            checkBoxVideoCustom.Checked = Convert.ToBoolean(br.ReadUInt32());
                            textBoxVideoCustomInfo.Text = br.ReadString();

                            comboBoxJpegOSD.SelectedIndex = Convert.ToInt32(br.ReadUInt32());
                            m_nJpegColor = br.ReadString();
                            checkBoxJpegDate.Checked = Convert.ToBoolean(br.ReadUInt32());
                            checkBoxJpegAlgo.Checked = Convert.ToBoolean(br.ReadUInt32());
                            checkBoxJpegCustom.Checked = Convert.ToBoolean(br.ReadUInt32());
                            textBoxJpegCustomInfo.Text = br.ReadString();

                            checkBoxOpenGate2.Checked = Convert.ToBoolean(br.ReadInt32());
                            checkBoxRS485.Checked = Convert.ToBoolean(br.ReadInt32());
                            checkBoxRS232.Checked = Convert.ToBoolean(br.ReadInt32());
                            textBoxIntervalOpen2.Text = br.ReadInt32().ToString();
                            textBoxIntervalRS485.Text = br.ReadInt32().ToString();
                            textBoxIntervalRS232.Text = br.ReadInt32().ToString();

                            br.Close();
                        }
                        fs.Close();
                    }
                    catch (System.Exception ex)
                    {

                    }
                }
            }
        }

        //获取视频osd叠加颜色
        private void buttonVideoColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = true;
            colorDlg.FullOpen = true;
            colorDlg.ShowHelp = true;
            if (m_nVideoColor == "")
            {
                m_nVideoColor = "000000";
            }
            colorDlg.Color = ColorTranslator.FromHtml("#"+m_nVideoColor);
            colorDlg.ShowDialog();
            //MessageBox.Show(colorDlg.Color.ToArgb().ToString("X8"));
            m_nVideoColor = ColorTranslator.ToHtml(Color.FromArgb(colorDlg.Color.ToArgb())).Replace("#", "");
        }
        //获取图片osd叠加颜色
        private void buttonJpegColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = true;
            colorDlg.FullOpen = true;
            colorDlg.ShowHelp = true;
            if (m_nJpegColor == "")
            {
                m_nJpegColor = "000000";
            }
            colorDlg.Color = ColorTranslator.FromHtml("#" + m_nJpegColor);
            colorDlg.ShowDialog();
            m_nJpegColor = ColorTranslator.ToHtml(Color.FromArgb(colorDlg.Color.ToArgb())).Replace("#", "");
            //m_nJpegColor = Convert.ToUInt32(strColor, 16);
        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBoxVideoCustomInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && textBoxVideoCustomInfo.Lines.Length >= 6)
            {
                e.Handled = true;
            }
        }

        private void textBoxJpegCustomInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && textBoxJpegCustomInfo.Lines.Length >= 6)
            {
                e.Handled = true;
            }
        }
        //限制输入的字符个数和行数
        private void textBoxVideoCustomInfo_TextChanged(object sender, EventArgs e)
        {
            if (textBoxVideoCustomInfo.Text == "")
            {
                return;
            }
            int index = textBoxVideoCustomInfo.GetFirstCharIndexOfCurrentLine();
            int line = textBoxVideoCustomInfo.GetLineFromCharIndex(index) + 1;
            string text = textBoxVideoCustomInfo.Lines[line - 1];
            int len = System.Text.Encoding.Default.GetByteCount(text);
            string[] lines = textBoxVideoCustomInfo.Lines;
            if (len <= 62)
            {
                return;
            }

            //string[] lines = textBoxVideoCustomInfo.Lines;
            int lineLen = 0;
            while (len > 62)
            {
                lineLen = lines[line - 1].Length;
                //删除输入行多余的字符
                lines[line - 1] = lines[line - 1].Remove(lineLen - 1);
                textBoxVideoCustomInfo.Text = "";

                len = System.Text.Encoding.Default.GetByteCount(lines[line - 1]);
            }
            //设置新文本
            textBoxVideoCustomInfo.Lines = lines;
            int textLen = 0;
            for (int i = 0; i < (line - 1); i++)
            {
                textLen += lines[i].Length + 2;
            }
            //设置光标
            textBoxVideoCustomInfo.Select(textLen + lineLen - 1, 0);
        }
        //限制输入的字符个数和行数
        private void textBoxJpegCustomInfo_TextChanged(object sender, EventArgs e)
        {
            if (textBoxJpegCustomInfo.Text == "")
            {
                return;
            }
            int index = textBoxJpegCustomInfo.GetFirstCharIndexOfCurrentLine();
            int line = textBoxJpegCustomInfo.GetLineFromCharIndex(index) + 1;
            string text = textBoxJpegCustomInfo.Lines[line - 1];
            int len = System.Text.Encoding.Default.GetByteCount(text);
            string[] lines = textBoxJpegCustomInfo.Lines;
            if (len <= 62)
            {
                return;
            }

            //string[] lines = textBoxVideoCustomInfo.Lines;
            int lineLen = 0;
            while (len > 62)
            {
                lineLen = lines[line - 1].Length;
                //删除输入行多余的字符
                lines[line - 1] = lines[line - 1].Remove(lineLen - 1);
                textBoxJpegCustomInfo.Text = "";

                len = System.Text.Encoding.Default.GetByteCount(lines[line - 1]);
            }
            //设置新文本
            textBoxJpegCustomInfo.Lines = lines;
            int textLen = 0;
            for (int i = 0; i < (line - 1); i++)
            {
                textLen += lines[i].Length + 2;
            }
            //设置光标
            textBoxJpegCustomInfo.Select(textLen + lineLen - 1, 0);
        }

        private void button_Browse2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDlg = new FolderBrowserDialog();
            folderBrowserDlg.Description = "请选择保存输出图片的文件夹";
            folderBrowserDlg.ShowNewFolderButton = true;
            folderBrowserDlg.RootFolder = Environment.SpecialFolder.MyComputer;
            DialogResult result = folderBrowserDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDlg.SelectedPath;
                if (folderName != "")
                {
                    textBox_logPath.Text = folderName;
                }
            }
        }

        private void textBoxIntervalOpen_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex r = new Regex("^[0-9]{1,}$");
            if (e.KeyChar != (char)8 && (!r.IsMatch(e.KeyChar.ToString())))
            {
                e.Handled = true;
            }
        }

        private void textBoxIntervalTrigger_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex r = new Regex("^[0-9]{1,}$");
            if (e.KeyChar != (char)8 && (!r.IsMatch(e.KeyChar.ToString())))
            {
                e.Handled = true;
            }
        }

        private void textBoxRecordTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex r = new Regex("^[0-9]{1,}$");
            if (e.KeyChar != (char)8 && (!r.IsMatch(e.KeyChar.ToString())))
            {
                e.Handled = true;
            }
        }
    }
}
