using AlumniNetworkAPI.Models.DTOs.UserDtos;
using AlumniNetworkAPI.Models.Models;

namespace AlumniNetworkAPI.Services.Users
{
    public interface IUserService : ICrudService<User, int>
    {   
        /// <summary>
        /// Gets user by spesific username
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns></returns>
        Task<User> GetByUsername(string username);
        
        /// <summary>
        /// Edits user by username
        /// </summary>
        /// <param name="user">Username</param>
        /// <returns></returns>
        Task<User> PatchByUsername(User user);
    }
}
