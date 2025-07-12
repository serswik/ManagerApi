using System.ComponentModel.DataAnnotations

namespace ManagerApi.DTOs
{
    public class UserCreateDto
    {
        [Required]
        [MinLength(2)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
