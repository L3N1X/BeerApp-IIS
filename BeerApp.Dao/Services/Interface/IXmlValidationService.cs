using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerApp.Dao.Services.Interface
{
    public interface IXmlValidationService
    {
        void TryValidateWithXsd(string xml, string schemaDocumentPath);
        bool ValidateWithRng(string xml);
    }
}
