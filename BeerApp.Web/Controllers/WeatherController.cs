using Microsoft.AspNetCore.Mvc;

namespace BeerApp.Web.Controllers
{
    public class WeatherController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
    }
}
