using AlumniNetworkAPI.Models.DTOs.PostDtos;
using AlumniNetworkAPI.Models.Models;

namespace AlumniNetworkAPI.Services.Posts
{
    public interface IPostService : ICrudService<Post, int>
    {
        /// <summary>
        /// Gets all child posts of spesific events posts 
        /// </summary>
        /// <param name="id">eventId</param>
        /// <returns></returns>
        Task<IEnumerable<Post>> GetAllChildPostsEvent(int id);

        /// <summary>
        /// Gets all child posts od spesific post
        /// </summary>
        /// <param name="id">postId</param>
        /// <returns></returns>
        Task<IEnumerable<Post>> GetAllChildPosts(int id);

        /// <summary>
        /// Gets posts of users groups and topics
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IEnumerable<Post>> GetTimeline(int userId);

        /// <summary>
        /// Gets all posts of spesific group
        /// </summary>
        /// <param name="groupId">GroupId</param>
        /// <returns></returns>
        Task<IEnumerable<Post>> GetGroup(int groupId);

        /// <summary>
        /// Gets all posts of spesific topic
        /// </summary>
        /// <param name="topicsId">TopicId</param>
        /// <returns></returns>
        Task<IEnumerable<Post>> GetTopicsPosts(int topicsId);

        /// <summary>
        /// Gets all posts related to spesific users groups and topics
        /// </summary>
        /// <param name="userId">UserId</param>
        /// <returns></returns>
        Task<IEnumerable<Post>> GetDashboard(int userId);
    }
}
