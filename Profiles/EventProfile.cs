using AlumniNetworkAPI.Models.DTOs.EventDtos;
using AlumniNetworkAPI.Models.Models;
using AutoMapper;

namespace AlumniNetworkAPI.Profiles
{
    public class EventProfile: Profile
    {
        public EventProfile() 
        {
            CreateMap<EventDto, Event>().ReverseMap();
        }
    }
}
