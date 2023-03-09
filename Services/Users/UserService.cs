using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.Models;

namespace AlumniNetworkAPI.Services.Users
{
    public class UserService : IUserService
    {
        private readonly AlumniNetworkDBContext? _dbContext;
        public Task<User> Create(User entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
