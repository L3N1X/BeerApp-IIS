using CookComputing.XmlRpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerApp.Dao.Services.Interface
{
    [XmlRpcUrl("http://localhost:6969/")]
    public interface IISXmlRpcService : IXmlRpcProxy
    {
        [XmlRpcMethod("IISXmlRpcService.findTemperatureByCityName")]
        string FindTemperatureByCityName(string cityName);

        [XmlRpcMethod("IISXmlRpcService.validateBeerXml")]
        string ValidateBeerXml(string xml);
    }
}
