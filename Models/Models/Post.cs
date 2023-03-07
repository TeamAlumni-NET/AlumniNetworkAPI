namespace AlumniNetworkAPI.Models.Models
{
    public class Post
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string? Title { get; set; }
        public string Content { get; set; }
        public int? TargetUserId { get; set; }
        public User? TargetUser { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int? TopicId { get; set; }
        public Topic? Topic { get; set; }
        public int? GroupId { get; set; }
        public Group? Group { get; set; }
        public int? ParentPostId { get; set; }
        public Post? ParentPost { get; set; }
        public int? EventId { get; set; }
        public Event? Event { get; set; }
    }
}
