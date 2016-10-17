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
        public IActionResult SightingsTable (  )
        {
            var sightingsData = _repository.GetSightingsForYear(2016); ;

            return View(sightingsData);
        }
        public IActionResult RecentSightings()
        {
            var sightingsData = _repository.MostRecentlySightedBirds(6); ;

            return View(sightingsData);
        }

        public IActionResult ReportTable(ReportResultViewModel result)//ViewModels.ReportResultViewModel vm ) //List<ReportItem> items)
        {

            //var reportResultViewModel = new ReportResultViewModel()
            //{
            //    Title = "Top Observers",
            //    Items = _repository.GetTopObersevers()
            //};

            return View(result);// new List<ReportItem>() { item });
        }
        public IActionResult Report()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Report(string conservationStatus)
        {
            var s = conservationStatus.ToString();

            return RedirectToAction("SightingsTable", 2016);
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var sightingsFor2016 = _repository.GetSightingsForYear(2016);
                var recentSightings = _repository.MostRecentlySightedBirds(5);

                var reportResultViewModel = new ReportResultViewModel()
                {
                    Title = "Top Observers",
                    Items = _repository.GetTopObersevers()
                };

                return View(new IndexViewModel() {
                    Bird = _repository.GetAllBirds().Take(5),
                    //RecentSightings = recentSightings,
                    ReportView = sightingsFor2016,
                    LinkedResultTable = new LinkedTableViewModel()
                    {
                        TableTitle = "Recent Sightings",
                        Controller = "Home",
                        Action = "Bird",
                        Items = _repository.MostRecentlySightedBirds(5).ToList()
                    },
                    TopObservers = reportResultViewModel
            });

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
