using System.ComponentModel.DataAnnotations;

namespace AlumniNetworkAPI.Models.DTOs.UserDtos
{
    public class UserSimpleDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PictureUrl { get; set; }
    }
}
