using AlumniNetworkAPI.Models.DTOs.PostDtos;
using AlumniNetworkAPI.Models.Models;

namespace AlumniNetworkAPI.Services.Posts
{
    public interface IPostService : ICrudService<Post, int>
    {
        Task<ChildPostRootDto> GetAllChildPosts(int id);
    }
}
    