using AlumniNetworkAPI.Models.DTOs.PostDtos;

namespace AlumniNetworkAPI.Models.DTOs.EventDtos
{
    public class EventNamesDto
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public List<String>? Topic { get; set; }
        public List<String>? Group { get; set; }
        public ICollection<SimplePostDto>? ChildPosts { get; set; }
    }
}
