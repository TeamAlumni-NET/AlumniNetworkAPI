using AlumniNetworkAPI.Models.DTOs.TopicDtos;
using AlumniNetworkAPI.Models.Models;
using AutoMapper;

namespace AlumniNetworkAPI.Profiles
{
    public class TopicProfile: Profile
    {
        public TopicProfile() 
        {
            CreateMap<TopicDto, Topic>().ReverseMap();
            CreateMap<TopicCreateDto, Topic>().ReverseMap();
            CreateMap<Topic, TopicDto>()
                .ForMember(dto => dto.Users, options =>
                options.MapFrom(topicDomain => topicDomain.Users.Select(u => u.Id).ToList()));
        }
    }
}
