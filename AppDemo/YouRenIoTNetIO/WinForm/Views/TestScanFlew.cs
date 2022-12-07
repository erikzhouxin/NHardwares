using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Cobber;
using System.Data.Extter;
using System.Data.Logger;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouRenIoTNetIO.WinForm.Views
{
    public partial class TestScanFlew : UserControl
    {
        internal static TestScanFlew Instance { get; set; }
        Thread _guardianService;
        CancellationTokenSource _guardianCts;
        bool _isInitialize;
        HashSet<string> _cacheTags;
        public TestScanFlew()
        {
            Instance = this;
            InitializeComponent();
        }
        private void TestScanner_Load(object sender, EventArgs e)
        {
            if (!_isInitialize)
            {
                _isInitialize = true;
                _cacheTags = new HashSet<string>();

                _guardianCts = new CancellationTokenSource();
                _guardianService = new Thread(async () => await GuardianServiceAsync(_guardianCts.Token));
                _guardianService.IsBackground = true;
                _guardianService.Start();
            }
        }
        private void BtnConnAdd_Click(object sender, EventArgs e)
        {
        }
        private void BtnConnRemove_Click(object sender, EventArgs e)
        {
        }
        #region // 服务内容
        async Task GuardianServiceAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(1000); // 等下载一下
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                }
                catch (Exception ex)
                {
                    Append(ex);
                }
                await Task.Delay(100 * 100, stoppingToken);
            }
        }
        #endregion
        #region // 日志控件
        public void AppendTextEx(string strText, Color clAppend)
        {
            int nLen = this.TxtLogger.TextLength;

            if (nLen != 0)
            {
                TxtLogger.AppendText(Environment.NewLine + System.DateTime.Now.ToString() + " " + strText);
            }
            else
            {
                TxtLogger.AppendText(System.DateTime.Now.ToString() + " " + strText);
            }

            TxtLogger.Select(nLen, this.TxtLogger.TextLength - nLen);
            this.TxtLogger.SelectionColor = clAppend;
        }
        public TestScanFlew AppendError(string message)
        {
            this.Invoke((Action)(() =>
            {
                AppendTextEx(message, Color.Red);
            }));
            return this;
        }
        public TestScanFlew AppendSuccess(string message)
        {
            this.Invoke((Action)(() =>
            {
                AppendTextEx(message, Color.Green);
            }));
            return this;
        }
        public TestScanFlew AppendInfo(string message)
        {
            this.Invoke((Action)(() =>
            {
                AppendTextEx(message, Color.Blue);
            }));
            return this;
        }
        public TestScanFlew Append(IAlertMsg alert)
        {
            this.Invoke((Action)(() =>
            {
                AppendTextEx(alert.Message, alert.IsSuccess ? Color.Green : Color.Red);
            }));
            return this;
        }
        public TestScanFlew Append(Exception alert)
        {
            var sb = new StringBuilder().AppendLine(alert.Message).AppendLine(alert.StackTrace);
            this.Invoke((Action)(() =>
            {
                AppendTextEx(sb.ToString(), Color.Red);
            }));
            return this;
        }
        private void TxtLogger_TextChanged(object sender, EventArgs e)
        {
            TxtLogger.Select(TxtLogger.TextLength, 0);
            TxtLogger.ScrollToCaret();
        }
        #endregion
    }
}
