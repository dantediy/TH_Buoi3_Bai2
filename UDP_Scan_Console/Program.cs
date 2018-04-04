using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDP_Scan_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("74.125.200.139"), 80);
            UdpClient udp = new UdpClient();
            udp.Connect(ipe);
            byte[] data = Encoding.ASCII.GetBytes("hell");
            udp.Send(data, data.Length);
            try
            {
                udp.Receive(ref ipe);
                Console.WriteLine(ipe.ToString() + " is open");
            }
            catch
            {
                Console.WriteLine(ipe.ToString() + " is closed");
            }
        }
    }
}
