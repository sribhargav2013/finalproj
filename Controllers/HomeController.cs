using System.Diagnostics;
using finalproj.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace finalproj.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataImporter _dataImporter;

        public HomeController(ILogger<HomeController> logger, IDataImporter dataImporter)
        {
            _logger = logger;
            _dataImporter = dataImporter;
        }

        public async Task<IActionResult> Index()
        {
            // Initiate data import in the background
            await _dataImporter.ImportData();

            // Render the existing Index view
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
