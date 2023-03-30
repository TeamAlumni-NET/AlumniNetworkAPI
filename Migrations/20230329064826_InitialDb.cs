using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlumniNetworkAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FunFact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllowGuests = table.Column<bool>(type: "bit", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EventCreatorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Users_EventCreatorId",
                        column: x => x.EventCreatorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GroupUser",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUser", x => new { x.GroupsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_GroupUser_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TopicUser",
                columns: table => new
                {
                    TopicsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicUser", x => new { x.TopicsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_TopicUser_Topics_TopicsId",
                        column: x => x.TopicsId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventGroup",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "int", nullable: false),
                    EventsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventGroup", x => new { x.GroupsId, x.EventsId });
                    table.ForeignKey(
                        name: "FK_EventGroup_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventGroup_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventTopic",
                columns: table => new
                {
                    TopicsId = table.Column<int>(type: "int", nullable: false),
                    EventsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTopic", x => new { x.TopicsId, x.EventsId });
                    table.ForeignKey(
                        name: "FK_EventTopic_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTopic_Topics_TopicsId",
                        column: x => x.TopicsId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventUsers", x => new { x.UserId, x.EventId });
                    table.ForeignKey(
                        name: "FK_EventUsers_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EventUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetUserId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TopicId = table.Column<int>(type: "int", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    ParentPostId = table.Column<int>(type: "int", nullable: true),
                    EventId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Posts_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Posts_Posts_ParentPostId",
                        column: x => x.ParentPostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Posts_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Posts_Users_TargetUserId",
                        column: x => x.TargetUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rsvps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuestCount = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rsvps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rsvps_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rsvps_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Description", "IsPrivate", "Name" },
                values: new object[,]
                {
                    { 1, "Experis employees", false, "Experis workers" },
                    { 2, "The amazing teachers of noroff.", true, "Noroff teachers" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "In this topic we don't talk about work, only fun.", "Afterwork" },
                    { 2, "In this topic we don't talk about work, only sports.", "Sports" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Bio", "FirstName", "FunFact", "LastName", "PictureUrl", "Status", "Username" },
                values: new object[,]
                {
                    { 1, "I am a proactive worker!", "Jaska", "Avocados are a fruit, not a vegetable. They're technically considered a single-seeded berry, believe it or not.", "Jokunen", "https://memesbams.com/wp-content/uploads/2017/10/homer-simpson-mmm-meme.jpg", "Working at Experis", "JaskaMan" },
                    { 2, "I am a happy worker!", "Emma", "Liechtenstein and Uzbekistan are the only doubly landlocked countries.", "Jokunen", "https://is.mediadelivery.fi/img/978/3f8de8ba787e4ae89c0322f57337435b.jpg.webp", "Working at Noroff", "EmmAA" },
                    { 3, "I love computers!", "Seamus", "The real name for a hashtag is an octothorpe.", "Smith", "https://www.misir.fi/wp-content/uploads/2015/08/harald-200x200.jpg", "Working with IBM", "seamass" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "AllowGuests", "Description", "EndTime", "EventCreatorId", "LastUpdated", "Name", "StartTime" },
                values: new object[,]
                {
                    { 1, true, "Friday night fun. At linnanmäki", new DateTime(2023, 3, 17, 21, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 3, 29, 9, 48, 25, 936, DateTimeKind.Local).AddTicks(6651), "Afterwork", new DateTime(2023, 3, 17, 17, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 2, true, "Noroffs teachers bootcamp", new DateTime(2023, 4, 2, 21, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2023, 3, 29, 9, 48, 25, 936, DateTimeKind.Local).AddTicks(6716), "Noroff summer bootcamp", new DateTime(2023, 3, 31, 17, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 3, true, "Boardgame tuesday!", null, 3, new DateTime(2023, 3, 29, 9, 48, 25, 936, DateTimeKind.Local).AddTicks(6719), "Boargames!", new DateTime(2023, 3, 21, 17, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "GroupUser",
                columns: new[] { "GroupsId", "UsersId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 2, 2 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "EventId", "GroupId", "ParentPostId", "TargetUserId", "TimeStamp", "Title", "TopicId", "UserId" },
                values: new object[,]
                {
                    { 1, "My very first content.", null, null, null, null, new DateTime(2023, 3, 29, 9, 48, 25, 936, DateTimeKind.Local).AddTicks(6741), "Afterwork coming soon!", 1, 1 },
                    { 3, "Get reafy to pack your bags!", null, 2, null, null, new DateTime(2023, 3, 29, 9, 48, 25, 936, DateTimeKind.Local).AddTicks(6756), "Bootcamp coming soon", null, 2 },
                    { 5, "What boardgames people like to play?", null, 1, null, null, new DateTime(2023, 3, 29, 9, 48, 25, 936, DateTimeKind.Local).AddTicks(6762), "Boardgames", null, 1 },
                    { 8, "What do your prefer?", null, 2, null, null, new DateTime(2023, 3, 29, 9, 48, 25, 936, DateTimeKind.Local).AddTicks(6778), "Best language to teach?", null, 3 },
                    { 11, "What games people like to play?", null, 1, null, null, new DateTime(2023, 3, 29, 9, 48, 25, 936, DateTimeKind.Local).AddTicks(6764), "Lan party", null, 1 },
                    { 20, "Only videogames!.", null, null, null, null, new DateTime(2023, 3, 29, 9, 48, 25, 936, DateTimeKind.Local).AddTicks(6746), "Gamers!", 1, 1 },
                    { 22, "You're such a noob!.", null, null, null, null, new DateTime(2023, 3, 29, 9, 48, 25, 936, DateTimeKind.Local).AddTicks(6751), null, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "TopicUser",
                columns: new[] { "TopicsId", "UsersId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 2, 2 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "EventGroup",
                columns: new[] { "EventsId", "GroupsId" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "EventTopic",
                columns: new[] { "EventsId", "TopicsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "EventUsers",
                columns: new[] { "EventId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "EventId", "GroupId", "ParentPostId", "TargetUserId", "TimeStamp", "Title", "TopicId", "UserId" },
                values: new object[,]
                {
                    { 2, "Lets GOO!", null, null, 1, null, new DateTime(2023, 3, 29, 9, 48, 25, 936, DateTimeKind.Local).AddTicks(6753), null, 1, 3 },
                    { 4, "Does someone have trangia?", 2, null, null, null, new DateTime(2023, 3, 29, 9, 48, 25, 936, DateTimeKind.Local).AddTicks(6759), null, null, 3 },
                    { 6, "Ark Nova is the best!", null, 1, 5, null, new DateTime(2023, 3, 29, 9, 48, 25, 936, DateTimeKind.Local).AddTicks(6771), null, null, 3 },
                    { 7, "Is it one of the games in SM-competition of boardgames?", null, 1, 5, 3, new DateTime(2023, 3, 29, 9, 48, 25, 936, DateTimeKind.Local).AddTicks(6774), null, null, 1 },
                    { 9, "Me first Javascript!", null, 2, 8, null, new DateTime(2023, 3, 29, 9, 48, 25, 936, DateTimeKind.Local).AddTicks(6780), null, null, 3 },
                    { 10, "C# is the best", null, 2, 8, null, new DateTime(2023, 3, 29, 9, 48, 25, 936, DateTimeKind.Local).AddTicks(6783), null, null, 2 },
                    { 12, "League of legends", null, 1, 11, null, new DateTime(2023, 3, 29, 9, 48, 25, 936, DateTimeKind.Local).AddTicks(6766), null, null, 3 },
                    { 21, "Ayyyyyy!.", null, null, 20, null, new DateTime(2023, 3, 29, 9, 48, 25, 936, DateTimeKind.Local).AddTicks(6748), null, 1, 1 },
                    { 25, "I do have, but Im out of gas", 2, null, null, 3, new DateTime(2023, 3, 29, 9, 48, 25, 936, DateTimeKind.Local).AddTicks(6785), null, null, 1 },
                    { 26, "Remember, no arcade games with company credit card!", 1, null, null, null, new DateTime(2023, 3, 29, 9, 48, 25, 936, DateTimeKind.Local).AddTicks(6788), null, null, 1 },
                    { 27, "Not even pony race?", 1, null, null, 1, new DateTime(2023, 3, 29, 9, 48, 25, 936, DateTimeKind.Local).AddTicks(6790), null, null, 2 },
                    { 28, "Havent lost in trivial Pursuit since 2005, who want to try to beat me?", 3, null, null, null, new DateTime(2023, 3, 29, 9, 48, 25, 936, DateTimeKind.Local).AddTicks(6792), null, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "Rsvps",
                columns: new[] { "Id", "EventId", "GuestCount", "LastUpdated", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2023, 3, 29, 9, 48, 25, 936, DateTimeKind.Local).AddTicks(6823), 1 },
                    { 2, 2, 1, new DateTime(2023, 3, 29, 9, 48, 25, 936, DateTimeKind.Local).AddTicks(6827), 2 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "EventId", "GroupId", "ParentPostId", "TargetUserId", "TimeStamp", "Title", "TopicId", "UserId" },
                values: new object[] { 13, "Omg who plays leage 2023?!", null, 1, 12, null, new DateTime(2023, 3, 29, 9, 48, 25, 936, DateTimeKind.Local).AddTicks(6769), null, null, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_EventGroup_EventsId",
                table: "EventGroup",
                column: "EventsId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventCreatorId",
                table: "Events",
                column: "EventCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTopic_EventsId",
                table: "EventTopic",
                column: "EventsId");

            migrationBuilder.CreateIndex(
                name: "IX_EventUsers_EventId",
                table: "EventUsers",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUser_UsersId",
                table: "GroupUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_EventId",
                table: "Posts",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_GroupId",
                table: "Posts",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ParentPostId",
                table: "Posts",
                column: "ParentPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TargetUserId",
                table: "Posts",
                column: "TargetUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TopicId",
                table: "Posts",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rsvps_EventId",
                table: "Rsvps",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Rsvps_UserId",
                table: "Rsvps",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicUser_UsersId",
                table: "TopicUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventGroup");

            migrationBuilder.DropTable(
                name: "EventTopic");

            migrationBuilder.DropTable(
                name: "EventUsers");

            migrationBuilder.DropTable(
                name: "GroupUser");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Rsvps");

            migrationBuilder.DropTable(
                name: "TopicUser");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
