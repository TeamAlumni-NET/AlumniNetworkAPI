﻿using AlumniNetworkAPI.Models.Models;

namespace AlumniNetworkAPI.Services.Users
{
    public interface IUserService : ICrudService<User, int>
    {
        Task<User> GetByUsername(string username);
    }
}
