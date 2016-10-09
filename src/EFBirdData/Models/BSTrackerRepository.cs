using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EFBirdData.Models
{
    public class BSTrackerRepository : IBSTrackerRepository
    {
        private EFBirdDbContext _context;

        public BSTrackerRepository(EFBirdDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Bird> GetAllBirds()
        {
            return _context.Birds.ToList();
        }

        public Bird GetBirdByID(int id)
        {
            return _context.Birds.FirstOrDefault(b => b.Id == id);
        }
        public Bird GetBirdByCommonName(string name)
        {
            return _context.Birds.FirstOrDefault(b => b.CommonName == name);
        }

        public IEnumerable<ViewModels.RecentSightingViewModel> MostRecentlySightedBirds(int birdsToReturn)
        {
            IOrderedQueryable<Sighting> birds = GetSightings();

            var recentSightings = birds
                .Select(s => new EFBirdData.ViewModels.RecentSightingViewModel() { CommonName = s.Bird.CommonName, SightingDate = s.SightingDate.Date.ToString("m") })
                .Take(birdsToReturn);

            return recentSightings;
        }

        public IOrderedQueryable<Sighting> GetSightings()
        {
            return _context.Birds
                        .Include(b => b.Sightings)
                        .SelectMany(b => b.Sightings)
                        .OrderByDescending(s => s.SightingDate);
        }
    }
}
