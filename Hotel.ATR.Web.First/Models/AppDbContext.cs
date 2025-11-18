using Microsoft.EntityFrameworkCore;

namespace Hotel.ATR.Web.First.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            :base(options)
        {
            
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<ContactForm> ContactForms { get; set; }
    }
}