using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BirdWatcher;
using EFBirdData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace EFBirdData.Controllers
{
    public class HomeController : Controller
    {
        private EFBirdDbContext db = new EFBirdDbContext();
        public HomeController(EFBirdDbContext context)
        {

        }
        public IActionResult Index()
        {
            //var birds = BirdRepository.LoadBirds();
            //var moreBirds = BirdRepository.LoadImportedBirds();


            var thisBird = db.Birds.Take(2);
                //.Include(birds => birds.Sightings)
                //.ThenInclude(birds => birds.Place)
                //.Include(experiences => experiences.PrimaryColor)
                //.Include(experiences => experiences.SecondaryColor)
                //.Include(experiences => experiences.BirdsTernaryColors)
                //.ThenInclude(experiences => experiences.TernaryColor)
                //.FirstOrDefault(experiences => experiences.Id == 1);
            return View(thisBird);
        }
        public IActionResult Bird(int Id)
        {
            var thisBird = db.Birds
                    .Include(birds => birds.Sightings)
                    .ThenInclude(birds => birds.Place)
                    .Include(experiences => experiences.PrimaryColor)
                    .Include(experiences => experiences.SecondaryColor)
                    .Include(experiences => experiences.BirdsTernaryColors)
                    .ThenInclude(experiences => experiences.TernaryColor)
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
