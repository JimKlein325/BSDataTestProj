using Microsoft.EntityFrameworkCore;

namespace EFBirdData.Models
{
    public interface IEFBirdDbContext
    {
        DbSet<Bird> Birds { get; set; }
        DbSet<BirdsPlaces> BirdsPlaces { get; set; }
        DbSet<BirdsTernaryColors> BirdsTernaryColors { get; set; }
        DbSet<Place> Places { get; set; }
        DbSet<Sighting> Sightings { get; set; }
    }
}