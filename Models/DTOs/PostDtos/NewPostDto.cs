namespace AlumniNetworkAPI.Models.DTOs.PostDtos
{
    public class NewPostDto
    {
        public string? Title { get; set; }
        public string Content { get; set; }
        public int? TargetUserId { get; set; }
        public int UserId { get; set; }
        public int? TopicId { get; set; }
        public int? GroupId { get; set; }
        public int? ParentPostId { get; set; }
        public int? EventId { get; set; }
    }
}
