using AlumniNetworkAPI.Exceptions;
using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.Models;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<Group> AddUserToGroup(int groupId, int userId)
        {
            var group = await _context.Groups.Include(x => x.Users).Where(x => x.Id == groupId).FirstAsync();
            var user = await _context.Users.FindAsync(userId);

            group.Users.Add(user);
            await _context.SaveChangesAsync();  

            return group;
        }

        public async Task<Group> Create(Group entity)
        {
            await _context.Groups.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
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
