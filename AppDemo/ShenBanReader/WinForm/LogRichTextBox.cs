using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace System.Data.ShenBanReader.WinForm
{
    public partial class LogRichTextBox : RichTextBox
    {
        public LogRichTextBox()
        {
            InitializeComponent();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            Select(TextLength, 0);
            ScrollToCaret();
        }

        public void AppendTextEx(string strText, Color clAppend)
        {
            int nLen = TextLength;

            if (nLen != 0)
            {
                AppendText(Environment.NewLine + System.DateTime.Now.ToString() + " " + strText);
            }
            else
            {
                AppendText(System.DateTime.Now.ToString() + " " + strText);
            }

            Select(nLen, TextLength - nLen);
            SelectionColor = clAppend;
        }
        public LogRichTextBox AppendError(string message)
        {
            AppendTextEx(message, Color.Red);
            return this;
        }
        public LogRichTextBox AppendSuccess(string message)
        {
            AppendTextEx(message, Color.Green);
            return this;
        }
        public LogRichTextBox AppendInfo(string message)
        {
            AppendTextEx(message, Color.Blue);
            return this;
        }
        public LogRichTextBox Append(IAlertMsg alert)
        {
            if (alert.IsSuccess)
            {
                AppendTextEx(alert.Message, Color.Green);
            }
            else
            {
                AppendTextEx(alert.Message, Color.Red);
            }
            return this;
        }
        public LogRichTextBox Append(Exception alert)
        {
            var sb  = new StringBuilder().AppendLine(alert.Message).AppendLine(alert.StackTrace);
            AppendTextEx(sb.ToString(), Color.Red);
            return this;
        }
    }
}
