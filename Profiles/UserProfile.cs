﻿using AlumniNetworkAPI.Models.DTOs.UserDtos;
using AlumniNetworkAPI.Models.Models;
using AutoMapper;

namespace AlumniNetworkAPI.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile() 
        {
            CreateMap<UserDto, User>().ReverseMap();

            CreateMap<UserEditDto, User>().ReverseMap();

            CreateMap<UserCreateDto, User>().ReverseMap();
        }
    }
}
