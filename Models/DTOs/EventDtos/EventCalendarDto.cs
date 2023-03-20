namespace AlumniNetworkAPI.Models.DTOs.EventDtos
{
    public class EventCalendarDto
    {
        public int id { get; set; }
        public string title { get; set; }
        public string Description { get; set; }
        public DateTime start { get; set; }
        public DateTime? end { get; set; }
    }
}
