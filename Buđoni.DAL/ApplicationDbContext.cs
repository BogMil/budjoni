using Buđoni.Data;
using Microsoft.EntityFrameworkCore;

namespace Buđoni.DAL
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options){}

        public DbSet<ModelObuce> ModeliObuce { get; set; }
    }
}
