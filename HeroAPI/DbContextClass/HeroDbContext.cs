using HeroAPI.Models;
using System.Data.Entity;

namespace HeroAPI.DbContextClass
{
    public class HeroDbContext : DbContext
    {
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Power> Powers { get; set; }
        public DbSet<PowerDetail> PowerDetails { get; set; }
    }
}