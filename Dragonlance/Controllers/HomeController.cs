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

        public IActionResult Index(string characterName)
        {
            //load that file
            string[] lines = System.IO.File.ReadAllLines(_env.ContentRootPath + @"\Data\names.txt");
            var heroes = new List<Hero>();

            foreach (var line in lines)
            {
                string[] linePieces = line.Split(",");

                var hero = new Hero();
                hero.Id = linePieces[0];
                hero.Name = linePieces[1];
                hero.Class = linePieces[2];
                hero.Race = linePieces[3];

                if (!String.IsNullOrEmpty(characterName) && characterName != hero.Name)
                {
                    continue;
                }

                heroes.Add(hero);
            }

            return View(heroes);
        }

        public ActionResult HeroDetail(string id)
        {
            // use id to look up data (read a file)
            // return data to view

            var model = new HeroDetail();
            model.Id = id;

            return View(model);
        }

        public ActionResult Paths()
        {
            string contentRootPath = _env.ContentRootPath;
            string webRootPath = _env.WebRootPath;

            return Content(contentRootPath + "\n" + webRootPath);
        }

        public ActionResult Info()
        {
            string[] files = System.IO.Directory.GetFiles(_env.ContentRootPath);
            string[] directories = System.IO.Directory.GetDirectories(_env.ContentRootPath);

            string output = "";
            foreach (var file in files) output += file + "\n";
            foreach (var directory in directories) output += directory + "\n";
            return Content(output);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Pants()
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
