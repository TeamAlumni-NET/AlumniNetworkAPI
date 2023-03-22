namespace AlumniNetworkAPI.Models.DTOs.PostDtos
{
    public class TimelinePostDto
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string? Title { get; set; }
        public string User { get; set; }
        public string? Topic { get; set; }
        public string? Group { get; set; }
        public List<SimplePostDto>? Posts { get; set; }
    }
}
