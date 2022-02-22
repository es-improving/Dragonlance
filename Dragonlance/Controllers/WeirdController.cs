using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dragonlance.Controllers
{
    public class WeirdController : Controller
    {
        public IActionResult Path()
        {
            return View();
        }
    }
}
