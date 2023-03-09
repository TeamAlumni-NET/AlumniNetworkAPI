using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.Models;

namespace AlumniNetworkAPI.Services.Groups
{
    public class GroupService : IGroupService
    {
        private readonly AlumniNetworkDBContext? _dbContext;
        public Task<Group> Create(Group entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Group>> GetAll()
        {
            throw new NotImplementedException();
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
