using Microsoft.AspNetCore.Mvc;
using NukeSafety.Models;
using NukeSafety.ORM.Context;
using NukeSafety.ORM.Factory;
using NukeSafety.ORM.Models;
using System.Diagnostics;
using System.Reflection;

namespace NukeSafety.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ExplosionCreator _explosionCreator;
        private readonly NukeSafetyContext _context;
        //private readonly List<Bomb> bombs = new List<Bomb>() { new Bomb { Id = 1, Name = "Mk-1",ImagePath= $"https://upload.wikimedia.org/wikipedia/commons/thumb/6/6a/Little_boy.jpg/1920px-Little_boy.jpg" }, new Bomb { Id = 2, Name = "W-5" } };

        public HomeController(ILogger<HomeController> logger,NukeSafetyContext context, ExplosionCreator explosionCreator)
        {
            _logger = logger;
            _explosionCreator = explosionCreator;
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Bombs);
        }


        public IActionResult CreateExplosion(string blastYeild, string type)
        {
            type = "NukeSafety.ORM.Factory." + type + "ExplosionFactory, NukeSafety.ORM";
            Type factoryType = Type.GetType(type);
            ConstructorInfo info = factoryType.GetConstructor(Type.EmptyTypes);
            _explosionCreator.SetState((IExplosionFactory)info.Invoke(new object[] {}));
            var explosion = _explosionCreator.CreateExplosion(Convert.ToDouble(blastYeild));
            Console.WriteLine(explosion.ToString());
            return Ok();
        }

        public int GetBombRadiuses(string bombId, string type)
        {
            //var bomb = _context.Bombs.FirstOrDefault(b => b.Id == int.Parse(bombId));
            var bomb = _context.Bombs.FirstOrDefault(b => b.Id == int.Parse(bombId));
            if(bomb != null)
            {
                type = "NukeSafety.ORM.Factory." + type + "ExplosionFactory, NukeSafety.ORM";
                Type factoryType = Type.GetType(type);
                ConstructorInfo info = factoryType.GetConstructor(Type.EmptyTypes);
                _explosionCreator.SetState((IExplosionFactory)info.Invoke(new object[] { }));
                var explosion = _explosionCreator.CreateExplosion(bomb);
                Console.WriteLine(explosion.ToString());
                return 1000;
            }
            return -1;
        }

        [HttpGet]
        public IActionResult BombInfo(int currentBombId)
        {
            var bomb = _context.Bombs.FirstOrDefault(b => b.Id == currentBombId);
            return View(bomb);
        }


        public IActionResult SaveActivities()
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