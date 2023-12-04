using System.Net;
using System.Net.Sockets;
using System.Text;

var server = new UdpClient(27001);

var remoteEP = new IPEndPoint(IPAddress.Any, 0);

var message = string.Empty;

while (true)
{
    var bytes = server.Receive(ref remoteEP);
    message = Encoding.Default.GetString(bytes);
    Console.WriteLine($"{remoteEP.Address} - {remoteEP.Port}: {message}");
}


