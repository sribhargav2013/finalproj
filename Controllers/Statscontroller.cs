using Microsoft.AspNetCore.Mvc;

namespace finalproj.Controllers
{
    public class Statscontroller : Controller
    {
        public IActionResult Stats()
        {
            return View();
        }
    }
}
