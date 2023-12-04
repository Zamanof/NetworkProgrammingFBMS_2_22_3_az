using System.Net;
using System.Net.Sockets;
using System.Text;

var listener = new Socket(
    AddressFamily.InterNetwork,
    SocketType.Dgram,
    ProtocolType.Udp);

IPAddress.TryParse("127.0.0.1", out var ip);
var connectEP = new IPEndPoint(ip, 27001);

listener.Bind(connectEP);

EndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);

var buffer = new byte[ushort.MaxValue];


while (true)
{
    var length = listener.ReceiveFrom(buffer, ref endPoint);
    var message = Encoding.Default.GetString(buffer, 0, length);
    Console.Write(message);

}
