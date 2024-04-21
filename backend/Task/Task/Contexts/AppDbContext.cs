using Microsoft.EntityFrameworkCore;
using Task.Models;

namespace Task.Contexts
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Users> Users { get; set; }
    }
}
