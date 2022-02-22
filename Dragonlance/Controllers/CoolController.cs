using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dragonlance.Controllers
{
    public class CoolController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Beans()
        {
            return View();
        }

        public IActionResult StoryBro()
        {
            return View();
        }
    }
}
