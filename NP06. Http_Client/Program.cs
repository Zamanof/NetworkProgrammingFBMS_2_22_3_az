#region Deprecated WebClient class
// HTTP + FTP
//var webClient = new WebClient();
//Console.WriteLine(webClient.DownloadString(@"https://www.google.az"));
#endregion

using System.Net;

var client = new HttpClient();
var message = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    RequestUri = new Uri(@"https://www.google.az")
};

message.Headers.Add("Accept", "text/html");

var responce = await client.SendAsync(message);


//Console.WriteLine(responce);
//Console.WriteLine(responce.Headers);
//Console.WriteLine(responce.StatusCode);
//Console.WriteLine(responce.Content);
Console.WriteLine(responce.RequestMessage);

