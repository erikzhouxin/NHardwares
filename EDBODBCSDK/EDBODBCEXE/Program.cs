using Newtonsoft.Json;
using System;
using System.Data.Cobber;
using System.Data.EDBODBCSDK;
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
                StreamWriter writer = null;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    writer ??= new StreamWriter(clientStream, Encoding.UTF8) { AutoFlush = true };
                    PiperSwapModel receive;
                    try
                    {
                        receive = line.GetJsonObject<PiperSwapModel>();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        writer.WriteLine(new PiperSwapModel
                        {
                            C = PiperSwapModel.ErrorCmd,
                            M = ex.Message,
                            P = JsonConvert.SerializeObject(ex),
                            T = DateTime.Now,
                        }.GetJsonString());
                        continue;
                    }
                    PiperSwapModel response;
                    try
                    {
                        response = Analyzing(receive);
                    }
                    catch (Exception ex)
                    {
                        response = new PiperSwapModel
                        {
                            C = PiperSwapModel.ErrorCmd,
                            M = ex.Message,
                            P = JsonConvert.SerializeObject(ex),
                            T = DateTime.Now,
                        };
                    }
                    writer.WriteLine(response.GetJsonString());
                }
            }
        }
        /// <summary>
        /// 分析
        /// </summary>
        /// <param name="receive"></param>
        /// <returns></returns>
        internal static PiperSwapModel Analyzing(PiperSwapModel receive)
        {
            if (receive.C.StartsWith(DbAccessApi.PreKey, StringComparison.OrdinalIgnoreCase))
            {
                return DbAccessApi.Call(receive);
            }
            switch (receive.C)
            {
                default:
                    {
                        return new PiperSwapModel
                        {
                            I = receive.I,
                            C = PiperSwapModel.NotFoundCmd,
                            M = receive.M,
                            P = receive.P,
                            K = receive.K,
                            F = false,
                            R = String.Empty,
                            T = DateTime.Now,
                        };
                    }
            }
        }
    }
}
