
namespace api_c__consumption;

public class CommentServices : Icomment

{

    private readonly HttpClient _Client ;
    private readonly  string _URL = "https://jsonplaceholder.typicode.com/comments";

     public CommentServices(){
        _Client = new HttpClient();
     }
    public async Task<List<dynamic>> getPostComments(string id)
    {
        
        var response = await _Client.GetAsync(_URL+"?"+$"postId={id}");
        var content = await response.Content.ReadAsStringAsync();
        List<dynamic> comments = Newtonsoft.Json.JsonConvert.DeserializeObject<List<dynamic>>(content);
        return comments;
    }
}
