﻿namespace VzClientSDK.WinForm.Views
{
    partial class VzLPRSDKDemo
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PnlMainContent = new System.Windows.Forms.Panel();
            this.TabMainContent = new System.Windows.Forms.TableLayoutPanel();
            this.PnlTabCnt1 = new System.Windows.Forms.Panel();
            this.GrbNetConfig = new System.Windows.Forms.GroupBox();
            this.PnlNetConfig = new System.Windows.Forms.Panel();
            this.PnlNetConfigDetail = new System.Windows.Forms.Panel();
            this.TxtNetSerialNum = new System.Windows.Forms.TextBox();
            this.ChkNetPDNS = new System.Windows.Forms.CheckBox();
            this.TxtNetPassword = new System.Windows.Forms.TextBox();
            this.TxtNetAccount = new System.Windows.Forms.TextBox();
            this.LblNetAccountPass = new System.Windows.Forms.Label();
            this.TxtNetPort = new System.Windows.Forms.TextBox();
            this.TxtNetIp = new System.Windows.Forms.TextBox();
            this.LblNetIpPort = new System.Windows.Forms.Label();
            this.PnlNetConfigList = new System.Windows.Forms.Panel();
            this.CbxNetConfigs = new System.Windows.Forms.ComboBox();
            this.PnlTabCnt2 = new System.Windows.Forms.Panel();
            this.GrbScreenView = new System.Windows.Forms.GroupBox();
            this.PnlScreenView = new System.Windows.Forms.Panel();
            this.PicScreenView = new System.Windows.Forms.PictureBox();
            this.PnlTabCnt3 = new System.Windows.Forms.Panel();
            this.PnlTabCnt4 = new System.Windows.Forms.Panel();
            this.GrbTxtLogger = new System.Windows.Forms.GroupBox();
            this.TxtLogger = new System.Windows.Forms.RichTextBox();
            this.CmsrTxtLoggerCtx = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TsrmLoggerClear = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnNetLogin = new System.Windows.Forms.Button();
            this.BtnNetExit = new System.Windows.Forms.Button();
            this.CmsrNetConfigBtns = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.手动识别ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.抓图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gPIOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.连接状态ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.预览输出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始录像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.车牌查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.白名单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.控制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.输入输出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.视频未知ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.线圈配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.基本配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oSD值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加密配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.播放语音ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.定焦配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.语音对讲ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.单步开闸ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lED补光ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PnlMainContent.SuspendLayout();
            this.TabMainContent.SuspendLayout();
            this.PnlTabCnt1.SuspendLayout();
            this.GrbNetConfig.SuspendLayout();
            this.PnlNetConfig.SuspendLayout();
            this.PnlNetConfigDetail.SuspendLayout();
            this.PnlNetConfigList.SuspendLayout();
            this.PnlTabCnt2.SuspendLayout();
            this.GrbScreenView.SuspendLayout();
            this.PnlScreenView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicScreenView)).BeginInit();
            this.PnlTabCnt4.SuspendLayout();
            this.GrbTxtLogger.SuspendLayout();
            this.CmsrTxtLoggerCtx.SuspendLayout();
            this.CmsrNetConfigBtns.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMainContent
            // 
            this.PnlMainContent.Controls.Add(this.TabMainContent);
            this.PnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMainContent.Location = new System.Drawing.Point(0, 0);
            this.PnlMainContent.Name = "PnlMainContent";
            this.PnlMainContent.Size = new System.Drawing.Size(791, 515);
            this.PnlMainContent.TabIndex = 0;
            // 
            // TabMainContent
            // 
            this.TabMainContent.ColumnCount = 2;
            this.TabMainContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TabMainContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TabMainContent.Controls.Add(this.PnlTabCnt1, 0, 0);
            this.TabMainContent.Controls.Add(this.PnlTabCnt2, 1, 0);
            this.TabMainContent.Controls.Add(this.PnlTabCnt3, 0, 1);
            this.TabMainContent.Controls.Add(this.PnlTabCnt4, 1, 1);
            this.TabMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabMainContent.Location = new System.Drawing.Point(0, 0);
            this.TabMainContent.Name = "TabMainContent";
            this.TabMainContent.RowCount = 3;
            this.TabMainContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TabMainContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TabMainContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TabMainContent.Size = new System.Drawing.Size(791, 515);
            this.TabMainContent.TabIndex = 0;
            // 
            // PnlTabCnt1
            // 
            this.PnlTabCnt1.Controls.Add(this.GrbNetConfig);
            this.PnlTabCnt1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlTabCnt1.Location = new System.Drawing.Point(3, 3);
            this.PnlTabCnt1.Name = "PnlTabCnt1";
            this.PnlTabCnt1.Size = new System.Drawing.Size(389, 241);
            this.PnlTabCnt1.TabIndex = 0;
            // 
            // GrbNetConfig
            // 
            this.GrbNetConfig.Controls.Add(this.PnlNetConfig);
            this.GrbNetConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbNetConfig.Location = new System.Drawing.Point(0, 0);
            this.GrbNetConfig.Name = "GrbNetConfig";
            this.GrbNetConfig.Size = new System.Drawing.Size(389, 241);
            this.GrbNetConfig.TabIndex = 0;
            this.GrbNetConfig.TabStop = false;
            this.GrbNetConfig.Text = "配置信息";
            // 
            // PnlNetConfig
            // 
            this.PnlNetConfig.Controls.Add(this.PnlNetConfigDetail);
            this.PnlNetConfig.Controls.Add(this.PnlNetConfigList);
            this.PnlNetConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlNetConfig.Location = new System.Drawing.Point(3, 19);
            this.PnlNetConfig.Name = "PnlNetConfig";
            this.PnlNetConfig.Size = new System.Drawing.Size(383, 219);
            this.PnlNetConfig.TabIndex = 0;
            // 
            // PnlNetConfigDetail
            // 
            this.PnlNetConfigDetail.AutoScroll = true;
            this.PnlNetConfigDetail.Controls.Add(this.BtnNetExit);
            this.PnlNetConfigDetail.Controls.Add(this.BtnNetLogin);
            this.PnlNetConfigDetail.Controls.Add(this.TxtNetSerialNum);
            this.PnlNetConfigDetail.Controls.Add(this.ChkNetPDNS);
            this.PnlNetConfigDetail.Controls.Add(this.TxtNetPassword);
            this.PnlNetConfigDetail.Controls.Add(this.TxtNetAccount);
            this.PnlNetConfigDetail.Controls.Add(this.LblNetAccountPass);
            this.PnlNetConfigDetail.Controls.Add(this.TxtNetPort);
            this.PnlNetConfigDetail.Controls.Add(this.TxtNetIp);
            this.PnlNetConfigDetail.Controls.Add(this.LblNetIpPort);
            this.PnlNetConfigDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlNetConfigDetail.Location = new System.Drawing.Point(0, 39);
            this.PnlNetConfigDetail.Name = "PnlNetConfigDetail";
            this.PnlNetConfigDetail.Size = new System.Drawing.Size(383, 180);
            this.PnlNetConfigDetail.TabIndex = 1;
            // 
            // TxtNetSerialNum
            // 
            this.TxtNetSerialNum.Enabled = false;
            this.TxtNetSerialNum.Location = new System.Drawing.Point(232, 89);
            this.TxtNetSerialNum.Name = "TxtNetSerialNum";
            this.TxtNetSerialNum.Size = new System.Drawing.Size(73, 23);
            this.TxtNetSerialNum.TabIndex = 7;
            // 
            // ChkNetPDNS
            // 
            this.ChkNetPDNS.AutoSize = true;
            this.ChkNetPDNS.Location = new System.Drawing.Point(78, 91);
            this.ChkNetPDNS.Name = "ChkNetPDNS";
            this.ChkNetPDNS.Size = new System.Drawing.Size(135, 21);
            this.ChkNetPDNS.TabIndex = 6;
            this.ChkNetPDNS.Text = "云服务器登录序列号";
            this.ChkNetPDNS.UseVisualStyleBackColor = true;
            this.ChkNetPDNS.Click += new System.EventHandler(this.ChkNetPDNS_Click);
            // 
            // TxtNetPassword
            // 
            this.TxtNetPassword.Location = new System.Drawing.Point(232, 56);
            this.TxtNetPassword.Name = "TxtNetPassword";
            this.TxtNetPassword.PasswordChar = '*';
            this.TxtNetPassword.Size = new System.Drawing.Size(73, 23);
            this.TxtNetPassword.TabIndex = 5;
            this.TxtNetPassword.Text = "admin";
            // 
            // TxtNetAccount
            // 
            this.TxtNetAccount.Location = new System.Drawing.Point(113, 55);
            this.TxtNetAccount.Name = "TxtNetAccount";
            this.TxtNetAccount.Size = new System.Drawing.Size(100, 23);
            this.TxtNetAccount.TabIndex = 4;
            this.TxtNetAccount.Text = "admin";
            // 
            // LblNetAccountPass
            // 
            this.LblNetAccountPass.AutoSize = true;
            this.LblNetAccountPass.Location = new System.Drawing.Point(31, 57);
            this.LblNetAccountPass.Name = "LblNetAccountPass";
            this.LblNetAccountPass.Size = new System.Drawing.Size(80, 17);
            this.LblNetAccountPass.TabIndex = 3;
            this.LblNetAccountPass.Text = "账号及密码：";
            // 
            // TxtNetPort
            // 
            this.TxtNetPort.Location = new System.Drawing.Point(232, 22);
            this.TxtNetPort.Name = "TxtNetPort";
            this.TxtNetPort.Size = new System.Drawing.Size(73, 23);
            this.TxtNetPort.TabIndex = 2;
            this.TxtNetPort.Text = "80";
            // 
            // TxtNetIp
            // 
            this.TxtNetIp.Location = new System.Drawing.Point(113, 22);
            this.TxtNetIp.Name = "TxtNetIp";
            this.TxtNetIp.Size = new System.Drawing.Size(100, 23);
            this.TxtNetIp.TabIndex = 1;
            this.TxtNetIp.Text = "192.168.1.100";
            // 
            // LblNetIpPort
            // 
            this.LblNetIpPort.AutoSize = true;
            this.LblNetIpPort.Location = new System.Drawing.Point(20, 25);
            this.LblNetIpPort.Name = "LblNetIpPort";
            this.LblNetIpPort.Size = new System.Drawing.Size(91, 17);
            this.LblNetIpPort.TabIndex = 0;
            this.LblNetIpPort.Text = "IP地址及端口：";
            // 
            // PnlNetConfigList
            // 
            this.PnlNetConfigList.Controls.Add(this.CbxNetConfigs);
            this.PnlNetConfigList.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlNetConfigList.Location = new System.Drawing.Point(0, 0);
            this.PnlNetConfigList.Name = "PnlNetConfigList";
            this.PnlNetConfigList.Size = new System.Drawing.Size(383, 39);
            this.PnlNetConfigList.TabIndex = 0;
            // 
            // CbxNetConfigs
            // 
            this.CbxNetConfigs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CbxNetConfigs.FormattingEnabled = true;
            this.CbxNetConfigs.Location = new System.Drawing.Point(24, 7);
            this.CbxNetConfigs.Name = "CbxNetConfigs";
            this.CbxNetConfigs.Size = new System.Drawing.Size(334, 25);
            this.CbxNetConfigs.TabIndex = 0;
            // 
            // PnlTabCnt2
            // 
            this.PnlTabCnt2.Controls.Add(this.GrbScreenView);
            this.PnlTabCnt2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlTabCnt2.Location = new System.Drawing.Point(398, 3);
            this.PnlTabCnt2.Name = "PnlTabCnt2";
            this.PnlTabCnt2.Size = new System.Drawing.Size(390, 241);
            this.PnlTabCnt2.TabIndex = 1;
            // 
            // GrbScreenView
            // 
            this.GrbScreenView.Controls.Add(this.PnlScreenView);
            this.GrbScreenView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbScreenView.Location = new System.Drawing.Point(0, 0);
            this.GrbScreenView.Name = "GrbScreenView";
            this.GrbScreenView.Size = new System.Drawing.Size(390, 241);
            this.GrbScreenView.TabIndex = 0;
            this.GrbScreenView.TabStop = false;
            this.GrbScreenView.Text = "视频预览";
            // 
            // PnlScreenView
            // 
            this.PnlScreenView.Controls.Add(this.PicScreenView);
            this.PnlScreenView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlScreenView.Location = new System.Drawing.Point(3, 19);
            this.PnlScreenView.Name = "PnlScreenView";
            this.PnlScreenView.Size = new System.Drawing.Size(384, 219);
            this.PnlScreenView.TabIndex = 0;
            // 
            // PicScreenView
            // 
            this.PicScreenView.BackColor = System.Drawing.SystemColors.WindowText;
            this.PicScreenView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicScreenView.Location = new System.Drawing.Point(0, 0);
            this.PicScreenView.Name = "PicScreenView";
            this.PicScreenView.Size = new System.Drawing.Size(384, 219);
            this.PicScreenView.TabIndex = 0;
            this.PicScreenView.TabStop = false;
            // 
            // PnlTabCnt3
            // 
            this.PnlTabCnt3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlTabCnt3.Location = new System.Drawing.Point(3, 250);
            this.PnlTabCnt3.Name = "PnlTabCnt3";
            this.PnlTabCnt3.Size = new System.Drawing.Size(389, 241);
            this.PnlTabCnt3.TabIndex = 2;
            // 
            // PnlTabCnt4
            // 
            this.PnlTabCnt4.Controls.Add(this.GrbTxtLogger);
            this.PnlTabCnt4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlTabCnt4.Location = new System.Drawing.Point(398, 250);
            this.PnlTabCnt4.Name = "PnlTabCnt4";
            this.PnlTabCnt4.Size = new System.Drawing.Size(390, 241);
            this.PnlTabCnt4.TabIndex = 3;
            // 
            // GrbTxtLogger
            // 
            this.GrbTxtLogger.Controls.Add(this.TxtLogger);
            this.GrbTxtLogger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbTxtLogger.Location = new System.Drawing.Point(0, 0);
            this.GrbTxtLogger.Name = "GrbTxtLogger";
            this.GrbTxtLogger.Size = new System.Drawing.Size(390, 241);
            this.GrbTxtLogger.TabIndex = 0;
            this.GrbTxtLogger.TabStop = false;
            this.GrbTxtLogger.Text = "日志信息";
            // 
            // TxtLogger
            // 
            this.TxtLogger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtLogger.Location = new System.Drawing.Point(3, 19);
            this.TxtLogger.Name = "TxtLogger";
            this.TxtLogger.Size = new System.Drawing.Size(384, 219);
            this.TxtLogger.TabIndex = 0;
            this.TxtLogger.Text = "";
            // 
            // CmsrTxtLoggerCtx
            // 
            this.CmsrTxtLoggerCtx.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsrmLoggerClear});
            this.CmsrTxtLoggerCtx.Name = "CmsrTxtLoggerCtx";
            this.CmsrTxtLoggerCtx.Size = new System.Drawing.Size(125, 26);
            // 
            // TsrmLoggerClear
            // 
            this.TsrmLoggerClear.Name = "TsrmLoggerClear";
            this.TsrmLoggerClear.Size = new System.Drawing.Size(124, 22);
            this.TsrmLoggerClear.Text = "清空日志";
            this.TsrmLoggerClear.Click += new System.EventHandler(this.TsrmLoggerClear_Click);
            // 
            // BtnNetLogin
            // 
            this.BtnNetLogin.Location = new System.Drawing.Point(119, 130);
            this.BtnNetLogin.Name = "BtnNetLogin";
            this.BtnNetLogin.Size = new System.Drawing.Size(64, 31);
            this.BtnNetLogin.TabIndex = 8;
            this.BtnNetLogin.Text = "登录";
            this.BtnNetLogin.UseVisualStyleBackColor = true;
            // 
            // BtnNetExit
            // 
            this.BtnNetExit.Location = new System.Drawing.Point(222, 130);
            this.BtnNetExit.Name = "BtnNetExit";
            this.BtnNetExit.Size = new System.Drawing.Size(64, 31);
            this.BtnNetExit.TabIndex = 9;
            this.BtnNetExit.Text = "退出";
            this.BtnNetExit.UseVisualStyleBackColor = true;
            // 
            // CmsrNetConfigBtns
            // 
            this.CmsrNetConfigBtns.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.手动识别ToolStripMenuItem,
            this.抓图ToolStripMenuItem,
            this.gPIOToolStripMenuItem,
            this.连接状态ToolStripMenuItem,
            this.预览输出ToolStripMenuItem,
            this.开始录像ToolStripMenuItem,
            this.车牌查询ToolStripMenuItem,
            this.白名单ToolStripMenuItem,
            this.控制ToolStripMenuItem,
            this.输入输出ToolStripMenuItem,
            this.视频未知ToolStripMenuItem,
            this.线圈配置ToolStripMenuItem,
            this.基本配置ToolStripMenuItem,
            this.oSD值ToolStripMenuItem,
            this.加密配置ToolStripMenuItem,
            this.播放语音ToolStripMenuItem,
            this.定焦配置ToolStripMenuItem,
            this.语音对讲ToolStripMenuItem,
            this.单步开闸ToolStripMenuItem,
            this.lED补光ToolStripMenuItem});
            this.CmsrNetConfigBtns.Name = "CmsrNetConfigBtns";
            this.CmsrNetConfigBtns.Size = new System.Drawing.Size(181, 466);
            // 
            // 手动识别ToolStripMenuItem
            // 
            this.手动识别ToolStripMenuItem.Name = "手动识别ToolStripMenuItem";
            this.手动识别ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.手动识别ToolStripMenuItem.Text = "手动识别";
            // 
            // 抓图ToolStripMenuItem
            // 
            this.抓图ToolStripMenuItem.Name = "抓图ToolStripMenuItem";
            this.抓图ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.抓图ToolStripMenuItem.Text = "抓图";
            // 
            // gPIOToolStripMenuItem
            // 
            this.gPIOToolStripMenuItem.Name = "gPIOToolStripMenuItem";
            this.gPIOToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gPIOToolStripMenuItem.Text = "GPIO";
            // 
            // 连接状态ToolStripMenuItem
            // 
            this.连接状态ToolStripMenuItem.Name = "连接状态ToolStripMenuItem";
            this.连接状态ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.连接状态ToolStripMenuItem.Text = "连接状态";
            // 
            // 预览输出ToolStripMenuItem
            // 
            this.预览输出ToolStripMenuItem.Name = "预览输出ToolStripMenuItem";
            this.预览输出ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.预览输出ToolStripMenuItem.Text = "预览输出";
            // 
            // 开始录像ToolStripMenuItem
            // 
            this.开始录像ToolStripMenuItem.Name = "开始录像ToolStripMenuItem";
            this.开始录像ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.开始录像ToolStripMenuItem.Text = "开始录像";
            // 
            // 车牌查询ToolStripMenuItem
            // 
            this.车牌查询ToolStripMenuItem.Name = "车牌查询ToolStripMenuItem";
            this.车牌查询ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.车牌查询ToolStripMenuItem.Text = "车牌查询";
            // 
            // 白名单ToolStripMenuItem
            // 
            this.白名单ToolStripMenuItem.Name = "白名单ToolStripMenuItem";
            this.白名单ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.白名单ToolStripMenuItem.Text = "白名单";
            // 
            // 控制ToolStripMenuItem
            // 
            this.控制ToolStripMenuItem.Name = "控制ToolStripMenuItem";
            this.控制ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.控制ToolStripMenuItem.Text = "485控制";
            // 
            // 输入输出ToolStripMenuItem
            // 
            this.输入输出ToolStripMenuItem.Name = "输入输出ToolStripMenuItem";
            this.输入输出ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.输入输出ToolStripMenuItem.Text = "输入输出";
            // 
            // 视频未知ToolStripMenuItem
            // 
            this.视频未知ToolStripMenuItem.Name = "视频未知ToolStripMenuItem";
            this.视频未知ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.视频未知ToolStripMenuItem.Text = "视频配置";
            // 
            // 线圈配置ToolStripMenuItem
            // 
            this.线圈配置ToolStripMenuItem.Name = "线圈配置ToolStripMenuItem";
            this.线圈配置ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.线圈配置ToolStripMenuItem.Text = "线圈配置";
            // 
            // 基本配置ToolStripMenuItem
            // 
            this.基本配置ToolStripMenuItem.Name = "基本配置ToolStripMenuItem";
            this.基本配置ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.基本配置ToolStripMenuItem.Text = "基本配置";
            // 
            // oSD值ToolStripMenuItem
            // 
            this.oSD值ToolStripMenuItem.Name = "oSD值ToolStripMenuItem";
            this.oSD值ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.oSD值ToolStripMenuItem.Text = "OSD配置";
            // 
            // 加密配置ToolStripMenuItem
            // 
            this.加密配置ToolStripMenuItem.Name = "加密配置ToolStripMenuItem";
            this.加密配置ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.加密配置ToolStripMenuItem.Text = "加密配置";
            // 
            // 播放语音ToolStripMenuItem
            // 
            this.播放语音ToolStripMenuItem.Name = "播放语音ToolStripMenuItem";
            this.播放语音ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.播放语音ToolStripMenuItem.Text = "播放语音";
            // 
            // 定焦配置ToolStripMenuItem
            // 
            this.定焦配置ToolStripMenuItem.Name = "定焦配置ToolStripMenuItem";
            this.定焦配置ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.定焦配置ToolStripMenuItem.Text = "定焦配置";
            // 
            // 语音对讲ToolStripMenuItem
            // 
            this.语音对讲ToolStripMenuItem.Name = "语音对讲ToolStripMenuItem";
            this.语音对讲ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.语音对讲ToolStripMenuItem.Text = "语音对讲";
            // 
            // 单步开闸ToolStripMenuItem
            // 
            this.单步开闸ToolStripMenuItem.Name = "单步开闸ToolStripMenuItem";
            this.单步开闸ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.单步开闸ToolStripMenuItem.Text = "单步开闸";
            // 
            // lED补光ToolStripMenuItem
            // 
            this.lED补光ToolStripMenuItem.Name = "lED补光ToolStripMenuItem";
            this.lED补光ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lED补光ToolStripMenuItem.Text = "补光设置";
            // 
            // VzLPRSDKDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PnlMainContent);
            this.Name = "VzLPRSDKDemo";
            this.Size = new System.Drawing.Size(791, 515);
            this.Load += new System.EventHandler(this.VzLPRSDKDemo_Load);
            this.PnlMainContent.ResumeLayout(false);
            this.TabMainContent.ResumeLayout(false);
            this.PnlTabCnt1.ResumeLayout(false);
            this.GrbNetConfig.ResumeLayout(false);
            this.PnlNetConfig.ResumeLayout(false);
            this.PnlNetConfigDetail.ResumeLayout(false);
            this.PnlNetConfigDetail.PerformLayout();
            this.PnlNetConfigList.ResumeLayout(false);
            this.PnlTabCnt2.ResumeLayout(false);
            this.GrbScreenView.ResumeLayout(false);
            this.PnlScreenView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicScreenView)).EndInit();
            this.PnlTabCnt4.ResumeLayout(false);
            this.GrbTxtLogger.ResumeLayout(false);
            this.CmsrTxtLoggerCtx.ResumeLayout(false);
            this.CmsrNetConfigBtns.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlMainContent;
        private System.Windows.Forms.TableLayoutPanel TabMainContent;
        private System.Windows.Forms.Panel PnlTabCnt1;
        private System.Windows.Forms.Panel PnlTabCnt2;
        private System.Windows.Forms.Panel PnlTabCnt3;
        private System.Windows.Forms.Panel PnlTabCnt4;
        private System.Windows.Forms.GroupBox GrbTxtLogger;
        private System.Windows.Forms.RichTextBox TxtLogger;
        private System.Windows.Forms.GroupBox GrbScreenView;
        private System.Windows.Forms.Panel PnlScreenView;
        private System.Windows.Forms.PictureBox PicScreenView;
        private System.Windows.Forms.ContextMenuStrip CmsrTxtLoggerCtx;
        private System.Windows.Forms.ToolStripMenuItem TsrmLoggerClear;
        private System.Windows.Forms.GroupBox GrbNetConfig;
        private System.Windows.Forms.Panel PnlNetConfig;
        private System.Windows.Forms.Panel PnlNetConfigList;
        private System.Windows.Forms.ComboBox CbxNetConfigs;
        private System.Windows.Forms.Panel PnlNetConfigDetail;
        private System.Windows.Forms.TextBox TxtNetIp;
        private System.Windows.Forms.Label LblNetIpPort;
        private System.Windows.Forms.TextBox TxtNetPort;
        private System.Windows.Forms.TextBox TxtNetPassword;
        private System.Windows.Forms.TextBox TxtNetAccount;
        private System.Windows.Forms.Label LblNetAccountPass;
        private System.Windows.Forms.TextBox TxtNetSerialNum;
        private System.Windows.Forms.CheckBox ChkNetPDNS;
        private System.Windows.Forms.Button BtnNetLogin;
        private System.Windows.Forms.Button BtnNetExit;
        private System.Windows.Forms.ContextMenuStrip CmsrNetConfigBtns;
        private System.Windows.Forms.ToolStripMenuItem 手动识别ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 抓图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gPIOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 连接状态ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 预览输出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开始录像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 车牌查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 白名单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 控制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 输入输出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 视频未知ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 线圈配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 基本配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oSD值ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 加密配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 播放语音ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 定焦配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 语音对讲ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 单步开闸ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lED补光ToolStripMenuItem;
    }
}
