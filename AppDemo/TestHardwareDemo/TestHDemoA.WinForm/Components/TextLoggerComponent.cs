using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestHardwareDemo.WinForm.Components
{

    /// <summary>
    /// 日志组件内容
    /// </summary>
    public partial class TextLoggerComponent : UserControl
    {
        /// <summary>
        /// 构造
        /// </summary>
        public TextLoggerComponent()
        {
            InitializeComponent();
        }
        #region // 值守任务
        /// <summary>
        /// 值守服务线程
        /// </summary>
        protected Thread _guardianService;
        /// <summary>
        /// 取消令牌资源
        /// </summary>
        protected CancellationTokenSource _guardianCts;
        /// <summary>
        /// 值守间隔(单位百毫秒)默认十秒
        /// </summary>
        public virtual int GuardianInterval { get; set; }
        async Task GuardianServiceAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try { GuardianTaskService(); }
                catch(NotImplementedException ex) { AppendError($"【{nameof(GuardianTaskService)}】方法未在子类中重写，方法未实现"); }
                catch (Exception ex) { Append(ex); }
                await Task.Delay(GuardianInterval * 100, stoppingToken);
            }
        }
        /// <summary>
        /// 值守任务服务内容
        /// </summary>
        /// <returns>等待间隔,单位秒</returns>
        public virtual void GuardianTaskService()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 启动值守服务
        /// </summary>
        public virtual void GuardianServiceStart()
        {
            if (_guardianService.IsAlive) { return; }
            _guardianCts = new CancellationTokenSource();
            _guardianService.Start();
        }
        /// <summary>
        /// 关闭值守服务
        /// </summary>
        public virtual void GuardianServiceStop()
        {
            _guardianCts.Cancel();
        }
        /// <summary>
        /// 值守服务初始化
        /// </summary>
        public virtual void GuardianServiceInitialize()
        {
            GuardianInterval = 100;
            _guardianCts = new CancellationTokenSource();
            _guardianService = new Thread(async () => await GuardianServiceAsync(_guardianCts.Token));
            _guardianService.IsBackground = true;
            _guardianService.Start();
        }
        #endregion 值守任务
        #region // 日志控件
        /// <summary>
        /// 当前日志控件
        /// </summary>
        public virtual RichTextBox ThisTxtLogger { get => throw new NotImplementedException(); }
        public virtual void AppendTextEx(string strText, Color clAppend)
        {
            int nLen = this.ThisTxtLogger.TextLength;
            if (nLen != 0) { ThisTxtLogger.AppendText(Environment.NewLine); }
            ThisTxtLogger.AppendText(System.DateTime.Now.ToString() + " " + strText);
            ThisTxtLogger.Select(nLen, this.ThisTxtLogger.TextLength - nLen);
            this.ThisTxtLogger.SelectionColor = clAppend;
        }
        public virtual TextLoggerComponent AppendError(string message)
        {
            this.Invoke((Action)(() => AppendTextEx(message, Color.Red)));
            return this;
        }
        public virtual void AppendErrorVoid(string message) => AppendError(message);
        public virtual TextLoggerComponent AppendSuccess(string message)
        {
            this.Invoke((Action)(() => AppendTextEx(message, Color.Green)));
            return this;
        }
        public virtual void AppendSuccessVoid(string message) => AppendSuccess(message);
        public virtual TextLoggerComponent AppendInfo(string message)
        {
            this.Invoke((Action)(() => AppendTextEx(message, Color.Blue)));
            return this;
        }
        public virtual void AppendInfoVoid(string message) => AppendInfo(message);
        public virtual TextLoggerComponent Append(IAlertMsg alert)
        {
            this.Invoke((Action)(() => AppendTextEx(alert.Message, alert.IsSuccess ? Color.Green : Color.Red)));
            return this;
        }
        public virtual TextLoggerComponent Append(Exception alert)
        {
            var sb = new StringBuilder().AppendLine(alert.Message).AppendLine(alert.StackTrace);
            this.Invoke((Action)(() => AppendTextEx(sb.ToString(), Color.Red)));
            return this;
        }
        public virtual void AppendVoid(IAlertMsg alert) => Append(alert);
        public virtual void AppendVoid(Exception alert) => Append(alert);
        private void TxtLogger_TextChanged(object sender, EventArgs e)
        {
            ThisTxtLogger.Select(ThisTxtLogger.TextLength, 0);
            ThisTxtLogger.ScrollToCaret();
        }
        public virtual void TxtLoggerInitialize()
        {
            ThisTxtLogger.TextChanged += TxtLogger_TextChanged;
        }

        public void TsrmLoggerClear_Click(object sender, EventArgs e)
        {
            this.ThisTxtLogger.Clear();
        }
        #endregion 日志控件
        protected virtual void Initialize()
        {
            TxtLoggerInitialize();
            GuardianServiceInitialize();
        }
    }
}
