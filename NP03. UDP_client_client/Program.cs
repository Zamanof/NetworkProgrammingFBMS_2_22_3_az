using System.Net;
using System.Net.Sockets;
using System.Text;

var client = new UdpClient();
var connectEP = new IPEndPoint(IPAddress.Loopback, 27001);

var message = string.Empty;
while (true)
{
    message = Console.ReadLine();
    var bytes = Encoding.Default.GetBytes(message);
    client.Send(bytes, bytes.Length, connectEP);
}
