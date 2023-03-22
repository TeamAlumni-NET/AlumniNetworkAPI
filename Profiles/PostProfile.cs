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
            CreateMap<Post, TimelinePostDto>()
                .ForMember(dto => dto.User, options =>
                options.MapFrom(postDomain => postDomain.User.Username))
                .ForMember(dto => dto.Group, options =>
                options.MapFrom(postDomain => postDomain.Group.Name))
                .ForMember(dto => dto.Topic, options => 
                options.MapFrom(postDomain => postDomain.Topic.Name));
            CreateMap<TimelinePostDto, SimplePostDto>().ReverseMap();

        }
    }
}
