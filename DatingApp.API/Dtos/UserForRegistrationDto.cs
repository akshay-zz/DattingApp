using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class UserForRegistrationDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "You must specify password between 8 to 15")]
        public string Password { get; set; }
    }
}
