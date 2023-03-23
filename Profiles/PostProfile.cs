﻿using AlumniNetworkAPI.Models.DTOs.PostDtos;
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
                .ForMember(dto => dto.User, options =>
                options.MapFrom(postDomain => postDomain.User.Username))
                .ForMember(dto => dto.Group, options =>
                options.MapFrom(postDomain => postDomain.Group.Name))
                .ForMember(dto => dto.Topic, options =>
                options.MapFrom(postDomain => postDomain.Topic.Name))
                .ForMember(dto => dto.ChildPosts, options =>
                options.MapFrom(eventDomain => eventDomain.ChildPosts
                .Select(post => new SimplePostDto { Id = post.Id, User = post.User.Username, Content = post.Content }).ToList()));
            CreateMap<TimelinePostDto, SimplePostDto>().ReverseMap();
            CreateMap<Post, PostWithCommentsDto>().ReverseMap();

        }
    }
}
