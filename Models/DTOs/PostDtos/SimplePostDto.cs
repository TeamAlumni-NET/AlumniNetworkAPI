using AlumniNetworkAPI.Models.Models;

namespace AlumniNetworkAPI.Models.DTOs.PostDtos
{
    public class SimplePostDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public String User { get; set; }
    }
}
