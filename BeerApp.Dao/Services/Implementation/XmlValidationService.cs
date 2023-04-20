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
using Commons.Xml.Relaxng;
using System.Xml.Linq;

namespace BeerApp.Dao.Services.Implementation
{
    public class XmlValidationService : IXmlValidationService
    {
        public void TryValidateWithRng(string xmlString, string schemaDocumentPath)
        {
            using (XmlReader instance = XmlReader.Create(new StringReader(xmlString)))
            using (XmlReader grammar = new XmlTextReader(schemaDocumentPath))
            using (var reader = new RelaxngValidatingReader(instance, grammar))
            {
                XDocument doc = XDocument.Load(reader);
                reader.InvalidNodeFound += (source, message) =>
                {
                    throw new Exception(message);
                };
            }
        }

        public void TryValidateWithXsd(string xmlString, string schemaDocumentPath)
        {
            xmlString = CleanEscapeChars(xmlString);

            XmlReader xmlReader;

            var settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationFlags |= System.Xml.Schema.XmlSchemaValidationFlags.ProcessSchemaLocation;
            settings.ValidationFlags |= System.Xml.Schema.XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.Schemas.Add(null, schemaDocumentPath);
            settings.ValidationEventHandler += ValidationEventHandle;
            xmlReader = XmlReader.Create(new StringReader(xmlString), settings);
            while (xmlReader.Read()) { };

            xmlReader?.Close();
        }

        private void ValidationEventHandle(object? sender, ValidationEventArgs e)
        {
            throw new Exception(e.Message);
        }

        private static string CleanEscapeChars(string value)
        {
            return Regex.Replace(value, @"\t|\n|\r", "");
        }
    }
}
