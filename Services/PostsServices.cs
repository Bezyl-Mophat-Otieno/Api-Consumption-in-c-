
namespace api_c__consumption;

public class PostsServices : Ipost
{

     private readonly HttpClient _Client ;
    private readonly  string _URL = "https://jsonplaceholder.typicode.com/posts";

     public PostsServices(){
        _Client = new HttpClient();
     }
    public async Task<List<dynamic>> getUserPost(string id)
    {
         var response = await _Client.GetAsync(_URL+"?"+$"userId={id}");
        var content = await response.Content.ReadAsStringAsync();
        List<dynamic> posts = Newtonsoft.Json.JsonConvert.DeserializeObject<List<dynamic>>(content);
        return posts;
    }
}
