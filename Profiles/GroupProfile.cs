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
            CreateMap<GroupCreateDto, Group>().ReverseMap();
            CreateMap<Group, GroupDto>()
                .ForMember(dto => dto.Users, options =>
                options.MapFrom(groupDomain => groupDomain.Users.Select(u => u.Id).ToList()));
        }
    }
}
