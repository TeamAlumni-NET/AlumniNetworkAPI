namespace AlumniNetworkAPI.Models.Models
{
    public class Rsvp
    {
        public int Id { get; set; }
        public DateTime LastUpdated { get; set; }
        public int GuestCount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
