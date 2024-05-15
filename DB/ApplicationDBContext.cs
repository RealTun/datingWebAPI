using DatingAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace DatingAPI.DB
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<UserAccount> UserAccount { get; set; }
        public DbSet<InterestType> InterestType { get; set; }
        public DbSet<RelationshipType> RelationshipType { get; set; }
    }
}
