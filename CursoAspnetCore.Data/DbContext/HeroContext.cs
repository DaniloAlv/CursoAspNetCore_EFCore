using CursoAspNetCore.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoAspNetCore.WebApi.Data
{
    public class HeroContext : DbContext
    {
        public HeroContext(DbContextOptions options) : base(options)
        {}

        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<HeroBattles> HeroBattles { get; set; }
        public DbSet<SecretIdentity> SecretIdentities { get; set; }
    }
}
