using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCPConnectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    using (var client = new TcpClient())
                    {
                        client.Connect("127.0.0.1", 5000);
                        var networkStream = client.GetStream();
                        using (var writer = new StreamWriter(networkStream))
                        {
                            writer.Write("4,0100\r\n");
                            writer.Flush();
                        }
                        client.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
