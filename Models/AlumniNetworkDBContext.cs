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
                        PictureUrl = "https://memesbams.com/wp-content/uploads/2017/10/homer-simpson-mmm-meme.jpg"
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
                        PictureUrl = "https://is.mediadelivery.fi/img/978/3f8de8ba787e4ae89c0322f57337435b.jpg.webp"
                    },
                    new User
                    {
                        Id = 3,
                        Username = "seamass",
                        FirstName = "Seamus",
                        LastName = "Smith",
                        Status = "Working with IBM",
                        Bio = "I love computers!",
                        FunFact = "The real name for a hashtag is an octothorpe.",
                        PictureUrl = "https://www.misir.fi/wp-content/uploads/2015/08/harald-200x200.jpg"
                    }
                    );
            modelBuilder.Entity<Group>()
                .HasData(
                    new Group
                    {
                        Id = 1,
                        Name = "Experis workers",
                        Description = "Experis employees",
                        IsPrivate = false,
                    },
                    new Group
                    {
                        Id = 2,
                        Name = "Noroff teachers",
                        Description = "The amazing teachers of noroff.",
                        IsPrivate = true,
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
                    StartTime = new DateTime(2023, 3, 17, 17, 30, 00),
                    EndTime = new DateTime(2023, 3, 17, 21, 00, 00),
                    EventCreatorId = 1
                },
                new Event
                {
                    Id = 2,
                    LastUpdated = DateTime.Now,
                    Name = "Noroff summer bootcamp",
                    Description = "Noroffs teachers bootcamp",
                    AllowGuests = true,
                    StartTime = new DateTime(2023, 3, 31, 17, 30, 00),
                    EndTime = new DateTime(2023, 4, 2, 21, 00, 00),
                    EventCreatorId = 2
                },
                new Event
                {
                    Id = 3,
                    LastUpdated = DateTime.Now,
                    Name = "Boargames!",
                    Description = "Boardgame tuesday!",
                    AllowGuests = true,
                    StartTime = new DateTime(2023, 3, 21, 17, 30, 00),
                    EventCreatorId = 3
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
                    },
                     new Post
                     {
                         Id = 20,
                         TimeStamp = DateTime.Now,
                         Title = "Gamers!",
                         Content = "Only videogames!.",
                         UserId = 1,
                         TopicId = 1,
                     },
                     new Post
                     {
                         Id = 21,
                         TimeStamp = DateTime.Now,
                         Content = "Ayyyyyy!.",
                         UserId = 1,
                         TopicId = 1,
                         ParentPostId = 20,
                     },
                     new Post
                     {
                         Id = 22,
                         TimeStamp = DateTime.Now,
                         Content = "You're such a noob!.",
                         UserId = 2,
                         TopicId = 1,
                     },
                    new Post
                    {
                        Id = 2,
                        TimeStamp = DateTime.Now,
                        Content = "Lets GOO!",
                        UserId = 3,
                        TopicId = 1,
                        ParentPostId = 1
                    },
                     new Post
                     {
                         Id = 3,
                         TimeStamp = DateTime.Now,
                         Title = "Bootcamp coming soon",
                         Content = "Get reafy to pack your bags!",
                         UserId = 2,
                         GroupId = 2,
                     },
                     new Post
                     {
                         Id = 4,
                         TimeStamp = DateTime.Now,
                         Content = "Does someone have trangia?",
                         UserId = 3,
                         EventId = 2
                     },
                     new Post
                     {
                         Id = 5,
                         TimeStamp = DateTime.Now,
                         Title = "Boardgames",
                         Content = "What boardgames people like to play?",
                         UserId = 1,
                         GroupId = 1,
                     },
                      new Post
                      {
                          Id = 11,
                          TimeStamp = DateTime.Now,
                          Title = "Lan party",
                          Content = "What games people like to play?",
                          UserId = 1,
                          GroupId = 1,
                      },
                      new Post
                      {
                          Id = 12,
                          TimeStamp = DateTime.Now,
                          Content = "League of legends",
                          UserId = 3,
                          GroupId = 1,
                          ParentPostId = 11,
                      },
                       new Post
                       {
                           Id = 13,
                           TimeStamp = DateTime.Now,
                           Content = "Omg who plays leage 2023?!",
                           UserId = 3,
                           GroupId = 1,
                           ParentPostId = 12,
                       },
                     new Post
                     {
                         Id = 6,
                         TimeStamp = DateTime.Now,
                         Content = "Ark Nova is the best!",
                         UserId = 3,
                         GroupId = 1,
                         ParentPostId = 5,
                     },
                     new Post
                     {
                         Id = 7,
                         TimeStamp = DateTime.Now,
                         Content = "Is it one of the games in SM-competition of boardgames?",
                         UserId = 1,
                         GroupId = 1,
                         ParentPostId = 5,
                         TargetUserId = 3,
                     },
                     new Post
                     {
                         Id = 8,
                         TimeStamp = DateTime.Now,
                         Title = "Best language to teach?",
                         Content = "What do your prefer?",
                         UserId = 3,
                         GroupId = 2,
                     },
                     new Post
                     {
                         Id = 9,
                         TimeStamp = DateTime.Now,
                         Content = "Me first Javascript!",
                         UserId = 3,
                         GroupId = 2,
                         ParentPostId = 8,
                     },
                     new Post
                     {
                         Id = 10,
                         TimeStamp = DateTime.Now,
                         Content = "C# is the best",
                         UserId = 2,
                         GroupId = 2,
                         ParentPostId = 8,
                     }, new Post
                     {
                         Id = 25,
                         TimeStamp = DateTime.Now,
                         Content = "I do have, but Im out of gas",
                         UserId = 1,
                         EventId = 2,
                         TargetUserId= 3,
                     },
                     new Post
                     {
                         Id = 26,
                         TimeStamp = DateTime.Now,
                         Content = "Remember, no arcade games with company credit card!",
                         UserId = 1,
                         EventId = 1
                     },
                     new Post
                     {
                         Id = 27,
                         TimeStamp = DateTime.Now,
                         Content = "Not even pony race?",
                         UserId = 2,
                         EventId = 2,
                         TargetUserId= 1,
                     },
                     new Post
                     {
                         Id = 28,
                         TimeStamp = DateTime.Now,
                         Content = "Havent lost in trivial Pursuit since 2005, who want to try to beat me?",
                         UserId = 3,
                         EventId = 3
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
                },
                new EventUser
                {
                    EventId = 3,
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
                        new { GroupsId = 2, EventsId = 3 }

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
