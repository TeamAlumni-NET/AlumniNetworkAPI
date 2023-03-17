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
            //DeleteBehavior configuration
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
            //Dummy data to DB
            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        Id = 1,
                        Username = "JaskaMan",
                        FirstName = "Jaska",
                        LastName = "Jokunen",
                        Status = "Working at Experis",
                        Bio = "I am a proactive worker!",
                        FunFact = "Avocados are a fruit, not a vegetable. They're technically considered a single-seeded berry, believe it or not.",
                        PictureUrl = "https://static.wikia.nocookie.net/familyguy/images/e/ee/FamilyGuy_Single_ChrisText_R7.jpg/revision/latest/scale-to-width-down/350?cb=20200526171839"
                    },
                    new User
                    {
                        Id = 2,
                        Username = "EmmAA",
                        FirstName = "Emma",
                        LastName = "Jokunen",
                        Status = "Working at Noroff",
                        Bio = "I am a happy worker!",
                        FunFact = "Liechtenstein and Uzbekistan are the only doubly landlocked countries.",
                        PictureUrl = "https://static.wikia.nocookie.net/familyguy/images/1/1b/FamilyGuy_Single_MegMakeup_R7.jpg/revision/latest/scale-to-width-down/350?cb=20200526171840"
                    },
                    new User
                    {
                        Id = 3,
                        Username = "seamass",
                        FirstName = "Seamus",
                        LastName = "Smith",
                        Status = "Working with IBM",
                        Bio = "I love computers!",
                        FunFact = "The sky is blue",
                        PictureUrl = "https://static.wikia.nocookie.net/familyguy/images/1/1b/FamilyGuy_Single_MegMakeup_R7.jpg/revision/latest/scale-to-width-down/350?cb=20200526171840"
                    }
                    );
            modelBuilder.Entity<Group>()
                .HasData(
                    new Group
                    {
                        Id = 1,
                        Name = "Experis workers",
                        Description = "Experis employees",
                        IsPrivate = false
                    },
                    new Group
                    {
                        Id = 2,
                        Name = "Noroff teachers",
                        Description = "The amazing teachers of noroff.",
                        IsPrivate = true
                    }
                );
            modelBuilder.Entity<Topic>()
                .HasData(
                    new Topic
                    {
                        Id = 1,
                        Name = "Afterwork",
                        Description = "In this topic we don't talk about work, only fun."
                    },
                    new Topic
                    {
                        Id = 2,
                        Name = "Sports",
                        Description = "In this topic we don't talk about work, only sports."
                    }
                );
            modelBuilder.Entity<Event>()
                .HasData(
                new Event
                {
                    Id = 1,
                    LastUpdated = DateTime.Now,
                    Name = "Afterwork",
                    Description = "Friday night fun. At linnanmäki",
                    AllowGuests = true,
                    StartTime = new DateTime(2023, 7, 5, 17, 30, 00),
                    EndTime = new DateTime(2023, 7, 5, 21, 00, 00),
                    EventCreatorId = 1
                },
                new Event
                {
                    Id = 2,
                    LastUpdated = DateTime.Now,
                    Name = "Noroff summer bootcamp",
                    Description = "Noroffs teachers bootcamp",
                    AllowGuests = true,
                    StartTime = new DateTime(2023, 6, 8, 17, 30, 00),
                    EndTime = new DateTime(2023, 6, 10, 21, 00, 00),
                    EventCreatorId = 2
                }
                );
            modelBuilder.Entity<Post>()
                .HasData(
                    new Post
                    {
                        Id = 1,
                        TimeStamp = DateTime.Now,
                        Title = "Afterwork coming soon!",
                        Content = "My very first content.",
                        UserId = 1,
                        TopicId = 1,
                        GroupId = 1,
                        EventId = 1
                    },
                    new Post
                    {
                        Id = 2,
                        TimeStamp = DateTime.Now,
                        Content = "Lets GOO!",
                        UserId = 1,
                        TopicId = 1,
                        GroupId = 1,
                        EventId = 1,
                        ParentPostId = 1
                    },
                     new Post
                     {
                         Id = 3,
                         TimeStamp = DateTime.Now,
                         Title = "Bootcamp coming soon",
                         Content = "My very first content.",
                         UserId = 2,
                         TopicId = 2,
                         GroupId = 2,
                         EventId = 2
                     }
                );
            modelBuilder.Entity<Rsvp>()
                .HasData(
                new Rsvp
                {
                    Id = 1,
                    LastUpdated = DateTime.Now,
                    GuestCount = 1,
                    UserId = 1,
                    EventId = 1,
                },
                 new Rsvp
                 {
                     Id = 2,
                     LastUpdated = DateTime.Now,
                     GuestCount = 1,
                     UserId = 2,
                     EventId = 2,
                 }
                );
            modelBuilder.Entity<EventUser>()
                .HasData(
                new EventUser
                {
                    EventId = 1,
                    UserId = 1
                },
                 new EventUser
                 {
                     EventId = 1,
                     UserId = 3
                 },
                  new EventUser
                  {
                      EventId = 2,
                      UserId = 2
                  },
                   new EventUser
                   {
                       EventId = 2,
                       UserId = 3
                   }
                );
            modelBuilder.Entity<User>()
                .HasMany(x => x.Topics)
                .WithMany(x => x.Users)
                .UsingEntity<Dictionary<string, object>>(
                "TopicUser",
                l => l.HasOne<Topic>().WithMany().HasForeignKey("TopicsId"),
                r => r.HasOne<User>().WithMany().HasForeignKey("UsersId"),
                je =>
                {
                    je.HasKey("TopicsId", "UsersId");
                    je.HasData(
                        new { TopicsId = 1, UsersId = 1 },
                        new { TopicsId = 1, UsersId = 3 },
                        new { TopicsId = 2, UsersId = 2 },
                        new { TopicsId = 2, UsersId = 3 }
                        );

                }
                );
            modelBuilder.Entity<Event>()
                .HasMany(x => x.Topics)
                .WithMany(x => x.Events)
                .UsingEntity<Dictionary<string, object>>(
                "EventTopic",
                l => l.HasOne<Topic>().WithMany().HasForeignKey("TopicsId"),
                r => r.HasOne<Event>().WithMany().HasForeignKey("EventsId"),
                je =>
                {
                    je.HasKey("TopicsId", "EventsId");
                    je.HasData(
                        new { TopicsId = 1, EventsId = 1 },
                        new { TopicsId = 2, EventsId = 2 }

                        );

                }
                );
            modelBuilder.Entity<Event>()
                .HasMany(x => x.Groups)
                .WithMany(x => x.Events)
                .UsingEntity<Dictionary<string, object>>(
                "EventGroup",
                l => l.HasOne<Group>().WithMany().HasForeignKey("GroupsId"),
                r => r.HasOne<Event>().WithMany().HasForeignKey("EventsId"),
                je =>
                {
                    je.HasKey("GroupsId", "EventsId");
                    je.HasData(
                        new { GroupsId = 1, EventsId = 1 },
                        new { GroupsId = 2, EventsId = 2 }

                        );

                }
                );
            modelBuilder.Entity<User>()
                .HasMany(x => x.Groups)
                .WithMany(x => x.Users)
                .UsingEntity<Dictionary<string, object>>(
                "GroupUser",
                l => l.HasOne<Group>().WithMany().HasForeignKey("GroupsId"),
                r => r.HasOne<User>().WithMany().HasForeignKey("UsersId"),
                je =>
                {
                    je.HasKey("GroupsId", "UsersId");
                    je.HasData(
                        new { GroupsId = 1, UsersId = 1 },
                        new { GroupsId = 1, UsersId = 3 },
                        new { GroupsId = 2, UsersId = 2 },
                        new { GroupsId = 2, UsersId = 3 }
                        );

                }
                );
        }
    }
}
