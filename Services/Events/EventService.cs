using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.Models;

namespace AlumniNetworkAPI.Services.Events
{
    public class EventService : IEventService
    {
        private readonly AlumniNetworkDBContext? _dbContext;
        public Task<Event> Create(Event entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Event>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Event> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Event> Update(Event entity)
        {
            throw new NotImplementedException();
        }
    }
}
