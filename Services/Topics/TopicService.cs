using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Linq;

namespace AlumniNetworkAPI.Services.Topics
{
    public class TopicService : ITopicService
    {
        private readonly AlumniNetworkDBContext _context;

        public TopicService(AlumniNetworkDBContext dbContext)
        {
            _context = dbContext;
        }

        public Task<Topic> Create(Topic entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Topic>> GetAll()
        {
            return await _context.Topics.Include(t => t.Users).ToListAsync();
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
