using Allari.Assessment.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Allari.Assessment.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Entering home page");
            return View();
        }
    }
}