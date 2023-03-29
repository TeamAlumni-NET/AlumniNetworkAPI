using System.ComponentModel.DataAnnotations;

namespace AlumniNetworkAPI.Models.DTOs.UserDtos
{
    public class UserEditDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public string? Status { get; set; }
        public string? Bio { get; set; }
        public string? FunFact { get; set; }
        [Url]
        public string? PictureUrl { get; set; }

    }
}
