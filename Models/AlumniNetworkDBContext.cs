using AlumniNetworkAPI.Models.Models;
using Microsoft.EntityFrameworkCore;


namespace AlumniNetworkAPI.Models
{
    public class AlumniNetworkDBContext : DbContext
    {
        public AlumniNetworkDBContext(DbContextOptions options) : base(options)
        { 
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Rsvp> Rsvps { get; set; }
        public DbSet<Topic> Topics { get; set; }
    }
}
