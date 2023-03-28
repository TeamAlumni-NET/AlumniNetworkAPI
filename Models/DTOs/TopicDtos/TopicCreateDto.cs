using System.ComponentModel.DataAnnotations;

namespace AlumniNetworkAPI.Models.DTOs.TopicDtos
{
    public class TopicCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
