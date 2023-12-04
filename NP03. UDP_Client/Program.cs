using System.Net;
using System.Net.Sockets;
using System.Text;

var client = new Socket(
    AddressFamily.InterNetwork, 
    SocketType.Dgram,
    ProtocolType.Udp);

IPAddress.TryParse("127.0.0.1", out var ip);
var connectEP = new IPEndPoint(ip, 27001);

var message = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
Praesent a massa eget arcu gravida consectetur quis at eros. 
Sed luctus nisi quis eleifend sagittis. 
Integer dapibus laoreet massa quis dignissim. 
Vestibulum ut lobortis odio. Nullam ac rhoncus lacus. 
Vestibulum a maximus felis. 
Maecenas lobortis elementum felis, vel volutpat purus iaculis eu. 
Integer et erat ac lacus maximus efficitur. 
Proin sit amet ante eget justo interdum posuere. 
Pellentesque bibendum eget felis vel sodales. 
Cras eleifend risus id urna vulputate porttitor. 
Suspendisse non vehicula elit. 
Nulla suscipit commodo erat, at porttitor augue suscipit at. 
Etiam malesuada eros a arcu finibus faucibus. 
Class aptent taciti sociosqu ad litora torquent per conubia nostra, 
per inceptos himenaeos. Integer sit amet auctor tortor.
Vestibulum semper tortor diam, at venenatis enim rhoncus id. 
Nam blandit magna sed lobortis iaculis. Pellentesque pulvinar, 
velit nec lobortis hendrerit, sem quam tristique tortor, 
bibendum venenatis leo mauris ac velit. 
Pellentesque ac mi non tortor luctus hendrerit sed at ligula. 
In hac habitasse platea dictumst. Pellentesque vitae tincidunt diam, 
non convallis urna. Pellentesque eu lectus eu dolor fermentum elementum 
ut in ex. Sed vulputate nisi a eros sodales convallis. 
Donec venenatis scelerisque ex fermentum tristique.";

int count = 0;

while (true)
{
    var bytes = Encoding.Default
            .GetBytes(message[count++ % message.Length].ToString());
    Thread.Sleep(100);
    client.SendTo(bytes, connectEP);
}
