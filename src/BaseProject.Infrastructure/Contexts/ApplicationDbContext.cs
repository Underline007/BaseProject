using BaseProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseProject.Infrastructure.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
               .HasOne(t => t.Role)
               .WithMany(u => u.Users)
               .HasForeignKey(t => t.RoleId);
        }
    }
}
