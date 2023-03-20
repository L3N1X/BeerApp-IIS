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

        private const string RNG_SCHEMA_PATH = "xml/schemas/beers.rng";
        private const string XSD_SCHEMA_PATH = "xml/schemas/beers.xsd";
        private const string VALIDATED_XML_FOLDER = "xml/validated/";

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
            if (!string.IsNullOrEmpty(validateBeerViewModel.Xml))
            {
                try
                {
                    if (validateBeerViewModel.ValidationSchema == "xsd")
                    {
                        string schemaDocumentPath = Path.Combine(_webHostEnvironment.WebRootPath, XSD_SCHEMA_PATH);
                        _xmlValidationService.TryValidateWithXsd(validateBeerViewModel.Xml, schemaDocumentPath);
                    }
                    else if (validateBeerViewModel.ValidationSchema == "rng")
                    {
                        string schemaDocumentPath = Path.Combine(_webHostEnvironment.WebRootPath, RNG_SCHEMA_PATH);
                        _xmlValidationService.TryValidateWithRng(validateBeerViewModel.Xml, schemaDocumentPath);
                    }
                    validateBeerViewModel.Valid = true;
                    string validatedXmlPath = Path.Combine(_webHostEnvironment.WebRootPath, $"{VALIDATED_XML_FOLDER}{Guid.NewGuid()}.xml");
                    System.IO.File.WriteAllText(validatedXmlPath, validateBeerViewModel.Xml);
                }
                catch (Exception ex)
                {
                    validateBeerViewModel.Message = ex.Message;
                    validateBeerViewModel.Valid = false;
                }
            }
            else
            {
                validateBeerViewModel.Message = "No data given.";
                validateBeerViewModel.Valid = false;
            }
            return View(validateBeerViewModel);
        }
    }
}
