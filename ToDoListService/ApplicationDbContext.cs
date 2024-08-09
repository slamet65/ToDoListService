using Microsoft.EntityFrameworkCore;
using ToDoListService.Entity;

namespace ToDoListService
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Checklist> Checklists { get; set; }
    }
}
