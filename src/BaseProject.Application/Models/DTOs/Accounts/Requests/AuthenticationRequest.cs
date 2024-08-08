using System.ComponentModel.DataAnnotations;

namespace BaseProject.Application.Models.DTOs.Accounts.Requests
{
    public class AuthenticationRequest
    {
        [Required]
        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(50)]
        public string Password { get; set; } = string.Empty;
    }
}
