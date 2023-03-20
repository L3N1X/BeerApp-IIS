using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeerApp.Web.Models
{
    public class ValidateBeerViewModel
    {
        public bool? Valid { get; set; }
        public string? Message { get; set; }
        public string? Xml { get; set; }
        public string? ValidationSchema { get; set; }
    }
}
