using System;
using System.Collections.Generic;
using System.Data.Cobber;
using System.Data.Dabber;
using System.Data.NHInterfaces;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;

namespace System.Data.EDBODBCSDK
{
    /// <summary>
    /// 数据访问SDK代理接口
    /// </summary>
    public interface IDbAccessSdkProxy
    {
        /// <summary>
        /// 获取单个模型
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        IAlertJson GetModel(RequestDatabaseRegularModel args);
        /// <summary>
        /// 获取单个模型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        /// <returns></returns>
        IAlertMsg<T> GetModel<T>(RequestDatabaseRegularModel args);
        /// <summary>
        /// 获取模型列表
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        IAlertJson GetModels(RequestDatabaseRegularModel args);
        /// <summary>
        /// 获取模型列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args"></param>
        /// <returns></returns>
        IAlertMsgs<T> GetModels<T>(RequestDatabaseRegularModel args);
        /// <summary>
        /// 执行脚本内容
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        IAlertJson Execute(RequestDatabaseRegularModel args);
        /// <summary>
        /// 事务执行脚本内容
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        IAlertJson Executes(RequestDatabaseRowsModel args);
    }
    /// <summary>
    /// 32位访问接口可直接实现
    /// </summary>
    internal class DbAccessSdkApi : DbAccessProxy, IDbAccessSdkProxy
    {
        /// <summary>
        /// 获取模型列表
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public virtual IAlertMsgs<T> GetModels<T>(RequestDatabaseRegularModel args)
        {
            using var conn = GetOpenedConnection(args.IsOdbc, args.ConnString);
            try
            {
                var res = conn.Query<T>(args.Sql, args.Args).ToList();
                return new AlertMsgs<T>(true, "操作成功") { Data = res };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new AlertMsgs<T>(false, ex.Message);
            }
        }
        /// <summary>
        /// 获取模型列表
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public virtual IAlertMsg<T> GetModel<T>(RequestDatabaseRegularModel args)
        {
            using var conn = GetOpenedConnection(args.IsOdbc, args.ConnString);
            try
            {
                var res = conn.QueryFirstOrDefault<T>(args.Sql, args.Args);
                return new AlertMsg<T>(true, "操作成功") { Data = res };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new AlertMsg<T>(false, ex.Message);
            }
        }
    }
    internal class DbAccessSdkApi64 : IDbAccessSdkProxy
    {
        /// <summary>
        /// 执行文件名
        /// </summary>
        public const string ExeFile = "NSystem.Data.EDBODBCEXE.exe";
        /// <summary>
        /// x86的dll目录
        /// </summary>
        public const String ExeTarget = $@".\{DbAccessSdk.DllVirtualPath}\x86\EDBODBCEXE.exe";
        /// <summary>
        /// 执行文件全名
        /// </summary>
        public static String ExeFileName { get; } = Path.Combine(DbAccessSdk.DllFullPath, "x86", ExeFile);
        /// <summary>
        /// 单一实例
        /// </summary>
        public static DbAccessSdkApi64 Instance { get; }
        /// <summary>
        /// 静态构造
        /// </summary>
        static DbAccessSdkApi64()
        {
            var res = File.ReadAllBytes(Path.GetFullPath(ExeTarget));
            if (!SdkFileComponent.CompareResourceFile(ExeFileName, res))
            { SdkFileComponent.WriteResourceFile(res, ExeFileName); }
            Instance = new DbAccessSdkApi64();
        }

        private Process _process;
        private NamedPipeServerStream _piper;
        private StreamWriter _writer;
        private Lazy<StreamReader> _reader;
        private String _key;
        /// <summary>
        /// 构造
        /// </summary>
        private DbAccessSdkApi64()
        {
            _key = Guid.NewGuid().ToString("N");
            _process = new Process();
            _process.StartInfo.FileName = ExeFileName;
            _process.StartInfo.WorkingDirectory = Path.GetDirectoryName(ExeFileName);
            _process.StartInfo.Arguments = _key;
            _process.StartInfo.CreateNoWindow = true;
            _process.StartInfo.UseShellExecute = false;
            _piper = new NamedPipeServerStream(_key, PipeDirection.InOut, 1, PipeTransmissionMode.Byte, PipeOptions.None);
            _process.Start();
            _piper.WaitForConnection();
            _writer = new StreamWriter(_piper, Encoding.UTF8)
            {
                AutoFlush = true
            };
            _reader = new Lazy<StreamReader>(() => new StreamReader(_piper, Encoding.UTF8), true);
        }
        public IAlertJson GetModels(RequestDatabaseRegularModel args)
        {
            var model = new PiperSwapModel()
            {
                I = nameof(GetModels),
                C = nameof(GetModels),
                M = String.Empty,
                F = true,
                K = String.Empty,
                P = args.GetJsonString(),
                R = String.Empty,
                T = DateTime.Now,
            };
            _writer.WriteLine(model.GetJsonString());
            var resObj = _reader.Value.ReadLine().GetJsonObject<PiperSwapModel>();
            return GetAlert(resObj);
        }

        internal IAlertJson GetAlert(PiperSwapModel resObj)
        {
            if (resObj.C == PiperSwapModel.ResponseCmd)
            {
                return new AlertJson(true, resObj.M) { Data = resObj.R };
            }
            return new AlertJson(false, resObj.M) { Data = resObj.R };
        }

        public IAlertJson GetModel(RequestDatabaseRegularModel args)
        {
            var model = new PiperSwapModel()
            {
                I = nameof(GetModel),
                C = nameof(GetModel),
                M = String.Empty,
                F = true,
                K = String.Empty,
                P = args.GetJsonString(),
                R = String.Empty,
                T = DateTime.Now,
            };
            _writer.WriteLine(model.GetJsonString());
            var resObj = _reader.Value.ReadLine().GetJsonObject<PiperSwapModel>();
            return GetAlert(resObj);
        }

        public IAlertMsg<T> GetModel<T>(RequestDatabaseRegularModel args)
        {
            var getModel = GetModel(args);
            if (getModel.IsSuccess)
            {
                return new AlertMsg<T>(true, "操作成功") { Data = getModel.Data.GetJsonObject<T>() };
            }
            Console.WriteLine(getModel);
            return new AlertMsg<T>(false, getModel.Message);
        }

        public IAlertMsgs<T> GetModels<T>(RequestDatabaseRegularModel args)
        {
            var getModel = GetModels(args);
            if (getModel.IsSuccess)
            {
                return new AlertMsgs<T>(true, "操作成功") { Data = getModel.Data.GetJsonObject<List<T>>() };
            }
            Console.WriteLine(getModel);
            return new AlertMsgs<T>(false, getModel.Message);
        }

        public IAlertJson Execute(RequestDatabaseRegularModel args)
        {
            var model = new PiperSwapModel()
            {
                I = nameof(Execute),
                C = nameof(Execute),
                M = String.Empty,
                F = true,
                K = String.Empty,
                P = args.GetJsonString(),
                R = String.Empty,
                T = DateTime.Now,
            };
            _writer.WriteLine(model.GetJsonString());
            var resObj = _reader.Value.ReadLine().GetJsonObject<PiperSwapModel>();
            return GetAlert(resObj);
        }

        public IAlertJson Executes(RequestDatabaseRowsModel args)
        {
            var model = new PiperSwapModel()
            {
                I = nameof(Executes),
                C = nameof(Executes),
                M = String.Empty,
                F = true,
                K = String.Empty,
                P = args.GetJsonString(),
                R = String.Empty,
                T = DateTime.Now,
            };
            _writer.WriteLine(model.GetJsonString());
            var resObj = _reader.Value.ReadLine().GetJsonObject<PiperSwapModel>();
            return GetAlert(resObj);
        }
    }
}
