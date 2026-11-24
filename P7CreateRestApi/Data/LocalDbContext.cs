using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using P7CreateRestApi.Domain;

namespace P7CreateRestApi.Data
{
    public class LocalDbContext : IdentityDbContext<User,IdentityRole<int>, int>
    {
        public LocalDbContext(DbContextOptions<LocalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
            });

            builder.Entity<IdentityUserRole<int>>()
                   .HasIndex(ur => ur.UserId)
                   .IsUnique();
        }                      
       
        public DbSet<BidList> BidLists { get; set; }
        public DbSet<CurvePoint> CurvePoints { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<RuleName> RuleNames { get; set; }
        public DbSet<Trade> Trades { get; set; }
    }
}