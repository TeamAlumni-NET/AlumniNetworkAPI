using AlumniNetworkAPI.Models.DTOs.GroupDtos;
using AlumniNetworkAPI.Models.Models;

namespace AlumniNetworkAPI.Services.Groups
{
    public interface IGroupService : ICrudService<Group, int>
    { 
        Task<Group> AddUserToGroup(int id, int userId);
    }
}
