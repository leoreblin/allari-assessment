using Allari.Assessment.Web.Models;
using Allari.Assessment.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Allari.Assessment.Web.Controllers
{
    public class StarWarsPeopleController : Controller
    {
        private readonly ILogger<StarWarsPeopleController> _logger;
        private readonly IStarWarsApiClient _starWarsApiClient;

        public StarWarsPeopleController(
            ILogger<StarWarsPeopleController> logger,
            IStarWarsApiClient starWarsApiClient)
        {
            _logger = logger;
            _starWarsApiClient = starWarsApiClient;
        }

        public IActionResult Index()
        {
            try
            {
                var response = _starWarsApiClient.GetPeople("people");
                return View(response);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex.Message);
            }

            return View(new List<StarWarsPeople>());            
        }

        [HttpGet]
        public async Task<IActionResult> ListAsync()
        {
            try
            {
                var response = await _starWarsApiClient.GetPeopleAsync("people");
                return View("Index", response);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex.Message);
            }

            return View(Task.FromResult(new List<StarWarsPeople>()));
        }
    }
}
