namespace YuShiITSSDK.NWinFormUI
{
    partial class MainForm
    {
        /// <summary>
        /// 
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing">。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 

        /// <summary>
        /// 
        /// 
        /// </summary>
        private void InitializeComponent()
        {
            this.LiveView = new System.Windows.Forms.GroupBox();
            this.VID_STREAM = new System.Windows.Forms.PictureBox();
            this.PhotoView = new System.Windows.Forms.GroupBox();
            this.PIC_STREAM = new System.Windows.Forms.PictureBox();
            this.mainTabCtrl = new System.Windows.Forms.TabControl();
            this.LocalFeatures = new System.Windows.Forms.TabPage();
            this.SetSDKLog = new System.Windows.Forms.GroupBox();
            this.SetlogPath = new System.Windows.Forms.Button();
            this.SetlogSizeNum = new System.Windows.Forms.Button();
            this.LogNumber = new System.Windows.Forms.TextBox();
            this.LogSize = new System.Windows.Forms.TextBox();
            this.LogPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SDKInfo = new System.Windows.Forms.GroupBox();
            this.SetEncodingFormat = new System.Windows.Forms.Button();
            this.GetVersion = new System.Windows.Forms.Button();
            this.PlateencodingCombox = new System.Windows.Forms.ComboBox();
            this.VersiontextBox = new System.Windows.Forms.TextBox();
            this.Plateencodingformat = new System.Windows.Forms.Label();
            this.SDKVersion = new System.Windows.Forms.Label();
            this.LiveOperation = new System.Windows.Forms.TabPage();
            this.DataCallback = new System.Windows.Forms.GroupBox();
            this.LiveDataReset = new System.Windows.Forms.Button();
            this.LiveDataSetCallback = new System.Windows.Forms.Button();
            this.LiveDataFormatcomboBox = new System.Windows.Forms.ComboBox();
            this.LiveDataFormat = new System.Windows.Forms.Label();
            this.VideoRecording = new System.Windows.Forms.GroupBox();
            this.StopRecording = new System.Windows.Forms.Button();
            this.StartRecording = new System.Windows.Forms.Button();
            this.LiveRecordcomboBox = new System.Windows.Forms.ComboBox();
            this.LiveRecordingSavePath = new System.Windows.Forms.TextBox();
            this.Format = new System.Windows.Forms.Label();
            this.SavePath = new System.Windows.Forms.Label();
            this.LivePreview = new System.Windows.Forms.GroupBox();
            this.Snapshot = new System.Windows.Forms.Button();
            this.LiveClose = new System.Windows.Forms.Button();
            this.LiveOpen = new System.Windows.Forms.Button();
            this.PhotoOperation = new System.Windows.Forms.TabPage();
            this.PhotoListView = new System.Windows.Forms.ListView();
            this.DeviceID = new System.Windows.Forms.ColumnHeader();
            this.PassTime = new System.Windows.Forms.ColumnHeader();
            this.LaneID = new System.Windows.Forms.ColumnHeader();
            this.PlateColor = new System.Windows.Forms.ColumnHeader();
            this.LicensePlate = new System.Windows.Forms.ColumnHeader();
            this.CapatureSys = new System.Windows.Forms.ColumnHeader();
            this.PicturePreview = new System.Windows.Forms.GroupBox();
            this.PhotoCaptureSys = new System.Windows.Forms.Button();
            this.PhotoCapture = new System.Windows.Forms.Button();
            this.PhotoClose = new System.Windows.Forms.Button();
            this.PhotoOpen = new System.Windows.Forms.Button();
            this.VechicleListOperation = new System.Windows.Forms.TabPage();
            this.VehicleRecordOperation = new System.Windows.Forms.GroupBox();
            this.ExpirationTime = new System.Windows.Forms.DateTimePicker();
            this.EffectiveTime = new System.Windows.Forms.DateTimePicker();
            this.ExpirationDate = new System.Windows.Forms.DateTimePicker();
            this.EffectiveData = new System.Windows.Forms.DateTimePicker();
            this.DeleteRecord = new System.Windows.Forms.Button();
            this.ModifyRecord = new System.Windows.Forms.Button();
            this.AddRecord = new System.Windows.Forms.Button();
            this.BlockListradioButton = new System.Windows.Forms.RadioButton();
            this.AllowListradioButton = new System.Windows.Forms.RadioButton();
            this.VechicleListNotextBox = new System.Windows.Forms.TextBox();
            this.VechicleListIDtextBox = new System.Windows.Forms.TextBox();
            this.VechicleListExpirationTime = new System.Windows.Forms.Label();
            this.VechicleListEffectiveTime = new System.Windows.Forms.Label();
            this.VechicleListPlateNo = new System.Windows.Forms.Label();
            this.VechicleListID = new System.Windows.Forms.Label();
            this.EntranceandExitVehicleListFile = new System.Windows.Forms.GroupBox();
            this.VehicleListBlockExport = new System.Windows.Forms.Button();
            this.VechicleListImport = new System.Windows.Forms.Button();
            this.VechicleListBrowse = new System.Windows.Forms.Button();
            this.VehicleListAllowExport = new System.Windows.Forms.Button();
            this.VechicleListFilePath = new System.Windows.Forms.TextBox();
            this.ExportBlocklistFile = new System.Windows.Forms.Label();
            this.ExportAllowlistFile = new System.Windows.Forms.Label();
            this.ImportFile = new System.Windows.Forms.Label();
            this.Parameter = new System.Windows.Forms.TabPage();
            this.LiveviewOSDcunstomsetting = new System.Windows.Forms.GroupBox();
            this.OSDContent = new System.Windows.Forms.GroupBox();
            this.SettingOSDContent = new System.Windows.Forms.Button();
            this.OSDContenttextBox = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.MinMargincomboBox = new System.Windows.Forms.ComboBox();
            this.FontColorcomboBox = new System.Windows.Forms.ComboBox();
            this.FontSizecomboBox = new System.Windows.Forms.ComboBox();
            this.EffectcomboBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Getdevicecapability = new System.Windows.Forms.GroupBox();
            this.getcapability = new System.Windows.Forms.Button();
            this.CapabilitycomboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Setparameter = new System.Windows.Forms.Button();
            this.Getparameter = new System.Windows.Forms.Button();
            this.setParametercomboBox = new System.Windows.Forms.ComboBox();
            this.getParametercomboBox = new System.Windows.Forms.ComboBox();
            this.SystemMaintenance = new System.Windows.Forms.TabPage();
            this.Reboot = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Upgrade = new System.Windows.Forms.Button();
            this.Browse = new System.Windows.Forms.Button();
            this.LocalUpgrade = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.NETInfo = new System.Windows.Forms.GroupBox();
            this.SetNetInfo = new System.Windows.Forms.Button();
            this.GetNetInfo = new System.Windows.Forms.Button();
            this.MTUtextBox = new System.Windows.Forms.TextBox();
            this.DHCPtextBox = new System.Windows.Forms.TextBox();
            this.SubnetMasktextBox = new System.Windows.Forms.TextBox();
            this.IPAddressBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SubnetMask = new System.Windows.Forms.Label();
            this.IPAddreing = new System.Windows.Forms.Label();
            this.VersionInfo = new System.Windows.Forms.GroupBox();
            this.VedrsionInfoRefresh = new System.Windows.Forms.Button();
            this.MacAdresstextBox = new System.Windows.Forms.TextBox();
            this.SerialNotextBox = new System.Windows.Forms.TextBox();
            this.DeviceNametextBox = new System.Windows.Forms.TextBox();
            this.HardwaretextBox = new System.Windows.Forms.TextBox();
            this.FirmwaretextBox = new System.Windows.Forms.TextBox();
            this.MACAddress = new System.Windows.Forms.Label();
            this.SerialNo = new System.Windows.Forms.Label();
            this.DeviceName = new System.Windows.Forms.Label();
            this.HardwareVersion = new System.Windows.Forms.Label();
            this.FirmwareVersion = new System.Windows.Forms.Label();
            this.UserInfo = new System.Windows.Forms.GroupBox();
            this.UserInfolistView = new System.Windows.Forms.ListView();
            this.IP = new System.Windows.Forms.ColumnHeader();
            this.Username = new System.Windows.Forms.ColumnHeader();
            this.Status = new System.Windows.Forms.ColumnHeader();
            this.Photosnumber = new System.Windows.Forms.ColumnHeader();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.deleteDevice = new System.Windows.Forms.Button();
            this.addDevice = new System.Windows.Forms.Button();
            this.MultiPasswordtextBox = new System.Windows.Forms.TextBox();
            this.MultiPorttextBox = new System.Windows.Forms.TextBox();
            this.MultiUsernametextBox = new System.Windows.Forms.TextBox();
            this.MultiIPtextBox = new System.Windows.Forms.TextBox();
            this.MultiLogoutbutton = new System.Windows.Forms.Button();
            this.MultiLoginbutton = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.VoiceFunction = new System.Windows.Forms.TabPage();
            this.ParkingConfiguration = new System.Windows.Forms.TabPage();
            this.SpaceNo = new System.Windows.Forms.ColumnHeader();
            this.AreaNo = new System.Windows.Forms.ColumnHeader();
            this.ParkingNo = new System.Windows.Forms.ColumnHeader();
            this.CarDeviceID = new System.Windows.Forms.ColumnHeader();
            this.CarPassTime = new System.Windows.Forms.ColumnHeader();
            this.CarLandID = new System.Windows.Forms.ColumnHeader();
            this.CarLicensePlate = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.RealStreamlabel = new System.Windows.Forms.Label();
            this.PicStreamlabel = new System.Windows.Forms.Label();
            this.TABcontrol_Login = new System.Windows.Forms.TabControl();
            this.Singleuser = new System.Windows.Forms.TabPage();
            this.UserLogin = new System.Windows.Forms.GroupBox();
            this.DeviceStatuslabel = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.logoutbutton = new System.Windows.Forms.Button();
            this.Loginbutton = new System.Windows.Forms.Button();
            this.PasswordtextBox = new System.Windows.Forms.TextBox();
            this.porttextBox = new System.Windows.Forms.TextBox();
            this.admintextBox = new System.Windows.Forms.TextBox();
            this.DeviceIPtextBox = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.Multiuser = new System.Windows.Forms.TabPage();
            this.LiveView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VID_STREAM)).BeginInit();
            this.PhotoView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PIC_STREAM)).BeginInit();
            this.mainTabCtrl.SuspendLayout();
            this.LocalFeatures.SuspendLayout();
            this.SetSDKLog.SuspendLayout();
            this.SDKInfo.SuspendLayout();
            this.LiveOperation.SuspendLayout();
            this.DataCallback.SuspendLayout();
            this.VideoRecording.SuspendLayout();
            this.LivePreview.SuspendLayout();
            this.PhotoOperation.SuspendLayout();
            this.PicturePreview.SuspendLayout();
            this.VechicleListOperation.SuspendLayout();
            this.VehicleRecordOperation.SuspendLayout();
            this.EntranceandExitVehicleListFile.SuspendLayout();
            this.Parameter.SuspendLayout();
            this.LiveviewOSDcunstomsetting.SuspendLayout();
            this.OSDContent.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.Getdevicecapability.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SystemMaintenance.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.NETInfo.SuspendLayout();
            this.VersionInfo.SuspendLayout();
            this.UserInfo.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.TABcontrol_Login.SuspendLayout();
            this.Singleuser.SuspendLayout();
            this.UserLogin.SuspendLayout();
            this.Multiuser.SuspendLayout();
            this.SuspendLayout();
            // 
            // LiveView
            // 
            this.LiveView.Controls.Add(this.VID_STREAM);
            this.LiveView.Location = new System.Drawing.Point(9, 26);
            this.LiveView.Margin = new System.Windows.Forms.Padding(2);
            this.LiveView.Name = "LiveView";
            this.LiveView.Padding = new System.Windows.Forms.Padding(2);
            this.LiveView.Size = new System.Drawing.Size(410, 251);
            this.LiveView.TabIndex = 0;
            this.LiveView.TabStop = false;
            this.LiveView.Text = "Live View";
            // 
            // VID_STREAM
            // 
            this.VID_STREAM.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.VID_STREAM.Location = new System.Drawing.Point(5, 19);
            this.VID_STREAM.Margin = new System.Windows.Forms.Padding(2);
            this.VID_STREAM.Name = "VID_STREAM";
            this.VID_STREAM.Size = new System.Drawing.Size(400, 240);
            this.VID_STREAM.TabIndex = 0;
            this.VID_STREAM.TabStop = false;
            // 
            // PhotoView
            // 
            this.PhotoView.Controls.Add(this.PIC_STREAM);
            this.PhotoView.Location = new System.Drawing.Point(9, 302);
            this.PhotoView.Margin = new System.Windows.Forms.Padding(2);
            this.PhotoView.Name = "PhotoView";
            this.PhotoView.Padding = new System.Windows.Forms.Padding(2);
            this.PhotoView.Size = new System.Drawing.Size(410, 258);
            this.PhotoView.TabIndex = 1;
            this.PhotoView.TabStop = false;
            this.PhotoView.Text = "Photo View";
            this.PhotoView.Enter += new System.EventHandler(this.PhotoView_Enter);
            // 
            // PIC_STREAM
            // 
            this.PIC_STREAM.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.PIC_STREAM.Location = new System.Drawing.Point(5, 20);
            this.PIC_STREAM.Margin = new System.Windows.Forms.Padding(2);
            this.PIC_STREAM.Name = "PIC_STREAM";
            this.PIC_STREAM.Size = new System.Drawing.Size(400, 243);
            this.PIC_STREAM.TabIndex = 0;
            this.PIC_STREAM.TabStop = false;
            // 
            // mainTabCtrl
            // 
            this.mainTabCtrl.Controls.Add(this.LocalFeatures);
            this.mainTabCtrl.Controls.Add(this.LiveOperation);
            this.mainTabCtrl.Controls.Add(this.PhotoOperation);
            this.mainTabCtrl.Controls.Add(this.VechicleListOperation);
            this.mainTabCtrl.Controls.Add(this.Parameter);
            this.mainTabCtrl.Controls.Add(this.SystemMaintenance);
            this.mainTabCtrl.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mainTabCtrl.Location = new System.Drawing.Point(424, 154);
            this.mainTabCtrl.Margin = new System.Windows.Forms.Padding(2);
            this.mainTabCtrl.Name = "mainTabCtrl";
            this.mainTabCtrl.SelectedIndex = 0;
            this.mainTabCtrl.Size = new System.Drawing.Size(664, 406);
            this.mainTabCtrl.TabIndex = 3;
            // 
            // LocalFeatures
            // 
            this.LocalFeatures.Controls.Add(this.SetSDKLog);
            this.LocalFeatures.Controls.Add(this.SDKInfo);
            this.LocalFeatures.Location = new System.Drawing.Point(4, 26);
            this.LocalFeatures.Margin = new System.Windows.Forms.Padding(2);
            this.LocalFeatures.Name = "LocalFeatures";
            this.LocalFeatures.Padding = new System.Windows.Forms.Padding(2);
            this.LocalFeatures.Size = new System.Drawing.Size(656, 376);
            this.LocalFeatures.TabIndex = 0;
            this.LocalFeatures.Text = "Local Features";
            this.LocalFeatures.UseVisualStyleBackColor = true;
            // 
            // SetSDKLog
            // 
            this.SetSDKLog.Controls.Add(this.SetlogPath);
            this.SetSDKLog.Controls.Add(this.SetlogSizeNum);
            this.SetSDKLog.Controls.Add(this.LogNumber);
            this.SetSDKLog.Controls.Add(this.LogSize);
            this.SetSDKLog.Controls.Add(this.LogPath);
            this.SetSDKLog.Controls.Add(this.label4);
            this.SetSDKLog.Controls.Add(this.label3);
            this.SetSDKLog.Controls.Add(this.label2);
            this.SetSDKLog.Location = new System.Drawing.Point(5, 197);
            this.SetSDKLog.Margin = new System.Windows.Forms.Padding(2);
            this.SetSDKLog.Name = "SetSDKLog";
            this.SetSDKLog.Padding = new System.Windows.Forms.Padding(2);
            this.SetSDKLog.Size = new System.Drawing.Size(649, 189);
            this.SetSDKLog.TabIndex = 1;
            this.SetSDKLog.TabStop = false;
            this.SetSDKLog.Text = "Set SDK Log";
            // 
            // SetlogPath
            // 
            this.SetlogPath.Location = new System.Drawing.Point(503, 105);
            this.SetlogPath.Margin = new System.Windows.Forms.Padding(2);
            this.SetlogPath.Name = "SetlogPath";
            this.SetlogPath.Size = new System.Drawing.Size(124, 26);
            this.SetlogPath.TabIndex = 8;
            this.SetlogPath.Text = "Set log Path";
            this.SetlogPath.UseVisualStyleBackColor = true;
            this.SetlogPath.Click += new System.EventHandler(this.SetlogPath_Click);
            // 
            // SetlogSizeNum
            // 
            this.SetlogSizeNum.Location = new System.Drawing.Point(503, 63);
            this.SetlogSizeNum.Margin = new System.Windows.Forms.Padding(2);
            this.SetlogSizeNum.Name = "SetlogSizeNum";
            this.SetlogSizeNum.Size = new System.Drawing.Size(124, 26);
            this.SetlogSizeNum.TabIndex = 7;
            this.SetlogSizeNum.Text = "Set log SizeNum";
            this.SetlogSizeNum.UseVisualStyleBackColor = true;
            this.SetlogSizeNum.Click += new System.EventHandler(this.SetlogSizeNum_Click);
            // 
            // LogNumber
            // 
            this.LogNumber.Location = new System.Drawing.Point(324, 65);
            this.LogNumber.Margin = new System.Windows.Forms.Padding(2);
            this.LogNumber.Name = "LogNumber";
            this.LogNumber.Size = new System.Drawing.Size(76, 23);
            this.LogNumber.TabIndex = 6;
            this.LogNumber.Text = "10";
            // 
            // LogSize
            // 
            this.LogSize.Location = new System.Drawing.Point(116, 65);
            this.LogSize.Margin = new System.Windows.Forms.Padding(2);
            this.LogSize.Name = "LogSize";
            this.LogSize.Size = new System.Drawing.Size(76, 23);
            this.LogSize.TabIndex = 5;
            this.LogSize.Text = "30";
            // 
            // LogPath
            // 
            this.LogPath.Location = new System.Drawing.Point(139, 109);
            this.LogPath.Margin = new System.Windows.Forms.Padding(2);
            this.LogPath.Name = "LogPath";
            this.LogPath.Size = new System.Drawing.Size(343, 23);
            this.LogPath.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 114);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "SDK log Path";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Size(MB)";
            // 
            // SDKInfo
            // 
            this.SDKInfo.Controls.Add(this.SetEncodingFormat);
            this.SDKInfo.Controls.Add(this.GetVersion);
            this.SDKInfo.Controls.Add(this.PlateencodingCombox);
            this.SDKInfo.Controls.Add(this.VersiontextBox);
            this.SDKInfo.Controls.Add(this.Plateencodingformat);
            this.SDKInfo.Controls.Add(this.SDKVersion);
            this.SDKInfo.Location = new System.Drawing.Point(5, 14);
            this.SDKInfo.Margin = new System.Windows.Forms.Padding(2);
            this.SDKInfo.Name = "SDKInfo";
            this.SDKInfo.Padding = new System.Windows.Forms.Padding(2);
            this.SDKInfo.Size = new System.Drawing.Size(647, 189);
            this.SDKInfo.TabIndex = 0;
            this.SDKInfo.TabStop = false;
            this.SDKInfo.Text = "SDKInfo";
            // 
            // SetEncodingFormat
            // 
            this.SetEncodingFormat.Location = new System.Drawing.Point(478, 100);
            this.SetEncodingFormat.Margin = new System.Windows.Forms.Padding(2);
            this.SetEncodingFormat.Name = "SetEncodingFormat";
            this.SetEncodingFormat.Size = new System.Drawing.Size(148, 26);
            this.SetEncodingFormat.TabIndex = 5;
            this.SetEncodingFormat.Text = "Set encoding format";
            this.SetEncodingFormat.UseVisualStyleBackColor = true;
            this.SetEncodingFormat.Click += new System.EventHandler(this.SetEncodingFormat_Click);
            // 
            // GetVersion
            // 
            this.GetVersion.Location = new System.Drawing.Point(516, 39);
            this.GetVersion.Margin = new System.Windows.Forms.Padding(2);
            this.GetVersion.Name = "GetVersion";
            this.GetVersion.Size = new System.Drawing.Size(110, 26);
            this.GetVersion.TabIndex = 4;
            this.GetVersion.Text = "Get Version";
            this.GetVersion.UseVisualStyleBackColor = true;
            this.GetVersion.Click += new System.EventHandler(this.GetVersion_Click);
            // 
            // PlateencodingCombox
            // 
            this.PlateencodingCombox.FormattingEnabled = true;
            this.PlateencodingCombox.Location = new System.Drawing.Point(178, 101);
            this.PlateencodingCombox.Margin = new System.Windows.Forms.Padding(2);
            this.PlateencodingCombox.Name = "PlateencodingCombox";
            this.PlateencodingCombox.Size = new System.Drawing.Size(92, 25);
            this.PlateencodingCombox.TabIndex = 3;
            this.PlateencodingCombox.Text = "UTF-8";
            // 
            // VersiontextBox
            // 
            this.VersiontextBox.Location = new System.Drawing.Point(116, 43);
            this.VersiontextBox.Margin = new System.Windows.Forms.Padding(2);
            this.VersiontextBox.Name = "VersiontextBox";
            this.VersiontextBox.Size = new System.Drawing.Size(334, 23);
            this.VersiontextBox.TabIndex = 2;
            // 
            // Plateencodingformat
            // 
            this.Plateencodingformat.AutoSize = true;
            this.Plateencodingformat.Location = new System.Drawing.Point(28, 101);
            this.Plateencodingformat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Plateencodingformat.Name = "Plateencodingformat";
            this.Plateencodingformat.Size = new System.Drawing.Size(137, 17);
            this.Plateencodingformat.TabIndex = 1;
            this.Plateencodingformat.Text = "Plate encoding format";
            // 
            // SDKVersion
            // 
            this.SDKVersion.AutoSize = true;
            this.SDKVersion.Location = new System.Drawing.Point(28, 48);
            this.SDKVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SDKVersion.Name = "SDKVersion";
            this.SDKVersion.Size = new System.Drawing.Size(76, 17);
            this.SDKVersion.TabIndex = 0;
            this.SDKVersion.Text = "SDKVersion";
            // 
            // LiveOperation
            // 
            this.LiveOperation.Controls.Add(this.DataCallback);
            this.LiveOperation.Controls.Add(this.VideoRecording);
            this.LiveOperation.Controls.Add(this.LivePreview);
            this.LiveOperation.Location = new System.Drawing.Point(4, 26);
            this.LiveOperation.Margin = new System.Windows.Forms.Padding(2);
            this.LiveOperation.Name = "LiveOperation";
            this.LiveOperation.Padding = new System.Windows.Forms.Padding(2);
            this.LiveOperation.Size = new System.Drawing.Size(656, 376);
            this.LiveOperation.TabIndex = 1;
            this.LiveOperation.Text = "Live Operation";
            this.LiveOperation.UseVisualStyleBackColor = true;
            // 
            // DataCallback
            // 
            this.DataCallback.Controls.Add(this.LiveDataReset);
            this.DataCallback.Controls.Add(this.LiveDataSetCallback);
            this.DataCallback.Controls.Add(this.LiveDataFormatcomboBox);
            this.DataCallback.Controls.Add(this.LiveDataFormat);
            this.DataCallback.Location = new System.Drawing.Point(8, 282);
            this.DataCallback.Margin = new System.Windows.Forms.Padding(2);
            this.DataCallback.Name = "DataCallback";
            this.DataCallback.Padding = new System.Windows.Forms.Padding(2);
            this.DataCallback.Size = new System.Drawing.Size(620, 80);
            this.DataCallback.TabIndex = 2;
            this.DataCallback.TabStop = false;
            this.DataCallback.Text = "Data Callback";
            // 
            // LiveDataReset
            // 
            this.LiveDataReset.Location = new System.Drawing.Point(497, 42);
            this.LiveDataReset.Margin = new System.Windows.Forms.Padding(2);
            this.LiveDataReset.Name = "LiveDataReset";
            this.LiveDataReset.Size = new System.Drawing.Size(98, 22);
            this.LiveDataReset.TabIndex = 3;
            this.LiveDataReset.Text = "Reset";
            this.LiveDataReset.UseVisualStyleBackColor = true;
            this.LiveDataReset.Click += new System.EventHandler(this.LiveDataReset_Click);
            // 
            // LiveDataSetCallback
            // 
            this.LiveDataSetCallback.Location = new System.Drawing.Point(365, 43);
            this.LiveDataSetCallback.Margin = new System.Windows.Forms.Padding(2);
            this.LiveDataSetCallback.Name = "LiveDataSetCallback";
            this.LiveDataSetCallback.Size = new System.Drawing.Size(98, 22);
            this.LiveDataSetCallback.TabIndex = 2;
            this.LiveDataSetCallback.Text = "Set Callback";
            this.LiveDataSetCallback.UseVisualStyleBackColor = true;
            this.LiveDataSetCallback.Click += new System.EventHandler(this.LiveDataSetCallback_Click);
            // 
            // LiveDataFormatcomboBox
            // 
            this.LiveDataFormatcomboBox.FormattingEnabled = true;
            this.LiveDataFormatcomboBox.Location = new System.Drawing.Point(124, 43);
            this.LiveDataFormatcomboBox.Margin = new System.Windows.Forms.Padding(2);
            this.LiveDataFormatcomboBox.Name = "LiveDataFormatcomboBox";
            this.LiveDataFormatcomboBox.Size = new System.Drawing.Size(189, 25);
            this.LiveDataFormatcomboBox.TabIndex = 1;
            this.LiveDataFormatcomboBox.Text = "Parse video data";
            // 
            // LiveDataFormat
            // 
            this.LiveDataFormat.AutoSize = true;
            this.LiveDataFormat.Location = new System.Drawing.Point(48, 43);
            this.LiveDataFormat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LiveDataFormat.Name = "LiveDataFormat";
            this.LiveDataFormat.Size = new System.Drawing.Size(49, 17);
            this.LiveDataFormat.TabIndex = 0;
            this.LiveDataFormat.Text = "Format";
            // 
            // VideoRecording
            // 
            this.VideoRecording.Controls.Add(this.StopRecording);
            this.VideoRecording.Controls.Add(this.StartRecording);
            this.VideoRecording.Controls.Add(this.LiveRecordcomboBox);
            this.VideoRecording.Controls.Add(this.LiveRecordingSavePath);
            this.VideoRecording.Controls.Add(this.Format);
            this.VideoRecording.Controls.Add(this.SavePath);
            this.VideoRecording.Location = new System.Drawing.Point(8, 105);
            this.VideoRecording.Margin = new System.Windows.Forms.Padding(2);
            this.VideoRecording.Name = "VideoRecording";
            this.VideoRecording.Padding = new System.Windows.Forms.Padding(2);
            this.VideoRecording.Size = new System.Drawing.Size(620, 172);
            this.VideoRecording.TabIndex = 1;
            this.VideoRecording.TabStop = false;
            this.VideoRecording.Text = "Video Recording";
            // 
            // StopRecording
            // 
            this.StopRecording.Location = new System.Drawing.Point(487, 93);
            this.StopRecording.Margin = new System.Windows.Forms.Padding(2);
            this.StopRecording.Name = "StopRecording";
            this.StopRecording.Size = new System.Drawing.Size(118, 29);
            this.StopRecording.TabIndex = 5;
            this.StopRecording.Text = "Stop Recording";
            this.StopRecording.UseVisualStyleBackColor = true;
            this.StopRecording.Click += new System.EventHandler(this.StopRecording_Click);
            // 
            // StartRecording
            // 
            this.StartRecording.Location = new System.Drawing.Point(487, 41);
            this.StartRecording.Margin = new System.Windows.Forms.Padding(2);
            this.StartRecording.Name = "StartRecording";
            this.StartRecording.Size = new System.Drawing.Size(118, 29);
            this.StartRecording.TabIndex = 4;
            this.StartRecording.Text = "Start Recording";
            this.StartRecording.UseVisualStyleBackColor = true;
            this.StartRecording.Click += new System.EventHandler(this.StartRecording_Click);
            // 
            // LiveRecordcomboBox
            // 
            this.LiveRecordcomboBox.FormattingEnabled = true;
            this.LiveRecordcomboBox.Location = new System.Drawing.Point(124, 95);
            this.LiveRecordcomboBox.Margin = new System.Windows.Forms.Padding(2);
            this.LiveRecordcomboBox.Name = "LiveRecordcomboBox";
            this.LiveRecordcomboBox.Size = new System.Drawing.Size(189, 25);
            this.LiveRecordcomboBox.TabIndex = 3;
            this.LiveRecordcomboBox.Text = "MP4(audio+video).mp4";
            // 
            // LiveRecordingSavePath
            // 
            this.LiveRecordingSavePath.Location = new System.Drawing.Point(124, 46);
            this.LiveRecordingSavePath.Margin = new System.Windows.Forms.Padding(2);
            this.LiveRecordingSavePath.Name = "LiveRecordingSavePath";
            this.LiveRecordingSavePath.Size = new System.Drawing.Size(326, 23);
            this.LiveRecordingSavePath.TabIndex = 2;
            // 
            // Format
            // 
            this.Format.AutoSize = true;
            this.Format.Location = new System.Drawing.Point(45, 98);
            this.Format.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Format.Name = "Format";
            this.Format.Size = new System.Drawing.Size(49, 17);
            this.Format.TabIndex = 1;
            this.Format.Text = "Format";
            // 
            // SavePath
            // 
            this.SavePath.AutoSize = true;
            this.SavePath.Location = new System.Drawing.Point(42, 52);
            this.SavePath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SavePath.Name = "SavePath";
            this.SavePath.Size = new System.Drawing.Size(64, 17);
            this.SavePath.TabIndex = 0;
            this.SavePath.Text = "Save Path";
            // 
            // LivePreview
            // 
            this.LivePreview.Controls.Add(this.Snapshot);
            this.LivePreview.Controls.Add(this.LiveClose);
            this.LivePreview.Controls.Add(this.LiveOpen);
            this.LivePreview.Location = new System.Drawing.Point(5, 6);
            this.LivePreview.Margin = new System.Windows.Forms.Padding(2);
            this.LivePreview.Name = "LivePreview";
            this.LivePreview.Padding = new System.Windows.Forms.Padding(2);
            this.LivePreview.Size = new System.Drawing.Size(622, 94);
            this.LivePreview.TabIndex = 0;
            this.LivePreview.TabStop = false;
            this.LivePreview.Text = "Live Preview";
            // 
            // Snapshot
            // 
            this.Snapshot.Location = new System.Drawing.Point(344, 42);
            this.Snapshot.Margin = new System.Windows.Forms.Padding(2);
            this.Snapshot.Name = "Snapshot";
            this.Snapshot.Size = new System.Drawing.Size(92, 25);
            this.Snapshot.TabIndex = 2;
            this.Snapshot.Text = "Snapshot";
            this.Snapshot.UseVisualStyleBackColor = true;
            this.Snapshot.Click += new System.EventHandler(this.Snapshot_Click);
            // 
            // LiveClose
            // 
            this.LiveClose.Location = new System.Drawing.Point(201, 42);
            this.LiveClose.Margin = new System.Windows.Forms.Padding(2);
            this.LiveClose.Name = "LiveClose";
            this.LiveClose.Size = new System.Drawing.Size(92, 25);
            this.LiveClose.TabIndex = 1;
            this.LiveClose.Text = "Close";
            this.LiveClose.UseVisualStyleBackColor = true;
            this.LiveClose.Click += new System.EventHandler(this.LiveClose_Click);
            // 
            // LiveOpen
            // 
            this.LiveOpen.Location = new System.Drawing.Point(44, 42);
            this.LiveOpen.Margin = new System.Windows.Forms.Padding(2);
            this.LiveOpen.Name = "LiveOpen";
            this.LiveOpen.Size = new System.Drawing.Size(92, 25);
            this.LiveOpen.TabIndex = 0;
            this.LiveOpen.Text = "Open";
            this.LiveOpen.UseVisualStyleBackColor = true;
            this.LiveOpen.Click += new System.EventHandler(this.LiveOpen_Click);
            // 
            // PhotoOperation
            // 
            this.PhotoOperation.Controls.Add(this.PhotoListView);
            this.PhotoOperation.Controls.Add(this.PicturePreview);
            this.PhotoOperation.Location = new System.Drawing.Point(4, 26);
            this.PhotoOperation.Margin = new System.Windows.Forms.Padding(2);
            this.PhotoOperation.Name = "PhotoOperation";
            this.PhotoOperation.Size = new System.Drawing.Size(656, 376);
            this.PhotoOperation.TabIndex = 2;
            this.PhotoOperation.Text = "Photo Operation";
            this.PhotoOperation.UseVisualStyleBackColor = true;
            // 
            // PhotoListView
            // 
            this.PhotoListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DeviceID,
            this.PassTime,
            this.LaneID,
            this.PlateColor,
            this.LicensePlate,
            this.CapatureSys});
            this.PhotoListView.FullRowSelect = true;
            this.PhotoListView.GridLines = true;
            this.PhotoListView.Location = new System.Drawing.Point(3, 134);
            this.PhotoListView.Margin = new System.Windows.Forms.Padding(2);
            this.PhotoListView.Name = "PhotoListView";
            this.PhotoListView.Size = new System.Drawing.Size(628, 250);
            this.PhotoListView.TabIndex = 1;
            this.PhotoListView.UseCompatibleStateImageBehavior = false;
            this.PhotoListView.View = System.Windows.Forms.View.Details;
            // 
            // DeviceID
            // 
            this.DeviceID.Text = "DeviceID";
            this.DeviceID.Width = 94;
            // 
            // PassTime
            // 
            this.PassTime.Text = "PassTime";
            this.PassTime.Width = 89;
            // 
            // LaneID
            // 
            this.LaneID.Text = "LaneID";
            this.LaneID.Width = 87;
            // 
            // PlateColor
            // 
            this.PlateColor.Text = "Plate Color";
            this.PlateColor.Width = 115;
            // 
            // LicensePlate
            // 
            this.LicensePlate.Text = "License Plate";
            this.LicensePlate.Width = 138;
            // 
            // CapatureSys
            // 
            this.CapatureSys.Text = "CapatureSys";
            this.CapatureSys.Width = 186;
            // 
            // PicturePreview
            // 
            this.PicturePreview.Controls.Add(this.PhotoCaptureSys);
            this.PicturePreview.Controls.Add(this.PhotoCapture);
            this.PicturePreview.Controls.Add(this.PhotoClose);
            this.PicturePreview.Controls.Add(this.PhotoOpen);
            this.PicturePreview.Location = new System.Drawing.Point(2, 2);
            this.PicturePreview.Margin = new System.Windows.Forms.Padding(2);
            this.PicturePreview.Name = "PicturePreview";
            this.PicturePreview.Padding = new System.Windows.Forms.Padding(2);
            this.PicturePreview.Size = new System.Drawing.Size(628, 126);
            this.PicturePreview.TabIndex = 0;
            this.PicturePreview.TabStop = false;
            this.PicturePreview.Text = "Picture Preview";
            this.PicturePreview.Enter += new System.EventHandler(this.PicturePreview_Enter);
            // 
            // PhotoCaptureSys
            // 
            this.PhotoCaptureSys.Location = new System.Drawing.Point(484, 53);
            this.PhotoCaptureSys.Margin = new System.Windows.Forms.Padding(2);
            this.PhotoCaptureSys.Name = "PhotoCaptureSys";
            this.PhotoCaptureSys.Size = new System.Drawing.Size(89, 25);
            this.PhotoCaptureSys.TabIndex = 3;
            this.PhotoCaptureSys.Text = "CaptureSys";
            this.PhotoCaptureSys.UseVisualStyleBackColor = true;
            this.PhotoCaptureSys.Click += new System.EventHandler(this.PhotoCaptureSys_Click);
            // 
            // PhotoCapture
            // 
            this.PhotoCapture.Location = new System.Drawing.Point(340, 53);
            this.PhotoCapture.Margin = new System.Windows.Forms.Padding(2);
            this.PhotoCapture.Name = "PhotoCapture";
            this.PhotoCapture.Size = new System.Drawing.Size(89, 25);
            this.PhotoCapture.TabIndex = 2;
            this.PhotoCapture.Text = "Capture";
            this.PhotoCapture.UseVisualStyleBackColor = true;
            this.PhotoCapture.Click += new System.EventHandler(this.PhotoCapture_Click);
            // 
            // PhotoClose
            // 
            this.PhotoClose.Location = new System.Drawing.Point(193, 53);
            this.PhotoClose.Margin = new System.Windows.Forms.Padding(2);
            this.PhotoClose.Name = "PhotoClose";
            this.PhotoClose.Size = new System.Drawing.Size(89, 25);
            this.PhotoClose.TabIndex = 1;
            this.PhotoClose.Text = "Close";
            this.PhotoClose.UseVisualStyleBackColor = true;
            this.PhotoClose.Click += new System.EventHandler(this.PhotoClose_Click);
            // 
            // PhotoOpen
            // 
            this.PhotoOpen.Location = new System.Drawing.Point(36, 53);
            this.PhotoOpen.Margin = new System.Windows.Forms.Padding(2);
            this.PhotoOpen.Name = "PhotoOpen";
            this.PhotoOpen.Size = new System.Drawing.Size(89, 25);
            this.PhotoOpen.TabIndex = 0;
            this.PhotoOpen.Text = "Open";
            this.PhotoOpen.UseVisualStyleBackColor = true;
            this.PhotoOpen.Click += new System.EventHandler(this.PhotoOpen_Click);
            // 
            // VechicleListOperation
            // 
            this.VechicleListOperation.Controls.Add(this.VehicleRecordOperation);
            this.VechicleListOperation.Controls.Add(this.EntranceandExitVehicleListFile);
            this.VechicleListOperation.Location = new System.Drawing.Point(4, 26);
            this.VechicleListOperation.Margin = new System.Windows.Forms.Padding(2);
            this.VechicleListOperation.Name = "VechicleListOperation";
            this.VechicleListOperation.Size = new System.Drawing.Size(656, 376);
            this.VechicleListOperation.TabIndex = 3;
            this.VechicleListOperation.Text = "VechicleList Operation";
            this.VechicleListOperation.UseVisualStyleBackColor = true;
            // 
            // VehicleRecordOperation
            // 
            this.VehicleRecordOperation.Controls.Add(this.ExpirationTime);
            this.VehicleRecordOperation.Controls.Add(this.EffectiveTime);
            this.VehicleRecordOperation.Controls.Add(this.ExpirationDate);
            this.VehicleRecordOperation.Controls.Add(this.EffectiveData);
            this.VehicleRecordOperation.Controls.Add(this.DeleteRecord);
            this.VehicleRecordOperation.Controls.Add(this.ModifyRecord);
            this.VehicleRecordOperation.Controls.Add(this.AddRecord);
            this.VehicleRecordOperation.Controls.Add(this.BlockListradioButton);
            this.VehicleRecordOperation.Controls.Add(this.AllowListradioButton);
            this.VehicleRecordOperation.Controls.Add(this.VechicleListNotextBox);
            this.VehicleRecordOperation.Controls.Add(this.VechicleListIDtextBox);
            this.VehicleRecordOperation.Controls.Add(this.VechicleListExpirationTime);
            this.VehicleRecordOperation.Controls.Add(this.VechicleListEffectiveTime);
            this.VehicleRecordOperation.Controls.Add(this.VechicleListPlateNo);
            this.VehicleRecordOperation.Controls.Add(this.VechicleListID);
            this.VehicleRecordOperation.Location = new System.Drawing.Point(3, 178);
            this.VehicleRecordOperation.Margin = new System.Windows.Forms.Padding(2);
            this.VehicleRecordOperation.Name = "VehicleRecordOperation";
            this.VehicleRecordOperation.Padding = new System.Windows.Forms.Padding(2);
            this.VehicleRecordOperation.Size = new System.Drawing.Size(627, 204);
            this.VehicleRecordOperation.TabIndex = 1;
            this.VehicleRecordOperation.TabStop = false;
            this.VehicleRecordOperation.Text = "VehicleRecord Operation";
            // 
            // ExpirationTime
            // 
            this.ExpirationTime.CustomFormat = "HH:mm:ss";
            this.ExpirationTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ExpirationTime.Location = new System.Drawing.Point(256, 148);
            this.ExpirationTime.Margin = new System.Windows.Forms.Padding(2);
            this.ExpirationTime.Name = "ExpirationTime";
            this.ExpirationTime.ShowUpDown = true;
            this.ExpirationTime.Size = new System.Drawing.Size(109, 23);
            this.ExpirationTime.TabIndex = 14;
            // 
            // EffectiveTime
            // 
            this.EffectiveTime.CustomFormat = "HH:mm:ss";
            this.EffectiveTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EffectiveTime.Location = new System.Drawing.Point(256, 110);
            this.EffectiveTime.Margin = new System.Windows.Forms.Padding(2);
            this.EffectiveTime.Name = "EffectiveTime";
            this.EffectiveTime.ShowUpDown = true;
            this.EffectiveTime.Size = new System.Drawing.Size(109, 23);
            this.EffectiveTime.TabIndex = 15;
            // 
            // ExpirationDate
            // 
            this.ExpirationDate.CustomFormat = "yyyy/MM/dd";
            this.ExpirationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ExpirationDate.Location = new System.Drawing.Point(130, 148);
            this.ExpirationDate.Margin = new System.Windows.Forms.Padding(2);
            this.ExpirationDate.Name = "ExpirationDate";
            this.ExpirationDate.Size = new System.Drawing.Size(109, 23);
            this.ExpirationDate.TabIndex = 14;
            // 
            // EffectiveData
            // 
            this.EffectiveData.CustomFormat = "yyyy/MM/dd";
            this.EffectiveData.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EffectiveData.Location = new System.Drawing.Point(129, 110);
            this.EffectiveData.Margin = new System.Windows.Forms.Padding(2);
            this.EffectiveData.Name = "EffectiveData";
            this.EffectiveData.Size = new System.Drawing.Size(109, 23);
            this.EffectiveData.TabIndex = 13;
            // 
            // DeleteRecord
            // 
            this.DeleteRecord.Location = new System.Drawing.Point(434, 148);
            this.DeleteRecord.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteRecord.Name = "DeleteRecord";
            this.DeleteRecord.Size = new System.Drawing.Size(102, 23);
            this.DeleteRecord.TabIndex = 12;
            this.DeleteRecord.Text = "Delete Record";
            this.DeleteRecord.UseVisualStyleBackColor = true;
            this.DeleteRecord.Click += new System.EventHandler(this.DeleteRecord_Click);
            // 
            // ModifyRecord
            // 
            this.ModifyRecord.Location = new System.Drawing.Point(434, 110);
            this.ModifyRecord.Margin = new System.Windows.Forms.Padding(2);
            this.ModifyRecord.Name = "ModifyRecord";
            this.ModifyRecord.Size = new System.Drawing.Size(102, 23);
            this.ModifyRecord.TabIndex = 11;
            this.ModifyRecord.Text = "Modify Record";
            this.ModifyRecord.UseVisualStyleBackColor = true;
            this.ModifyRecord.Click += new System.EventHandler(this.ModifyRecord_Click);
            // 
            // AddRecord
            // 
            this.AddRecord.Location = new System.Drawing.Point(434, 38);
            this.AddRecord.Margin = new System.Windows.Forms.Padding(2);
            this.AddRecord.Name = "AddRecord";
            this.AddRecord.Size = new System.Drawing.Size(102, 26);
            this.AddRecord.TabIndex = 10;
            this.AddRecord.Text = "Add Record";
            this.AddRecord.UseVisualStyleBackColor = true;
            this.AddRecord.Click += new System.EventHandler(this.AddRecord_Click);
            // 
            // BlockListradioButton
            // 
            this.BlockListradioButton.AutoSize = true;
            this.BlockListradioButton.Location = new System.Drawing.Point(338, 40);
            this.BlockListradioButton.Margin = new System.Windows.Forms.Padding(2);
            this.BlockListradioButton.Name = "BlockListradioButton";
            this.BlockListradioButton.Size = new System.Drawing.Size(77, 21);
            this.BlockListradioButton.TabIndex = 9;
            this.BlockListradioButton.TabStop = true;
            this.BlockListradioButton.Text = "BlockList";
            this.BlockListradioButton.UseVisualStyleBackColor = true;
            this.BlockListradioButton.CheckedChanged += new System.EventHandler(this.BlockListradioButton_CheckedChanged);
            // 
            // AllowListradioButton
            // 
            this.AllowListradioButton.AutoSize = true;
            this.AllowListradioButton.Location = new System.Drawing.Point(256, 40);
            this.AllowListradioButton.Margin = new System.Windows.Forms.Padding(2);
            this.AllowListradioButton.Name = "AllowListradioButton";
            this.AllowListradioButton.Size = new System.Drawing.Size(76, 21);
            this.AllowListradioButton.TabIndex = 8;
            this.AllowListradioButton.TabStop = true;
            this.AllowListradioButton.Text = "AllowList";
            this.AllowListradioButton.UseVisualStyleBackColor = true;
            this.AllowListradioButton.CheckedChanged += new System.EventHandler(this.AllowListradioButton_CheckedChanged);
            // 
            // VechicleListNotextBox
            // 
            this.VechicleListNotextBox.Location = new System.Drawing.Point(130, 74);
            this.VechicleListNotextBox.Margin = new System.Windows.Forms.Padding(2);
            this.VechicleListNotextBox.Name = "VechicleListNotextBox";
            this.VechicleListNotextBox.Size = new System.Drawing.Size(93, 23);
            this.VechicleListNotextBox.TabIndex = 5;
            this.VechicleListNotextBox.Text = "A1234";
            // 
            // VechicleListIDtextBox
            // 
            this.VechicleListIDtextBox.Location = new System.Drawing.Point(130, 37);
            this.VechicleListIDtextBox.Margin = new System.Windows.Forms.Padding(2);
            this.VechicleListIDtextBox.Name = "VechicleListIDtextBox";
            this.VechicleListIDtextBox.Size = new System.Drawing.Size(93, 23);
            this.VechicleListIDtextBox.TabIndex = 4;
            this.VechicleListIDtextBox.Text = "1";
            // 
            // VechicleListExpirationTime
            // 
            this.VechicleListExpirationTime.AutoSize = true;
            this.VechicleListExpirationTime.Location = new System.Drawing.Point(29, 154);
            this.VechicleListExpirationTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.VechicleListExpirationTime.Name = "VechicleListExpirationTime";
            this.VechicleListExpirationTime.Size = new System.Drawing.Size(94, 17);
            this.VechicleListExpirationTime.TabIndex = 3;
            this.VechicleListExpirationTime.Text = "ExpirationTime";
            // 
            // VechicleListEffectiveTime
            // 
            this.VechicleListEffectiveTime.AutoSize = true;
            this.VechicleListEffectiveTime.Location = new System.Drawing.Point(29, 116);
            this.VechicleListEffectiveTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.VechicleListEffectiveTime.Name = "VechicleListEffectiveTime";
            this.VechicleListEffectiveTime.Size = new System.Drawing.Size(84, 17);
            this.VechicleListEffectiveTime.TabIndex = 2;
            this.VechicleListEffectiveTime.Text = "EffectiveTime";
            // 
            // VechicleListPlateNo
            // 
            this.VechicleListPlateNo.AutoSize = true;
            this.VechicleListPlateNo.Location = new System.Drawing.Point(29, 78);
            this.VechicleListPlateNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.VechicleListPlateNo.Name = "VechicleListPlateNo";
            this.VechicleListPlateNo.Size = new System.Drawing.Size(54, 17);
            this.VechicleListPlateNo.TabIndex = 1;
            this.VechicleListPlateNo.Text = "PlateNo";
            // 
            // VechicleListID
            // 
            this.VechicleListID.AutoSize = true;
            this.VechicleListID.Location = new System.Drawing.Point(29, 40);
            this.VechicleListID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.VechicleListID.Name = "VechicleListID";
            this.VechicleListID.Size = new System.Drawing.Size(21, 17);
            this.VechicleListID.TabIndex = 0;
            this.VechicleListID.Text = "ID";
            // 
            // EntranceandExitVehicleListFile
            // 
            this.EntranceandExitVehicleListFile.Controls.Add(this.VehicleListBlockExport);
            this.EntranceandExitVehicleListFile.Controls.Add(this.VechicleListImport);
            this.EntranceandExitVehicleListFile.Controls.Add(this.VechicleListBrowse);
            this.EntranceandExitVehicleListFile.Controls.Add(this.VehicleListAllowExport);
            this.EntranceandExitVehicleListFile.Controls.Add(this.VechicleListFilePath);
            this.EntranceandExitVehicleListFile.Controls.Add(this.ExportBlocklistFile);
            this.EntranceandExitVehicleListFile.Controls.Add(this.ExportAllowlistFile);
            this.EntranceandExitVehicleListFile.Controls.Add(this.ImportFile);
            this.EntranceandExitVehicleListFile.Location = new System.Drawing.Point(3, 3);
            this.EntranceandExitVehicleListFile.Margin = new System.Windows.Forms.Padding(2);
            this.EntranceandExitVehicleListFile.Name = "EntranceandExitVehicleListFile";
            this.EntranceandExitVehicleListFile.Padding = new System.Windows.Forms.Padding(2);
            this.EntranceandExitVehicleListFile.Size = new System.Drawing.Size(627, 170);
            this.EntranceandExitVehicleListFile.TabIndex = 0;
            this.EntranceandExitVehicleListFile.TabStop = false;
            this.EntranceandExitVehicleListFile.Text = "Entrance and Exit VehicleList File";
            // 
            // VehicleListBlockExport
            // 
            this.VehicleListBlockExport.Location = new System.Drawing.Point(496, 94);
            this.VehicleListBlockExport.Margin = new System.Windows.Forms.Padding(2);
            this.VehicleListBlockExport.Name = "VehicleListBlockExport";
            this.VehicleListBlockExport.Size = new System.Drawing.Size(76, 23);
            this.VehicleListBlockExport.TabIndex = 7;
            this.VehicleListBlockExport.Text = "Export";
            this.VehicleListBlockExport.UseVisualStyleBackColor = true;
            this.VehicleListBlockExport.Click += new System.EventHandler(this.VehicleListBlockExport_Click);
            // 
            // VechicleListImport
            // 
            this.VechicleListImport.Location = new System.Drawing.Point(517, 33);
            this.VechicleListImport.Margin = new System.Windows.Forms.Padding(2);
            this.VechicleListImport.Name = "VechicleListImport";
            this.VechicleListImport.Size = new System.Drawing.Size(76, 23);
            this.VechicleListImport.TabIndex = 6;
            this.VechicleListImport.Text = "Import";
            this.VechicleListImport.UseVisualStyleBackColor = true;
            this.VechicleListImport.Click += new System.EventHandler(this.VechicleListImport_Click);
            // 
            // VechicleListBrowse
            // 
            this.VechicleListBrowse.Location = new System.Drawing.Point(422, 33);
            this.VechicleListBrowse.Margin = new System.Windows.Forms.Padding(2);
            this.VechicleListBrowse.Name = "VechicleListBrowse";
            this.VechicleListBrowse.Size = new System.Drawing.Size(76, 23);
            this.VechicleListBrowse.TabIndex = 5;
            this.VechicleListBrowse.Text = "Browse";
            this.VechicleListBrowse.UseVisualStyleBackColor = true;
            this.VechicleListBrowse.Click += new System.EventHandler(this.VechicleListBrowse_Click);
            // 
            // VehicleListAllowExport
            // 
            this.VehicleListAllowExport.Location = new System.Drawing.Point(161, 94);
            this.VehicleListAllowExport.Margin = new System.Windows.Forms.Padding(2);
            this.VehicleListAllowExport.Name = "VehicleListAllowExport";
            this.VehicleListAllowExport.Size = new System.Drawing.Size(76, 23);
            this.VehicleListAllowExport.TabIndex = 4;
            this.VehicleListAllowExport.Text = "Export";
            this.VehicleListAllowExport.UseVisualStyleBackColor = true;
            this.VehicleListAllowExport.Click += new System.EventHandler(this.VehicleListAllowExport_Click);
            // 
            // VechicleListFilePath
            // 
            this.VechicleListFilePath.Location = new System.Drawing.Point(118, 35);
            this.VechicleListFilePath.Margin = new System.Windows.Forms.Padding(2);
            this.VechicleListFilePath.Name = "VechicleListFilePath";
            this.VechicleListFilePath.Size = new System.Drawing.Size(292, 23);
            this.VechicleListFilePath.TabIndex = 3;
            // 
            // ExportBlocklistFile
            // 
            this.ExportBlocklistFile.AutoSize = true;
            this.ExportBlocklistFile.Location = new System.Drawing.Point(366, 100);
            this.ExportBlocklistFile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ExportBlocklistFile.Name = "ExportBlocklistFile";
            this.ExportBlocklistFile.Size = new System.Drawing.Size(121, 17);
            this.ExportBlocklistFile.TabIndex = 2;
            this.ExportBlocklistFile.Text = "Export Blocklist File";
            // 
            // ExportAllowlistFile
            // 
            this.ExportAllowlistFile.AutoSize = true;
            this.ExportAllowlistFile.Location = new System.Drawing.Point(29, 100);
            this.ExportAllowlistFile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ExportAllowlistFile.Name = "ExportAllowlistFile";
            this.ExportAllowlistFile.Size = new System.Drawing.Size(120, 17);
            this.ExportAllowlistFile.TabIndex = 1;
            this.ExportAllowlistFile.Text = "Export Allowlist File";
            // 
            // ImportFile
            // 
            this.ImportFile.AutoSize = true;
            this.ImportFile.Location = new System.Drawing.Point(26, 40);
            this.ImportFile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ImportFile.Name = "ImportFile";
            this.ImportFile.Size = new System.Drawing.Size(71, 17);
            this.ImportFile.TabIndex = 0;
            this.ImportFile.Text = "Import File";
            // 
            // Parameter
            // 
            this.Parameter.Controls.Add(this.LiveviewOSDcunstomsetting);
            this.Parameter.Controls.Add(this.Getdevicecapability);
            this.Parameter.Controls.Add(this.groupBox3);
            this.Parameter.Location = new System.Drawing.Point(4, 26);
            this.Parameter.Margin = new System.Windows.Forms.Padding(2);
            this.Parameter.Name = "Parameter";
            this.Parameter.Size = new System.Drawing.Size(656, 376);
            this.Parameter.TabIndex = 4;
            this.Parameter.Text = "Parameter";
            this.Parameter.UseVisualStyleBackColor = true;
            // 
            // LiveviewOSDcunstomsetting
            // 
            this.LiveviewOSDcunstomsetting.Controls.Add(this.OSDContent);
            this.LiveviewOSDcunstomsetting.Controls.Add(this.groupBox4);
            this.LiveviewOSDcunstomsetting.Location = new System.Drawing.Point(3, 206);
            this.LiveviewOSDcunstomsetting.Margin = new System.Windows.Forms.Padding(2);
            this.LiveviewOSDcunstomsetting.Name = "LiveviewOSDcunstomsetting";
            this.LiveviewOSDcunstomsetting.Padding = new System.Windows.Forms.Padding(2);
            this.LiveviewOSDcunstomsetting.Size = new System.Drawing.Size(620, 170);
            this.LiveviewOSDcunstomsetting.TabIndex = 2;
            this.LiveviewOSDcunstomsetting.TabStop = false;
            this.LiveviewOSDcunstomsetting.Text = "Live view OSD Cunstom setting";
            // 
            // OSDContent
            // 
            this.OSDContent.Controls.Add(this.SettingOSDContent);
            this.OSDContent.Controls.Add(this.OSDContenttextBox);
            this.OSDContent.Location = new System.Drawing.Point(379, 32);
            this.OSDContent.Margin = new System.Windows.Forms.Padding(2);
            this.OSDContent.Name = "OSDContent";
            this.OSDContent.Padding = new System.Windows.Forms.Padding(2);
            this.OSDContent.Size = new System.Drawing.Size(236, 138);
            this.OSDContent.TabIndex = 1;
            this.OSDContent.TabStop = false;
            this.OSDContent.Text = "OSD Content";
            // 
            // SettingOSDContent
            // 
            this.SettingOSDContent.Location = new System.Drawing.Point(163, 89);
            this.SettingOSDContent.Margin = new System.Windows.Forms.Padding(2);
            this.SettingOSDContent.Name = "SettingOSDContent";
            this.SettingOSDContent.Size = new System.Drawing.Size(62, 23);
            this.SettingOSDContent.TabIndex = 1;
            this.SettingOSDContent.Text = "Set";
            this.SettingOSDContent.UseVisualStyleBackColor = true;
            this.SettingOSDContent.Click += new System.EventHandler(this.SettingOSDContent_Click);
            // 
            // OSDContenttextBox
            // 
            this.OSDContenttextBox.Location = new System.Drawing.Point(19, 38);
            this.OSDContenttextBox.Margin = new System.Windows.Forms.Padding(2);
            this.OSDContenttextBox.Name = "OSDContenttextBox";
            this.OSDContenttextBox.Size = new System.Drawing.Size(206, 23);
            this.OSDContenttextBox.TabIndex = 0;
            this.OSDContenttextBox.Text = "AAA123";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.MinMargincomboBox);
            this.groupBox4.Controls.Add(this.FontColorcomboBox);
            this.groupBox4.Controls.Add(this.FontSizecomboBox);
            this.groupBox4.Controls.Add(this.EffectcomboBox);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(14, 32);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(360, 138);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Display Style";
            // 
            // MinMargincomboBox
            // 
            this.MinMargincomboBox.FormattingEnabled = true;
            this.MinMargincomboBox.Location = new System.Drawing.Point(254, 90);
            this.MinMargincomboBox.Margin = new System.Windows.Forms.Padding(2);
            this.MinMargincomboBox.Name = "MinMargincomboBox";
            this.MinMargincomboBox.Size = new System.Drawing.Size(92, 25);
            this.MinMargincomboBox.TabIndex = 7;
            this.MinMargincomboBox.Text = "None";
            // 
            // FontColorcomboBox
            // 
            this.FontColorcomboBox.FormattingEnabled = true;
            this.FontColorcomboBox.Location = new System.Drawing.Point(254, 36);
            this.FontColorcomboBox.Margin = new System.Windows.Forms.Padding(2);
            this.FontColorcomboBox.Name = "FontColorcomboBox";
            this.FontColorcomboBox.Size = new System.Drawing.Size(92, 25);
            this.FontColorcomboBox.TabIndex = 6;
            this.FontColorcomboBox.Text = "Black";
            // 
            // FontSizecomboBox
            // 
            this.FontSizecomboBox.FormattingEnabled = true;
            this.FontSizecomboBox.Location = new System.Drawing.Point(79, 90);
            this.FontSizecomboBox.Margin = new System.Windows.Forms.Padding(2);
            this.FontSizecomboBox.Name = "FontSizecomboBox";
            this.FontSizecomboBox.Size = new System.Drawing.Size(92, 25);
            this.FontSizecomboBox.TabIndex = 5;
            this.FontSizecomboBox.Text = "X-large";
            // 
            // EffectcomboBox
            // 
            this.EffectcomboBox.FormattingEnabled = true;
            this.EffectcomboBox.Location = new System.Drawing.Point(79, 36);
            this.EffectcomboBox.Margin = new System.Windows.Forms.Padding(2);
            this.EffectcomboBox.Name = "EffectcomboBox";
            this.EffectcomboBox.Size = new System.Drawing.Size(92, 25);
            this.EffectcomboBox.TabIndex = 4;
            this.EffectcomboBox.Text = "Background";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(184, 92);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 17);
            this.label11.TabIndex = 3;
            this.label11.Text = "Min.Margin";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(184, 36);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 17);
            this.label10.TabIndex = 2;
            this.label10.Text = "Font Color";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 92);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "Font Size";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 36);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Effect";
            // 
            // Getdevicecapability
            // 
            this.Getdevicecapability.Controls.Add(this.getcapability);
            this.Getdevicecapability.Controls.Add(this.CapabilitycomboBox);
            this.Getdevicecapability.Controls.Add(this.label7);
            this.Getdevicecapability.Location = new System.Drawing.Point(3, 114);
            this.Getdevicecapability.Margin = new System.Windows.Forms.Padding(2);
            this.Getdevicecapability.Name = "Getdevicecapability";
            this.Getdevicecapability.Padding = new System.Windows.Forms.Padding(2);
            this.Getdevicecapability.Size = new System.Drawing.Size(620, 86);
            this.Getdevicecapability.TabIndex = 1;
            this.Getdevicecapability.TabStop = false;
            this.Getdevicecapability.Text = "Get device capability";
            // 
            // getcapability
            // 
            this.getcapability.Location = new System.Drawing.Point(442, 36);
            this.getcapability.Margin = new System.Windows.Forms.Padding(2);
            this.getcapability.Name = "getcapability";
            this.getcapability.Size = new System.Drawing.Size(126, 25);
            this.getcapability.TabIndex = 2;
            this.getcapability.Text = "get capability";
            this.getcapability.UseVisualStyleBackColor = true;
            this.getcapability.Click += new System.EventHandler(this.getcapability_Click);
            // 
            // CapabilitycomboBox
            // 
            this.CapabilitycomboBox.FormattingEnabled = true;
            this.CapabilitycomboBox.Location = new System.Drawing.Point(158, 36);
            this.CapabilitycomboBox.Margin = new System.Windows.Forms.Padding(2);
            this.CapabilitycomboBox.Name = "CapabilitycomboBox";
            this.CapabilitycomboBox.Size = new System.Drawing.Size(216, 25);
            this.CapabilitycomboBox.TabIndex = 1;
            this.CapabilitycomboBox.Text = "OSD parameter capability";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 39);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Capability command";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Setparameter);
            this.groupBox3.Controls.Add(this.Getparameter);
            this.groupBox3.Controls.Add(this.setParametercomboBox);
            this.groupBox3.Controls.Add(this.getParametercomboBox);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(620, 116);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Device general parameter  configuration";
            // 
            // Setparameter
            // 
            this.Setparameter.Location = new System.Drawing.Point(376, 73);
            this.Setparameter.Margin = new System.Windows.Forms.Padding(2);
            this.Setparameter.Name = "Setparameter";
            this.Setparameter.Size = new System.Drawing.Size(160, 26);
            this.Setparameter.TabIndex = 3;
            this.Setparameter.Text = "Set parameter";
            this.Setparameter.UseVisualStyleBackColor = true;
            this.Setparameter.Click += new System.EventHandler(this.Setparameter_Click);
            // 
            // Getparameter
            // 
            this.Getparameter.Location = new System.Drawing.Point(376, 34);
            this.Getparameter.Margin = new System.Windows.Forms.Padding(2);
            this.Getparameter.Name = "Getparameter";
            this.Getparameter.Size = new System.Drawing.Size(160, 26);
            this.Getparameter.TabIndex = 2;
            this.Getparameter.Text = "Get parameter";
            this.Getparameter.UseVisualStyleBackColor = true;
            this.Getparameter.Click += new System.EventHandler(this.Getparameter_Click);
            // 
            // setParametercomboBox
            // 
            this.setParametercomboBox.FormattingEnabled = true;
            this.setParametercomboBox.Location = new System.Drawing.Point(14, 77);
            this.setParametercomboBox.Margin = new System.Windows.Forms.Padding(2);
            this.setParametercomboBox.Name = "setParametercomboBox";
            this.setParametercomboBox.Size = new System.Drawing.Size(282, 25);
            this.setParametercomboBox.TabIndex = 1;
            this.setParametercomboBox.Text = "OSD configuration info";
            // 
            // getParametercomboBox
            // 
            this.getParametercomboBox.FormattingEnabled = true;
            this.getParametercomboBox.Location = new System.Drawing.Point(14, 36);
            this.getParametercomboBox.Margin = new System.Windows.Forms.Padding(2);
            this.getParametercomboBox.Name = "getParametercomboBox";
            this.getParametercomboBox.Size = new System.Drawing.Size(282, 25);
            this.getParametercomboBox.TabIndex = 0;
            this.getParametercomboBox.Text = "Device Info";
            // 
            // SystemMaintenance
            // 
            this.SystemMaintenance.Controls.Add(this.Reboot);
            this.SystemMaintenance.Controls.Add(this.groupBox2);
            this.SystemMaintenance.Controls.Add(this.NETInfo);
            this.SystemMaintenance.Controls.Add(this.VersionInfo);
            this.SystemMaintenance.Location = new System.Drawing.Point(4, 26);
            this.SystemMaintenance.Margin = new System.Windows.Forms.Padding(2);
            this.SystemMaintenance.Name = "SystemMaintenance";
            this.SystemMaintenance.Size = new System.Drawing.Size(656, 376);
            this.SystemMaintenance.TabIndex = 7;
            this.SystemMaintenance.Text = "System Maintenance";
            this.SystemMaintenance.UseVisualStyleBackColor = true;
            // 
            // Reboot
            // 
            this.Reboot.Location = new System.Drawing.Point(520, 319);
            this.Reboot.Margin = new System.Windows.Forms.Padding(2);
            this.Reboot.Name = "Reboot";
            this.Reboot.Size = new System.Drawing.Size(74, 25);
            this.Reboot.TabIndex = 3;
            this.Reboot.Text = "Reboot";
            this.Reboot.UseVisualStyleBackColor = true;
            this.Reboot.Click += new System.EventHandler(this.Reboot_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Upgrade);
            this.groupBox2.Controls.Add(this.Browse);
            this.groupBox2.Controls.Add(this.LocalUpgrade);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(3, 279);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(495, 98);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Software Upgrade";
            // 
            // Upgrade
            // 
            this.Upgrade.Location = new System.Drawing.Point(412, 40);
            this.Upgrade.Margin = new System.Windows.Forms.Padding(2);
            this.Upgrade.Name = "Upgrade";
            this.Upgrade.Size = new System.Drawing.Size(74, 25);
            this.Upgrade.TabIndex = 3;
            this.Upgrade.Text = "Upgrade";
            this.Upgrade.UseVisualStyleBackColor = true;
            this.Upgrade.Click += new System.EventHandler(this.Upgrade_Click);
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(325, 40);
            this.Browse.Margin = new System.Windows.Forms.Padding(2);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(74, 25);
            this.Browse.TabIndex = 2;
            this.Browse.Text = "Browse";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // LocalUpgrade
            // 
            this.LocalUpgrade.Location = new System.Drawing.Point(122, 39);
            this.LocalUpgrade.Margin = new System.Windows.Forms.Padding(2);
            this.LocalUpgrade.Name = "LocalUpgrade";
            this.LocalUpgrade.Size = new System.Drawing.Size(187, 23);
            this.LocalUpgrade.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 45);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Local Upgrade";
            // 
            // NETInfo
            // 
            this.NETInfo.Controls.Add(this.SetNetInfo);
            this.NETInfo.Controls.Add(this.GetNetInfo);
            this.NETInfo.Controls.Add(this.MTUtextBox);
            this.NETInfo.Controls.Add(this.DHCPtextBox);
            this.NETInfo.Controls.Add(this.SubnetMasktextBox);
            this.NETInfo.Controls.Add(this.IPAddressBox);
            this.NETInfo.Controls.Add(this.label5);
            this.NETInfo.Controls.Add(this.label1);
            this.NETInfo.Controls.Add(this.SubnetMask);
            this.NETInfo.Controls.Add(this.IPAddreing);
            this.NETInfo.Location = new System.Drawing.Point(315, 4);
            this.NETInfo.Margin = new System.Windows.Forms.Padding(2);
            this.NETInfo.Name = "NETInfo";
            this.NETInfo.Padding = new System.Windows.Forms.Padding(2);
            this.NETInfo.Size = new System.Drawing.Size(325, 270);
            this.NETInfo.TabIndex = 1;
            this.NETInfo.TabStop = false;
            this.NETInfo.Text = "NET Info";
            // 
            // SetNetInfo
            // 
            this.SetNetInfo.Location = new System.Drawing.Point(209, 210);
            this.SetNetInfo.Margin = new System.Windows.Forms.Padding(2);
            this.SetNetInfo.Name = "SetNetInfo";
            this.SetNetInfo.Size = new System.Drawing.Size(73, 25);
            this.SetNetInfo.TabIndex = 9;
            this.SetNetInfo.Text = "Set";
            this.SetNetInfo.UseVisualStyleBackColor = true;
            this.SetNetInfo.Click += new System.EventHandler(this.SetNetInfo_Click);
            // 
            // GetNetInfo
            // 
            this.GetNetInfo.Location = new System.Drawing.Point(114, 210);
            this.GetNetInfo.Margin = new System.Windows.Forms.Padding(2);
            this.GetNetInfo.Name = "GetNetInfo";
            this.GetNetInfo.Size = new System.Drawing.Size(73, 25);
            this.GetNetInfo.TabIndex = 8;
            this.GetNetInfo.Text = "Get";
            this.GetNetInfo.UseVisualStyleBackColor = true;
            this.GetNetInfo.Click += new System.EventHandler(this.GetNetInfo_Click);
            // 
            // MTUtextBox
            // 
            this.MTUtextBox.Location = new System.Drawing.Point(114, 158);
            this.MTUtextBox.Margin = new System.Windows.Forms.Padding(2);
            this.MTUtextBox.Name = "MTUtextBox";
            this.MTUtextBox.Size = new System.Drawing.Size(168, 23);
            this.MTUtextBox.TabIndex = 7;
            // 
            // DHCPtextBox
            // 
            this.DHCPtextBox.Location = new System.Drawing.Point(114, 118);
            this.DHCPtextBox.Margin = new System.Windows.Forms.Padding(2);
            this.DHCPtextBox.Name = "DHCPtextBox";
            this.DHCPtextBox.Size = new System.Drawing.Size(168, 23);
            this.DHCPtextBox.TabIndex = 6;
            // 
            // SubnetMasktextBox
            // 
            this.SubnetMasktextBox.Location = new System.Drawing.Point(114, 77);
            this.SubnetMasktextBox.Margin = new System.Windows.Forms.Padding(2);
            this.SubnetMasktextBox.Name = "SubnetMasktextBox";
            this.SubnetMasktextBox.Size = new System.Drawing.Size(168, 23);
            this.SubnetMasktextBox.TabIndex = 5;
            // 
            // IPAddressBox
            // 
            this.IPAddressBox.Location = new System.Drawing.Point(114, 30);
            this.IPAddressBox.Margin = new System.Windows.Forms.Padding(2);
            this.IPAddressBox.Name = "IPAddressBox";
            this.IPAddressBox.Size = new System.Drawing.Size(168, 23);
            this.IPAddressBox.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 165);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "MTU";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 123);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "DHCP";
            // 
            // SubnetMask
            // 
            this.SubnetMask.AutoSize = true;
            this.SubnetMask.Location = new System.Drawing.Point(22, 79);
            this.SubnetMask.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SubnetMask.Name = "SubnetMask";
            this.SubnetMask.Size = new System.Drawing.Size(84, 17);
            this.SubnetMask.TabIndex = 1;
            this.SubnetMask.Text = "Subnet Mask";
            // 
            // IPAddreing
            // 
            this.IPAddreing.AutoSize = true;
            this.IPAddreing.Location = new System.Drawing.Point(22, 32);
            this.IPAddreing.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.IPAddreing.Name = "IPAddreing";
            this.IPAddreing.Size = new System.Drawing.Size(71, 17);
            this.IPAddreing.TabIndex = 0;
            this.IPAddreing.Text = "IP Address";
            // 
            // VersionInfo
            // 
            this.VersionInfo.Controls.Add(this.VedrsionInfoRefresh);
            this.VersionInfo.Controls.Add(this.MacAdresstextBox);
            this.VersionInfo.Controls.Add(this.SerialNotextBox);
            this.VersionInfo.Controls.Add(this.DeviceNametextBox);
            this.VersionInfo.Controls.Add(this.HardwaretextBox);
            this.VersionInfo.Controls.Add(this.FirmwaretextBox);
            this.VersionInfo.Controls.Add(this.MACAddress);
            this.VersionInfo.Controls.Add(this.SerialNo);
            this.VersionInfo.Controls.Add(this.DeviceName);
            this.VersionInfo.Controls.Add(this.HardwareVersion);
            this.VersionInfo.Controls.Add(this.FirmwareVersion);
            this.VersionInfo.Location = new System.Drawing.Point(3, 4);
            this.VersionInfo.Margin = new System.Windows.Forms.Padding(2);
            this.VersionInfo.Name = "VersionInfo";
            this.VersionInfo.Padding = new System.Windows.Forms.Padding(2);
            this.VersionInfo.Size = new System.Drawing.Size(308, 270);
            this.VersionInfo.TabIndex = 0;
            this.VersionInfo.TabStop = false;
            this.VersionInfo.Text = "Version Info";
            // 
            // VedrsionInfoRefresh
            // 
            this.VedrsionInfoRefresh.Location = new System.Drawing.Point(219, 232);
            this.VedrsionInfoRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.VedrsionInfoRefresh.Name = "VedrsionInfoRefresh";
            this.VedrsionInfoRefresh.Size = new System.Drawing.Size(73, 25);
            this.VedrsionInfoRefresh.TabIndex = 10;
            this.VedrsionInfoRefresh.Text = " Refresh";
            this.VedrsionInfoRefresh.UseVisualStyleBackColor = true;
            this.VedrsionInfoRefresh.Click += new System.EventHandler(this.VedrsionInfoRefresh_Click);
            // 
            // MacAdresstextBox
            // 
            this.MacAdresstextBox.Location = new System.Drawing.Point(136, 198);
            this.MacAdresstextBox.Margin = new System.Windows.Forms.Padding(2);
            this.MacAdresstextBox.Name = "MacAdresstextBox";
            this.MacAdresstextBox.Size = new System.Drawing.Size(159, 23);
            this.MacAdresstextBox.TabIndex = 9;
            // 
            // SerialNotextBox
            // 
            this.SerialNotextBox.Location = new System.Drawing.Point(136, 158);
            this.SerialNotextBox.Margin = new System.Windows.Forms.Padding(2);
            this.SerialNotextBox.Name = "SerialNotextBox";
            this.SerialNotextBox.Size = new System.Drawing.Size(159, 23);
            this.SerialNotextBox.TabIndex = 8;
            // 
            // DeviceNametextBox
            // 
            this.DeviceNametextBox.Location = new System.Drawing.Point(136, 116);
            this.DeviceNametextBox.Margin = new System.Windows.Forms.Padding(2);
            this.DeviceNametextBox.Name = "DeviceNametextBox";
            this.DeviceNametextBox.Size = new System.Drawing.Size(159, 23);
            this.DeviceNametextBox.TabIndex = 7;
            // 
            // HardwaretextBox
            // 
            this.HardwaretextBox.Location = new System.Drawing.Point(136, 73);
            this.HardwaretextBox.Margin = new System.Windows.Forms.Padding(2);
            this.HardwaretextBox.Name = "HardwaretextBox";
            this.HardwaretextBox.Size = new System.Drawing.Size(159, 23);
            this.HardwaretextBox.TabIndex = 6;
            // 
            // FirmwaretextBox
            // 
            this.FirmwaretextBox.Location = new System.Drawing.Point(136, 32);
            this.FirmwaretextBox.Margin = new System.Windows.Forms.Padding(2);
            this.FirmwaretextBox.Name = "FirmwaretextBox";
            this.FirmwaretextBox.Size = new System.Drawing.Size(159, 23);
            this.FirmwaretextBox.TabIndex = 5;
            // 
            // MACAddress
            // 
            this.MACAddress.AutoSize = true;
            this.MACAddress.Location = new System.Drawing.Point(19, 199);
            this.MACAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MACAddress.Name = "MACAddress";
            this.MACAddress.Size = new System.Drawing.Size(88, 17);
            this.MACAddress.TabIndex = 4;
            this.MACAddress.Text = "MAC Address";
            // 
            // SerialNo
            // 
            this.SerialNo.AutoSize = true;
            this.SerialNo.Location = new System.Drawing.Point(19, 161);
            this.SerialNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SerialNo.Name = "SerialNo";
            this.SerialNo.Size = new System.Drawing.Size(65, 17);
            this.SerialNo.TabIndex = 3;
            this.SerialNo.Text = "Serial No.";
            // 
            // DeviceName
            // 
            this.DeviceName.AutoSize = true;
            this.DeviceName.Location = new System.Drawing.Point(19, 120);
            this.DeviceName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DeviceName.Name = "DeviceName";
            this.DeviceName.Size = new System.Drawing.Size(85, 17);
            this.DeviceName.TabIndex = 2;
            this.DeviceName.Text = "Device Name";
            // 
            // HardwareVersion
            // 
            this.HardwareVersion.AutoSize = true;
            this.HardwareVersion.Location = new System.Drawing.Point(19, 79);
            this.HardwareVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.HardwareVersion.Name = "HardwareVersion";
            this.HardwareVersion.Size = new System.Drawing.Size(113, 17);
            this.HardwareVersion.TabIndex = 1;
            this.HardwareVersion.Text = "Hardware Version";
            // 
            // FirmwareVersion
            // 
            this.FirmwareVersion.AutoSize = true;
            this.FirmwareVersion.Location = new System.Drawing.Point(19, 34);
            this.FirmwareVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FirmwareVersion.Name = "FirmwareVersion";
            this.FirmwareVersion.Size = new System.Drawing.Size(109, 17);
            this.FirmwareVersion.TabIndex = 0;
            this.FirmwareVersion.Text = "Firmware Version";
            // 
            // UserInfo
            // 
            this.UserInfo.Controls.Add(this.UserInfolistView);
            this.UserInfo.Location = new System.Drawing.Point(3, 2);
            this.UserInfo.Margin = new System.Windows.Forms.Padding(2);
            this.UserInfo.Name = "UserInfo";
            this.UserInfo.Padding = new System.Windows.Forms.Padding(2);
            this.UserInfo.Size = new System.Drawing.Size(294, 111);
            this.UserInfo.TabIndex = 1;
            this.UserInfo.TabStop = false;
            this.UserInfo.Text = "User Info";
            // 
            // UserInfolistView
            // 
            this.UserInfolistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IP,
            this.Username,
            this.Status,
            this.Photosnumber});
            this.UserInfolistView.FullRowSelect = true;
            this.UserInfolistView.GridLines = true;
            this.UserInfolistView.Location = new System.Drawing.Point(-1, 12);
            this.UserInfolistView.Margin = new System.Windows.Forms.Padding(2);
            this.UserInfolistView.Name = "UserInfolistView";
            this.UserInfolistView.Size = new System.Drawing.Size(291, 100);
            this.UserInfolistView.TabIndex = 0;
            this.UserInfolistView.UseCompatibleStateImageBehavior = false;
            this.UserInfolistView.View = System.Windows.Forms.View.Details;
            this.UserInfolistView.SelectedIndexChanged += new System.EventHandler(this.UserInfolistView_SelectedIndexChanged);
            // 
            // IP
            // 
            this.IP.Text = "IP";
            this.IP.Width = 92;
            // 
            // Username
            // 
            this.Username.Text = "Username";
            this.Username.Width = 61;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            // 
            // Photosnumber
            // 
            this.Photosnumber.Text = "Photos number";
            this.Photosnumber.Width = 160;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.deleteDevice);
            this.groupBox9.Controls.Add(this.addDevice);
            this.groupBox9.Controls.Add(this.MultiPasswordtextBox);
            this.groupBox9.Controls.Add(this.MultiPorttextBox);
            this.groupBox9.Controls.Add(this.MultiUsernametextBox);
            this.groupBox9.Controls.Add(this.MultiIPtextBox);
            this.groupBox9.Controls.Add(this.MultiLogoutbutton);
            this.groupBox9.Controls.Add(this.MultiLoginbutton);
            this.groupBox9.Controls.Add(this.label31);
            this.groupBox9.Controls.Add(this.label30);
            this.groupBox9.Controls.Add(this.label29);
            this.groupBox9.Controls.Add(this.label28);
            this.groupBox9.Location = new System.Drawing.Point(300, 2);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox9.Size = new System.Drawing.Size(353, 115);
            this.groupBox9.TabIndex = 0;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "User Login";
            // 
            // deleteDevice
            // 
            this.deleteDevice.Location = new System.Drawing.Point(179, 35);
            this.deleteDevice.Name = "deleteDevice";
            this.deleteDevice.Size = new System.Drawing.Size(71, 20);
            this.deleteDevice.TabIndex = 11;
            this.deleteDevice.Text = "DelDevice";
            this.deleteDevice.UseVisualStyleBackColor = true;
            this.deleteDevice.Click += new System.EventHandler(this.deleteDevice_Click);
            // 
            // addDevice
            // 
            this.addDevice.Location = new System.Drawing.Point(179, 11);
            this.addDevice.Name = "addDevice";
            this.addDevice.Size = new System.Drawing.Size(71, 20);
            this.addDevice.TabIndex = 10;
            this.addDevice.Text = "AddDevice";
            this.addDevice.UseVisualStyleBackColor = true;
            this.addDevice.Click += new System.EventHandler(this.addDevice_Click);
            // 
            // MultiPasswordtextBox
            // 
            this.MultiPasswordtextBox.Location = new System.Drawing.Point(62, 85);
            this.MultiPasswordtextBox.Margin = new System.Windows.Forms.Padding(2);
            this.MultiPasswordtextBox.Multiline = true;
            this.MultiPasswordtextBox.Name = "MultiPasswordtextBox";
            this.MultiPasswordtextBox.Size = new System.Drawing.Size(97, 18);
            this.MultiPasswordtextBox.TabIndex = 9;
            this.MultiPasswordtextBox.Text = "admin_123";
            // 
            // MultiPorttextBox
            // 
            this.MultiPorttextBox.Location = new System.Drawing.Point(62, 38);
            this.MultiPorttextBox.Margin = new System.Windows.Forms.Padding(2);
            this.MultiPorttextBox.Multiline = true;
            this.MultiPorttextBox.Name = "MultiPorttextBox";
            this.MultiPorttextBox.Size = new System.Drawing.Size(97, 18);
            this.MultiPorttextBox.TabIndex = 8;
            this.MultiPorttextBox.Text = "80";
            // 
            // MultiUsernametextBox
            // 
            this.MultiUsernametextBox.Location = new System.Drawing.Point(62, 61);
            this.MultiUsernametextBox.Margin = new System.Windows.Forms.Padding(2);
            this.MultiUsernametextBox.Multiline = true;
            this.MultiUsernametextBox.Name = "MultiUsernametextBox";
            this.MultiUsernametextBox.Size = new System.Drawing.Size(97, 18);
            this.MultiUsernametextBox.TabIndex = 7;
            this.MultiUsernametextBox.Text = "admin";
            // 
            // MultiIPtextBox
            // 
            this.MultiIPtextBox.Location = new System.Drawing.Point(62, 16);
            this.MultiIPtextBox.Margin = new System.Windows.Forms.Padding(2);
            this.MultiIPtextBox.Multiline = true;
            this.MultiIPtextBox.Name = "MultiIPtextBox";
            this.MultiIPtextBox.Size = new System.Drawing.Size(97, 17);
            this.MultiIPtextBox.TabIndex = 6;
            this.MultiIPtextBox.Text = "192.174.1.173";
            // 
            // MultiLogoutbutton
            // 
            this.MultiLogoutbutton.Location = new System.Drawing.Point(179, 85);
            this.MultiLogoutbutton.Margin = new System.Windows.Forms.Padding(2);
            this.MultiLogoutbutton.Name = "MultiLogoutbutton";
            this.MultiLogoutbutton.Size = new System.Drawing.Size(71, 20);
            this.MultiLogoutbutton.TabIndex = 5;
            this.MultiLogoutbutton.Text = "logout";
            this.MultiLogoutbutton.UseVisualStyleBackColor = true;
            this.MultiLogoutbutton.Click += new System.EventHandler(this.MultiLogoutbutton_Click);
            // 
            // MultiLoginbutton
            // 
            this.MultiLoginbutton.Location = new System.Drawing.Point(179, 59);
            this.MultiLoginbutton.Margin = new System.Windows.Forms.Padding(2);
            this.MultiLoginbutton.Name = "MultiLoginbutton";
            this.MultiLoginbutton.Size = new System.Drawing.Size(71, 20);
            this.MultiLoginbutton.TabIndex = 4;
            this.MultiLoginbutton.Text = "login";
            this.MultiLoginbutton.UseVisualStyleBackColor = true;
            this.MultiLoginbutton.Click += new System.EventHandler(this.MultiLoginbutton_Click);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(10, 89);
            this.label31.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(53, 12);
            this.label31.TabIndex = 3;
            this.label31.Text = "Password";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(9, 69);
            this.label30.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(53, 12);
            this.label30.TabIndex = 2;
            this.label30.Text = "Username";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(31, 48);
            this.label29.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(29, 12);
            this.label29.TabIndex = 1;
            this.label29.Text = "Port";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(41, 22);
            this.label28.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(17, 12);
            this.label28.TabIndex = 0;
            this.label28.Text = "IP";
            // 
            // VoiceFunction
            // 
            this.VoiceFunction.Location = new System.Drawing.Point(0, 0);
            this.VoiceFunction.Name = "VoiceFunction";
            this.VoiceFunction.Size = new System.Drawing.Size(200, 100);
            this.VoiceFunction.TabIndex = 0;
            // 
            // ParkingConfiguration
            // 
            this.ParkingConfiguration.Location = new System.Drawing.Point(0, 0);
            this.ParkingConfiguration.Name = "ParkingConfiguration";
            this.ParkingConfiguration.Size = new System.Drawing.Size(200, 100);
            this.ParkingConfiguration.TabIndex = 0;
            // 
            // RealStreamlabel
            // 
            this.RealStreamlabel.AutoSize = true;
            this.RealStreamlabel.Location = new System.Drawing.Point(14, 10);
            this.RealStreamlabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RealStreamlabel.Name = "RealStreamlabel";
            this.RealStreamlabel.Size = new System.Drawing.Size(47, 12);
            this.RealStreamlabel.TabIndex = 4;
            this.RealStreamlabel.Text = "Offline";
            // 
            // PicStreamlabel
            // 
            this.PicStreamlabel.AutoSize = true;
            this.PicStreamlabel.Location = new System.Drawing.Point(16, 286);
            this.PicStreamlabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PicStreamlabel.Name = "PicStreamlabel";
            this.PicStreamlabel.Size = new System.Drawing.Size(47, 12);
            this.PicStreamlabel.TabIndex = 5;
            this.PicStreamlabel.Text = "Offline";
            // 
            // TABcontrol_Login
            // 
            this.TABcontrol_Login.Controls.Add(this.Singleuser);
            this.TABcontrol_Login.Controls.Add(this.Multiuser);
            this.TABcontrol_Login.Location = new System.Drawing.Point(424, 10);
            this.TABcontrol_Login.Name = "TABcontrol_Login";
            this.TABcontrol_Login.SelectedIndex = 0;
            this.TABcontrol_Login.Size = new System.Drawing.Size(664, 141);
            this.TABcontrol_Login.TabIndex = 6;
            // 
            // Singleuser
            // 
            this.Singleuser.Controls.Add(this.UserLogin);
            this.Singleuser.Location = new System.Drawing.Point(4, 22);
            this.Singleuser.Name = "Singleuser";
            this.Singleuser.Padding = new System.Windows.Forms.Padding(3);
            this.Singleuser.Size = new System.Drawing.Size(656, 115);
            this.Singleuser.TabIndex = 0;
            this.Singleuser.Text = "Singleuser";
            this.Singleuser.UseVisualStyleBackColor = true;
            // 
            // UserLogin
            // 
            this.UserLogin.Controls.Add(this.DeviceStatuslabel);
            this.UserLogin.Controls.Add(this.label27);
            this.UserLogin.Controls.Add(this.logoutbutton);
            this.UserLogin.Controls.Add(this.Loginbutton);
            this.UserLogin.Controls.Add(this.PasswordtextBox);
            this.UserLogin.Controls.Add(this.porttextBox);
            this.UserLogin.Controls.Add(this.admintextBox);
            this.UserLogin.Controls.Add(this.DeviceIPtextBox);
            this.UserLogin.Controls.Add(this.label26);
            this.UserLogin.Controls.Add(this.label25);
            this.UserLogin.Controls.Add(this.label24);
            this.UserLogin.Controls.Add(this.label23);
            this.UserLogin.Location = new System.Drawing.Point(2, 2);
            this.UserLogin.Margin = new System.Windows.Forms.Padding(2);
            this.UserLogin.Name = "UserLogin";
            this.UserLogin.Padding = new System.Windows.Forms.Padding(2);
            this.UserLogin.Size = new System.Drawing.Size(638, 111);
            this.UserLogin.TabIndex = 3;
            this.UserLogin.TabStop = false;
            this.UserLogin.Text = "User Login";
            // 
            // DeviceStatuslabel
            // 
            this.DeviceStatuslabel.AutoSize = true;
            this.DeviceStatuslabel.Location = new System.Drawing.Point(145, 91);
            this.DeviceStatuslabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DeviceStatuslabel.Name = "DeviceStatuslabel";
            this.DeviceStatuslabel.Size = new System.Drawing.Size(47, 12);
            this.DeviceStatuslabel.TabIndex = 11;
            this.DeviceStatuslabel.Text = "Offline";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(48, 91);
            this.label27.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(89, 12);
            this.label27.TabIndex = 10;
            this.label27.Text = "Device status:";
            // 
            // logoutbutton
            // 
            this.logoutbutton.Location = new System.Drawing.Point(548, 63);
            this.logoutbutton.Margin = new System.Windows.Forms.Padding(2);
            this.logoutbutton.Name = "logoutbutton";
            this.logoutbutton.Size = new System.Drawing.Size(56, 21);
            this.logoutbutton.TabIndex = 9;
            this.logoutbutton.Text = "logout";
            this.logoutbutton.UseVisualStyleBackColor = true;
            this.logoutbutton.Click += new System.EventHandler(this.logoutbutton_Click);
            // 
            // Loginbutton
            // 
            this.Loginbutton.BackColor = System.Drawing.SystemColors.Control;
            this.Loginbutton.Location = new System.Drawing.Point(548, 25);
            this.Loginbutton.Margin = new System.Windows.Forms.Padding(2);
            this.Loginbutton.Name = "Loginbutton";
            this.Loginbutton.Size = new System.Drawing.Size(56, 21);
            this.Loginbutton.TabIndex = 8;
            this.Loginbutton.Text = "login";
            this.Loginbutton.UseVisualStyleBackColor = true;
            this.Loginbutton.Click += new System.EventHandler(this.Loginbutton_Click);
            // 
            // PasswordtextBox
            // 
            this.PasswordtextBox.Location = new System.Drawing.Point(355, 63);
            this.PasswordtextBox.Margin = new System.Windows.Forms.Padding(2);
            this.PasswordtextBox.Name = "PasswordtextBox";
            this.PasswordtextBox.Size = new System.Drawing.Size(130, 21);
            this.PasswordtextBox.TabIndex = 7;
            this.PasswordtextBox.Text = "admin_123";
            // 
            // porttextBox
            // 
            this.porttextBox.Location = new System.Drawing.Point(114, 63);
            this.porttextBox.Margin = new System.Windows.Forms.Padding(2);
            this.porttextBox.Name = "porttextBox";
            this.porttextBox.Size = new System.Drawing.Size(130, 21);
            this.porttextBox.TabIndex = 6;
            this.porttextBox.Text = "80";
            // 
            // admintextBox
            // 
            this.admintextBox.Location = new System.Drawing.Point(355, 25);
            this.admintextBox.Margin = new System.Windows.Forms.Padding(2);
            this.admintextBox.Name = "admintextBox";
            this.admintextBox.Size = new System.Drawing.Size(130, 21);
            this.admintextBox.TabIndex = 5;
            this.admintextBox.Text = "admin";
            // 
            // DeviceIPtextBox
            // 
            this.DeviceIPtextBox.Location = new System.Drawing.Point(114, 25);
            this.DeviceIPtextBox.Margin = new System.Windows.Forms.Padding(2);
            this.DeviceIPtextBox.Name = "DeviceIPtextBox";
            this.DeviceIPtextBox.Size = new System.Drawing.Size(130, 21);
            this.DeviceIPtextBox.TabIndex = 4;
            this.DeviceIPtextBox.Text = "192.174.1.173";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(286, 69);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(53, 12);
            this.label26.TabIndex = 3;
            this.label26.Text = "Password";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(73, 68);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(29, 12);
            this.label25.TabIndex = 2;
            this.label25.Text = "Port";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(285, 30);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(53, 12);
            this.label24.TabIndex = 1;
            this.label24.Text = "Username";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(83, 30);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(17, 12);
            this.label23.TabIndex = 0;
            this.label23.Text = "IP";
            // 
            // Multiuser
            // 
            this.Multiuser.Controls.Add(this.groupBox9);
            this.Multiuser.Controls.Add(this.UserInfo);
            this.Multiuser.Location = new System.Drawing.Point(4, 22);
            this.Multiuser.Name = "Multiuser";
            this.Multiuser.Padding = new System.Windows.Forms.Padding(3);
            this.Multiuser.Size = new System.Drawing.Size(656, 115);
            this.Multiuser.TabIndex = 1;
            this.Multiuser.Text = "Multiuser";
            this.Multiuser.UseVisualStyleBackColor = true;
            // 
            // NETSDKDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 602);
            this.Controls.Add(this.TABcontrol_Login);
            this.Controls.Add(this.PicStreamlabel);
            this.Controls.Add(this.RealStreamlabel);
            this.Controls.Add(this.mainTabCtrl);
            this.Controls.Add(this.PhotoView);
            this.Controls.Add(this.LiveView);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "NETSDKDemo";
            this.Text = "NETSDKDemo";
            this.LiveView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VID_STREAM)).EndInit();
            this.PhotoView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PIC_STREAM)).EndInit();
            this.mainTabCtrl.ResumeLayout(false);
            this.LocalFeatures.ResumeLayout(false);
            this.SetSDKLog.ResumeLayout(false);
            this.SetSDKLog.PerformLayout();
            this.SDKInfo.ResumeLayout(false);
            this.SDKInfo.PerformLayout();
            this.LiveOperation.ResumeLayout(false);
            this.DataCallback.ResumeLayout(false);
            this.DataCallback.PerformLayout();
            this.VideoRecording.ResumeLayout(false);
            this.VideoRecording.PerformLayout();
            this.LivePreview.ResumeLayout(false);
            this.PhotoOperation.ResumeLayout(false);
            this.PicturePreview.ResumeLayout(false);
            this.VechicleListOperation.ResumeLayout(false);
            this.VehicleRecordOperation.ResumeLayout(false);
            this.VehicleRecordOperation.PerformLayout();
            this.EntranceandExitVehicleListFile.ResumeLayout(false);
            this.EntranceandExitVehicleListFile.PerformLayout();
            this.Parameter.ResumeLayout(false);
            this.LiveviewOSDcunstomsetting.ResumeLayout(false);
            this.OSDContent.ResumeLayout(false);
            this.OSDContent.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.Getdevicecapability.ResumeLayout(false);
            this.Getdevicecapability.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.SystemMaintenance.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.NETInfo.ResumeLayout(false);
            this.NETInfo.PerformLayout();
            this.VersionInfo.ResumeLayout(false);
            this.VersionInfo.PerformLayout();
            this.UserInfo.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.TABcontrol_Login.ResumeLayout(false);
            this.Singleuser.ResumeLayout(false);
            this.UserLogin.ResumeLayout(false);
            this.UserLogin.PerformLayout();
            this.Multiuser.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox LiveView;
        private System.Windows.Forms.GroupBox PhotoView;
        private System.Windows.Forms.TabControl mainTabCtrl;
        private System.Windows.Forms.TabPage LocalFeatures;
        private System.Windows.Forms.TabPage LiveOperation;
        private System.Windows.Forms.TabPage PhotoOperation;
        private System.Windows.Forms.TabPage VechicleListOperation;
        private System.Windows.Forms.TabPage Parameter;
        private System.Windows.Forms.TabPage VoiceFunction;
        private System.Windows.Forms.TabPage SystemMaintenance;
        private System.Windows.Forms.TabPage ParkingConfiguration;
        private System.Windows.Forms.GroupBox SetSDKLog;
        private System.Windows.Forms.GroupBox SDKInfo;
        private System.Windows.Forms.Label Plateencodingformat;
        private System.Windows.Forms.Label SDKVersion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SetlogPath;
        private System.Windows.Forms.Button SetlogSizeNum;
        private System.Windows.Forms.TextBox LogNumber;
        private System.Windows.Forms.TextBox LogSize;
        private System.Windows.Forms.TextBox LogPath;
        private System.Windows.Forms.Button SetEncodingFormat;
        private System.Windows.Forms.Button GetVersion;
        private System.Windows.Forms.ComboBox PlateencodingCombox;
        private System.Windows.Forms.TextBox VersiontextBox;
        private System.Windows.Forms.GroupBox DataCallback;
        private System.Windows.Forms.GroupBox VideoRecording;
        private System.Windows.Forms.GroupBox LivePreview;
        private System.Windows.Forms.Button Snapshot;
        private System.Windows.Forms.Button LiveClose;
        private System.Windows.Forms.Button LiveOpen;
        private System.Windows.Forms.Label LiveDataFormat;
        private System.Windows.Forms.Button StopRecording;
        private System.Windows.Forms.Button StartRecording;
        private System.Windows.Forms.ComboBox LiveRecordcomboBox;
        private System.Windows.Forms.TextBox LiveRecordingSavePath;
        private System.Windows.Forms.Label Format;
        private System.Windows.Forms.Label SavePath;
        private System.Windows.Forms.Button LiveDataReset;
        private System.Windows.Forms.Button LiveDataSetCallback;
        private System.Windows.Forms.ComboBox LiveDataFormatcomboBox;
        private System.Windows.Forms.GroupBox PicturePreview;
        private System.Windows.Forms.Button PhotoCaptureSys;
        private System.Windows.Forms.Button PhotoCapture;
        private System.Windows.Forms.Button PhotoClose;
        private System.Windows.Forms.Button PhotoOpen;
        private System.Windows.Forms.ListView PhotoListView;
        private System.Windows.Forms.ColumnHeader PassTime;
        private System.Windows.Forms.ColumnHeader LaneID;
        private System.Windows.Forms.ColumnHeader PlateColor;
        private System.Windows.Forms.ColumnHeader LicensePlate;
        private System.Windows.Forms.ColumnHeader CapatureSys;
        private System.Windows.Forms.GroupBox EntranceandExitVehicleListFile;
        private System.Windows.Forms.GroupBox VehicleRecordOperation;
        private System.Windows.Forms.Button VechicleListImport;
        private System.Windows.Forms.Button VechicleListBrowse;
        private System.Windows.Forms.Button VehicleListAllowExport;
        private System.Windows.Forms.TextBox VechicleListFilePath;
        private System.Windows.Forms.Label ExportBlocklistFile;
        private System.Windows.Forms.Label ExportAllowlistFile;
        private System.Windows.Forms.Label ImportFile;
        private System.Windows.Forms.Button VehicleListBlockExport;
        private System.Windows.Forms.Label VechicleListExpirationTime;
        private System.Windows.Forms.Label VechicleListEffectiveTime;
        private System.Windows.Forms.Label VechicleListPlateNo;
        private System.Windows.Forms.Label VechicleListID;
        private System.Windows.Forms.TextBox VechicleListNotextBox;
        private System.Windows.Forms.TextBox VechicleListIDtextBox;
        private System.Windows.Forms.RadioButton BlockListradioButton;
        private System.Windows.Forms.RadioButton AllowListradioButton;
        private System.Windows.Forms.Button DeleteRecord;
        private System.Windows.Forms.Button ModifyRecord;
        private System.Windows.Forms.Button AddRecord;
        private System.Windows.Forms.ColumnHeader SpaceNo;
        private System.Windows.Forms.ColumnHeader AreaNo;
        private System.Windows.Forms.ColumnHeader ParkingNo;
        private System.Windows.Forms.GroupBox NETInfo;
        private System.Windows.Forms.GroupBox VersionInfo;
        private System.Windows.Forms.Label MACAddress;
        private System.Windows.Forms.Label SerialNo;
        private System.Windows.Forms.Label DeviceName;
        private System.Windows.Forms.Label HardwareVersion;
        private System.Windows.Forms.Label FirmwareVersion;
        private System.Windows.Forms.Button VedrsionInfoRefresh;
        private System.Windows.Forms.TextBox MacAdresstextBox;
        private System.Windows.Forms.TextBox SerialNotextBox;
        private System.Windows.Forms.TextBox DeviceNametextBox;
        private System.Windows.Forms.TextBox HardwaretextBox;
        private System.Windows.Forms.TextBox FirmwaretextBox;
        private System.Windows.Forms.Label IPAddreing;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label SubnetMask;
        private System.Windows.Forms.Button SetNetInfo;
        private System.Windows.Forms.Button GetNetInfo;
        private System.Windows.Forms.TextBox MTUtextBox;
        private System.Windows.Forms.TextBox DHCPtextBox;
        private System.Windows.Forms.TextBox SubnetMasktextBox;
        private System.Windows.Forms.TextBox IPAddressBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Reboot;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Upgrade;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.TextBox LocalUpgrade;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox getParametercomboBox;
        private System.Windows.Forms.GroupBox Getdevicecapability;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Setparameter;
        private System.Windows.Forms.Button Getparameter;
        private System.Windows.Forms.ComboBox setParametercomboBox;
        private System.Windows.Forms.GroupBox LiveviewOSDcunstomsetting;
        private System.Windows.Forms.Button getcapability;
        private System.Windows.Forms.ComboBox CapabilitycomboBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox MinMargincomboBox;
        private System.Windows.Forms.ComboBox FontColorcomboBox;
        private System.Windows.Forms.ComboBox FontSizecomboBox;
        private System.Windows.Forms.ComboBox EffectcomboBox;
        private System.Windows.Forms.GroupBox OSDContent;
        private System.Windows.Forms.Button SettingOSDContent;
        private System.Windows.Forms.TextBox OSDContenttextBox;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.PictureBox VID_STREAM;
        private System.Windows.Forms.PictureBox PIC_STREAM;
        private System.Windows.Forms.DateTimePicker EffectiveData;
        private System.Windows.Forms.DateTimePicker ExpirationTime;
        private System.Windows.Forms.DateTimePicker EffectiveTime;
        private System.Windows.Forms.DateTimePicker ExpirationDate;
        private System.Windows.Forms.ColumnHeader CarDeviceID;
        private System.Windows.Forms.ColumnHeader CarPassTime;
        private System.Windows.Forms.ColumnHeader CarLandID;
        private System.Windows.Forms.ColumnHeader CarLicensePlate;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader DeviceID;
        private System.Windows.Forms.Label RealStreamlabel;
        private System.Windows.Forms.Label PicStreamlabel;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button MultiLogoutbutton;
        private System.Windows.Forms.Button MultiLoginbutton;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox MultiIPtextBox;
        private System.Windows.Forms.TextBox MultiPasswordtextBox;
        private System.Windows.Forms.TextBox MultiPorttextBox;
        private System.Windows.Forms.TextBox MultiUsernametextBox;
        private System.Windows.Forms.GroupBox UserInfo;
        private System.Windows.Forms.ListView UserInfolistView;
        private System.Windows.Forms.ColumnHeader IP;
        private System.Windows.Forms.ColumnHeader Username;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader Photosnumber;
        private System.Windows.Forms.TabControl TABcontrol_Login;
        private System.Windows.Forms.TabPage Singleuser;
        private System.Windows.Forms.GroupBox UserLogin;
        private System.Windows.Forms.Label DeviceStatuslabel;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button logoutbutton;
        private System.Windows.Forms.Button Loginbutton;
        private System.Windows.Forms.TextBox PasswordtextBox;
        private System.Windows.Forms.TextBox porttextBox;
        private System.Windows.Forms.TextBox admintextBox;
        private System.Windows.Forms.TextBox DeviceIPtextBox;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TabPage Multiuser;
        private System.Windows.Forms.Button deleteDevice;
        private System.Windows.Forms.Button addDevice;
    }
}

