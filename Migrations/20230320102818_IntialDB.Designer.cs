﻿// <auto-generated />
using System;
using AlumniNetworkAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlumniNetworkAPI.Migrations
{
    [DbContext(typeof(AlumniNetworkDBContext))]
    [Migration("20230320102818_IntialDB")]
    partial class IntialDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AlumniNetworkAPI.Models.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AllowGuests")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventCreatorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EventCreatorId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AllowGuests = true,
                            Description = "Friday night fun. At linnanmäki",
                            EndTime = new DateTime(2023, 3, 17, 21, 0, 0, 0, DateTimeKind.Unspecified),
                            EventCreatorId = 1,
                            LastUpdated = new DateTime(2023, 3, 20, 12, 28, 17, 940, DateTimeKind.Local).AddTicks(8868),
                            Name = "Afterwork",
                            StartTime = new DateTime(2023, 3, 17, 17, 30, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            AllowGuests = true,
                            Description = "Noroffs teachers bootcamp",
                            EndTime = new DateTime(2023, 4, 2, 21, 0, 0, 0, DateTimeKind.Unspecified),
                            EventCreatorId = 2,
                            LastUpdated = new DateTime(2023, 3, 20, 12, 28, 17, 940, DateTimeKind.Local).AddTicks(8919),
                            Name = "Noroff summer bootcamp",
                            StartTime = new DateTime(2023, 3, 31, 17, 30, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            AllowGuests = true,
                            Description = "Boardgame tuesday!",
                            EventCreatorId = 3,
                            LastUpdated = new DateTime(2023, 3, 20, 12, 28, 17, 940, DateTimeKind.Local).AddTicks(8922),
                            Name = "Boargames!",
                            StartTime = new DateTime(2023, 3, 21, 17, 30, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("AlumniNetworkAPI.Models.Models.EventUser", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("EventUsers");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            EventId = 1
                        },
                        new
                        {
                            UserId = 3,
                            EventId = 1
                        },
                        new
                        {
                            UserId = 2,
                            EventId = 2
                        },
                        new
                        {
                            UserId = 3,
                            EventId = 2
                        },
                        new
                        {
                            UserId = 3,
                            EventId = 3
                        });
                });

            modelBuilder.Entity("AlumniNetworkAPI.Models.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Experis employees",
                            IsPrivate = false,
                            Name = "Experis workers"
                        },
                        new
                        {
                            Id = 2,
                            Description = "The amazing teachers of noroff.",
                            IsPrivate = true,
                            Name = "Noroff teachers"
                        });
                });

            modelBuilder.Entity("AlumniNetworkAPI.Models.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<int?>("ParentPostId")
                        .HasColumnType("int");

                    b.Property<int?>("TargetUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TopicId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("GroupId");

                    b.HasIndex("ParentPostId");

                    b.HasIndex("TargetUserId");

                    b.HasIndex("TopicId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "My very first content.",
                            TimeStamp = new DateTime(2023, 3, 20, 12, 28, 17, 940, DateTimeKind.Local).AddTicks(8938),
                            Title = "Afterwork coming soon!",
                            TopicId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Content = "Lets GOO!",
                            ParentPostId = 1,
                            TimeStamp = new DateTime(2023, 3, 20, 12, 28, 17, 940, DateTimeKind.Local).AddTicks(8941),
                            TopicId = 1,
                            UserId = 3
                        },
                        new
                        {
                            Id = 3,
                            Content = "Get reafy to pack your bags!",
                            GroupId = 2,
                            TimeStamp = new DateTime(2023, 3, 20, 12, 28, 17, 940, DateTimeKind.Local).AddTicks(8944),
                            Title = "Bootcamp coming soon",
                            UserId = 2
                        },
                        new
                        {
                            Id = 4,
                            Content = "Does someone have trangia?",
                            EventId = 2,
                            TimeStamp = new DateTime(2023, 3, 20, 12, 28, 17, 940, DateTimeKind.Local).AddTicks(8946),
                            UserId = 3
                        },
                        new
                        {
                            Id = 5,
                            Content = "What boardgames people like to play?",
                            GroupId = 1,
                            TimeStamp = new DateTime(2023, 3, 20, 12, 28, 17, 940, DateTimeKind.Local).AddTicks(8948),
                            Title = "Boardgames",
                            UserId = 1
                        },
                        new
                        {
                            Id = 6,
                            Content = "Ark Nova is the best!",
                            GroupId = 1,
                            ParentPostId = 5,
                            TimeStamp = new DateTime(2023, 3, 20, 12, 28, 17, 940, DateTimeKind.Local).AddTicks(8950),
                            UserId = 3
                        },
                        new
                        {
                            Id = 7,
                            Content = "Is it one of the games in SM-competition of boardgames?",
                            GroupId = 1,
                            ParentPostId = 5,
                            TargetUserId = 3,
                            TimeStamp = new DateTime(2023, 3, 20, 12, 28, 17, 940, DateTimeKind.Local).AddTicks(8953),
                            UserId = 1
                        },
                        new
                        {
                            Id = 8,
                            Content = "What do your prefer?",
                            GroupId = 2,
                            TimeStamp = new DateTime(2023, 3, 20, 12, 28, 17, 940, DateTimeKind.Local).AddTicks(8956),
                            Title = "Best language to teach?",
                            UserId = 3
                        },
                        new
                        {
                            Id = 9,
                            Content = "Me first Javascript!",
                            GroupId = 2,
                            ParentPostId = 8,
                            TimeStamp = new DateTime(2023, 3, 20, 12, 28, 17, 940, DateTimeKind.Local).AddTicks(9005),
                            UserId = 3
                        },
                        new
                        {
                            Id = 10,
                            Content = "C# is the best",
                            GroupId = 2,
                            ParentPostId = 8,
                            TimeStamp = new DateTime(2023, 3, 20, 12, 28, 17, 940, DateTimeKind.Local).AddTicks(9009),
                            UserId = 2
                        });
                });

            modelBuilder.Entity("AlumniNetworkAPI.Models.Models.Rsvp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("GuestCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Rsvps");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EventId = 1,
                            GuestCount = 1,
                            LastUpdated = new DateTime(2023, 3, 20, 12, 28, 17, 940, DateTimeKind.Local).AddTicks(9032),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            EventId = 2,
                            GuestCount = 1,
                            LastUpdated = new DateTime(2023, 3, 20, 12, 28, 17, 940, DateTimeKind.Local).AddTicks(9035),
                            UserId = 2
                        });
                });

            modelBuilder.Entity("AlumniNetworkAPI.Models.Models.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Topics");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "In this topic we don't talk about work, only fun.",
                            Name = "Afterwork"
                        },
                        new
                        {
                            Id = 2,
                            Description = "In this topic we don't talk about work, only sports.",
                            Name = "Sports"
                        });
                });

            modelBuilder.Entity("AlumniNetworkAPI.Models.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FunFact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bio = "I am a proactive worker!",
                            FirstName = "Jaska",
                            FunFact = "Avocados are a fruit, not a vegetable. They're technically considered a single-seeded berry, believe it or not.",
                            LastName = "Jokunen",
                            PictureUrl = "https://static.wikia.nocookie.net/familyguy/images/e/ee/FamilyGuy_Single_ChrisText_R7.jpg/revision/latest/scale-to-width-down/350?cb=20200526171839",
                            Status = "Working at Experis",
                            Username = "JaskaMan"
                        },
                        new
                        {
                            Id = 2,
                            Bio = "I am a happy worker!",
                            FirstName = "Emma",
                            FunFact = "Liechtenstein and Uzbekistan are the only doubly landlocked countries.",
                            LastName = "Jokunen",
                            PictureUrl = "https://static.wikia.nocookie.net/familyguy/images/1/1b/FamilyGuy_Single_MegMakeup_R7.jpg/revision/latest/scale-to-width-down/350?cb=20200526171840",
                            Status = "Working at Noroff",
                            Username = "EmmAA"
                        },
                        new
                        {
                            Id = 3,
                            Bio = "I love computers!",
                            FirstName = "Seamus",
                            FunFact = "The sky is blue",
                            LastName = "Smith",
                            PictureUrl = "https://static.wikia.nocookie.net/familyguy/images/1/1b/FamilyGuy_Single_MegMakeup_R7.jpg/revision/latest/scale-to-width-down/350?cb=20200526171840",
                            Status = "Working with IBM",
                            Username = "seamass"
                        });
                });

            modelBuilder.Entity("EventGroup", b =>
                {
                    b.Property<int>("GroupsId")
                        .HasColumnType("int");

                    b.Property<int>("EventsId")
                        .HasColumnType("int");

                    b.HasKey("GroupsId", "EventsId");

                    b.HasIndex("EventsId");

                    b.ToTable("EventGroup");

                    b.HasData(
                        new
                        {
                            GroupsId = 2,
                            EventsId = 3
                        });
                });

            modelBuilder.Entity("EventTopic", b =>
                {
                    b.Property<int>("TopicsId")
                        .HasColumnType("int");

                    b.Property<int>("EventsId")
                        .HasColumnType("int");

                    b.HasKey("TopicsId", "EventsId");

                    b.HasIndex("EventsId");

                    b.ToTable("EventTopic");

                    b.HasData(
                        new
                        {
                            TopicsId = 1,
                            EventsId = 1
                        },
                        new
                        {
                            TopicsId = 2,
                            EventsId = 2
                        });
                });

            modelBuilder.Entity("GroupUser", b =>
                {
                    b.Property<int>("GroupsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("GroupsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("GroupUser");

                    b.HasData(
                        new
                        {
                            GroupsId = 1,
                            UsersId = 1
                        },
                        new
                        {
                            GroupsId = 1,
                            UsersId = 3
                        },
                        new
                        {
                            GroupsId = 2,
                            UsersId = 2
                        },
                        new
                        {
                            GroupsId = 2,
                            UsersId = 3
                        });
                });

            modelBuilder.Entity("TopicUser", b =>
                {
                    b.Property<int>("TopicsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("TopicsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("TopicUser");

                    b.HasData(
                        new
                        {
                            TopicsId = 1,
                            UsersId = 1
                        },
                        new
                        {
                            TopicsId = 1,
                            UsersId = 3
                        },
                        new
                        {
                            TopicsId = 2,
                            UsersId = 2
                        },
                        new
                        {
                            TopicsId = 2,
                            UsersId = 3
                        });
                });

            modelBuilder.Entity("AlumniNetworkAPI.Models.Models.Event", b =>
                {
                    b.HasOne("AlumniNetworkAPI.Models.Models.User", "EventCreator")
                        .WithMany("Events")
                        .HasForeignKey("EventCreatorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("EventCreator");
                });

            modelBuilder.Entity("AlumniNetworkAPI.Models.Models.EventUser", b =>
                {
                    b.HasOne("AlumniNetworkAPI.Models.Models.Event", "Event")
                        .WithMany("EventUsers")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AlumniNetworkAPI.Models.Models.User", "User")
                        .WithMany("EventUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AlumniNetworkAPI.Models.Models.Post", b =>
                {
                    b.HasOne("AlumniNetworkAPI.Models.Models.Event", "Event")
                        .WithMany("Posts")
                        .HasForeignKey("EventId");

                    b.HasOne("AlumniNetworkAPI.Models.Models.Group", "Group")
                        .WithMany("Posts")
                        .HasForeignKey("GroupId");

                    b.HasOne("AlumniNetworkAPI.Models.Models.Post", "ParentPost")
                        .WithMany()
                        .HasForeignKey("ParentPostId");

                    b.HasOne("AlumniNetworkAPI.Models.Models.User", "TargetUser")
                        .WithMany()
                        .HasForeignKey("TargetUserId");

                    b.HasOne("AlumniNetworkAPI.Models.Models.Topic", "Topic")
                        .WithMany("Posts")
                        .HasForeignKey("TopicId");

                    b.HasOne("AlumniNetworkAPI.Models.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Group");

                    b.Navigation("ParentPost");

                    b.Navigation("TargetUser");

                    b.Navigation("Topic");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AlumniNetworkAPI.Models.Models.Rsvp", b =>
                {
                    b.HasOne("AlumniNetworkAPI.Models.Models.Event", "Event")
                        .WithMany("Rsvps")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlumniNetworkAPI.Models.Models.User", "User")
                        .WithMany("Rsvps")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EventGroup", b =>
                {
                    b.HasOne("AlumniNetworkAPI.Models.Models.Event", null)
                        .WithMany()
                        .HasForeignKey("EventsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlumniNetworkAPI.Models.Models.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EventTopic", b =>
                {
                    b.HasOne("AlumniNetworkAPI.Models.Models.Event", null)
                        .WithMany()
                        .HasForeignKey("EventsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlumniNetworkAPI.Models.Models.Topic", null)
                        .WithMany()
                        .HasForeignKey("TopicsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GroupUser", b =>
                {
                    b.HasOne("AlumniNetworkAPI.Models.Models.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlumniNetworkAPI.Models.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TopicUser", b =>
                {
                    b.HasOne("AlumniNetworkAPI.Models.Models.Topic", null)
                        .WithMany()
                        .HasForeignKey("TopicsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlumniNetworkAPI.Models.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AlumniNetworkAPI.Models.Models.Event", b =>
                {
                    b.Navigation("EventUsers");

                    b.Navigation("Posts");

                    b.Navigation("Rsvps");
                });

            modelBuilder.Entity("AlumniNetworkAPI.Models.Models.Group", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("AlumniNetworkAPI.Models.Models.Topic", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("AlumniNetworkAPI.Models.Models.User", b =>
                {
                    b.Navigation("EventUsers");

                    b.Navigation("Events");

                    b.Navigation("Posts");

                    b.Navigation("Rsvps");
                });
#pragma warning restore 612, 618
        }
    }
}
