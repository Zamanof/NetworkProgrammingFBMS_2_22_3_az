using System.Net;

var listener = new HttpListener();

listener.Prefixes.Add(@"http://localhost:27001/");

listener.Start();

while (true)
{
    var context = listener.GetContext();
    var request = context.Request;
    var response = context.Response;
    //response.AddHeader("Content-Type", "text/plain");
    //Console.WriteLine(request.RawUrl);
    //foreach ( string key in request.QueryString.Keys)
    //{
    //    Console.WriteLine($"{key} - {request.QueryString[key]}");
    //}
    StreamWriter writer = new StreamWriter(response.OutputStream);
    //writer.WriteLine("Salam");
    var str = request.QueryString["name"];
    //    writer.WriteLine($@"<h1 style='color: red;'>Hello World! 
    //Hello {str}</h1>");
    //writer.WriteLine($@"<a href='https://google.com/search?q={str}'>About me<a/>");
    writer.WriteLine($@"<a href='https://google.com/search?q={str}'>");
    writer.WriteLine($@"<img src='https://sun9-57.userapi.com/c9191/u17656220/a_172036cb.jpg'>");
    writer.WriteLine($@"</a>");
    writer.Close();
}
