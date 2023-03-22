using AlumniNetworkAPI.Models.Models;

namespace AlumniNetworkAPI.Services.Posts
{
    public interface IPostService : ICrudService<Post, int>
    {
        Task<IEnumerable<Post>> GetTimeline(int userId);
        Task<IEnumerable<Post>> GetGroup(int userId);
    }
}
