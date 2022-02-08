using Dragonlance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

namespace Dragonlance.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _env;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public IActionResult Index()
        {
            //load that file
            string[] lines = System.IO.File.ReadAllLines(_env.WebRootPath + @"\Data\names.txt");
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

        public ActionResult Paths()
        {
            string contentRootPath = _env.ContentRootPath;
            string webRootPath = _env.WebRootPath;

            return Content(contentRootPath + "\n" + webRootPath);
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
