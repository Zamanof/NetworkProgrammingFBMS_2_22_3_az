using System.Net;
using System.Net.Sockets;
using System.Text;

var client = new UdpClient();
var endPoint = new IPEndPoint(IPAddress.Broadcast, 27001);

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
    var data = Encoding.Default.GetBytes(strings[i++ % length]);
    client.Send(data, endPoint);
    Thread.Sleep(40);
}
