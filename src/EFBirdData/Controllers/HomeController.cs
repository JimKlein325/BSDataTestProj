using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BirdWatcher;
using EFBirdData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using EFBirdData.ViewModels;
using Microsoft.Extensions.Logging;

namespace EFBirdData.Controllers
{
    public class ReportItem
    {
        public string Status { get; set; }
        public int Count { get; set; }
    }
    public class HomeController : Controller
    {
        private EFBirdDbContext db = new EFBirdDbContext();
        private IBSTrackerRepository _repository;
        private ILogger<HomeController> _logger;

        public HomeController(IBSTrackerRepository repository,
            ILogger<HomeController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IActionResult SightingReport(string conservationStatus)//ViewModels.ReportResultViewModel vm ) //List<ReportItem> items)
        {
            var birds = BirdRepository.LoadBirds();
            var importedBirds = BirdRepository.LoadImportedBirds();



            var endangeredStatuses = birds.Select(b => b.ConservationStatus)
            .Distinct();

            var result = birds.Join(endangeredStatuses,
            b => b.ConservationStatus,
            s => s,
            (b, s) => new { Status = s, Sightings = b.Sightings }
            )
            .GroupBy(b => b.Status)
            .Select(b => new { Status = b.Key, Sightings = b.Sum(s => s.Sightings.Count()) })
            .ToList();

            var resultList = new List<ReportItem>();// new ReportResultViewModel();
            foreach (var item in result)
            {
                resultList.Add(new ReportItem() { Status = item.Status, Count = item.Sightings });
            }


            //return RedirectToActionResult("SightingReport", resultList);
            //var resultArray = resultList.ToArray();

            return View(resultList);// new List<ReportItem>() { item });
        }
        public IActionResult Report()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Report(string conservationStatus)
        {
            var s = conservationStatus.ToString();

            return RedirectToAction("SightingReport", null);
        }

        public async Task<IActionResult> Index()
        {
            try
            {
            var birds = db.Birds
                .Include(b => b.Sightings)
                .SelectMany(b => b.Sightings)
                .OrderByDescending(s => s.SightingDate)
                .Select(s => s.Bird)
                .Take(10);

            return View(birds);

            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to get");
                //TODO: implement error action
                return RedirectToAction("/error");
            }
        }
        public IActionResult Bird(int Id)
        {
            var thisBird = db.Birds
                    //.Include(birds => birds.Sightings)
                    //.ThenInclude(birds => birds.Place)
                    //.Include(experiences => experiences.PrimaryColor)
                    //.Include(experiences => experiences.SecondaryColor)
                    //.Include(experiences => experiences.BirdsTernaryColors)
                    //.ThenInclude(experiences => experiences.TernaryColor)
                    .FirstOrDefault(experiences => experiences.Id == Id);
            return View(thisBird);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
