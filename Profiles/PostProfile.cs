using AlumniNetworkAPI.Models.DTOs.PostDtos;
using AlumniNetworkAPI.Models.Models;
using AutoMapper;

namespace AlumniNetworkAPI.Profiles
{
    public class PostProfile: Profile
    {
        public PostProfile() 
        {
            CreateMap<CreatePostDto, Post>().ReverseMap();
            CreateMap<PostDto, Post>().ReverseMap();
            CreateMap<EditPostDto, Post>().ReverseMap();
            CreateMap<ChildPostDto, Post>().ReverseMap();
            CreateMap<ChildPostRootDto, ChildPostDto>().ReverseMap();
        }
    }
}
