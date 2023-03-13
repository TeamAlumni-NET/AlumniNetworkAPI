using AlumniNetworkAPI.Models.DTOs.User;
using AlumniNetworkAPI.Models.Models;
using AutoMapper;

namespace AlumniNetworkAPI.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile() 
        {
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
