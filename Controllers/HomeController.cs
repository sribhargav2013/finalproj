using System.Diagnostics;
using finalproj.Models;
using Microsoft.AspNetCore.Mvc;

namespace finalproj.Controllers
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
			return View();
		}
        public IActionResult Stats()
        {
            return View();
        }

        public IActionResult Found()
        {
            return View();
        }

        public IActionResult Lost()
        {
            return View();
        }

        public IActionResult About()
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
