using AlumniNetworkAPI.Models.DTOs.EventUserDtos;
using AutoMapper;

namespace AlumniNetworkAPI.Profiles
{
    public class EventUser: Profile
    {
        public EventUser() 
        {
            CreateMap<EventUserDto, EventUser>().ReverseMap();
        }
    }
}
