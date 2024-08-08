using BaseProject.Domain.Common.Models;

namespace BaseProject.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string RoleName { get; set; } = string.Empty;
        public ICollection<User>? Users { get; set; }
    }
}