using System.ComponentModel.DataAnnotations;

namespace AlumniNetworkAPI.Models.Models
{
    public class Topic
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}



