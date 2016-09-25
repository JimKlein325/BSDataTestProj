using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFBirdData.Models
{
    public class EFBirdDbContext: DbContext
    {
        public DbSet<Bird> Birds { get; set; }

        public DbSet<Sighting> Sightings { get; set; }

        public DbSet<BirdsPlaces> BirdsPlaces { get; set; }

        public DbSet<Place> Places { get; set; }
        public DbSet<PrimaryColor> PrimaryColors { get; set; }
        public DbSet<SecondaryColor> SecondaryColors { get; set; }
        public DbSet<BirdsTernaryColors> BirdsTernaryColors { get; set; }

        //public EFBirdDbContext(DbContextOptions<EFBirdDbContext> options)
        //    : base(options)
        //{
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFBirds;integrated security=True");
        }

    }
}
