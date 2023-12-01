
namespace api_c__consumption;

public class UserServices : Iuser
{

    private readonly HttpClient _Client ;
    private readonly  string _URL = "https://jsonplaceholder.typicode.com/users";

     public UserServices(){
        _Client = new HttpClient();
     }
    public async Task<List<dynamic>> getAllUsers()
    {
        var response = await _Client.GetAsync(_URL);
        var content = await response.Content.ReadAsStringAsync();
        List<dynamic> users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<dynamic>>(content);
        return users;

    }
}
