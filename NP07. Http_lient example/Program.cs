using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;

var postClient = new HttpClient();
var message = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    RequestUri = new Uri(@"https://jsonplaceholder.typicode.com/posts")
};

// .GetAsync(), .PostAsync(), .DeleteAsync() ...
// responce.Content.ReadAsStringAsync()

var responce = await postClient.SendAsync(message);
//Console.WriteLine(responce);

var json = await responce.Content.ReadAsStringAsync();

//Console.WriteLine(json);

var posts = JsonSerializer.Deserialize<List<Post>>(json);

// boxing unboxing
// generic
// ArrayList        List<int>
//ArrayList array = new ArrayList() 
//{
//    5,
//    3,
//    21
//};
//var a = array[0];

//List<int> ints = new List<int>()
//{ 
//    5,
//    3,
//    21
//}; 



//foreach (var post in posts)
//{
//    Console.WriteLine(post);
//}



class Post
{
    [JsonPropertyName("userId")]
    public int UserId { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("body")]
    public string Text { get; set; }

    public override string ToString()
    {
        return $@"post id: {Id}
Sender: {UserId}
                {Title}
{Text}
";
    }
}
