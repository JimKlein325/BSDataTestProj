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

        public IEnumerable<ViewModels.RecentSightingViewModel> MostRecentlySightedBirds(int birdsToReturn)
        {
            IQueryable<Sighting> birds = GetSightings();
//            var mostRecentlySightedBirds = _context.Birds 
//                .Include( b => b.Sightings)
//.SelectMany(
//b => b.Sightings,
//(b, s) => new { Name = b.CommonName, s.SightingDate })
//.OrderByDescending(ns => ns.SightingDate as IComparable)
//.GroupBy(
//ns => ns.SightingDate,
//ns => ns.Name
//)
//.Take(8)

////		.Dump()
//;
//            foreach (var k in mostRecentlySightedBirds)
//            {
//                Console.Write(k.Key + System.Environment.NewLine);
//                foreach (var s in k)
//                {
//                    Console.Write(s + System.Environment.NewLine);
//                }
//            }

            var recentSightings = birds
                .Select( s => new { Name = s.Bird.CommonName, Date = s.SightingDate
                })
                .OrderByDescending(s => s.Date as IComparable)
                .Select(s => new EFBirdData.ViewModels.RecentSightingViewModel() { CommonName = s.Name, SightingDate = s.Date.ToString("m") })
                .Take(birdsToReturn);

            return recentSightings;
        }

        public IQueryable<Sighting> GetSightings()
        {
            return _context.Birds
                        .Include(b => b.Sightings)
                        .SelectMany(b => b.Sightings);
            //.OrderByDescending(s => s.SightingDate);
        }

        public SightingsForYearReportViewModel GetSightingsForYear(int year)
        {
            var result = _context.Birds
                .SelectMany(
    b => b.Sightings,
    (bird, sighting) => new { Bird = bird.CommonName, Sighting = sighting.SightingDate.Date.ToString("M"), Day = sighting.SightingDate.Date.Day, Month = sighting.SightingDate.Date.Month, MonthString = sighting.SightingDate.Date.ToString("MMM"), Year = sighting.SightingDate.Date.Year, Place = sighting.Place.Country })
    .Where(r => r.Year == 2016 && r.Place == "United States")
    .GroupBy(
    f => f.Month,
    ms => ms.MonthString,
    (f, ms) => new { Month = f, Text = ms, }
    )
    //.Select(grp => new { grp.Key, Count = grp.Count() })
    .OrderByDescending(g => g.Month)
    .Select(i => new ResultItem() { Name = i.Text.FirstOrDefault(), Value = i.Text.Count() })
    ;
            //     .Include(b => b.Sightings)
            //    .SelectMany(
            //    b => b.Sightings,
            //    (bird, sighting) => new { Bird = bird.CommonName, Sighting = sighting.SightingDate.Date.ToString("M"), Month = sighting.SightingDate.Date.Month, Year = sighting.SightingDate.Date.Year, Place = sighting.Place.Country })
            //    .Where(r => r.Year == 2016 && r.Place == "United States")
            //    .GroupBy(f => f.Month)
            //    .OrderByDescending(g => g.Key)
            //    .Select(grp => new ResultItem() {Name = grp.Key.ToString(), Value = grp.Count() })
            //;

            return new SightingsForYearReportViewModel() { TableName = $"Sightings for {year}", Items = result };
        }
    }
}
