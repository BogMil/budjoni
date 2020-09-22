using Budjoni.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Budjoni.DAL
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options){}

        public DbSet<ModelObuce> ModeliObuce { get; set; }
    }
}
