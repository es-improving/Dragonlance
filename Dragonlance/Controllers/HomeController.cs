using Dragonlance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Dragonlance.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //load that file
            string[] lines = System.IO.File.ReadAllLines("Data/names.txt");
            var heroes = new List<Hero>();

            foreach (var line in lines)
            {
                string[] linePieces = line.Split(",");

                var hero = new Hero();
                hero.Name = linePieces[0];
                hero.Class = linePieces[1];
                hero.Race = linePieces[2];

                heroes.Add(hero);
            }

            return View(heroes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
