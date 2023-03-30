using AlumniNetworkAPI.Models.Models;

namespace AlumniNetworkAPI.Services.Topics
{
    public interface ITopicService : ICrudService<Topic, int>
    {
        /// <summary>
        /// Adds user to spesific topic
        /// </summary>
        /// <param name="id">TopicId</param>
        /// <param name="userId">UserId</param>
        /// <returns></returns>
        Task<Topic> AddUserToTopic(int id, int userId);

        /// <summary>
        /// Removes user from spesific topic
        /// </summary>
        /// <param name="topicId">TopicId</param>
        /// <param name="userId">UserId</param>
        /// <returns></returns>
        Task RemoveUserFromTopic(int topicId, int userId);
    }
}
