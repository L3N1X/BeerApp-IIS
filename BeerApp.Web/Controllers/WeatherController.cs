using BeerApp.Dao.Services.Interface;
using BeerApp.Web.Models;
using CookComputing.XmlRpc;
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

        [HttpPost]
        public IActionResult Index([FromForm] WeatherViewModel weatherViewModel)
        {
            if (string.IsNullOrEmpty(weatherViewModel.City))
            {
                weatherViewModel.Message = "Please enter a city name.";
                return View(weatherViewModel);
            }
            IDhmzService dhmzService = XmlRpcProxyGen.Create<IDhmzService>();
            weatherViewModel.Temperature = dhmzService.FindTemperatureByCityName(weatherViewModel.City).Trim();
            return View(weatherViewModel);
        }
    }
}
