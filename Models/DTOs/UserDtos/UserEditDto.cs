using System.ComponentModel.DataAnnotations;

namespace AlumniNetworkAPI.Models.DTOs.UserDtos
{
    public class UserEditDto
    {
        public int Id { get; set; }
        [Required]
       public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Status { get; set; }
        public string Bio { get; set; }
        public string FunFact { get; set; }
        [Url]
        public string PictureUrl { get; set; }

    }
}
