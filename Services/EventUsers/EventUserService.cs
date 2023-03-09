using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.Models;

namespace AlumniNetworkAPI.Services.EventUsers
{
    public class EventUserService : IEventUserService
    {
        private readonly AlumniNetworkDBContext? _dbContext;
        public Task<EventUser> Create(EventUser entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EventUser>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<EventUser> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<EventUser> Update(EventUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
