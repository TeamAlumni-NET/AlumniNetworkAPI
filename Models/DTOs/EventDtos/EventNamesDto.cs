namespace AlumniNetworkAPI.Models.DTOs.EventDtos
{
    public class EventNamesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public String? Topics { get; set; }
        public String? Groups { get; set; }
    }
}
