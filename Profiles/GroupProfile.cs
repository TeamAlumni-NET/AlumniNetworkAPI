using AlumniNetworkAPI.Models.DTOs.GroupDtos;
using AlumniNetworkAPI.Models.Models;
using AutoMapper;

namespace AlumniNetworkAPI.Profiles
{
    public class GroupProfile: Profile
    {
        public GroupProfile() 
        {
            CreateMap<GroupDto, Group>().ReverseMap();
        }
    }
}
