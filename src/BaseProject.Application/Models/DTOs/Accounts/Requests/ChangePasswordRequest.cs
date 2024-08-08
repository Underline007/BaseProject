using System.ComponentModel.DataAnnotations;

namespace BaseProject.Application.Models.DTOs.Accounts.Requests
{
    public class ChangePasswordRequest
    {
        [Required]
        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; } = string.Empty;
    }
}
