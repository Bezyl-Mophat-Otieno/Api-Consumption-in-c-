namespace api_c__consumption;

public class UserController
{

    UserServices userservice = new UserServices();
    PostsServices postsServices = new PostsServices();

    CommentServices commentServices = new CommentServices();

    public async Task  init (){

        var users = await userservice.getAllUsers();
       
        Console.WriteLine("\tID\t\tName\t\tUserName\t\tEmail");
        foreach (var user in users)
        {

            Console.WriteLine($"\t{user.id}\t\t{user.name}\t\t{user.username}\t\t{user.email}\n");

            
        }
        Console.WriteLine("\t\t\t\tChoose Post to Display based on the User Id\n\n");
        string userId = Console.ReadLine();

        await RenderUserPost(userId);

    }

    public async Task RenderUserPost (string userid){

        var posts = await postsServices.getUserPost(userid);
        Console.WriteLine("\t\tUSERID\t\tPOSTID\t\t\t\tTITLE\t\t\t\tCONTENT\n");
        foreach (var post in posts)
        {

            Console.WriteLine($"\t\t{post.userId}\t\t{post.id}\t\t{post.title}\t\t\t{post.body}\n");
            
        }

         Console.WriteLine("\t\t\t\tChoose Comments to Display based on the Post Id\n\n");
        string postId = Console.ReadLine();

        await RenderPostComments(postId);


    }

    public async Task RenderPostComments(string postId){
        var comments = await commentServices.getPostComments(postId);

        Console.WriteLine("\t\tAUTHOR EMAIL\t\t\t\t COMMENT \n");
        foreach (var comment in comments)
        {

            Console.WriteLine($"\t\t{comment.email}\t\t\t\t{comment.body}");
            
        }
    }


    





}
