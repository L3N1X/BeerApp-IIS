using BeerApp.Dao.Services.Interface;
using BeerApp.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace BeerApp.Web.Controllers
{
    public class BeerController : Controller
    {
        private readonly IXmlValidationService _xmlValidationService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        private const string SCHEMA_PATH = "xml/beers/beers.xsd";
        public BeerController(IXmlValidationService xmlValidationService, IWebHostEnvironment webHostEnvironment)
        {
            _xmlValidationService = xmlValidationService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult ValidateBeer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ValidateBeer([FromForm] ValidateBeerViewModel validateBeerViewModel)
        {
            bool valid = false;
            if(validateBeerViewModel.Xml is not null)
            {
                string schemaDocumentPath = Path.Combine(_webHostEnvironment.WebRootPath, "xml/note/note.xsd");
                try
                {
                    _xmlValidationService.TryValidateWithXsd(validateBeerViewModel.Xml, schemaDocumentPath);
                    valid = true;
                } 
                catch (Exception ex)
                {
                    validateBeerViewModel.Message = ex.Message;
                }
            }
            validateBeerViewModel.Valid = valid;
            return View(validateBeerViewModel);
        }
    }
}
