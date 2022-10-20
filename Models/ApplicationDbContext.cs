using Microsoft.EntityFrameworkCore;

namespace BugTrack.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<BugCategory> Categories { get; set; }
    }
}
