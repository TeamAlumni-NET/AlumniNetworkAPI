using AlumniNetworkAPI.Models.DTOs.Topic;
using AlumniNetworkAPI.Models.Models;
using AutoMapper;

namespace AlumniNetworkAPI.Profiles
{
    public class TopicProfile: Profile
    {
        public TopicProfile() 
        {
            CreateMap<TopicDto, Topic>().ReverseMap();  
        }
    }
}
