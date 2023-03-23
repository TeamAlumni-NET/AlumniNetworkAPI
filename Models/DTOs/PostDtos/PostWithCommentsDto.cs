using AlumniNetworkAPI.Models.DTOs.UserDtos;

namespace AlumniNetworkAPI.Models.DTOs.PostDtos
{
    public class PostWithCommentsDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string Content { get; set; }
        public UserDto User { get; set; }
        public ICollection<PostWithCommentsDto>? ChildPosts { get; set; }
    }
}
