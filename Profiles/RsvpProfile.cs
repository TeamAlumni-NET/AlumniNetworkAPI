using AlumniNetworkAPI.Models.DTOs.RsvpDtos;
using AlumniNetworkAPI.Models.Models;
using AutoMapper;

namespace AlumniNetworkAPI.Profiles
{
    public class RsvpProfile: Profile
    {
        public RsvpProfile()
        {
            CreateMap<RsvpDto, Rsvp>().ReverseMap();
        }
    }
}
