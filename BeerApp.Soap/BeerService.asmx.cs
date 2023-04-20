using BeerApp.Soap.LegacyDao;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml.Serialization;

namespace BeerApp.Soap
{
    /// <summary>
    /// Summary description for BeerService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BeerService : System.Web.Services.WebService
    {

        private readonly SimpleBeerRepository _repository = new SimpleBeerRepository();

        [WebMethod]
        public List<Beer> GetBeers()
        {
            return _repository.GetAll().ToList();
        }

        [WebMethod]
        public List<Beer> GetByName(string name)
        {
            return _repository.GetByName(name).ToList();
        }

        [WebMethod]
        public string GetBeerXmlByQuery(string query)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Beer>));
            using (StringWriter writer = new StringWriter())
            {
                var beers = _repository.GetAll().ToList();
                serializer.Serialize(writer, beers);
                string xmlString = writer.ToString();
                return xmlString;
            }
            throw new Exception("Can't serialize string");
        }
    }
}
