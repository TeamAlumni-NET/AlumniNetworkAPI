using AlumniNetworkAPI.Models.DTOs.UserDtos;
using AlumniNetworkAPI.Models.Models;
using AutoMapper;

namespace AlumniNetworkAPI.Profiles
{
    public class UserCreateProfile : Profile
    {
        public UserCreateProfile()
        {
            CreateMap<UserCreateDto, User>().ReverseMap();
        }
    }
}
