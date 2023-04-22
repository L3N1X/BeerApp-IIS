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
        public IActionResult Index()
        {
            XmlRpcClient client = new XmlRpcClient();
            client.Url = "http://example.com/xmlrpc"; // Replace with the URL of the XML-RPC endpoint
            object myResult = client.Invoke("myMethod");
            Console.WriteLine(myResult.ToString());
            return View();
        }
    }
}
