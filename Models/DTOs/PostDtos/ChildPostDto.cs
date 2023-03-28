using AlumniNetworkAPI.Models.DTOs.UserDtos;

namespace AlumniNetworkAPI.Models.DTOs.PostDtos
{
    public class ChildPostDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime TimeStamp { get; set; }
        public UserSimpleDto user { get; set; }

        public string targetUser { get; set; }
        
    }
}
