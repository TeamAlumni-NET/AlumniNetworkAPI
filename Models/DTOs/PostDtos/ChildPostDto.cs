namespace AlumniNetworkAPI.Models.DTOs.PostDtos
{
    public class ChildPostDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime TimeStamp { get; set; }
        public string username { get; set; }

        public string pictureUrl { get; set; }
        public string targetUser { get; set; }
        
    }
}
