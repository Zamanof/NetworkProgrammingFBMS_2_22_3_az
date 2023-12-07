using System.Net;
using System.Net.Sockets;
using System.Text;

var listener = new UdpClient(27001);
var ip = IPAddress.Parse("224.1.2.3");
listener.JoinMulticastGroup(ip);

var endPoint = new IPEndPoint(IPAddress.Any, 0);

while (true)
{
    var data = listener.Receive(ref endPoint);
    Console.WriteLine(Encoding.Default.GetString(data));
    Thread.Sleep(40);
    Console.Clear();
}
