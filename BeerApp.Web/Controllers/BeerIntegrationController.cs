using BeerApp.Dao.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace BeerApp.Web.Controllers
{
    [Authorize]
    [Route("api/beer")]
    [ApiController]
    public class BeerIntegrationController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public ActionResult<ICollection<Beer>> GetAllBeers()
        {
            var beers = GetBeersFromApi();
            return Ok(beers);
        }

        private ICollection<Beer> GetBeersFromApi()
        {
            var apiClient = new RestClient("https://api.punkapi.com/v2/beers");
            var apiResult = apiClient.Execute<Beer>(new RestRequest());
            return JsonConvert.DeserializeObject<ICollection<Beer>>(apiResult.Content!)!;
        }
    }
}
