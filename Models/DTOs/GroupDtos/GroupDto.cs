using AlumniNetworkAPI.Models.Models;
using System.ComponentModel.DataAnnotations;

namespace AlumniNetworkAPI.Models.DTOs.GroupDtos
{
    public class GroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPrivate { get; set; }
        public List<int> Users { get; set; }
        public List<int> Posts { get; set; }
        public List<int> Events { get; set; }
    }
}
