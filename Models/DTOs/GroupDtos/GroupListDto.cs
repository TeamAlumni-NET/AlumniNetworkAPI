using AlumniNetworkAPI.Models.Models;
using System.ComponentModel.DataAnnotations;

namespace AlumniNetworkAPI.Models.DTOs.GroupDtos
{
    public class GroupListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsUsers { get; set; }

    }
}
