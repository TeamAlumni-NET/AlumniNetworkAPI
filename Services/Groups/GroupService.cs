using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Linq;

namespace AlumniNetworkAPI.Services.Groups
{
    public class GroupService : IGroupService
    {
        private readonly AlumniNetworkDBContext _context;

        public GroupService(AlumniNetworkDBContext dbContext)
        {
            _context = dbContext;
        }

        public Task<Group> Create(Group entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Group>> GetAll()
        {
            return await _context.Groups.Include(g => g.Users).ToListAsync();
        }


        public Task<Group> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Group> Update(Group entity)
        {
            throw new NotImplementedException();
        }
    }
}
