using Microsoft.EntityFrameworkCore;

namespace SchoolSystems.Models.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            
        }
        public DbSet<User> User { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Branch> Branch { get; set; }
        public DbSet<Issues> Issues { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Permission> Permission { get; set; }
    }
}
