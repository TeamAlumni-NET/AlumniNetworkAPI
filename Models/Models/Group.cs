using System.ComponentModel.DataAnnotations;

namespace AlumniNetworkAPI.Models.Models
{
    public class Group
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPrivate { get; set; }
        public int CreatorId { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
