using BeerApp.Dao.Services.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

namespace BeerApp.Dao.Services.Implementation
{
    public class XmlValidationService : IXmlValidationService
    {
        public bool ValidateWithRng(string xml)
        {
            throw new NotImplementedException();
        }

        public void TryValidateWithXsd(string xmlString, string schemaDocumentPath)
        {
            xmlString = Regex.Replace(xmlString, @"\t|\n|\r", "");

            var schemaSet = new XmlSchemaSet();
            XmlReader xmlReader;

            var settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationFlags |= System.Xml.Schema.XmlSchemaValidationFlags.ProcessSchemaLocation;
            settings.ValidationFlags |= System.Xml.Schema.XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.Schemas.Add(null, schemaDocumentPath);
            settings.ValidationEventHandler += ValidationEventHandle;

            //Validate file
            xmlReader = XmlReader.Create(new StringReader(xmlString), settings);
            while (xmlReader.Read()) { };

            xmlReader?.Close();
        }

        private void ValidationEventHandle(object? sender, ValidationEventArgs e)
        {
            throw new Exception(e.Message);
        }
    }
}
