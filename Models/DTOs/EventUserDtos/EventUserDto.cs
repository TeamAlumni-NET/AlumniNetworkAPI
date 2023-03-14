namespace AlumniNetworkAPI.Models.DTOs.EventUserDtos
{
    public class EventUserDto
    {
        public int UserId { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
