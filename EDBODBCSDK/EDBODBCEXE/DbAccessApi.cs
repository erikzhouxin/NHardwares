using System;
using System.Collections.Generic;
using System.Data.Cobber;
using System.Data.Dubber;
using System.Linq;
using System.Text;

namespace System.Data.EDBODBCSDK
{
    /// <summary>
    /// Access访问接口
    /// </summary>
    public static partial class DbAccessApi
    {
        /// <summary>
        /// 前置键
        /// </summary>
        public const string PreKey = "DbAccess.";
        /// <summary>
        /// 调用实现
        /// </summary>
        /// <param name="receive"></param>
        /// <returns></returns>
        public static PiperSwapModel Call(PiperSwapModel receive)
        {
            var cmd = receive.C.Substring(9);
            switch (cmd)
            {
                case nameof(DbAccessProxy.GetModel):
                    {
                        var args = receive.P.GetJsonObject<RequestDatabaseRegularModel>();
                        var res = new DbAccessProxy().GetModel(args);
                        receive.C = res.IsSuccess ? PiperSwapModel.ResponseCmd : PiperSwapModel.ErrorCmd;
                        receive.M = res.Message;
                        receive.R = res.Data;
                        break;
                    }
                case nameof(DbAccessProxy.GetModels):
                    {
                        var args = receive.P.GetJsonObject<RequestDatabaseRegularModel>();
                        var res = new DbAccessProxy().GetModels(args);
                        receive.C = res.IsSuccess ? PiperSwapModel.ResponseCmd : PiperSwapModel.ErrorCmd;
                        receive.M = res.Message;
                        receive.R = res.Data;
                        break;
                    }
                case nameof(DbAccessProxy.Execute):
                    {
                        var args = receive.P.GetJsonObject<RequestDatabaseRegularModel>();
                        var res = new DbAccessProxy().Execute(args);
                        receive.C = res.IsSuccess ? PiperSwapModel.ResponseCmd : PiperSwapModel.ErrorCmd;
                        receive.M = res.Message;
                        receive.R = res.Data;
                    }
                    break;
                case nameof(DbAccessProxy.Executes):
                    {
                        var args = receive.P.GetJsonObject<RequestDatabaseRowsModel>();
                        var res = new DbAccessProxy().Executes(args);
                        receive.C = res.IsSuccess ? PiperSwapModel.ResponseCmd : PiperSwapModel.ErrorCmd;
                        receive.M = res.Message;
                        receive.R = res.Data;
                    }
                    break;
                default:
                    {
                        receive.C = PiperSwapModel.NotFoundCmd;
                        receive.M = $"未找到【{receive.C}】的实现";
                        break;
                    }
            }
            return receive;
        }
    }
}
