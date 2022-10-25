using Microsoft.AspNetCore.Mvc;
using NukeSafety.Models;
using NukeSafety.ORM.Context;
using System.Diagnostics;

namespace NukeSafety.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly NukeSafetyContext _context;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
           //_context = context;
        }

        public IActionResult Index()
        {
            return View();
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