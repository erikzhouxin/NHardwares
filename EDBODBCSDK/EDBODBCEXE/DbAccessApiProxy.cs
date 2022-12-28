using System;
using System.Collections.Generic;
using System.Data.Cobber;
using System.Data.Common;
using System.Data.Dabber;
using System.Linq;
using System.Text;

namespace System.Data.EDBODBCSDK
{
    /// <summary>
    /// 数据库访问API
    /// </summary>
    internal class DbAccessProxy
    {
        /// <summary>
        /// 获取模型列表
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public virtual IAlertJson GetModel(RequestDatabaseRegularModel args)
        {
            using var conn = GetOpenedConnection(args.IsOdbc, args.ConnString);
            bool isSuccess;
            string msg;
            string jsonString;
            try
            {
                var res = conn.QueryFirstOrDefault(args.Sql, args.Args);
                jsonString = res.GetJsonString();
                isSuccess = true;
                msg = "操作成功";
            }
            catch (Exception ex)
            {
                jsonString = ex.GetJsonString();
                isSuccess = false;
                msg = ex.Message;
            }
            return new AlertJson(isSuccess, msg) { Data = jsonString };
        }
        /// <summary>
        /// 获取模型列表
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public virtual IAlertJson GetModels(RequestDatabaseRegularModel args)
        {
            using var conn = GetOpenedConnection(args.IsOdbc, args.ConnString);
            bool isSuccess;
            string msg;
            string jsonString;
            try
            {
                var res = conn.Query(args.Sql, args.Args).ToList();
                jsonString = res.GetJsonString();
                isSuccess = true;
                msg = "操作成功";
            }
            catch (Exception ex)
            {
                jsonString = ex.GetJsonString();
                isSuccess = false;
                msg = ex.Message;
            }
            return new AlertJson(isSuccess, msg) { Data = jsonString };
        }
        /// <summary>
        /// 更新模型行
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public virtual IAlertJson UpdateRow(RequestDatabaseRegularModel args)
        {
            using var conn = GetOpenedConnection(args.IsOdbc, args.ConnString);
            string jsonString;
            string msg;
            bool isSuccess;
            try
            {
                var res = conn.Execute(args.Sql, args.Args);
                msg = "操作成功";
                jsonString = res.GetJsonString();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                jsonString = ex.GetJsonString();
                isSuccess = false;
                msg = ex.Message;
            }
            return new AlertJson(isSuccess, msg) { Data = jsonString };
        }
        /// <summary>
        /// 更新模型行列表
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public virtual IAlertJson UpdateRows(RequestDatabaseRowsModel args)
        {
            string jsonString;
            string msg;
            bool isSuccess;
#pragma warning disable IDE0063 // 使用事务时必须不能简化
            using (var conn = GetOpenedConnection(args.IsOdbc, args.ConnString))
            {
                DbTransaction trans = null;
                try
                {
                    trans = conn.BeginTransaction();
                    var effLine = 0;
                    foreach (var item in args.Args)
                    {
                        effLine += conn.Execute(args.Sql, item, trans);
                    }
                    trans.Commit();
                    msg = "操作成功";
                    jsonString = effLine.GetJsonString();
                    isSuccess = true;
                }
                catch (Exception ex)
                {
                    trans?.Rollback();
                    jsonString = ex.GetJsonString();
                    isSuccess = false;
                    msg = ex.Message;
                }
            }
#pragma warning restore IDE0063 // 使用事务时必须不能简化
            return new AlertJson(isSuccess, msg) { Data = jsonString };
        }
        /// <summary>
        /// 执行脚本内容
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public virtual IAlertJson Execute(RequestDatabaseRegularModel args)
        {
            using var conn = GetOpenedConnection(args.IsOdbc, args.ConnString);
            bool isSuccess;
            string msg;
            string jsonString;
            try
            {
                var res = conn.Query(args.Sql, args.Args).ToList();
                jsonString = res.GetJsonString();
                isSuccess = true;
                msg = "操作成功";
            }
            catch (Exception ex)
            {
                jsonString = ex.GetJsonString();
                isSuccess = false;
                msg = ex.Message;
            }
            return new AlertJson(isSuccess, msg) { Data = jsonString };
        }
        /// <summary>
        /// 事务执行脚本内容
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public virtual IAlertJson Executes(RequestDatabaseRowsModel args)
        {
            string jsonString;
            string msg;
            bool isSuccess;
#pragma warning disable IDE0063 // 使用事务时必须不能简化
            using (var conn = GetOpenedConnection(args.IsOdbc, args.ConnString))
            {
                DbTransaction trans = null;
                try
                {
                    trans = conn.BeginTransaction();
                    var effLine = 0;
                    foreach (var item in args.Args)
                    {
                        effLine += conn.Execute(args.Sql, item, trans);
                    }
                    trans.Commit();
                    msg = "操作成功";
                    jsonString = effLine.GetJsonString();
                    isSuccess = true;
                }
                catch (Exception ex)
                {
                    trans?.Rollback();
                    jsonString = ex.GetJsonString();
                    isSuccess = false;
                    msg = ex.Message;
                }
            }
#pragma warning restore IDE0063 // 使用事务时必须不能简化
            return new AlertJson(isSuccess, msg) { Data = jsonString };
        }
        /// <summary>
        /// 获取一个连接
        /// </summary>
        /// <param name="isOdbc"></param>
        /// <param name="connString"></param>
        /// <returns></returns>
        internal DbConnection GetOpenedConnection(bool isOdbc, string connString)
        {
            DbConnection connection = isOdbc ? new Odbc.OdbcConnection(connString) : new OleDb.OleDbConnection(connString);
            connection.Open();
            return connection;
        }
    }
    /// <summary>
    /// 请求数据库执行SQL模型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ReqDbExecSqlModel<T>
    {
        /// <summary>
        /// 是ODBC访问
        /// </summary>
        public virtual bool IsOdbc { get; set; }
        /// <summary>
        /// 连接字符串
        /// </summary>
        public virtual String ConnString { get; set; }
        /// <summary>
        /// SQL语句
        /// </summary>
        public virtual String Sql { get; set; }
        /// <summary>
        /// 执行参数
        /// </summary>
        public virtual T Args { get; set; }
    }
    /// <summary>
    /// 请求数据库普通模型
    /// </summary>
    public class RequestDatabaseRegularModel : ReqDbExecSqlModel<Dictionary<string, object>> { }
    /// <summary>
    /// 请求数据库行记录模型
    /// </summary>
    public class RequestDatabaseRowsModel : ReqDbExecSqlModel<List<Dictionary<string, object>>> { }
}
