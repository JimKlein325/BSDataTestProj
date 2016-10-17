using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFBirdData.ViewModels;

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

        public IEnumerable<Models.ResultItem> MostRecentlySightedBirds(int birdsToReturn)
        {
            IQueryable<Sighting> birds = GetSightings();

            var recentSightings = birds
                .Select(s => new
                {
                    Name = s.Bird.CommonName,
                    Date = s.SightingDate,
                    Id = s.Bird.Id
                })
                .OrderByDescending(s => s.Date as IComparable)
                .Select(s => new EFBirdData.Models.ResultItem() { Name = s.Name, Value = s.Date.ToString("m"), Id = s.Id })
                .Take(birdsToReturn);

            return recentSightings;
        }

        public IQueryable<Sighting> GetSightings()
        {
            return _context.Birds
                        .Include(b => b.Sightings)
                        .SelectMany(b => b.Sightings);
        }

        public SightingsForYearReportViewModel GetSightingsForYear(int year)
        {
            var result = _context.Birds
                .SelectMany(
                b => b.Sightings,
                (bird, sighting) => new { Bird = bird.CommonName, Sighting = sighting.SightingDate.Date.ToString("M"), Day = sighting.SightingDate.Date.Day, Month = sighting.SightingDate.Date.Month, MonthString = sighting.SightingDate.Date.ToString("MMM"), Year = sighting.SightingDate.Date.Year, Place = sighting.Place.Country })
                .Where(r => r.Year == year )
                .GroupBy(
                f => f.Month,
                ms => ms.MonthString,
                (f, ms) => new { Month = f, Text = ms, }
                )
                .OrderBy(g => g.Month)
                .Select(i => new ResultItem() { Name = i.Text.FirstOrDefault(), Value = i.Text.Count().ToString() })
                ;
            return new SightingsForYearReportViewModel() { TableName = $"Sightings for {year}", Items = result };
        }

        public List<ResultItem> GetTopObersevers()
        {
            var result = _context.Birds
                        .Include(b => b.Sightings)
                .SelectMany(b => b.Sightings,
                (bird, sighting) => new
                {
                    FullName = $"{sighting.ObserverFirstName} {sighting.ObserverLastName}",
                })
                .GroupBy(f => f.FullName)
                .Select(g => new { Name = g.Key, Value = g.Count() })
                .OrderByDescending(n => n.Value)
                .Select(n => new ResultItem { Name = n.Name, Value = n.Value.ToString() })
                .Take(6)
                ;
            return result.ToList();
        }
    }
}
