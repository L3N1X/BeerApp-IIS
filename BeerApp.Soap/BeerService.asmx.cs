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

        //53021 PORT

        private readonly SimpleBeerRepository _repository = new SimpleBeerRepository();

        //[WebMethod]
        //public  GetBeers()
        //{
        //    return _repository.GetBeerCollection();
        //}

        //[WebMethod]
        //public Beer GetByName(string name)
        //{
        //    return _repository.GetByName(name);
        //}

        [WebMethod]
        public string GetBeerXmlByQuery(string query)
        {
            //XmlSerializer serializer = new XmlSerializer(typeof(List<Beer>));
            //using (StringWriter writer = new StringWriter())
            //{
            //    var beers = _repository.GetAll()
            //    serializer.Serialize(writer, beers);
            //    string xmlString = writer.ToString();
            //    return xmlString;
            //}
            throw new Exception("Failed to serialize string");
        }

        [WebMethod]
        public string GetBeerXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(beers));
            using (StringWriter writer = new StringWriter())
            {
                var beers = _repository.GetBeerCollection();
                serializer.Serialize(writer, beers);
                string xmlString = writer.ToString();
                return xmlString;
            }
            throw new Exception("Failed to serialize string");
        }
    }
}
