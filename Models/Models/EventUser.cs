namespace AlumniNetworkAPI.Models.Models
{
    public class EventUser
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }

    }
}
