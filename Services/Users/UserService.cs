using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace AlumniNetworkAPI.Services.Users
{
    public class UserService : IUserService
    {
        private readonly AlumniNetworkDBContext? _dbContext;

        public UserService(AlumniNetworkDBContext dbContext)
        {
            _dbContext = dbContext;
        }
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

        public async Task<User> GetById(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                throw new NotImplementedException();
            }
            return user;
        }

        public Task<User> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}