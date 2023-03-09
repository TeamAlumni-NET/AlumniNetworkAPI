using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.Models;

namespace AlumniNetworkAPI.Services.Topics
{
    public class TopicService : ITopicService
    {
        private readonly AlumniNetworkDBContext? _dbContext;
        public Task<Topic> Create(Topic entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Topic>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Topic> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Topic> Update(Topic entity)
        {
            throw new NotImplementedException();
        }
    }
}
