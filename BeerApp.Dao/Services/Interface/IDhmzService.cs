using CookComputing.XmlRpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerApp.Dao.Services.Interface
{
    [XmlRpcUrl("http://localhost:6969/")]
    public interface IDhmzService : IXmlRpcProxy
    {
        [XmlRpcMethod("Temperature.findTemperatureByCityName")]
        string FindTemperatureByCityName(string cityName);
    }
}
