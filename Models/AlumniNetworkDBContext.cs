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
        public DbSet<EventUser> EventUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rsvp>()
                .HasOne<User>(u => u.User)
                .WithMany(r => r.Rsvps)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Event>()
               .HasOne<User>(u => u.EventCreator)
               .WithMany(r => r.Events)
               .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Post>()
               .HasOne<User>(u => u.User)
               .WithMany(r => r.Posts)
               .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<EventUser>()
                .HasKey(u => new { u.UserId, u.EventId });
            modelBuilder.Entity<EventUser>()
                .HasOne<User>(eu => eu.User)
                .WithMany(e => e.EventUsers)
                .HasForeignKey(eu => eu.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<EventUser>()
                .HasOne<Event>(eu => eu.Event)
                .WithMany(e => e.EventUsers)
                .HasForeignKey(eu => eu.EventId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
