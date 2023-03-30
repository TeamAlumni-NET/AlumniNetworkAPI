using AlumniNetworkAPI.Models.DTOs.PostDtos;
using AlumniNetworkAPI.Models.DTOs.UserDtos;
using AlumniNetworkAPI.Models.Models;
using AutoMapper;

namespace AlumniNetworkAPI.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<CreatePostDto, Post>().ReverseMap();
            CreateMap<PostDto, Post>().ReverseMap();
            CreateMap<EditPostDto, Post>().ReverseMap();
            CreateMap<ChildPostDto, Post>().ReverseMap();
            CreateMap<ChildPostRootDto, ChildPostDto>().ReverseMap();

            CreateMap<Post, TimelinePostDto>()
                .ForMember(dto => dto.Group, options =>
                options.MapFrom(postDomain => postDomain.Group.Name))
                .ForMember(dto => dto.Topic, options =>
                options.MapFrom(postDomain => postDomain.Topic.Name));

            CreateMap<TimelinePostDto, SimplePostDto>().ReverseMap();

            CreateMap<Post, SimplePostDto>()
            .ForMember(dto => dto.User, options =>
            options.MapFrom(postDomain => postDomain.User.Username));

            CreateMap<Post, PostByIdDto>()
                .ForMember(dto => dto.User, options =>
                options.MapFrom(postDomain => postDomain.User.Username));
                //.ForMember(dto => dto.picture, options =>
                //options.MapFrom(postDomain => postDomain.User.PictureUrl));

            CreateMap<Post, ChildPostDto>()
                .ForMember(dto => dto.user, options =>
                options.MapFrom(postDomain => new UserSimpleDto
                {
                    Id = postDomain.UserId,
                    Username = postDomain.User.Username,
                    FirstName = postDomain.User.FirstName,
                    LastName = postDomain.User.LastName,
                    PictureUrl = postDomain.User.PictureUrl
                }))
                .ForMember(dto => dto.targetUser, options =>
                options.MapFrom(postDomain => postDomain.TargetUser.Username));

            CreateMap<CreatePostDto, NewPostDto>()
                .ForMember(dto => dto.UserId, options =>
                options.MapFrom(postDomain => postDomain.User.Id));

            CreateMap<NewPostDto, Post>().ReverseMap();
        }
    }
}
