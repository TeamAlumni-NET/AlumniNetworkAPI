using System.ComponentModel.DataAnnotations;

namespace AlumniNetworkAPI.Models.DTOs.UserDtos
{
    public class UserDto
    {
        public int Id { get; set; }
        [MaxLength(50)]
<<<<<<< HEAD
        public string Username { get; set; }
=======
        public string UserName { get; set; }
>>>>>>> master
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Status { get; set; }
        public string Bio { get; set; }
        public string FunFact { get; set; }
        [Url]
        public string PictureUrl { get; set; }
        


    }
}
