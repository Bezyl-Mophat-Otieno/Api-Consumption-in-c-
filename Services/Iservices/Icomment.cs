namespace api_c__consumption;

public interface Icomment
{
    Task<List<dynamic>> getPostComments( string postId);

}
