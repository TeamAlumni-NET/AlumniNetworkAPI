using AlumniNetworkAPI.Models.DTOs.EventDtos;
using AlumniNetworkAPI.Models.DTOs.PostDtos;
using AlumniNetworkAPI.Models.DTOs.UserDtos;

namespace AlumniNetworkAPI.Models.DTOs.GroupDtos
{
    public class GroupCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPrivate { get; set; }
     
    }
}
