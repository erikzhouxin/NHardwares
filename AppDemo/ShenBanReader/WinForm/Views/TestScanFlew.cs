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
using System.Data.ShenBanReader;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShenBanReader.WinForm.Views
{
    public partial class TestScanFlew : UserControl
    {
        Thread _downloadService;
        CancellationTokenSource _downloadCts;
        Thread _guardianService;
        CancellationTokenSource _guardianCts;
        Thread _uploadService;
        CancellationTokenSource _uploadCts;
        bool _isInitialize;
        public TestScanFlew()
        {
            InitializeComponent();
        }
        private void TestScanner_Load(object sender, EventArgs e)
        {
            if (!_isInitialize)
            {
                _isInitialize = true;
                LoggerCaller.UseFile();
                _downloadCts = new CancellationTokenSource();
                _downloadService = new Thread(async () => await DownloadServiceAsync(_downloadCts.Token));
                _downloadService.IsBackground = true;
                _downloadService.Start();
                _guardianCts = new CancellationTokenSource();
                _guardianService = new Thread(async () => await GuardianServiceAsync(_guardianCts.Token));
                _guardianService.IsBackground = true;
                _guardianService.Start();
                _uploadCts = new CancellationTokenSource();
                _uploadService = new Thread(async () => await UploadServiceAsync(_uploadCts.Token));
                _uploadService.IsBackground = true;
                _uploadService.Start();
            }
        }
        #region // 服务内容
        static ICacheModel<TLocalRfids> _rfidModel = CacheModel<TLocalRfids>.Concurrent;
        static string _rfidPath = System.IO.Path.GetFullPath("TLocalRfids.json");
        static string _rfidSetting = System.IO.Path.GetFullPath("TLocalSettings.json");
        static Dictionary<string, ShenBanReaderContent> RfidDic { get; } = new Dictionary<string, ShenBanReaderContent>();
        static IEnumerable<ShenBanReaderContent> Rfids { get => RfidDic.Values.ToList(); }
        static TLocalSettings Setting { get; } = GetRfidSetting();
        async Task DownloadServiceAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var tagKeys = _rfidModel.GetKeys() ?? new List<string>();
                    if (!System.IO.File.Exists(_rfidPath))
                    { System.IO.File.WriteAllText(_rfidPath, new List<TLocalRfids>() { GetDefaultRfid(false), GetDefaultRfid(true) }.GetJsonFormatString()); }
                    var srcModels = System.IO.File.ReadAllText(_rfidPath).GetJsonObject<List<TLocalRfids>>();
                    foreach (var item in srcModels)
                    {
                        _rfidModel.Set(item.Uuid, item);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                await Task.Delay(600 * 1000, stoppingToken);
            }
        }
        private static TLocalRfids GetDefaultRfid(bool isCom)
        {
            return new TLocalRfids
            {
                Id = isCom ? 0 : 1,
                Uuid = Guid.NewGuid().ToString(),
                Address = isCom ? "COM1" : "192.168.1.178",
                Port = isCom ? 12800 : 4001,
                Ant = 0,
                AreaId = 1,
                AreaName = "测试区域",
                BehindAccount = "",
                BehindAddress = "",
                BehindPassword = "",
                BehindPort = 0,
                BehindRemark = "",
                EditName = "周鑫",
                Editor = 1,
                EditTime = DateTime.Now,
                Flag = 0,
                FrontAccount = "",
                FrontAddress = "",
                FrontPassword = "",
                FrontPort = 0,
                FrontRemark = "",
                KeyCode = "",
                Name = isCom ? "串口测试" : "网口测试",
                Remark = "",
                Status = 0,
                Version = isCom ? 0 : 1,
            };
        }
        private static TLocalSettings GetRfidSetting()
        {
            if (!System.IO.File.Exists(_rfidSetting))
            { System.IO.File.WriteAllText(_rfidSetting, new TLocalSettings().GetJsonFormatString()); }
            return System.IO.File.ReadAllText(_rfidSetting).GetJsonObject<TLocalSettings>();
        }
        async Task GuardianServiceAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(1000); // 等下载一下
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var infos = new List<TLocalRfids>();
                    foreach (var item in _rfidModel.GetKeys())
                    {
                        var model = _rfidModel.Get(item);
                        if (model == null) { continue; }
                        infos.Add(model);
                    }
                    var list = infos.Select(s => s.Uuid).ToList();
                    foreach (var item in RfidDic.Keys.ToList()) // 移除掉已经释放的
                    {
                        if (!list.Contains(item))
                        {
                            if (RfidDic.Remove(item, out var work))
                            {
                                work.Dispose();
                            }
                        }
                    }
                    foreach (var info in infos)
                    {
                        if (RfidDic.TryGetValue(info.Uuid, out ShenBanReaderContent work))
                        {
                            work.Update(info); // 设置更新
                            continue;
                        }
                        RfidDic[info.Uuid] = new ShenBanReaderContent(info);
                    }
                    var tasks = new List<Task>();
                    foreach (var item in RfidDic.Values.ToList())
                    {
                        tasks.Add(Task.Factory.StartNew(() => item.Starting()));
                    }
                    await Task.WhenAll(tasks);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                await Task.Delay(Setting.ChangeInterval * 100, stoppingToken);
            }
        }
        async Task UploadServiceAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(1000); // 等下载一下
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var locker = CacheConcurrentLockModel<TestScanFlew>.Get(nameof(UploadServiceAsync));
                    if (Monitor.TryEnter(locker, TimeSpan.FromSeconds(1)))
                    {
                        try
                        {
                            Thread.Sleep(1000);
                        }
                        finally
                        {
                            Monitor.Exit(locker);
                        }
                    }
                    var statusDic = new List<TDeviceRfids>();
                    foreach (var item in Rfids)
                    {
                        var status = item.Status;
                        statusDic.Add(new TDeviceRfids
                        {
                            Uuid = item.Model.Uuid,
                            Status = status.Item1,
                            Remark = status.Item2,
                            FrontRemark = status.Item3,
                            BehindRemark = status.Item4,
                        });
                    }
                    if (statusDic.IsNotEmpty())
                    {
                        Thread.Sleep(1000);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                await Task.Delay(Setting.UploadInterval, stoppingToken);
            }
        }
        #endregion
        internal class ShenBanReaderContent
        {
            static readonly string KeyString = new byte[] { (byte)'Z', (byte)'C', (byte)'P', (byte)'D' }.GetHexString();

            readonly ConcurrentDictionary<string, TakePictureInfo> KeyDic = new();

            private object _locker;
            private TLocalRfids _model;
            private TLocalRfids _updated;
            private IR600Reader _reader;
            private Thread _workingThread;
            private Thread _captureThread;
            private HashSet<string> _tags = new HashSet<string>();
            private int _readId = 1;
            private Tuble<int, string, string, string> _status;
            public ShenBanReaderContent(TLocalRfids info)
            {
                _locker = new object();
                _reader = ReaderBuilder.GetR600Reader(new R600CallAction
                {
                    ReceiveCallback = ReceiveCallback,
                    SendCallback = SendCallback,
                    AlertCallbackError = AlertCallbackError,
                    AlertError = AlertError,
                    FastSwitchInventory = InventoryReal,
                    FastSwitchInventoryEnd = InventoryRealEnd,
                    InventoryReal = InventoryReal,
                    InventoryRealEnd = InventoryRealEnd,
                    SetWorkAntenna = SetWorkAntenna
                });
                _model = info;
                _status = new Tuble<int, string, string, string>(info.Status, info.Remark, info.FrontRemark, info.BehindRemark);
                _workingThread = new Thread(new ThreadStart(DoJumpWorking))
                {
                    IsBackground = true
                };
                _captureThread = new Thread(DoCapture)
                {
                    IsBackground = true
                };
            }
            public TDeviceRfids Model { get => _model; }
            public ITuble<int, string, string, string> Status { get => _status.Clone(); }
            public void Dispose()
            {
                _reader.Dispose();
            }
            public bool Update(TLocalRfids info)
            {
                var compareRes = IsConfigDiff(_model, info);
                _updated = info;
                if (compareRes.Item1 || compareRes.Item2 || compareRes.Item3 || compareRes.Item4)
                {
                    Console.WriteLine($"[{_model.Name}]配置发生变更");
                    Console.WriteLine(new { New = info, Old = _model });
                    return true;
                }
                return false;
            }
            public bool Starting()
            {
                if (Monitor.TryEnter(_locker, TimeSpan.FromSeconds(1)))
                {
                    try
                    {
                        var compareRes = IsConfigDiff(_model, _updated);
                        _model = _updated ?? _model;
                        if ((_status.Item1 & 2) > 0 || !_reader.IsConnected || compareRes.Item1)
                        {
                            if (!ConnectRfidDevice()) { return false; }
                        }
                        if (!_workingThread.IsAlive)
                        {
                            _workingThread.Start();
                        }
                        if (!_captureThread.IsAlive)
                        {
                            _captureThread.Start();
                        }
                        return true;
                    }
                    finally
                    {
                        Monitor.Exit(_locker);
                    }
                }
                return false;
            }
            private void SetRfidStatus(bool isSuccess, string message)
            {
                _model.Remark = (_status.Item2 = message);
                _model.Status = (isSuccess ? (_status.Item1 &= ~2) : (_status.Item1 |= 2));
            }
            private void SetFrontCameraStatus(bool isSuccess, string message)
            {
                _model.FrontRemark = (_status.Item3 = message);
                _model.Status = (isSuccess ? (_status.Item1 &= ~4) : (_status.Item1 |= 4));
            }
            private void SetBehindCameraStatus(bool isSuccess, string message)
            {
                _model.BehindRemark = (_status.Item4 = message);
                _model.Status = (isSuccess ? (_status.Item1 &= ~8) : (_status.Item1 |= 8));
            }
            /// <summary>
            /// 跳转工作内容
            /// </summary>
            private void DoJumpWorking()
            {
                while (true)
                {
                    // 准备设置值,防止中途变更
                    var isReadLine = _model.Ant != 0;
                    var ants = GetAntennaTypes(_model.Ant);
                    var reconnInterval = 10 * 100;
                    var inInterval = 3 * 100;
                    var result = -1;
                    try
                    {
                        // 盘点
                        if (isReadLine)
                        {
                            foreach (var item in ants)
                            {
                                _reader.SetWorkAntenna((byte)_readId, (byte)item);
                                Thread.Sleep(50);
                                var curr = _reader.InventoryReal((byte)_readId, 1);
                                if (curr >= 0) { result = 0; }
                                Thread.Sleep(50);
                            }
                        }
                        else
                        {
                            result = _reader.FastSwitchInventory(1, new byte[] { 0, 1, 1, 1, 2, 1, 3, 1, 0, 1 });
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{nameof(ShenBanReaderContent)}:{nameof(DoJumpWorking)}:{nameof(IR600Reader.FastSwitchInventory)}");
                        Console.WriteLine(ex);
                        continue;
                    }
                    if (result < 0)
                    {
                        Starting();
                        Thread.Sleep(reconnInterval * 2); // 防止频繁操作,此时可当做重连了
                        continue;
                    }
                    Thread.Sleep(inInterval * 2);// 稍作休整
                }
            }

            private ReadAntennaType[] GetAntennaTypes(int ant)
            {
                var result = new List<ReadAntennaType>();
                if ((ant & 1) > 0) { result.Add(ReadAntennaType.L1); }
                if ((ant & 2) > 0) { result.Add(ReadAntennaType.L2); }
                if ((ant & 4) > 0) { result.Add(ReadAntennaType.L3); }
                if ((ant & 8) > 0) { result.Add(ReadAntennaType.L4); }
                if (result.Count > 0) { return result.ToArray(); }
                return new ReadAntennaType[]
                {
                ReadAntennaType.L1,
                ReadAntennaType.L2,
                ReadAntennaType.L3,
                ReadAntennaType.L4,
                };
            }

            private bool ConnectRfidDevice()
            {
                if (_model.Address.StartsWith("COM"))
                {
                    if (!_reader.Connect(_model.Address, _model.Port, out string comMsg))
                    {
                        SetRfidStatus(false, comMsg);
                        Console.WriteLine($"{nameof(ShenBanReaderContent)}:{_model.Address}:{_model.Port}---------{comMsg}");
                        Console.WriteLine(_model);
                        return false;
                    }
                    SetRfidStatus(true, comMsg);
                    Console.WriteLine($"{nameof(ShenBanReaderContent)}:{_model.Address}:{_model.Port}---------{comMsg}");
                    Console.WriteLine(_model);
                    return true;
                }
                IPAddress.TryParse(_model.Address, out var ipAddress);
                if (!_reader.Connect(ipAddress, _model.Port, out string msg))
                {
                    SetRfidStatus(false, msg);
                    Console.WriteLine($"{nameof(ShenBanReaderContent)}:{_model.Address}:{_model.Port}---------{msg}");
                    Console.WriteLine(_model);
                    return false;
                }
                SetRfidStatus(true, msg);
                Console.WriteLine($"{nameof(ShenBanReaderContent)}:{_model.Address}:{_model.Port}---------{msg}");
                Console.WriteLine(_model);
                return true;
            }
            private Tuble<bool, bool, bool, bool> IsConfigDiff(TLocalRfids model, TLocalRfids info)
            {
                if (model == null || info == null) { return new Tuble<bool, bool, bool, bool>(true, true, true, true); }
                var rfidChange = false;
                if (model.Address != info.Address) { rfidChange = true; }
                if (model.Port != info.Port) { rfidChange = true; }

                var antChange = false;
                if (model.Ant != info.Ant) { antChange = true; } // 理论上天线变更不管,但需要重新赋值

                var frontChange = false;
                if (model.FrontAddress != info.FrontAddress) { frontChange = true; }
                if (model.FrontPort != info.FrontPort) { frontChange = true; }
                if (model.FrontAccount != info.FrontAccount) { frontChange = true; }
                if (model.FrontPassword != info.FrontPassword) { frontChange = true; }

                var behindChange = false;
                if (model.BehindAddress != info.BehindAddress) { behindChange = true; }
                if (model.BehindPort != info.BehindPort) { behindChange = true; }
                if (model.BehindAccount != info.BehindAccount) { behindChange = true; }
                if (model.BehindPassword != info.BehindPassword) { behindChange = true; }
                return new Tuble<bool, bool, bool, bool>(rfidChange, frontChange, behindChange, antChange);
            }
            #region // 回调方法
            private void SetWorkAntenna(IReadMessage obj)
            {
                _readId = obj.ReadId;
            }
            private void InventoryReal(IReadMessage msg, R600TagInfo tag)
            {
                _readId = msg.ReadId;
                if (tag.EPC == null || !tag.TakeEpc(16)) { return; }
                new Task(() => InventoryRecords(tag)).Start();
                _tags.Add(tag.Key);
            }
            private void InventoryRecords(R600TagInfo tag)
            {
                TLocalScanRecords record = null;
                try
                {
                    // 判断卡内容是否是新增
                    var cacheKey = GetCacheKey(tag.Key);
                    var cacheLock = CacheConcurrentLockModel<ShenBanReaderContent>.Get(cacheKey);
                    if (Monitor.TryEnter(cacheLock, TimeSpan.FromMilliseconds(100))) // 转流可能正在进行,所以可以释放掉
                    {
                        try
                        {
                            var timeout = 30;
                            var cardCache = CacheModel.Concurrent.Get<TLocalScanRecords>(cacheKey);
                            var currentTime = DateTime.Now;
                            if (cardCache != null && (currentTime - cardCache.ScanTime).TotalMinutes < timeout) { return; }
                            if (!tag.Key.StartsWith(KeyString)) // 不符合标签内容规格
                            {
                                Console.WriteLine($"{nameof(InventoryRecords)}:{tag.Key}:扫描到不符合资产管理内容的标签");
                                return;
                            }
                            var tid = tag.EPC.GetHexString().Substring(KeyString.Length);
                            record = new TLocalScanRecords()
                            {
                                Uuid = Guid.NewGuid().GetString(),
                                ScanUuid = _model.Uuid,
                                Epc = tag.Key,
                                TidCode = tid,
                                AssetCode = String.Empty,
                                AssetName = String.Empty,
                                LastAreaId = 0,
                                DealReason = String.Empty,
                                IsDeal = false,
                                DealTime = currentTime,
                                DealType = 0,
                                DealUserId = 0,
                                Photos = string.Empty,
                                Remarks = string.Empty,
                                ScanAreaId = _model.AreaId,
                                ScanTime = currentTime,
                                Type = 1,
                                UploadFlag = 0,
                                UploadTime = currentTime,
                                Extra = tag.GetJsonString(),
                            };
                            CacheModel.Concurrent.Set(cacheKey, record, new DateTimeOffset(DateTime.Now.AddHours(1)));
                            SaveScanRecord(record);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(new { record, tag, ex });
                        }
                        finally
                        {
                            Monitor.Exit(cacheLock);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(new { record, tag, ex });
                }
            }

            private void SaveScanRecord(TLocalScanRecords record)
            {
                var key = $"{record.ScanUuid}:{record.Epc}";
                // 去拍第一张照片(如果已经有的话就完结去)
                SaveLastAndRemove(key);
                var result = new TakePictureInfo
                {
                    Key = key,
                    Time = DateTime.Now,
                    Count = 3,
                };
                KeyDic[key] = result;
                Console.WriteLine($"保存扫描记录=>{new { record, result }.GetJsonFormatString()}");
                Thread.Sleep(1000);
            }

            private string GetCacheKey(string key) => $"RFID:Record:{_model.Uuid}:{key}";

            private void InventoryRealEnd(IReadMessage msg, int arg2, int arg3)
            {
                _readId = msg.ReadId;
                TakeEndPicture(_tags.ToArray());
                _tags.Clear();
            }

            private void AlertError(ReadAlertError alert)
            {
                Console.WriteLine(alert);
            }
            private void AlertCallbackError(Exception ex)
            {
                Console.WriteLine(ex);
            }
            private void ReceiveCallback(byte[] aryData)
            {
                Console.WriteLine($"接收数据回调[{aryData.GetHexString()}]");
            }
            private void SendCallback(byte[] aryData)
            {
                Console.WriteLine($"发送数据回调[{aryData.GetHexString()}]");
            }
            #endregion
            #region // 内部方法
            private void TakeEndPicture(string[] keys)
            {
                var endTimes = 3;
                var inTimeout = 30;
                keys = keys.Select(s => $"{_model.Uuid}:{s}").ToArray();
                foreach (var item in KeyDic.Values.ToList())
                {
                    if (keys.Contains(item.Key))
                    {
                        if (!item.IsShutdown) { item.Count = endTimes; }
                    }
                    else
                    {
                        if (item.HasThird && item.HasSecond)
                        {
                            if ((--item.Count) == 0) // 可以继续减,只有等于零会处理它
                            {
                                item.IsShutdown = true;
                                SaveLastAndRemove(item.Key);
                            }
                        }
                    }
                    if ((DateTime.Now - item.Time).TotalMinutes > inTimeout)
                    {
                        SaveLastAndRemove(item.Key);
                    }
                }
            }

            private void SaveLastAndRemove(string key)
            {
                if (KeyDic.TryRemove(key, out var item))// 如果是它移除的,便进行保存
                {
                    if (item == null) { return; }
                    Console.WriteLine($"保存最后一张截图并移除=>{item.GetJsonFormatString()}");
                    Thread.Sleep(1000);
                }
            }
            private void DoCapture()
            {
                while (true)
                {
                    var secondInterval = 20 * 100;
                    var thirdInterval = 50 * 100;
                    var interval = 5 * 100;
                    try
                    {
                        foreach (var item in KeyDic.Values.ToList())
                        {
                            var keyMain = $"RFID:Capture:{item.Key}:";
                            var key2Lock = CacheConcurrentLockModel<ShenBanReaderContent>.Get(keyMain + "Second");
                            if (Monitor.TryEnter(key2Lock)) // 第二张照片已经在处理就不需要别的在做了
                            {
                                if (!item.HasSecond && (DateTime.Now - item.Time).TotalMilliseconds > secondInterval)
                                {
                                    Console.WriteLine($"保存第二张截图并移除=>{item.GetJsonFormatString()}");
                                    Thread.Sleep(1000);
                                    item.HasSecond = true;
                                }
                                Monitor.Exit(key2Lock);
                            }
                            var key5Lock = CacheConcurrentLockModel<ShenBanReaderContent>.Get(keyMain + "Third");
                            if (Monitor.TryEnter(key5Lock)) // 第三张照片已经在处理就不需要别的在做了,后摄像头拍第三张
                            {
                                if (!item.HasThird && (DateTime.Now - item.Time).TotalMilliseconds > thirdInterval)
                                {
                                    Console.WriteLine($"保存第三张截图并移除=>{item.GetJsonFormatString()}");
                                    Thread.Sleep(1000);
                                    item.HasThird = true;
                                }
                                Monitor.Exit(key5Lock);
                            }
                        }
                    }
                    catch { }
                    Thread.Sleep(interval); // 休息一会
                }
            }
            #endregion
            #region // 内部类
            /// <summary>
            /// 截图信息
            /// </summary>
            internal class TakePictureInfo
            {
                public string Key { get; set; }
                public DateTime Time { get; set; }
                public int Count { get; set; }
                //public List<string> Photos { get; set; }
                public bool HasSecond { get; set; }
                public bool HasThird { get; set; }
                public bool IsShutdown { get; set; }
            }
            #endregion
        }
        #region // 辅助定义
        public class TLocalSettings
        {
            /// <summary>
            /// 更新数量
            /// </summary>
            public virtual Int32 UploadCount { get; set; } = 20;
            /// <summary>
            /// 上传间隔(单位秒)
            /// </summary>
            public virtual Int32 UploadInterval { get; set; } = 600 * 1000;
            /// <summary>
            /// 上传内容上线(单位秒)
            /// </summary>
            public virtual Int32 UploadCeiling { get; set; } = 60 * 1000;
            /// <summary>
            /// 下载间隔(单位秒)
            /// </summary>
            public virtual Int32 DownloadInterval { get; set; } = 600 * 1000;
            /// <summary>
            /// 最小功率
            /// </summary>
            public int MinPower { get; set; } = 10;
            /// <summary>
            /// 默认功率
            /// </summary>
            public int DefaultPower { get; set; } = 30;
            /// <summary>
            /// 最大功率
            /// </summary>
            public int MaxPower { get; set; } = 32;
            /// <summary>
            /// 扫描频率(单位百毫秒)
            /// 默认1秒
            /// </summary>
            public int ScanInterval { get; set; } = 10;
            /// <summary>
            /// 变更频率(单位百毫秒)
            /// 默认1分钟
            /// </summary>
            public int ChangeInterval { get; set; } = 600;
            /// <summary>
            /// 读取频率(单位百毫秒)
            /// 默认300毫秒
            /// </summary>
            public int ReadInterval { get; set; } = 3;
            /// <summary>
            /// 缓存过期间隔(单位小时)
            /// 默认3小时
            /// </summary>
            public Int32 CachedInterval { get; set; } = 3;
            /// <summary>
            /// 是读天线
            /// </summary>
            public bool IsReadLine { get; set; } = true;
            /// <summary>
            /// 超时时间(分钟)
            /// </summary>
            public int TimeOut { get; set; } = 30;
            /// <summary>
            /// 读天线内容
            /// 1=>天线一
            /// 2=>天线二
            /// 4=>天线三
            /// 4=>天线四
            /// </summary>
            public int ReadLine { get; set; } = 15;
            /// <summary>
            /// 结束次数
            /// </summary>
            public int EndTimes { get; set; } = 3;
            /// <summary>
            /// 截图间隔(单位百毫秒)
            /// 默认500毫秒
            /// </summary>
            public Int32 CaptureInterval { get; set; } = 5;
            /// <summary>
            /// 截图第二张间隔(单位百毫秒)
            /// 默认两秒
            /// </summary>
            public Int32 CaptureSecondInterval { get; set; } = 20;
            /// <summary>
            /// 截图第三张间隔(单位百毫秒)
            /// 默认五秒
            /// </summary>
            public Int32 CaptureThirdInterval { get; set; } = 50;
            /// <summary>
            /// 截图失败超过次数将重启
            /// </summary>
            public Int32 CaptureFailedCount { get; set; } = 2;
        }
        /// <summary>
        /// 预警记录
        /// </summary>
        [Table("t_scan_record")]
        [DbCol("预警记录", Name = "t_scan_record")]
        public partial class TScanRecord : ICloneable
        {
            /// <summary>
            /// 自增
            /// </summary>
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Display(Name = "自增")]
            [Column("id")]
            [DbCol("自增", Key = DbIxType.APK, Type = DbColType.Int64)]
            public virtual Int64 Id { get; set; }
            /// <summary>
            /// 唯一标识
            /// </summary>
            [Display(Name = "唯一标识")]
            [Column("uuid")]
            [DbCol("唯一标识", Len = 50)]
            public virtual String Uuid { get; set; }
            /// <summary>
            /// 扫描设备标识
            /// </summary>
            [Display(Name = "扫描设备标识")]
            [Column("scan_uuid")]
            [DbCol("扫描设备标识", Name = "scan_uuid", Len = 50)]
            public virtual String ScanUuid { get; set; }
            /// <summary>
            /// 扫描到的区域id
            /// </summary>
            [Display(Name = "扫描到的区域id")]
            [Column("scan_area_id")]
            [DbCol("扫描到的区域id", Name = "scan_area_id", Type = DbColType.Int32)]
            public virtual Int32 ScanAreaId { get; set; }
            /// <summary>
            /// 扫描到的时间
            /// </summary>
            [Display(Name = "扫描到的时间")]
            [Column("scan_time")]
            [DbCol("扫描到的时间", Name = "scan_time", Type = DbColType.DateTime)]
            public virtual DateTime ScanTime { get; set; }
            /// <summary>
            /// 扫描标签TID
            /// </summary>
            [Display(Name = "扫描标签TID")]
            [Column("tid_code")]
            [DbCol("扫描标签TID", Name = "tid_code")]
            public virtual String TidCode { get; set; }
            /// <summary>
            /// 资产编号
            /// </summary>
            [Display(Name = "资产编号")]
            [Column("asset_code")]
            [DbCol("资产编号", Name = "asset_code", Len = 255)]
            public virtual String AssetCode { get; set; }
            /// <summary>
            /// 资产名称
            /// </summary>
            [Display(Name = "资产名称")]
            [Column("asset_name")]
            [DbCol("资产名称", Name = "asset_name", Len = 255)]
            public virtual String AssetName { get; set; }
            /// <summary>
            /// 上次区域位置
            /// </summary>
            [Display(Name = "上次区域位置")]
            [Column("last_area_id")]
            [DbCol("上次区域位置", Name = "last_area_id", Type = DbColType.Int32)]
            public virtual Int32 LastAreaId { get; set; }
            /// <summary>
            /// 类型1异常报警2位置变更
            /// </summary>
            [Display(Name = "类型1异常报警2位置变更")]
            [Column("type")]
            [DbCol("类型1异常报警2位置变更", Type = DbColType.Int32)]
            public virtual Int32 Type { get; set; }
            /// <summary>
            /// 是否处理
            /// </summary>
            [Display(Name = "是否处理")]
            [Column("is_deal")]
            [DbCol("是否处理", Name = "is_deal", Type = DbColType.Boolean, IsReq = false)]
            public virtual Boolean? IsDeal { get; set; }
            /// <summary>
            /// 处理人
            /// </summary>
            [Display(Name = "处理人")]
            [Column("deal_user_id")]
            [DbCol("处理人", Name = "deal_user_id", Type = DbColType.Int32, IsReq = false)]
            public virtual Int32? DealUserId { get; set; }
            /// <summary>
            /// 处理时间
            /// </summary>
            [Display(Name = "处理时间")]
            [Column("deal_time")]
            [DbCol("处理时间", Name = "deal_time", Type = DbColType.DateTime, IsReq = false)]
            public virtual DateTime? DealTime { get; set; }
            /// <summary>
            /// 处理类型
            /// </summary>
            [Display(Name = "处理类型")]
            [Column("deal_type")]
            [DbCol("处理类型", Name = "deal_type", Type = DbColType.Int32, IsReq = false)]
            public virtual Int32? DealType { get; set; }
            /// <summary>
            /// 处理手填的内容
            /// </summary>
            [Display(Name = "处理手填的内容")]
            [Column("deal_reason")]
            [DbCol("处理手填的内容", Name = "deal_reason", Type = DbColType.StringNormal, IsReq = false)]
            public virtual String DealReason { get; set; }
            object ICloneable.Clone() { return this.Clone(); }
            /// <summary>
            /// 浅表复制
            /// </summary>
            public TScanRecord Clone() { return (TScanRecord)this.MemberwiseClone(); }
        }
        /// <summary>
        /// 本地扫描记录表
        /// </summary>
        [Table("t_local_scan_records")]
        [DbCol("本地扫描记录表", Name = "t_local_scan_records")]
        public class TLocalScanRecords : TScanRecord
        {
            /// <summary>
            /// 自增
            /// </summary>
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Display(Name = "自增")]
            [Column("id")]
            [DbCol("自增", Key = DbIxType.APK, Type = DbColType.Int64)]
            public override Int64 Id { get; set; }
            /// <summary>
            /// 唯一标识
            /// </summary>
            [Display(Name = "唯一标识")]
            [Column("uuid")]
            [DbCol("唯一标识", Len = 50)]
            public override String Uuid { get; set; }
            /// <summary>
            /// EPC内容
            /// </summary>
            [Display(Name = "EPC内容")]
            [Column("epc")]
            [DbCol("EPC内容", Name = "epc", Len = 64)]
            public virtual String Epc { get; set; }
            /// <summary>
            /// 扫描到的区域id
            /// </summary>
            [Display(Name = "扫描到的区域id")]
            [Column("scan_area_id")]
            [DbCol("扫描到的区域id", Name = "scan_area_id", Type = DbColType.Int32)]
            public override Int32 ScanAreaId { get; set; }
            /// <summary>
            /// 扫描到的时间
            /// </summary>
            [Display(Name = "扫描到的时间")]
            [Column("scan_time")]
            [DbCol("扫描到的时间", Name = "scan_time", Type = DbColType.DateTime)]
            public override DateTime ScanTime { get; set; }
            /// <summary>
            /// 资产编号
            /// </summary>
            [Display(Name = "资产编号")]
            [Column("asset_code")]
            [DbCol("资产编号", Name = "asset_code", Len = 255)]
            public override String AssetCode { get; set; }
            /// <summary>
            /// 资产名称
            /// </summary>
            [Display(Name = "资产名称")]
            [Column("asset_name")]
            [DbCol("资产名称", Name = "asset_name", Len = 255)]
            public override String AssetName { get; set; }
            /// <summary>
            /// 上次区域位置
            /// </summary>
            [Display(Name = "上次区域位置")]
            [Column("last_area_id")]
            [DbCol("上次区域位置", Name = "last_area_id", Type = DbColType.Int32)]
            public override Int32 LastAreaId { get; set; }
            /// <summary>
            /// 类型1异常报警2位置变更
            /// </summary>
            [Display(Name = "类型1异常报警2位置变更")]
            [Column("type")]
            [DbCol("类型1异常报警2位置变更", Type = DbColType.Int32)]
            public override Int32 Type { get; set; }
            /// <summary>
            /// 是否处理
            /// </summary>
            [Display(Name = "是否处理")]
            [Column("is_deal")]
            [DbCol("是否处理", Name = "is_deal", Type = DbColType.Boolean, IsReq = false)]
            public override Boolean? IsDeal { get; set; }
            /// <summary>
            /// 处理人
            /// </summary>
            [Display(Name = "处理人")]
            [Column("deal_user_id")]
            [DbCol("处理人", Name = "deal_user_id", Type = DbColType.Int32, IsReq = false)]
            public override Int32? DealUserId { get; set; }
            /// <summary>
            /// 处理时间
            /// </summary>
            [Display(Name = "处理时间")]
            [Column("deal_time")]
            [DbCol("处理时间", Name = "deal_time", Type = DbColType.DateTime, IsReq = false)]
            public override DateTime? DealTime { get; set; }
            /// <summary>
            /// 处理类型
            /// </summary>
            [Display(Name = "处理类型")]
            [Column("deal_type")]
            [DbCol("处理类型", Name = "deal_type", Type = DbColType.Int32, IsReq = false)]
            public override Int32? DealType { get; set; }
            /// <summary>
            /// 处理手填的内容
            /// </summary>
            [Display(Name = "处理手填的内容")]
            [Column("deal_reason")]
            [DbCol("处理手填的内容", Name = "deal_reason", Type = DbColType.StringNormal)]
            public override String DealReason { get; set; }
            /// <summary>
            /// 照片标识,字符数组
            /// </summary>
            [Display(Name = "照片列表,字符数组")]
            [Column("photos")]
            [DbCol("照片列表,字符数组", Name = "photos", Len = 1024)]
            public virtual String Photos { get; set; }
            /// <summary>
            /// 上传标识
            /// </summary>
            [Display(Name = "上传标识")]
            [Column("upload_flag")]
            [DbCol("上传标识", Name = "upload_flag", Type = DbColType.DateTime)]
            public virtual int UploadFlag { get; set; }
            /// <summary>
            /// 上传时间
            /// </summary>
            [Display(Name = "上传时间")]
            [Column("upload_time")]
            [DbCol("上传时间", Name = "upload_time", Type = DbColType.DateTime)]
            public virtual DateTime UploadTime { get; set; }
            /// <summary>
            /// 附加信息
            /// </summary>
            [Display(Name = "附加信息")]
            [Column("extra")]
            [DbCol("附加信息", Type = DbColType.StringNormal)]
            public virtual String Extra { get; set; }
            /// <summary>
            /// 原因
            /// </summary>
            [Display(Name = "原因")]
            [Column("remarks")]
            [DbCol("原因", Len = 255)]
            public virtual String Remarks { get; set; }
        }
        /// <summary>
        /// RFID配置内容
        /// </summary>
        [DbCol("RFID配置内容", Name = "t_local_rfids")]
        public partial class TLocalRfids : TDeviceRfids
        {
            /// <summary>
            /// 标识
            /// </summary>
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Display(Name = "标识")]
            [Column("id")]
            [DbCol("标识", Key = DbIxType.APK, Type = DbColType.Int32)]
            public override Int32 Id { get; set; }
            /// <summary>
            /// 唯一标识
            /// </summary>
            [Display(Name = "唯一标识")]
            [Column("uuid")]
            [DbCol("唯一标识", Key = DbIxType.UIX)]
            public override String Uuid { get; set; }
            /// <summary>
            /// 终端授权码
            /// </summary>
            [Display(Name = "终端授权码")]
            [Column("key_code")]
            [DbCol("终端授权码", Name = "key_code")]
            public override String KeyCode { get; set; }
            /// <summary>
            /// 仪器名称
            /// </summary>
            [Display(Name = "仪器名称")]
            [Column("name")]
            [DbCol("仪器名称")]
            public override String Name { get; set; }
            /// <summary>
            /// IP地址/串口号
            /// </summary>
            [Display(Name = "IP地址/串口号")]
            [Column("address")]
            [DbCol("IP地址/串口号")]
            public override String Address { get; set; }
            /// <summary>
            /// 端口/波特率
            /// </summary>
            [Display(Name = "端口/波特率")]
            [Column("port")]
            [DbCol("端口/波特率", Type = DbColType.Int32)]
            public override Int32 Port { get; set; }
            /// <summary>
            /// 逻辑天线,0:快速四天线,1:天线一,2:天线二,4:天线三,8:天线四
            /// </summary>
            [Display(Name = "逻辑天线,0:快速四天线,1:天线一,2:天线二,4:天线三,8:天线四")]
            [Column("ant")]
            [DbCol("逻辑天线,0:快速四天线,1:天线一,2:天线二,4:天线三,8:天线四", Type = DbColType.Int32)]
            public override Int32 Ant { get; set; }
            /// <summary>
            /// 安装区域标识
            /// </summary>
            [Display(Name = "安装区域标识")]
            [Column("area_id")]
            [DbCol("安装区域标识", Name = "area_id", Type = DbColType.Int32)]
            public override Int32 AreaId { get; set; }
            /// <summary>
            /// 安装区域名称
            /// </summary>
            [Display(Name = "安装区域名称")]
            [Column("area_name")]
            [DbCol("安装区域名称", Name = "area_name")]
            public override String AreaName { get; set; }
            /// <summary>
            /// 前摄像头IP地址
            /// </summary>
            [Display(Name = "前摄像头IP地址")]
            [Column("front_address")]
            [DbCol("前摄像头IP地址", Name = "front_address")]
            public override String FrontAddress { get; set; }
            /// <summary>
            /// 前摄像头端口号
            /// </summary>
            [Display(Name = "前摄像头端口号")]
            [Column("front_port")]
            [DbCol("前摄像头端口号", Name = "front_port", Type = DbColType.Int32)]
            public override Int32 FrontPort { get; set; }
            /// <summary>
            /// 前摄像头账号
            /// </summary>
            [Display(Name = "前摄像头账号")]
            [Column("front_account")]
            [DbCol("前摄像头账号", Name = "front_account")]
            public override String FrontAccount { get; set; }
            /// <summary>
            /// 前摄像头密码
            /// </summary>
            [Display(Name = "前摄像头密码")]
            [Column("front_password")]
            [DbCol("前摄像头密码", Name = "front_password")]
            public override String FrontPassword { get; set; }
            /// <summary>
            /// 前摄像头备注
            /// </summary>
            [Display(Name = "前摄像头备注")]
            [Column("front_remark")]
            [DbCol("前摄像头备注", Name = "front_remark", Len = 255)]
            public override String FrontRemark { get; set; }
            /// <summary>
            /// 后摄像头IP地址
            /// </summary>
            [Display(Name = "后摄像头IP地址")]
            [Column("behind_address")]
            [DbCol("后摄像头IP地址", Name = "behind_address")]
            public override String BehindAddress { get; set; }
            /// <summary>
            /// 后摄像头端口号
            /// </summary>
            [Display(Name = "后摄像头端口号")]
            [Column("behind_port")]
            [DbCol("后摄像头端口号", Name = "behind_port", Type = DbColType.Int32)]
            public override Int32 BehindPort { get; set; }
            /// <summary>
            /// 后摄像头账号
            /// </summary>
            [Display(Name = "后摄像头账号")]
            [Column("behind_account")]
            [DbCol("后摄像头账号", Name = "behind_account")]
            public override String BehindAccount { get; set; }
            /// <summary>
            /// 后摄像头密码
            /// </summary>
            [Display(Name = "后摄像头密码")]
            [Column("behind_password")]
            [DbCol("后摄像头密码", Name = "behind_password")]
            public override String BehindPassword { get; set; }
            /// <summary>
            /// 后摄像头备注
            /// </summary>
            [Display(Name = "后摄像头备注")]
            [Column("behind_remark")]
            [DbCol("后摄像头备注", Name = "behind_remark", Len = 255)]
            public override String BehindRemark { get; set; }
            /// <summary>
            /// 逻辑状态,0:正常,2:通道机异常,4:前摄像头异常,8:后摄像头异常
            /// </summary>
            [Display(Name = "逻辑状态,0:正常,2:通道机异常,4:前摄像头异常,8:后摄像头异常")]
            [Column("status")]
            [DbCol("逻辑状态,0:正常,2:通道机异常,4:前摄像头异常,8:后摄像头异常", Type = DbColType.Int32)]
            public override Int32 Status { get; set; }
            /// <summary>
            /// 编辑人标识
            /// </summary>
            [Display(Name = "编辑人标识")]
            [Column("editor")]
            [DbCol("编辑人标识", Type = DbColType.Int32)]
            public override Int32 Editor { get; set; }
            /// <summary>
            /// 编辑人名称
            /// </summary>
            [Display(Name = "编辑人名称")]
            [Column("edit_name")]
            [DbCol("编辑人名称", Name = "edit_name", Len = 255)]
            public override String EditName { get; set; }
            /// <summary>
            /// 编辑时间
            /// </summary>
            [Display(Name = "编辑时间")]
            [Column("edit_time")]
            [DbCol("编辑时间", Name = "edit_time", Type = DbColType.DateTime)]
            public override DateTime EditTime { get; set; }
            /// <summary>
            /// 删除标识,0:启用,1:禁用,2:删除
            /// </summary>
            [Display(Name = "删除标识,0:启用,1:禁用,2:删除")]
            [Column("flag")]
            [DbCol("删除标识,0:启用,1:禁用,2:删除", Type = DbColType.Int32)]
            public override Int32 Flag { get; set; }
            /// <summary>
            /// 版本号
            /// </summary>
            [Display(Name = "版本号")]
            [Column("version")]
            [DbCol("版本号", Type = DbColType.Int32)]
            public override Int32 Version { get; set; }
            /// <summary>
            /// 备注
            /// </summary>
            [Display(Name = "备注")]
            [Column("remark")]
            [DbCol("备注", Len = 255)]
            public override String Remark { get; set; }
        }
        /// <summary>
        /// RFID配置内容
        /// </summary>
        [Table("t_device_rfids")]
        [DbCol("RFID配置内容", Name = "t_device_rfids")]
        public partial class TDeviceRfids : ICloneable
        {
            /// <summary>
            /// 标识
            /// </summary>
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Display(Name = "标识")]
            [Column("id")]
            [DbCol("标识", Key = DbIxType.APK, Type = DbColType.Int32)]
            public virtual Int32 Id { get; set; }
            /// <summary>
            /// 唯一标识
            /// </summary>
            [Display(Name = "唯一标识")]
            [Column("uuid")]
            [DbCol("唯一标识")]
            public virtual String Uuid { get; set; }
            /// <summary>
            /// 终端授权码
            /// </summary>
            [Display(Name = "终端授权码")]
            [Column("key_code")]
            [DbCol("终端授权码", Name = "key_code")]
            public virtual String KeyCode { get; set; }
            /// <summary>
            /// 仪器名称
            /// </summary>
            [Display(Name = "仪器名称")]
            [Column("name")]
            [DbCol("仪器名称")]
            public virtual String Name { get; set; }
            /// <summary>
            /// IP地址/串口号
            /// </summary>
            [Display(Name = "IP地址/串口号")]
            [Column("address")]
            [DbCol("IP地址/串口号")]
            public virtual String Address { get; set; }
            /// <summary>
            /// 端口/波特率
            /// </summary>
            [Display(Name = "端口/波特率")]
            [Column("port")]
            [DbCol("端口/波特率", Type = DbColType.Int32)]
            public virtual Int32 Port { get; set; }
            /// <summary>
            /// 逻辑天线,0:快速四天线,1:天线一,2:天线二,4:天线三,8:天线四
            /// </summary>
            [Display(Name = "逻辑天线,0:快速四天线,1:天线一,2:天线二,4:天线三,8:天线四")]
            [Column("ant")]
            [DbCol("逻辑天线,0:快速四天线,1:天线一,2:天线二,4:天线三,8:天线四", Type = DbColType.Int32)]
            public virtual Int32 Ant { get; set; }
            /// <summary>
            /// 安装区域标识
            /// </summary>
            [Display(Name = "安装区域标识")]
            [Column("area_id")]
            [DbCol("安装区域标识", Name = "area_id", Type = DbColType.Int32)]
            public virtual Int32 AreaId { get; set; }
            /// <summary>
            /// 安装区域名称
            /// </summary>
            [Display(Name = "安装区域名称")]
            [Column("area_name")]
            [DbCol("安装区域名称", Name = "area_name")]
            public virtual String AreaName { get; set; }
            /// <summary>
            /// 前摄像头IP地址
            /// </summary>
            [Display(Name = "前摄像头IP地址")]
            [Column("front_address")]
            [DbCol("前摄像头IP地址", Name = "front_address")]
            public virtual String FrontAddress { get; set; }
            /// <summary>
            /// 前摄像头端口号
            /// </summary>
            [Display(Name = "前摄像头端口号")]
            [Column("front_port")]
            [DbCol("前摄像头端口号", Name = "front_port", Type = DbColType.Int32)]
            public virtual Int32 FrontPort { get; set; }
            /// <summary>
            /// 前摄像头账号
            /// </summary>
            [Display(Name = "前摄像头账号")]
            [Column("front_account")]
            [DbCol("前摄像头账号", Name = "front_account")]
            public virtual String FrontAccount { get; set; }
            /// <summary>
            /// 前摄像头密码
            /// </summary>
            [Display(Name = "前摄像头密码")]
            [Column("front_password")]
            [DbCol("前摄像头密码", Name = "front_password")]
            public virtual String FrontPassword { get; set; }
            /// <summary>
            /// 前摄像头备注
            /// </summary>
            [Display(Name = "前摄像头备注")]
            [Column("front_remark")]
            [DbCol("前摄像头备注", Name = "front_remark", Len = 255)]
            public virtual String FrontRemark { get; set; }
            /// <summary>
            /// 后摄像头IP地址
            /// </summary>
            [Display(Name = "后摄像头IP地址")]
            [Column("behind_address")]
            [DbCol("后摄像头IP地址", Name = "behind_address")]
            public virtual String BehindAddress { get; set; }
            /// <summary>
            /// 后摄像头端口号
            /// </summary>
            [Display(Name = "后摄像头端口号")]
            [Column("behind_port")]
            [DbCol("后摄像头端口号", Name = "behind_port", Type = DbColType.Int32)]
            public virtual Int32 BehindPort { get; set; }
            /// <summary>
            /// 后摄像头账号
            /// </summary>
            [Display(Name = "后摄像头账号")]
            [Column("behind_account")]
            [DbCol("后摄像头账号", Name = "behind_account")]
            public virtual String BehindAccount { get; set; }
            /// <summary>
            /// 后摄像头密码
            /// </summary>
            [Display(Name = "后摄像头密码")]
            [Column("behind_password")]
            [DbCol("后摄像头密码", Name = "behind_password")]
            public virtual String BehindPassword { get; set; }
            /// <summary>
            /// 后摄像头备注
            /// </summary>
            [Display(Name = "后摄像头备注")]
            [Column("behind_remark")]
            [DbCol("后摄像头备注", Name = "behind_remark", Len = 255)]
            public virtual String BehindRemark { get; set; }
            /// <summary>
            /// 逻辑状态,0:正常,2:通道机异常,4:前摄像头异常,8:后摄像头异常
            /// </summary>
            [Display(Name = "逻辑状态,0:正常,2:通道机异常,4:前摄像头异常,8:后摄像头异常")]
            [Column("status")]
            [DbCol("逻辑状态,0:正常,2:通道机异常,4:前摄像头异常,8:后摄像头异常", Type = DbColType.Int32)]
            public virtual Int32 Status { get; set; }
            /// <summary>
            /// 编辑人标识
            /// </summary>
            [Display(Name = "编辑人标识")]
            [Column("editor")]
            [DbCol("编辑人标识", Type = DbColType.Int32)]
            public virtual Int32 Editor { get; set; }
            /// <summary>
            /// 编辑人名称
            /// </summary>
            [Display(Name = "编辑人名称")]
            [Column("edit_name")]
            [DbCol("编辑人名称", Name = "edit_name", Len = 255)]
            public virtual String EditName { get; set; }
            /// <summary>
            /// 编辑时间
            /// </summary>
            [Display(Name = "编辑时间")]
            [Column("edit_time")]
            [DbCol("编辑时间", Name = "edit_time", Type = DbColType.DateTime)]
            public virtual DateTime EditTime { get; set; }
            /// <summary>
            /// 删除标识,0:启用,1:禁用,2:删除
            /// </summary>
            [Display(Name = "删除标识,0:启用,1:禁用,2:删除")]
            [Column("flag")]
            [DbCol("删除标识,0:启用,1:禁用,2:删除", Type = DbColType.Int32)]
            public virtual Int32 Flag { get; set; }
            /// <summary>
            /// 版本号
            /// </summary>
            [Display(Name = "版本号")]
            [Column("version")]
            [DbCol("版本号", Type = DbColType.Int32)]
            public virtual Int32 Version { get; set; }
            /// <summary>
            /// 备注
            /// </summary>
            [Display(Name = "备注")]
            [Column("remark")]
            [DbCol("备注", Len = 255)]
            public virtual String Remark { get; set; }
            object ICloneable.Clone() { return this.Clone(); }
            /// <summary>
            /// 浅表复制
            /// </summary>
            public TDeviceRfids Clone() { return (TDeviceRfids)this.MemberwiseClone(); }
        }
        #endregion
    }
}
