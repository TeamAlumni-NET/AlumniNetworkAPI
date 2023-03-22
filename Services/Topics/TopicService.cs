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

        public async Task<Topic> AddUserToTopic(int id, int userId)
        {
            var topic = await _context.Topics.Include(x => x.Users).Where(x => x.Id == id).FirstOrDefaultAsync();
            var user = await _context.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();

            topic.Users.Add(user);
            _context.Entry(topic).State= EntityState.Modified;
            await _context.SaveChangesAsync();

            return topic;
        }

        public async Task<Topic> Create(Topic entity)
        {
            await _context.Topics.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
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
