using AlumniNetworkAPI.Models.DTOs.EventDtos;
using AlumniNetworkAPI.Models.Models;
using AutoMapper;

namespace AlumniNetworkAPI.Profiles
{
    public class EventProfile : Profile
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
            CreateMap<EventCreateDto, Event>().ReverseMap();

            CreateMap<Event, EventNamesDto>()
                .ForMember(dto => dto.Group, options =>
                options.MapFrom(eventDomain => eventDomain.Groups.Select(g => g.Name).ToList()))
                .ForMember(dto => dto.Topic, options =>
                options.MapFrom(eventDomain => eventDomain.Topics.Select(g => g.Name).ToList()))
                .ForMember(dto => dto.TimeStamp, options =>
                options.MapFrom(eventDomain => eventDomain.LastUpdated))
                .ForMember(dto => dto.ChildPosts, options =>
                options.MapFrom(eventDomain => eventDomain.Posts));

            CreateMap<Event, EventCalendarDto>()
                .ForMember(dto => dto.title, opt =>
               opt.MapFrom(src => src.Name))
                .ForMember(dto => dto.start, opt =>
                   opt.MapFrom(src => src.StartTime))
                .ForMember(dto => dto.end, opt =>
                   opt.MapFrom(src => src.EndTime))
                .ReverseMap();
        }
    }
}
