using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace BeerApp.Soap.LegacyDao
{
    public class Beer
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("tagline")]
        public string Tagline { get; set; }

        [XmlElement("first_brewed")]
        public string FirstBrewed { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("image_url")]
        public string ImageUrl { get; set; }

        [XmlElement("abv")]
        public int Abv { get; set; }

        [XmlElement("ibu")]
        public int Ibu { get; set; }

        [XmlElement("target_fg")]
        public int TargetFg { get; set; }

        [XmlElement("target_og")]
        public int TargetOg { get; set; }

        [XmlElement("ebc")]
        public int Ebc { get; set; }

        [XmlElement("srm")]
        public int Srm { get; set; }

        [XmlElement("ph")]
        public int Ph { get; set; }

        [XmlElement("attenuation_level")]
        public int AttenuationLevel { get; set; }
    }

    public class beers
    {
        [XmlElement("beer")]
        public List<Beer> BeersCollection { get; set; }
    }
}