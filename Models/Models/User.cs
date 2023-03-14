using System.ComponentModel.DataAnnotations;

namespace AlumniNetworkAPI.Models.Models
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Status { get; set; }
        public string? Bio { get; set; }
        public string? FunFact { get; set; }
        [Url]
        public string? PictureUrl { get; set; }
        public IList<EventUser> EventUsers { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<Topic> Topics { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Rsvp> Rsvps { get; set; }

    }
}
