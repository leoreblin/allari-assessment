using Allari.Assessment.Web.Models;
using Allari.Assessment.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Allari.Assessment.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStarWarsApiClient _starWarsApiClient;

        public HomeController(
            IConfiguration configuration,
            ILogger<HomeController> logger,
            IStarWarsApiClient starWarsApiClient)
        {
            _logger = logger;
            _starWarsApiClient = starWarsApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _starWarsApiClient.GetPeopleAsync("people");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}