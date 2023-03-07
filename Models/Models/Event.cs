namespace AlumniNetworkAPI.Models.Models
{
    public class Event
    {
        public int Id { get; set; }
        
        public DateTime LastUpdated { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool AllowGuests { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int UserId { get; set; } 
        public User User { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Rsvp> Rsvps { get; set; }
        public ICollection<Group> Groups { get; set; }

    }
}
