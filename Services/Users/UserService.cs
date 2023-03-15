﻿using AlumniNetworkAPI.Exceptions;
using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AlumniNetworkAPI.Services.Users
{
    public class UserService : IUserService
    {
        private readonly AlumniNetworkDBContext? _dbContext;
        private readonly IMapper _mapper;

        public UserService(AlumniNetworkDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<User> Create(User entity)
        {
            var exists = await _dbContext.Users.Where(x => x.Username == entity.Username).ToListAsync();
            foreach (var user in exists) { Console.WriteLine(user); }
            if (exists.Any())
            {
                throw new UserAlreadyExistsException(entity.Username);
            }
            else
            {
                _dbContext.Users.Add(entity);
                await _dbContext.SaveChangesAsync();
            }

            return entity;
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
        public async Task<User> GetByUsername(string username)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == username);
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