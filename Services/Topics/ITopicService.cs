using AlumniNetworkAPI.Models.Models;

namespace AlumniNetworkAPI.Services.Topics
{
    public interface ITopicService : ICrudService<Topic, int>
    {
        Task<Topic> AddUserToTopic(int id, int userId);
    }
}
