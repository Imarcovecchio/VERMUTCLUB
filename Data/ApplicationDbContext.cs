using Microsoft.EntityFrameworkCore;
using VermutClub.Models;

namespace VermutClub.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<SubscriptionRequest> SubscriptionRequests { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }   
}
