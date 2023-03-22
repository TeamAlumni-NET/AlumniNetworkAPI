using System.ComponentModel.DataAnnotations;

namespace AlumniNetworkAPI.Models.DTOs.TopicDtos
{
    public class TopicCreateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
