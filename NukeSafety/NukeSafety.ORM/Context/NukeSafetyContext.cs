using Microsoft.EntityFrameworkCore;
using NukeSafety.ORM.Models;
using NukeSafety.ORM.Models.Explosions;
using System.Runtime.CompilerServices;

namespace NukeSafety.ORM.Context
{
    public class NukeSafetyContext : DbContext
    {
        
        public NukeSafetyContext(DbContextOptions contextOptions) : base(contextOptions)
        {
           //Database.EnsureCreated and Deleted for what and DbcontextOptions
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<ChemicalElement> Elements { get; set; }
        public DbSet<Bomb> Bombs { get; set; }
        public DbSet<Explosion> Explosions { get; set; }
        public DbSet<AirExplosion> AirExplosions { get; set; }
        public DbSet<HeightExplosion> HeightExplosions { get; set; }
        public DbSet<CosmicExplosion> CosmicExplosions { get; set; }
        public DbSet<GroundExplosion> GroundExplosions { get; set; }
        public DbSet<UndergroundExplosion> UndergroundExplosions { get; set; }
        public DbSet<WaterExplosion> WaterExplosions { get; set; }
        public DbSet<UnderwaterExplosion> UnderwaterExplosions { get; set; }
    }
}
