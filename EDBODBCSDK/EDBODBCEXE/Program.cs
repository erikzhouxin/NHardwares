using Newtonsoft.Json;
using System;
using System.IO;
using System.IO.Pipes;
using System.Text;

namespace System.Data.EDBODBCEXE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0) { args = new string[] { typeof(Program).Namespace }; }
            using (NamedPipeClientStream clientStream = new NamedPipeClientStream(args[0]))
            {
                // 连接
                clientStream.Connect();
                StreamReader reader = new StreamReader(clientStream, Encoding.UTF8);
                StreamWriter writer = new StreamWriter(clientStream, Encoding.UTF8) { AutoFlush = true };
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    PipeTransformModel receive;
                    try
                    {
                        receive = PipeTransformModel.GetModel(line);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        writer.WriteLine(new PipeTransformModel
                        {
                            C = PipeTransformModel.ErrorCmd,
                            M = ex.Message,
                            P = JsonConvert.SerializeObject(ex),
                            T = DateTime.Now,
                        }.ToJson());
                        continue;
                    }
                    PipeTransformModel response;
                    try
                    {
                        response = Analyzing(receive);
                    }
                    catch (Exception ex)
                    {
                        response = new PipeTransformModel
                        {
                            C = PipeTransformModel.ErrorCmd,
                            M = ex.Message,
                            P = JsonConvert.SerializeObject(ex),
                            T = DateTime.Now,
                        };
                    }
                    writer.WriteLine(response.ToJson());
                }
            }
        }
        /// <summary>
        /// 分析
        /// </summary>
        /// <param name="receive"></param>
        /// <returns></returns>
        internal static PipeTransformModel Analyzing(PipeTransformModel receive)
        {
            if (receive.C.StartsWith("DbAccess.", StringComparison.OrdinalIgnoreCase))
            {
                return 
            }
            switch (receive.C)
            {
                case "":
                    {
                        return 
                    }
                default:
                    {
                        return new PipeTransformModel
                        {
                            C = PipeTransformModel.NotFoundCmd,
                        };
                    }
            }
        }
    }
}
