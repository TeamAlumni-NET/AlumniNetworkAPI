using AlumniNetworkAPI.Models.Models;

namespace AlumniNetworkAPI.Models.DTOs.Rsvp
{
    public class RsvpDto
    {
        public int Id { get; set; }
        public DateTime LastUpdated { get; set; }
        public int GuestCount { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
    }
}
