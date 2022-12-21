using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Data.HDSSSEEXE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0) { args = new string[] { typeof(Program).Namespace }; }
            using (NamedPipeClientStream clientStream = new NamedPipeClientStream(args[0]))
            {
                //连接
                clientStream.Connect();
                StreamReader reader = new StreamReader(clientStream, Encoding.UTF8);
                StreamWriter writer = null;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string response;
                    try
                    {
                        response = HD100CardSdkDller.Call(line);
                    }
                    catch (Exception ex)
                    {
                        response = new PiperSwapModel("Unknown")
                        {
                            R = -1,
                            IT = false,
                            Msg = ex.Message,
                        }.ToJson();
                    }
                    writer ??= new StreamWriter(clientStream, Encoding.UTF8) { AutoFlush = true };
                    writer.WriteLine(response);
                }
            }
        }
    }
}
