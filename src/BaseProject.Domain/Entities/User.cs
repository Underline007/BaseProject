using BaseProject.Domain.Common.Models;
using BaseProject.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace BaseProject.Domain.Entities
{
    public class User : BaseEntity
    {

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        public string PasswordSalt { get; set; } = string.Empty;

        public EnumUserAccountStatus Status { get; set; } = EnumUserAccountStatus.Inactive;
        public Guid RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
