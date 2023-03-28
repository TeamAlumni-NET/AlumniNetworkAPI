namespace AlumniNetworkAPI.Models.DTOs.EventDtos
{
    public class EventCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool AllowGuests { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int EventCreatorId { get; set; }

        public List<int>? Topics { get; set; }
        //public List<int>? EventUsers { get; set; }
        //public List<int>? Posts { get; set; }
        //public List<int>? Rsvps { get; set; }
        public List<int>? Groups { get; set; }
    }
}
