using System.Net;
using System.Net.Sockets;
using System.Text;

var client = new UdpClient();
var ip = IPAddress.Parse("224.1.2.3");
client.JoinMulticastGroup(ip);
var endPoint = new IPEndPoint(ip, 27001);
List<string> strings = new List<string>() {
    @"\_________",
    @"/\________",
    @"_/\_______",
    @"__/\______",
    @"___/\_____",
    @"____/\____",
    @"_____/\___",
    @"______/\__",
    @"_______/\_",
    @"________/\",
    @"_________/"

};
var i = 0;
var length = strings.Count;
while (true)
{
    var  data = Encoding.Default.GetBytes(strings[i++ % length]);
    client.Send(data, data.Length, endPoint);
    Thread.Sleep(40);
}
