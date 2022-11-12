using System.Drawing;
using System.Windows.Forms;
using GeneralDef;

namespace YuShiNetDevSDK.WinForm
{
    partial class NetDemo
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("(Right Click to Add Device)");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetDemo));
            this.presetIDCobBox = new System.Windows.Forms.ComboBox();
            this.Discovery = new System.Windows.Forms.Button();
            this.DeviceTree = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.mainTabCtrl = new System.Windows.Forms.TabControl();
            this.LiveView = new System.Windows.Forms.TabPage();
            this.groupBox39 = new System.Windows.Forms.GroupBox();
            this.ButtonStopVoice = new System.Windows.Forms.Button();
            this.ButtoncaptureNoPreview = new System.Windows.Forms.Button();
            this.ButtonStartVoice = new System.Windows.Forms.Button();
            this.ButtonStoprecord = new System.Windows.Forms.Button();
            this.ButtonStartrecrod = new System.Windows.Forms.Button();
            this.inputPcmBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.focusFarBtn = new System.Windows.Forms.Button();
            this.MoreBtn = new System.Windows.Forms.Button();
            this.zoomTeleBtn = new System.Windows.Forms.Button();
            this.focusNearBtn = new System.Windows.Forms.Button();
            this.zoomWideBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.PresetGBox = new System.Windows.Forms.GroupBox();
            this.presetNameText = new System.Windows.Forms.TextBox();
            this.presetDeleteBtn = new System.Windows.Forms.Button();
            this.presetSetBtn = new System.Windows.Forms.Button();
            this.presetGoToBtn = new System.Windows.Forms.Button();
            this.presetGetBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PTZRDBtn = new System.Windows.Forms.Button();
            this.PTZRBtn = new System.Windows.Forms.Button();
            this.PTZRUBtn = new System.Windows.Forms.Button();
            this.PTZDBtn = new System.Windows.Forms.Button();
            this.PTZStopBtn = new System.Windows.Forms.Button();
            this.PTZUBtn = new System.Windows.Forms.Button();
            this.PTZLDBtn = new System.Windows.Forms.Button();
            this.PTZLBtn = new System.Windows.Forms.Button();
            this.ptzLUBtn = new System.Windows.Forms.Button();
            this.PTZSpeedTrackBar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.LayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.PannelPlayCtrl = new System.Windows.Forms.GroupBox();
            this.Sequence = new System.Windows.Forms.Button();
            this.LocalRecodBtn = new System.Windows.Forms.Button();
            this.CapturePicture = new System.Windows.Forms.Button();
            this.StopRealPlay = new System.Windows.Forms.Button();
            this.RealPlay = new System.Windows.Forms.Button();
            this.group_win = new System.Windows.Forms.GroupBox();
            this.comboBoxMultiScreen = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupSound = new System.Windows.Forms.GroupBox();
            this.SliSoundVolume = new System.Windows.Forms.TrackBar();
            this.SoundBtn = new System.Windows.Forms.Button();
            this.SliMicVolume = new System.Windows.Forms.TrackBar();
            this.MicVolumeBtn = new System.Windows.Forms.Button();
            this.Playback = new System.Windows.Forms.TabPage();
            this.GetRecordDays = new System.Windows.Forms.Button();
            this.BoxPositionList = new System.Windows.Forms.ComboBox();
            this.playBackLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PBDownLoadStopBtn = new System.Windows.Forms.Button();
            this.PBDownLoadInfoBtn = new System.Windows.Forms.Button();
            this.PBDownLoadStartBtn = new System.Windows.Forms.Button();
            this.PBVideoTimeListView = new System.Windows.Forms.ListView();
            this.BeginTime = new System.Windows.Forms.ColumnHeader();
            this.EndTime = new System.Windows.Forms.ColumnHeader();
            this.PBQueryBtn = new System.Windows.Forms.Button();
            this.PBVideoTrackBar = new System.Windows.Forms.TrackBar();
            this.PBVolTrackBar = new System.Windows.Forms.TrackBar();
            this.PBEventType = new System.Windows.Forms.ComboBox();
            this.PBEndTime = new System.Windows.Forms.DateTimePicker();
            this.PBEndDate = new System.Windows.Forms.DateTimePicker();
            this.PBBeginTime = new System.Windows.Forms.DateTimePicker();
            this.PBBeginDate = new System.Windows.Forms.DateTimePicker();
            this.PBShowFBSpeedLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.PBRemainingTimeLabel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.PBVideoDateTimeLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.PBVolBtn = new System.Windows.Forms.Button();
            this.PBFrameBtn = new System.Windows.Forms.Button();
            this.PBRestartBtn = new System.Windows.Forms.Button();
            this.PBCaptureBtn = new System.Windows.Forms.Button();
            this.PBFastForwardBtn = new System.Windows.Forms.Button();
            this.PBFastBackwardBtn = new System.Windows.Forms.Button();
            this.PBStopBtn = new System.Windows.Forms.Button();
            this.PBPauseBtn = new System.Windows.Forms.Button();
            this.PBStartBtn = new System.Windows.Forms.Button();
            this.Configure = new System.Windows.Forms.TabPage();
            this.cfgTabControl = new System.Windows.Forms.TabControl();
            this.ConfigBasic = new System.Windows.Forms.TabPage();
            this.GetHDDSmartInfo = new System.Windows.Forms.Button();
            this.BaiscRefreshBtn = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.BasicHDInfoListView = new System.Windows.Forms.ListView();
            this.HardDiskNo = new System.Windows.Forms.ColumnHeader();
            this.HardDiskTotalCapacity = new System.Windows.Forms.ColumnHeader();
            this.HardDiskFreeSpace = new System.Windows.Forms.ColumnHeader();
            this.HardDiskStatus = new System.Windows.Forms.ColumnHeader();
            this.HardDiskManufacturer = new System.Windows.Forms.ColumnHeader();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.BasicDeviceNameText = new System.Windows.Forms.TextBox();
            this.BasicDeviceNameSaveBtn = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.BasicSysTimeSaveBtn = new System.Windows.Forms.Button();
            this.BasicTime = new System.Windows.Forms.DateTimePicker();
            this.BasicDate = new System.Windows.Forms.DateTimePicker();
            this.BasicGMTCobBox = new System.Windows.Forms.ComboBox();
            this.ConfigNetwork = new System.Windows.Forms.TabPage();
            this.NetworkRefreshBtn = new System.Windows.Forms.Button();
            this.NetSaveBtn = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.NetNTPSaveBtn = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.NetNTPServerIPText = new System.Windows.Forms.TextBox();
            this.NetNTPDHCPCkBox = new System.Windows.Forms.CheckBox();
            this.NetNTPIPTypeCobBox = new System.Windows.Forms.ComboBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.NetPortSaveBtn = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.NetPortRTSPText = new System.Windows.Forms.TextBox();
            this.NetPortHTTPSText = new System.Windows.Forms.TextBox();
            this.NetPortHTTPText = new System.Windows.Forms.TextBox();
            this.NetPortRTSPCobBox = new System.Windows.Forms.ComboBox();
            this.NetPortHTTPSCobBox = new System.Windows.Forms.ComboBox();
            this.NetPortHTTPCobBox = new System.Windows.Forms.ComboBox();
            this.NetMTUText = new System.Windows.Forms.TextBox();
            this.NetGatwayText = new System.Windows.Forms.TextBox();
            this.NetSubMaskText = new System.Windows.Forms.TextBox();
            this.NetIPAddText = new System.Windows.Forms.TextBox();
            this.NetDHCPCkBox = new System.Windows.Forms.CheckBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.ConfigVideo = new System.Windows.Forms.TabPage();
            this.VideoRefreshBtn = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.VideoSaveBtn = new System.Windows.Forms.Button();
            this.VideoResolutionHText = new System.Windows.Forms.TextBox();
            this.VideoGopText = new System.Windows.Forms.TextBox();
            this.VideoFrameRateText = new System.Windows.Forms.TextBox();
            this.VideoBitRateText = new System.Windows.Forms.TextBox();
            this.VideoResolutionWText = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.VideoQualityCobBox = new System.Windows.Forms.ComboBox();
            this.label40 = new System.Windows.Forms.Label();
            this.VideoEncodeFormatCobBox = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.VideoStreamIndexCobBox = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.ConfigImage = new System.Windows.Forms.TabPage();
            this.ImageRefreshBtn = new System.Windows.Forms.Button();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.ImageSaveBtn = new System.Windows.Forms.Button();
            this.label50 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.SharpnessText = new System.Windows.Forms.TextBox();
            this.ContrastText = new System.Windows.Forms.TextBox();
            this.SaturationText = new System.Windows.Forms.TextBox();
            this.BrightnessText = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.SharpnessTrackBar = new System.Windows.Forms.TrackBar();
            this.ContrastTrackBar = new System.Windows.Forms.TrackBar();
            this.SaturationTrackBar = new System.Windows.Forms.TrackBar();
            this.BrightnessTrackBar = new System.Windows.Forms.TrackBar();
            this.ConfigOSD = new System.Windows.Forms.TabPage();
            this.OSDRefreshBtn = new System.Windows.Forms.Button();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.OSDText6CheckBox = new System.Windows.Forms.CheckBox();
            this.OSDText5CheckBox = new System.Windows.Forms.CheckBox();
            this.OSDText4CheckBox = new System.Windows.Forms.CheckBox();
            this.OSDText3CheckBox = new System.Windows.Forms.CheckBox();
            this.OSDText2CheckBox = new System.Windows.Forms.CheckBox();
            this.OSDText1CheckBox = new System.Windows.Forms.CheckBox();
            this.OSDNameCheckBox = new System.Windows.Forms.CheckBox();
            this.OSDTimeCheckBox = new System.Windows.Forms.CheckBox();
            this.OSDSaveBtn = new System.Windows.Forms.Button();
            this.OSDText6PointY = new System.Windows.Forms.TextBox();
            this.OSDText5PointY = new System.Windows.Forms.TextBox();
            this.OSDText4PointY = new System.Windows.Forms.TextBox();
            this.OSDText3PointY = new System.Windows.Forms.TextBox();
            this.OSDText2PointY = new System.Windows.Forms.TextBox();
            this.OSDText1PointY = new System.Windows.Forms.TextBox();
            this.OSDNamePointYText = new System.Windows.Forms.TextBox();
            this.OSDTimePointYText = new System.Windows.Forms.TextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.OSDText6 = new System.Windows.Forms.TextBox();
            this.OSDText6PointX = new System.Windows.Forms.TextBox();
            this.OSDText5 = new System.Windows.Forms.TextBox();
            this.OSDText5PointX = new System.Windows.Forms.TextBox();
            this.OSDText4 = new System.Windows.Forms.TextBox();
            this.OSDText4PointX = new System.Windows.Forms.TextBox();
            this.OSDText3 = new System.Windows.Forms.TextBox();
            this.OSDText3PointX = new System.Windows.Forms.TextBox();
            this.label73 = new System.Windows.Forms.Label();
            this.OSDText2 = new System.Windows.Forms.TextBox();
            this.label70 = new System.Windows.Forms.Label();
            this.OSDText2PointX = new System.Windows.Forms.TextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.OSDText1 = new System.Windows.Forms.TextBox();
            this.label64 = new System.Windows.Forms.Label();
            this.OSDText1PointX = new System.Windows.Forms.TextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.OSDNameText = new System.Windows.Forms.TextBox();
            this.label69 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.OSDNamePointXText = new System.Windows.Forms.TextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.OSDTimePointXText = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.OSDDateCobBox = new System.Windows.Forms.ComboBox();
            this.OSDTimeCobBox = new System.Windows.Forms.ComboBox();
            this.ConfigIO = new System.Windows.Forms.TabPage();
            this.IORefreshBtn = new System.Windows.Forms.Button();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.IOAlarmOutputSaveBtn = new System.Windows.Forms.Button();
            this.IOAlarmOutputTriggerBtn = new System.Windows.Forms.Button();
            this.IOAlarmOutputDelayText = new System.Windows.Forms.TextBox();
            this.IOAlarmOutputChannelID = new System.Windows.Forms.TextBox();
            this.label78 = new System.Windows.Forms.Label();
            this.IOAlarmOutputNameText = new System.Windows.Forms.TextBox();
            this.label77 = new System.Windows.Forms.Label();
            this.IOAlarmOutputStatusCobBox = new System.Windows.Forms.ComboBox();
            this.IOAlarmOutputIndexCobBox = new System.Windows.Forms.ComboBox();
            this.label79 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.IOAlarmInputListView = new System.Windows.Forms.ListView();
            this.AlarmName = new System.Windows.Forms.ColumnHeader();
            this.ConfigPrivacyMask = new System.Windows.Forms.TabPage();
            this.PrivacyMaskRefreshBtn = new System.Windows.Forms.Button();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.privacyMaskSubItemText = new System.Windows.Forms.TextBox();
            this.privacyMaskModifyBtn = new System.Windows.Forms.Button();
            this.PrivacyMaskSaveBtn = new System.Windows.Forms.Button();
            this.PrivacyMaskDelBtn = new System.Windows.Forms.Button();
            this.PrivacyMaskAddBtn = new System.Windows.Forms.Button();
            this.privacyMaskInfoListView = new System.Windows.Forms.ListView();
            this.PrivacyMaskNo = new System.Windows.Forms.ColumnHeader();
            this.PrivacyMaskLeftTopX = new System.Windows.Forms.ColumnHeader();
            this.PrivacyMaskLeftTopY = new System.Windows.Forms.ColumnHeader();
            this.PrivacyMaskRightBottomX = new System.Windows.Forms.ColumnHeader();
            this.PrivacyMaskRightBottomY = new System.Windows.Forms.ColumnHeader();
            this.ConfigMotion = new System.Windows.Forms.TabPage();
            this.MotionRefreshBtn = new System.Windows.Forms.Button();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.MotionSaveBtn = new System.Windows.Forms.Button();
            this.label81 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.MotionHistoryText = new System.Windows.Forms.TextBox();
            this.MotionObjectSizeText = new System.Windows.Forms.TextBox();
            this.MotionSensitivityText = new System.Windows.Forms.TextBox();
            this.label85 = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.MotionHistoryTrackBar = new System.Windows.Forms.TrackBar();
            this.MotionObjectSizeTrackBar = new System.Windows.Forms.TrackBar();
            this.MotionSensitivityTrackBar = new System.Windows.Forms.TrackBar();
            this.ConfigTemper = new System.Windows.Forms.TabPage();
            this.TemperRefreshBtn = new System.Windows.Forms.Button();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.TemperSaveBtn = new System.Windows.Forms.Button();
            this.label80 = new System.Windows.Forms.Label();
            this.TemperSensitivityText = new System.Windows.Forms.TextBox();
            this.label89 = new System.Windows.Forms.Label();
            this.TemperSensitivityTrackBar = new System.Windows.Forms.TrackBar();
            this.AlarmRecords = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.AlarmRecordsListView = new System.Windows.Forms.ListView();
            this.AlarmRecordTime = new System.Windows.Forms.ColumnHeader();
            this.AlarmRecordIP = new System.Windows.Forms.ColumnHeader();
            this.AlarmRecordChannelID = new System.Windows.Forms.ColumnHeader();
            this.AlarmRecordInfo = new System.Windows.Forms.ColumnHeader();
            this.AlarmRecordsClearBtn = new System.Windows.Forms.Button();
            this.VCA = new System.Windows.Forms.TabPage();
            this.VCATabCtrl = new System.Windows.Forms.TabControl();
            this.PeopleCountingforReport = new System.Windows.Forms.TabPage();
            this.VCAReportDataListView = new System.Windows.Forms.ListView();
            this.DeviceIP = new System.Windows.Forms.ColumnHeader();
            this.ChannelID = new System.Windows.Forms.ColumnHeader();
            this.ReportTime = new System.Windows.Forms.ColumnHeader();
            this.IntervalTime = new System.Windows.Forms.ColumnHeader();
            this.EnterNumber = new System.Windows.Forms.ColumnHeader();
            this.ExitNumber = new System.Windows.Forms.ColumnHeader();
            this.TotalEnterNumber = new System.Windows.Forms.ColumnHeader();
            this.TotalExitNumber = new System.Windows.Forms.ColumnHeader();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.VCAClearDataBtn = new System.Windows.Forms.Button();
            this.VCACloseCallBackBtn = new System.Windows.Forms.Button();
            this.VCARegCallBackBtn = new System.Windows.Forms.Button();
            this.PeopleCountingforStatistics = new System.Windows.Forms.TabPage();
            this.VCAStatisticalTime = new System.Windows.Forms.DateTimePicker();
            this.VCACountingType = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.VCAReportType = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.VCAStatisticDataListView = new System.Windows.Forms.ListView();
            this.StatisticalTime = new System.Windows.Forms.ColumnHeader();
            this.PeopleEntered = new System.Windows.Forms.ColumnHeader();
            this.PeopleLeft = new System.Windows.Forms.ColumnHeader();
            this.label16 = new System.Windows.Forms.Label();
            this.VCACountBtn = new System.Windows.Forms.Button();
            this.FaceTabPage = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.FaceRealtimeMonitoringTabPage = new System.Windows.Forms.TabPage();
            this.groupBox27 = new System.Windows.Forms.GroupBox();
            this.faceSnapshotSubBtn = new System.Windows.Forms.Button();
            this.faceSnapshotUnSubBtn = new System.Windows.Forms.Button();
            this.groupBox26 = new System.Windows.Forms.GroupBox();
            this.faceRecogSubBtn = new System.Windows.Forms.Button();
            this.faceRecogUnSubBtn = new System.Windows.Forms.Button();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.faceRecogRealPlayStartBtn = new System.Windows.Forms.Button();
            this.faceRecogRealPlayStopBtn = new System.Windows.Forms.Button();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.similarityLab = new System.Windows.Forms.Label();
            this.faceRecogAlarmRecordsListView = new System.Windows.Forms.ListView();
            this.FaceRecogMatchRecordAlarmTimeCHeader = new System.Windows.Forms.ColumnHeader();
            this.FaceRecogMatchRecordNameCHeader = new System.Windows.Forms.ColumnHeader();
            this.FaceRecogMatchRecordIDNoCHeader = new System.Windows.Forms.ColumnHeader();
            this.FaceRecogMatchRecordMatchCHeader = new System.Windows.Forms.ColumnHeader();
            this.FaceRecogMatchRecordAlarmSourceCHeader = new System.Windows.Forms.ColumnHeader();
            this.personLibPictureBox = new System.Windows.Forms.PictureBox();
            this.snapshotPictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.faceSnapshotPicTimeLab = new System.Windows.Forms.Label();
            this.faceSnapshotSmallPictureBox = new System.Windows.Forms.PictureBox();
            this.faceSnapshotLargePictureBox = new System.Windows.Forms.PictureBox();
            this.faceRecogRealPlayFLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.FaceLibraryManagenentTabPage = new System.Windows.Forms.TabPage();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.nextPersonInfoBtn = new System.Windows.Forms.Button();
            this.previousPersonInfoBtn = new System.Windows.Forms.Button();
            this.delPersonInfoBtn = new System.Windows.Forms.Button();
            this.modifyPersonInfoBtn = new System.Windows.Forms.Button();
            this.addPersonInfoBtn = new System.Windows.Forms.Button();
            this.findPersonInfoBtn = new System.Windows.Forms.Button();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.personInfoBirthText = new System.Windows.Forms.TextBox();
            this.personInfoImagePictureBox = new System.Windows.Forms.PictureBox();
            this.personInfoGenderCmb = new System.Windows.Forms.ComboBox();
            this.personInfoCityText = new System.Windows.Forms.TextBox();
            this.personInfoIDNoText = new System.Windows.Forms.TextBox();
            this.personInfoCityLab = new System.Windows.Forms.Label();
            this.personInfoIDNoLab = new System.Windows.Forms.Label();
            this.personInfoIDTypeCmb = new System.Windows.Forms.ComboBox();
            this.personInfoNationalityText = new System.Windows.Forms.TextBox();
            this.personInfoProvinceText = new System.Windows.Forms.TextBox();
            this.personInfoProvinceLab = new System.Windows.Forms.Label();
            this.personInfoNationalityLab = new System.Windows.Forms.Label();
            this.personInfoIDTypeLab = new System.Windows.Forms.Label();
            this.personInfoGenderLab = new System.Windows.Forms.Label();
            this.personInfoNameText = new System.Windows.Forms.TextBox();
            this.personInfoBirthdayLab = new System.Windows.Forms.Label();
            this.personInfoNameLab = new System.Windows.Forms.Label();
            this.personInfoListView = new System.Windows.Forms.ListView();
            this.personInfoIDColHeader = new System.Windows.Forms.ColumnHeader();
            this.PersonName = new System.Windows.Forms.ColumnHeader();
            this.PersonGender = new System.Windows.Forms.ColumnHeader();
            this.PersonDateOfBirth = new System.Windows.Forms.ColumnHeader();
            this.PersonNationality = new System.Windows.Forms.ColumnHeader();
            this.PersonProvince = new System.Windows.Forms.ColumnHeader();
            this.PersonCity = new System.Windows.Forms.ColumnHeader();
            this.PersonIDType = new System.Windows.Forms.ColumnHeader();
            this.PersonIDNo = new System.Windows.Forms.ColumnHeader();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.PersonLibNameText = new System.Windows.Forms.TextBox();
            this.personLibCmb = new System.Windows.Forms.ComboBox();
            this.delPersonLibBtn = new System.Windows.Forms.Button();
            this.modifyPersonLibBtn = new System.Windows.Forms.Button();
            this.addPersonLibBtn = new System.Windows.Forms.Button();
            this.findPersonLibBtn = new System.Windows.Forms.Button();
            this.FaceMonitoringTaskTabPage = new System.Windows.Forms.TabPage();
            this.faceMonitorTaskLibNameText = new System.Windows.Forms.TextBox();
            this.disableFaceMonitorBtn = new System.Windows.Forms.Button();
            this.enableFaceMonitorBtn = new System.Windows.Forms.Button();
            this.delFaceMonitorBtn = new System.Windows.Forms.Button();
            this.modifyFaceMonitorBtn = new System.Windows.Forms.Button();
            this.FindFaceMonitorBtn = new System.Windows.Forms.Button();
            this.faceMonitorInfoListView = new System.Windows.Forms.ListView();
            this.LPRmonitorTaskIDColHeader = new System.Windows.Forms.ColumnHeader();
            this.LPRmonitorTaskNameColHeader = new System.Windows.Forms.ColumnHeader();
            this.LPRmonitorTaskRemarksColHeader = new System.Windows.Forms.ColumnHeader();
            this.LPRmonitorThresholdColHeader = new System.Windows.Forms.ColumnHeader();
            this.LPRmonitorObjectColHeader = new System.Windows.Forms.ColumnHeader();
            this.LPRmonitorStatusColHeader = new System.Windows.Forms.ColumnHeader();
            this.addFaceMonitorBtn = new System.Windows.Forms.Button();
            this.faceMonitorThresholdTextBox = new System.Windows.Forms.TextBox();
            this.label84 = new System.Windows.Forms.Label();
            this.faceMonitorObjectCmbBox = new System.Windows.Forms.ComboBox();
            this.faceMonitorTypeCmbBox = new System.Windows.Forms.ComboBox();
            this.faceMonitorRemarksTextBox = new System.Windows.Forms.TextBox();
            this.faceMonitorTaskNameTextBox = new System.Windows.Forms.TextBox();
            this.faceMonitorTaskObjectLab = new System.Windows.Forms.Label();
            this.faceMonitorTaskRemarksLab = new System.Windows.Forms.Label();
            this.faceMonitorTaskTypeLab = new System.Windows.Forms.Label();
            this.faceMonitorTaskNameLab = new System.Windows.Forms.Label();
            this.FaceAlarmRecordTabPage = new System.Windows.Forms.TabPage();
            this.faceAlarmRecordNextBtn = new System.Windows.Forms.Button();
            this.faceAlarmRecordPreviousBtn = new System.Windows.Forms.Button();
            this.faceAlarmRecordSearchBtn = new System.Windows.Forms.Button();
            this.faceAlarmRecordMonitorTypeCmbBox = new System.Windows.Forms.ComboBox();
            this.label100 = new System.Windows.Forms.Label();
            this.faceAlarmRecordEndTimeDT = new System.Windows.Forms.DateTimePicker();
            this.faceAlarmRecordBeginTimeDT = new System.Windows.Forms.DateTimePicker();
            this.label99 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.faceAlarmRecordDataGridView = new System.Windows.Forms.DataGridView();
            this.faceAlarmRecordSnapImageDataGVImgCol = new System.Windows.Forms.DataGridViewImageColumn();
            this.faceAlarmRecordLibImageDataGVImgCol = new System.Windows.Forms.DataGridViewImageColumn();
            this.faceAlarmRecordTimeDataGVTextCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.faceAlarmRecordSourceDataGVTextCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.faceAlarmRecordNameDataGVTextCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.faceAlarmRecordIDNoDataGVTextCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.faceAlarmRecordMatchDataGVTextCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FacePassThruRecordTabPage = new System.Windows.Forms.TabPage();
            this.facePassThruRecordAlarmSourceText = new System.Windows.Forms.TextBox();
            this.label103 = new System.Windows.Forms.Label();
            this.facePassThruRecordNextBtn = new System.Windows.Forms.Button();
            this.facePassThruRecordPreviousBtn = new System.Windows.Forms.Button();
            this.facePassThruRecordSearchBtn = new System.Windows.Forms.Button();
            this.label101 = new System.Windows.Forms.Label();
            this.facePassThruRecordEndTimeDT = new System.Windows.Forms.DateTimePicker();
            this.facePassThruRecordBeginTimeDT = new System.Windows.Forms.DateTimePicker();
            this.label102 = new System.Windows.Forms.Label();
            this.facePassThruRecordDataGridView = new System.Windows.Forms.DataGridView();
            this.facePassThruRecordPanoImageDataGVImgCol = new System.Windows.Forms.DataGridViewImageColumn();
            this.facePassThruRecordFaceImageDataGVImgCol = new System.Windows.Forms.DataGridViewImageColumn();
            this.facePassThruRecordTimeDataGVTextCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.facePassThruRecordAlarmSourceDataGVTextCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LicensePlateRecognitionTabPage = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.LPRRealtimeMonitoringTabPage = new System.Windows.Forms.TabPage();
            this.groupBox31 = new System.Windows.Forms.GroupBox();
            this.LPRSnapshotSubBtn = new System.Windows.Forms.Button();
            this.LPRSnapshotUnSubBtn = new System.Windows.Forms.Button();
            this.groupBox32 = new System.Windows.Forms.GroupBox();
            this.LPRRecogSubBtn = new System.Windows.Forms.Button();
            this.LPRRecogUnSubBtn = new System.Windows.Forms.Button();
            this.groupBox34 = new System.Windows.Forms.GroupBox();
            this.LPRRealPlayStartBtn = new System.Windows.Forms.Button();
            this.LPRRealPlayStopBtn = new System.Windows.Forms.Button();
            this.groupBox35 = new System.Windows.Forms.GroupBox();
            this.vehiclePanoRecogPicBox = new System.Windows.Forms.PictureBox();
            this.plateNoRecogLab = new System.Windows.Forms.Label();
            this.plateRecogPicBox = new System.Windows.Forms.PictureBox();
            this.LPRAlarmRecordsListView = new System.Windows.Forms.ListView();
            this.plateNoAlarmRecordColHeader = new System.Windows.Forms.ColumnHeader();
            this.LPRSnapshotTimeAlarmRecordColHeader = new System.Windows.Forms.ColumnHeader();
            this.plateColorAlarmRecordColHeader = new System.Windows.Forms.ColumnHeader();
            this.plateMatchAlarmRecordColHeader = new System.Windows.Forms.ColumnHeader();
            this.plateTypeAlarmRecordColHeader = new System.Windows.Forms.ColumnHeader();
            this.VehicleColorAlarmRecordColHeader = new System.Windows.Forms.ColumnHeader();
            this.LPRCameraNameAlarmRecordColHeader = new System.Windows.Forms.ColumnHeader();
            this.LPRCauseAlarmRecordColHeader = new System.Windows.Forms.ColumnHeader();
            this.groupBox36 = new System.Windows.Forms.GroupBox();
            this.vehicleSnapshotPicTimeLab = new System.Windows.Forms.Label();
            this.plateSnapshotSmallPictureBox = new System.Windows.Forms.PictureBox();
            this.vehicleSnapshotLargePictureBox = new System.Windows.Forms.PictureBox();
            this.LPRRealPlayFLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.LPRVehicleLibraryManagemnetTabPage = new System.Windows.Forms.TabPage();
            this.groupBox28 = new System.Windows.Forms.GroupBox();
            this.delVehicleInfoBtn = new System.Windows.Forms.Button();
            this.modifyVehicleInfoBtn = new System.Windows.Forms.Button();
            this.addVehicleInfoBtn = new System.Windows.Forms.Button();
            this.FindVehicleInfoBtn = new System.Windows.Forms.Button();
            this.groupBox29 = new System.Windows.Forms.GroupBox();
            this.plateAreaCmb = new System.Windows.Forms.ComboBox();
            this.PlateTypeCmb = new System.Windows.Forms.ComboBox();
            this.plateColorCmb = new System.Windows.Forms.ComboBox();
            this.vehicleColorCmb = new System.Windows.Forms.ComboBox();
            this.label98 = new System.Windows.Forms.Label();
            this.label94 = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.plateNoText = new System.Windows.Forms.TextBox();
            this.label97 = new System.Windows.Forms.Label();
            this.vehicleInfoListView = new System.Windows.Forms.ListView();
            this.LPRVehicleInfoPlateIDColHeader = new System.Windows.Forms.ColumnHeader();
            this.LPRVehicleInfoPlateNoColHeader = new System.Windows.Forms.ColumnHeader();
            this.LPRVehicleInfoPlateColorColHeader = new System.Windows.Forms.ColumnHeader();
            this.LPRVehicleInfoPlateTypeColHeader = new System.Windows.Forms.ColumnHeader();
            this.LPRVehicleInfoVehicleColorColHeader = new System.Windows.Forms.ColumnHeader();
            this.LPRVehicleInfoStatusColHeader = new System.Windows.Forms.ColumnHeader();
            this.groupBox30 = new System.Windows.Forms.GroupBox();
            this.vehicleLibNameText = new System.Windows.Forms.TextBox();
            this.vehicleLibCmb = new System.Windows.Forms.ComboBox();
            this.delVehicleLibBtn = new System.Windows.Forms.Button();
            this.modifyVehicleLibBtn = new System.Windows.Forms.Button();
            this.addVehicleLibBtn = new System.Windows.Forms.Button();
            this.FindVehicleLibBtn = new System.Windows.Forms.Button();
            this.LPRMonitoringTaskTabPage = new System.Windows.Forms.TabPage();
            this.vehicleMonitorTaskLibNameText = new System.Windows.Forms.TextBox();
            this.disableVehicleMonitorBtn = new System.Windows.Forms.Button();
            this.enableVehicleMonitorBtn = new System.Windows.Forms.Button();
            this.DelVehicleMonitorBtn = new System.Windows.Forms.Button();
            this.modifyVehicleMonitorBtn = new System.Windows.Forms.Button();
            this.FindVehicleMonitorBtn = new System.Windows.Forms.Button();
            this.vehicleMonitorInfoListView = new System.Windows.Forms.ListView();
            this.vehicleMonitorTaskIDColHeader = new System.Windows.Forms.ColumnHeader();
            this.vehicleMonitorTaskNameColHeader = new System.Windows.Forms.ColumnHeader();
            this.vehicleMonitorRemarksColHeader = new System.Windows.Forms.ColumnHeader();
            this.vehicleMonitorTypeColHeader = new System.Windows.Forms.ColumnHeader();
            this.vehicleMonitorStatusColHeader = new System.Windows.Forms.ColumnHeader();
            this.addVehicleMonitorBtn = new System.Windows.Forms.Button();
            this.vehicleMonitorObjectCmbBox = new System.Windows.Forms.ComboBox();
            this.vehicleCauseCmbBox = new System.Windows.Forms.ComboBox();
            this.vehicleMonitorTypeCmbBox = new System.Windows.Forms.ComboBox();
            this.vehicleMonitorRemarksText = new System.Windows.Forms.TextBox();
            this.vehicleMonitorTaskNameText = new System.Windows.Forms.TextBox();
            this.label90 = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.label92 = new System.Windows.Forms.Label();
            this.label93 = new System.Windows.Forms.Label();
            this.LPRAlarmAndPassThruRecordTabPage = new System.Windows.Forms.TabPage();
            this.LPRAlarmRecordMonitoringCauseCmbBox = new System.Windows.Forms.ComboBox();
            this.label112 = new System.Windows.Forms.Label();
            this.LPRAlarmRecordMonitoringTypeCmbBox = new System.Windows.Forms.ComboBox();
            this.label111 = new System.Windows.Forms.Label();
            this.LPRAlarmRecordSearchTypeCmbBox = new System.Windows.Forms.ComboBox();
            this.label110 = new System.Windows.Forms.Label();
            this.LPRAlarmRecordSearchVehicleColorCmbBox = new System.Windows.Forms.ComboBox();
            this.label109 = new System.Windows.Forms.Label();
            this.LPRAlarmRecordSearchPlateColorCmbBox = new System.Windows.Forms.ComboBox();
            this.label108 = new System.Windows.Forms.Label();
            this.LPRAlarmRecordSearchPlateNoText = new System.Windows.Forms.TextBox();
            this.label107 = new System.Windows.Forms.Label();
            this.LPRAlarmRecordSearchCameraNameText = new System.Windows.Forms.TextBox();
            this.label104 = new System.Windows.Forms.Label();
            this.LPRAlarmRecordNextBtn = new System.Windows.Forms.Button();
            this.LPRAlarmRecordPreviousBtn = new System.Windows.Forms.Button();
            this.LPRAlarmRecordSearchBtn = new System.Windows.Forms.Button();
            this.label105 = new System.Windows.Forms.Label();
            this.LPRAlarmRecordSearchEndTimeDT = new System.Windows.Forms.DateTimePicker();
            this.LPRAlarmRecordSearchBeginTimeDT = new System.Windows.Forms.DateTimePicker();
            this.label106 = new System.Windows.Forms.Label();
            this.LPRAlarmRecordDataGridView = new System.Windows.Forms.DataGridView();
            this.LPRAlarmRecordPlateImageDataGVImgCol = new System.Windows.Forms.DataGridViewImageColumn();
            this.LPRAlarmRecordPlateNoDataGVTextCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LPRAlarmRecordPlateColorDataGVTextCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LPRAlarmRecordPlateTypeDataGVTextCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LPRAlarmRecordVehicleColorDataGVTextCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LPRAlarmRecordCameraNameDataGVTextCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LPRAlarmRecordTimeDataGVTextCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Maintenance = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.factoryDefaultBtn = new System.Windows.Forms.Button();
            this.RebootBtn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label120 = new System.Windows.Forms.Label();
            this.groupBox38 = new System.Windows.Forms.GroupBox();
            this.label119 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.ModifyCurPwd = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label118 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label117 = new System.Windows.Forms.Label();
            this.label116 = new System.Windows.Forms.Label();
            this.label115 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label114 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label113 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.UserID = new System.Windows.Forms.Label();
            this.groupBox37 = new System.Windows.Forms.GroupBox();
            this.listView3 = new System.Windows.Forms.ListView();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.groupBox33 = new System.Windows.Forms.GroupBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupDiscovery = new System.Windows.Forms.GroupBox();
            this.deviceOper = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Login = new System.Windows.Forms.ToolStripMenuItem();
            this.Logout = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.Property = new System.Windows.Forms.ToolStripMenuItem();
            this.rootOper = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.LocalDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.cleanLogBtn = new System.Windows.Forms.Button();
            this.settingLogBtn = new System.Windows.Forms.Button();
            this.logListView = new System.Windows.Forms.ListView();
            this.Time = new System.Windows.Forms.ColumnHeader();
            this.DeviceInfo = new System.Windows.Forms.ColumnHeader();
            this.Operation = new System.Windows.Forms.ColumnHeader();
            this.Status = new System.Windows.Forms.ColumnHeader();
            this.ErrorCode = new System.Windows.Forms.ColumnHeader();
            this.PannelContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Close = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ProcessingMode = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowDelay = new System.Windows.Forms.ToolStripMenuItem();
            this.Fluent = new System.Windows.Forms.ToolStripMenuItem();
            this.MakeKeyFrame = new System.Windows.Forms.ToolStripMenuItem();
            this.DigitalZoom = new System.Windows.Forms.ToolStripMenuItem();
            this.ThreeDPosition = new System.Windows.Forms.ToolStripMenuItem();
            this.TwoWayAudio = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.FullScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.MultiScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.CameraInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTabCtrl.SuspendLayout();
            this.LiveView.SuspendLayout();
            this.groupBox39.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.PresetGBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PTZSpeedTrackBar)).BeginInit();
            this.PannelPlayCtrl.SuspendLayout();
            this.group_win.SuspendLayout();
            this.groupSound.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SliSoundVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SliMicVolume)).BeginInit();
            this.Playback.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBVideoTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBVolTrackBar)).BeginInit();
            this.Configure.SuspendLayout();
            this.cfgTabControl.SuspendLayout();
            this.ConfigBasic.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.ConfigNetwork.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.ConfigVideo.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.ConfigImage.SuspendLayout();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SharpnessTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContrastTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaturationTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessTrackBar)).BeginInit();
            this.ConfigOSD.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.ConfigIO.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.ConfigPrivacyMask.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.ConfigMotion.SuspendLayout();
            this.groupBox17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MotionHistoryTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MotionObjectSizeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MotionSensitivityTrackBar)).BeginInit();
            this.ConfigTemper.SuspendLayout();
            this.groupBox18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TemperSensitivityTrackBar)).BeginInit();
            this.AlarmRecords.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.VCA.SuspendLayout();
            this.VCATabCtrl.SuspendLayout();
            this.PeopleCountingforReport.SuspendLayout();
            this.PeopleCountingforStatistics.SuspendLayout();
            this.FaceTabPage.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.FaceRealtimeMonitoringTabPage.SuspendLayout();
            this.groupBox27.SuspendLayout();
            this.groupBox26.SuspendLayout();
            this.groupBox24.SuspendLayout();
            this.groupBox23.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personLibPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.snapshotPictureBox)).BeginInit();
            this.groupBox22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.faceSnapshotSmallPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.faceSnapshotLargePictureBox)).BeginInit();
            this.FaceLibraryManagenentTabPage.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personInfoImagePictureBox)).BeginInit();
            this.groupBox19.SuspendLayout();
            this.FaceMonitoringTaskTabPage.SuspendLayout();
            this.FaceAlarmRecordTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.faceAlarmRecordDataGridView)).BeginInit();
            this.FacePassThruRecordTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facePassThruRecordDataGridView)).BeginInit();
            this.LicensePlateRecognitionTabPage.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.LPRRealtimeMonitoringTabPage.SuspendLayout();
            this.groupBox31.SuspendLayout();
            this.groupBox32.SuspendLayout();
            this.groupBox34.SuspendLayout();
            this.groupBox35.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vehiclePanoRecogPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plateRecogPicBox)).BeginInit();
            this.groupBox36.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plateSnapshotSmallPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleSnapshotLargePictureBox)).BeginInit();
            this.LPRVehicleLibraryManagemnetTabPage.SuspendLayout();
            this.groupBox28.SuspendLayout();
            this.groupBox29.SuspendLayout();
            this.groupBox30.SuspendLayout();
            this.LPRMonitoringTaskTabPage.SuspendLayout();
            this.LPRAlarmAndPassThruRecordTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LPRAlarmRecordDataGridView)).BeginInit();
            this.Maintenance.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox38.SuspendLayout();
            this.groupBox37.SuspendLayout();
            this.groupBox33.SuspendLayout();
            this.groupBox25.SuspendLayout();
            this.groupDiscovery.SuspendLayout();
            this.deviceOper.SuspendLayout();
            this.rootOper.SuspendLayout();
            this.PannelContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // presetIDCobBox
            // 
            this.presetIDCobBox.FormattingEnabled = true;
            this.presetIDCobBox.Location = new System.Drawing.Point(90, 15);
            this.presetIDCobBox.Name = "presetIDCobBox";
            this.presetIDCobBox.Size = new System.Drawing.Size(60, 25);
            this.presetIDCobBox.TabIndex = 1;
            this.presetIDCobBox.SelectedIndexChanged += new System.EventHandler(this.presetIDCobBox_SelectedIndexChanged);
            // 
            // Discovery
            // 
            this.Discovery.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Discovery.Location = new System.Drawing.Point(35, 14);
            this.Discovery.Name = "Discovery";
            this.Discovery.Size = new System.Drawing.Size(80, 30);
            this.Discovery.TabIndex = 0;
            this.Discovery.Text = "Discovery";
            this.Discovery.UseVisualStyleBackColor = true;
            this.Discovery.Click += new System.EventHandler(this.Discovery_Click);
            // 
            // DeviceTree
            // 
            this.DeviceTree.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DeviceTree.FullRowSelect = true;
            this.DeviceTree.HideSelection = false;
            this.DeviceTree.ImageIndex = 0;
            this.DeviceTree.ImageList = this.imageList1;
            this.DeviceTree.Location = new System.Drawing.Point(12, 65);
            this.DeviceTree.Name = "DeviceTree";
            treeNode1.ImageIndex = 0;
            treeNode1.Name = "root";
            treeNode1.Text = "(Right Click to Add Device)";
            this.DeviceTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.DeviceTree.SelectedImageIndex = 0;
            this.DeviceTree.Size = new System.Drawing.Size(189, 691);
            this.DeviceTree.TabIndex = 1;
            this.DeviceTree.DoubleClick += new System.EventHandler(this.DeviceTree_DoubleClick);
            this.DeviceTree.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DeviceTree_MouseUp);
            this.DeviceTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DeviceTree_MouseDown);
            this.DeviceTree.Click += new System.EventHandler(this.DeviceTree_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "tree.bmp");
            this.imageList1.Images.SetKeyName(1, "device.bmp");
            this.imageList1.Images.SetKeyName(2, "device_logout.bmp");
            this.imageList1.Images.SetKeyName(3, "login.bmp");
            this.imageList1.Images.SetKeyName(4, "logout.bmp");
            this.imageList1.Images.SetKeyName(5, "device.bmp");
            this.imageList1.Images.SetKeyName(6, "device_logout.bmp");
            this.imageList1.Images.SetKeyName(7, "org.bmp");
            // 
            // mainTabCtrl
            // 
            this.mainTabCtrl.Controls.Add(this.LiveView);
            this.mainTabCtrl.Controls.Add(this.Playback);
            this.mainTabCtrl.Controls.Add(this.Configure);
            this.mainTabCtrl.Controls.Add(this.AlarmRecords);
            this.mainTabCtrl.Controls.Add(this.VCA);
            this.mainTabCtrl.Controls.Add(this.Maintenance);
            this.mainTabCtrl.Controls.Add(this.tabPage1);
            this.mainTabCtrl.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mainTabCtrl.Location = new System.Drawing.Point(207, 12);
            this.mainTabCtrl.Name = "mainTabCtrl";
            this.mainTabCtrl.SelectedIndex = 0;
            this.mainTabCtrl.Size = new System.Drawing.Size(907, 636);
            this.mainTabCtrl.TabIndex = 2;
            this.mainTabCtrl.SelectedIndexChanged += new System.EventHandler(this.mainTabCtrlSelectedChanged);
            // 
            // LiveView
            // 
            this.LiveView.BackColor = System.Drawing.Color.DarkGray;
            this.LiveView.Controls.Add(this.groupBox39);
            this.LiveView.Controls.Add(this.inputPcmBtn);
            this.LiveView.Controls.Add(this.groupBox2);
            this.LiveView.Controls.Add(this.PresetGBox);
            this.LiveView.Controls.Add(this.groupBox1);
            this.LiveView.Controls.Add(this.LayoutPanel);
            this.LiveView.Controls.Add(this.PannelPlayCtrl);
            this.LiveView.Controls.Add(this.group_win);
            this.LiveView.Controls.Add(this.groupSound);
            this.LiveView.Location = new System.Drawing.Point(4, 26);
            this.LiveView.Name = "LiveView";
            this.LiveView.Padding = new System.Windows.Forms.Padding(3);
            this.LiveView.Size = new System.Drawing.Size(899, 606);
            this.LiveView.TabIndex = 0;
            this.LiveView.Text = "Live View";
            this.LiveView.UseVisualStyleBackColor = true;
            // 
            // groupBox39
            // 
            this.groupBox39.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox39.Controls.Add(this.ButtonStopVoice);
            this.groupBox39.Controls.Add(this.ButtoncaptureNoPreview);
            this.groupBox39.Controls.Add(this.ButtonStartVoice);
            this.groupBox39.Controls.Add(this.ButtonStoprecord);
            this.groupBox39.Controls.Add(this.ButtonStartrecrod);
            this.groupBox39.Location = new System.Drawing.Point(709, 433);
            this.groupBox39.Name = "groupBox39";
            this.groupBox39.Size = new System.Drawing.Size(184, 132);
            this.groupBox39.TabIndex = 9;
            this.groupBox39.TabStop = false;
            this.groupBox39.Text = "NoPreview";
            // 
            // ButtonStopVoice
            // 
            this.ButtonStopVoice.Enabled = true;
            this.ButtonStopVoice.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonStopVoice.Location = new System.Drawing.Point(97, 60);
            this.ButtonStopVoice.Name = "ButtonStopVoice";
            this.ButtonStopVoice.Size = new System.Drawing.Size(84, 30);
            this.ButtonStopVoice.TabIndex = 0;
            this.ButtonStopVoice.Text = "StopVoice";
            this.ButtonStopVoice.UseVisualStyleBackColor = true;
            this.ButtonStopVoice.Click += new System.EventHandler(this.ButtonStopVoice_Click);
            // 
            // ButtoncaptureNoPreview
            // 
            this.ButtoncaptureNoPreview.Enabled = true;
            this.ButtoncaptureNoPreview.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtoncaptureNoPreview.Location = new System.Drawing.Point(10, 96);
            this.ButtoncaptureNoPreview.Name = "ButtoncaptureNoPreview";
            this.ButtoncaptureNoPreview.Size = new System.Drawing.Size(79, 30);
            this.ButtoncaptureNoPreview.TabIndex = 0;
            this.ButtoncaptureNoPreview.Text = "SnapShot";
            this.ButtoncaptureNoPreview.UseVisualStyleBackColor = true;
            this.ButtoncaptureNoPreview.Click += new System.EventHandler(this.ButtoncaptureNoPreview_Click);
            // 
            // ButtonStartVoice
            // 
            this.ButtonStartVoice.Enabled = true;
            this.ButtonStartVoice.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonStartVoice.Location = new System.Drawing.Point(10, 60);
            this.ButtonStartVoice.Name = "ButtonStartVoice";
            this.ButtonStartVoice.Size = new System.Drawing.Size(79, 30);
            this.ButtonStartVoice.TabIndex = 0;
            this.ButtonStartVoice.Text = "StartVoice";
            this.ButtonStartVoice.UseVisualStyleBackColor = true;
            this.ButtonStartVoice.Click += new System.EventHandler(this.ButtonStartVoice_Click);
            // 
            // ButtonStoprecord
            // 
            this.ButtonStoprecord.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonStoprecord.Location = new System.Drawing.Point(96, 22);
            this.ButtonStoprecord.Name = "ButtonStoprecord";
            this.ButtonStoprecord.Size = new System.Drawing.Size(84, 30);
            this.ButtonStoprecord.TabIndex = 0;
            this.ButtonStoprecord.Text = "StopRecord";
            this.ButtonStoprecord.UseVisualStyleBackColor = true;
            this.ButtonStoprecord.Click += new System.EventHandler(this.ButtonStoprecord_Click);
            // 
            // ButtonStartrecrod
            // 
            this.ButtonStartrecrod.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonStartrecrod.Location = new System.Drawing.Point(10, 22);
            this.ButtonStartrecrod.Name = "ButtonStartrecrod";
            this.ButtonStartrecrod.Size = new System.Drawing.Size(79, 30);
            this.ButtonStartrecrod.TabIndex = 0;
            this.ButtonStartrecrod.Text = "StartRecord";
            this.ButtonStartrecrod.UseVisualStyleBackColor = true;
            this.ButtonStartrecrod.Click += new System.EventHandler(this.ButtonStartrecrod_Click);
            // 
            // inputPcmBtn
            // 
            this.inputPcmBtn.Enabled = true;
            this.inputPcmBtn.Location = new System.Drawing.Point(735, 574);
            this.inputPcmBtn.Name = "inputPcmBtn";
            this.inputPcmBtn.Size = new System.Drawing.Size(90, 23);
            this.inputPcmBtn.TabIndex = 9;
            this.inputPcmBtn.Text = "PCM input";
            this.inputPcmBtn.UseVisualStyleBackColor = true;
            this.inputPcmBtn.Visible = true;
            this.inputPcmBtn.Click += new System.EventHandler(this.inputPcmBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Controls.Add(this.focusFarBtn);
            this.groupBox2.Controls.Add(this.MoreBtn);
            this.groupBox2.Controls.Add(this.zoomTeleBtn);
            this.groupBox2.Controls.Add(this.focusNearBtn);
            this.groupBox2.Controls.Add(this.zoomWideBtn);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(709, 294);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(182, 137);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // focusFarBtn
            // 
            this.focusFarBtn.Enabled = false;
            this.focusFarBtn.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.focusFarBtn.Location = new System.Drawing.Point(100, 62);
            this.focusFarBtn.Name = "focusFarBtn";
            this.focusFarBtn.Size = new System.Drawing.Size(57, 30);
            this.focusFarBtn.TabIndex = 0;
            this.focusFarBtn.Text = "Far";
            this.focusFarBtn.UseVisualStyleBackColor = true;
            this.focusFarBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.focusFarBtn_MouseDown);
            this.focusFarBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.focusFarBtn_MouseUp);
            // 
            // MoreBtn
            // 
            this.MoreBtn.Enabled = false;
            this.MoreBtn.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MoreBtn.Location = new System.Drawing.Point(17, 99);
            this.MoreBtn.Name = "MoreBtn";
            this.MoreBtn.Size = new System.Drawing.Size(57, 30);
            this.MoreBtn.TabIndex = 0;
            this.MoreBtn.Text = "More...";
            this.MoreBtn.UseVisualStyleBackColor = true;
            this.MoreBtn.Click += new System.EventHandler(this.MoreBtn_Click);
            // 
            // zoomTeleBtn
            // 
            this.zoomTeleBtn.Enabled = false;
            this.zoomTeleBtn.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.zoomTeleBtn.Location = new System.Drawing.Point(17, 62);
            this.zoomTeleBtn.Name = "zoomTeleBtn";
            this.zoomTeleBtn.Size = new System.Drawing.Size(57, 30);
            this.zoomTeleBtn.TabIndex = 0;
            this.zoomTeleBtn.Text = "Tele";
            this.zoomTeleBtn.UseVisualStyleBackColor = true;
            this.zoomTeleBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.zoomTeleBtn_MouseDown);
            this.zoomTeleBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.zoomTeleBtn_MouseUp);
            // 
            // focusNearBtn
            // 
            this.focusNearBtn.Enabled = false;
            this.focusNearBtn.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.focusNearBtn.Location = new System.Drawing.Point(100, 13);
            this.focusNearBtn.Name = "focusNearBtn";
            this.focusNearBtn.Size = new System.Drawing.Size(57, 30);
            this.focusNearBtn.TabIndex = 0;
            this.focusNearBtn.Text = "Near";
            this.focusNearBtn.UseVisualStyleBackColor = true;
            this.focusNearBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.focusNearBtn_MouseDown);
            this.focusNearBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.focusNearBtn_MouseUp);
            // 
            // zoomWideBtn
            // 
            this.zoomWideBtn.Enabled = false;
            this.zoomWideBtn.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.zoomWideBtn.Location = new System.Drawing.Point(17, 13);
            this.zoomWideBtn.Name = "zoomWideBtn";
            this.zoomWideBtn.Size = new System.Drawing.Size(57, 30);
            this.zoomWideBtn.TabIndex = 0;
            this.zoomWideBtn.Text = "Wide";
            this.zoomWideBtn.UseVisualStyleBackColor = true;
            this.zoomWideBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.zoomWideBtn_MouseDown);
            this.zoomWideBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.zoomWideBtn_MouseUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(111, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Focus";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(16, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Zoom";
            // 
            // PresetGBox
            // 
            this.PresetGBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PresetGBox.Controls.Add(this.presetNameText);
            this.PresetGBox.Controls.Add(this.presetIDCobBox);
            this.PresetGBox.Controls.Add(this.presetDeleteBtn);
            this.PresetGBox.Controls.Add(this.presetSetBtn);
            this.PresetGBox.Controls.Add(this.presetGoToBtn);
            this.PresetGBox.Controls.Add(this.presetGetBtn);
            this.PresetGBox.Controls.Add(this.label4);
            this.PresetGBox.Controls.Add(this.label3);
            this.PresetGBox.Location = new System.Drawing.Point(709, 156);
            this.PresetGBox.Name = "PresetGBox";
            this.PresetGBox.Size = new System.Drawing.Size(182, 137);
            this.PresetGBox.TabIndex = 7;
            this.PresetGBox.TabStop = false;
            this.PresetGBox.Text = "Preset";
            // 
            // presetNameText
            // 
            this.presetNameText.Location = new System.Drawing.Point(91, 42);
            this.presetNameText.Name = "presetNameText";
            this.presetNameText.Size = new System.Drawing.Size(59, 23);
            this.presetNameText.TabIndex = 2;
            // 
            // presetDeleteBtn
            // 
            this.presetDeleteBtn.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.presetDeleteBtn.Location = new System.Drawing.Point(93, 102);
            this.presetDeleteBtn.Name = "presetDeleteBtn";
            this.presetDeleteBtn.Size = new System.Drawing.Size(57, 30);
            this.presetDeleteBtn.TabIndex = 0;
            this.presetDeleteBtn.Text = "Delete";
            this.presetDeleteBtn.UseVisualStyleBackColor = true;
            this.presetDeleteBtn.Click += new System.EventHandler(this.presetDeleteBtn_Click);
            // 
            // presetSetBtn
            // 
            this.presetSetBtn.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.presetSetBtn.Location = new System.Drawing.Point(93, 67);
            this.presetSetBtn.Name = "presetSetBtn";
            this.presetSetBtn.Size = new System.Drawing.Size(57, 30);
            this.presetSetBtn.TabIndex = 0;
            this.presetSetBtn.Text = "Set";
            this.presetSetBtn.UseVisualStyleBackColor = true;
            this.presetSetBtn.Click += new System.EventHandler(this.presetSetBtn_Click);
            // 
            // presetGoToBtn
            // 
            this.presetGoToBtn.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.presetGoToBtn.Location = new System.Drawing.Point(19, 102);
            this.presetGoToBtn.Name = "presetGoToBtn";
            this.presetGoToBtn.Size = new System.Drawing.Size(57, 30);
            this.presetGoToBtn.TabIndex = 0;
            this.presetGoToBtn.Text = "Go to";
            this.presetGoToBtn.UseVisualStyleBackColor = true;
            this.presetGoToBtn.Click += new System.EventHandler(this.presetGoToBtn_Click);
            // 
            // presetGetBtn
            // 
            this.presetGetBtn.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.presetGetBtn.Location = new System.Drawing.Point(19, 68);
            this.presetGetBtn.Name = "presetGetBtn";
            this.presetGetBtn.Size = new System.Drawing.Size(57, 30);
            this.presetGetBtn.TabIndex = 0;
            this.presetGetBtn.Text = "Get";
            this.presetGetBtn.UseVisualStyleBackColor = true;
            this.presetGetBtn.Click += new System.EventHandler(this.presetGetBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(25, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(25, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.PTZRDBtn);
            this.groupBox1.Controls.Add(this.PTZRBtn);
            this.groupBox1.Controls.Add(this.PTZRUBtn);
            this.groupBox1.Controls.Add(this.PTZDBtn);
            this.groupBox1.Controls.Add(this.PTZStopBtn);
            this.groupBox1.Controls.Add(this.PTZUBtn);
            this.groupBox1.Controls.Add(this.PTZLDBtn);
            this.groupBox1.Controls.Add(this.PTZLBtn);
            this.groupBox1.Controls.Add(this.ptzLUBtn);
            this.groupBox1.Controls.Add(this.PTZSpeedTrackBar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(709, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 148);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PTZ";
            // 
            // PTZRDBtn
            // 
            this.PTZRDBtn.BackgroundImage = global::YuShiNetDevSDK.WinForm.Properties.Resources.ico00013;
            this.PTZRDBtn.Enabled = false;
            this.PTZRDBtn.Location = new System.Drawing.Point(126, 109);
            this.PTZRDBtn.Name = "PTZRDBtn";
            this.PTZRDBtn.Size = new System.Drawing.Size(30, 30);
            this.PTZRDBtn.TabIndex = 2;
            this.PTZRDBtn.UseVisualStyleBackColor = true;
            this.PTZRDBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PTZRDBtn_MouseDown);
            this.PTZRDBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PTZRDBtn_MouseUp);
            // 
            // PTZRBtn
            // 
            this.PTZRBtn.BackgroundImage = global::YuShiNetDevSDK.WinForm.Properties.Resources.icon3;
            this.PTZRBtn.Enabled = false;
            this.PTZRBtn.Location = new System.Drawing.Point(126, 76);
            this.PTZRBtn.Name = "PTZRBtn";
            this.PTZRBtn.Size = new System.Drawing.Size(30, 30);
            this.PTZRBtn.TabIndex = 2;
            this.PTZRBtn.UseVisualStyleBackColor = true;
            this.PTZRBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PTZRBtn_MouseDown);
            this.PTZRBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PTZRBtn_MouseUp);
            // 
            // PTZRUBtn
            // 
            this.PTZRUBtn.BackgroundImage = global::YuShiNetDevSDK.WinForm.Properties.Resources.ico00012;
            this.PTZRUBtn.Enabled = false;
            this.PTZRUBtn.Location = new System.Drawing.Point(126, 43);
            this.PTZRUBtn.Name = "PTZRUBtn";
            this.PTZRUBtn.Size = new System.Drawing.Size(30, 30);
            this.PTZRUBtn.TabIndex = 2;
            this.PTZRUBtn.UseVisualStyleBackColor = true;
            this.PTZRUBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PTZRUBtn_MouseDown);
            this.PTZRUBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PTZRUBtn_MouseUp);
            // 
            // PTZDBtn
            // 
            this.PTZDBtn.BackgroundImage = global::YuShiNetDevSDK.WinForm.Properties.Resources.ico00007;
            this.PTZDBtn.Enabled = false;
            this.PTZDBtn.Location = new System.Drawing.Point(74, 109);
            this.PTZDBtn.Name = "PTZDBtn";
            this.PTZDBtn.Size = new System.Drawing.Size(30, 30);
            this.PTZDBtn.TabIndex = 2;
            this.PTZDBtn.UseVisualStyleBackColor = true;
            this.PTZDBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PTZDBtn_MouseDown);
            this.PTZDBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PTZDBtn_MouseUp);
            // 
            // PTZStopBtn
            // 
            this.PTZStopBtn.BackgroundImage = global::YuShiNetDevSDK.WinForm.Properties.Resources.ico00010;
            this.PTZStopBtn.Enabled = false;
            this.PTZStopBtn.Location = new System.Drawing.Point(74, 76);
            this.PTZStopBtn.Name = "PTZStopBtn";
            this.PTZStopBtn.Size = new System.Drawing.Size(30, 30);
            this.PTZStopBtn.TabIndex = 2;
            this.PTZStopBtn.UseVisualStyleBackColor = true;
            this.PTZStopBtn.Click += new System.EventHandler(this.PTZStopBtn_Click);
            // 
            // PTZUBtn
            // 
            this.PTZUBtn.BackgroundImage = global::YuShiNetDevSDK.WinForm.Properties.Resources.ico00005;
            this.PTZUBtn.Enabled = false;
            this.PTZUBtn.Location = new System.Drawing.Point(74, 43);
            this.PTZUBtn.Name = "PTZUBtn";
            this.PTZUBtn.Size = new System.Drawing.Size(30, 30);
            this.PTZUBtn.TabIndex = 2;
            this.PTZUBtn.UseVisualStyleBackColor = true;
            this.PTZUBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PTZUBtn_MouseDown);
            this.PTZUBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PTZUBtn_MouseUp);
            // 
            // PTZLDBtn
            // 
            this.PTZLDBtn.BackgroundImage = global::YuShiNetDevSDK.WinForm.Properties.Resources.icon4;
            this.PTZLDBtn.Enabled = false;
            this.PTZLDBtn.Location = new System.Drawing.Point(21, 109);
            this.PTZLDBtn.Name = "PTZLDBtn";
            this.PTZLDBtn.Size = new System.Drawing.Size(30, 30);
            this.PTZLDBtn.TabIndex = 2;
            this.PTZLDBtn.UseVisualStyleBackColor = true;
            this.PTZLDBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PTZLDBtn_MouseDown);
            this.PTZLDBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PTZLDBtn_MouseUp);
            // 
            // PTZLBtn
            // 
            this.PTZLBtn.BackgroundImage = global::YuShiNetDevSDK.WinForm.Properties.Resources.ico00004;
            this.PTZLBtn.Enabled = false;
            this.PTZLBtn.Location = new System.Drawing.Point(21, 76);
            this.PTZLBtn.Name = "PTZLBtn";
            this.PTZLBtn.Size = new System.Drawing.Size(30, 30);
            this.PTZLBtn.TabIndex = 2;
            this.PTZLBtn.UseVisualStyleBackColor = true;
            this.PTZLBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PTZLBtn_MouseDown);
            this.PTZLBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PTZLBtn_MouseUp);
            // 
            // ptzLUBtn
            // 
            this.ptzLUBtn.BackgroundImage = global::YuShiNetDevSDK.WinForm.Properties.Resources.ico00011;
            this.ptzLUBtn.Enabled = false;
            this.ptzLUBtn.Location = new System.Drawing.Point(21, 43);
            this.ptzLUBtn.Name = "ptzLUBtn";
            this.ptzLUBtn.Size = new System.Drawing.Size(30, 30);
            this.ptzLUBtn.TabIndex = 2;
            this.ptzLUBtn.UseVisualStyleBackColor = true;
            this.ptzLUBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ptzLUBtn_MouseDown);
            this.ptzLUBtn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ptzLUBtn_MouseUp);
            // 
            // PTZSpeedTrackBar
            // 
            this.PTZSpeedTrackBar.AutoSize = false;
            this.PTZSpeedTrackBar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PTZSpeedTrackBar.Location = new System.Drawing.Point(64, 17);
            this.PTZSpeedTrackBar.Maximum = 9;
            this.PTZSpeedTrackBar.Minimum = 1;
            this.PTZSpeedTrackBar.Name = "PTZSpeedTrackBar";
            this.PTZSpeedTrackBar.Size = new System.Drawing.Size(104, 33);
            this.PTZSpeedTrackBar.TabIndex = 1;
            this.PTZSpeedTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.PTZSpeedTrackBar.Value = 1;
            this.PTZSpeedTrackBar.Scroll += new System.EventHandler(this.PTZSpeedTrackBar_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(18, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Speed";
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this.LayoutPanel.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LayoutPanel.Location = new System.Drawing.Point(2, 11);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.Size = new System.Drawing.Size(710, 556);
            this.LayoutPanel.TabIndex = 0;
            this.LayoutPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LayoutPanel_MouseUp);
            // 
            // PannelPlayCtrl
            // 
            this.PannelPlayCtrl.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PannelPlayCtrl.Controls.Add(this.Sequence);
            this.PannelPlayCtrl.Controls.Add(this.LocalRecodBtn);
            this.PannelPlayCtrl.Controls.Add(this.CapturePicture);
            this.PannelPlayCtrl.Controls.Add(this.StopRealPlay);
            this.PannelPlayCtrl.Controls.Add(this.RealPlay);
            this.PannelPlayCtrl.Location = new System.Drawing.Point(4, 556);
            this.PannelPlayCtrl.Name = "PannelPlayCtrl";
            this.PannelPlayCtrl.Size = new System.Drawing.Size(241, 47);
            this.PannelPlayCtrl.TabIndex = 3;
            this.PannelPlayCtrl.TabStop = false;
            // 
            // Sequence
            // 
            this.Sequence.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Sequence.Location = new System.Drawing.Point(170, 11);
            this.Sequence.Name = "Sequence";
            this.Sequence.Size = new System.Drawing.Size(67, 30);
            this.Sequence.TabIndex = 3;
            this.Sequence.Text = "Sequence";
            this.Sequence.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Sequence.UseVisualStyleBackColor = true;
            this.Sequence.Click += new System.EventHandler(this.Sequence_Click);
            // 
            // LocalRecodBtn
            // 
            this.LocalRecodBtn.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LocalRecodBtn.Location = new System.Drawing.Point(112, 11);
            this.LocalRecodBtn.Name = "LocalRecodBtn";
            this.LocalRecodBtn.Size = new System.Drawing.Size(58, 30);
            this.LocalRecodBtn.TabIndex = 2;
            this.LocalRecodBtn.Text = "Record";
            this.LocalRecodBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LocalRecodBtn.UseVisualStyleBackColor = true;
            this.LocalRecodBtn.Click += new System.EventHandler(this.LocalRecodBtn_Click);
            // 
            // CapturePicture
            // 
            this.CapturePicture.AutoSize = true;
            this.CapturePicture.BackgroundImage = global::YuShiNetDevSDK.WinForm.Properties.Resources.camera;
            this.CapturePicture.Location = new System.Drawing.Point(79, 11);
            this.CapturePicture.Name = "CapturePicture";
            this.CapturePicture.Size = new System.Drawing.Size(30, 30);
            this.CapturePicture.TabIndex = 1;
            this.CapturePicture.UseVisualStyleBackColor = true;
            this.CapturePicture.Click += new System.EventHandler(this.CapturePicture_Click);
            // 
            // StopRealPlay
            // 
            this.StopRealPlay.BackgroundImage = global::YuShiNetDevSDK.WinForm.Properties.Resources.STOP;
            this.StopRealPlay.Location = new System.Drawing.Point(44, 11);
            this.StopRealPlay.Name = "StopRealPlay";
            this.StopRealPlay.Size = new System.Drawing.Size(30, 30);
            this.StopRealPlay.TabIndex = 1;
            this.StopRealPlay.UseVisualStyleBackColor = true;
            this.StopRealPlay.Click += new System.EventHandler(this.StopRealPlay_Click);
            // 
            // RealPlay
            // 
            this.RealPlay.BackgroundImage = global::YuShiNetDevSDK.WinForm.Properties.Resources.PLAY_ENABLE;
            this.RealPlay.Location = new System.Drawing.Point(8, 11);
            this.RealPlay.Name = "RealPlay";
            this.RealPlay.Size = new System.Drawing.Size(30, 30);
            this.RealPlay.TabIndex = 0;
            this.RealPlay.UseVisualStyleBackColor = true;
            this.RealPlay.Click += new System.EventHandler(this.RealPlay_Click);
            // 
            // group_win
            // 
            this.group_win.BackColor = System.Drawing.Color.WhiteSmoke;
            this.group_win.Controls.Add(this.comboBoxMultiScreen);
            this.group_win.Controls.Add(this.label1);
            this.group_win.Location = new System.Drawing.Point(247, 556);
            this.group_win.Name = "group_win";
            this.group_win.Size = new System.Drawing.Size(120, 47);
            this.group_win.TabIndex = 4;
            this.group_win.TabStop = false;
            // 
            // comboBoxMultiScreen
            // 
            this.comboBoxMultiScreen.FormattingEnabled = true;
            this.comboBoxMultiScreen.Items.AddRange(new object[] {
            "1",
            "4",
            "9",
            "16"});
            this.comboBoxMultiScreen.Location = new System.Drawing.Point(60, 17);
            this.comboBoxMultiScreen.Name = "comboBoxMultiScreen";
            this.comboBoxMultiScreen.Size = new System.Drawing.Size(50, 25);
            this.comboBoxMultiScreen.TabIndex = 5;
            this.comboBoxMultiScreen.SelectedIndexChanged += new System.EventHandler(this.comboBoxMultiScreen_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(4, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Win Num";
            // 
            // groupSound
            // 
            this.groupSound.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupSound.Controls.Add(this.SliSoundVolume);
            this.groupSound.Controls.Add(this.SoundBtn);
            this.groupSound.Controls.Add(this.SliMicVolume);
            this.groupSound.Controls.Add(this.MicVolumeBtn);
            this.groupSound.Location = new System.Drawing.Point(370, 556);
            this.groupSound.Name = "groupSound";
            this.groupSound.Size = new System.Drawing.Size(336, 47);
            this.groupSound.TabIndex = 5;
            this.groupSound.TabStop = false;
            // 
            // SliSoundVolume
            // 
            this.SliSoundVolume.AutoSize = false;
            this.SliSoundVolume.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SliSoundVolume.Enabled = false;
            this.SliSoundVolume.Location = new System.Drawing.Point(211, 17);
            this.SliSoundVolume.Maximum = 255;
            this.SliSoundVolume.Name = "SliSoundVolume";
            this.SliSoundVolume.Size = new System.Drawing.Size(114, 22);
            this.SliSoundVolume.TabIndex = 3;
            this.SliSoundVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.SliSoundVolume.Scroll += new System.EventHandler(this.SliSoundVolume_Scroll);
            // 
            // SoundBtn
            // 
            this.SoundBtn.AutoSize = true;
            this.SoundBtn.BackgroundImage = global::YuShiNetDevSDK.WinForm.Properties.Resources.ico00009;
            this.SoundBtn.Enabled = false;
            this.SoundBtn.Location = new System.Drawing.Point(167, 11);
            this.SoundBtn.Name = "SoundBtn";
            this.SoundBtn.Size = new System.Drawing.Size(30, 30);
            this.SoundBtn.TabIndex = 2;
            this.SoundBtn.UseVisualStyleBackColor = true;
            this.SoundBtn.Click += new System.EventHandler(this.SoundBtn_Click);
            // 
            // SliMicVolume
            // 
            this.SliMicVolume.AutoSize = false;
            this.SliMicVolume.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SliMicVolume.Enabled = false;
            this.SliMicVolume.Location = new System.Drawing.Point(47, 17);
            this.SliMicVolume.Maximum = 255;
            this.SliMicVolume.Name = "SliMicVolume";
            this.SliMicVolume.Size = new System.Drawing.Size(114, 22);
            this.SliMicVolume.TabIndex = 1;
            this.SliMicVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.SliMicVolume.Scroll += new System.EventHandler(this.SliMicVolume_Scroll);
            // 
            // MicVolumeBtn
            // 
            this.MicVolumeBtn.AutoSize = true;
            this.MicVolumeBtn.BackgroundImage = global::YuShiNetDevSDK.WinForm.Properties.Resources._222;
            this.MicVolumeBtn.Location = new System.Drawing.Point(6, 12);
            this.MicVolumeBtn.Name = "MicVolumeBtn";
            this.MicVolumeBtn.Size = new System.Drawing.Size(38, 30);
            this.MicVolumeBtn.TabIndex = 0;
            this.MicVolumeBtn.UseVisualStyleBackColor = true;
            this.MicVolumeBtn.Click += new System.EventHandler(this.MicVolumeBtn_Click);
            // 
            // Playback
            // 
            this.Playback.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Playback.Controls.Add(this.GetRecordDays);
            this.Playback.Controls.Add(this.BoxPositionList);
            this.Playback.Controls.Add(this.playBackLayoutPanel);
            this.Playback.Controls.Add(this.groupBox3);
            this.Playback.Controls.Add(this.PBVideoTimeListView);
            this.Playback.Controls.Add(this.PBQueryBtn);
            this.Playback.Controls.Add(this.PBVideoTrackBar);
            this.Playback.Controls.Add(this.PBVolTrackBar);
            this.Playback.Controls.Add(this.PBEventType);
            this.Playback.Controls.Add(this.PBEndTime);
            this.Playback.Controls.Add(this.PBEndDate);
            this.Playback.Controls.Add(this.PBBeginTime);
            this.Playback.Controls.Add(this.PBBeginDate);
            this.Playback.Controls.Add(this.PBShowFBSpeedLabel);
            this.Playback.Controls.Add(this.label12);
            this.Playback.Controls.Add(this.PBRemainingTimeLabel);
            this.Playback.Controls.Add(this.label13);
            this.Playback.Controls.Add(this.PBVideoDateTimeLabel);
            this.Playback.Controls.Add(this.label14);
            this.Playback.Controls.Add(this.label7);
            this.Playback.Controls.Add(this.PBVolBtn);
            this.Playback.Controls.Add(this.PBFrameBtn);
            this.Playback.Controls.Add(this.PBRestartBtn);
            this.Playback.Controls.Add(this.PBCaptureBtn);
            this.Playback.Controls.Add(this.PBFastForwardBtn);
            this.Playback.Controls.Add(this.PBFastBackwardBtn);
            this.Playback.Controls.Add(this.PBStopBtn);
            this.Playback.Controls.Add(this.PBPauseBtn);
            this.Playback.Controls.Add(this.PBStartBtn);
            this.Playback.Location = new System.Drawing.Point(4, 26);
            this.Playback.Name = "Playback";
            this.Playback.Padding = new System.Windows.Forms.Padding(3);
            this.Playback.Size = new System.Drawing.Size(899, 606);
            this.Playback.TabIndex = 1;
            this.Playback.Text = "Playback";
            this.Playback.UseVisualStyleBackColor = true;
            // 
            // GetRecordDays
            // 
            this.GetRecordDays.Location = new System.Drawing.Point(690, 27);
            this.GetRecordDays.Name = "GetRecordDays";
            this.GetRecordDays.Size = new System.Drawing.Size(114, 30);
            this.GetRecordDays.TabIndex = 9;
            this.GetRecordDays.Text = "GetRecordDays";
            this.GetRecordDays.UseVisualStyleBackColor = true;
            this.GetRecordDays.Click += new System.EventHandler(this.GetRecordDays_Click);
            // 
            // BoxPositionList
            // 
            this.BoxPositionList.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BoxPositionList.FormattingEnabled = true;
            this.BoxPositionList.Items.AddRange(new object[] {
            "Center",
            "Device"});
            this.BoxPositionList.Location = new System.Drawing.Point(344, 59);
            this.BoxPositionList.Name = "BoxPositionList";
            this.BoxPositionList.Size = new System.Drawing.Size(65, 24);
            this.BoxPositionList.TabIndex = 8;
            this.BoxPositionList.Text = "Center";
            // 
            // playBackLayoutPanel
            // 
            this.playBackLayoutPanel.Location = new System.Drawing.Point(12, 103);
            this.playBackLayoutPanel.Name = "playBackLayoutPanel";
            this.playBackLayoutPanel.Size = new System.Drawing.Size(590, 419);
            this.playBackLayoutPanel.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.PBDownLoadStopBtn);
            this.groupBox3.Controls.Add(this.PBDownLoadInfoBtn);
            this.groupBox3.Controls.Add(this.PBDownLoadStartBtn);
            this.groupBox3.Location = new System.Drawing.Point(624, 524);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(240, 80);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DownLoad";
            // 
            // PBDownLoadStopBtn
            // 
            this.PBDownLoadStopBtn.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PBDownLoadStopBtn.Location = new System.Drawing.Point(128, 18);
            this.PBDownLoadStopBtn.Name = "PBDownLoadStopBtn";
            this.PBDownLoadStopBtn.Size = new System.Drawing.Size(75, 23);
            this.PBDownLoadStopBtn.TabIndex = 0;
            this.PBDownLoadStopBtn.Text = "Stop";
            this.PBDownLoadStopBtn.UseVisualStyleBackColor = true;
            this.PBDownLoadStopBtn.Click += new System.EventHandler(this.PBDownLoadStopBtn_Click);
            // 
            // PBDownLoadInfoBtn
            // 
            this.PBDownLoadInfoBtn.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PBDownLoadInfoBtn.Location = new System.Drawing.Point(38, 47);
            this.PBDownLoadInfoBtn.Name = "PBDownLoadInfoBtn";
            this.PBDownLoadInfoBtn.Size = new System.Drawing.Size(165, 23);
            this.PBDownLoadInfoBtn.TabIndex = 0;
            this.PBDownLoadInfoBtn.Text = "DownLoad Info";
            this.PBDownLoadInfoBtn.UseVisualStyleBackColor = true;
            this.PBDownLoadInfoBtn.Click += new System.EventHandler(this.PBDownLoadInfoBtn_Click);
            // 
            // PBDownLoadStartBtn
            // 
            this.PBDownLoadStartBtn.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PBDownLoadStartBtn.Location = new System.Drawing.Point(38, 18);
            this.PBDownLoadStartBtn.Name = "PBDownLoadStartBtn";
            this.PBDownLoadStartBtn.Size = new System.Drawing.Size(75, 23);
            this.PBDownLoadStartBtn.TabIndex = 0;
            this.PBDownLoadStartBtn.Text = "Start";
            this.PBDownLoadStartBtn.UseVisualStyleBackColor = true;
            this.PBDownLoadStartBtn.Click += new System.EventHandler(this.PBDownLoadStartBtn_Click);
            // 
            // PBVideoTimeListView
            // 
            this.PBVideoTimeListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.BeginTime,
            this.EndTime});
            this.PBVideoTimeListView.FullRowSelect = true;
            this.PBVideoTimeListView.GridLines = true;
            this.PBVideoTimeListView.HideSelection = false;
            this.PBVideoTimeListView.Location = new System.Drawing.Point(613, 103);
            this.PBVideoTimeListView.Name = "PBVideoTimeListView";
            this.PBVideoTimeListView.Size = new System.Drawing.Size(273, 415);
            this.PBVideoTimeListView.TabIndex = 5;
            this.PBVideoTimeListView.UseCompatibleStateImageBehavior = false;
            this.PBVideoTimeListView.View = System.Windows.Forms.View.Details;
            this.PBVideoTimeListView.SelectedIndexChanged += new System.EventHandler(this.PBVideoTimeListView_SelectedIndexChanged);
            // 
            // BeginTime
            // 
            this.BeginTime.Text = "Begin Time";
            this.BeginTime.Width = 123;
            // 
            // EndTime
            // 
            this.EndTime.Text = "End Time";
            this.EndTime.Width = 135;
            // 
            // PBQueryBtn
            // 
            this.PBQueryBtn.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PBQueryBtn.Location = new System.Drawing.Point(435, 59);
            this.PBQueryBtn.Name = "PBQueryBtn";
            this.PBQueryBtn.Size = new System.Drawing.Size(75, 23);
            this.PBQueryBtn.TabIndex = 0;
            this.PBQueryBtn.Text = "Query";
            this.PBQueryBtn.UseVisualStyleBackColor = true;
            this.PBQueryBtn.Click += new System.EventHandler(this.PBQueryBtn_Click);
            // 
            // PBVideoTrackBar
            // 
            this.PBVideoTrackBar.AutoSize = false;
            this.PBVideoTrackBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.PBVideoTrackBar.Enabled = false;
            this.PBVideoTrackBar.Location = new System.Drawing.Point(8, 548);
            this.PBVideoTrackBar.Name = "PBVideoTrackBar";
            this.PBVideoTrackBar.Size = new System.Drawing.Size(594, 17);
            this.PBVideoTrackBar.TabIndex = 4;
            this.PBVideoTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.PBVideoTrackBar.Scroll += new System.EventHandler(this.PBVideoTrackBar_Scroll);
            // 
            // PBVolTrackBar
            // 
            this.PBVolTrackBar.AutoSize = false;
            this.PBVolTrackBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.PBVolTrackBar.Location = new System.Drawing.Point(498, 572);
            this.PBVolTrackBar.Maximum = 255;
            this.PBVolTrackBar.Name = "PBVolTrackBar";
            this.PBVolTrackBar.Size = new System.Drawing.Size(104, 24);
            this.PBVolTrackBar.TabIndex = 4;
            this.PBVolTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.PBVolTrackBar.Scroll += new System.EventHandler(this.PBVolTrackBar_Scroll);
            // 
            // PBEventType
            // 
            this.PBEventType.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PBEventType.FormattingEnabled = true;
            this.PBEventType.Items.AddRange(new object[] {
            "Normal",
            "Motion Detection",
            "Digital Input",
            "Video Loss"});
            this.PBEventType.Location = new System.Drawing.Point(83, 59);
            this.PBEventType.Name = "PBEventType";
            this.PBEventType.Size = new System.Drawing.Size(212, 24);
            this.PBEventType.TabIndex = 3;
            this.PBEventType.Text = "Normal";
            // 
            // PBEndTime
            // 
            this.PBEndTime.CustomFormat = "HH:mm:ss";
            this.PBEndTime.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PBEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.PBEndTime.Location = new System.Drawing.Point(526, 24);
            this.PBEndTime.Name = "PBEndTime";
            this.PBEndTime.ShowUpDown = true;
            this.PBEndTime.Size = new System.Drawing.Size(88, 22);
            this.PBEndTime.TabIndex = 2;
            this.PBEndTime.Value = new System.DateTime(2017, 9, 4, 23, 59, 59, 0);
            // 
            // PBEndDate
            // 
            this.PBEndDate.CustomFormat = "yyyy/MM/dd";
            this.PBEndDate.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PBEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.PBEndDate.Location = new System.Drawing.Point(402, 24);
            this.PBEndDate.Name = "PBEndDate";
            this.PBEndDate.Size = new System.Drawing.Size(108, 22);
            this.PBEndDate.TabIndex = 2;
            // 
            // PBBeginTime
            // 
            this.PBBeginTime.CustomFormat = "HH:mm:ss";
            this.PBBeginTime.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PBBeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.PBBeginTime.Location = new System.Drawing.Point(207, 25);
            this.PBBeginTime.Name = "PBBeginTime";
            this.PBBeginTime.ShowUpDown = true;
            this.PBBeginTime.Size = new System.Drawing.Size(88, 22);
            this.PBBeginTime.TabIndex = 2;
            this.PBBeginTime.Value = new System.DateTime(2017, 9, 4, 0, 0, 0, 0);
            // 
            // PBBeginDate
            // 
            this.PBBeginDate.CustomFormat = "yyyy/MM/dd";
            this.PBBeginDate.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PBBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.PBBeginDate.Location = new System.Drawing.Point(83, 25);
            this.PBBeginDate.Name = "PBBeginDate";
            this.PBBeginDate.Size = new System.Drawing.Size(108, 22);
            this.PBBeginDate.TabIndex = 2;
            // 
            // PBShowFBSpeedLabel
            // 
            this.PBShowFBSpeedLabel.AutoSize = true;
            this.PBShowFBSpeedLabel.Location = new System.Drawing.Point(218, 577);
            this.PBShowFBSpeedLabel.Name = "PBShowFBSpeedLabel";
            this.PBShowFBSpeedLabel.Size = new System.Drawing.Size(21, 17);
            this.PBShowFBSpeedLabel.TabIndex = 1;
            this.PBShowFBSpeedLabel.Text = "1x";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(509, 526);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 17);
            this.label12.TabIndex = 1;
            this.label12.Text = "/";
            // 
            // PBRemainingTimeLabel
            // 
            this.PBRemainingTimeLabel.AutoSize = true;
            this.PBRemainingTimeLabel.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PBRemainingTimeLabel.Location = new System.Drawing.Point(531, 525);
            this.PBRemainingTimeLabel.Name = "PBRemainingTimeLabel";
            this.PBRemainingTimeLabel.Size = new System.Drawing.Size(50, 16);
            this.PBRemainingTimeLabel.TabIndex = 1;
            this.PBRemainingTimeLabel.Text = "00:00:00";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(341, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 16);
            this.label13.TabIndex = 1;
            this.label13.Text = "End Time";
            // 
            // PBVideoDateTimeLabel
            // 
            this.PBVideoDateTimeLabel.AutoSize = true;
            this.PBVideoDateTimeLabel.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PBVideoDateTimeLabel.Location = new System.Drawing.Point(377, 527);
            this.PBVideoDateTimeLabel.Name = "PBVideoDateTimeLabel";
            this.PBVideoDateTimeLabel.Size = new System.Drawing.Size(111, 16);
            this.PBVideoDateTimeLabel.TabIndex = 1;
            this.PBVideoDateTimeLabel.Text = "0000/00/00 00:00:00";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(10, 62);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 16);
            this.label14.TabIndex = 1;
            this.label14.Text = "Event Type";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(10, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Begin Time";
            // 
            // PBVolBtn
            // 
            this.PBVolBtn.BackgroundImage = global::YuShiNetDevSDK.WinForm.Properties.Resources.ico00009;
            this.PBVolBtn.Enabled = false;
            this.PBVolBtn.Location = new System.Drawing.Point(461, 568);
            this.PBVolBtn.Name = "PBVolBtn";
            this.PBVolBtn.Size = new System.Drawing.Size(35, 28);
            this.PBVolBtn.TabIndex = 0;
            this.PBVolBtn.UseVisualStyleBackColor = true;
            this.PBVolBtn.Click += new System.EventHandler(this.PBVolBtn_Click);
            // 
            // PBFrameBtn
            // 
            this.PBFrameBtn.BackgroundImage = global::YuShiNetDevSDK.WinForm.Properties.Resources.icon2;
            this.PBFrameBtn.Enabled = false;
            this.PBFrameBtn.Location = new System.Drawing.Point(411, 568);
            this.PBFrameBtn.Name = "PBFrameBtn";
            this.PBFrameBtn.Size = new System.Drawing.Size(35, 28);
            this.PBFrameBtn.TabIndex = 0;
            this.PBFrameBtn.UseVisualStyleBackColor = true;
            this.PBFrameBtn.Click += new System.EventHandler(this.PBFrameBtn_Click);
            // 
            // PBRestartBtn
            // 
            this.PBRestartBtn.BackgroundImage = global::YuShiNetDevSDK.WinForm.Properties.Resources.ico00006;
            this.PBRestartBtn.Enabled = false;
            this.PBRestartBtn.Location = new System.Drawing.Point(360, 568);
            this.PBRestartBtn.Name = "PBRestartBtn";
            this.PBRestartBtn.Size = new System.Drawing.Size(35, 28);
            this.PBRestartBtn.TabIndex = 0;
            this.PBRestartBtn.UseVisualStyleBackColor = true;
            this.PBRestartBtn.Click += new System.EventHandler(this.PBRestartBtn_Click);
            // 
            // PBCaptureBtn
            // 
            this.PBCaptureBtn.BackgroundImage = global::YuShiNetDevSDK.WinForm.Properties.Resources.camera;
            this.PBCaptureBtn.Enabled = false;
            this.PBCaptureBtn.Location = new System.Drawing.Point(307, 568);
            this.PBCaptureBtn.Name = "PBCaptureBtn";
            this.PBCaptureBtn.Size = new System.Drawing.Size(35, 28);
            this.PBCaptureBtn.TabIndex = 0;
            this.PBCaptureBtn.UseVisualStyleBackColor = true;
            this.PBCaptureBtn.Click += new System.EventHandler(this.PBCaptureBtn_Click);
            // 
            // PBFastForwardBtn
            // 
            this.PBFastForwardBtn.BackgroundImage = global::YuShiNetDevSDK.WinForm.Properties.Resources.ico00001;
            this.PBFastForwardBtn.Enabled = false;
            this.PBFastForwardBtn.Location = new System.Drawing.Point(177, 568);
            this.PBFastForwardBtn.Name = "PBFastForwardBtn";
            this.PBFastForwardBtn.Size = new System.Drawing.Size(35, 28);
            this.PBFastForwardBtn.TabIndex = 0;
            this.PBFastForwardBtn.UseVisualStyleBackColor = true;
            this.PBFastForwardBtn.Click += new System.EventHandler(this.PBFastForwardBtn_Click);
            // 
            // PBFastBackwardBtn
            // 
            this.PBFastBackwardBtn.BackgroundImage = global::YuShiNetDevSDK.WinForm.Properties.Resources.icon8;
            this.PBFastBackwardBtn.Enabled = false;
            this.PBFastBackwardBtn.Location = new System.Drawing.Point(136, 568);
            this.PBFastBackwardBtn.Name = "PBFastBackwardBtn";
            this.PBFastBackwardBtn.Size = new System.Drawing.Size(35, 28);
            this.PBFastBackwardBtn.TabIndex = 0;
            this.PBFastBackwardBtn.UseVisualStyleBackColor = true;
            this.PBFastBackwardBtn.Click += new System.EventHandler(this.PBFastBackwardBtn_Click);
            // 
            // PBStopBtn
            // 
            this.PBStopBtn.BackgroundImage = global::YuShiNetDevSDK.WinForm.Properties.Resources.STOP;
            this.PBStopBtn.Enabled = false;
            this.PBStopBtn.Location = new System.Drawing.Point(95, 568);
            this.PBStopBtn.Name = "PBStopBtn";
            this.PBStopBtn.Size = new System.Drawing.Size(35, 28);
            this.PBStopBtn.TabIndex = 0;
            this.PBStopBtn.UseVisualStyleBackColor = true;
            this.PBStopBtn.Click += new System.EventHandler(this.PBStopBtn_Click);
            // 
            // PBPauseBtn
            // 
            this.PBPauseBtn.BackgroundImage = global::YuShiNetDevSDK.WinForm.Properties.Resources.PAUSE_ENABLE;
            this.PBPauseBtn.Enabled = false;
            this.PBPauseBtn.Location = new System.Drawing.Point(54, 568);
            this.PBPauseBtn.Name = "PBPauseBtn";
            this.PBPauseBtn.Size = new System.Drawing.Size(35, 28);
            this.PBPauseBtn.TabIndex = 0;
            this.PBPauseBtn.UseVisualStyleBackColor = true;
            this.PBPauseBtn.Click += new System.EventHandler(this.PBPauseBtn_Click);
            // 
            // PBStartBtn
            // 
            this.PBStartBtn.BackgroundImage = global::YuShiNetDevSDK.WinForm.Properties.Resources.PLAY_ENABLE;
            this.PBStartBtn.Enabled = false;
            this.PBStartBtn.Location = new System.Drawing.Point(12, 568);
            this.PBStartBtn.Name = "PBStartBtn";
            this.PBStartBtn.Size = new System.Drawing.Size(35, 28);
            this.PBStartBtn.TabIndex = 0;
            this.PBStartBtn.UseVisualStyleBackColor = true;
            this.PBStartBtn.Click += new System.EventHandler(this.PBStartBtn_Click);
            // 
            // Configure
            // 
            this.Configure.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Configure.Controls.Add(this.cfgTabControl);
            this.Configure.Location = new System.Drawing.Point(4, 26);
            this.Configure.Name = "Configure";
            this.Configure.Padding = new System.Windows.Forms.Padding(3);
            this.Configure.Size = new System.Drawing.Size(899, 606);
            this.Configure.TabIndex = 2;
            this.Configure.Text = "Configure";
            this.Configure.UseVisualStyleBackColor = true;
            // 
            // cfgTabControl
            // 
            this.cfgTabControl.Controls.Add(this.ConfigBasic);
            this.cfgTabControl.Controls.Add(this.ConfigNetwork);
            this.cfgTabControl.Controls.Add(this.ConfigVideo);
            this.cfgTabControl.Controls.Add(this.ConfigImage);
            this.cfgTabControl.Controls.Add(this.ConfigOSD);
            this.cfgTabControl.Controls.Add(this.ConfigIO);
            this.cfgTabControl.Controls.Add(this.ConfigPrivacyMask);
            this.cfgTabControl.Controls.Add(this.ConfigMotion);
            this.cfgTabControl.Controls.Add(this.ConfigTemper);
            this.cfgTabControl.Location = new System.Drawing.Point(-4, 0);
            this.cfgTabControl.Name = "cfgTabControl";
            this.cfgTabControl.SelectedIndex = 0;
            this.cfgTabControl.Size = new System.Drawing.Size(907, 606);
            this.cfgTabControl.TabIndex = 0;
            this.cfgTabControl.SelectedIndexChanged += new System.EventHandler(this.cfgTabControl_SelectedIndexChanged);
            // 
            // ConfigBasic
            // 
            this.ConfigBasic.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ConfigBasic.Controls.Add(this.GetHDDSmartInfo);
            this.ConfigBasic.Controls.Add(this.BaiscRefreshBtn);
            this.ConfigBasic.Controls.Add(this.groupBox8);
            this.ConfigBasic.Controls.Add(this.groupBox7);
            this.ConfigBasic.Controls.Add(this.groupBox6);
            this.ConfigBasic.Location = new System.Drawing.Point(4, 26);
            this.ConfigBasic.Name = "ConfigBasic";
            this.ConfigBasic.Padding = new System.Windows.Forms.Padding(3);
            this.ConfigBasic.Size = new System.Drawing.Size(899, 576);
            this.ConfigBasic.TabIndex = 0;
            this.ConfigBasic.Text = "Basic";
            // 
            // GetHDDSmartInfo
            // 
            this.GetHDDSmartInfo.Location = new System.Drawing.Point(26, 456);
            this.GetHDDSmartInfo.Name = "GetHDDSmartInfo";
            this.GetHDDSmartInfo.Size = new System.Drawing.Size(126, 35);
            this.GetHDDSmartInfo.TabIndex = 8;
            this.GetHDDSmartInfo.Text = "GetHDDSmartInfo";
            this.GetHDDSmartInfo.UseVisualStyleBackColor = true;
            this.GetHDDSmartInfo.Click += new System.EventHandler(this.GetHDDSmartInfo_Click);
            // 
            // BaiscRefreshBtn
            // 
            this.BaiscRefreshBtn.Location = new System.Drawing.Point(619, 468);
            this.BaiscRefreshBtn.Name = "BaiscRefreshBtn";
            this.BaiscRefreshBtn.Size = new System.Drawing.Size(75, 23);
            this.BaiscRefreshBtn.TabIndex = 7;
            this.BaiscRefreshBtn.Text = "Refresh";
            this.BaiscRefreshBtn.UseVisualStyleBackColor = true;
            this.BaiscRefreshBtn.Click += new System.EventHandler(this.BaiscRefreshBtn_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.BasicHDInfoListView);
            this.groupBox8.Location = new System.Drawing.Point(6, 193);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(761, 231);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Hard Disk";
            // 
            // BasicHDInfoListView
            // 
            this.BasicHDInfoListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.HardDiskNo,
            this.HardDiskTotalCapacity,
            this.HardDiskFreeSpace,
            this.HardDiskStatus,
            this.HardDiskManufacturer});
            this.BasicHDInfoListView.GridLines = true;
            this.BasicHDInfoListView.Location = new System.Drawing.Point(18, 32);
            this.BasicHDInfoListView.Name = "BasicHDInfoListView";
            this.BasicHDInfoListView.Size = new System.Drawing.Size(725, 179);
            this.BasicHDInfoListView.TabIndex = 0;
            this.BasicHDInfoListView.UseCompatibleStateImageBehavior = false;
            this.BasicHDInfoListView.View = System.Windows.Forms.View.Details;
            // 
            // HardDiskNo
            // 
            this.HardDiskNo.Text = "No.";
            this.HardDiskNo.Width = 120;
            // 
            // HardDiskTotalCapacity
            // 
            this.HardDiskTotalCapacity.Text = "Total Capacity(GB)";
            this.HardDiskTotalCapacity.Width = 150;
            // 
            // HardDiskFreeSpace
            // 
            this.HardDiskFreeSpace.Text = "Free Space(GB)";
            this.HardDiskFreeSpace.Width = 150;
            // 
            // HardDiskStatus
            // 
            this.HardDiskStatus.Text = "Status";
            this.HardDiskStatus.Width = 150;
            // 
            // HardDiskManufacturer
            // 
            this.HardDiskManufacturer.Text = "Manufacturer";
            this.HardDiskManufacturer.Width = 150;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.BasicDeviceNameText);
            this.groupBox7.Controls.Add(this.BasicDeviceNameSaveBtn);
            this.groupBox7.Location = new System.Drawing.Point(6, 97);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(761, 71);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Device Name";
            // 
            // BasicDeviceNameText
            // 
            this.BasicDeviceNameText.Location = new System.Drawing.Point(18, 29);
            this.BasicDeviceNameText.Name = "BasicDeviceNameText";
            this.BasicDeviceNameText.Size = new System.Drawing.Size(291, 23);
            this.BasicDeviceNameText.TabIndex = 8;
            // 
            // BasicDeviceNameSaveBtn
            // 
            this.BasicDeviceNameSaveBtn.Location = new System.Drawing.Point(615, 29);
            this.BasicDeviceNameSaveBtn.Name = "BasicDeviceNameSaveBtn";
            this.BasicDeviceNameSaveBtn.Size = new System.Drawing.Size(75, 23);
            this.BasicDeviceNameSaveBtn.TabIndex = 7;
            this.BasicDeviceNameSaveBtn.Text = "Save";
            this.BasicDeviceNameSaveBtn.UseVisualStyleBackColor = true;
            this.BasicDeviceNameSaveBtn.Click += new System.EventHandler(this.BasicDeviceNameSaveBtn_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.BasicSysTimeSaveBtn);
            this.groupBox6.Controls.Add(this.BasicTime);
            this.groupBox6.Controls.Add(this.BasicDate);
            this.groupBox6.Controls.Add(this.BasicGMTCobBox);
            this.groupBox6.Location = new System.Drawing.Point(6, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(761, 71);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "System Time";
            // 
            // BasicSysTimeSaveBtn
            // 
            this.BasicSysTimeSaveBtn.Location = new System.Drawing.Point(615, 29);
            this.BasicSysTimeSaveBtn.Name = "BasicSysTimeSaveBtn";
            this.BasicSysTimeSaveBtn.Size = new System.Drawing.Size(75, 23);
            this.BasicSysTimeSaveBtn.TabIndex = 7;
            this.BasicSysTimeSaveBtn.Text = "Save";
            this.BasicSysTimeSaveBtn.UseVisualStyleBackColor = true;
            this.BasicSysTimeSaveBtn.Click += new System.EventHandler(this.BasicSysTimeSaveBtn_Click);
            // 
            // BasicTime
            // 
            this.BasicTime.CustomFormat = "HH:mm:ss ";
            this.BasicTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.BasicTime.Location = new System.Drawing.Point(459, 31);
            this.BasicTime.Name = "BasicTime";
            this.BasicTime.ShowUpDown = true;
            this.BasicTime.Size = new System.Drawing.Size(88, 23);
            this.BasicTime.TabIndex = 6;
            // 
            // BasicDate
            // 
            this.BasicDate.CustomFormat = "yyyy/MM/dd";
            this.BasicDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.BasicDate.Location = new System.Drawing.Point(317, 31);
            this.BasicDate.Name = "BasicDate";
            this.BasicDate.Size = new System.Drawing.Size(121, 23);
            this.BasicDate.TabIndex = 5;
            // 
            // BasicGMTCobBox
            // 
            this.BasicGMTCobBox.FormattingEnabled = true;
            this.BasicGMTCobBox.Items.AddRange(new object[] {
            "GMT-12:00 International Date Line West",
            "GMT-11:00 Midway Island, Samoa",
            "GMT-10:00 Hawaii",
            "GMT-09:00 Alaska",
            "GMT-08:00 Pacific Time (U.S. & Canada)",
            "GMT-07:00 Mountain Time (U.S. & Canada)",
            "GMT-06:00 Central Time (U.S. & Canada)",
            "GMT-05:00 Eastern Time (U.S. & Canada)",
            "GMT-04:30 Caracas",
            "GMT-04:00 Atlantic Time (Canada)",
            "GMT-03:30 Newfoundland",
            "GMT-03:00 Georgetown, Brasilia",
            "GMT-02:00 Mid-Atlantic",
            "GMT-01:00 Cape verde Islands, Azores",
            "GMT+00:00 Dublin, Edinburgh, London",
            "GMT+01:00 Amsterdam, Berlin, Rome, Paris",
            "GMT+02:00 Athens, Jerusalem, Istanbul",
            "GMT+03:00 Baghdad, Kuwait, Moscow",
            "GMT+03:30 Tehran",
            "GMT+04:00 Caucasus Standard Time",
            "GMT+04:30 Kabul",
            "GMT+05:00 Islamabad, Karachi, Tashkent",
            "GMT+05:30 Madras, Bombay, New Delhi",
            "GMT+05:45 Kathmandu",
            "GMT+06:00 Almaty, Novosibirsk, Dhaka",
            "GMT+06:30 Yangon",
            "GMT+07:00 Bangkok, Hanoi, Jakarta",
            "GMT+08:00 Beijing, Hong Kong, Urumqi, Singapore, Taipei",
            "GMT+09:00 Seoul, Tokyo, Osaka, Sapporo",
            "GMT+09:30 Adelaide, Darwin",
            "GMT+10:00 Melbourne, Sydney, Canberra",
            "GMT+11:00 Magadan, Solomon Islands",
            "GMT+12:00 Auckland, Wellington",
            "GMT+13:00 Nuku\'alofa"});
            this.BasicGMTCobBox.Location = new System.Drawing.Point(18, 31);
            this.BasicGMTCobBox.Name = "BasicGMTCobBox";
            this.BasicGMTCobBox.Size = new System.Drawing.Size(277, 25);
            this.BasicGMTCobBox.TabIndex = 0;
            this.BasicGMTCobBox.Text = "GMT-12:00 International Date Line West";
            // 
            // ConfigNetwork
            // 
            this.ConfigNetwork.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ConfigNetwork.Controls.Add(this.NetworkRefreshBtn);
            this.ConfigNetwork.Controls.Add(this.NetSaveBtn);
            this.ConfigNetwork.Controls.Add(this.groupBox10);
            this.ConfigNetwork.Controls.Add(this.groupBox9);
            this.ConfigNetwork.Controls.Add(this.NetMTUText);
            this.ConfigNetwork.Controls.Add(this.NetGatwayText);
            this.ConfigNetwork.Controls.Add(this.NetSubMaskText);
            this.ConfigNetwork.Controls.Add(this.NetIPAddText);
            this.ConfigNetwork.Controls.Add(this.NetDHCPCkBox);
            this.ConfigNetwork.Controls.Add(this.label30);
            this.ConfigNetwork.Controls.Add(this.label23);
            this.ConfigNetwork.Controls.Add(this.label22);
            this.ConfigNetwork.Controls.Add(this.label21);
            this.ConfigNetwork.Controls.Add(this.label20);
            this.ConfigNetwork.Controls.Add(this.label19);
            this.ConfigNetwork.Location = new System.Drawing.Point(4, 26);
            this.ConfigNetwork.Name = "ConfigNetwork";
            this.ConfigNetwork.Padding = new System.Windows.Forms.Padding(3);
            this.ConfigNetwork.Size = new System.Drawing.Size(899, 576);
            this.ConfigNetwork.TabIndex = 1;
            this.ConfigNetwork.Text = "Network";
            // 
            // NetworkRefreshBtn
            // 
            this.NetworkRefreshBtn.Location = new System.Drawing.Point(460, 448);
            this.NetworkRefreshBtn.Name = "NetworkRefreshBtn";
            this.NetworkRefreshBtn.Size = new System.Drawing.Size(75, 23);
            this.NetworkRefreshBtn.TabIndex = 6;
            this.NetworkRefreshBtn.Text = "Refresh";
            this.NetworkRefreshBtn.UseVisualStyleBackColor = true;
            this.NetworkRefreshBtn.Click += new System.EventHandler(this.NetworkRefreshBtn_Click);
            // 
            // NetSaveBtn
            // 
            this.NetSaveBtn.Location = new System.Drawing.Point(460, 152);
            this.NetSaveBtn.Name = "NetSaveBtn";
            this.NetSaveBtn.Size = new System.Drawing.Size(75, 23);
            this.NetSaveBtn.TabIndex = 6;
            this.NetSaveBtn.Text = "Save";
            this.NetSaveBtn.UseVisualStyleBackColor = true;
            this.NetSaveBtn.Click += new System.EventHandler(this.NetSaveBtn_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.NetNTPSaveBtn);
            this.groupBox10.Controls.Add(this.label27);
            this.groupBox10.Controls.Add(this.label28);
            this.groupBox10.Controls.Add(this.label29);
            this.groupBox10.Controls.Add(this.NetNTPServerIPText);
            this.groupBox10.Controls.Add(this.NetNTPDHCPCkBox);
            this.groupBox10.Controls.Add(this.NetNTPIPTypeCobBox);
            this.groupBox10.Location = new System.Drawing.Point(14, 306);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(753, 108);
            this.groupBox10.TabIndex = 5;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "NTP";
            // 
            // NetNTPSaveBtn
            // 
            this.NetNTPSaveBtn.Location = new System.Drawing.Point(446, 71);
            this.NetNTPSaveBtn.Name = "NetNTPSaveBtn";
            this.NetNTPSaveBtn.Size = new System.Drawing.Size(75, 23);
            this.NetNTPSaveBtn.TabIndex = 6;
            this.NetNTPSaveBtn.Text = "Save";
            this.NetNTPSaveBtn.UseVisualStyleBackColor = true;
            this.NetNTPSaveBtn.Click += new System.EventHandler(this.NetNTPSaveBtn_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(24, 51);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(51, 17);
            this.label27.TabIndex = 0;
            this.label27.Text = "IP Type";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(24, 21);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(41, 17);
            this.label28.TabIndex = 0;
            this.label28.Text = "DHCP";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(24, 82);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(60, 17);
            this.label29.TabIndex = 0;
            this.label29.Text = "Server IP";
            // 
            // NetNTPServerIPText
            // 
            this.NetNTPServerIPText.Location = new System.Drawing.Point(111, 78);
            this.NetNTPServerIPText.Name = "NetNTPServerIPText";
            this.NetNTPServerIPText.Size = new System.Drawing.Size(139, 23);
            this.NetNTPServerIPText.TabIndex = 3;
            // 
            // NetNTPDHCPCkBox
            // 
            this.NetNTPDHCPCkBox.AutoSize = true;
            this.NetNTPDHCPCkBox.Location = new System.Drawing.Point(111, 18);
            this.NetNTPDHCPCkBox.Name = "NetNTPDHCPCkBox";
            this.NetNTPDHCPCkBox.Size = new System.Drawing.Size(66, 21);
            this.NetNTPDHCPCkBox.TabIndex = 1;
            this.NetNTPDHCPCkBox.Text = "Enable";
            this.NetNTPDHCPCkBox.UseVisualStyleBackColor = true;
            this.NetNTPDHCPCkBox.CheckedChanged += new System.EventHandler(this.NetNTPDHCPCkBox_CheckedChanged);
            // 
            // NetNTPIPTypeCobBox
            // 
            this.NetNTPIPTypeCobBox.FormattingEnabled = true;
            this.NetNTPIPTypeCobBox.Items.AddRange(new object[] {
            "IPV4",
            "IPV6",
            "DNS"});
            this.NetNTPIPTypeCobBox.Location = new System.Drawing.Point(111, 45);
            this.NetNTPIPTypeCobBox.Name = "NetNTPIPTypeCobBox";
            this.NetNTPIPTypeCobBox.Size = new System.Drawing.Size(139, 25);
            this.NetNTPIPTypeCobBox.TabIndex = 4;
            this.NetNTPIPTypeCobBox.Text = "IPV4";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.NetPortSaveBtn);
            this.groupBox9.Controls.Add(this.label25);
            this.groupBox9.Controls.Add(this.label24);
            this.groupBox9.Controls.Add(this.label26);
            this.groupBox9.Controls.Add(this.NetPortRTSPText);
            this.groupBox9.Controls.Add(this.NetPortHTTPSText);
            this.groupBox9.Controls.Add(this.NetPortHTTPText);
            this.groupBox9.Controls.Add(this.NetPortRTSPCobBox);
            this.groupBox9.Controls.Add(this.NetPortHTTPSCobBox);
            this.groupBox9.Controls.Add(this.NetPortHTTPCobBox);
            this.groupBox9.Location = new System.Drawing.Point(14, 192);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(753, 106);
            this.groupBox9.TabIndex = 5;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Port";
            // 
            // NetPortSaveBtn
            // 
            this.NetPortSaveBtn.Location = new System.Drawing.Point(446, 71);
            this.NetPortSaveBtn.Name = "NetPortSaveBtn";
            this.NetPortSaveBtn.Size = new System.Drawing.Size(75, 23);
            this.NetPortSaveBtn.TabIndex = 6;
            this.NetPortSaveBtn.Text = "Save";
            this.NetPortSaveBtn.UseVisualStyleBackColor = true;
            this.NetPortSaveBtn.Click += new System.EventHandler(this.NetPortSaveBtn_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(24, 52);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(45, 17);
            this.label25.TabIndex = 0;
            this.label25.Text = "HTTPS";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(24, 22);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(38, 17);
            this.label24.TabIndex = 0;
            this.label24.Text = "HTTP";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(24, 83);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(37, 17);
            this.label26.TabIndex = 0;
            this.label26.Text = "RTSP";
            // 
            // NetPortRTSPText
            // 
            this.NetPortRTSPText.Location = new System.Drawing.Point(111, 74);
            this.NetPortRTSPText.Name = "NetPortRTSPText";
            this.NetPortRTSPText.Size = new System.Drawing.Size(60, 23);
            this.NetPortRTSPText.TabIndex = 3;
            this.NetPortRTSPText.Text = "0";
            // 
            // NetPortHTTPSText
            // 
            this.NetPortHTTPSText.Location = new System.Drawing.Point(111, 48);
            this.NetPortHTTPSText.Name = "NetPortHTTPSText";
            this.NetPortHTTPSText.Size = new System.Drawing.Size(60, 23);
            this.NetPortHTTPSText.TabIndex = 3;
            this.NetPortHTTPSText.Text = "0";
            // 
            // NetPortHTTPText
            // 
            this.NetPortHTTPText.Location = new System.Drawing.Point(111, 22);
            this.NetPortHTTPText.Name = "NetPortHTTPText";
            this.NetPortHTTPText.Size = new System.Drawing.Size(60, 23);
            this.NetPortHTTPText.TabIndex = 3;
            this.NetPortHTTPText.Text = "0";
            // 
            // NetPortRTSPCobBox
            // 
            this.NetPortRTSPCobBox.Enabled = false;
            this.NetPortRTSPCobBox.FormattingEnabled = true;
            this.NetPortRTSPCobBox.Items.AddRange(new object[] {
            "Disable",
            "Enable"});
            this.NetPortRTSPCobBox.Location = new System.Drawing.Point(177, 74);
            this.NetPortRTSPCobBox.Name = "NetPortRTSPCobBox";
            this.NetPortRTSPCobBox.Size = new System.Drawing.Size(73, 25);
            this.NetPortRTSPCobBox.TabIndex = 4;
            this.NetPortRTSPCobBox.Text = "Disable";
            // 
            // NetPortHTTPSCobBox
            // 
            this.NetPortHTTPSCobBox.FormattingEnabled = true;
            this.NetPortHTTPSCobBox.Items.AddRange(new object[] {
            "Disable",
            "Enable"});
            this.NetPortHTTPSCobBox.Location = new System.Drawing.Point(177, 48);
            this.NetPortHTTPSCobBox.Name = "NetPortHTTPSCobBox";
            this.NetPortHTTPSCobBox.Size = new System.Drawing.Size(73, 25);
            this.NetPortHTTPSCobBox.TabIndex = 4;
            this.NetPortHTTPSCobBox.Text = "Disable";
            // 
            // NetPortHTTPCobBox
            // 
            this.NetPortHTTPCobBox.Enabled = false;
            this.NetPortHTTPCobBox.FormattingEnabled = true;
            this.NetPortHTTPCobBox.Items.AddRange(new object[] {
            "Disable",
            "Enable"});
            this.NetPortHTTPCobBox.Location = new System.Drawing.Point(177, 22);
            this.NetPortHTTPCobBox.Name = "NetPortHTTPCobBox";
            this.NetPortHTTPCobBox.Size = new System.Drawing.Size(73, 25);
            this.NetPortHTTPCobBox.TabIndex = 4;
            this.NetPortHTTPCobBox.Text = "Disable";
            // 
            // NetMTUText
            // 
            this.NetMTUText.Location = new System.Drawing.Point(125, 154);
            this.NetMTUText.Name = "NetMTUText";
            this.NetMTUText.Size = new System.Drawing.Size(139, 23);
            this.NetMTUText.TabIndex = 3;
            this.NetMTUText.Text = "0";
            // 
            // NetGatwayText
            // 
            this.NetGatwayText.Location = new System.Drawing.Point(125, 121);
            this.NetGatwayText.Name = "NetGatwayText";
            this.NetGatwayText.Size = new System.Drawing.Size(139, 23);
            this.NetGatwayText.TabIndex = 3;
            // 
            // NetSubMaskText
            // 
            this.NetSubMaskText.Location = new System.Drawing.Point(125, 85);
            this.NetSubMaskText.Name = "NetSubMaskText";
            this.NetSubMaskText.Size = new System.Drawing.Size(139, 23);
            this.NetSubMaskText.TabIndex = 3;
            // 
            // NetIPAddText
            // 
            this.NetIPAddText.Location = new System.Drawing.Point(125, 51);
            this.NetIPAddText.Name = "NetIPAddText";
            this.NetIPAddText.Size = new System.Drawing.Size(139, 23);
            this.NetIPAddText.TabIndex = 3;
            // 
            // NetDHCPCkBox
            // 
            this.NetDHCPCkBox.AutoSize = true;
            this.NetDHCPCkBox.Location = new System.Drawing.Point(125, 27);
            this.NetDHCPCkBox.Name = "NetDHCPCkBox";
            this.NetDHCPCkBox.Size = new System.Drawing.Size(66, 21);
            this.NetDHCPCkBox.TabIndex = 1;
            this.NetDHCPCkBox.Text = "Enable";
            this.NetDHCPCkBox.UseVisualStyleBackColor = true;
            this.NetDHCPCkBox.CheckedChanged += new System.EventHandler(this.NetDHCPCkBox_CheckedChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(274, 159);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(186, 17);
            this.label30.TabIndex = 0;
            this.label30.Text = "IPC:576~1500 NVR:1280~1500";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(38, 161);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(36, 17);
            this.label23.TabIndex = 0;
            this.label23.Text = "MTU";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(38, 126);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(57, 17);
            this.label22.TabIndex = 0;
            this.label22.Text = "Gateway";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(38, 91);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(84, 17);
            this.label21.TabIndex = 0;
            this.label21.Text = "Subnet Mask";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(38, 57);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(71, 17);
            this.label20.TabIndex = 0;
            this.label20.Text = "IP Address";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(38, 28);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 17);
            this.label19.TabIndex = 0;
            this.label19.Text = "DHCP";
            // 
            // ConfigVideo
            // 
            this.ConfigVideo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ConfigVideo.Controls.Add(this.VideoRefreshBtn);
            this.ConfigVideo.Controls.Add(this.groupBox11);
            this.ConfigVideo.Location = new System.Drawing.Point(4, 26);
            this.ConfigVideo.Name = "ConfigVideo";
            this.ConfigVideo.Size = new System.Drawing.Size(899, 576);
            this.ConfigVideo.TabIndex = 2;
            this.ConfigVideo.Text = "Video";
            // 
            // VideoRefreshBtn
            // 
            this.VideoRefreshBtn.Location = new System.Drawing.Point(611, 394);
            this.VideoRefreshBtn.Name = "VideoRefreshBtn";
            this.VideoRefreshBtn.Size = new System.Drawing.Size(75, 23);
            this.VideoRefreshBtn.TabIndex = 7;
            this.VideoRefreshBtn.Text = "Refresh";
            this.VideoRefreshBtn.UseVisualStyleBackColor = true;
            this.VideoRefreshBtn.Click += new System.EventHandler(this.VideoRefreshBtn_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.VideoSaveBtn);
            this.groupBox11.Controls.Add(this.VideoResolutionHText);
            this.groupBox11.Controls.Add(this.VideoGopText);
            this.groupBox11.Controls.Add(this.VideoFrameRateText);
            this.groupBox11.Controls.Add(this.VideoBitRateText);
            this.groupBox11.Controls.Add(this.VideoResolutionWText);
            this.groupBox11.Controls.Add(this.label42);
            this.groupBox11.Controls.Add(this.VideoQualityCobBox);
            this.groupBox11.Controls.Add(this.label40);
            this.groupBox11.Controls.Add(this.VideoEncodeFormatCobBox);
            this.groupBox11.Controls.Add(this.label37);
            this.groupBox11.Controls.Add(this.label41);
            this.groupBox11.Controls.Add(this.VideoStreamIndexCobBox);
            this.groupBox11.Controls.Add(this.label39);
            this.groupBox11.Controls.Add(this.label34);
            this.groupBox11.Controls.Add(this.label36);
            this.groupBox11.Controls.Add(this.label35);
            this.groupBox11.Controls.Add(this.label38);
            this.groupBox11.Controls.Add(this.label33);
            this.groupBox11.Controls.Add(this.label32);
            this.groupBox11.Controls.Add(this.label31);
            this.groupBox11.Location = new System.Drawing.Point(14, 18);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(753, 276);
            this.groupBox11.TabIndex = 0;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Stream Info";
            // 
            // VideoSaveBtn
            // 
            this.VideoSaveBtn.Location = new System.Drawing.Point(403, 194);
            this.VideoSaveBtn.Name = "VideoSaveBtn";
            this.VideoSaveBtn.Size = new System.Drawing.Size(75, 23);
            this.VideoSaveBtn.TabIndex = 3;
            this.VideoSaveBtn.Text = "Save";
            this.VideoSaveBtn.UseVisualStyleBackColor = true;
            this.VideoSaveBtn.Click += new System.EventHandler(this.VideoSaveBtn_Click);
            // 
            // VideoResolutionHText
            // 
            this.VideoResolutionHText.Location = new System.Drawing.Point(222, 89);
            this.VideoResolutionHText.Name = "VideoResolutionHText";
            this.VideoResolutionHText.Size = new System.Drawing.Size(62, 23);
            this.VideoResolutionHText.TabIndex = 2;
            this.VideoResolutionHText.Text = "0";
            // 
            // VideoGopText
            // 
            this.VideoGopText.Location = new System.Drawing.Point(117, 225);
            this.VideoGopText.Name = "VideoGopText";
            this.VideoGopText.Size = new System.Drawing.Size(167, 23);
            this.VideoGopText.TabIndex = 2;
            this.VideoGopText.Text = "0";
            // 
            // VideoFrameRateText
            // 
            this.VideoFrameRateText.Location = new System.Drawing.Point(117, 190);
            this.VideoFrameRateText.Name = "VideoFrameRateText";
            this.VideoFrameRateText.Size = new System.Drawing.Size(167, 23);
            this.VideoFrameRateText.TabIndex = 2;
            this.VideoFrameRateText.Text = "0";
            // 
            // VideoBitRateText
            // 
            this.VideoBitRateText.Location = new System.Drawing.Point(117, 123);
            this.VideoBitRateText.Name = "VideoBitRateText";
            this.VideoBitRateText.Size = new System.Drawing.Size(167, 23);
            this.VideoBitRateText.TabIndex = 2;
            this.VideoBitRateText.Text = "0";
            // 
            // VideoResolutionWText
            // 
            this.VideoResolutionWText.Location = new System.Drawing.Point(117, 89);
            this.VideoResolutionWText.Name = "VideoResolutionWText";
            this.VideoResolutionWText.Size = new System.Drawing.Size(62, 23);
            this.VideoResolutionWText.TabIndex = 2;
            this.VideoResolutionWText.Text = "0";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(169, 228);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(16, 17);
            this.label42.TabIndex = 0;
            this.label42.Text = "X";
            // 
            // VideoQualityCobBox
            // 
            this.VideoQualityCobBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VideoQualityCobBox.FormattingEnabled = true;
            this.VideoQualityCobBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.VideoQualityCobBox.Location = new System.Drawing.Point(117, 158);
            this.VideoQualityCobBox.Name = "VideoQualityCobBox";
            this.VideoQualityCobBox.Size = new System.Drawing.Size(167, 25);
            this.VideoQualityCobBox.TabIndex = 1;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(169, 193);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(16, 17);
            this.label40.TabIndex = 0;
            this.label40.Text = "X";
            // 
            // VideoEncodeFormatCobBox
            // 
            this.VideoEncodeFormatCobBox.FormattingEnabled = true;
            this.VideoEncodeFormatCobBox.Items.AddRange(new object[] {
            "MJPEG",
            "H.264",
            "H.265"});
            this.VideoEncodeFormatCobBox.Location = new System.Drawing.Point(117, 55);
            this.VideoEncodeFormatCobBox.Name = "VideoEncodeFormatCobBox";
            this.VideoEncodeFormatCobBox.Size = new System.Drawing.Size(167, 25);
            this.VideoEncodeFormatCobBox.TabIndex = 1;
            this.VideoEncodeFormatCobBox.Text = "MJPEG";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(169, 126);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(16, 17);
            this.label37.TabIndex = 0;
            this.label37.Text = "X";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(17, 231);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(99, 17);
            this.label41.TabIndex = 0;
            this.label41.Text = "I Frame Interval";
            // 
            // VideoStreamIndexCobBox
            // 
            this.VideoStreamIndexCobBox.FormattingEnabled = true;
            this.VideoStreamIndexCobBox.Items.AddRange(new object[] {
            "Main Stream",
            "Sub Stream",
            "Third Stream"});
            this.VideoStreamIndexCobBox.Location = new System.Drawing.Point(117, 20);
            this.VideoStreamIndexCobBox.Name = "VideoStreamIndexCobBox";
            this.VideoStreamIndexCobBox.Size = new System.Drawing.Size(167, 25);
            this.VideoStreamIndexCobBox.TabIndex = 1;
            this.VideoStreamIndexCobBox.Text = "Main Stream";
            this.VideoStreamIndexCobBox.SelectedIndexChanged += new System.EventHandler(this.VideoStreamIndexCobBox_SelectedIndexChanged);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(17, 196);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(100, 17);
            this.label39.TabIndex = 0;
            this.label39.Text = "Frame Rate(fps)";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(169, 92);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(16, 17);
            this.label34.TabIndex = 0;
            this.label34.Text = "X";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(17, 129);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(90, 17);
            this.label36.TabIndex = 0;
            this.label36.Text = "Bit Rate(kbps)";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(194, 94);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(16, 17);
            this.label35.TabIndex = 0;
            this.label35.Text = "X";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(17, 166);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(48, 17);
            this.label38.TabIndex = 0;
            this.label38.Text = "Quality";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(17, 95);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(69, 17);
            this.label33.TabIndex = 0;
            this.label33.Text = "Resolution";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(17, 63);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(96, 17);
            this.label32.TabIndex = 0;
            this.label32.Text = "Encode Format";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(17, 27);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(85, 17);
            this.label31.TabIndex = 0;
            this.label31.Text = "Stream Index";
            // 
            // ConfigImage
            // 
            this.ConfigImage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ConfigImage.Controls.Add(this.ImageRefreshBtn);
            this.ConfigImage.Controls.Add(this.groupBox12);
            this.ConfigImage.Location = new System.Drawing.Point(4, 26);
            this.ConfigImage.Name = "ConfigImage";
            this.ConfigImage.Size = new System.Drawing.Size(899, 576);
            this.ConfigImage.TabIndex = 3;
            this.ConfigImage.Text = "Image";
            // 
            // ImageRefreshBtn
            // 
            this.ImageRefreshBtn.Location = new System.Drawing.Point(612, 397);
            this.ImageRefreshBtn.Name = "ImageRefreshBtn";
            this.ImageRefreshBtn.Size = new System.Drawing.Size(75, 23);
            this.ImageRefreshBtn.TabIndex = 8;
            this.ImageRefreshBtn.Text = "Refresh";
            this.ImageRefreshBtn.UseVisualStyleBackColor = true;
            this.ImageRefreshBtn.Click += new System.EventHandler(this.ImageRefreshBtn_Click);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.ImageSaveBtn);
            this.groupBox12.Controls.Add(this.label50);
            this.groupBox12.Controls.Add(this.label48);
            this.groupBox12.Controls.Add(this.label46);
            this.groupBox12.Controls.Add(this.label44);
            this.groupBox12.Controls.Add(this.SharpnessText);
            this.groupBox12.Controls.Add(this.ContrastText);
            this.groupBox12.Controls.Add(this.SaturationText);
            this.groupBox12.Controls.Add(this.BrightnessText);
            this.groupBox12.Controls.Add(this.label49);
            this.groupBox12.Controls.Add(this.label47);
            this.groupBox12.Controls.Add(this.label45);
            this.groupBox12.Controls.Add(this.label43);
            this.groupBox12.Controls.Add(this.SharpnessTrackBar);
            this.groupBox12.Controls.Add(this.ContrastTrackBar);
            this.groupBox12.Controls.Add(this.SaturationTrackBar);
            this.groupBox12.Controls.Add(this.BrightnessTrackBar);
            this.groupBox12.Location = new System.Drawing.Point(17, 17);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(734, 167);
            this.groupBox12.TabIndex = 0;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Image Info";
            // 
            // ImageSaveBtn
            // 
            this.ImageSaveBtn.Location = new System.Drawing.Point(595, 125);
            this.ImageSaveBtn.Name = "ImageSaveBtn";
            this.ImageSaveBtn.Size = new System.Drawing.Size(75, 23);
            this.ImageSaveBtn.TabIndex = 9;
            this.ImageSaveBtn.Text = "Save";
            this.ImageSaveBtn.UseVisualStyleBackColor = true;
            this.ImageSaveBtn.Click += new System.EventHandler(this.ImageSaveBtn_Click);
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(17, 130);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(68, 17);
            this.label50.TabIndex = 8;
            this.label50.Text = "Sharpness";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(17, 100);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(57, 17);
            this.label48.TabIndex = 8;
            this.label48.Text = "Contrast";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(17, 70);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(67, 17);
            this.label46.TabIndex = 8;
            this.label46.Text = "Saturation";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(17, 40);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(69, 17);
            this.label44.TabIndex = 8;
            this.label44.Text = "Brightness";
            // 
            // SharpnessText
            // 
            this.SharpnessText.Location = new System.Drawing.Point(334, 127);
            this.SharpnessText.Name = "SharpnessText";
            this.SharpnessText.Size = new System.Drawing.Size(58, 23);
            this.SharpnessText.TabIndex = 7;
            this.SharpnessText.Text = "128";
            this.SharpnessText.TextChanged += new System.EventHandler(this.SharpnessText_TextChanged);
            // 
            // ContrastText
            // 
            this.ContrastText.Location = new System.Drawing.Point(334, 97);
            this.ContrastText.Name = "ContrastText";
            this.ContrastText.Size = new System.Drawing.Size(58, 23);
            this.ContrastText.TabIndex = 7;
            this.ContrastText.Text = "128";
            this.ContrastText.TextChanged += new System.EventHandler(this.ContrastText_TextChanged);
            // 
            // SaturationText
            // 
            this.SaturationText.Location = new System.Drawing.Point(334, 67);
            this.SaturationText.Name = "SaturationText";
            this.SaturationText.Size = new System.Drawing.Size(58, 23);
            this.SaturationText.TabIndex = 7;
            this.SaturationText.Text = "128";
            this.SaturationText.TextChanged += new System.EventHandler(this.SaturationText_TextChanged);
            // 
            // BrightnessText
            // 
            this.BrightnessText.Location = new System.Drawing.Point(334, 37);
            this.BrightnessText.Name = "BrightnessText";
            this.BrightnessText.Size = new System.Drawing.Size(58, 23);
            this.BrightnessText.TabIndex = 7;
            this.BrightnessText.Text = "128";
            this.BrightnessText.TextChanged += new System.EventHandler(this.BrightnessText_TextChanged);
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(402, 132);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(69, 17);
            this.label49.TabIndex = 6;
            this.label49.Text = "( 0 ~ 255 )";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(402, 102);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(69, 17);
            this.label47.TabIndex = 6;
            this.label47.Text = "( 0 ~ 255 )";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(402, 72);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(69, 17);
            this.label45.TabIndex = 6;
            this.label45.Text = "( 0 ~ 255 )";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(402, 42);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(69, 17);
            this.label43.TabIndex = 6;
            this.label43.Text = "( 0 ~ 255 )";
            // 
            // SharpnessTrackBar
            // 
            this.SharpnessTrackBar.AutoSize = false;
            this.SharpnessTrackBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.SharpnessTrackBar.Location = new System.Drawing.Point(100, 127);
            this.SharpnessTrackBar.Maximum = 255;
            this.SharpnessTrackBar.Name = "SharpnessTrackBar";
            this.SharpnessTrackBar.Size = new System.Drawing.Size(214, 24);
            this.SharpnessTrackBar.TabIndex = 5;
            this.SharpnessTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.SharpnessTrackBar.Value = 128;
            this.SharpnessTrackBar.Scroll += new System.EventHandler(this.SharpnessTrackBar_Scroll);
            // 
            // ContrastTrackBar
            // 
            this.ContrastTrackBar.AutoSize = false;
            this.ContrastTrackBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.ContrastTrackBar.Location = new System.Drawing.Point(100, 97);
            this.ContrastTrackBar.Maximum = 255;
            this.ContrastTrackBar.Name = "ContrastTrackBar";
            this.ContrastTrackBar.Size = new System.Drawing.Size(214, 24);
            this.ContrastTrackBar.TabIndex = 5;
            this.ContrastTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ContrastTrackBar.Value = 128;
            this.ContrastTrackBar.Scroll += new System.EventHandler(this.ContrastTrackBar_Scroll);
            // 
            // SaturationTrackBar
            // 
            this.SaturationTrackBar.AutoSize = false;
            this.SaturationTrackBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.SaturationTrackBar.Location = new System.Drawing.Point(100, 67);
            this.SaturationTrackBar.Maximum = 255;
            this.SaturationTrackBar.Name = "SaturationTrackBar";
            this.SaturationTrackBar.Size = new System.Drawing.Size(214, 24);
            this.SaturationTrackBar.TabIndex = 5;
            this.SaturationTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.SaturationTrackBar.Value = 128;
            this.SaturationTrackBar.Scroll += new System.EventHandler(this.SaturationTrackBar_Scroll);
            // 
            // BrightnessTrackBar
            // 
            this.BrightnessTrackBar.AutoSize = false;
            this.BrightnessTrackBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.BrightnessTrackBar.Location = new System.Drawing.Point(100, 37);
            this.BrightnessTrackBar.Maximum = 255;
            this.BrightnessTrackBar.Name = "BrightnessTrackBar";
            this.BrightnessTrackBar.Size = new System.Drawing.Size(214, 24);
            this.BrightnessTrackBar.TabIndex = 5;
            this.BrightnessTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.BrightnessTrackBar.Value = 128;
            this.BrightnessTrackBar.Scroll += new System.EventHandler(this.BrightnessTrackBar_Scroll);
            // 
            // ConfigOSD
            // 
            this.ConfigOSD.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ConfigOSD.Controls.Add(this.OSDRefreshBtn);
            this.ConfigOSD.Controls.Add(this.groupBox13);
            this.ConfigOSD.Location = new System.Drawing.Point(4, 26);
            this.ConfigOSD.Name = "ConfigOSD";
            this.ConfigOSD.Size = new System.Drawing.Size(899, 576);
            this.ConfigOSD.TabIndex = 4;
            this.ConfigOSD.Text = "OSD";
            // 
            // OSDRefreshBtn
            // 
            this.OSDRefreshBtn.Location = new System.Drawing.Point(592, 452);
            this.OSDRefreshBtn.Name = "OSDRefreshBtn";
            this.OSDRefreshBtn.Size = new System.Drawing.Size(75, 23);
            this.OSDRefreshBtn.TabIndex = 9;
            this.OSDRefreshBtn.Text = "Refresh";
            this.OSDRefreshBtn.UseVisualStyleBackColor = true;
            this.OSDRefreshBtn.Click += new System.EventHandler(this.OSDRefreshBtn_Click);
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.OSDText6CheckBox);
            this.groupBox13.Controls.Add(this.OSDText5CheckBox);
            this.groupBox13.Controls.Add(this.OSDText4CheckBox);
            this.groupBox13.Controls.Add(this.OSDText3CheckBox);
            this.groupBox13.Controls.Add(this.OSDText2CheckBox);
            this.groupBox13.Controls.Add(this.OSDText1CheckBox);
            this.groupBox13.Controls.Add(this.OSDNameCheckBox);
            this.groupBox13.Controls.Add(this.OSDTimeCheckBox);
            this.groupBox13.Controls.Add(this.OSDSaveBtn);
            this.groupBox13.Controls.Add(this.OSDText6PointY);
            this.groupBox13.Controls.Add(this.OSDText5PointY);
            this.groupBox13.Controls.Add(this.OSDText4PointY);
            this.groupBox13.Controls.Add(this.OSDText3PointY);
            this.groupBox13.Controls.Add(this.OSDText2PointY);
            this.groupBox13.Controls.Add(this.OSDText1PointY);
            this.groupBox13.Controls.Add(this.OSDNamePointYText);
            this.groupBox13.Controls.Add(this.OSDTimePointYText);
            this.groupBox13.Controls.Add(this.label74);
            this.groupBox13.Controls.Add(this.label71);
            this.groupBox13.Controls.Add(this.label68);
            this.groupBox13.Controls.Add(this.label65);
            this.groupBox13.Controls.Add(this.label62);
            this.groupBox13.Controls.Add(this.label59);
            this.groupBox13.Controls.Add(this.label56);
            this.groupBox13.Controls.Add(this.label53);
            this.groupBox13.Controls.Add(this.OSDText6);
            this.groupBox13.Controls.Add(this.OSDText6PointX);
            this.groupBox13.Controls.Add(this.OSDText5);
            this.groupBox13.Controls.Add(this.OSDText5PointX);
            this.groupBox13.Controls.Add(this.OSDText4);
            this.groupBox13.Controls.Add(this.OSDText4PointX);
            this.groupBox13.Controls.Add(this.OSDText3);
            this.groupBox13.Controls.Add(this.OSDText3PointX);
            this.groupBox13.Controls.Add(this.label73);
            this.groupBox13.Controls.Add(this.OSDText2);
            this.groupBox13.Controls.Add(this.label70);
            this.groupBox13.Controls.Add(this.OSDText2PointX);
            this.groupBox13.Controls.Add(this.label67);
            this.groupBox13.Controls.Add(this.OSDText1);
            this.groupBox13.Controls.Add(this.label64);
            this.groupBox13.Controls.Add(this.OSDText1PointX);
            this.groupBox13.Controls.Add(this.label61);
            this.groupBox13.Controls.Add(this.label72);
            this.groupBox13.Controls.Add(this.OSDNameText);
            this.groupBox13.Controls.Add(this.label69);
            this.groupBox13.Controls.Add(this.label58);
            this.groupBox13.Controls.Add(this.label66);
            this.groupBox13.Controls.Add(this.OSDNamePointXText);
            this.groupBox13.Controls.Add(this.label63);
            this.groupBox13.Controls.Add(this.label55);
            this.groupBox13.Controls.Add(this.label60);
            this.groupBox13.Controls.Add(this.OSDTimePointXText);
            this.groupBox13.Controls.Add(this.label57);
            this.groupBox13.Controls.Add(this.label52);
            this.groupBox13.Controls.Add(this.label54);
            this.groupBox13.Controls.Add(this.label51);
            this.groupBox13.Controls.Add(this.OSDDateCobBox);
            this.groupBox13.Controls.Add(this.OSDTimeCobBox);
            this.groupBox13.Location = new System.Drawing.Point(23, 25);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(700, 382);
            this.groupBox13.TabIndex = 3;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "OSD";
            // 
            // OSDText6CheckBox
            // 
            this.OSDText6CheckBox.AutoSize = true;
            this.OSDText6CheckBox.Location = new System.Drawing.Point(21, 300);
            this.OSDText6CheckBox.Name = "OSDText6CheckBox";
            this.OSDText6CheckBox.Size = new System.Drawing.Size(66, 21);
            this.OSDText6CheckBox.TabIndex = 11;
            this.OSDText6CheckBox.Text = "Enable";
            this.OSDText6CheckBox.UseVisualStyleBackColor = true;
            this.OSDText6CheckBox.Visible = false;
            // 
            // OSDText5CheckBox
            // 
            this.OSDText5CheckBox.AutoSize = true;
            this.OSDText5CheckBox.Location = new System.Drawing.Point(21, 262);
            this.OSDText5CheckBox.Name = "OSDText5CheckBox";
            this.OSDText5CheckBox.Size = new System.Drawing.Size(66, 21);
            this.OSDText5CheckBox.TabIndex = 11;
            this.OSDText5CheckBox.Text = "Enable";
            this.OSDText5CheckBox.UseVisualStyleBackColor = true;
            this.OSDText5CheckBox.Visible = false;
            // 
            // OSDText4CheckBox
            // 
            this.OSDText4CheckBox.AutoSize = true;
            this.OSDText4CheckBox.Location = new System.Drawing.Point(21, 218);
            this.OSDText4CheckBox.Name = "OSDText4CheckBox";
            this.OSDText4CheckBox.Size = new System.Drawing.Size(66, 21);
            this.OSDText4CheckBox.TabIndex = 11;
            this.OSDText4CheckBox.Text = "Enable";
            this.OSDText4CheckBox.UseVisualStyleBackColor = true;
            this.OSDText4CheckBox.Visible = false;
            // 
            // OSDText3CheckBox
            // 
            this.OSDText3CheckBox.AutoSize = true;
            this.OSDText3CheckBox.Location = new System.Drawing.Point(21, 180);
            this.OSDText3CheckBox.Name = "OSDText3CheckBox";
            this.OSDText3CheckBox.Size = new System.Drawing.Size(66, 21);
            this.OSDText3CheckBox.TabIndex = 11;
            this.OSDText3CheckBox.Text = "Enable";
            this.OSDText3CheckBox.UseVisualStyleBackColor = true;
            this.OSDText3CheckBox.Visible = false;
            // 
            // OSDText2CheckBox
            // 
            this.OSDText2CheckBox.AutoSize = true;
            this.OSDText2CheckBox.Location = new System.Drawing.Point(21, 138);
            this.OSDText2CheckBox.Name = "OSDText2CheckBox";
            this.OSDText2CheckBox.Size = new System.Drawing.Size(66, 21);
            this.OSDText2CheckBox.TabIndex = 11;
            this.OSDText2CheckBox.Text = "Enable";
            this.OSDText2CheckBox.UseVisualStyleBackColor = true;
            this.OSDText2CheckBox.Visible = false;
            // 
            // OSDText1CheckBox
            // 
            this.OSDText1CheckBox.AutoSize = true;
            this.OSDText1CheckBox.Location = new System.Drawing.Point(21, 98);
            this.OSDText1CheckBox.Name = "OSDText1CheckBox";
            this.OSDText1CheckBox.Size = new System.Drawing.Size(66, 21);
            this.OSDText1CheckBox.TabIndex = 11;
            this.OSDText1CheckBox.Text = "Enable";
            this.OSDText1CheckBox.UseVisualStyleBackColor = true;
            this.OSDText1CheckBox.Visible = false;
            // 
            // OSDNameCheckBox
            // 
            this.OSDNameCheckBox.AutoSize = true;
            this.OSDNameCheckBox.Location = new System.Drawing.Point(21, 62);
            this.OSDNameCheckBox.Name = "OSDNameCheckBox";
            this.OSDNameCheckBox.Size = new System.Drawing.Size(66, 21);
            this.OSDNameCheckBox.TabIndex = 11;
            this.OSDNameCheckBox.Text = "Enable";
            this.OSDNameCheckBox.UseVisualStyleBackColor = true;
            this.OSDNameCheckBox.Visible = false;
            // 
            // OSDTimeCheckBox
            // 
            this.OSDTimeCheckBox.AutoSize = true;
            this.OSDTimeCheckBox.Location = new System.Drawing.Point(21, 24);
            this.OSDTimeCheckBox.Name = "OSDTimeCheckBox";
            this.OSDTimeCheckBox.Size = new System.Drawing.Size(66, 21);
            this.OSDTimeCheckBox.TabIndex = 11;
            this.OSDTimeCheckBox.Text = "Enable";
            this.OSDTimeCheckBox.UseVisualStyleBackColor = true;
            this.OSDTimeCheckBox.Visible = false;
            // 
            // OSDSaveBtn
            // 
            this.OSDSaveBtn.Location = new System.Drawing.Point(569, 340);
            this.OSDSaveBtn.Name = "OSDSaveBtn";
            this.OSDSaveBtn.Size = new System.Drawing.Size(75, 23);
            this.OSDSaveBtn.TabIndex = 9;
            this.OSDSaveBtn.Text = "Save";
            this.OSDSaveBtn.UseVisualStyleBackColor = true;
            this.OSDSaveBtn.Click += new System.EventHandler(this.OSDSaveBtn_Click);
            // 
            // OSDText6PointY
            // 
            this.OSDText6PointY.Location = new System.Drawing.Point(540, 301);
            this.OSDText6PointY.Name = "OSDText6PointY";
            this.OSDText6PointY.Size = new System.Drawing.Size(58, 23);
            this.OSDText6PointY.TabIndex = 10;
            this.OSDText6PointY.Text = "0";
            // 
            // OSDText5PointY
            // 
            this.OSDText5PointY.Location = new System.Drawing.Point(540, 263);
            this.OSDText5PointY.Name = "OSDText5PointY";
            this.OSDText5PointY.Size = new System.Drawing.Size(58, 23);
            this.OSDText5PointY.TabIndex = 10;
            this.OSDText5PointY.Text = "0";
            // 
            // OSDText4PointY
            // 
            this.OSDText4PointY.Location = new System.Drawing.Point(540, 219);
            this.OSDText4PointY.Name = "OSDText4PointY";
            this.OSDText4PointY.Size = new System.Drawing.Size(58, 23);
            this.OSDText4PointY.TabIndex = 10;
            this.OSDText4PointY.Text = "0";
            // 
            // OSDText3PointY
            // 
            this.OSDText3PointY.Location = new System.Drawing.Point(540, 181);
            this.OSDText3PointY.Name = "OSDText3PointY";
            this.OSDText3PointY.Size = new System.Drawing.Size(58, 23);
            this.OSDText3PointY.TabIndex = 10;
            this.OSDText3PointY.Text = "0";
            // 
            // OSDText2PointY
            // 
            this.OSDText2PointY.Location = new System.Drawing.Point(540, 138);
            this.OSDText2PointY.Name = "OSDText2PointY";
            this.OSDText2PointY.Size = new System.Drawing.Size(58, 23);
            this.OSDText2PointY.TabIndex = 10;
            this.OSDText2PointY.Text = "0";
            // 
            // OSDText1PointY
            // 
            this.OSDText1PointY.Location = new System.Drawing.Point(540, 98);
            this.OSDText1PointY.Name = "OSDText1PointY";
            this.OSDText1PointY.Size = new System.Drawing.Size(58, 23);
            this.OSDText1PointY.TabIndex = 10;
            this.OSDText1PointY.Text = "0";
            // 
            // OSDNamePointYText
            // 
            this.OSDNamePointYText.Location = new System.Drawing.Point(540, 59);
            this.OSDNamePointYText.Name = "OSDNamePointYText";
            this.OSDNamePointYText.Size = new System.Drawing.Size(58, 23);
            this.OSDNamePointYText.TabIndex = 10;
            this.OSDNamePointYText.Text = "0";
            // 
            // OSDTimePointYText
            // 
            this.OSDTimePointYText.Location = new System.Drawing.Point(540, 22);
            this.OSDTimePointYText.Name = "OSDTimePointYText";
            this.OSDTimePointYText.Size = new System.Drawing.Size(58, 23);
            this.OSDTimePointYText.TabIndex = 10;
            this.OSDTimePointYText.Text = "0";
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(523, 305);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(15, 17);
            this.label74.TabIndex = 9;
            this.label74.Text = "Y";
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(523, 267);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(15, 17);
            this.label71.TabIndex = 9;
            this.label71.Text = "Y";
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(523, 223);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(15, 17);
            this.label68.TabIndex = 9;
            this.label68.Text = "Y";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(523, 185);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(15, 17);
            this.label65.TabIndex = 9;
            this.label65.Text = "Y";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(523, 142);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(15, 17);
            this.label62.TabIndex = 9;
            this.label62.Text = "Y";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(523, 102);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(15, 17);
            this.label59.TabIndex = 9;
            this.label59.Text = "Y";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(523, 63);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(15, 17);
            this.label56.TabIndex = 9;
            this.label56.Text = "Y";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(523, 26);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(15, 17);
            this.label53.TabIndex = 9;
            this.label53.Text = "Y";
            // 
            // OSDText6
            // 
            this.OSDText6.Location = new System.Drawing.Point(166, 301);
            this.OSDText6.Name = "OSDText6";
            this.OSDText6.Size = new System.Drawing.Size(242, 23);
            this.OSDText6.TabIndex = 10;
            // 
            // OSDText6PointX
            // 
            this.OSDText6PointX.Location = new System.Drawing.Point(446, 301);
            this.OSDText6PointX.Name = "OSDText6PointX";
            this.OSDText6PointX.Size = new System.Drawing.Size(58, 23);
            this.OSDText6PointX.TabIndex = 10;
            this.OSDText6PointX.Text = "0";
            // 
            // OSDText5
            // 
            this.OSDText5.Location = new System.Drawing.Point(166, 263);
            this.OSDText5.Name = "OSDText5";
            this.OSDText5.Size = new System.Drawing.Size(242, 23);
            this.OSDText5.TabIndex = 10;
            // 
            // OSDText5PointX
            // 
            this.OSDText5PointX.Location = new System.Drawing.Point(446, 263);
            this.OSDText5PointX.Name = "OSDText5PointX";
            this.OSDText5PointX.Size = new System.Drawing.Size(58, 23);
            this.OSDText5PointX.TabIndex = 10;
            this.OSDText5PointX.Text = "0";
            // 
            // OSDText4
            // 
            this.OSDText4.Location = new System.Drawing.Point(166, 219);
            this.OSDText4.Name = "OSDText4";
            this.OSDText4.Size = new System.Drawing.Size(242, 23);
            this.OSDText4.TabIndex = 10;
            // 
            // OSDText4PointX
            // 
            this.OSDText4PointX.Location = new System.Drawing.Point(446, 219);
            this.OSDText4PointX.Name = "OSDText4PointX";
            this.OSDText4PointX.Size = new System.Drawing.Size(58, 23);
            this.OSDText4PointX.TabIndex = 10;
            this.OSDText4PointX.Text = "0";
            // 
            // OSDText3
            // 
            this.OSDText3.Location = new System.Drawing.Point(166, 181);
            this.OSDText3.Name = "OSDText3";
            this.OSDText3.Size = new System.Drawing.Size(242, 23);
            this.OSDText3.TabIndex = 10;
            // 
            // OSDText3PointX
            // 
            this.OSDText3PointX.Location = new System.Drawing.Point(446, 181);
            this.OSDText3PointX.Name = "OSDText3PointX";
            this.OSDText3PointX.Size = new System.Drawing.Size(58, 23);
            this.OSDText3PointX.TabIndex = 10;
            this.OSDText3PointX.Text = "0";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(429, 305);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(16, 17);
            this.label73.TabIndex = 9;
            this.label73.Text = "X";
            // 
            // OSDText2
            // 
            this.OSDText2.Location = new System.Drawing.Point(166, 138);
            this.OSDText2.Name = "OSDText2";
            this.OSDText2.Size = new System.Drawing.Size(242, 23);
            this.OSDText2.TabIndex = 10;
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(429, 267);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(16, 17);
            this.label70.TabIndex = 9;
            this.label70.Text = "X";
            // 
            // OSDText2PointX
            // 
            this.OSDText2PointX.Location = new System.Drawing.Point(446, 138);
            this.OSDText2PointX.Name = "OSDText2PointX";
            this.OSDText2PointX.Size = new System.Drawing.Size(58, 23);
            this.OSDText2PointX.TabIndex = 10;
            this.OSDText2PointX.Text = "0";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(429, 223);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(16, 17);
            this.label67.TabIndex = 9;
            this.label67.Text = "X";
            // 
            // OSDText1
            // 
            this.OSDText1.Location = new System.Drawing.Point(166, 98);
            this.OSDText1.Name = "OSDText1";
            this.OSDText1.Size = new System.Drawing.Size(242, 23);
            this.OSDText1.TabIndex = 10;
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(429, 185);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(16, 17);
            this.label64.TabIndex = 9;
            this.label64.Text = "X";
            // 
            // OSDText1PointX
            // 
            this.OSDText1PointX.Location = new System.Drawing.Point(446, 98);
            this.OSDText1PointX.Name = "OSDText1PointX";
            this.OSDText1PointX.Size = new System.Drawing.Size(58, 23);
            this.OSDText1PointX.TabIndex = 10;
            this.OSDText1PointX.Text = "0";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(429, 142);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(16, 17);
            this.label61.TabIndex = 9;
            this.label61.Text = "X";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(116, 304);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(43, 17);
            this.label72.TabIndex = 9;
            this.label72.Text = "Text 6";
            // 
            // OSDNameText
            // 
            this.OSDNameText.Location = new System.Drawing.Point(166, 59);
            this.OSDNameText.Name = "OSDNameText";
            this.OSDNameText.Size = new System.Drawing.Size(242, 23);
            this.OSDNameText.TabIndex = 10;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(116, 266);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(43, 17);
            this.label69.TabIndex = 9;
            this.label69.Text = "Text 5";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(429, 102);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(16, 17);
            this.label58.TabIndex = 9;
            this.label58.Text = "X";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(116, 222);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(43, 17);
            this.label66.TabIndex = 9;
            this.label66.Text = "Text 4";
            // 
            // OSDNamePointXText
            // 
            this.OSDNamePointXText.Location = new System.Drawing.Point(446, 59);
            this.OSDNamePointXText.Name = "OSDNamePointXText";
            this.OSDNamePointXText.Size = new System.Drawing.Size(58, 23);
            this.OSDNamePointXText.TabIndex = 10;
            this.OSDNamePointXText.Text = "0";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(116, 184);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(43, 17);
            this.label63.TabIndex = 9;
            this.label63.Text = "Text 3";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(429, 63);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(16, 17);
            this.label55.TabIndex = 9;
            this.label55.Text = "X";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(116, 141);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(43, 17);
            this.label60.TabIndex = 9;
            this.label60.Text = "Text 2";
            // 
            // OSDTimePointXText
            // 
            this.OSDTimePointXText.Location = new System.Drawing.Point(446, 22);
            this.OSDTimePointXText.Name = "OSDTimePointXText";
            this.OSDTimePointXText.Size = new System.Drawing.Size(58, 23);
            this.OSDTimePointXText.TabIndex = 10;
            this.OSDTimePointXText.Text = "0";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(116, 101);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(43, 17);
            this.label57.TabIndex = 9;
            this.label57.Text = "Text 1";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(429, 26);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(16, 17);
            this.label52.TabIndex = 9;
            this.label52.Text = "X";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(116, 62);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(43, 17);
            this.label54.TabIndex = 9;
            this.label54.Text = "Name";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(116, 26);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(36, 17);
            this.label51.TabIndex = 9;
            this.label51.Text = "Time";
            // 
            // OSDDateCobBox
            // 
            this.OSDDateCobBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OSDDateCobBox.FormattingEnabled = true;
            this.OSDDateCobBox.Items.AddRange(new object[] {
            "M/d/yyyy",
            "MM/dd/yyyy",
            "dd/MM/yyyy",
            "yyyy/MM/dd",
            "yyyy-MM-dd",
            "dddd, MMMM dd, yyyy",
            "MMMM dd, yyyy",
            "dd MMMM, yyyy"});
            this.OSDDateCobBox.Location = new System.Drawing.Point(166, 23);
            this.OSDDateCobBox.Name = "OSDDateCobBox";
            this.OSDDateCobBox.Size = new System.Drawing.Size(122, 25);
            this.OSDDateCobBox.TabIndex = 2;
            // 
            // OSDTimeCobBox
            // 
            this.OSDTimeCobBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OSDTimeCobBox.FormattingEnabled = true;
            this.OSDTimeCobBox.Items.AddRange(new object[] {
            "HH:mm:ss",
            "hh:mm:ss tt"});
            this.OSDTimeCobBox.Location = new System.Drawing.Point(296, 23);
            this.OSDTimeCobBox.Name = "OSDTimeCobBox";
            this.OSDTimeCobBox.Size = new System.Drawing.Size(112, 25);
            this.OSDTimeCobBox.TabIndex = 2;
            // 
            // ConfigIO
            // 
            this.ConfigIO.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ConfigIO.Controls.Add(this.IORefreshBtn);
            this.ConfigIO.Controls.Add(this.groupBox15);
            this.ConfigIO.Controls.Add(this.groupBox14);
            this.ConfigIO.Location = new System.Drawing.Point(4, 26);
            this.ConfigIO.Name = "ConfigIO";
            this.ConfigIO.Size = new System.Drawing.Size(899, 576);
            this.ConfigIO.TabIndex = 5;
            this.ConfigIO.Text = "I/O";
            // 
            // IORefreshBtn
            // 
            this.IORefreshBtn.Location = new System.Drawing.Point(633, 482);
            this.IORefreshBtn.Name = "IORefreshBtn";
            this.IORefreshBtn.Size = new System.Drawing.Size(75, 23);
            this.IORefreshBtn.TabIndex = 10;
            this.IORefreshBtn.Text = "Refresh";
            this.IORefreshBtn.UseVisualStyleBackColor = true;
            this.IORefreshBtn.Click += new System.EventHandler(this.IORefreshBtn_Click);
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.IOAlarmOutputSaveBtn);
            this.groupBox15.Controls.Add(this.IOAlarmOutputTriggerBtn);
            this.groupBox15.Controls.Add(this.IOAlarmOutputDelayText);
            this.groupBox15.Controls.Add(this.IOAlarmOutputChannelID);
            this.groupBox15.Controls.Add(this.label78);
            this.groupBox15.Controls.Add(this.IOAlarmOutputNameText);
            this.groupBox15.Controls.Add(this.label77);
            this.groupBox15.Controls.Add(this.IOAlarmOutputStatusCobBox);
            this.groupBox15.Controls.Add(this.IOAlarmOutputIndexCobBox);
            this.groupBox15.Controls.Add(this.label79);
            this.groupBox15.Controls.Add(this.label76);
            this.groupBox15.Controls.Add(this.label75);
            this.groupBox15.Location = new System.Drawing.Point(16, 232);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(738, 214);
            this.groupBox15.TabIndex = 0;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Alarm Output";
            // 
            // IOAlarmOutputSaveBtn
            // 
            this.IOAlarmOutputSaveBtn.Location = new System.Drawing.Point(617, 172);
            this.IOAlarmOutputSaveBtn.Name = "IOAlarmOutputSaveBtn";
            this.IOAlarmOutputSaveBtn.Size = new System.Drawing.Size(75, 23);
            this.IOAlarmOutputSaveBtn.TabIndex = 10;
            this.IOAlarmOutputSaveBtn.Text = "Save";
            this.IOAlarmOutputSaveBtn.UseVisualStyleBackColor = true;
            this.IOAlarmOutputSaveBtn.Click += new System.EventHandler(this.IOAlarmOutputSaveBtn_Click);
            // 
            // IOAlarmOutputTriggerBtn
            // 
            this.IOAlarmOutputTriggerBtn.Location = new System.Drawing.Point(517, 172);
            this.IOAlarmOutputTriggerBtn.Name = "IOAlarmOutputTriggerBtn";
            this.IOAlarmOutputTriggerBtn.Size = new System.Drawing.Size(75, 23);
            this.IOAlarmOutputTriggerBtn.TabIndex = 10;
            this.IOAlarmOutputTriggerBtn.Text = "Trigger";
            this.IOAlarmOutputTriggerBtn.UseVisualStyleBackColor = true;
            this.IOAlarmOutputTriggerBtn.Click += new System.EventHandler(this.IOAlarmOutputTriggerBtn_Click);
            // 
            // IOAlarmOutputDelayText
            // 
            this.IOAlarmOutputDelayText.Location = new System.Drawing.Point(108, 172);
            this.IOAlarmOutputDelayText.Name = "IOAlarmOutputDelayText";
            this.IOAlarmOutputDelayText.Size = new System.Drawing.Size(166, 23);
            this.IOAlarmOutputDelayText.TabIndex = 2;
            this.IOAlarmOutputDelayText.Text = "0";
            // 
            // IOAlarmOutputChannelID
            // 
            this.IOAlarmOutputChannelID.Location = new System.Drawing.Point(108, 136);
            this.IOAlarmOutputChannelID.Name = "IOAlarmOutputChannelID";
            this.IOAlarmOutputChannelID.Size = new System.Drawing.Size(166, 23);
            this.IOAlarmOutputChannelID.TabIndex = 2;
            this.IOAlarmOutputChannelID.Text = "0";
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(31, 175);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(53, 17);
            this.label78.TabIndex = 0;
            this.label78.Text = "delay(s)";
            // 
            // IOAlarmOutputNameText
            // 
            this.IOAlarmOutputNameText.Enabled = false;
            this.IOAlarmOutputNameText.Location = new System.Drawing.Point(108, 67);
            this.IOAlarmOutputNameText.Name = "IOAlarmOutputNameText";
            this.IOAlarmOutputNameText.Size = new System.Drawing.Size(166, 23);
            this.IOAlarmOutputNameText.TabIndex = 2;
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(31, 139);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(71, 17);
            this.label77.TabIndex = 0;
            this.label77.Text = "Channel ID";
            // 
            // IOAlarmOutputStatusCobBox
            // 
            this.IOAlarmOutputStatusCobBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IOAlarmOutputStatusCobBox.FormattingEnabled = true;
            this.IOAlarmOutputStatusCobBox.Items.AddRange(new object[] {
            "Normally Open",
            "Normally Closed"});
            this.IOAlarmOutputStatusCobBox.Location = new System.Drawing.Point(108, 103);
            this.IOAlarmOutputStatusCobBox.Name = "IOAlarmOutputStatusCobBox";
            this.IOAlarmOutputStatusCobBox.Size = new System.Drawing.Size(166, 25);
            this.IOAlarmOutputStatusCobBox.TabIndex = 1;
            // 
            // IOAlarmOutputIndexCobBox
            // 
            this.IOAlarmOutputIndexCobBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IOAlarmOutputIndexCobBox.FormattingEnabled = true;
            this.IOAlarmOutputIndexCobBox.Location = new System.Drawing.Point(108, 32);
            this.IOAlarmOutputIndexCobBox.Name = "IOAlarmOutputIndexCobBox";
            this.IOAlarmOutputIndexCobBox.Size = new System.Drawing.Size(166, 25);
            this.IOAlarmOutputIndexCobBox.TabIndex = 1;
            this.IOAlarmOutputIndexCobBox.SelectedIndexChanged += new System.EventHandler(this.IOAlarmOutputIndexCobBox_SelectedIndexChanged);
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(31, 106);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(43, 17);
            this.label79.TabIndex = 0;
            this.label79.Text = "Status";
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(31, 70);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(43, 17);
            this.label76.TabIndex = 0;
            this.label76.Text = "Name";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(31, 35);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(40, 17);
            this.label75.TabIndex = 0;
            this.label75.Text = "Index";
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.IOAlarmInputListView);
            this.groupBox14.Location = new System.Drawing.Point(16, 19);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(738, 196);
            this.groupBox14.TabIndex = 0;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Alarm Input";
            // 
            // IOAlarmInputListView
            // 
            this.IOAlarmInputListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AlarmName});
            this.IOAlarmInputListView.GridLines = true;
            this.IOAlarmInputListView.Location = new System.Drawing.Point(19, 20);
            this.IOAlarmInputListView.Name = "IOAlarmInputListView";
            this.IOAlarmInputListView.Size = new System.Drawing.Size(700, 170);
            this.IOAlarmInputListView.TabIndex = 0;
            this.IOAlarmInputListView.UseCompatibleStateImageBehavior = false;
            this.IOAlarmInputListView.View = System.Windows.Forms.View.Details;
            // 
            // AlarmName
            // 
            this.AlarmName.Text = "Alarm Name";
            this.AlarmName.Width = 272;
            // 
            // ConfigPrivacyMask
            // 
            this.ConfigPrivacyMask.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ConfigPrivacyMask.Controls.Add(this.PrivacyMaskRefreshBtn);
            this.ConfigPrivacyMask.Controls.Add(this.groupBox16);
            this.ConfigPrivacyMask.Location = new System.Drawing.Point(4, 26);
            this.ConfigPrivacyMask.Name = "ConfigPrivacyMask";
            this.ConfigPrivacyMask.Size = new System.Drawing.Size(899, 576);
            this.ConfigPrivacyMask.TabIndex = 6;
            this.ConfigPrivacyMask.Text = "Privacy Mask";
            // 
            // PrivacyMaskRefreshBtn
            // 
            this.PrivacyMaskRefreshBtn.Location = new System.Drawing.Point(643, 454);
            this.PrivacyMaskRefreshBtn.Name = "PrivacyMaskRefreshBtn";
            this.PrivacyMaskRefreshBtn.Size = new System.Drawing.Size(75, 23);
            this.PrivacyMaskRefreshBtn.TabIndex = 10;
            this.PrivacyMaskRefreshBtn.Text = "Refresh";
            this.PrivacyMaskRefreshBtn.UseVisualStyleBackColor = true;
            this.PrivacyMaskRefreshBtn.Click += new System.EventHandler(this.PrivacyMaskRefreshBtn_Click);
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.privacyMaskSubItemText);
            this.groupBox16.Controls.Add(this.privacyMaskModifyBtn);
            this.groupBox16.Controls.Add(this.PrivacyMaskSaveBtn);
            this.groupBox16.Controls.Add(this.PrivacyMaskDelBtn);
            this.groupBox16.Controls.Add(this.PrivacyMaskAddBtn);
            this.groupBox16.Controls.Add(this.privacyMaskInfoListView);
            this.groupBox16.Location = new System.Drawing.Point(19, 22);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(756, 257);
            this.groupBox16.TabIndex = 0;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Privacy mask";
            // 
            // privacyMaskSubItemText
            // 
            this.privacyMaskSubItemText.Enabled = false;
            this.privacyMaskSubItemText.Location = new System.Drawing.Point(6, 214);
            this.privacyMaskSubItemText.Name = "privacyMaskSubItemText";
            this.privacyMaskSubItemText.Size = new System.Drawing.Size(134, 23);
            this.privacyMaskSubItemText.TabIndex = 12;
            // 
            // privacyMaskModifyBtn
            // 
            this.privacyMaskModifyBtn.Enabled = false;
            this.privacyMaskModifyBtn.Location = new System.Drawing.Point(159, 214);
            this.privacyMaskModifyBtn.Name = "privacyMaskModifyBtn";
            this.privacyMaskModifyBtn.Size = new System.Drawing.Size(75, 23);
            this.privacyMaskModifyBtn.TabIndex = 11;
            this.privacyMaskModifyBtn.Text = "Modify";
            this.privacyMaskModifyBtn.UseVisualStyleBackColor = true;
            this.privacyMaskModifyBtn.Click += new System.EventHandler(this.privacyMaskModifyBtn_Click);
            // 
            // PrivacyMaskSaveBtn
            // 
            this.PrivacyMaskSaveBtn.Location = new System.Drawing.Point(657, 214);
            this.PrivacyMaskSaveBtn.Name = "PrivacyMaskSaveBtn";
            this.PrivacyMaskSaveBtn.Size = new System.Drawing.Size(75, 23);
            this.PrivacyMaskSaveBtn.TabIndex = 10;
            this.PrivacyMaskSaveBtn.Text = "Save";
            this.PrivacyMaskSaveBtn.UseVisualStyleBackColor = true;
            this.PrivacyMaskSaveBtn.Click += new System.EventHandler(this.PrivacyMaskSaveBtn_Click);
            // 
            // PrivacyMaskDelBtn
            // 
            this.PrivacyMaskDelBtn.Location = new System.Drawing.Point(566, 214);
            this.PrivacyMaskDelBtn.Name = "PrivacyMaskDelBtn";
            this.PrivacyMaskDelBtn.Size = new System.Drawing.Size(75, 23);
            this.PrivacyMaskDelBtn.TabIndex = 10;
            this.PrivacyMaskDelBtn.Text = "Delete";
            this.PrivacyMaskDelBtn.UseVisualStyleBackColor = true;
            this.PrivacyMaskDelBtn.Click += new System.EventHandler(this.PrivacyMaskDelBtn_Click);
            // 
            // PrivacyMaskAddBtn
            // 
            this.PrivacyMaskAddBtn.Location = new System.Drawing.Point(472, 214);
            this.PrivacyMaskAddBtn.Name = "PrivacyMaskAddBtn";
            this.PrivacyMaskAddBtn.Size = new System.Drawing.Size(75, 23);
            this.PrivacyMaskAddBtn.TabIndex = 10;
            this.PrivacyMaskAddBtn.Text = "Add";
            this.PrivacyMaskAddBtn.UseVisualStyleBackColor = true;
            this.PrivacyMaskAddBtn.Click += new System.EventHandler(this.PrivacyMaskAddBtn_Click);
            // 
            // privacyMaskInfoListView
            // 
            this.privacyMaskInfoListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PrivacyMaskNo,
            this.PrivacyMaskLeftTopX,
            this.PrivacyMaskLeftTopY,
            this.PrivacyMaskRightBottomX,
            this.PrivacyMaskRightBottomY});
            this.privacyMaskInfoListView.FullRowSelect = true;
            this.privacyMaskInfoListView.GridLines = true;
            this.privacyMaskInfoListView.HideSelection = false;
            this.privacyMaskInfoListView.Location = new System.Drawing.Point(6, 20);
            this.privacyMaskInfoListView.Name = "privacyMaskInfoListView";
            this.privacyMaskInfoListView.Size = new System.Drawing.Size(742, 174);
            this.privacyMaskInfoListView.TabIndex = 0;
            this.privacyMaskInfoListView.UseCompatibleStateImageBehavior = false;
            this.privacyMaskInfoListView.View = System.Windows.Forms.View.Details;
            this.privacyMaskInfoListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.privacyMaskInfoListView_MouseDoubleClick);
            // 
            // PrivacyMaskNo
            // 
            this.PrivacyMaskNo.Text = "No.";
            // 
            // PrivacyMaskLeftTopX
            // 
            this.PrivacyMaskLeftTopX.Text = "Left Top(X)";
            this.PrivacyMaskLeftTopX.Width = 118;
            // 
            // PrivacyMaskLeftTopY
            // 
            this.PrivacyMaskLeftTopY.Text = "Left Top(Y)";
            this.PrivacyMaskLeftTopY.Width = 111;
            // 
            // PrivacyMaskRightBottomX
            // 
            this.PrivacyMaskRightBottomX.Text = "Right Bottom(X)";
            this.PrivacyMaskRightBottomX.Width = 127;
            // 
            // PrivacyMaskRightBottomY
            // 
            this.PrivacyMaskRightBottomY.Text = "Right Bottom(X)";
            this.PrivacyMaskRightBottomY.Width = 125;
            // 
            // ConfigMotion
            // 
            this.ConfigMotion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ConfigMotion.Controls.Add(this.MotionRefreshBtn);
            this.ConfigMotion.Controls.Add(this.groupBox17);
            this.ConfigMotion.Location = new System.Drawing.Point(4, 26);
            this.ConfigMotion.Name = "ConfigMotion";
            this.ConfigMotion.Size = new System.Drawing.Size(899, 576);
            this.ConfigMotion.TabIndex = 7;
            this.ConfigMotion.Text = "Motion";
            // 
            // MotionRefreshBtn
            // 
            this.MotionRefreshBtn.Location = new System.Drawing.Point(585, 437);
            this.MotionRefreshBtn.Name = "MotionRefreshBtn";
            this.MotionRefreshBtn.Size = new System.Drawing.Size(75, 23);
            this.MotionRefreshBtn.TabIndex = 11;
            this.MotionRefreshBtn.Text = "Refresh";
            this.MotionRefreshBtn.UseVisualStyleBackColor = true;
            this.MotionRefreshBtn.Click += new System.EventHandler(this.MotionRefreshBtn_Click);
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.MotionSaveBtn);
            this.groupBox17.Controls.Add(this.label81);
            this.groupBox17.Controls.Add(this.label82);
            this.groupBox17.Controls.Add(this.label83);
            this.groupBox17.Controls.Add(this.MotionHistoryText);
            this.groupBox17.Controls.Add(this.MotionObjectSizeText);
            this.groupBox17.Controls.Add(this.MotionSensitivityText);
            this.groupBox17.Controls.Add(this.label85);
            this.groupBox17.Controls.Add(this.label86);
            this.groupBox17.Controls.Add(this.label87);
            this.groupBox17.Controls.Add(this.MotionHistoryTrackBar);
            this.groupBox17.Controls.Add(this.MotionObjectSizeTrackBar);
            this.groupBox17.Controls.Add(this.MotionSensitivityTrackBar);
            this.groupBox17.Location = new System.Drawing.Point(18, 15);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(734, 134);
            this.groupBox17.TabIndex = 1;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Motion";
            // 
            // MotionSaveBtn
            // 
            this.MotionSaveBtn.Location = new System.Drawing.Point(567, 97);
            this.MotionSaveBtn.Name = "MotionSaveBtn";
            this.MotionSaveBtn.Size = new System.Drawing.Size(75, 23);
            this.MotionSaveBtn.TabIndex = 9;
            this.MotionSaveBtn.Text = "Save";
            this.MotionSaveBtn.UseVisualStyleBackColor = true;
            this.MotionSaveBtn.Click += new System.EventHandler(this.MotionSaveBtn_Click);
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(17, 100);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(49, 17);
            this.label81.TabIndex = 8;
            this.label81.Text = "History";
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(17, 70);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(73, 17);
            this.label82.TabIndex = 8;
            this.label82.Text = "Object Size";
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(17, 40);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(64, 17);
            this.label83.TabIndex = 8;
            this.label83.Text = "Sensitivity";
            // 
            // MotionHistoryText
            // 
            this.MotionHistoryText.Location = new System.Drawing.Point(334, 97);
            this.MotionHistoryText.Name = "MotionHistoryText";
            this.MotionHistoryText.Size = new System.Drawing.Size(58, 23);
            this.MotionHistoryText.TabIndex = 7;
            this.MotionHistoryText.Text = "50";
            this.MotionHistoryText.TextChanged += new System.EventHandler(this.MotionHistoryText_TextChanged);
            // 
            // MotionObjectSizeText
            // 
            this.MotionObjectSizeText.Location = new System.Drawing.Point(334, 67);
            this.MotionObjectSizeText.Name = "MotionObjectSizeText";
            this.MotionObjectSizeText.Size = new System.Drawing.Size(58, 23);
            this.MotionObjectSizeText.TabIndex = 7;
            this.MotionObjectSizeText.Text = "50";
            this.MotionObjectSizeText.TextChanged += new System.EventHandler(this.MotionObjectSizeText_TextChanged);
            // 
            // MotionSensitivityText
            // 
            this.MotionSensitivityText.Location = new System.Drawing.Point(334, 37);
            this.MotionSensitivityText.Name = "MotionSensitivityText";
            this.MotionSensitivityText.Size = new System.Drawing.Size(58, 23);
            this.MotionSensitivityText.TabIndex = 7;
            this.MotionSensitivityText.Text = "50";
            this.MotionSensitivityText.TextChanged += new System.EventHandler(this.MotionSensitivityText_TextChanged);
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Location = new System.Drawing.Point(402, 102);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(69, 17);
            this.label85.TabIndex = 6;
            this.label85.Text = "( 1 ~ 100 )";
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(402, 72);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(69, 17);
            this.label86.TabIndex = 6;
            this.label86.Text = "( 1 ~ 100 )";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(402, 42);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(69, 17);
            this.label87.TabIndex = 6;
            this.label87.Text = "( 1 ~ 100 )";
            // 
            // MotionHistoryTrackBar
            // 
            this.MotionHistoryTrackBar.AutoSize = false;
            this.MotionHistoryTrackBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.MotionHistoryTrackBar.Location = new System.Drawing.Point(100, 97);
            this.MotionHistoryTrackBar.Maximum = 100;
            this.MotionHistoryTrackBar.Minimum = 1;
            this.MotionHistoryTrackBar.Name = "MotionHistoryTrackBar";
            this.MotionHistoryTrackBar.Size = new System.Drawing.Size(214, 24);
            this.MotionHistoryTrackBar.TabIndex = 5;
            this.MotionHistoryTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.MotionHistoryTrackBar.Value = 50;
            this.MotionHistoryTrackBar.Scroll += new System.EventHandler(this.MotionHistoryTrackBar_Scroll);
            // 
            // MotionObjectSizeTrackBar
            // 
            this.MotionObjectSizeTrackBar.AutoSize = false;
            this.MotionObjectSizeTrackBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.MotionObjectSizeTrackBar.Location = new System.Drawing.Point(100, 67);
            this.MotionObjectSizeTrackBar.Maximum = 100;
            this.MotionObjectSizeTrackBar.Minimum = 1;
            this.MotionObjectSizeTrackBar.Name = "MotionObjectSizeTrackBar";
            this.MotionObjectSizeTrackBar.Size = new System.Drawing.Size(214, 24);
            this.MotionObjectSizeTrackBar.TabIndex = 5;
            this.MotionObjectSizeTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.MotionObjectSizeTrackBar.Value = 50;
            this.MotionObjectSizeTrackBar.Scroll += new System.EventHandler(this.MotionObjectSizeTrackBar_Scroll);
            // 
            // MotionSensitivityTrackBar
            // 
            this.MotionSensitivityTrackBar.AutoSize = false;
            this.MotionSensitivityTrackBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.MotionSensitivityTrackBar.Location = new System.Drawing.Point(100, 37);
            this.MotionSensitivityTrackBar.Maximum = 100;
            this.MotionSensitivityTrackBar.Minimum = 1;
            this.MotionSensitivityTrackBar.Name = "MotionSensitivityTrackBar";
            this.MotionSensitivityTrackBar.Size = new System.Drawing.Size(214, 24);
            this.MotionSensitivityTrackBar.TabIndex = 5;
            this.MotionSensitivityTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.MotionSensitivityTrackBar.Value = 50;
            this.MotionSensitivityTrackBar.Scroll += new System.EventHandler(this.MotionSensitivityTrackBar_Scroll);
            // 
            // ConfigTemper
            // 
            this.ConfigTemper.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ConfigTemper.Controls.Add(this.TemperRefreshBtn);
            this.ConfigTemper.Controls.Add(this.groupBox18);
            this.ConfigTemper.Location = new System.Drawing.Point(4, 26);
            this.ConfigTemper.Name = "ConfigTemper";
            this.ConfigTemper.Size = new System.Drawing.Size(899, 576);
            this.ConfigTemper.TabIndex = 8;
            this.ConfigTemper.Text = "Temper";
            // 
            // TemperRefreshBtn
            // 
            this.TemperRefreshBtn.Location = new System.Drawing.Point(584, 441);
            this.TemperRefreshBtn.Name = "TemperRefreshBtn";
            this.TemperRefreshBtn.Size = new System.Drawing.Size(75, 23);
            this.TemperRefreshBtn.TabIndex = 12;
            this.TemperRefreshBtn.Text = "Refresh";
            this.TemperRefreshBtn.UseVisualStyleBackColor = true;
            this.TemperRefreshBtn.Click += new System.EventHandler(this.TemperRefreshBtn_Click);
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.TemperSaveBtn);
            this.groupBox18.Controls.Add(this.label80);
            this.groupBox18.Controls.Add(this.TemperSensitivityText);
            this.groupBox18.Controls.Add(this.label89);
            this.groupBox18.Controls.Add(this.TemperSensitivityTrackBar);
            this.groupBox18.Location = new System.Drawing.Point(17, 16);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(734, 69);
            this.groupBox18.TabIndex = 2;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Temper";
            // 
            // TemperSaveBtn
            // 
            this.TemperSaveBtn.Location = new System.Drawing.Point(567, 25);
            this.TemperSaveBtn.Name = "TemperSaveBtn";
            this.TemperSaveBtn.Size = new System.Drawing.Size(75, 23);
            this.TemperSaveBtn.TabIndex = 9;
            this.TemperSaveBtn.Text = "Save";
            this.TemperSaveBtn.UseVisualStyleBackColor = true;
            this.TemperSaveBtn.Click += new System.EventHandler(this.TemperSaveBtn_Click);
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(17, 28);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(64, 17);
            this.label80.TabIndex = 8;
            this.label80.Text = "Sensitivity";
            // 
            // TemperSensitivityText
            // 
            this.TemperSensitivityText.Location = new System.Drawing.Point(334, 25);
            this.TemperSensitivityText.Name = "TemperSensitivityText";
            this.TemperSensitivityText.Size = new System.Drawing.Size(58, 23);
            this.TemperSensitivityText.TabIndex = 7;
            this.TemperSensitivityText.Text = "50";
            this.TemperSensitivityText.TextChanged += new System.EventHandler(this.TemperSensitivityText_TextChanged);
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(402, 30);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(69, 17);
            this.label89.TabIndex = 6;
            this.label89.Text = "( 1 ~ 100 )";
            // 
            // TemperSensitivityTrackBar
            // 
            this.TemperSensitivityTrackBar.AutoSize = false;
            this.TemperSensitivityTrackBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.TemperSensitivityTrackBar.Location = new System.Drawing.Point(100, 25);
            this.TemperSensitivityTrackBar.Maximum = 100;
            this.TemperSensitivityTrackBar.Name = "TemperSensitivityTrackBar";
            this.TemperSensitivityTrackBar.Size = new System.Drawing.Size(214, 24);
            this.TemperSensitivityTrackBar.TabIndex = 5;
            this.TemperSensitivityTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TemperSensitivityTrackBar.Value = 50;
            this.TemperSensitivityTrackBar.Scroll += new System.EventHandler(this.TemperSensitivityTrackBar_Scroll);
            // 
            // AlarmRecords
            // 
            this.AlarmRecords.BackColor = System.Drawing.Color.WhiteSmoke;
            this.AlarmRecords.Controls.Add(this.groupBox5);
            this.AlarmRecords.Location = new System.Drawing.Point(4, 26);
            this.AlarmRecords.Name = "AlarmRecords";
            this.AlarmRecords.Padding = new System.Windows.Forms.Padding(3);
            this.AlarmRecords.Size = new System.Drawing.Size(899, 606);
            this.AlarmRecords.TabIndex = 3;
            this.AlarmRecords.Text = "Alarm Records";
            this.AlarmRecords.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.AlarmRecordsListView);
            this.groupBox5.Controls.Add(this.AlarmRecordsClearBtn);
            this.groupBox5.Location = new System.Drawing.Point(3, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(888, 604);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Real-Time Alarm";
            // 
            // AlarmRecordsListView
            // 
            this.AlarmRecordsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AlarmRecordTime,
            this.AlarmRecordIP,
            this.AlarmRecordChannelID,
            this.AlarmRecordInfo});
            this.AlarmRecordsListView.FullRowSelect = true;
            this.AlarmRecordsListView.GridLines = true;
            this.AlarmRecordsListView.HideSelection = false;
            this.AlarmRecordsListView.Location = new System.Drawing.Point(17, 67);
            this.AlarmRecordsListView.Name = "AlarmRecordsListView";
            this.AlarmRecordsListView.Size = new System.Drawing.Size(801, 513);
            this.AlarmRecordsListView.TabIndex = 1;
            this.AlarmRecordsListView.UseCompatibleStateImageBehavior = false;
            this.AlarmRecordsListView.View = System.Windows.Forms.View.Details;
            // 
            // AlarmRecordTime
            // 
            this.AlarmRecordTime.Text = "Time";
            this.AlarmRecordTime.Width = 150;
            // 
            // AlarmRecordIP
            // 
            this.AlarmRecordIP.Text = "IP";
            this.AlarmRecordIP.Width = 150;
            // 
            // AlarmRecordChannelID
            // 
            this.AlarmRecordChannelID.Text = "Channel ID";
            this.AlarmRecordChannelID.Width = 150;
            // 
            // AlarmRecordInfo
            // 
            this.AlarmRecordInfo.Text = "Info";
            this.AlarmRecordInfo.Width = 345;
            // 
            // AlarmRecordsClearBtn
            // 
            this.AlarmRecordsClearBtn.Location = new System.Drawing.Point(709, 32);
            this.AlarmRecordsClearBtn.Name = "AlarmRecordsClearBtn";
            this.AlarmRecordsClearBtn.Size = new System.Drawing.Size(75, 23);
            this.AlarmRecordsClearBtn.TabIndex = 0;
            this.AlarmRecordsClearBtn.Text = "Clear";
            this.AlarmRecordsClearBtn.UseVisualStyleBackColor = true;
            this.AlarmRecordsClearBtn.Click += new System.EventHandler(this.AlarmRecordsClearBtn_Click);
            // 
            // VCA
            // 
            this.VCA.BackColor = System.Drawing.Color.WhiteSmoke;
            this.VCA.Controls.Add(this.VCATabCtrl);
            this.VCA.Location = new System.Drawing.Point(4, 26);
            this.VCA.Name = "VCA";
            this.VCA.Padding = new System.Windows.Forms.Padding(3);
            this.VCA.Size = new System.Drawing.Size(899, 606);
            this.VCA.TabIndex = 4;
            this.VCA.Text = " VCA";
            this.VCA.UseVisualStyleBackColor = true;
            // 
            // VCATabCtrl
            // 
            this.VCATabCtrl.Controls.Add(this.PeopleCountingforReport);
            this.VCATabCtrl.Controls.Add(this.PeopleCountingforStatistics);
            this.VCATabCtrl.Controls.Add(this.FaceTabPage);
            this.VCATabCtrl.Controls.Add(this.LicensePlateRecognitionTabPage);
            this.VCATabCtrl.Location = new System.Drawing.Point(0, 0);
            this.VCATabCtrl.Name = "VCATabCtrl";
            this.VCATabCtrl.SelectedIndex = 0;
            this.VCATabCtrl.Size = new System.Drawing.Size(903, 600);
            this.VCATabCtrl.TabIndex = 0;
            // 
            // PeopleCountingforReport
            // 
            this.PeopleCountingforReport.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PeopleCountingforReport.Controls.Add(this.VCAReportDataListView);
            this.PeopleCountingforReport.Controls.Add(this.label15);
            this.PeopleCountingforReport.Controls.Add(this.label10);
            this.PeopleCountingforReport.Controls.Add(this.VCAClearDataBtn);
            this.PeopleCountingforReport.Controls.Add(this.VCACloseCallBackBtn);
            this.PeopleCountingforReport.Controls.Add(this.VCARegCallBackBtn);
            this.PeopleCountingforReport.Location = new System.Drawing.Point(4, 26);
            this.PeopleCountingforReport.Name = "PeopleCountingforReport";
            this.PeopleCountingforReport.Padding = new System.Windows.Forms.Padding(3);
            this.PeopleCountingforReport.Size = new System.Drawing.Size(895, 570);
            this.PeopleCountingforReport.TabIndex = 0;
            this.PeopleCountingforReport.Text = "People Counting for Report";
            // 
            // VCAReportDataListView
            // 
            this.VCAReportDataListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DeviceIP,
            this.ChannelID,
            this.ReportTime,
            this.IntervalTime,
            this.EnterNumber,
            this.ExitNumber,
            this.TotalEnterNumber,
            this.TotalExitNumber});
            this.VCAReportDataListView.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.VCAReportDataListView.GridLines = true;
            this.VCAReportDataListView.Location = new System.Drawing.Point(11, 58);
            this.VCAReportDataListView.Name = "VCAReportDataListView";
            this.VCAReportDataListView.Size = new System.Drawing.Size(756, 423);
            this.VCAReportDataListView.TabIndex = 2;
            this.VCAReportDataListView.UseCompatibleStateImageBehavior = false;
            this.VCAReportDataListView.View = System.Windows.Forms.View.Details;
            // 
            // DeviceIP
            // 
            this.DeviceIP.Text = "Device IP";
            this.DeviceIP.Width = 80;
            // 
            // ChannelID
            // 
            this.ChannelID.Text = "Channel ID";
            this.ChannelID.Width = 80;
            // 
            // ReportTime
            // 
            this.ReportTime.Text = "Report Time";
            this.ReportTime.Width = 90;
            // 
            // IntervalTime
            // 
            this.IntervalTime.Text = "Interval Time";
            this.IntervalTime.Width = 90;
            // 
            // EnterNumber
            // 
            this.EnterNumber.Text = "Enter Number";
            this.EnterNumber.Width = 90;
            // 
            // ExitNumber
            // 
            this.ExitNumber.Text = "Exit Number";
            this.ExitNumber.Width = 80;
            // 
            // TotalEnterNumber
            // 
            this.TotalEnterNumber.Text = "Total Enter Number";
            this.TotalEnterNumber.Width = 120;
            // 
            // TotalExitNumber
            // 
            this.TotalExitNumber.Text = "Total Exit Number";
            this.TotalExitNumber.Width = 120;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 491);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(260, 17);
            this.label15.TabIndex = 1;
            this.label15.Text = "Note: This function is available for IPC only.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(9, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "Register Call Back";
            // 
            // VCAClearDataBtn
            // 
            this.VCAClearDataBtn.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.VCAClearDataBtn.Location = new System.Drawing.Point(692, 19);
            this.VCAClearDataBtn.Name = "VCAClearDataBtn";
            this.VCAClearDataBtn.Size = new System.Drawing.Size(75, 23);
            this.VCAClearDataBtn.TabIndex = 0;
            this.VCAClearDataBtn.Text = "Clear";
            this.VCAClearDataBtn.UseVisualStyleBackColor = true;
            this.VCAClearDataBtn.Click += new System.EventHandler(this.VCAClearDataBtn_Click);
            // 
            // VCACloseCallBackBtn
            // 
            this.VCACloseCallBackBtn.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.VCACloseCallBackBtn.Location = new System.Drawing.Point(249, 19);
            this.VCACloseCallBackBtn.Name = "VCACloseCallBackBtn";
            this.VCACloseCallBackBtn.Size = new System.Drawing.Size(75, 23);
            this.VCACloseCallBackBtn.TabIndex = 0;
            this.VCACloseCallBackBtn.Text = "Close";
            this.VCACloseCallBackBtn.UseVisualStyleBackColor = true;
            this.VCACloseCallBackBtn.Click += new System.EventHandler(this.VCACloseCallBackBtn_Click);
            // 
            // VCARegCallBackBtn
            // 
            this.VCARegCallBackBtn.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.VCARegCallBackBtn.Location = new System.Drawing.Point(153, 19);
            this.VCARegCallBackBtn.Name = "VCARegCallBackBtn";
            this.VCARegCallBackBtn.Size = new System.Drawing.Size(75, 23);
            this.VCARegCallBackBtn.TabIndex = 0;
            this.VCARegCallBackBtn.Text = "Register";
            this.VCARegCallBackBtn.UseVisualStyleBackColor = true;
            this.VCARegCallBackBtn.Click += new System.EventHandler(this.VCARegCallBackBtn_Click);
            // 
            // PeopleCountingforStatistics
            // 
            this.PeopleCountingforStatistics.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PeopleCountingforStatistics.Controls.Add(this.VCAStatisticalTime);
            this.PeopleCountingforStatistics.Controls.Add(this.VCACountingType);
            this.PeopleCountingforStatistics.Controls.Add(this.label18);
            this.PeopleCountingforStatistics.Controls.Add(this.label11);
            this.PeopleCountingforStatistics.Controls.Add(this.VCAReportType);
            this.PeopleCountingforStatistics.Controls.Add(this.label17);
            this.PeopleCountingforStatistics.Controls.Add(this.VCAStatisticDataListView);
            this.PeopleCountingforStatistics.Controls.Add(this.label16);
            this.PeopleCountingforStatistics.Controls.Add(this.VCACountBtn);
            this.PeopleCountingforStatistics.Location = new System.Drawing.Point(4, 26);
            this.PeopleCountingforStatistics.Name = "PeopleCountingforStatistics";
            this.PeopleCountingforStatistics.Padding = new System.Windows.Forms.Padding(3);
            this.PeopleCountingforStatistics.Size = new System.Drawing.Size(895, 570);
            this.PeopleCountingforStatistics.TabIndex = 1;
            this.PeopleCountingforStatistics.Text = "People Counting for Statistics";
            // 
            // VCAStatisticalTime
            // 
            this.VCAStatisticalTime.CustomFormat = "yyyy/MM/dd";
            this.VCAStatisticalTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.VCAStatisticalTime.Location = new System.Drawing.Point(134, 95);
            this.VCAStatisticalTime.Name = "VCAStatisticalTime";
            this.VCAStatisticalTime.Size = new System.Drawing.Size(121, 23);
            this.VCAStatisticalTime.TabIndex = 4;
            // 
            // VCACountingType
            // 
            this.VCACountingType.FormattingEnabled = true;
            this.VCACountingType.Items.AddRange(new object[] {
            "People Entered",
            "People Left",
            "Total"});
            this.VCACountingType.Location = new System.Drawing.Point(134, 60);
            this.VCACountingType.Name = "VCACountingType";
            this.VCACountingType.Size = new System.Drawing.Size(121, 25);
            this.VCACountingType.TabIndex = 3;
            this.VCACountingType.Text = "People Entered";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 434);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(267, 17);
            this.label18.TabIndex = 1;
            this.label18.Text = "Note: This function is available for NVR only.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 17);
            this.label11.TabIndex = 1;
            this.label11.Text = "Statistical Time";
            // 
            // VCAReportType
            // 
            this.VCAReportType.FormattingEnabled = true;
            this.VCAReportType.Items.AddRange(new object[] {
            "Daily",
            "Weekly",
            "Monthly",
            "Yearly"});
            this.VCAReportType.Location = new System.Drawing.Point(134, 24);
            this.VCAReportType.Name = "VCAReportType";
            this.VCAReportType.Size = new System.Drawing.Size(121, 25);
            this.VCAReportType.TabIndex = 3;
            this.VCAReportType.Text = "Daily";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 63);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(92, 17);
            this.label17.TabIndex = 1;
            this.label17.Text = "Counting Type";
            // 
            // VCAStatisticDataListView
            // 
            this.VCAStatisticDataListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.StatisticalTime,
            this.PeopleEntered,
            this.PeopleLeft});
            this.VCAStatisticDataListView.GridLines = true;
            this.VCAStatisticDataListView.Location = new System.Drawing.Point(14, 134);
            this.VCAStatisticDataListView.Name = "VCAStatisticDataListView";
            this.VCAStatisticDataListView.Size = new System.Drawing.Size(594, 285);
            this.VCAStatisticDataListView.TabIndex = 2;
            this.VCAStatisticDataListView.UseCompatibleStateImageBehavior = false;
            this.VCAStatisticDataListView.View = System.Windows.Forms.View.Details;
            // 
            // StatisticalTime
            // 
            this.StatisticalTime.Text = "Statistical Time";
            this.StatisticalTime.Width = 195;
            // 
            // PeopleEntered
            // 
            this.PeopleEntered.Text = "People Entered";
            this.PeopleEntered.Width = 195;
            // 
            // PeopleLeft
            // 
            this.PeopleLeft.Text = "People Left";
            this.PeopleLeft.Width = 195;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 27);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 17);
            this.label16.TabIndex = 1;
            this.label16.Text = "Report Type";
            // 
            // VCACountBtn
            // 
            this.VCACountBtn.Location = new System.Drawing.Point(286, 21);
            this.VCACountBtn.Name = "VCACountBtn";
            this.VCACountBtn.Size = new System.Drawing.Size(75, 23);
            this.VCACountBtn.TabIndex = 0;
            this.VCACountBtn.Text = "Count";
            this.VCACountBtn.UseVisualStyleBackColor = true;
            this.VCACountBtn.Click += new System.EventHandler(this.VCACountBtn_Click);
            // 
            // FaceTabPage
            // 
            this.FaceTabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.FaceTabPage.Controls.Add(this.tabControl1);
            this.FaceTabPage.Location = new System.Drawing.Point(4, 26);
            this.FaceTabPage.Name = "FaceTabPage";
            this.FaceTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.FaceTabPage.Size = new System.Drawing.Size(895, 570);
            this.FaceTabPage.TabIndex = 2;
            this.FaceTabPage.Text = "Face Recognition";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.FaceRealtimeMonitoringTabPage);
            this.tabControl1.Controls.Add(this.FaceLibraryManagenentTabPage);
            this.tabControl1.Controls.Add(this.FaceMonitoringTaskTabPage);
            this.tabControl1.Controls.Add(this.FaceAlarmRecordTabPage);
            this.tabControl1.Controls.Add(this.FacePassThruRecordTabPage);
            this.tabControl1.Location = new System.Drawing.Point(7, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(846, 552);
            this.tabControl1.TabIndex = 2;
            // 
            // FaceRealtimeMonitoringTabPage
            // 
            this.FaceRealtimeMonitoringTabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.FaceRealtimeMonitoringTabPage.Controls.Add(this.groupBox27);
            this.FaceRealtimeMonitoringTabPage.Controls.Add(this.groupBox26);
            this.FaceRealtimeMonitoringTabPage.Controls.Add(this.groupBox24);
            this.FaceRealtimeMonitoringTabPage.Controls.Add(this.groupBox23);
            this.FaceRealtimeMonitoringTabPage.Controls.Add(this.groupBox22);
            this.FaceRealtimeMonitoringTabPage.Controls.Add(this.faceRecogRealPlayFLayoutPanel);
            this.FaceRealtimeMonitoringTabPage.Location = new System.Drawing.Point(4, 26);
            this.FaceRealtimeMonitoringTabPage.Name = "FaceRealtimeMonitoringTabPage";
            this.FaceRealtimeMonitoringTabPage.Size = new System.Drawing.Size(838, 522);
            this.FaceRealtimeMonitoringTabPage.TabIndex = 2;
            this.FaceRealtimeMonitoringTabPage.Text = "Realtime Monitoring";
            this.FaceRealtimeMonitoringTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox27
            // 
            this.groupBox27.Controls.Add(this.faceSnapshotSubBtn);
            this.groupBox27.Controls.Add(this.faceSnapshotUnSubBtn);
            this.groupBox27.Location = new System.Drawing.Point(472, 1);
            this.groupBox27.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox27.Name = "groupBox27";
            this.groupBox27.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox27.Size = new System.Drawing.Size(200, 42);
            this.groupBox27.TabIndex = 7;
            this.groupBox27.TabStop = false;
            this.groupBox27.Text = "Snapshot";
            // 
            // faceSnapshotSubBtn
            // 
            this.faceSnapshotSubBtn.Location = new System.Drawing.Point(11, 15);
            this.faceSnapshotSubBtn.Name = "faceSnapshotSubBtn";
            this.faceSnapshotSubBtn.Size = new System.Drawing.Size(75, 23);
            this.faceSnapshotSubBtn.TabIndex = 6;
            this.faceSnapshotSubBtn.Text = "Subscribe";
            this.faceSnapshotSubBtn.UseVisualStyleBackColor = true;
            this.faceSnapshotSubBtn.Click += new System.EventHandler(this.faceSnapshotSubBtn_Click);
            // 
            // faceSnapshotUnSubBtn
            // 
            this.faceSnapshotUnSubBtn.Location = new System.Drawing.Point(92, 15);
            this.faceSnapshotUnSubBtn.Name = "faceSnapshotUnSubBtn";
            this.faceSnapshotUnSubBtn.Size = new System.Drawing.Size(90, 23);
            this.faceSnapshotUnSubBtn.TabIndex = 6;
            this.faceSnapshotUnSubBtn.Text = "UnSubscribe";
            this.faceSnapshotUnSubBtn.UseVisualStyleBackColor = true;
            this.faceSnapshotUnSubBtn.Click += new System.EventHandler(this.faceSnapshotUnSubBtn_Click);
            // 
            // groupBox26
            // 
            this.groupBox26.Controls.Add(this.faceRecogSubBtn);
            this.groupBox26.Controls.Add(this.faceRecogUnSubBtn);
            this.groupBox26.Location = new System.Drawing.Point(239, 1);
            this.groupBox26.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox26.Name = "groupBox26";
            this.groupBox26.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox26.Size = new System.Drawing.Size(200, 42);
            this.groupBox26.TabIndex = 7;
            this.groupBox26.TabStop = false;
            this.groupBox26.Text = "Recognition";
            // 
            // faceRecogSubBtn
            // 
            this.faceRecogSubBtn.Location = new System.Drawing.Point(11, 15);
            this.faceRecogSubBtn.Name = "faceRecogSubBtn";
            this.faceRecogSubBtn.Size = new System.Drawing.Size(75, 23);
            this.faceRecogSubBtn.TabIndex = 6;
            this.faceRecogSubBtn.Text = "Subscribe";
            this.faceRecogSubBtn.UseVisualStyleBackColor = true;
            this.faceRecogSubBtn.Click += new System.EventHandler(this.faceRecogSubBtn_Click);
            // 
            // faceRecogUnSubBtn
            // 
            this.faceRecogUnSubBtn.Location = new System.Drawing.Point(92, 15);
            this.faceRecogUnSubBtn.Name = "faceRecogUnSubBtn";
            this.faceRecogUnSubBtn.Size = new System.Drawing.Size(91, 23);
            this.faceRecogUnSubBtn.TabIndex = 6;
            this.faceRecogUnSubBtn.Text = "UnSubscribe";
            this.faceRecogUnSubBtn.UseVisualStyleBackColor = true;
            this.faceRecogUnSubBtn.Click += new System.EventHandler(this.faceRecogUnSubBtn_Click);
            // 
            // groupBox24
            // 
            this.groupBox24.Controls.Add(this.faceRecogRealPlayStartBtn);
            this.groupBox24.Controls.Add(this.faceRecogRealPlayStopBtn);
            this.groupBox24.Location = new System.Drawing.Point(20, 1);
            this.groupBox24.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox24.Size = new System.Drawing.Size(200, 42);
            this.groupBox24.TabIndex = 7;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = "RealPlay";
            // 
            // faceRecogRealPlayStartBtn
            // 
            this.faceRecogRealPlayStartBtn.Location = new System.Drawing.Point(11, 15);
            this.faceRecogRealPlayStartBtn.Name = "faceRecogRealPlayStartBtn";
            this.faceRecogRealPlayStartBtn.Size = new System.Drawing.Size(75, 23);
            this.faceRecogRealPlayStartBtn.TabIndex = 6;
            this.faceRecogRealPlayStartBtn.Text = "start";
            this.faceRecogRealPlayStartBtn.UseVisualStyleBackColor = true;
            this.faceRecogRealPlayStartBtn.Click += new System.EventHandler(this.faceRecogRealPlayStartBtn_Click);
            // 
            // faceRecogRealPlayStopBtn
            // 
            this.faceRecogRealPlayStopBtn.Location = new System.Drawing.Point(92, 15);
            this.faceRecogRealPlayStopBtn.Name = "faceRecogRealPlayStopBtn";
            this.faceRecogRealPlayStopBtn.Size = new System.Drawing.Size(75, 23);
            this.faceRecogRealPlayStopBtn.TabIndex = 6;
            this.faceRecogRealPlayStopBtn.Text = "Stop";
            this.faceRecogRealPlayStopBtn.UseVisualStyleBackColor = true;
            this.faceRecogRealPlayStopBtn.Click += new System.EventHandler(this.faceRecogRealPlayStopBtn_Click);
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.similarityLab);
            this.groupBox23.Controls.Add(this.faceRecogAlarmRecordsListView);
            this.groupBox23.Controls.Add(this.personLibPictureBox);
            this.groupBox23.Controls.Add(this.snapshotPictureBox);
            this.groupBox23.Location = new System.Drawing.Point(3, 360);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(823, 159);
            this.groupBox23.TabIndex = 5;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "Alarm Records";
            // 
            // similarityLab
            // 
            this.similarityLab.BackColor = System.Drawing.Color.LightGray;
            this.similarityLab.Location = new System.Drawing.Point(6, 132);
            this.similarityLab.Name = "similarityLab";
            this.similarityLab.Size = new System.Drawing.Size(197, 20);
            this.similarityLab.TabIndex = 4;
            this.similarityLab.Text = "0%";
            this.similarityLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // faceRecogAlarmRecordsListView
            // 
            this.faceRecogAlarmRecordsListView.BackColor = System.Drawing.SystemColors.Window;
            this.faceRecogAlarmRecordsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FaceRecogMatchRecordAlarmTimeCHeader,
            this.FaceRecogMatchRecordNameCHeader,
            this.FaceRecogMatchRecordIDNoCHeader,
            this.FaceRecogMatchRecordMatchCHeader,
            this.FaceRecogMatchRecordAlarmSourceCHeader});
            this.faceRecogAlarmRecordsListView.GridLines = true;
            this.faceRecogAlarmRecordsListView.Location = new System.Drawing.Point(211, 22);
            this.faceRecogAlarmRecordsListView.Name = "faceRecogAlarmRecordsListView";
            this.faceRecogAlarmRecordsListView.Size = new System.Drawing.Size(606, 131);
            this.faceRecogAlarmRecordsListView.TabIndex = 1;
            this.faceRecogAlarmRecordsListView.UseCompatibleStateImageBehavior = false;
            this.faceRecogAlarmRecordsListView.View = System.Windows.Forms.View.Details;
            // 
            // FaceRecogMatchRecordAlarmTimeCHeader
            // 
            this.FaceRecogMatchRecordAlarmTimeCHeader.Text = "Alarm Time";
            this.FaceRecogMatchRecordAlarmTimeCHeader.Width = 134;
            // 
            // FaceRecogMatchRecordNameCHeader
            // 
            this.FaceRecogMatchRecordNameCHeader.Text = "Name";
            this.FaceRecogMatchRecordNameCHeader.Width = 81;
            // 
            // FaceRecogMatchRecordIDNoCHeader
            // 
            this.FaceRecogMatchRecordIDNoCHeader.Text = "ID No.";
            this.FaceRecogMatchRecordIDNoCHeader.Width = 100;
            // 
            // FaceRecogMatchRecordMatchCHeader
            // 
            this.FaceRecogMatchRecordMatchCHeader.Text = "Match";
            this.FaceRecogMatchRecordMatchCHeader.Width = 80;
            // 
            // FaceRecogMatchRecordAlarmSourceCHeader
            // 
            this.FaceRecogMatchRecordAlarmSourceCHeader.Text = "Alarm Source";
            this.FaceRecogMatchRecordAlarmSourceCHeader.Width = 185;
            // 
            // personLibPictureBox
            // 
            this.personLibPictureBox.BackColor = System.Drawing.Color.LightGray;
            this.personLibPictureBox.Location = new System.Drawing.Point(105, 20);
            this.personLibPictureBox.Name = "personLibPictureBox";
            this.personLibPictureBox.Size = new System.Drawing.Size(98, 111);
            this.personLibPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.personLibPictureBox.TabIndex = 3;
            this.personLibPictureBox.TabStop = false;
            // 
            // snapshotPictureBox
            // 
            this.snapshotPictureBox.BackColor = System.Drawing.Color.LightGray;
            this.snapshotPictureBox.Location = new System.Drawing.Point(6, 20);
            this.snapshotPictureBox.Name = "snapshotPictureBox";
            this.snapshotPictureBox.Size = new System.Drawing.Size(98, 111);
            this.snapshotPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.snapshotPictureBox.TabIndex = 2;
            this.snapshotPictureBox.TabStop = false;
            // 
            // groupBox22
            // 
            this.groupBox22.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox22.Controls.Add(this.faceSnapshotPicTimeLab);
            this.groupBox22.Controls.Add(this.faceSnapshotSmallPictureBox);
            this.groupBox22.Controls.Add(this.faceSnapshotLargePictureBox);
            this.groupBox22.Location = new System.Drawing.Point(583, 39);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(243, 319);
            this.groupBox22.TabIndex = 4;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "snapshots";
            // 
            // faceSnapshotPicTimeLab
            // 
            this.faceSnapshotPicTimeLab.BackColor = System.Drawing.Color.LightGray;
            this.faceSnapshotPicTimeLab.Location = new System.Drawing.Point(12, 289);
            this.faceSnapshotPicTimeLab.Name = "faceSnapshotPicTimeLab";
            this.faceSnapshotPicTimeLab.Size = new System.Drawing.Size(225, 25);
            this.faceSnapshotPicTimeLab.TabIndex = 2;
            this.faceSnapshotPicTimeLab.Text = "Time";
            this.faceSnapshotPicTimeLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // faceSnapshotSmallPictureBox
            // 
            this.faceSnapshotSmallPictureBox.BackColor = System.Drawing.Color.LightGray;
            this.faceSnapshotSmallPictureBox.Location = new System.Drawing.Point(68, 161);
            this.faceSnapshotSmallPictureBox.Name = "faceSnapshotSmallPictureBox";
            this.faceSnapshotSmallPictureBox.Size = new System.Drawing.Size(115, 125);
            this.faceSnapshotSmallPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.faceSnapshotSmallPictureBox.TabIndex = 1;
            this.faceSnapshotSmallPictureBox.TabStop = false;
            // 
            // faceSnapshotLargePictureBox
            // 
            this.faceSnapshotLargePictureBox.BackColor = System.Drawing.Color.LightGray;
            this.faceSnapshotLargePictureBox.Location = new System.Drawing.Point(15, 22);
            this.faceSnapshotLargePictureBox.Name = "faceSnapshotLargePictureBox";
            this.faceSnapshotLargePictureBox.Size = new System.Drawing.Size(222, 137);
            this.faceSnapshotLargePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.faceSnapshotLargePictureBox.TabIndex = 0;
            this.faceSnapshotLargePictureBox.TabStop = false;
            // 
            // faceRecogRealPlayFLayoutPanel
            // 
            this.faceRecogRealPlayFLayoutPanel.Location = new System.Drawing.Point(3, 45);
            this.faceRecogRealPlayFLayoutPanel.Name = "faceRecogRealPlayFLayoutPanel";
            this.faceRecogRealPlayFLayoutPanel.Size = new System.Drawing.Size(574, 313);
            this.faceRecogRealPlayFLayoutPanel.TabIndex = 0;
            // 
            // FaceLibraryManagenentTabPage
            // 
            this.FaceLibraryManagenentTabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.FaceLibraryManagenentTabPage.Controls.Add(this.groupBox20);
            this.FaceLibraryManagenentTabPage.Controls.Add(this.groupBox19);
            this.FaceLibraryManagenentTabPage.Location = new System.Drawing.Point(4, 26);
            this.FaceLibraryManagenentTabPage.Name = "FaceLibraryManagenentTabPage";
            this.FaceLibraryManagenentTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.FaceLibraryManagenentTabPage.Size = new System.Drawing.Size(838, 522);
            this.FaceLibraryManagenentTabPage.TabIndex = 0;
            this.FaceLibraryManagenentTabPage.Text = "Face Library Managenent";
            this.FaceLibraryManagenentTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.nextPersonInfoBtn);
            this.groupBox20.Controls.Add(this.previousPersonInfoBtn);
            this.groupBox20.Controls.Add(this.delPersonInfoBtn);
            this.groupBox20.Controls.Add(this.modifyPersonInfoBtn);
            this.groupBox20.Controls.Add(this.addPersonInfoBtn);
            this.groupBox20.Controls.Add(this.findPersonInfoBtn);
            this.groupBox20.Controls.Add(this.groupBox21);
            this.groupBox20.Controls.Add(this.personInfoListView);
            this.groupBox20.Location = new System.Drawing.Point(6, 73);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(826, 443);
            this.groupBox20.TabIndex = 2;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Person Info";
            // 
            // nextPersonInfoBtn
            // 
            this.nextPersonInfoBtn.Location = new System.Drawing.Point(478, 225);
            this.nextPersonInfoBtn.Name = "nextPersonInfoBtn";
            this.nextPersonInfoBtn.Size = new System.Drawing.Size(75, 23);
            this.nextPersonInfoBtn.TabIndex = 23;
            this.nextPersonInfoBtn.Text = "Next";
            this.nextPersonInfoBtn.UseVisualStyleBackColor = true;
            this.nextPersonInfoBtn.Click += new System.EventHandler(this.nextPersonInfoBtn_Click);
            // 
            // previousPersonInfoBtn
            // 
            this.previousPersonInfoBtn.Location = new System.Drawing.Point(385, 225);
            this.previousPersonInfoBtn.Name = "previousPersonInfoBtn";
            this.previousPersonInfoBtn.Size = new System.Drawing.Size(75, 23);
            this.previousPersonInfoBtn.TabIndex = 22;
            this.previousPersonInfoBtn.Text = "Previous";
            this.previousPersonInfoBtn.UseVisualStyleBackColor = true;
            this.previousPersonInfoBtn.Click += new System.EventHandler(this.previousPersonInfoBtn_Click);
            // 
            // delPersonInfoBtn
            // 
            this.delPersonInfoBtn.Location = new System.Drawing.Point(293, 225);
            this.delPersonInfoBtn.Name = "delPersonInfoBtn";
            this.delPersonInfoBtn.Size = new System.Drawing.Size(75, 23);
            this.delPersonInfoBtn.TabIndex = 21;
            this.delPersonInfoBtn.Text = "Delete";
            this.delPersonInfoBtn.UseVisualStyleBackColor = true;
            this.delPersonInfoBtn.Click += new System.EventHandler(this.delPersonInfoBtn_Click);
            // 
            // modifyPersonInfoBtn
            // 
            this.modifyPersonInfoBtn.Location = new System.Drawing.Point(197, 225);
            this.modifyPersonInfoBtn.Name = "modifyPersonInfoBtn";
            this.modifyPersonInfoBtn.Size = new System.Drawing.Size(75, 23);
            this.modifyPersonInfoBtn.TabIndex = 20;
            this.modifyPersonInfoBtn.Text = "Modify";
            this.modifyPersonInfoBtn.UseVisualStyleBackColor = true;
            this.modifyPersonInfoBtn.Click += new System.EventHandler(this.modifyPersonInfoBtn_Click);
            // 
            // addPersonInfoBtn
            // 
            this.addPersonInfoBtn.Location = new System.Drawing.Point(104, 225);
            this.addPersonInfoBtn.Name = "addPersonInfoBtn";
            this.addPersonInfoBtn.Size = new System.Drawing.Size(75, 23);
            this.addPersonInfoBtn.TabIndex = 19;
            this.addPersonInfoBtn.Text = "Add";
            this.addPersonInfoBtn.UseVisualStyleBackColor = true;
            this.addPersonInfoBtn.Click += new System.EventHandler(this.addPersonInfoBtn_Click);
            // 
            // findPersonInfoBtn
            // 
            this.findPersonInfoBtn.Location = new System.Drawing.Point(8, 225);
            this.findPersonInfoBtn.Name = "findPersonInfoBtn";
            this.findPersonInfoBtn.Size = new System.Drawing.Size(75, 23);
            this.findPersonInfoBtn.TabIndex = 18;
            this.findPersonInfoBtn.Text = "Find";
            this.findPersonInfoBtn.UseVisualStyleBackColor = true;
            this.findPersonInfoBtn.Click += new System.EventHandler(this.findPersonInfoBtn_Click);
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.personInfoBirthText);
            this.groupBox21.Controls.Add(this.personInfoImagePictureBox);
            this.groupBox21.Controls.Add(this.personInfoGenderCmb);
            this.groupBox21.Controls.Add(this.personInfoCityText);
            this.groupBox21.Controls.Add(this.personInfoIDNoText);
            this.groupBox21.Controls.Add(this.personInfoCityLab);
            this.groupBox21.Controls.Add(this.personInfoIDNoLab);
            this.groupBox21.Controls.Add(this.personInfoIDTypeCmb);
            this.groupBox21.Controls.Add(this.personInfoNationalityText);
            this.groupBox21.Controls.Add(this.personInfoProvinceText);
            this.groupBox21.Controls.Add(this.personInfoProvinceLab);
            this.groupBox21.Controls.Add(this.personInfoNationalityLab);
            this.groupBox21.Controls.Add(this.personInfoIDTypeLab);
            this.groupBox21.Controls.Add(this.personInfoGenderLab);
            this.groupBox21.Controls.Add(this.personInfoNameText);
            this.groupBox21.Controls.Add(this.personInfoBirthdayLab);
            this.groupBox21.Controls.Add(this.personInfoNameLab);
            this.groupBox21.Location = new System.Drawing.Point(7, 21);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(813, 193);
            this.groupBox21.TabIndex = 17;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "Person Info";
            // 
            // personInfoBirthText
            // 
            this.personInfoBirthText.Location = new System.Drawing.Point(537, 20);
            this.personInfoBirthText.Name = "personInfoBirthText";
            this.personInfoBirthText.Size = new System.Drawing.Size(227, 23);
            this.personInfoBirthText.TabIndex = 38;
            // 
            // personInfoImagePictureBox
            // 
            this.personInfoImagePictureBox.BackColor = System.Drawing.Color.LightGray;
            this.personInfoImagePictureBox.Location = new System.Drawing.Point(17, 21);
            this.personInfoImagePictureBox.Name = "personInfoImagePictureBox";
            this.personInfoImagePictureBox.Size = new System.Drawing.Size(121, 149);
            this.personInfoImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.personInfoImagePictureBox.TabIndex = 37;
            this.personInfoImagePictureBox.TabStop = false;
            this.personInfoImagePictureBox.DoubleClick += new System.EventHandler(this.personInfoImagePictureBox_DoubleClick);
            // 
            // personInfoGenderCmb
            // 
            this.personInfoGenderCmb.FormattingEnabled = true;
            this.personInfoGenderCmb.Items.AddRange(new object[] {
            "Unidentified",
            "Male",
            "Female"});
            this.personInfoGenderCmb.Location = new System.Drawing.Point(215, 57);
            this.personInfoGenderCmb.Name = "personInfoGenderCmb";
            this.personInfoGenderCmb.Size = new System.Drawing.Size(221, 25);
            this.personInfoGenderCmb.TabIndex = 36;
            this.personInfoGenderCmb.Text = "Unidentified";
            // 
            // personInfoCityText
            // 
            this.personInfoCityText.Location = new System.Drawing.Point(537, 129);
            this.personInfoCityText.Name = "personInfoCityText";
            this.personInfoCityText.Size = new System.Drawing.Size(227, 23);
            this.personInfoCityText.TabIndex = 29;
            // 
            // personInfoIDNoText
            // 
            this.personInfoIDNoText.Location = new System.Drawing.Point(214, 129);
            this.personInfoIDNoText.Name = "personInfoIDNoText";
            this.personInfoIDNoText.Size = new System.Drawing.Size(222, 23);
            this.personInfoIDNoText.TabIndex = 28;
            // 
            // personInfoCityLab
            // 
            this.personInfoCityLab.AutoSize = true;
            this.personInfoCityLab.Location = new System.Drawing.Point(449, 132);
            this.personInfoCityLab.Name = "personInfoCityLab";
            this.personInfoCityLab.Size = new System.Drawing.Size(29, 17);
            this.personInfoCityLab.TabIndex = 27;
            this.personInfoCityLab.Text = "City";
            // 
            // personInfoIDNoLab
            // 
            this.personInfoIDNoLab.AutoSize = true;
            this.personInfoIDNoLab.Location = new System.Drawing.Point(151, 132);
            this.personInfoIDNoLab.Name = "personInfoIDNoLab";
            this.personInfoIDNoLab.Size = new System.Drawing.Size(55, 17);
            this.personInfoIDNoLab.TabIndex = 26;
            this.personInfoIDNoLab.Text = "* ID No.";
            // 
            // personInfoIDTypeCmb
            // 
            this.personInfoIDTypeCmb.FormattingEnabled = true;
            this.personInfoIDTypeCmb.Items.AddRange(new object[] {
            "ID Card",
            "IC Card",
            "Passport",
            "Driver\'s License",
            "Other"});
            this.personInfoIDTypeCmb.Location = new System.Drawing.Point(215, 92);
            this.personInfoIDTypeCmb.Name = "personInfoIDTypeCmb";
            this.personInfoIDTypeCmb.Size = new System.Drawing.Size(221, 25);
            this.personInfoIDTypeCmb.TabIndex = 25;
            this.personInfoIDTypeCmb.Text = "ID Card";
            // 
            // personInfoNationalityText
            // 
            this.personInfoNationalityText.Location = new System.Drawing.Point(537, 62);
            this.personInfoNationalityText.Name = "personInfoNationalityText";
            this.personInfoNationalityText.Size = new System.Drawing.Size(227, 23);
            this.personInfoNationalityText.TabIndex = 24;
            // 
            // personInfoProvinceText
            // 
            this.personInfoProvinceText.Location = new System.Drawing.Point(537, 95);
            this.personInfoProvinceText.Name = "personInfoProvinceText";
            this.personInfoProvinceText.Size = new System.Drawing.Size(227, 23);
            this.personInfoProvinceText.TabIndex = 23;
            // 
            // personInfoProvinceLab
            // 
            this.personInfoProvinceLab.AutoSize = true;
            this.personInfoProvinceLab.Location = new System.Drawing.Point(449, 98);
            this.personInfoProvinceLab.Name = "personInfoProvinceLab";
            this.personInfoProvinceLab.Size = new System.Drawing.Size(57, 17);
            this.personInfoProvinceLab.TabIndex = 22;
            this.personInfoProvinceLab.Text = "Province";
            // 
            // personInfoNationalityLab
            // 
            this.personInfoNationalityLab.AutoSize = true;
            this.personInfoNationalityLab.Location = new System.Drawing.Point(451, 65);
            this.personInfoNationalityLab.Name = "personInfoNationalityLab";
            this.personInfoNationalityLab.Size = new System.Drawing.Size(70, 17);
            this.personInfoNationalityLab.TabIndex = 21;
            this.personInfoNationalityLab.Text = "Nationality";
            // 
            // personInfoIDTypeLab
            // 
            this.personInfoIDTypeLab.AutoSize = true;
            this.personInfoIDTypeLab.Location = new System.Drawing.Point(151, 98);
            this.personInfoIDTypeLab.Name = "personInfoIDTypeLab";
            this.personInfoIDTypeLab.Size = new System.Drawing.Size(62, 17);
            this.personInfoIDTypeLab.TabIndex = 20;
            this.personInfoIDTypeLab.Text = "* ID Type";
            // 
            // personInfoGenderLab
            // 
            this.personInfoGenderLab.AutoSize = true;
            this.personInfoGenderLab.Location = new System.Drawing.Point(151, 66);
            this.personInfoGenderLab.Name = "personInfoGenderLab";
            this.personInfoGenderLab.Size = new System.Drawing.Size(51, 17);
            this.personInfoGenderLab.TabIndex = 19;
            this.personInfoGenderLab.Text = "Gender";
            // 
            // personInfoNameText
            // 
            this.personInfoNameText.Location = new System.Drawing.Point(215, 20);
            this.personInfoNameText.Name = "personInfoNameText";
            this.personInfoNameText.Size = new System.Drawing.Size(221, 23);
            this.personInfoNameText.TabIndex = 17;
            // 
            // personInfoBirthdayLab
            // 
            this.personInfoBirthdayLab.AutoSize = true;
            this.personInfoBirthdayLab.Location = new System.Drawing.Point(449, 21);
            this.personInfoBirthdayLab.Name = "personInfoBirthdayLab";
            this.personInfoBirthdayLab.Size = new System.Drawing.Size(82, 17);
            this.personInfoBirthdayLab.TabIndex = 16;
            this.personInfoBirthdayLab.Text = "Date of Birth";
            // 
            // personInfoNameLab
            // 
            this.personInfoNameLab.AutoSize = true;
            this.personInfoNameLab.Location = new System.Drawing.Point(151, 21);
            this.personInfoNameLab.Name = "personInfoNameLab";
            this.personInfoNameLab.Size = new System.Drawing.Size(52, 17);
            this.personInfoNameLab.TabIndex = 15;
            this.personInfoNameLab.Text = "* Name";
            // 
            // personInfoListView
            // 
            this.personInfoListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.personInfoIDColHeader,
            this.PersonName,
            this.PersonGender,
            this.PersonDateOfBirth,
            this.PersonNationality,
            this.PersonProvince,
            this.PersonCity,
            this.PersonIDType,
            this.PersonIDNo});
            this.personInfoListView.FullRowSelect = true;
            this.personInfoListView.GridLines = true;
            this.personInfoListView.Location = new System.Drawing.Point(7, 261);
            this.personInfoListView.MultiSelect = false;
            this.personInfoListView.Name = "personInfoListView";
            this.personInfoListView.Size = new System.Drawing.Size(813, 176);
            this.personInfoListView.TabIndex = 16;
            this.personInfoListView.UseCompatibleStateImageBehavior = false;
            this.personInfoListView.View = System.Windows.Forms.View.Details;
            this.personInfoListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.personInfoListView_ItemSelectionChanged);
            // 
            // personInfoIDColHeader
            // 
            this.personInfoIDColHeader.Text = "ID";
            // 
            // PersonName
            // 
            this.PersonName.Text = "Name";
            this.PersonName.Width = 100;
            // 
            // PersonGender
            // 
            this.PersonGender.Text = "Gender";
            this.PersonGender.Width = 80;
            // 
            // PersonDateOfBirth
            // 
            this.PersonDateOfBirth.Text = "Date of Birth";
            this.PersonDateOfBirth.Width = 100;
            // 
            // PersonNationality
            // 
            this.PersonNationality.Text = "Nationality";
            this.PersonNationality.Width = 100;
            // 
            // PersonProvince
            // 
            this.PersonProvince.Text = "Province";
            this.PersonProvince.Width = 100;
            // 
            // PersonCity
            // 
            this.PersonCity.Text = "City";
            this.PersonCity.Width = 100;
            // 
            // PersonIDType
            // 
            this.PersonIDType.Text = "ID Type";
            this.PersonIDType.Width = 100;
            // 
            // PersonIDNo
            // 
            this.PersonIDNo.Text = "IDNo.";
            this.PersonIDNo.Width = 70;
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.PersonLibNameText);
            this.groupBox19.Controls.Add(this.personLibCmb);
            this.groupBox19.Controls.Add(this.delPersonLibBtn);
            this.groupBox19.Controls.Add(this.modifyPersonLibBtn);
            this.groupBox19.Controls.Add(this.addPersonLibBtn);
            this.groupBox19.Controls.Add(this.findPersonLibBtn);
            this.groupBox19.Location = new System.Drawing.Point(5, 7);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(826, 63);
            this.groupBox19.TabIndex = 1;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Person Lib";
            // 
            // PersonLibNameText
            // 
            this.PersonLibNameText.Location = new System.Drawing.Point(152, 23);
            this.PersonLibNameText.Name = "PersonLibNameText";
            this.PersonLibNameText.Size = new System.Drawing.Size(132, 23);
            this.PersonLibNameText.TabIndex = 5;
            // 
            // personLibCmb
            // 
            this.personLibCmb.FormattingEnabled = true;
            this.personLibCmb.Location = new System.Drawing.Point(25, 23);
            this.personLibCmb.Name = "personLibCmb";
            this.personLibCmb.Size = new System.Drawing.Size(121, 25);
            this.personLibCmb.TabIndex = 4;
            this.personLibCmb.SelectedIndexChanged += new System.EventHandler(this.personLibCmb_SelectedIndexChanged);
            // 
            // delPersonLibBtn
            // 
            this.delPersonLibBtn.Location = new System.Drawing.Point(575, 22);
            this.delPersonLibBtn.Name = "delPersonLibBtn";
            this.delPersonLibBtn.Size = new System.Drawing.Size(75, 23);
            this.delPersonLibBtn.TabIndex = 3;
            this.delPersonLibBtn.Text = "Delete";
            this.delPersonLibBtn.UseVisualStyleBackColor = true;
            this.delPersonLibBtn.Click += new System.EventHandler(this.delPersonLibBtn_Click);
            // 
            // modifyPersonLibBtn
            // 
            this.modifyPersonLibBtn.Location = new System.Drawing.Point(479, 22);
            this.modifyPersonLibBtn.Name = "modifyPersonLibBtn";
            this.modifyPersonLibBtn.Size = new System.Drawing.Size(75, 23);
            this.modifyPersonLibBtn.TabIndex = 2;
            this.modifyPersonLibBtn.Text = "Modify";
            this.modifyPersonLibBtn.UseVisualStyleBackColor = true;
            this.modifyPersonLibBtn.Click += new System.EventHandler(this.modifyPersonLibBtn_Click);
            // 
            // addPersonLibBtn
            // 
            this.addPersonLibBtn.Location = new System.Drawing.Point(386, 22);
            this.addPersonLibBtn.Name = "addPersonLibBtn";
            this.addPersonLibBtn.Size = new System.Drawing.Size(75, 23);
            this.addPersonLibBtn.TabIndex = 1;
            this.addPersonLibBtn.Text = "Add";
            this.addPersonLibBtn.UseVisualStyleBackColor = true;
            this.addPersonLibBtn.Click += new System.EventHandler(this.addPersonLibBtn_Click);
            // 
            // findPersonLibBtn
            // 
            this.findPersonLibBtn.Location = new System.Drawing.Point(290, 22);
            this.findPersonLibBtn.Name = "findPersonLibBtn";
            this.findPersonLibBtn.Size = new System.Drawing.Size(75, 23);
            this.findPersonLibBtn.TabIndex = 0;
            this.findPersonLibBtn.Text = "Find";
            this.findPersonLibBtn.UseVisualStyleBackColor = true;
            this.findPersonLibBtn.Click += new System.EventHandler(this.findPersonLibBtn_Click);
            // 
            // FaceMonitoringTaskTabPage
            // 
            this.FaceMonitoringTaskTabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.FaceMonitoringTaskTabPage.Controls.Add(this.faceMonitorTaskLibNameText);
            this.FaceMonitoringTaskTabPage.Controls.Add(this.disableFaceMonitorBtn);
            this.FaceMonitoringTaskTabPage.Controls.Add(this.enableFaceMonitorBtn);
            this.FaceMonitoringTaskTabPage.Controls.Add(this.delFaceMonitorBtn);
            this.FaceMonitoringTaskTabPage.Controls.Add(this.modifyFaceMonitorBtn);
            this.FaceMonitoringTaskTabPage.Controls.Add(this.FindFaceMonitorBtn);
            this.FaceMonitoringTaskTabPage.Controls.Add(this.faceMonitorInfoListView);
            this.FaceMonitoringTaskTabPage.Controls.Add(this.addFaceMonitorBtn);
            this.FaceMonitoringTaskTabPage.Controls.Add(this.faceMonitorThresholdTextBox);
            this.FaceMonitoringTaskTabPage.Controls.Add(this.label84);
            this.FaceMonitoringTaskTabPage.Controls.Add(this.faceMonitorObjectCmbBox);
            this.FaceMonitoringTaskTabPage.Controls.Add(this.faceMonitorTypeCmbBox);
            this.FaceMonitoringTaskTabPage.Controls.Add(this.faceMonitorRemarksTextBox);
            this.FaceMonitoringTaskTabPage.Controls.Add(this.faceMonitorTaskNameTextBox);
            this.FaceMonitoringTaskTabPage.Controls.Add(this.faceMonitorTaskObjectLab);
            this.FaceMonitoringTaskTabPage.Controls.Add(this.faceMonitorTaskRemarksLab);
            this.FaceMonitoringTaskTabPage.Controls.Add(this.faceMonitorTaskTypeLab);
            this.FaceMonitoringTaskTabPage.Controls.Add(this.faceMonitorTaskNameLab);
            this.FaceMonitoringTaskTabPage.Location = new System.Drawing.Point(4, 26);
            this.FaceMonitoringTaskTabPage.Name = "FaceMonitoringTaskTabPage";
            this.FaceMonitoringTaskTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.FaceMonitoringTaskTabPage.Size = new System.Drawing.Size(838, 522);
            this.FaceMonitoringTaskTabPage.TabIndex = 1;
            this.FaceMonitoringTaskTabPage.Text = "Monitoring Task";
            this.FaceMonitoringTaskTabPage.UseVisualStyleBackColor = true;
            // 
            // faceMonitorTaskLibNameText
            // 
            this.faceMonitorTaskLibNameText.Location = new System.Drawing.Point(222, 77);
            this.faceMonitorTaskLibNameText.Name = "faceMonitorTaskLibNameText";
            this.faceMonitorTaskLibNameText.ReadOnly = true;
            this.faceMonitorTaskLibNameText.Size = new System.Drawing.Size(147, 23);
            this.faceMonitorTaskLibNameText.TabIndex = 16;
            // 
            // disableFaceMonitorBtn
            // 
            this.disableFaceMonitorBtn.Location = new System.Drawing.Point(507, 117);
            this.disableFaceMonitorBtn.Name = "disableFaceMonitorBtn";
            this.disableFaceMonitorBtn.Size = new System.Drawing.Size(75, 23);
            this.disableFaceMonitorBtn.TabIndex = 15;
            this.disableFaceMonitorBtn.Text = "Disable";
            this.disableFaceMonitorBtn.UseVisualStyleBackColor = true;
            this.disableFaceMonitorBtn.Click += new System.EventHandler(this.disableFaceMonitorBtn_Click);
            // 
            // enableFaceMonitorBtn
            // 
            this.enableFaceMonitorBtn.Location = new System.Drawing.Point(409, 117);
            this.enableFaceMonitorBtn.Name = "enableFaceMonitorBtn";
            this.enableFaceMonitorBtn.Size = new System.Drawing.Size(75, 23);
            this.enableFaceMonitorBtn.TabIndex = 15;
            this.enableFaceMonitorBtn.Text = "Enable";
            this.enableFaceMonitorBtn.UseVisualStyleBackColor = true;
            this.enableFaceMonitorBtn.Click += new System.EventHandler(this.enableFaceMonitorBtn_Click);
            // 
            // delFaceMonitorBtn
            // 
            this.delFaceMonitorBtn.Location = new System.Drawing.Point(317, 117);
            this.delFaceMonitorBtn.Name = "delFaceMonitorBtn";
            this.delFaceMonitorBtn.Size = new System.Drawing.Size(75, 23);
            this.delFaceMonitorBtn.TabIndex = 14;
            this.delFaceMonitorBtn.Text = "Delete";
            this.delFaceMonitorBtn.UseVisualStyleBackColor = true;
            this.delFaceMonitorBtn.Click += new System.EventHandler(this.delFaceMonitorBtn_Click);
            // 
            // modifyFaceMonitorBtn
            // 
            this.modifyFaceMonitorBtn.Location = new System.Drawing.Point(222, 117);
            this.modifyFaceMonitorBtn.Name = "modifyFaceMonitorBtn";
            this.modifyFaceMonitorBtn.Size = new System.Drawing.Size(75, 23);
            this.modifyFaceMonitorBtn.TabIndex = 13;
            this.modifyFaceMonitorBtn.Text = "Modify";
            this.modifyFaceMonitorBtn.UseVisualStyleBackColor = true;
            this.modifyFaceMonitorBtn.Click += new System.EventHandler(this.modifyFaceMonitorBtn_Click);
            // 
            // FindFaceMonitorBtn
            // 
            this.FindFaceMonitorBtn.Location = new System.Drawing.Point(21, 117);
            this.FindFaceMonitorBtn.Name = "FindFaceMonitorBtn";
            this.FindFaceMonitorBtn.Size = new System.Drawing.Size(75, 23);
            this.FindFaceMonitorBtn.TabIndex = 12;
            this.FindFaceMonitorBtn.Text = "Find";
            this.FindFaceMonitorBtn.UseVisualStyleBackColor = true;
            this.FindFaceMonitorBtn.Click += new System.EventHandler(this.FindFaceMonitorBtn_Click);
            // 
            // faceMonitorInfoListView
            // 
            this.faceMonitorInfoListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LPRmonitorTaskIDColHeader,
            this.LPRmonitorTaskNameColHeader,
            this.LPRmonitorTaskRemarksColHeader,
            this.LPRmonitorThresholdColHeader,
            this.LPRmonitorObjectColHeader,
            this.LPRmonitorStatusColHeader});
            this.faceMonitorInfoListView.FullRowSelect = true;
            this.faceMonitorInfoListView.GridLines = true;
            this.faceMonitorInfoListView.Location = new System.Drawing.Point(21, 150);
            this.faceMonitorInfoListView.MultiSelect = false;
            this.faceMonitorInfoListView.Name = "faceMonitorInfoListView";
            this.faceMonitorInfoListView.Size = new System.Drawing.Size(800, 133);
            this.faceMonitorInfoListView.TabIndex = 11;
            this.faceMonitorInfoListView.UseCompatibleStateImageBehavior = false;
            this.faceMonitorInfoListView.View = System.Windows.Forms.View.Details;
            this.faceMonitorInfoListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.faceMonitorInfoListView_ItemSelectionChanged);
            // 
            // LPRmonitorTaskIDColHeader
            // 
            this.LPRmonitorTaskIDColHeader.Text = "ID";
            // 
            // LPRmonitorTaskNameColHeader
            // 
            this.LPRmonitorTaskNameColHeader.Text = "Task Name";
            this.LPRmonitorTaskNameColHeader.Width = 120;
            // 
            // LPRmonitorTaskRemarksColHeader
            // 
            this.LPRmonitorTaskRemarksColHeader.Text = "Remarks";
            this.LPRmonitorTaskRemarksColHeader.Width = 120;
            // 
            // LPRmonitorThresholdColHeader
            // 
            this.LPRmonitorThresholdColHeader.Text = "Alarm Threshold";
            this.LPRmonitorThresholdColHeader.Width = 120;
            // 
            // LPRmonitorObjectColHeader
            // 
            this.LPRmonitorObjectColHeader.Text = "Monitoring Object";
            this.LPRmonitorObjectColHeader.Width = 120;
            // 
            // LPRmonitorStatusColHeader
            // 
            this.LPRmonitorStatusColHeader.Text = "Status";
            this.LPRmonitorStatusColHeader.Width = 120;
            // 
            // addFaceMonitorBtn
            // 
            this.addFaceMonitorBtn.Location = new System.Drawing.Point(122, 117);
            this.addFaceMonitorBtn.Name = "addFaceMonitorBtn";
            this.addFaceMonitorBtn.Size = new System.Drawing.Size(75, 23);
            this.addFaceMonitorBtn.TabIndex = 10;
            this.addFaceMonitorBtn.Text = "Add";
            this.addFaceMonitorBtn.UseVisualStyleBackColor = true;
            this.addFaceMonitorBtn.Click += new System.EventHandler(this.addFaceMonitorBtn_Click);
            // 
            // faceMonitorThresholdTextBox
            // 
            this.faceMonitorThresholdTextBox.Location = new System.Drawing.Point(532, 12);
            this.faceMonitorThresholdTextBox.Name = "faceMonitorThresholdTextBox";
            this.faceMonitorThresholdTextBox.Size = new System.Drawing.Size(215, 23);
            this.faceMonitorThresholdTextBox.TabIndex = 9;
            this.faceMonitorThresholdTextBox.Text = "80";
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(396, 12);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(104, 17);
            this.label84.TabIndex = 8;
            this.label84.Text = "Alarm Threshold";
            // 
            // faceMonitorObjectCmbBox
            // 
            this.faceMonitorObjectCmbBox.FormattingEnabled = true;
            this.faceMonitorObjectCmbBox.Location = new System.Drawing.Point(154, 77);
            this.faceMonitorObjectCmbBox.Name = "faceMonitorObjectCmbBox";
            this.faceMonitorObjectCmbBox.Size = new System.Drawing.Size(60, 25);
            this.faceMonitorObjectCmbBox.TabIndex = 7;
            this.faceMonitorObjectCmbBox.SelectedIndexChanged += new System.EventHandler(this.faceMonitorObjectCmbBox_SelectedIndexChanged);
            // 
            // faceMonitorTypeCmbBox
            // 
            this.faceMonitorTypeCmbBox.FormattingEnabled = true;
            this.faceMonitorTypeCmbBox.Items.AddRange(new object[] {
            "Match Alarm",
            "Not Match  Alarm",
            "All"});
            this.faceMonitorTypeCmbBox.Location = new System.Drawing.Point(154, 42);
            this.faceMonitorTypeCmbBox.Name = "faceMonitorTypeCmbBox";
            this.faceMonitorTypeCmbBox.Size = new System.Drawing.Size(215, 25);
            this.faceMonitorTypeCmbBox.TabIndex = 6;
            this.faceMonitorTypeCmbBox.Text = "Match Alarm";
            // 
            // faceMonitorRemarksTextBox
            // 
            this.faceMonitorRemarksTextBox.Location = new System.Drawing.Point(532, 42);
            this.faceMonitorRemarksTextBox.Name = "faceMonitorRemarksTextBox";
            this.faceMonitorRemarksTextBox.Size = new System.Drawing.Size(215, 23);
            this.faceMonitorRemarksTextBox.TabIndex = 5;
            // 
            // faceMonitorTaskNameTextBox
            // 
            this.faceMonitorTaskNameTextBox.Location = new System.Drawing.Point(154, 9);
            this.faceMonitorTaskNameTextBox.Name = "faceMonitorTaskNameTextBox";
            this.faceMonitorTaskNameTextBox.Size = new System.Drawing.Size(215, 23);
            this.faceMonitorTaskNameTextBox.TabIndex = 4;
            // 
            // faceMonitorTaskObjectLab
            // 
            this.faceMonitorTaskObjectLab.AutoSize = true;
            this.faceMonitorTaskObjectLab.Location = new System.Drawing.Point(18, 85);
            this.faceMonitorTaskObjectLab.Name = "faceMonitorTaskObjectLab";
            this.faceMonitorTaskObjectLab.Size = new System.Drawing.Size(124, 17);
            this.faceMonitorTaskObjectLab.TabIndex = 3;
            this.faceMonitorTaskObjectLab.Text = "* Monitoring Object";
            // 
            // faceMonitorTaskRemarksLab
            // 
            this.faceMonitorTaskRemarksLab.AutoSize = true;
            this.faceMonitorTaskRemarksLab.Location = new System.Drawing.Point(396, 48);
            this.faceMonitorTaskRemarksLab.Name = "faceMonitorTaskRemarksLab";
            this.faceMonitorTaskRemarksLab.Size = new System.Drawing.Size(59, 17);
            this.faceMonitorTaskRemarksLab.TabIndex = 2;
            this.faceMonitorTaskRemarksLab.Text = "Remarks";
            // 
            // faceMonitorTaskTypeLab
            // 
            this.faceMonitorTaskTypeLab.AutoSize = true;
            this.faceMonitorTaskTypeLab.Location = new System.Drawing.Point(18, 50);
            this.faceMonitorTaskTypeLab.Name = "faceMonitorTaskTypeLab";
            this.faceMonitorTaskTypeLab.Size = new System.Drawing.Size(114, 17);
            this.faceMonitorTaskTypeLab.TabIndex = 1;
            this.faceMonitorTaskTypeLab.Text = "* Monitoring Type";
            // 
            // faceMonitorTaskNameLab
            // 
            this.faceMonitorTaskNameLab.AutoSize = true;
            this.faceMonitorTaskNameLab.Location = new System.Drawing.Point(18, 12);
            this.faceMonitorTaskNameLab.Name = "faceMonitorTaskNameLab";
            this.faceMonitorTaskNameLab.Size = new System.Drawing.Size(83, 17);
            this.faceMonitorTaskNameLab.TabIndex = 0;
            this.faceMonitorTaskNameLab.Text = "* Task Name";
            // 
            // FaceAlarmRecordTabPage
            // 
            this.FaceAlarmRecordTabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.FaceAlarmRecordTabPage.Controls.Add(this.faceAlarmRecordNextBtn);
            this.FaceAlarmRecordTabPage.Controls.Add(this.faceAlarmRecordPreviousBtn);
            this.FaceAlarmRecordTabPage.Controls.Add(this.faceAlarmRecordSearchBtn);
            this.FaceAlarmRecordTabPage.Controls.Add(this.faceAlarmRecordMonitorTypeCmbBox);
            this.FaceAlarmRecordTabPage.Controls.Add(this.label100);
            this.FaceAlarmRecordTabPage.Controls.Add(this.faceAlarmRecordEndTimeDT);
            this.FaceAlarmRecordTabPage.Controls.Add(this.faceAlarmRecordBeginTimeDT);
            this.FaceAlarmRecordTabPage.Controls.Add(this.label99);
            this.FaceAlarmRecordTabPage.Controls.Add(this.label96);
            this.FaceAlarmRecordTabPage.Controls.Add(this.faceAlarmRecordDataGridView);
            this.FaceAlarmRecordTabPage.Location = new System.Drawing.Point(4, 26);
            this.FaceAlarmRecordTabPage.Name = "FaceAlarmRecordTabPage";
            this.FaceAlarmRecordTabPage.Size = new System.Drawing.Size(838, 522);
            this.FaceAlarmRecordTabPage.TabIndex = 3;
            this.FaceAlarmRecordTabPage.Text = "Alarm Records";
            this.FaceAlarmRecordTabPage.UseVisualStyleBackColor = true;
            // 
            // faceAlarmRecordNextBtn
            // 
            this.faceAlarmRecordNextBtn.Location = new System.Drawing.Point(789, 16);
            this.faceAlarmRecordNextBtn.Name = "faceAlarmRecordNextBtn";
            this.faceAlarmRecordNextBtn.Size = new System.Drawing.Size(46, 23);
            this.faceAlarmRecordNextBtn.TabIndex = 9;
            this.faceAlarmRecordNextBtn.Text = "Next";
            this.faceAlarmRecordNextBtn.UseVisualStyleBackColor = true;
            this.faceAlarmRecordNextBtn.Click += new System.EventHandler(this.faceAlarmRecordNextBtn_Click);
            // 
            // faceAlarmRecordPreviousBtn
            // 
            this.faceAlarmRecordPreviousBtn.Location = new System.Drawing.Point(713, 16);
            this.faceAlarmRecordPreviousBtn.Name = "faceAlarmRecordPreviousBtn";
            this.faceAlarmRecordPreviousBtn.Size = new System.Drawing.Size(75, 23);
            this.faceAlarmRecordPreviousBtn.TabIndex = 8;
            this.faceAlarmRecordPreviousBtn.Text = "Previous";
            this.faceAlarmRecordPreviousBtn.UseVisualStyleBackColor = true;
            this.faceAlarmRecordPreviousBtn.Click += new System.EventHandler(this.faceAlarmRecordPreviousBtn_Click);
            // 
            // faceAlarmRecordSearchBtn
            // 
            this.faceAlarmRecordSearchBtn.Location = new System.Drawing.Point(651, 16);
            this.faceAlarmRecordSearchBtn.Name = "faceAlarmRecordSearchBtn";
            this.faceAlarmRecordSearchBtn.Size = new System.Drawing.Size(59, 23);
            this.faceAlarmRecordSearchBtn.TabIndex = 7;
            this.faceAlarmRecordSearchBtn.Text = "Search";
            this.faceAlarmRecordSearchBtn.UseVisualStyleBackColor = true;
            this.faceAlarmRecordSearchBtn.Click += new System.EventHandler(this.faceAlarmRecordSearchBtn_Click);
            // 
            // faceAlarmRecordMonitorTypeCmbBox
            // 
            this.faceAlarmRecordMonitorTypeCmbBox.FormattingEnabled = true;
            this.faceAlarmRecordMonitorTypeCmbBox.Items.AddRange(new object[] {
            "Match Alarm",
            "Not Match Alarm"});
            this.faceAlarmRecordMonitorTypeCmbBox.Location = new System.Drawing.Point(118, 16);
            this.faceAlarmRecordMonitorTypeCmbBox.Name = "faceAlarmRecordMonitorTypeCmbBox";
            this.faceAlarmRecordMonitorTypeCmbBox.Size = new System.Drawing.Size(121, 25);
            this.faceAlarmRecordMonitorTypeCmbBox.TabIndex = 6;
            this.faceAlarmRecordMonitorTypeCmbBox.Text = "Match Alarm";
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Location = new System.Drawing.Point(473, 19);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(17, 17);
            this.label100.TabIndex = 5;
            this.label100.Text = "~";
            // 
            // faceAlarmRecordEndTimeDT
            // 
            this.faceAlarmRecordEndTimeDT.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.faceAlarmRecordEndTimeDT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.faceAlarmRecordEndTimeDT.Location = new System.Drawing.Point(493, 17);
            this.faceAlarmRecordEndTimeDT.Name = "faceAlarmRecordEndTimeDT";
            this.faceAlarmRecordEndTimeDT.Size = new System.Drawing.Size(156, 23);
            this.faceAlarmRecordEndTimeDT.TabIndex = 4;
            // 
            // faceAlarmRecordBeginTimeDT
            // 
            this.faceAlarmRecordBeginTimeDT.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.faceAlarmRecordBeginTimeDT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.faceAlarmRecordBeginTimeDT.Location = new System.Drawing.Point(314, 16);
            this.faceAlarmRecordBeginTimeDT.Name = "faceAlarmRecordBeginTimeDT";
            this.faceAlarmRecordBeginTimeDT.Size = new System.Drawing.Size(159, 23);
            this.faceAlarmRecordBeginTimeDT.TabIndex = 3;
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Location = new System.Drawing.Point(244, 19);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(74, 17);
            this.label99.TabIndex = 2;
            this.label99.Text = "Alarm Time";
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.Location = new System.Drawing.Point(8, 19);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(105, 17);
            this.label96.TabIndex = 1;
            this.label96.Text = "Monitoring Type";
            // 
            // faceAlarmRecordDataGridView
            // 
            this.faceAlarmRecordDataGridView.AllowUserToAddRows = false;
            this.faceAlarmRecordDataGridView.AllowUserToDeleteRows = false;
            this.faceAlarmRecordDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.faceAlarmRecordDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.faceAlarmRecordDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.faceAlarmRecordSnapImageDataGVImgCol,
            this.faceAlarmRecordLibImageDataGVImgCol,
            this.faceAlarmRecordTimeDataGVTextCol,
            this.faceAlarmRecordSourceDataGVTextCol,
            this.faceAlarmRecordNameDataGVTextCol,
            this.faceAlarmRecordIDNoDataGVTextCol,
            this.faceAlarmRecordMatchDataGVTextCol});
            this.faceAlarmRecordDataGridView.Location = new System.Drawing.Point(3, 50);
            this.faceAlarmRecordDataGridView.MultiSelect = false;
            this.faceAlarmRecordDataGridView.Name = "faceAlarmRecordDataGridView";
            this.faceAlarmRecordDataGridView.RowHeadersVisible = false;
            this.faceAlarmRecordDataGridView.RowTemplate.Height = 100;
            this.faceAlarmRecordDataGridView.RowTemplate.ReadOnly = true;
            this.faceAlarmRecordDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.faceAlarmRecordDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.faceAlarmRecordDataGridView.Size = new System.Drawing.Size(832, 469);
            this.faceAlarmRecordDataGridView.TabIndex = 0;
            // 
            // faceAlarmRecordSnapImageDataGVImgCol
            // 
            this.faceAlarmRecordSnapImageDataGVImgCol.HeaderText = "Snapshot Image";
            this.faceAlarmRecordSnapImageDataGVImgCol.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.faceAlarmRecordSnapImageDataGVImgCol.Name = "faceAlarmRecordSnapImageDataGVImgCol";
            this.faceAlarmRecordSnapImageDataGVImgCol.ReadOnly = true;
            // 
            // faceAlarmRecordLibImageDataGVImgCol
            // 
            this.faceAlarmRecordLibImageDataGVImgCol.HeaderText = "lib Image";
            this.faceAlarmRecordLibImageDataGVImgCol.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.faceAlarmRecordLibImageDataGVImgCol.Name = "faceAlarmRecordLibImageDataGVImgCol";
            this.faceAlarmRecordLibImageDataGVImgCol.ReadOnly = true;
            // 
            // faceAlarmRecordTimeDataGVTextCol
            // 
            this.faceAlarmRecordTimeDataGVTextCol.HeaderText = "Time";
            this.faceAlarmRecordTimeDataGVTextCol.Name = "faceAlarmRecordTimeDataGVTextCol";
            this.faceAlarmRecordTimeDataGVTextCol.ReadOnly = true;
            this.faceAlarmRecordTimeDataGVTextCol.Width = 150;
            // 
            // faceAlarmRecordSourceDataGVTextCol
            // 
            this.faceAlarmRecordSourceDataGVTextCol.HeaderText = "Alarm Source";
            this.faceAlarmRecordSourceDataGVTextCol.Name = "faceAlarmRecordSourceDataGVTextCol";
            this.faceAlarmRecordSourceDataGVTextCol.ReadOnly = true;
            this.faceAlarmRecordSourceDataGVTextCol.Width = 180;
            // 
            // faceAlarmRecordNameDataGVTextCol
            // 
            this.faceAlarmRecordNameDataGVTextCol.HeaderText = "Name";
            this.faceAlarmRecordNameDataGVTextCol.Name = "faceAlarmRecordNameDataGVTextCol";
            this.faceAlarmRecordNameDataGVTextCol.ReadOnly = true;
            // 
            // faceAlarmRecordIDNoDataGVTextCol
            // 
            this.faceAlarmRecordIDNoDataGVTextCol.HeaderText = "ID No.";
            this.faceAlarmRecordIDNoDataGVTextCol.Name = "faceAlarmRecordIDNoDataGVTextCol";
            this.faceAlarmRecordIDNoDataGVTextCol.ReadOnly = true;
            // 
            // faceAlarmRecordMatchDataGVTextCol
            // 
            this.faceAlarmRecordMatchDataGVTextCol.HeaderText = "Match";
            this.faceAlarmRecordMatchDataGVTextCol.Name = "faceAlarmRecordMatchDataGVTextCol";
            this.faceAlarmRecordMatchDataGVTextCol.ReadOnly = true;
            this.faceAlarmRecordMatchDataGVTextCol.Width = 80;
            // 
            // FacePassThruRecordTabPage
            // 
            this.FacePassThruRecordTabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.FacePassThruRecordTabPage.Controls.Add(this.facePassThruRecordAlarmSourceText);
            this.FacePassThruRecordTabPage.Controls.Add(this.label103);
            this.FacePassThruRecordTabPage.Controls.Add(this.facePassThruRecordNextBtn);
            this.FacePassThruRecordTabPage.Controls.Add(this.facePassThruRecordPreviousBtn);
            this.FacePassThruRecordTabPage.Controls.Add(this.facePassThruRecordSearchBtn);
            this.FacePassThruRecordTabPage.Controls.Add(this.label101);
            this.FacePassThruRecordTabPage.Controls.Add(this.facePassThruRecordEndTimeDT);
            this.FacePassThruRecordTabPage.Controls.Add(this.facePassThruRecordBeginTimeDT);
            this.FacePassThruRecordTabPage.Controls.Add(this.label102);
            this.FacePassThruRecordTabPage.Controls.Add(this.facePassThruRecordDataGridView);
            this.FacePassThruRecordTabPage.Location = new System.Drawing.Point(4, 26);
            this.FacePassThruRecordTabPage.Name = "FacePassThruRecordTabPage";
            this.FacePassThruRecordTabPage.Size = new System.Drawing.Size(838, 522);
            this.FacePassThruRecordTabPage.TabIndex = 4;
            this.FacePassThruRecordTabPage.Text = "Pass-Thru Records";
            // 
            // facePassThruRecordAlarmSourceText
            // 
            this.facePassThruRecordAlarmSourceText.Location = new System.Drawing.Point(510, 11);
            this.facePassThruRecordAlarmSourceText.Name = "facePassThruRecordAlarmSourceText";
            this.facePassThruRecordAlarmSourceText.Size = new System.Drawing.Size(125, 23);
            this.facePassThruRecordAlarmSourceText.TabIndex = 19;
            // 
            // label103
            // 
            this.label103.AutoSize = true;
            this.label103.Location = new System.Drawing.Point(423, 13);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(86, 17);
            this.label103.TabIndex = 18;
            this.label103.Text = "Alarm Source";
            // 
            // facePassThruRecordNextBtn
            // 
            this.facePassThruRecordNextBtn.Location = new System.Drawing.Point(789, 10);
            this.facePassThruRecordNextBtn.Name = "facePassThruRecordNextBtn";
            this.facePassThruRecordNextBtn.Size = new System.Drawing.Size(46, 23);
            this.facePassThruRecordNextBtn.TabIndex = 17;
            this.facePassThruRecordNextBtn.Text = "Next";
            this.facePassThruRecordNextBtn.UseVisualStyleBackColor = true;
            this.facePassThruRecordNextBtn.Click += new System.EventHandler(this.facePassThruRecordNextBtn_Click);
            // 
            // facePassThruRecordPreviousBtn
            // 
            this.facePassThruRecordPreviousBtn.Location = new System.Drawing.Point(713, 10);
            this.facePassThruRecordPreviousBtn.Name = "facePassThruRecordPreviousBtn";
            this.facePassThruRecordPreviousBtn.Size = new System.Drawing.Size(75, 23);
            this.facePassThruRecordPreviousBtn.TabIndex = 16;
            this.facePassThruRecordPreviousBtn.Text = "Previous";
            this.facePassThruRecordPreviousBtn.UseVisualStyleBackColor = true;
            this.facePassThruRecordPreviousBtn.Click += new System.EventHandler(this.facePassThruRecordPreviousBtn_Click);
            // 
            // facePassThruRecordSearchBtn
            // 
            this.facePassThruRecordSearchBtn.Location = new System.Drawing.Point(651, 10);
            this.facePassThruRecordSearchBtn.Name = "facePassThruRecordSearchBtn";
            this.facePassThruRecordSearchBtn.Size = new System.Drawing.Size(59, 23);
            this.facePassThruRecordSearchBtn.TabIndex = 15;
            this.facePassThruRecordSearchBtn.Text = "Search";
            this.facePassThruRecordSearchBtn.UseVisualStyleBackColor = true;
            this.facePassThruRecordSearchBtn.Click += new System.EventHandler(this.facePassThruRecordSearchBtn_Click);
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.Location = new System.Drawing.Point(241, 13);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(17, 17);
            this.label101.TabIndex = 14;
            this.label101.Text = "~";
            // 
            // facePassThruRecordEndTimeDT
            // 
            this.facePassThruRecordEndTimeDT.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.facePassThruRecordEndTimeDT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.facePassThruRecordEndTimeDT.Location = new System.Drawing.Point(261, 11);
            this.facePassThruRecordEndTimeDT.Name = "facePassThruRecordEndTimeDT";
            this.facePassThruRecordEndTimeDT.Size = new System.Drawing.Size(156, 23);
            this.facePassThruRecordEndTimeDT.TabIndex = 13;
            // 
            // facePassThruRecordBeginTimeDT
            // 
            this.facePassThruRecordBeginTimeDT.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.facePassThruRecordBeginTimeDT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.facePassThruRecordBeginTimeDT.Location = new System.Drawing.Point(82, 10);
            this.facePassThruRecordBeginTimeDT.Name = "facePassThruRecordBeginTimeDT";
            this.facePassThruRecordBeginTimeDT.Size = new System.Drawing.Size(159, 23);
            this.facePassThruRecordBeginTimeDT.TabIndex = 12;
            // 
            // label102
            // 
            this.label102.AutoSize = true;
            this.label102.Location = new System.Drawing.Point(10, 13);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(74, 17);
            this.label102.TabIndex = 11;
            this.label102.Text = "Alarm Time";
            // 
            // facePassThruRecordDataGridView
            // 
            this.facePassThruRecordDataGridView.AllowUserToAddRows = false;
            this.facePassThruRecordDataGridView.AllowUserToDeleteRows = false;
            this.facePassThruRecordDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.facePassThruRecordDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.facePassThruRecordDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.facePassThruRecordPanoImageDataGVImgCol,
            this.facePassThruRecordFaceImageDataGVImgCol,
            this.facePassThruRecordTimeDataGVTextCol,
            this.facePassThruRecordAlarmSourceDataGVTextCol});
            this.facePassThruRecordDataGridView.Location = new System.Drawing.Point(3, 44);
            this.facePassThruRecordDataGridView.MultiSelect = false;
            this.facePassThruRecordDataGridView.Name = "facePassThruRecordDataGridView";
            this.facePassThruRecordDataGridView.RowHeadersVisible = false;
            this.facePassThruRecordDataGridView.RowTemplate.Height = 175;
            this.facePassThruRecordDataGridView.RowTemplate.ReadOnly = true;
            this.facePassThruRecordDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.facePassThruRecordDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.facePassThruRecordDataGridView.Size = new System.Drawing.Size(832, 469);
            this.facePassThruRecordDataGridView.TabIndex = 10;
            // 
            // facePassThruRecordPanoImageDataGVImgCol
            // 
            this.facePassThruRecordPanoImageDataGVImgCol.HeaderText = "Panoramic Image";
            this.facePassThruRecordPanoImageDataGVImgCol.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.facePassThruRecordPanoImageDataGVImgCol.Name = "facePassThruRecordPanoImageDataGVImgCol";
            this.facePassThruRecordPanoImageDataGVImgCol.ReadOnly = true;
            this.facePassThruRecordPanoImageDataGVImgCol.Width = 310;
            // 
            // facePassThruRecordFaceImageDataGVImgCol
            // 
            this.facePassThruRecordFaceImageDataGVImgCol.HeaderText = "face Image";
            this.facePassThruRecordFaceImageDataGVImgCol.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.facePassThruRecordFaceImageDataGVImgCol.Name = "facePassThruRecordFaceImageDataGVImgCol";
            this.facePassThruRecordFaceImageDataGVImgCol.ReadOnly = true;
            this.facePassThruRecordFaceImageDataGVImgCol.Width = 172;
            // 
            // facePassThruRecordTimeDataGVTextCol
            // 
            this.facePassThruRecordTimeDataGVTextCol.HeaderText = "Time";
            this.facePassThruRecordTimeDataGVTextCol.Name = "facePassThruRecordTimeDataGVTextCol";
            this.facePassThruRecordTimeDataGVTextCol.ReadOnly = true;
            this.facePassThruRecordTimeDataGVTextCol.Width = 141;
            // 
            // facePassThruRecordAlarmSourceDataGVTextCol
            // 
            this.facePassThruRecordAlarmSourceDataGVTextCol.HeaderText = "Alarm Source";
            this.facePassThruRecordAlarmSourceDataGVTextCol.Name = "facePassThruRecordAlarmSourceDataGVTextCol";
            this.facePassThruRecordAlarmSourceDataGVTextCol.ReadOnly = true;
            this.facePassThruRecordAlarmSourceDataGVTextCol.Width = 180;
            // 
            // LicensePlateRecognitionTabPage
            // 
            this.LicensePlateRecognitionTabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LicensePlateRecognitionTabPage.Controls.Add(this.tabControl2);
            this.LicensePlateRecognitionTabPage.Location = new System.Drawing.Point(4, 26);
            this.LicensePlateRecognitionTabPage.Name = "LicensePlateRecognitionTabPage";
            this.LicensePlateRecognitionTabPage.Size = new System.Drawing.Size(895, 570);
            this.LicensePlateRecognitionTabPage.TabIndex = 3;
            this.LicensePlateRecognitionTabPage.Text = " LPR";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.LPRRealtimeMonitoringTabPage);
            this.tabControl2.Controls.Add(this.LPRVehicleLibraryManagemnetTabPage);
            this.tabControl2.Controls.Add(this.LPRMonitoringTaskTabPage);
            this.tabControl2.Controls.Add(this.LPRAlarmAndPassThruRecordTabPage);
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(853, 553);
            this.tabControl2.TabIndex = 0;
            // 
            // LPRRealtimeMonitoringTabPage
            // 
            this.LPRRealtimeMonitoringTabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LPRRealtimeMonitoringTabPage.Controls.Add(this.groupBox31);
            this.LPRRealtimeMonitoringTabPage.Controls.Add(this.groupBox32);
            this.LPRRealtimeMonitoringTabPage.Controls.Add(this.groupBox34);
            this.LPRRealtimeMonitoringTabPage.Controls.Add(this.groupBox35);
            this.LPRRealtimeMonitoringTabPage.Controls.Add(this.groupBox36);
            this.LPRRealtimeMonitoringTabPage.Controls.Add(this.LPRRealPlayFLayoutPanel);
            this.LPRRealtimeMonitoringTabPage.Location = new System.Drawing.Point(4, 26);
            this.LPRRealtimeMonitoringTabPage.Name = "LPRRealtimeMonitoringTabPage";
            this.LPRRealtimeMonitoringTabPage.Size = new System.Drawing.Size(845, 523);
            this.LPRRealtimeMonitoringTabPage.TabIndex = 2;
            this.LPRRealtimeMonitoringTabPage.Text = "Realtime Monitoring";
            this.LPRRealtimeMonitoringTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox31
            // 
            this.groupBox31.Controls.Add(this.LPRSnapshotSubBtn);
            this.groupBox31.Controls.Add(this.LPRSnapshotUnSubBtn);
            this.groupBox31.Location = new System.Drawing.Point(480, 2);
            this.groupBox31.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox31.Name = "groupBox31";
            this.groupBox31.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox31.Size = new System.Drawing.Size(200, 42);
            this.groupBox31.TabIndex = 11;
            this.groupBox31.TabStop = false;
            this.groupBox31.Text = "Snapshot";
            // 
            // LPRSnapshotSubBtn
            // 
            this.LPRSnapshotSubBtn.Location = new System.Drawing.Point(11, 15);
            this.LPRSnapshotSubBtn.Name = "LPRSnapshotSubBtn";
            this.LPRSnapshotSubBtn.Size = new System.Drawing.Size(75, 23);
            this.LPRSnapshotSubBtn.TabIndex = 6;
            this.LPRSnapshotSubBtn.Text = "Subscribe";
            this.LPRSnapshotSubBtn.UseVisualStyleBackColor = true;
            this.LPRSnapshotSubBtn.Click += new System.EventHandler(this.LPRSnapshotSubBtn_Click);
            // 
            // LPRSnapshotUnSubBtn
            // 
            this.LPRSnapshotUnSubBtn.Location = new System.Drawing.Point(92, 15);
            this.LPRSnapshotUnSubBtn.Name = "LPRSnapshotUnSubBtn";
            this.LPRSnapshotUnSubBtn.Size = new System.Drawing.Size(90, 23);
            this.LPRSnapshotUnSubBtn.TabIndex = 6;
            this.LPRSnapshotUnSubBtn.Text = "UnSubscribe";
            this.LPRSnapshotUnSubBtn.UseVisualStyleBackColor = true;
            this.LPRSnapshotUnSubBtn.Click += new System.EventHandler(this.LPRSnapshotUnSubBtn_Click);
            // 
            // groupBox32
            // 
            this.groupBox32.Controls.Add(this.LPRRecogSubBtn);
            this.groupBox32.Controls.Add(this.LPRRecogUnSubBtn);
            this.groupBox32.Location = new System.Drawing.Point(247, 2);
            this.groupBox32.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox32.Name = "groupBox32";
            this.groupBox32.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox32.Size = new System.Drawing.Size(200, 42);
            this.groupBox32.TabIndex = 12;
            this.groupBox32.TabStop = false;
            this.groupBox32.Text = "Recognition";
            // 
            // LPRRecogSubBtn
            // 
            this.LPRRecogSubBtn.Location = new System.Drawing.Point(11, 15);
            this.LPRRecogSubBtn.Name = "LPRRecogSubBtn";
            this.LPRRecogSubBtn.Size = new System.Drawing.Size(75, 23);
            this.LPRRecogSubBtn.TabIndex = 6;
            this.LPRRecogSubBtn.Text = "Subscribe";
            this.LPRRecogSubBtn.UseVisualStyleBackColor = true;
            this.LPRRecogSubBtn.Click += new System.EventHandler(this.LPRRecogSubBtn_Click);
            // 
            // LPRRecogUnSubBtn
            // 
            this.LPRRecogUnSubBtn.Location = new System.Drawing.Point(92, 15);
            this.LPRRecogUnSubBtn.Name = "LPRRecogUnSubBtn";
            this.LPRRecogUnSubBtn.Size = new System.Drawing.Size(91, 23);
            this.LPRRecogUnSubBtn.TabIndex = 6;
            this.LPRRecogUnSubBtn.Text = "UnSubscribe";
            this.LPRRecogUnSubBtn.UseVisualStyleBackColor = true;
            this.LPRRecogUnSubBtn.Click += new System.EventHandler(this.LPRRecogUnSubBtn_Click);
            // 
            // groupBox34
            // 
            this.groupBox34.Controls.Add(this.LPRRealPlayStartBtn);
            this.groupBox34.Controls.Add(this.LPRRealPlayStopBtn);
            this.groupBox34.Location = new System.Drawing.Point(28, 2);
            this.groupBox34.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox34.Name = "groupBox34";
            this.groupBox34.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox34.Size = new System.Drawing.Size(200, 42);
            this.groupBox34.TabIndex = 14;
            this.groupBox34.TabStop = false;
            this.groupBox34.Text = "RealPlay";
            // 
            // LPRRealPlayStartBtn
            // 
            this.LPRRealPlayStartBtn.Location = new System.Drawing.Point(11, 15);
            this.LPRRealPlayStartBtn.Name = "LPRRealPlayStartBtn";
            this.LPRRealPlayStartBtn.Size = new System.Drawing.Size(75, 23);
            this.LPRRealPlayStartBtn.TabIndex = 6;
            this.LPRRealPlayStartBtn.Text = "start";
            this.LPRRealPlayStartBtn.UseVisualStyleBackColor = true;
            this.LPRRealPlayStartBtn.Click += new System.EventHandler(this.LPRRealPlayStartBtn_Click);
            // 
            // LPRRealPlayStopBtn
            // 
            this.LPRRealPlayStopBtn.Location = new System.Drawing.Point(92, 15);
            this.LPRRealPlayStopBtn.Name = "LPRRealPlayStopBtn";
            this.LPRRealPlayStopBtn.Size = new System.Drawing.Size(75, 23);
            this.LPRRealPlayStopBtn.TabIndex = 6;
            this.LPRRealPlayStopBtn.Text = "Stop";
            this.LPRRealPlayStopBtn.UseVisualStyleBackColor = true;
            this.LPRRealPlayStopBtn.Click += new System.EventHandler(this.LPRRealPlayStopBtn_Click);
            // 
            // groupBox35
            // 
            this.groupBox35.Controls.Add(this.vehiclePanoRecogPicBox);
            this.groupBox35.Controls.Add(this.plateNoRecogLab);
            this.groupBox35.Controls.Add(this.plateRecogPicBox);
            this.groupBox35.Controls.Add(this.LPRAlarmRecordsListView);
            this.groupBox35.Location = new System.Drawing.Point(11, 361);
            this.groupBox35.Name = "groupBox35";
            this.groupBox35.Size = new System.Drawing.Size(823, 159);
            this.groupBox35.TabIndex = 10;
            this.groupBox35.TabStop = false;
            this.groupBox35.Text = "Alarm Records";
            // 
            // vehiclePanoRecogPicBox
            // 
            this.vehiclePanoRecogPicBox.BackColor = System.Drawing.Color.LightGray;
            this.vehiclePanoRecogPicBox.Location = new System.Drawing.Point(3, 24);
            this.vehiclePanoRecogPicBox.Name = "vehiclePanoRecogPicBox";
            this.vehiclePanoRecogPicBox.Size = new System.Drawing.Size(105, 60);
            this.vehiclePanoRecogPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.vehiclePanoRecogPicBox.TabIndex = 4;
            this.vehiclePanoRecogPicBox.TabStop = false;
            // 
            // plateNoRecogLab
            // 
            this.plateNoRecogLab.BackColor = System.Drawing.Color.LightGray;
            this.plateNoRecogLab.Location = new System.Drawing.Point(2, 126);
            this.plateNoRecogLab.Name = "plateNoRecogLab";
            this.plateNoRecogLab.Size = new System.Drawing.Size(106, 25);
            this.plateNoRecogLab.TabIndex = 3;
            this.plateNoRecogLab.Text = "Plate No.";
            this.plateNoRecogLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // plateRecogPicBox
            // 
            this.plateRecogPicBox.BackColor = System.Drawing.Color.LightGray;
            this.plateRecogPicBox.Location = new System.Drawing.Point(2, 86);
            this.plateRecogPicBox.Name = "plateRecogPicBox";
            this.plateRecogPicBox.Size = new System.Drawing.Size(106, 38);
            this.plateRecogPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.plateRecogPicBox.TabIndex = 2;
            this.plateRecogPicBox.TabStop = false;
            // 
            // LPRAlarmRecordsListView
            // 
            this.LPRAlarmRecordsListView.BackColor = System.Drawing.SystemColors.Window;
            this.LPRAlarmRecordsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.plateNoAlarmRecordColHeader,
            this.LPRSnapshotTimeAlarmRecordColHeader,
            this.plateColorAlarmRecordColHeader,
            this.plateMatchAlarmRecordColHeader,
            this.plateTypeAlarmRecordColHeader,
            this.VehicleColorAlarmRecordColHeader,
            this.LPRCameraNameAlarmRecordColHeader,
            this.LPRCauseAlarmRecordColHeader});
            this.LPRAlarmRecordsListView.GridLines = true;
            this.LPRAlarmRecordsListView.Location = new System.Drawing.Point(109, 22);
            this.LPRAlarmRecordsListView.Name = "LPRAlarmRecordsListView";
            this.LPRAlarmRecordsListView.Size = new System.Drawing.Size(709, 131);
            this.LPRAlarmRecordsListView.TabIndex = 1;
            this.LPRAlarmRecordsListView.UseCompatibleStateImageBehavior = false;
            this.LPRAlarmRecordsListView.View = System.Windows.Forms.View.Details;
            // 
            // plateNoAlarmRecordColHeader
            // 
            this.plateNoAlarmRecordColHeader.Text = "Plate No.";
            this.plateNoAlarmRecordColHeader.Width = 73;
            // 
            // LPRSnapshotTimeAlarmRecordColHeader
            // 
            this.LPRSnapshotTimeAlarmRecordColHeader.Text = "SnapshotTime";
            this.LPRSnapshotTimeAlarmRecordColHeader.Width = 140;
            // 
            // plateColorAlarmRecordColHeader
            // 
            this.plateColorAlarmRecordColHeader.Text = "Plate Color";
            this.plateColorAlarmRecordColHeader.Width = 76;
            // 
            // plateMatchAlarmRecordColHeader
            // 
            this.plateMatchAlarmRecordColHeader.Text = "Match";
            this.plateMatchAlarmRecordColHeader.Width = 89;
            // 
            // plateTypeAlarmRecordColHeader
            // 
            this.plateTypeAlarmRecordColHeader.Text = "Plate Type";
            this.plateTypeAlarmRecordColHeader.Width = 122;
            // 
            // VehicleColorAlarmRecordColHeader
            // 
            this.VehicleColorAlarmRecordColHeader.Text = "Vehicle Color";
            this.VehicleColorAlarmRecordColHeader.Width = 100;
            // 
            // LPRCameraNameAlarmRecordColHeader
            // 
            this.LPRCameraNameAlarmRecordColHeader.Text = "Camera Name";
            this.LPRCameraNameAlarmRecordColHeader.Width = 122;
            // 
            // LPRCauseAlarmRecordColHeader
            // 
            this.LPRCauseAlarmRecordColHeader.Text = "Cause";
            this.LPRCauseAlarmRecordColHeader.Width = 128;
            // 
            // groupBox36
            // 
            this.groupBox36.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox36.Controls.Add(this.vehicleSnapshotPicTimeLab);
            this.groupBox36.Controls.Add(this.plateSnapshotSmallPictureBox);
            this.groupBox36.Controls.Add(this.vehicleSnapshotLargePictureBox);
            this.groupBox36.Location = new System.Drawing.Point(591, 40);
            this.groupBox36.Name = "groupBox36";
            this.groupBox36.Size = new System.Drawing.Size(243, 319);
            this.groupBox36.TabIndex = 9;
            this.groupBox36.TabStop = false;
            this.groupBox36.Text = "snapshots";
            // 
            // vehicleSnapshotPicTimeLab
            // 
            this.vehicleSnapshotPicTimeLab.BackColor = System.Drawing.Color.LightGray;
            this.vehicleSnapshotPicTimeLab.Location = new System.Drawing.Point(6, 227);
            this.vehicleSnapshotPicTimeLab.Name = "vehicleSnapshotPicTimeLab";
            this.vehicleSnapshotPicTimeLab.Size = new System.Drawing.Size(231, 34);
            this.vehicleSnapshotPicTimeLab.TabIndex = 3;
            this.vehicleSnapshotPicTimeLab.Text = "Time";
            this.vehicleSnapshotPicTimeLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // plateSnapshotSmallPictureBox
            // 
            this.plateSnapshotSmallPictureBox.BackColor = System.Drawing.Color.LightGray;
            this.plateSnapshotSmallPictureBox.Location = new System.Drawing.Point(6, 167);
            this.plateSnapshotSmallPictureBox.Name = "plateSnapshotSmallPictureBox";
            this.plateSnapshotSmallPictureBox.Size = new System.Drawing.Size(231, 59);
            this.plateSnapshotSmallPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.plateSnapshotSmallPictureBox.TabIndex = 2;
            this.plateSnapshotSmallPictureBox.TabStop = false;
            // 
            // vehicleSnapshotLargePictureBox
            // 
            this.vehicleSnapshotLargePictureBox.BackColor = System.Drawing.Color.LightGray;
            this.vehicleSnapshotLargePictureBox.Location = new System.Drawing.Point(6, 22);
            this.vehicleSnapshotLargePictureBox.Name = "vehicleSnapshotLargePictureBox";
            this.vehicleSnapshotLargePictureBox.Size = new System.Drawing.Size(231, 143);
            this.vehicleSnapshotLargePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.vehicleSnapshotLargePictureBox.TabIndex = 0;
            this.vehicleSnapshotLargePictureBox.TabStop = false;
            // 
            // LPRRealPlayFLayoutPanel
            // 
            this.LPRRealPlayFLayoutPanel.Location = new System.Drawing.Point(11, 46);
            this.LPRRealPlayFLayoutPanel.Name = "LPRRealPlayFLayoutPanel";
            this.LPRRealPlayFLayoutPanel.Size = new System.Drawing.Size(574, 313);
            this.LPRRealPlayFLayoutPanel.TabIndex = 8;
            // 
            // LPRVehicleLibraryManagemnetTabPage
            // 
            this.LPRVehicleLibraryManagemnetTabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LPRVehicleLibraryManagemnetTabPage.Controls.Add(this.groupBox28);
            this.LPRVehicleLibraryManagemnetTabPage.Controls.Add(this.groupBox30);
            this.LPRVehicleLibraryManagemnetTabPage.Location = new System.Drawing.Point(4, 26);
            this.LPRVehicleLibraryManagemnetTabPage.Name = "LPRVehicleLibraryManagemnetTabPage";
            this.LPRVehicleLibraryManagemnetTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.LPRVehicleLibraryManagemnetTabPage.Size = new System.Drawing.Size(845, 523);
            this.LPRVehicleLibraryManagemnetTabPage.TabIndex = 0;
            this.LPRVehicleLibraryManagemnetTabPage.Text = "Vehicle Library Managemnet";
            this.LPRVehicleLibraryManagemnetTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox28
            // 
            this.groupBox28.Controls.Add(this.delVehicleInfoBtn);
            this.groupBox28.Controls.Add(this.modifyVehicleInfoBtn);
            this.groupBox28.Controls.Add(this.addVehicleInfoBtn);
            this.groupBox28.Controls.Add(this.FindVehicleInfoBtn);
            this.groupBox28.Controls.Add(this.groupBox29);
            this.groupBox28.Controls.Add(this.vehicleInfoListView);
            this.groupBox28.Location = new System.Drawing.Point(10, 73);
            this.groupBox28.Name = "groupBox28";
            this.groupBox28.Size = new System.Drawing.Size(826, 443);
            this.groupBox28.TabIndex = 4;
            this.groupBox28.TabStop = false;
            this.groupBox28.Text = "Plate Info";
            // 
            // delVehicleInfoBtn
            // 
            this.delVehicleInfoBtn.Location = new System.Drawing.Point(293, 130);
            this.delVehicleInfoBtn.Name = "delVehicleInfoBtn";
            this.delVehicleInfoBtn.Size = new System.Drawing.Size(75, 23);
            this.delVehicleInfoBtn.TabIndex = 21;
            this.delVehicleInfoBtn.Text = "Delete";
            this.delVehicleInfoBtn.UseVisualStyleBackColor = true;
            this.delVehicleInfoBtn.Click += new System.EventHandler(this.delVehicleInfoBtn_Click);
            // 
            // modifyVehicleInfoBtn
            // 
            this.modifyVehicleInfoBtn.Location = new System.Drawing.Point(197, 130);
            this.modifyVehicleInfoBtn.Name = "modifyVehicleInfoBtn";
            this.modifyVehicleInfoBtn.Size = new System.Drawing.Size(75, 23);
            this.modifyVehicleInfoBtn.TabIndex = 20;
            this.modifyVehicleInfoBtn.Text = "Modify";
            this.modifyVehicleInfoBtn.UseVisualStyleBackColor = true;
            this.modifyVehicleInfoBtn.Click += new System.EventHandler(this.modifyVehicleInfoBtn_Click);
            // 
            // addVehicleInfoBtn
            // 
            this.addVehicleInfoBtn.Location = new System.Drawing.Point(104, 130);
            this.addVehicleInfoBtn.Name = "addVehicleInfoBtn";
            this.addVehicleInfoBtn.Size = new System.Drawing.Size(75, 23);
            this.addVehicleInfoBtn.TabIndex = 19;
            this.addVehicleInfoBtn.Text = "Add";
            this.addVehicleInfoBtn.UseVisualStyleBackColor = true;
            this.addVehicleInfoBtn.Click += new System.EventHandler(this.addVehicleInfoBtn_Click);
            // 
            // FindVehicleInfoBtn
            // 
            this.FindVehicleInfoBtn.Location = new System.Drawing.Point(8, 130);
            this.FindVehicleInfoBtn.Name = "FindVehicleInfoBtn";
            this.FindVehicleInfoBtn.Size = new System.Drawing.Size(75, 23);
            this.FindVehicleInfoBtn.TabIndex = 18;
            this.FindVehicleInfoBtn.Text = "Find";
            this.FindVehicleInfoBtn.UseVisualStyleBackColor = true;
            this.FindVehicleInfoBtn.Click += new System.EventHandler(this.FindVehicleInfoBtn_Click);
            // 
            // groupBox29
            // 
            this.groupBox29.Controls.Add(this.plateAreaCmb);
            this.groupBox29.Controls.Add(this.PlateTypeCmb);
            this.groupBox29.Controls.Add(this.plateColorCmb);
            this.groupBox29.Controls.Add(this.vehicleColorCmb);
            this.groupBox29.Controls.Add(this.label98);
            this.groupBox29.Controls.Add(this.label94);
            this.groupBox29.Controls.Add(this.label95);
            this.groupBox29.Controls.Add(this.plateNoText);
            this.groupBox29.Controls.Add(this.label97);
            this.groupBox29.Location = new System.Drawing.Point(7, 21);
            this.groupBox29.Name = "groupBox29";
            this.groupBox29.Size = new System.Drawing.Size(813, 97);
            this.groupBox29.TabIndex = 17;
            this.groupBox29.TabStop = false;
            this.groupBox29.Text = "Plate Info";
            // 
            // plateAreaCmb
            // 
            this.plateAreaCmb.FormattingEnabled = true;
            this.plateAreaCmb.Items.AddRange(new object[] {
            "京",
            "津",
            "沪",
            "渝",
            "冀",
            "豫",
            "云",
            "辽",
            "黑",
            "湘",
            "皖",
            "鲁",
            "新",
            "苏",
            "浙",
            "赣",
            "鄂",
            "桂",
            "甘",
            "晋",
            "蒙",
            "陕",
            "吉",
            "闽",
            "贵",
            "粤",
            "青",
            "藏",
            "川",
            "琼"});
            this.plateAreaCmb.Location = new System.Drawing.Point(82, 25);
            this.plateAreaCmb.Name = "plateAreaCmb";
            this.plateAreaCmb.Size = new System.Drawing.Size(61, 25);
            this.plateAreaCmb.TabIndex = 37;
            this.plateAreaCmb.Text = "京";
            // 
            // PlateTypeCmb
            // 
            this.PlateTypeCmb.FormattingEnabled = true;
            this.PlateTypeCmb.Items.AddRange(new object[] {
            "Large Vehicle Plate",
            "Small Vehicle Plate",
            "Embassy Vehicle Plate",
            "Consulate Vehicle Plate",
            "Overseas Vehicle Plate",
            "Foreign Vehicle Plate",
            "Overseas Motorcycle Plate",
            "Foreign Motorcycle Plate",
            "Common Motorcycle Plate",
            "Light Motorcycle Plate",
            "Embassy Motorcycle Plate",
            "Consulate Motorcycle Plate",
            "Low Speed Vehicle Plate",
            "Tractor Plate",
            "Trailer Plate",
            "Coach Vehicle Plate",
            "Coach Motorcycle Plate",
            "Temporary Entry Vehicle Plate",
            "Temporary Entry Motorcycle Plate",
            "Temporary Vehicle Plate",
            "Police Vehicle Plate",
            "Police Motorcycle Plate",
            "Border Crossing Vehicle (Hong Kong) Plate",
            "Border Crossing Vehicle (Macau) Plate",
            "Armed Police Plate",
            "Military Plate",
            "Other"});
            this.PlateTypeCmb.Location = new System.Drawing.Point(470, 22);
            this.PlateTypeCmb.Name = "PlateTypeCmb";
            this.PlateTypeCmb.Size = new System.Drawing.Size(221, 25);
            this.PlateTypeCmb.TabIndex = 36;
            this.PlateTypeCmb.Text = "Other";
            // 
            // plateColorCmb
            // 
            this.plateColorCmb.FormattingEnabled = true;
            this.plateColorCmb.Items.AddRange(new object[] {
            "Black",
            "White",
            "Gray",
            "Red",
            "Blue",
            "Yellow",
            "Orange",
            "Brown",
            "Green",
            "Purple",
            "Cyan",
            "Pink",
            "Transparent",
            "Silvery White",
            "Dark",
            "Light",
            "No Color",
            "Yellow&Green",
            "Gradated Green",
            "Other"});
            this.plateColorCmb.Location = new System.Drawing.Point(82, 57);
            this.plateColorCmb.Name = "plateColorCmb";
            this.plateColorCmb.Size = new System.Drawing.Size(284, 25);
            this.plateColorCmb.TabIndex = 25;
            this.plateColorCmb.Text = "Other";
            // 
            // vehicleColorCmb
            // 
            this.vehicleColorCmb.FormattingEnabled = true;
            this.vehicleColorCmb.Items.AddRange(new object[] {
            "Black",
            "White",
            "Gray",
            "Red",
            "Blue",
            "Yellow",
            "Orange",
            "Brown",
            "Green",
            "Purple",
            "Cyan",
            "Pink",
            "Transparent",
            "Silvery White",
            "Dark",
            "Light",
            "No Color",
            "Yellow&Green",
            "Gradated Green",
            "Other"});
            this.vehicleColorCmb.Location = new System.Drawing.Point(470, 57);
            this.vehicleColorCmb.Name = "vehicleColorCmb";
            this.vehicleColorCmb.Size = new System.Drawing.Size(221, 25);
            this.vehicleColorCmb.TabIndex = 25;
            this.vehicleColorCmb.Text = "Other";
            // 
            // label98
            // 
            this.label98.AutoSize = true;
            this.label98.Location = new System.Drawing.Point(7, 62);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(72, 17);
            this.label98.TabIndex = 20;
            this.label98.Text = "Plate Color";
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Location = new System.Drawing.Point(380, 60);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(85, 17);
            this.label94.TabIndex = 20;
            this.label94.Text = "Vehicle Color";
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Location = new System.Drawing.Point(380, 26);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(68, 17);
            this.label95.TabIndex = 19;
            this.label95.Text = "Plate Type";
            // 
            // plateNoText
            // 
            this.plateNoText.Location = new System.Drawing.Point(145, 25);
            this.plateNoText.Name = "plateNoText";
            this.plateNoText.Size = new System.Drawing.Size(221, 23);
            this.plateNoText.TabIndex = 17;
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.Location = new System.Drawing.Point(6, 29);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(70, 17);
            this.label97.TabIndex = 15;
            this.label97.Text = "* Plate No.";
            // 
            // vehicleInfoListView
            // 
            this.vehicleInfoListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LPRVehicleInfoPlateIDColHeader,
            this.LPRVehicleInfoPlateNoColHeader,
            this.LPRVehicleInfoPlateColorColHeader,
            this.LPRVehicleInfoPlateTypeColHeader,
            this.LPRVehicleInfoVehicleColorColHeader,
            this.LPRVehicleInfoStatusColHeader});
            this.vehicleInfoListView.FullRowSelect = true;
            this.vehicleInfoListView.GridLines = true;
            this.vehicleInfoListView.Location = new System.Drawing.Point(7, 165);
            this.vehicleInfoListView.MultiSelect = false;
            this.vehicleInfoListView.Name = "vehicleInfoListView";
            this.vehicleInfoListView.Size = new System.Drawing.Size(813, 176);
            this.vehicleInfoListView.TabIndex = 16;
            this.vehicleInfoListView.UseCompatibleStateImageBehavior = false;
            this.vehicleInfoListView.View = System.Windows.Forms.View.Details;
            this.vehicleInfoListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.vehicleInfoListView_ItemSelectionChanged);
            // 
            // LPRVehicleInfoPlateIDColHeader
            // 
            this.LPRVehicleInfoPlateIDColHeader.Text = "ID";
            // 
            // LPRVehicleInfoPlateNoColHeader
            // 
            this.LPRVehicleInfoPlateNoColHeader.Text = "Plate No.";
            this.LPRVehicleInfoPlateNoColHeader.Width = 100;
            // 
            // LPRVehicleInfoPlateColorColHeader
            // 
            this.LPRVehicleInfoPlateColorColHeader.Text = "Plate Color";
            this.LPRVehicleInfoPlateColorColHeader.Width = 100;
            // 
            // LPRVehicleInfoPlateTypeColHeader
            // 
            this.LPRVehicleInfoPlateTypeColHeader.Text = "Plate Type";
            this.LPRVehicleInfoPlateTypeColHeader.Width = 100;
            // 
            // LPRVehicleInfoVehicleColorColHeader
            // 
            this.LPRVehicleInfoVehicleColorColHeader.Text = "Vehicle Color";
            this.LPRVehicleInfoVehicleColorColHeader.Width = 100;
            // 
            // LPRVehicleInfoStatusColHeader
            // 
            this.LPRVehicleInfoStatusColHeader.Text = "Status";
            this.LPRVehicleInfoStatusColHeader.Width = 100;
            // 
            // groupBox30
            // 
            this.groupBox30.Controls.Add(this.vehicleLibNameText);
            this.groupBox30.Controls.Add(this.vehicleLibCmb);
            this.groupBox30.Controls.Add(this.delVehicleLibBtn);
            this.groupBox30.Controls.Add(this.modifyVehicleLibBtn);
            this.groupBox30.Controls.Add(this.addVehicleLibBtn);
            this.groupBox30.Controls.Add(this.FindVehicleLibBtn);
            this.groupBox30.Location = new System.Drawing.Point(9, 7);
            this.groupBox30.Name = "groupBox30";
            this.groupBox30.Size = new System.Drawing.Size(826, 63);
            this.groupBox30.TabIndex = 3;
            this.groupBox30.TabStop = false;
            this.groupBox30.Text = "Vehicle Library";
            // 
            // vehicleLibNameText
            // 
            this.vehicleLibNameText.Location = new System.Drawing.Point(152, 23);
            this.vehicleLibNameText.Name = "vehicleLibNameText";
            this.vehicleLibNameText.Size = new System.Drawing.Size(132, 23);
            this.vehicleLibNameText.TabIndex = 5;
            // 
            // vehicleLibCmb
            // 
            this.vehicleLibCmb.FormattingEnabled = true;
            this.vehicleLibCmb.Location = new System.Drawing.Point(25, 23);
            this.vehicleLibCmb.Name = "vehicleLibCmb";
            this.vehicleLibCmb.Size = new System.Drawing.Size(121, 25);
            this.vehicleLibCmb.TabIndex = 4;
            this.vehicleLibCmb.SelectedIndexChanged += new System.EventHandler(this.vehicleLibCmb_SelectedIndexChanged);
            // 
            // delVehicleLibBtn
            // 
            this.delVehicleLibBtn.Location = new System.Drawing.Point(575, 22);
            this.delVehicleLibBtn.Name = "delVehicleLibBtn";
            this.delVehicleLibBtn.Size = new System.Drawing.Size(75, 23);
            this.delVehicleLibBtn.TabIndex = 3;
            this.delVehicleLibBtn.Text = "Delete";
            this.delVehicleLibBtn.UseVisualStyleBackColor = true;
            this.delVehicleLibBtn.Click += new System.EventHandler(this.delVehicleLibBtn_Click);
            // 
            // modifyVehicleLibBtn
            // 
            this.modifyVehicleLibBtn.Location = new System.Drawing.Point(479, 22);
            this.modifyVehicleLibBtn.Name = "modifyVehicleLibBtn";
            this.modifyVehicleLibBtn.Size = new System.Drawing.Size(75, 23);
            this.modifyVehicleLibBtn.TabIndex = 2;
            this.modifyVehicleLibBtn.Text = "Modify";
            this.modifyVehicleLibBtn.UseVisualStyleBackColor = true;
            this.modifyVehicleLibBtn.Click += new System.EventHandler(this.modifyVehicleLibBtn_Click);
            // 
            // addVehicleLibBtn
            // 
            this.addVehicleLibBtn.Location = new System.Drawing.Point(386, 22);
            this.addVehicleLibBtn.Name = "addVehicleLibBtn";
            this.addVehicleLibBtn.Size = new System.Drawing.Size(75, 23);
            this.addVehicleLibBtn.TabIndex = 1;
            this.addVehicleLibBtn.Text = "Add";
            this.addVehicleLibBtn.UseVisualStyleBackColor = true;
            this.addVehicleLibBtn.Click += new System.EventHandler(this.addVehicleLibBtn_Click);
            // 
            // FindVehicleLibBtn
            // 
            this.FindVehicleLibBtn.Location = new System.Drawing.Point(290, 22);
            this.FindVehicleLibBtn.Name = "FindVehicleLibBtn";
            this.FindVehicleLibBtn.Size = new System.Drawing.Size(75, 23);
            this.FindVehicleLibBtn.TabIndex = 0;
            this.FindVehicleLibBtn.Text = "Find";
            this.FindVehicleLibBtn.UseVisualStyleBackColor = true;
            this.FindVehicleLibBtn.Click += new System.EventHandler(this.FindVehicleLibBtn_Click);
            // 
            // LPRMonitoringTaskTabPage
            // 
            this.LPRMonitoringTaskTabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LPRMonitoringTaskTabPage.Controls.Add(this.vehicleMonitorTaskLibNameText);
            this.LPRMonitoringTaskTabPage.Controls.Add(this.disableVehicleMonitorBtn);
            this.LPRMonitoringTaskTabPage.Controls.Add(this.enableVehicleMonitorBtn);
            this.LPRMonitoringTaskTabPage.Controls.Add(this.DelVehicleMonitorBtn);
            this.LPRMonitoringTaskTabPage.Controls.Add(this.modifyVehicleMonitorBtn);
            this.LPRMonitoringTaskTabPage.Controls.Add(this.FindVehicleMonitorBtn);
            this.LPRMonitoringTaskTabPage.Controls.Add(this.vehicleMonitorInfoListView);
            this.LPRMonitoringTaskTabPage.Controls.Add(this.addVehicleMonitorBtn);
            this.LPRMonitoringTaskTabPage.Controls.Add(this.vehicleMonitorObjectCmbBox);
            this.LPRMonitoringTaskTabPage.Controls.Add(this.vehicleCauseCmbBox);
            this.LPRMonitoringTaskTabPage.Controls.Add(this.vehicleMonitorTypeCmbBox);
            this.LPRMonitoringTaskTabPage.Controls.Add(this.vehicleMonitorRemarksText);
            this.LPRMonitoringTaskTabPage.Controls.Add(this.vehicleMonitorTaskNameText);
            this.LPRMonitoringTaskTabPage.Controls.Add(this.label90);
            this.LPRMonitoringTaskTabPage.Controls.Add(this.label88);
            this.LPRMonitoringTaskTabPage.Controls.Add(this.label91);
            this.LPRMonitoringTaskTabPage.Controls.Add(this.label92);
            this.LPRMonitoringTaskTabPage.Controls.Add(this.label93);
            this.LPRMonitoringTaskTabPage.Location = new System.Drawing.Point(4, 26);
            this.LPRMonitoringTaskTabPage.Name = "LPRMonitoringTaskTabPage";
            this.LPRMonitoringTaskTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.LPRMonitoringTaskTabPage.Size = new System.Drawing.Size(845, 523);
            this.LPRMonitoringTaskTabPage.TabIndex = 1;
            this.LPRMonitoringTaskTabPage.Text = "Monitoring Task";
            this.LPRMonitoringTaskTabPage.UseVisualStyleBackColor = true;
            // 
            // vehicleMonitorTaskLibNameText
            // 
            this.vehicleMonitorTaskLibNameText.Location = new System.Drawing.Point(225, 51);
            this.vehicleMonitorTaskLibNameText.Name = "vehicleMonitorTaskLibNameText";
            this.vehicleMonitorTaskLibNameText.ReadOnly = true;
            this.vehicleMonitorTaskLibNameText.Size = new System.Drawing.Size(139, 23);
            this.vehicleMonitorTaskLibNameText.TabIndex = 33;
            // 
            // disableVehicleMonitorBtn
            // 
            this.disableVehicleMonitorBtn.Location = new System.Drawing.Point(502, 124);
            this.disableVehicleMonitorBtn.Name = "disableVehicleMonitorBtn";
            this.disableVehicleMonitorBtn.Size = new System.Drawing.Size(75, 23);
            this.disableVehicleMonitorBtn.TabIndex = 32;
            this.disableVehicleMonitorBtn.Text = "Disable";
            this.disableVehicleMonitorBtn.UseVisualStyleBackColor = true;
            this.disableVehicleMonitorBtn.Click += new System.EventHandler(this.disableVehicleMonitorBtn_Click);
            // 
            // enableVehicleMonitorBtn
            // 
            this.enableVehicleMonitorBtn.Location = new System.Drawing.Point(404, 124);
            this.enableVehicleMonitorBtn.Name = "enableVehicleMonitorBtn";
            this.enableVehicleMonitorBtn.Size = new System.Drawing.Size(75, 23);
            this.enableVehicleMonitorBtn.TabIndex = 31;
            this.enableVehicleMonitorBtn.Text = "Enable";
            this.enableVehicleMonitorBtn.UseVisualStyleBackColor = true;
            this.enableVehicleMonitorBtn.Click += new System.EventHandler(this.enableVehicleMonitorBtn_Click);
            // 
            // DelVehicleMonitorBtn
            // 
            this.DelVehicleMonitorBtn.Location = new System.Drawing.Point(312, 124);
            this.DelVehicleMonitorBtn.Name = "DelVehicleMonitorBtn";
            this.DelVehicleMonitorBtn.Size = new System.Drawing.Size(75, 23);
            this.DelVehicleMonitorBtn.TabIndex = 30;
            this.DelVehicleMonitorBtn.Text = "Delete";
            this.DelVehicleMonitorBtn.UseVisualStyleBackColor = true;
            this.DelVehicleMonitorBtn.Click += new System.EventHandler(this.DelVehicleMonitorBtn_Click);
            // 
            // modifyVehicleMonitorBtn
            // 
            this.modifyVehicleMonitorBtn.Location = new System.Drawing.Point(217, 124);
            this.modifyVehicleMonitorBtn.Name = "modifyVehicleMonitorBtn";
            this.modifyVehicleMonitorBtn.Size = new System.Drawing.Size(75, 23);
            this.modifyVehicleMonitorBtn.TabIndex = 29;
            this.modifyVehicleMonitorBtn.Text = "Modify";
            this.modifyVehicleMonitorBtn.UseVisualStyleBackColor = true;
            this.modifyVehicleMonitorBtn.Click += new System.EventHandler(this.modifyVehicleMonitorBtn_Click);
            // 
            // FindVehicleMonitorBtn
            // 
            this.FindVehicleMonitorBtn.Location = new System.Drawing.Point(16, 124);
            this.FindVehicleMonitorBtn.Name = "FindVehicleMonitorBtn";
            this.FindVehicleMonitorBtn.Size = new System.Drawing.Size(75, 23);
            this.FindVehicleMonitorBtn.TabIndex = 28;
            this.FindVehicleMonitorBtn.Text = "Find";
            this.FindVehicleMonitorBtn.UseVisualStyleBackColor = true;
            this.FindVehicleMonitorBtn.Click += new System.EventHandler(this.FindVehicleMonitorBtn_Click);
            // 
            // vehicleMonitorInfoListView
            // 
            this.vehicleMonitorInfoListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.vehicleMonitorTaskIDColHeader,
            this.vehicleMonitorTaskNameColHeader,
            this.vehicleMonitorRemarksColHeader,
            this.vehicleMonitorTypeColHeader,
            this.vehicleMonitorStatusColHeader});
            this.vehicleMonitorInfoListView.FullRowSelect = true;
            this.vehicleMonitorInfoListView.GridLines = true;
            this.vehicleMonitorInfoListView.Location = new System.Drawing.Point(16, 157);
            this.vehicleMonitorInfoListView.MultiSelect = false;
            this.vehicleMonitorInfoListView.Name = "vehicleMonitorInfoListView";
            this.vehicleMonitorInfoListView.Size = new System.Drawing.Size(800, 133);
            this.vehicleMonitorInfoListView.TabIndex = 27;
            this.vehicleMonitorInfoListView.UseCompatibleStateImageBehavior = false;
            this.vehicleMonitorInfoListView.View = System.Windows.Forms.View.Details;
            this.vehicleMonitorInfoListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.vehicleMonitorInfoListView_ItemSelectionChanged);
            // 
            // vehicleMonitorTaskIDColHeader
            // 
            this.vehicleMonitorTaskIDColHeader.Text = "ID";
            // 
            // vehicleMonitorTaskNameColHeader
            // 
            this.vehicleMonitorTaskNameColHeader.Text = "Task Name";
            this.vehicleMonitorTaskNameColHeader.Width = 120;
            // 
            // vehicleMonitorRemarksColHeader
            // 
            this.vehicleMonitorRemarksColHeader.Text = "Remarks";
            this.vehicleMonitorRemarksColHeader.Width = 120;
            // 
            // vehicleMonitorTypeColHeader
            // 
            this.vehicleMonitorTypeColHeader.Text = "Alarm Type";
            this.vehicleMonitorTypeColHeader.Width = 120;
            // 
            // vehicleMonitorStatusColHeader
            // 
            this.vehicleMonitorStatusColHeader.Text = "Status";
            this.vehicleMonitorStatusColHeader.Width = 120;
            // 
            // addVehicleMonitorBtn
            // 
            this.addVehicleMonitorBtn.Location = new System.Drawing.Point(117, 124);
            this.addVehicleMonitorBtn.Name = "addVehicleMonitorBtn";
            this.addVehicleMonitorBtn.Size = new System.Drawing.Size(75, 23);
            this.addVehicleMonitorBtn.TabIndex = 26;
            this.addVehicleMonitorBtn.Text = "Add";
            this.addVehicleMonitorBtn.UseVisualStyleBackColor = true;
            this.addVehicleMonitorBtn.Click += new System.EventHandler(this.addVehicleMonitorBtn_Click);
            // 
            // vehicleMonitorObjectCmbBox
            // 
            this.vehicleMonitorObjectCmbBox.FormattingEnabled = true;
            this.vehicleMonitorObjectCmbBox.Location = new System.Drawing.Point(149, 51);
            this.vehicleMonitorObjectCmbBox.Name = "vehicleMonitorObjectCmbBox";
            this.vehicleMonitorObjectCmbBox.Size = new System.Drawing.Size(70, 25);
            this.vehicleMonitorObjectCmbBox.TabIndex = 23;
            this.vehicleMonitorObjectCmbBox.SelectedIndexChanged += new System.EventHandler(this.vehicleMonitorObjectCmbBox_SelectedIndexChanged);
            // 
            // vehicleCauseCmbBox
            // 
            this.vehicleCauseCmbBox.FormattingEnabled = true;
            this.vehicleCauseCmbBox.Items.AddRange(new object[] {
            "Robbed Vehicle",
            "Stolen Vehicle",
            "Suspect Vehicle",
            "Traffic Violation",
            "Emergency Control"});
            this.vehicleCauseCmbBox.Location = new System.Drawing.Point(527, 49);
            this.vehicleCauseCmbBox.Name = "vehicleCauseCmbBox";
            this.vehicleCauseCmbBox.Size = new System.Drawing.Size(215, 25);
            this.vehicleCauseCmbBox.TabIndex = 22;
            this.vehicleCauseCmbBox.Text = "Robbed Vehicle";
            // 
            // vehicleMonitorTypeCmbBox
            // 
            this.vehicleMonitorTypeCmbBox.FormattingEnabled = true;
            this.vehicleMonitorTypeCmbBox.Items.AddRange(new object[] {
            "Match Alarm",
            "Not Match Alarm"});
            this.vehicleMonitorTypeCmbBox.Location = new System.Drawing.Point(527, 11);
            this.vehicleMonitorTypeCmbBox.Name = "vehicleMonitorTypeCmbBox";
            this.vehicleMonitorTypeCmbBox.Size = new System.Drawing.Size(215, 25);
            this.vehicleMonitorTypeCmbBox.TabIndex = 22;
            this.vehicleMonitorTypeCmbBox.Text = "Match Alarm";
            // 
            // vehicleMonitorRemarksText
            // 
            this.vehicleMonitorRemarksText.Location = new System.Drawing.Point(149, 86);
            this.vehicleMonitorRemarksText.Name = "vehicleMonitorRemarksText";
            this.vehicleMonitorRemarksText.Size = new System.Drawing.Size(215, 23);
            this.vehicleMonitorRemarksText.TabIndex = 21;
            // 
            // vehicleMonitorTaskNameText
            // 
            this.vehicleMonitorTaskNameText.Location = new System.Drawing.Point(149, 16);
            this.vehicleMonitorTaskNameText.Name = "vehicleMonitorTaskNameText";
            this.vehicleMonitorTaskNameText.Size = new System.Drawing.Size(215, 23);
            this.vehicleMonitorTaskNameText.TabIndex = 20;
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(13, 57);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(124, 17);
            this.label90.TabIndex = 19;
            this.label90.Text = "* Monitoring Object";
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Location = new System.Drawing.Point(392, 57);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(43, 17);
            this.label88.TabIndex = 17;
            this.label88.Text = "Cause";
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(13, 92);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(59, 17);
            this.label91.TabIndex = 18;
            this.label91.Text = "Remarks";
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Location = new System.Drawing.Point(391, 19);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(114, 17);
            this.label92.TabIndex = 17;
            this.label92.Text = "* Monitoring Type";
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Location = new System.Drawing.Point(13, 19);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(83, 17);
            this.label93.TabIndex = 16;
            this.label93.Text = "* Task Name";
            // 
            // LPRAlarmAndPassThruRecordTabPage
            // 
            this.LPRAlarmAndPassThruRecordTabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LPRAlarmAndPassThruRecordTabPage.Controls.Add(this.LPRAlarmRecordMonitoringCauseCmbBox);
            this.LPRAlarmAndPassThruRecordTabPage.Controls.Add(this.label112);
            this.LPRAlarmAndPassThruRecordTabPage.Controls.Add(this.LPRAlarmRecordMonitoringTypeCmbBox);
            this.LPRAlarmAndPassThruRecordTabPage.Controls.Add(this.label111);
            this.LPRAlarmAndPassThruRecordTabPage.Controls.Add(this.LPRAlarmRecordSearchTypeCmbBox);
            this.LPRAlarmAndPassThruRecordTabPage.Controls.Add(this.label110);
            this.LPRAlarmAndPassThruRecordTabPage.Controls.Add(this.LPRAlarmRecordSearchVehicleColorCmbBox);
            this.LPRAlarmAndPassThruRecordTabPage.Controls.Add(this.label109);
            this.LPRAlarmAndPassThruRecordTabPage.Controls.Add(this.LPRAlarmRecordSearchPlateColorCmbBox);
            this.LPRAlarmAndPassThruRecordTabPage.Controls.Add(this.label108);
            this.LPRAlarmAndPassThruRecordTabPage.Controls.Add(this.LPRAlarmRecordSearchPlateNoText);
            this.LPRAlarmAndPassThruRecordTabPage.Controls.Add(this.label107);
            this.LPRAlarmAndPassThruRecordTabPage.Controls.Add(this.LPRAlarmRecordSearchCameraNameText);
            this.LPRAlarmAndPassThruRecordTabPage.Controls.Add(this.label104);
            this.LPRAlarmAndPassThruRecordTabPage.Controls.Add(this.LPRAlarmRecordNextBtn);
            this.LPRAlarmAndPassThruRecordTabPage.Controls.Add(this.LPRAlarmRecordPreviousBtn);
            this.LPRAlarmAndPassThruRecordTabPage.Controls.Add(this.LPRAlarmRecordSearchBtn);
            this.LPRAlarmAndPassThruRecordTabPage.Controls.Add(this.label105);
            this.LPRAlarmAndPassThruRecordTabPage.Controls.Add(this.LPRAlarmRecordSearchEndTimeDT);
            this.LPRAlarmAndPassThruRecordTabPage.Controls.Add(this.LPRAlarmRecordSearchBeginTimeDT);
            this.LPRAlarmAndPassThruRecordTabPage.Controls.Add(this.label106);
            this.LPRAlarmAndPassThruRecordTabPage.Controls.Add(this.LPRAlarmRecordDataGridView);
            this.LPRAlarmAndPassThruRecordTabPage.Location = new System.Drawing.Point(4, 26);
            this.LPRAlarmAndPassThruRecordTabPage.Name = "LPRAlarmAndPassThruRecordTabPage";
            this.LPRAlarmAndPassThruRecordTabPage.Size = new System.Drawing.Size(845, 523);
            this.LPRAlarmAndPassThruRecordTabPage.TabIndex = 3;
            this.LPRAlarmAndPassThruRecordTabPage.Text = "Alarm Record & Pass-Thru Record";
            // 
            // LPRAlarmRecordMonitoringCauseCmbBox
            // 
            this.LPRAlarmRecordMonitoringCauseCmbBox.FormattingEnabled = true;
            this.LPRAlarmRecordMonitoringCauseCmbBox.Items.AddRange(new object[] {
            "Robbed Vehicle",
            "Stolen Vehicle",
            "Suspect Vehicle",
            "Traffic Violation",
            "Emergency Control",
            "All"});
            this.LPRAlarmRecordMonitoringCauseCmbBox.Location = new System.Drawing.Point(117, 73);
            this.LPRAlarmRecordMonitoringCauseCmbBox.Name = "LPRAlarmRecordMonitoringCauseCmbBox";
            this.LPRAlarmRecordMonitoringCauseCmbBox.Size = new System.Drawing.Size(152, 25);
            this.LPRAlarmRecordMonitoringCauseCmbBox.TabIndex = 40;
            this.LPRAlarmRecordMonitoringCauseCmbBox.Text = "All";
            // 
            // label112
            // 
            this.label112.AutoSize = true;
            this.label112.Location = new System.Drawing.Point(6, 77);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(43, 17);
            this.label112.TabIndex = 39;
            this.label112.Text = "Cause";
            // 
            // LPRAlarmRecordMonitoringTypeCmbBox
            // 
            this.LPRAlarmRecordMonitoringTypeCmbBox.FormattingEnabled = true;
            this.LPRAlarmRecordMonitoringTypeCmbBox.Items.AddRange(new object[] {
            "Match Alarm",
            "Not Match Alarm"});
            this.LPRAlarmRecordMonitoringTypeCmbBox.Location = new System.Drawing.Point(117, 42);
            this.LPRAlarmRecordMonitoringTypeCmbBox.Name = "LPRAlarmRecordMonitoringTypeCmbBox";
            this.LPRAlarmRecordMonitoringTypeCmbBox.Size = new System.Drawing.Size(152, 25);
            this.LPRAlarmRecordMonitoringTypeCmbBox.TabIndex = 38;
            this.LPRAlarmRecordMonitoringTypeCmbBox.Text = "Match Alarm";
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.Location = new System.Drawing.Point(6, 44);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(105, 17);
            this.label111.TabIndex = 37;
            this.label111.Text = "Monitoring Type";
            // 
            // LPRAlarmRecordSearchTypeCmbBox
            // 
            this.LPRAlarmRecordSearchTypeCmbBox.FormattingEnabled = true;
            this.LPRAlarmRecordSearchTypeCmbBox.Items.AddRange(new object[] {
            "Alarm Record",
            "Pass-Thru Record"});
            this.LPRAlarmRecordSearchTypeCmbBox.Location = new System.Drawing.Point(117, 9);
            this.LPRAlarmRecordSearchTypeCmbBox.Name = "LPRAlarmRecordSearchTypeCmbBox";
            this.LPRAlarmRecordSearchTypeCmbBox.Size = new System.Drawing.Size(152, 25);
            this.LPRAlarmRecordSearchTypeCmbBox.TabIndex = 36;
            this.LPRAlarmRecordSearchTypeCmbBox.Text = "Alarm Record";
            // 
            // label110
            // 
            this.label110.AutoSize = true;
            this.label110.Location = new System.Drawing.Point(6, 14);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(79, 17);
            this.label110.TabIndex = 35;
            this.label110.Text = "Search Type";
            // 
            // LPRAlarmRecordSearchVehicleColorCmbBox
            // 
            this.LPRAlarmRecordSearchVehicleColorCmbBox.FormattingEnabled = true;
            this.LPRAlarmRecordSearchVehicleColorCmbBox.Items.AddRange(new object[] {
            "Black",
            "White",
            "Gray",
            "Red",
            "Blue",
            "Yellow",
            "Orange",
            "Brown",
            "Green",
            "Purple",
            "Cyan",
            "Pink",
            "Transparent",
            "Silvery White",
            "Dark",
            "Light",
            "No Color",
            "Yellow&Green",
            "Gradated Green",
            "Other",
            "All"});
            this.LPRAlarmRecordSearchVehicleColorCmbBox.Location = new System.Drawing.Point(372, 74);
            this.LPRAlarmRecordSearchVehicleColorCmbBox.Name = "LPRAlarmRecordSearchVehicleColorCmbBox";
            this.LPRAlarmRecordSearchVehicleColorCmbBox.Size = new System.Drawing.Size(113, 25);
            this.LPRAlarmRecordSearchVehicleColorCmbBox.TabIndex = 34;
            this.LPRAlarmRecordSearchVehicleColorCmbBox.Text = "All";
            // 
            // label109
            // 
            this.label109.AutoSize = true;
            this.label109.Location = new System.Drawing.Point(275, 78);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(85, 17);
            this.label109.TabIndex = 33;
            this.label109.Text = "Vehicle Color";
            // 
            // LPRAlarmRecordSearchPlateColorCmbBox
            // 
            this.LPRAlarmRecordSearchPlateColorCmbBox.FormattingEnabled = true;
            this.LPRAlarmRecordSearchPlateColorCmbBox.Items.AddRange(new object[] {
            "Black",
            "White",
            "Gray",
            "Red",
            "Blue",
            "Yellow",
            "Orange",
            "Brown",
            "Green",
            "Purple",
            "Cyan",
            "Pink",
            "Transparent",
            "Silvery White",
            "Dark",
            "Light",
            "No Color",
            "Yellow&Green",
            "Gradated Green",
            "Other",
            "All"});
            this.LPRAlarmRecordSearchPlateColorCmbBox.Location = new System.Drawing.Point(559, 75);
            this.LPRAlarmRecordSearchPlateColorCmbBox.Name = "LPRAlarmRecordSearchPlateColorCmbBox";
            this.LPRAlarmRecordSearchPlateColorCmbBox.Size = new System.Drawing.Size(89, 25);
            this.LPRAlarmRecordSearchPlateColorCmbBox.TabIndex = 32;
            this.LPRAlarmRecordSearchPlateColorCmbBox.Text = "All";
            // 
            // label108
            // 
            this.label108.AutoSize = true;
            this.label108.Location = new System.Drawing.Point(484, 78);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(72, 17);
            this.label108.TabIndex = 31;
            this.label108.Text = "Plate Color";
            // 
            // LPRAlarmRecordSearchPlateNoText
            // 
            this.LPRAlarmRecordSearchPlateNoText.Location = new System.Drawing.Point(564, 41);
            this.LPRAlarmRecordSearchPlateNoText.Name = "LPRAlarmRecordSearchPlateNoText";
            this.LPRAlarmRecordSearchPlateNoText.Size = new System.Drawing.Size(147, 23);
            this.LPRAlarmRecordSearchPlateNoText.TabIndex = 30;
            // 
            // label107
            // 
            this.label107.AutoSize = true;
            this.label107.Location = new System.Drawing.Point(497, 44);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(61, 17);
            this.label107.TabIndex = 29;
            this.label107.Text = "Plate No.";
            // 
            // LPRAlarmRecordSearchCameraNameText
            // 
            this.LPRAlarmRecordSearchCameraNameText.Location = new System.Drawing.Point(372, 41);
            this.LPRAlarmRecordSearchCameraNameText.Name = "LPRAlarmRecordSearchCameraNameText";
            this.LPRAlarmRecordSearchCameraNameText.Size = new System.Drawing.Size(113, 23);
            this.LPRAlarmRecordSearchCameraNameText.TabIndex = 28;
            // 
            // label104
            // 
            this.label104.AutoSize = true;
            this.label104.Location = new System.Drawing.Point(274, 44);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(92, 17);
            this.label104.TabIndex = 27;
            this.label104.Text = "Camera Name";
            // 
            // LPRAlarmRecordNextBtn
            // 
            this.LPRAlarmRecordNextBtn.Location = new System.Drawing.Point(791, 75);
            this.LPRAlarmRecordNextBtn.Name = "LPRAlarmRecordNextBtn";
            this.LPRAlarmRecordNextBtn.Size = new System.Drawing.Size(46, 23);
            this.LPRAlarmRecordNextBtn.TabIndex = 26;
            this.LPRAlarmRecordNextBtn.Text = "Next";
            this.LPRAlarmRecordNextBtn.UseVisualStyleBackColor = true;
            this.LPRAlarmRecordNextBtn.Click += new System.EventHandler(this.LPRAlarmRecordNextBtn_Click);
            // 
            // LPRAlarmRecordPreviousBtn
            // 
            this.LPRAlarmRecordPreviousBtn.Location = new System.Drawing.Point(715, 75);
            this.LPRAlarmRecordPreviousBtn.Name = "LPRAlarmRecordPreviousBtn";
            this.LPRAlarmRecordPreviousBtn.Size = new System.Drawing.Size(75, 23);
            this.LPRAlarmRecordPreviousBtn.TabIndex = 25;
            this.LPRAlarmRecordPreviousBtn.Text = "Previous";
            this.LPRAlarmRecordPreviousBtn.UseVisualStyleBackColor = true;
            this.LPRAlarmRecordPreviousBtn.Click += new System.EventHandler(this.LPRAlarmRecordPreviousBtn_Click);
            // 
            // LPRAlarmRecordSearchBtn
            // 
            this.LPRAlarmRecordSearchBtn.Location = new System.Drawing.Point(653, 75);
            this.LPRAlarmRecordSearchBtn.Name = "LPRAlarmRecordSearchBtn";
            this.LPRAlarmRecordSearchBtn.Size = new System.Drawing.Size(59, 23);
            this.LPRAlarmRecordSearchBtn.TabIndex = 24;
            this.LPRAlarmRecordSearchBtn.Text = "Search";
            this.LPRAlarmRecordSearchBtn.UseVisualStyleBackColor = true;
            this.LPRAlarmRecordSearchBtn.Click += new System.EventHandler(this.LPRAlarmRecordSearchBtn_Click);
            // 
            // label105
            // 
            this.label105.AutoSize = true;
            this.label105.Location = new System.Drawing.Point(498, 12);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(17, 17);
            this.label105.TabIndex = 23;
            this.label105.Text = "~";
            // 
            // LPRAlarmRecordSearchEndTimeDT
            // 
            this.LPRAlarmRecordSearchEndTimeDT.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.LPRAlarmRecordSearchEndTimeDT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.LPRAlarmRecordSearchEndTimeDT.Location = new System.Drawing.Point(518, 8);
            this.LPRAlarmRecordSearchEndTimeDT.Name = "LPRAlarmRecordSearchEndTimeDT";
            this.LPRAlarmRecordSearchEndTimeDT.Size = new System.Drawing.Size(194, 23);
            this.LPRAlarmRecordSearchEndTimeDT.TabIndex = 22;
            // 
            // LPRAlarmRecordSearchBeginTimeDT
            // 
            this.LPRAlarmRecordSearchBeginTimeDT.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.LPRAlarmRecordSearchBeginTimeDT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.LPRAlarmRecordSearchBeginTimeDT.Location = new System.Drawing.Point(313, 9);
            this.LPRAlarmRecordSearchBeginTimeDT.Name = "LPRAlarmRecordSearchBeginTimeDT";
            this.LPRAlarmRecordSearchBeginTimeDT.Size = new System.Drawing.Size(173, 23);
            this.LPRAlarmRecordSearchBeginTimeDT.TabIndex = 21;
            // 
            // label106
            // 
            this.label106.AutoSize = true;
            this.label106.Location = new System.Drawing.Point(275, 12);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(36, 17);
            this.label106.TabIndex = 20;
            this.label106.Text = "Time";
            // 
            // LPRAlarmRecordDataGridView
            // 
            this.LPRAlarmRecordDataGridView.AllowUserToAddRows = false;
            this.LPRAlarmRecordDataGridView.AllowUserToDeleteRows = false;
            this.LPRAlarmRecordDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.LPRAlarmRecordDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LPRAlarmRecordDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LPRAlarmRecordPlateImageDataGVImgCol,
            this.LPRAlarmRecordPlateNoDataGVTextCol,
            this.LPRAlarmRecordPlateColorDataGVTextCol,
            this.LPRAlarmRecordPlateTypeDataGVTextCol,
            this.LPRAlarmRecordVehicleColorDataGVTextCol,
            this.LPRAlarmRecordCameraNameDataGVTextCol,
            this.LPRAlarmRecordTimeDataGVTextCol});
            this.LPRAlarmRecordDataGridView.Location = new System.Drawing.Point(6, 104);
            this.LPRAlarmRecordDataGridView.MultiSelect = false;
            this.LPRAlarmRecordDataGridView.Name = "LPRAlarmRecordDataGridView";
            this.LPRAlarmRecordDataGridView.RowHeadersVisible = false;
            this.LPRAlarmRecordDataGridView.RowTemplate.Height = 45;
            this.LPRAlarmRecordDataGridView.RowTemplate.ReadOnly = true;
            this.LPRAlarmRecordDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LPRAlarmRecordDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LPRAlarmRecordDataGridView.Size = new System.Drawing.Size(832, 414);
            this.LPRAlarmRecordDataGridView.TabIndex = 11;
            // 
            // LPRAlarmRecordPlateImageDataGVImgCol
            // 
            this.LPRAlarmRecordPlateImageDataGVImgCol.HeaderText = "Plate Image";
            this.LPRAlarmRecordPlateImageDataGVImgCol.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.LPRAlarmRecordPlateImageDataGVImgCol.Name = "LPRAlarmRecordPlateImageDataGVImgCol";
            this.LPRAlarmRecordPlateImageDataGVImgCol.ReadOnly = true;
            this.LPRAlarmRecordPlateImageDataGVImgCol.Width = 154;
            // 
            // LPRAlarmRecordPlateNoDataGVTextCol
            // 
            this.LPRAlarmRecordPlateNoDataGVTextCol.HeaderText = "Plate No.";
            this.LPRAlarmRecordPlateNoDataGVTextCol.Name = "LPRAlarmRecordPlateNoDataGVTextCol";
            this.LPRAlarmRecordPlateNoDataGVTextCol.ReadOnly = true;
            this.LPRAlarmRecordPlateNoDataGVTextCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LPRAlarmRecordPlateNoDataGVTextCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LPRAlarmRecordPlateNoDataGVTextCol.Width = 80;
            // 
            // LPRAlarmRecordPlateColorDataGVTextCol
            // 
            this.LPRAlarmRecordPlateColorDataGVTextCol.HeaderText = "Plate Color";
            this.LPRAlarmRecordPlateColorDataGVTextCol.Name = "LPRAlarmRecordPlateColorDataGVTextCol";
            this.LPRAlarmRecordPlateColorDataGVTextCol.ReadOnly = true;
            this.LPRAlarmRecordPlateColorDataGVTextCol.Width = 80;
            // 
            // LPRAlarmRecordPlateTypeDataGVTextCol
            // 
            this.LPRAlarmRecordPlateTypeDataGVTextCol.HeaderText = "Plate Type";
            this.LPRAlarmRecordPlateTypeDataGVTextCol.Name = "LPRAlarmRecordPlateTypeDataGVTextCol";
            this.LPRAlarmRecordPlateTypeDataGVTextCol.ReadOnly = true;
            this.LPRAlarmRecordPlateTypeDataGVTextCol.Width = 150;
            // 
            // LPRAlarmRecordVehicleColorDataGVTextCol
            // 
            this.LPRAlarmRecordVehicleColorDataGVTextCol.HeaderText = "Vehicle Color";
            this.LPRAlarmRecordVehicleColorDataGVTextCol.Name = "LPRAlarmRecordVehicleColorDataGVTextCol";
            this.LPRAlarmRecordVehicleColorDataGVTextCol.ReadOnly = true;
            this.LPRAlarmRecordVehicleColorDataGVTextCol.Width = 80;
            // 
            // LPRAlarmRecordCameraNameDataGVTextCol
            // 
            this.LPRAlarmRecordCameraNameDataGVTextCol.HeaderText = "Camera Name";
            this.LPRAlarmRecordCameraNameDataGVTextCol.Name = "LPRAlarmRecordCameraNameDataGVTextCol";
            this.LPRAlarmRecordCameraNameDataGVTextCol.ReadOnly = true;
            this.LPRAlarmRecordCameraNameDataGVTextCol.Width = 120;
            // 
            // LPRAlarmRecordTimeDataGVTextCol
            // 
            this.LPRAlarmRecordTimeDataGVTextCol.HeaderText = "Snapshot Time";
            this.LPRAlarmRecordTimeDataGVTextCol.Name = "LPRAlarmRecordTimeDataGVTextCol";
            this.LPRAlarmRecordTimeDataGVTextCol.ReadOnly = true;
            this.LPRAlarmRecordTimeDataGVTextCol.Width = 130;
            // 
            // Maintenance
            // 
            this.Maintenance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Maintenance.Controls.Add(this.groupBox4);
            this.Maintenance.Location = new System.Drawing.Point(4, 26);
            this.Maintenance.Name = "Maintenance";
            this.Maintenance.Padding = new System.Windows.Forms.Padding(3);
            this.Maintenance.Size = new System.Drawing.Size(899, 606);
            this.Maintenance.TabIndex = 5;
            this.Maintenance.Text = "Maintenance";
            this.Maintenance.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.factoryDefaultBtn);
            this.groupBox4.Controls.Add(this.RebootBtn);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(896, 600);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Maintenance";
            // 
            // factoryDefaultBtn
            // 
            this.factoryDefaultBtn.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.factoryDefaultBtn.Location = new System.Drawing.Point(41, 74);
            this.factoryDefaultBtn.Name = "factoryDefaultBtn";
            this.factoryDefaultBtn.Size = new System.Drawing.Size(111, 23);
            this.factoryDefaultBtn.TabIndex = 0;
            this.factoryDefaultBtn.Text = "Factory Default";
            this.factoryDefaultBtn.UseVisualStyleBackColor = true;
            this.factoryDefaultBtn.Click += new System.EventHandler(this.factoryDefaultBtn_Click);
            // 
            // RebootBtn
            // 
            this.RebootBtn.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RebootBtn.Location = new System.Drawing.Point(41, 35);
            this.RebootBtn.Name = "RebootBtn";
            this.RebootBtn.Size = new System.Drawing.Size(75, 23);
            this.RebootBtn.TabIndex = 0;
            this.RebootBtn.Text = "Reboot";
            this.RebootBtn.UseVisualStyleBackColor = true;
            this.RebootBtn.Click += new System.EventHandler(this.RebootBtn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(163, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(186, 16);
            this.label9.TabIndex = 1;
            this.label9.Text = "Restore all factory default settings";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(163, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "Restart device";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.label120);
            this.tabPage1.Controls.Add(this.groupBox38);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.comboBox2);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.dateTimePicker2);
            this.tabPage1.Controls.Add(this.label118);
            this.tabPage1.Controls.Add(this.dateTimePicker1);
            this.tabPage1.Controls.Add(this.label117);
            this.tabPage1.Controls.Add(this.label116);
            this.tabPage1.Controls.Add(this.label115);
            this.tabPage1.Controls.Add(this.textBox3);
            this.tabPage1.Controls.Add(this.label114);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.label113);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.UserID);
            this.tabPage1.Controls.Add(this.groupBox37);
            this.tabPage1.Controls.Add(this.groupBox33);
            this.tabPage1.Controls.Add(this.groupBox25);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(899, 606);
            this.tabPage1.TabIndex = 6;
            this.tabPage1.Text = "UserCfg";
            // 
            // label120
            // 
            this.label120.AutoSize = true;
            this.label120.Location = new System.Drawing.Point(15, 577);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(268, 17);
            this.label120.TabIndex = 27;
            this.label120.Text = "Note: This function is available for VMS only.";
            // 
            // groupBox38
            // 
            this.groupBox38.Controls.Add(this.label119);
            this.groupBox38.Controls.Add(this.textBox4);
            this.groupBox38.Controls.Add(this.ModifyCurPwd);
            this.groupBox38.Location = new System.Drawing.Point(7, 378);
            this.groupBox38.Name = "groupBox38";
            this.groupBox38.Size = new System.Drawing.Size(868, 54);
            this.groupBox38.TabIndex = 26;
            this.groupBox38.TabStop = false;
            // 
            // label119
            // 
            this.label119.AutoSize = true;
            this.label119.Location = new System.Drawing.Point(8, 28);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(58, 17);
            this.label119.TabIndex = 23;
            this.label119.Text = "NewPwd";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(111, 22);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(102, 23);
            this.textBox4.TabIndex = 24;
            // 
            // ModifyCurPwd
            // 
            this.ModifyCurPwd.Location = new System.Drawing.Point(764, 22);
            this.ModifyCurPwd.Name = "ModifyCurPwd";
            this.ModifyCurPwd.Size = new System.Drawing.Size(102, 23);
            this.ModifyCurPwd.TabIndex = 22;
            this.ModifyCurPwd.Text = "ModifyCurPwd";
            this.ModifyCurPwd.UseVisualStyleBackColor = true;
            this.ModifyCurPwd.Click += new System.EventHandler(this.ModifyCurPwd_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(771, 571);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(105, 23);
            this.button4.TabIndex = 25;
            this.button4.Text = "AddUserIno";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(365, 488);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(100, 25);
            this.comboBox2.TabIndex = 21;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(118, 488);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 25);
            this.comboBox1.TabIndex = 20;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "yyyy/MM/dd";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(278, 538);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(112, 23);
            this.dateTimePicker2.TabIndex = 18;
            // 
            // label118
            // 
            this.label118.AutoSize = true;
            this.label118.Location = new System.Drawing.Point(246, 543);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(17, 17);
            this.label118.TabIndex = 17;
            this.label118.Text = "~";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy/MM/dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(116, 537);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(110, 23);
            this.dateTimePicker1.TabIndex = 16;
            // 
            // label117
            // 
            this.label117.AutoSize = true;
            this.label117.Location = new System.Drawing.Point(15, 538);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(64, 17);
            this.label117.TabIndex = 15;
            this.label117.Text = "VaildData";
            // 
            // label116
            // 
            this.label116.AutoSize = true;
            this.label116.Location = new System.Drawing.Point(246, 496);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(103, 17);
            this.label116.TabIndex = 13;
            this.label116.Text = "TimeTemplateID";
            // 
            // label115
            // 
            this.label115.AutoSize = true;
            this.label115.Location = new System.Drawing.Point(15, 496);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(47, 17);
            this.label115.TabIndex = 11;
            this.label115.Text = "RoleID";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(595, 448);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 23);
            this.textBox3.TabIndex = 10;
            // 
            // label114
            // 
            this.label114.AutoSize = true;
            this.label114.Location = new System.Drawing.Point(510, 451);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(64, 17);
            this.label114.TabIndex = 9;
            this.label114.Text = "Password";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(365, 446);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 8;
            // 
            // label113
            // 
            this.label113.AutoSize = true;
            this.label113.Location = new System.Drawing.Point(246, 451);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(70, 17);
            this.label113.TabIndex = 7;
            this.label113.Text = "UserName";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(118, 446);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 6;
            // 
            // UserID
            // 
            this.UserID.AutoSize = true;
            this.UserID.Location = new System.Drawing.Point(14, 452);
            this.UserID.Name = "UserID";
            this.UserID.Size = new System.Drawing.Size(48, 17);
            this.UserID.TabIndex = 5;
            this.UserID.Text = "UserID";
            // 
            // groupBox37
            // 
            this.groupBox37.Controls.Add(this.listView3);
            this.groupBox37.Location = new System.Drawing.Point(7, 253);
            this.groupBox37.Name = "groupBox37";
            this.groupBox37.Size = new System.Drawing.Size(866, 122);
            this.groupBox37.TabIndex = 2;
            this.groupBox37.TabStop = false;
            this.groupBox37.Text = "UserInfo";
            // 
            // listView3
            // 
            this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.listView3.FullRowSelect = true;
            this.listView3.GridLines = true;
            this.listView3.Location = new System.Drawing.Point(6, 22);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(854, 97);
            this.listView3.TabIndex = 0;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            this.listView3.SelectedIndexChanged += new System.EventHandler(this.listView3_SelectedIndexChanged);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "ID";
            this.columnHeader9.Width = 150;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "UserName";
            this.columnHeader10.Width = 150;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "RoleID";
            this.columnHeader11.Width = 150;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "TimeTemplateID";
            this.columnHeader12.Width = 150;
            // 
            // groupBox33
            // 
            this.groupBox33.Controls.Add(this.listView2);
            this.groupBox33.Location = new System.Drawing.Point(7, 130);
            this.groupBox33.Name = "groupBox33";
            this.groupBox33.Size = new System.Drawing.Size(866, 122);
            this.groupBox33.TabIndex = 1;
            this.groupBox33.TabStop = false;
            this.groupBox33.Text = "Time Template";
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listView2.GridLines = true;
            this.listView2.Location = new System.Drawing.Point(6, 19);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(854, 97);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "ID";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Name";
            this.columnHeader6.Width = 150;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "IsDefault";
            this.columnHeader7.Width = 150;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Desc";
            this.columnHeader8.Width = 150;
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.listView1);
            this.groupBox25.Location = new System.Drawing.Point(7, 7);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(866, 122);
            this.groupBox25.TabIndex = 0;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "Role Info";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(7, 20);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(853, 96);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "RoleName";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Level";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Desc";
            this.columnHeader4.Width = 150;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(771, 484);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 23);
            this.button3.TabIndex = 19;
            this.button3.Text = "ModifyUserInfo";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(771, 446);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "GetUserInfo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(771, 528);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "DeleteUserInfo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupDiscovery
            // 
            this.groupDiscovery.Controls.Add(this.Discovery);
            this.groupDiscovery.Location = new System.Drawing.Point(12, 2);
            this.groupDiscovery.Name = "groupDiscovery";
            this.groupDiscovery.Size = new System.Drawing.Size(189, 57);
            this.groupDiscovery.TabIndex = 0;
            this.groupDiscovery.TabStop = false;
            // 
            // deviceOper
            // 
            this.deviceOper.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Login,
            this.Logout,
            this.Delete,
            this.toolStripSeparator4,
            this.Property});
            this.deviceOper.Name = "deviceOper";
            this.deviceOper.Size = new System.Drawing.Size(127, 98);
            this.deviceOper.Text = "deviceOper";
            // 
            // Login
            // 
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(126, 22);
            this.Login.Text = "Login";
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // Logout
            // 
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(126, 22);
            this.Logout.Text = "Logout";
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // Delete
            // 
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(126, 22);
            this.Delete.Text = "Delete";
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(123, 6);
            // 
            // Property
            // 
            this.Property.Name = "Property";
            this.Property.Size = new System.Drawing.Size(126, 22);
            this.Property.Text = "Property";
            this.Property.Click += new System.EventHandler(this.Property_Click);
            // 
            // rootOper
            // 
            this.rootOper.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LocalDevice});
            this.rootOper.Name = "rootOper";
            this.rootOper.Size = new System.Drawing.Size(149, 26);
            this.rootOper.Text = "rootOper";
            // 
            // LocalDevice
            // 
            this.LocalDevice.Name = "LocalDevice";
            this.LocalDevice.Size = new System.Drawing.Size(148, 22);
            this.LocalDevice.Text = "Local Device";
            this.LocalDevice.Click += new System.EventHandler(this.LocalDevice_Click);
            // 
            // cleanLogBtn
            // 
            this.cleanLogBtn.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cleanLogBtn.Location = new System.Drawing.Point(934, 654);
            this.cleanLogBtn.Name = "cleanLogBtn";
            this.cleanLogBtn.Size = new System.Drawing.Size(81, 30);
            this.cleanLogBtn.TabIndex = 3;
            this.cleanLogBtn.Text = "Clear";
            this.cleanLogBtn.UseVisualStyleBackColor = true;
            this.cleanLogBtn.Click += new System.EventHandler(this.cleanLogBtn_Click);
            // 
            // settingLogBtn
            // 
            this.settingLogBtn.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.settingLogBtn.Location = new System.Drawing.Point(936, 725);
            this.settingLogBtn.Name = "settingLogBtn";
            this.settingLogBtn.Size = new System.Drawing.Size(78, 30);
            this.settingLogBtn.TabIndex = 5;
            this.settingLogBtn.Text = "Setting";
            this.settingLogBtn.UseVisualStyleBackColor = true;
            this.settingLogBtn.Click += new System.EventHandler(this.settingLogBtn_Click);
            // 
            // logListView
            // 
            this.logListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Time,
            this.DeviceInfo,
            this.Operation,
            this.Status,
            this.ErrorCode});
            this.logListView.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.logListView.FullRowSelect = true;
            this.logListView.GridLines = true;
            this.logListView.HideSelection = false;
            this.logListView.Location = new System.Drawing.Point(207, 650);
            this.logListView.Name = "logListView";
            this.logListView.Size = new System.Drawing.Size(710, 115);
            this.logListView.TabIndex = 6;
            this.logListView.UseCompatibleStateImageBehavior = false;
            this.logListView.View = System.Windows.Forms.View.Details;
            // 
            // Time
            // 
            this.Time.Text = "Time";
            this.Time.Width = 141;
            // 
            // DeviceInfo
            // 
            this.DeviceInfo.Text = "Device Info";
            this.DeviceInfo.Width = 141;
            // 
            // Operation
            // 
            this.Operation.Text = "Operation";
            this.Operation.Width = 141;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 141;
            // 
            // ErrorCode
            // 
            this.ErrorCode.Text = "Error Code";
            this.ErrorCode.Width = 141;
            // 
            // PannelContextMenuStrip
            // 
            this.PannelContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Close,
            this.CloseAll,
            this.toolStripSeparator1,
            this.ProcessingMode,
            this.MakeKeyFrame,
            this.DigitalZoom,
            this.ThreeDPosition,
            this.TwoWayAudio,
            this.toolStripSeparator2,
            this.FullScreen,
            this.MultiScreen,
            this.toolStripSeparator3,
            this.CameraInfo});
            this.PannelContextMenuStrip.Name = "PannelContextMenuStrip";
            this.PannelContextMenuStrip.Size = new System.Drawing.Size(179, 242);
            this.PannelContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.PannelContextMenuStrip_Opening);
            // 
            // Close
            // 
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(178, 22);
            this.Close.Text = "Close";
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // CloseAll
            // 
            this.CloseAll.Name = "CloseAll";
            this.CloseAll.Size = new System.Drawing.Size(178, 22);
            this.CloseAll.Text = "Close All";
            this.CloseAll.Click += new System.EventHandler(this.CloseAll_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // ProcessingMode
            // 
            this.ProcessingMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowDelay,
            this.Fluent});
            this.ProcessingMode.Name = "ProcessingMode";
            this.ProcessingMode.Size = new System.Drawing.Size(178, 22);
            this.ProcessingMode.Text = "Processing Mode";
            // 
            // ShowDelay
            // 
            this.ShowDelay.Checked = true;
            this.ShowDelay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowDelay.Name = "ShowDelay";
            this.ShowDelay.Size = new System.Drawing.Size(143, 22);
            this.ShowDelay.Text = "Show Delay";
            this.ShowDelay.Click += new System.EventHandler(this.ShowDelay_Click);
            // 
            // Fluent
            // 
            this.Fluent.Name = "Fluent";
            this.Fluent.Size = new System.Drawing.Size(143, 22);
            this.Fluent.Text = "Fluent";
            this.Fluent.Click += new System.EventHandler(this.Fluent_Click);
            // 
            // MakeKeyFrame
            // 
            this.MakeKeyFrame.Name = "MakeKeyFrame";
            this.MakeKeyFrame.Size = new System.Drawing.Size(178, 22);
            this.MakeKeyFrame.Text = "Make Key Frame";
            this.MakeKeyFrame.Click += new System.EventHandler(this.MakeKeyFrame_Click);
            // 
            // DigitalZoom
            // 
            this.DigitalZoom.Name = "DigitalZoom";
            this.DigitalZoom.Size = new System.Drawing.Size(178, 22);
            this.DigitalZoom.Text = "Digital Zoom";
            this.DigitalZoom.Click += new System.EventHandler(this.DigitalZoom_Click);
            // 
            // ThreeDPosition
            // 
            this.ThreeDPosition.Name = "ThreeDPosition";
            this.ThreeDPosition.Size = new System.Drawing.Size(178, 22);
            this.ThreeDPosition.Text = "3D Position";
            this.ThreeDPosition.Click += new System.EventHandler(this.ThreeDPosition_Click);
            // 
            // TwoWayAudio
            // 
            this.TwoWayAudio.Name = "TwoWayAudio";
            this.TwoWayAudio.Size = new System.Drawing.Size(178, 22);
            this.TwoWayAudio.Text = "Two-way Audio";
            this.TwoWayAudio.Click += new System.EventHandler(this.TwoWayAudio_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(175, 6);
            // 
            // FullScreen
            // 
            this.FullScreen.Name = "FullScreen";
            this.FullScreen.Size = new System.Drawing.Size(178, 22);
            this.FullScreen.Text = "Full Screen";
            this.FullScreen.Click += new System.EventHandler(this.FullScreen_Click);
            // 
            // MultiScreen
            // 
            this.MultiScreen.Checked = true;
            this.MultiScreen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MultiScreen.Name = "MultiScreen";
            this.MultiScreen.Size = new System.Drawing.Size(178, 22);
            this.MultiScreen.Text = "Multi-Screen";
            this.MultiScreen.Click += new System.EventHandler(this.MultiScreen_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(175, 6);
            // 
            // CameraInfo
            // 
            this.CameraInfo.Name = "CameraInfo";
            this.CameraInfo.Size = new System.Drawing.Size(178, 22);
            this.CameraInfo.Text = "Camera Info";
            this.CameraInfo.Click += new System.EventHandler(this.CameraInfo_Click);
            // 
            // NetDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 767);
            this.Controls.Add(this.logListView);
            this.Controls.Add(this.groupDiscovery);
            this.Controls.Add(this.mainTabCtrl);
            this.Controls.Add(this.DeviceTree);
            this.Controls.Add(this.cleanLogBtn);
            this.Controls.Add(this.settingLogBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "NetDemo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NetDemo V2.6.0.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NetDemo_FormClosing);
            this.mainTabCtrl.ResumeLayout(false);
            this.LiveView.ResumeLayout(false);
            this.groupBox39.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.PresetGBox.ResumeLayout(false);
            this.PresetGBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PTZSpeedTrackBar)).EndInit();
            this.PannelPlayCtrl.ResumeLayout(false);
            this.PannelPlayCtrl.PerformLayout();
            this.group_win.ResumeLayout(false);
            this.group_win.PerformLayout();
            this.groupSound.ResumeLayout(false);
            this.groupSound.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SliSoundVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SliMicVolume)).EndInit();
            this.Playback.ResumeLayout(false);
            this.Playback.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PBVideoTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBVolTrackBar)).EndInit();
            this.Configure.ResumeLayout(false);
            this.cfgTabControl.ResumeLayout(false);
            this.ConfigBasic.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.ConfigNetwork.ResumeLayout(false);
            this.ConfigNetwork.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.ConfigVideo.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.ConfigImage.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SharpnessTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContrastTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaturationTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessTrackBar)).EndInit();
            this.ConfigOSD.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.ConfigIO.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.ConfigPrivacyMask.ResumeLayout(false);
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.ConfigMotion.ResumeLayout(false);
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MotionHistoryTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MotionObjectSizeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MotionSensitivityTrackBar)).EndInit();
            this.ConfigTemper.ResumeLayout(false);
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TemperSensitivityTrackBar)).EndInit();
            this.AlarmRecords.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.VCA.ResumeLayout(false);
            this.VCATabCtrl.ResumeLayout(false);
            this.PeopleCountingforReport.ResumeLayout(false);
            this.PeopleCountingforReport.PerformLayout();
            this.PeopleCountingforStatistics.ResumeLayout(false);
            this.PeopleCountingforStatistics.PerformLayout();
            this.FaceTabPage.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.FaceRealtimeMonitoringTabPage.ResumeLayout(false);
            this.groupBox27.ResumeLayout(false);
            this.groupBox26.ResumeLayout(false);
            this.groupBox24.ResumeLayout(false);
            this.groupBox23.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.personLibPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.snapshotPictureBox)).EndInit();
            this.groupBox22.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.faceSnapshotSmallPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.faceSnapshotLargePictureBox)).EndInit();
            this.FaceLibraryManagenentTabPage.ResumeLayout(false);
            this.groupBox20.ResumeLayout(false);
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personInfoImagePictureBox)).EndInit();
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.FaceMonitoringTaskTabPage.ResumeLayout(false);
            this.FaceMonitoringTaskTabPage.PerformLayout();
            this.FaceAlarmRecordTabPage.ResumeLayout(false);
            this.FaceAlarmRecordTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.faceAlarmRecordDataGridView)).EndInit();
            this.FacePassThruRecordTabPage.ResumeLayout(false);
            this.FacePassThruRecordTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facePassThruRecordDataGridView)).EndInit();
            this.LicensePlateRecognitionTabPage.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.LPRRealtimeMonitoringTabPage.ResumeLayout(false);
            this.groupBox31.ResumeLayout(false);
            this.groupBox32.ResumeLayout(false);
            this.groupBox34.ResumeLayout(false);
            this.groupBox35.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vehiclePanoRecogPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plateRecogPicBox)).EndInit();
            this.groupBox36.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plateSnapshotSmallPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleSnapshotLargePictureBox)).EndInit();
            this.LPRVehicleLibraryManagemnetTabPage.ResumeLayout(false);
            this.groupBox28.ResumeLayout(false);
            this.groupBox29.ResumeLayout(false);
            this.groupBox29.PerformLayout();
            this.groupBox30.ResumeLayout(false);
            this.groupBox30.PerformLayout();
            this.LPRMonitoringTaskTabPage.ResumeLayout(false);
            this.LPRMonitoringTaskTabPage.PerformLayout();
            this.LPRAlarmAndPassThruRecordTabPage.ResumeLayout(false);
            this.LPRAlarmAndPassThruRecordTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LPRAlarmRecordDataGridView)).EndInit();
            this.Maintenance.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox38.ResumeLayout(false);
            this.groupBox38.PerformLayout();
            this.groupBox37.ResumeLayout(false);
            this.groupBox33.ResumeLayout(false);
            this.groupBox25.ResumeLayout(false);
            this.groupDiscovery.ResumeLayout(false);
            this.deviceOper.ResumeLayout(false);
            this.rootOper.ResumeLayout(false);
            this.PannelContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Discovery;
        private System.Windows.Forms.TreeView DeviceTree;
        private System.Windows.Forms.TabControl mainTabCtrl;
        private System.Windows.Forms.TabPage LiveView;
        private System.Windows.Forms.TabPage Configure;
        private System.Windows.Forms.TabPage AlarmRecords;
        private System.Windows.Forms.TabPage VCA;
        private System.Windows.Forms.TabPage Maintenance;
        private System.Windows.Forms.GroupBox groupDiscovery;
        private System.Windows.Forms.GroupBox PannelPlayCtrl;
        private System.Windows.Forms.Button RealPlay;
        private System.Windows.Forms.Button CapturePicture;
        private System.Windows.Forms.Button StopRealPlay;
        private System.Windows.Forms.Button LocalRecodBtn;
        private System.Windows.Forms.Button Sequence;
        private System.Windows.Forms.GroupBox group_win;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxMultiScreen;
        private System.Windows.Forms.GroupBox groupSound;
        private System.Windows.Forms.TrackBar SliMicVolume;
        private System.Windows.Forms.Button MicVolumeBtn;
        private System.Windows.Forms.TrackBar SliSoundVolume;
        private System.Windows.Forms.Button SoundBtn;
        private System.Windows.Forms.FlowLayoutPanel LayoutPanel;
        private System.Windows.Forms.ContextMenuStrip deviceOper;
        private System.Windows.Forms.ContextMenuStrip rootOper;
        private System.Windows.Forms.ToolStripMenuItem Login;
        private System.Windows.Forms.ToolStripMenuItem Logout;
        private System.Windows.Forms.ToolStripMenuItem Delete;
        private System.Windows.Forms.ToolStripMenuItem LocalDevice;
        private System.Windows.Forms.Button cleanLogBtn;
        private System.Windows.Forms.Button settingLogBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button PTZUBtn;
        private System.Windows.Forms.Button ptzLUBtn;
        private System.Windows.Forms.TrackBar PTZSpeedTrackBar;
        private System.Windows.Forms.Button PTZRDBtn;
        private System.Windows.Forms.Button PTZRBtn;
        private System.Windows.Forms.Button PTZRUBtn;
        private System.Windows.Forms.Button PTZDBtn;
        private System.Windows.Forms.Button PTZStopBtn;
        private System.Windows.Forms.Button PTZLDBtn;
        private System.Windows.Forms.Button PTZLBtn;
        private System.Windows.Forms.GroupBox PresetGBox;
        private System.Windows.Forms.Button presetSetBtn;
        private System.Windows.Forms.Button presetGetBtn;
        private System.Windows.Forms.TextBox presetNameText;
        private System.Windows.Forms.Button presetDeleteBtn;
        private System.Windows.Forms.Button presetGoToBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button focusFarBtn;
        private System.Windows.Forms.Button MoreBtn;
        private System.Windows.Forms.Button zoomTeleBtn;
        private System.Windows.Forms.Button focusNearBtn;
        private System.Windows.Forms.Button zoomWideBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private ListView logListView;
        private ColumnHeader Time;
        private ColumnHeader DeviceInfo;
        private ColumnHeader Operation;
        private ColumnHeader Status;
        private ColumnHeader ErrorCode;
        private GroupBox groupBox4;
        private Button factoryDefaultBtn;
        private Button RebootBtn;
        private Label label8;
        private Label label9;
        private TabControl VCATabCtrl;
        private TabPage PeopleCountingforReport;
        private TabPage PeopleCountingforStatistics;
        private Label label10;
        private Button VCARegCallBackBtn;
        private ListView VCAReportDataListView;
        private ColumnHeader DeviceIP;
        private ColumnHeader ChannelID;
        private ColumnHeader ReportTime;
        private ColumnHeader IntervalTime;
        private ColumnHeader EnterNumber;
        private ColumnHeader ExitNumber;
        private ColumnHeader TotalEnterNumber;
        private ColumnHeader TotalExitNumber;
        private Label label15;
        private Button VCAClearDataBtn;
        private Button VCACloseCallBackBtn;
        private DateTimePicker VCAStatisticalTime;
        private ComboBox VCAReportType;
        private ListView VCAStatisticDataListView;
        private Button VCACountBtn;
        private Label label16;
        private ComboBox VCACountingType;
        private Label label11;
        private Label label17;
        private Label label18;
        private ColumnHeader StatisticalTime;
        private ColumnHeader PeopleEntered;
        private ColumnHeader PeopleLeft;
        private GroupBox groupBox5;
        private ListView AlarmRecordsListView;
        private ColumnHeader AlarmRecordTime;
        private ColumnHeader AlarmRecordIP;
        private ColumnHeader AlarmRecordChannelID;
        private ColumnHeader AlarmRecordInfo;
        private Button AlarmRecordsClearBtn;
        private TabControl cfgTabControl;
        private TabPage ConfigBasic;
        private TabPage ConfigNetwork;
        private TabPage ConfigVideo;
        private TabPage ConfigImage;
        private TabPage ConfigOSD;
        private TabPage ConfigIO;
        private TabPage ConfigPrivacyMask;
        private TabPage ConfigMotion;
        private TabPage ConfigTemper;
        private GroupBox groupBox6;
        private ComboBox BasicGMTCobBox;
        private GroupBox groupBox7;
        private TextBox BasicDeviceNameText;
        private Button BasicDeviceNameSaveBtn;
        private Button BasicSysTimeSaveBtn;
        private DateTimePicker BasicTime;
        private DateTimePicker BasicDate;
        private Button BaiscRefreshBtn;
        private GroupBox groupBox8;
        private ListView BasicHDInfoListView;
        private ColumnHeader HardDiskNo;
        private ColumnHeader HardDiskTotalCapacity;
        private ColumnHeader HardDiskFreeSpace;
        private ColumnHeader HardDiskStatus;
        private ColumnHeader HardDiskManufacturer;
        private CheckBox NetDHCPCkBox;
        private Label label19;
        private Button NetSaveBtn;
        private GroupBox groupBox9;
        private ComboBox NetPortHTTPCobBox;
        private TextBox NetIPAddText;
        private Label label21;
        private Label label20;
        private Label label22;
        private GroupBox groupBox10;
        private Label label27;
        private Label label28;
        private Label label29;
        private Label label25;
        private Label label24;
        private Label label26;
        private TextBox NetMTUText;
        private TextBox NetGatwayText;
        private TextBox NetSubMaskText;
        private Label label23;
        private TextBox NetPortHTTPText;
        private Label label30;
        private TextBox NetPortRTSPText;
        private TextBox NetPortHTTPSText;
        private ComboBox NetPortRTSPCobBox;
        private ComboBox NetPortHTTPSCobBox;
        private Button NetworkRefreshBtn;
        private Button NetNTPSaveBtn;
        private TextBox NetNTPServerIPText;
        private CheckBox NetNTPDHCPCkBox;
        private ComboBox NetNTPIPTypeCobBox;
        private Button NetPortSaveBtn;
        private GroupBox groupBox11;
        private TextBox VideoResolutionWText;
        private ComboBox VideoStreamIndexCobBox;
        private Label label31;
        private Button VideoSaveBtn;
        private TextBox VideoResolutionHText;
        private TextBox VideoGopText;
        private TextBox VideoFrameRateText;
        private TextBox VideoBitRateText;
        private Label label42;
        private ComboBox VideoQualityCobBox;
        private Label label40;
        private ComboBox VideoEncodeFormatCobBox;
        private Label label37;
        private Label label41;
        private Label label39;
        private Label label34;
        private Label label36;
        private Label label35;
        private Label label38;
        private Label label33;
        private Label label32;
        private Button VideoRefreshBtn;
        private GroupBox groupBox12;
        private TextBox BrightnessText;
        private Label label43;
        private TrackBar BrightnessTrackBar;
        private Button ImageRefreshBtn;
        private Button ImageSaveBtn;
        private Label label50;
        private Label label48;
        private Label label46;
        private Label label44;
        private TextBox SharpnessText;
        private TextBox ContrastText;
        private TextBox SaturationText;
        private Label label49;
        private Label label47;
        private Label label45;
        private TrackBar SharpnessTrackBar;
        private TrackBar ContrastTrackBar;
        private TrackBar SaturationTrackBar;
        private ComboBox OSDTimeCobBox;
        private Button OSDRefreshBtn;
        private GroupBox groupBox13;
        private TextBox OSDTimePointYText;
        private Label label53;
        private TextBox OSDTimePointXText;
        private Label label52;
        private Label label51;
        private ComboBox OSDDateCobBox;
        private Button OSDSaveBtn;
        private TextBox OSDText6PointY;
        private TextBox OSDText5PointY;
        private TextBox OSDText4PointY;
        private TextBox OSDText3PointY;
        private TextBox OSDText2PointY;
        private TextBox OSDText1PointY;
        private TextBox OSDNamePointYText;
        private Label label74;
        private Label label71;
        private Label label68;
        private Label label65;
        private Label label62;
        private Label label59;
        private Label label56;
        private TextBox OSDText6;
        private TextBox OSDText6PointX;
        private TextBox OSDText5;
        private TextBox OSDText5PointX;
        private TextBox OSDText4;
        private TextBox OSDText4PointX;
        private TextBox OSDText3;
        private TextBox OSDText3PointX;
        private Label label73;
        private TextBox OSDText2;
        private Label label70;
        private TextBox OSDText2PointX;
        private Label label67;
        private TextBox OSDText1;
        private Label label64;
        private TextBox OSDText1PointX;
        private Label label61;
        private Label label72;
        private TextBox OSDNameText;
        private Label label69;
        private Label label58;
        private Label label66;
        private TextBox OSDNamePointXText;
        private Label label63;
        private Label label55;
        private Label label60;
        private Label label57;
        private Label label54;
        private Button IORefreshBtn;
        private GroupBox groupBox15;
        private GroupBox groupBox14;
        private Button IOAlarmOutputSaveBtn;
        private Button IOAlarmOutputTriggerBtn;
        private TextBox IOAlarmOutputChannelID;
        private TextBox IOAlarmOutputNameText;
        private Label label77;
        private ComboBox IOAlarmOutputIndexCobBox;
        private Label label76;
        private Label label75;
        private ListView IOAlarmInputListView;
        private ColumnHeader AlarmName;
        private TextBox IOAlarmOutputDelayText;
        private Label label78;
        private ComboBox IOAlarmOutputStatusCobBox;
        private Label label79;
        private Button PrivacyMaskRefreshBtn;
        private GroupBox groupBox16;
        private Button PrivacyMaskSaveBtn;
        private Button PrivacyMaskDelBtn;
        private Button PrivacyMaskAddBtn;
        private ListView privacyMaskInfoListView;
        private ColumnHeader PrivacyMaskNo;
        private ColumnHeader PrivacyMaskLeftTopX;
        private ColumnHeader PrivacyMaskLeftTopY;
        private ColumnHeader PrivacyMaskRightBottomX;
        private ColumnHeader PrivacyMaskRightBottomY;
        private Button MotionRefreshBtn;
        private GroupBox groupBox17;
        private Button MotionSaveBtn;
        private Label label81;
        private Label label82;
        private Label label83;
        private TextBox MotionHistoryText;
        private TextBox MotionObjectSizeText;
        private TextBox MotionSensitivityText;
        private Label label85;
        private Label label86;
        private Label label87;
        private TrackBar MotionHistoryTrackBar;
        private TrackBar MotionObjectSizeTrackBar;
        private TrackBar MotionSensitivityTrackBar;
        private GroupBox groupBox18;
        private Button TemperSaveBtn;
        private Label label80;
        private TextBox TemperSensitivityText;
        private Label label89;
        private TrackBar TemperSensitivityTrackBar;
        private Button TemperRefreshBtn;
        private ImageList imageList1;
        private ContextMenuStrip PannelContextMenuStrip;
        private ToolStripMenuItem Close;
        private ToolStripMenuItem CloseAll;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem ProcessingMode;
        private ToolStripMenuItem MakeKeyFrame;
        private ToolStripMenuItem DigitalZoom;
        private ToolStripMenuItem ThreeDPosition;
        private ToolStripMenuItem TwoWayAudio;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem FullScreen;
        private ToolStripMenuItem MultiScreen;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem CameraInfo;
        private ToolStripMenuItem ShowDelay;
        private ToolStripMenuItem Fluent;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem Property;
        private ComboBox presetIDCobBox;
        private CheckBox OSDTimeCheckBox;
        private CheckBox OSDText6CheckBox;
        private CheckBox OSDText5CheckBox;
        private CheckBox OSDText4CheckBox;
        private CheckBox OSDText3CheckBox;
        private CheckBox OSDText2CheckBox;
        private CheckBox OSDText1CheckBox;
        private CheckBox OSDNameCheckBox;
        private TextBox privacyMaskSubItemText;
        private Button privacyMaskModifyBtn;
        private Button inputPcmBtn;
        private TabPage FaceTabPage;
        private TabPage LicensePlateRecognitionTabPage;
        private TabControl tabControl1;
        private TabPage FaceLibraryManagenentTabPage;
        private TabPage FaceMonitoringTaskTabPage;
        private GroupBox groupBox20;
        private Button delPersonInfoBtn;
        private Button modifyPersonInfoBtn;
        private Button addPersonInfoBtn;
        private Button findPersonInfoBtn;
        private GroupBox groupBox21;
        private TextBox personInfoCityText;
        private TextBox personInfoIDNoText;
        private Label personInfoCityLab;
        private Label personInfoIDNoLab;
        private ComboBox personInfoIDTypeCmb;
        private TextBox personInfoNationalityText;
        private TextBox personInfoProvinceText;
        private Label personInfoProvinceLab;
        private Label personInfoNationalityLab;
        private Label personInfoIDTypeLab;
        private Label personInfoGenderLab;
        private TextBox personInfoNameText;
        private Label personInfoBirthdayLab;
        private Label personInfoNameLab;
        private ListView personInfoListView;
        private ColumnHeader PersonName;
        private ColumnHeader PersonGender;
        private ColumnHeader PersonDateOfBirth;
        private ColumnHeader PersonNationality;
        private ColumnHeader PersonProvince;
        private ColumnHeader PersonCity;
        private ColumnHeader PersonIDType;
        private ColumnHeader PersonIDNo;
        private GroupBox groupBox19;
        private ComboBox personLibCmb;
        private Button delPersonLibBtn;
        private Button modifyPersonLibBtn;
        private Button addPersonLibBtn;
        private Button findPersonLibBtn;
        private Label faceMonitorTaskObjectLab;
        private Label faceMonitorTaskRemarksLab;
        private Label faceMonitorTaskTypeLab;
        private Label faceMonitorTaskNameLab;
        private ComboBox faceMonitorObjectCmbBox;
        private ComboBox faceMonitorTypeCmbBox;
        private TextBox faceMonitorRemarksTextBox;
        private TextBox faceMonitorTaskNameTextBox;
        private TextBox faceMonitorThresholdTextBox;
        private Label label84;
        private Button addFaceMonitorBtn;
        private ListView faceMonitorInfoListView;
        private Button FindFaceMonitorBtn;
        private Button delFaceMonitorBtn;
        private Button modifyFaceMonitorBtn;
        private TabPage FaceRealtimeMonitoringTabPage;
        private GroupBox groupBox23;
        private ListView faceRecogAlarmRecordsListView;
        private ColumnHeader FaceRecogMatchRecordAlarmTimeCHeader;
        private ColumnHeader FaceRecogMatchRecordNameCHeader;
        private ColumnHeader FaceRecogMatchRecordIDNoCHeader;
        private ColumnHeader FaceRecogMatchRecordMatchCHeader;
        private ColumnHeader FaceRecogMatchRecordAlarmSourceCHeader;
        private PictureBox personLibPictureBox;
        private PictureBox snapshotPictureBox;
        private GroupBox groupBox22;
        private FlowLayoutPanel faceRecogRealPlayFLayoutPanel;
        private GroupBox groupBox27;
        private Button faceSnapshotSubBtn;
        private Button faceSnapshotUnSubBtn;
        private GroupBox groupBox26;
        private Button faceRecogSubBtn;
        private Button faceRecogUnSubBtn;
        private GroupBox groupBox24;
        private Button faceRecogRealPlayStartBtn;
        private Button faceRecogRealPlayStopBtn;
        private Label similarityLab;
        private ComboBox personInfoGenderCmb;
        private TabControl tabControl2;
        private TabPage LPRVehicleLibraryManagemnetTabPage;
        private TabPage LPRMonitoringTaskTabPage;
        private TabPage LPRRealtimeMonitoringTabPage;
        private TextBox PersonLibNameText;
        private GroupBox groupBox28;
        private Button delVehicleInfoBtn;
        private Button modifyVehicleInfoBtn;
        private Button addVehicleInfoBtn;
        private Button FindVehicleInfoBtn;
        private GroupBox groupBox29;
        private ComboBox PlateTypeCmb;
        private ComboBox vehicleColorCmb;
        private Label label94;
        private Label label95;
        private TextBox plateNoText;
        private Label label97;
        private ListView vehicleInfoListView;
        private ColumnHeader LPRVehicleInfoPlateNoColHeader;
        private ColumnHeader LPRVehicleInfoPlateColorColHeader;
        private ColumnHeader LPRVehicleInfoPlateTypeColHeader;
        private ColumnHeader LPRVehicleInfoVehicleColorColHeader;
        private ColumnHeader LPRVehicleInfoStatusColHeader;
        private GroupBox groupBox30;
        private TextBox vehicleLibNameText;
        private ComboBox vehicleLibCmb;
        private Button delVehicleLibBtn;
        private Button modifyVehicleLibBtn;
        private Button addVehicleLibBtn;
        private Button FindVehicleLibBtn;
        private ComboBox plateAreaCmb;
        private ComboBox plateColorCmb;
        private Label label98;
        private ColumnHeader LPRmonitorTaskNameColHeader;
        private ColumnHeader LPRmonitorTaskRemarksColHeader;
        private ColumnHeader LPRmonitorThresholdColHeader;
        private ColumnHeader LPRmonitorObjectColHeader;
        private ColumnHeader LPRmonitorStatusColHeader;
        private Button disableFaceMonitorBtn;
        private Button enableFaceMonitorBtn;
        private Button disableVehicleMonitorBtn;
        private Button enableVehicleMonitorBtn;
        private Button DelVehicleMonitorBtn;
        private Button modifyVehicleMonitorBtn;
        private Button FindVehicleMonitorBtn;
        private ListView vehicleMonitorInfoListView;
        private ColumnHeader vehicleMonitorTaskNameColHeader;
        private ColumnHeader vehicleMonitorRemarksColHeader;
        private ColumnHeader vehicleMonitorTypeColHeader;
        private ColumnHeader vehicleMonitorStatusColHeader;
        private Button addVehicleMonitorBtn;
        private ComboBox vehicleMonitorObjectCmbBox;
        private ComboBox vehicleMonitorTypeCmbBox;
        private TextBox vehicleMonitorRemarksText;
        private TextBox vehicleMonitorTaskNameText;
        private Label label90;
        private Label label91;
        private Label label92;
        private Label label93;
        private ComboBox vehicleCauseCmbBox;
        private Label label88;
        private GroupBox groupBox31;
        private Button LPRSnapshotSubBtn;
        private Button LPRSnapshotUnSubBtn;
        private GroupBox groupBox32;
        private Button LPRRecogSubBtn;
        private Button LPRRecogUnSubBtn;
        private GroupBox groupBox34;
        private Button LPRRealPlayStartBtn;
        private Button LPRRealPlayStopBtn;
        private GroupBox groupBox35;
        private ListView LPRAlarmRecordsListView;
        private ColumnHeader plateNoAlarmRecordColHeader;
        private ColumnHeader plateColorAlarmRecordColHeader;
        private ColumnHeader plateMatchAlarmRecordColHeader;
        private ColumnHeader plateTypeAlarmRecordColHeader;
        private GroupBox groupBox36;
        private FlowLayoutPanel LPRRealPlayFLayoutPanel;
        private ColumnHeader VehicleColorAlarmRecordColHeader;
        private ColumnHeader LPRCameraNameAlarmRecordColHeader;
        private ColumnHeader LPRSnapshotTimeAlarmRecordColHeader;
        private ColumnHeader LPRCauseAlarmRecordColHeader;
        private PictureBox personInfoImagePictureBox;
        private ColumnHeader personInfoIDColHeader;
        private TextBox personInfoBirthText;
        private Button nextPersonInfoBtn;
        private Button previousPersonInfoBtn;
        private ColumnHeader LPRmonitorTaskIDColHeader;
        private TextBox faceMonitorTaskLibNameText;
        private PictureBox faceSnapshotSmallPictureBox;
        private PictureBox faceSnapshotLargePictureBox;
        private PictureBox plateSnapshotSmallPictureBox;
        private PictureBox vehicleSnapshotLargePictureBox;
        private TextBox vehicleMonitorTaskLibNameText;
        private ColumnHeader LPRVehicleInfoPlateIDColHeader;
        private ColumnHeader vehicleMonitorTaskIDColHeader;
        private Label plateNoRecogLab;
        private PictureBox plateRecogPicBox;
        private PictureBox vehiclePanoRecogPicBox;
        private Label faceSnapshotPicTimeLab;
        private Label vehicleSnapshotPicTimeLab;
        private TabPage FaceAlarmRecordTabPage;
        private DataGridView faceAlarmRecordDataGridView;
        private ComboBox faceAlarmRecordMonitorTypeCmbBox;
        private Label label100;
        private DateTimePicker faceAlarmRecordEndTimeDT;
        private DateTimePicker faceAlarmRecordBeginTimeDT;
        private Label label99;
        private Label label96;
        private Button faceAlarmRecordNextBtn;
        private Button faceAlarmRecordPreviousBtn;
        private Button faceAlarmRecordSearchBtn;
        private TabPage FacePassThruRecordTabPage;
        private TextBox facePassThruRecordAlarmSourceText;
        private Label label103;
        private Button facePassThruRecordNextBtn;
        private Button facePassThruRecordPreviousBtn;
        private Button facePassThruRecordSearchBtn;
        private Label label101;
        private DateTimePicker facePassThruRecordEndTimeDT;
        private DateTimePicker facePassThruRecordBeginTimeDT;
        private Label label102;
        private DataGridView facePassThruRecordDataGridView;
        private DataGridViewImageColumn faceAlarmRecordSnapImageDataGVImgCol;
        private DataGridViewImageColumn faceAlarmRecordLibImageDataGVImgCol;
        private DataGridViewTextBoxColumn faceAlarmRecordTimeDataGVTextCol;
        private DataGridViewTextBoxColumn faceAlarmRecordSourceDataGVTextCol;
        private DataGridViewTextBoxColumn faceAlarmRecordNameDataGVTextCol;
        private DataGridViewTextBoxColumn faceAlarmRecordIDNoDataGVTextCol;
        private DataGridViewTextBoxColumn faceAlarmRecordMatchDataGVTextCol;
        private DataGridViewImageColumn facePassThruRecordPanoImageDataGVImgCol;
        private DataGridViewImageColumn facePassThruRecordFaceImageDataGVImgCol;
        private DataGridViewTextBoxColumn facePassThruRecordTimeDataGVTextCol;
        private DataGridViewTextBoxColumn facePassThruRecordAlarmSourceDataGVTextCol;
        private TabPage LPRAlarmAndPassThruRecordTabPage;
        private DataGridView LPRAlarmRecordDataGridView;
        private TextBox LPRAlarmRecordSearchPlateNoText;
        private Label label107;
        private TextBox LPRAlarmRecordSearchCameraNameText;
        private Label label104;
        private Button LPRAlarmRecordNextBtn;
        private Button LPRAlarmRecordPreviousBtn;
        private Button LPRAlarmRecordSearchBtn;
        private Label label105;
        private DateTimePicker LPRAlarmRecordSearchEndTimeDT;
        private DateTimePicker LPRAlarmRecordSearchBeginTimeDT;
        private Label label106;
        private ComboBox LPRAlarmRecordSearchTypeCmbBox;
        private Label label110;
        private ComboBox LPRAlarmRecordSearchVehicleColorCmbBox;
        private Label label109;
        private ComboBox LPRAlarmRecordSearchPlateColorCmbBox;
        private Label label108;
        private Label label111;
        private ComboBox LPRAlarmRecordMonitoringCauseCmbBox;
        private Label label112;
        private ComboBox LPRAlarmRecordMonitoringTypeCmbBox;
        private DataGridViewImageColumn LPRAlarmRecordPlateImageDataGVImgCol;
        private DataGridViewTextBoxColumn LPRAlarmRecordPlateNoDataGVTextCol;
        private DataGridViewTextBoxColumn LPRAlarmRecordPlateColorDataGVTextCol;
        private DataGridViewTextBoxColumn LPRAlarmRecordPlateTypeDataGVTextCol;
        private DataGridViewTextBoxColumn LPRAlarmRecordVehicleColorDataGVTextCol;
        private DataGridViewTextBoxColumn LPRAlarmRecordCameraNameDataGVTextCol;
        private DataGridViewTextBoxColumn LPRAlarmRecordTimeDataGVTextCol;
        private TabPage tabPage1;
        private GroupBox groupBox25;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private GroupBox groupBox37;
        private ListView listView3;
        private GroupBox groupBox33;
        private ListView listView2;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader4;
        private Button button2;
        private Button button1;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private Label UserID;
        private Label label116;
        private Label label115;
        private TextBox textBox3;
        private Label label114;
        private TextBox textBox2;
        private Label label113;
        private TextBox textBox1;
        private Label label117;
        private Button button3;
        private DateTimePicker dateTimePicker2;
        private Label label118;
        private DateTimePicker dateTimePicker1;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private Button ModifyCurPwd;
        private TextBox textBox4;
        private Label label119;
        private Button button4;
        private GroupBox groupBox38;
        private GroupBox groupBox39;
        private Button ButtonStopVoice;
        private Button ButtoncaptureNoPreview;
        private Button ButtonStartVoice;
        private Button ButtonStoprecord;
        private Button ButtonStartrecrod;
        private Label label120;
        private TabPage Playback;
        private Button GetRecordDays;
        private ComboBox BoxPositionList;
        private FlowLayoutPanel playBackLayoutPanel;
        private GroupBox groupBox3;
        private Button PBDownLoadStopBtn;
        private Button PBDownLoadInfoBtn;
        private Button PBDownLoadStartBtn;
        private ListView PBVideoTimeListView;
        private ColumnHeader BeginTime;
        private ColumnHeader EndTime;
        private Button PBQueryBtn;
        private TrackBar PBVideoTrackBar;
        private TrackBar PBVolTrackBar;
        private ComboBox PBEventType;
        private DateTimePicker PBEndTime;
        private DateTimePicker PBEndDate;
        private DateTimePicker PBBeginTime;
        private DateTimePicker PBBeginDate;
        private Label PBShowFBSpeedLabel;
        private Label label12;
        private Label PBRemainingTimeLabel;
        private Label label13;
        private Label PBVideoDateTimeLabel;
        private Label label14;
        private Label label7;
        private Button PBVolBtn;
        private Button PBFrameBtn;
        private Button PBRestartBtn;
        private Button PBCaptureBtn;
        private Button PBFastForwardBtn;
        private Button PBFastBackwardBtn;
        private Button PBStopBtn;
        private Button PBPauseBtn;
        private Button PBStartBtn;
        private Button GetHDDSmartInfo;
    }
}

