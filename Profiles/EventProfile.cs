using AlumniNetworkAPI.Models.DTOs.EventDtos;
using AlumniNetworkAPI.Models.Models;
using AutoMapper;

namespace AlumniNetworkAPI.Profiles
{
    public class EventProfile: Profile
    {
        public EventProfile() 
        {
            CreateMap<Event, EventDto>()
                .ForMember(dto => dto.Topics, options =>
                options.MapFrom(eventDomain => eventDomain.Topics.Select(topic => $"{topic.Id}").ToList()))
                .ForMember(dto => dto.Posts, options =>
                options.MapFrom(postDomain => postDomain.Posts.Select(post => $"{post.Id}").ToList()))
                .ForMember(dto => dto.Groups, options =>
                options.MapFrom(groupDomain => groupDomain.Groups.Select(group => $"{group.Id}").ToList()));
            CreateMap<EventDto, Event>().ReverseMap();
            CreateMap<Event, EventNamesDto>()
                .ForMember(dto => dto.Groups, options =>
                options.MapFrom(eventDomain => eventDomain.Groups.Select(g => g.Name)))
                .ForMember(dto => dto.Topics, options =>
                options.MapFrom(eventDomain => eventDomain.Topics.Select(g => g.Name)));
        }
    }
}
