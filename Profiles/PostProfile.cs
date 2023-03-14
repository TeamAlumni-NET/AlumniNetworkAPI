using AlumniNetworkAPI.Models.DTOs.PostDtos;
using AlumniNetworkAPI.Models.Models;
using AutoMapper;

namespace AlumniNetworkAPI.Profiles
{
    public class PostProfile: Profile
    {
        public PostProfile() 
        { 
            CreateMap<PostDto, Post>().ReverseMap();
        }
    }
}
