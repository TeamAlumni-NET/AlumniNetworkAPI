using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.Models;

namespace AlumniNetworkAPI.Services.Rsvps
{
    public class RsvpService : IRsvpService
    {
        private readonly AlumniNetworkDBContext? _dbContext;
        public Task<Rsvp> Create(Rsvp entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Rsvp>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Rsvp> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Rsvp> Update(Rsvp entity)
        {
            throw new NotImplementedException();
        }
    }
}
