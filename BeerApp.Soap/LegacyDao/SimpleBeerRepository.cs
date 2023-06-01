using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerApp.Soap.LegacyDao
{
    public class SimpleBeerRepository
    {
        private readonly ICollection<Beer> _beers = new HashSet<Beer>()
        {
            new Beer
            {
                Id = 1,
                Name = "IPA",
                Tagline = "Bold and Hoppy",
                FirstBrewed = "2005",
                Description = "India Pale Ale is a hoppy beer style within the broader category of pale ale.",
                ImageUrl = "https://example.com/ipa.jpg",
                Abv = 6,
                Ibu = 60,
                TargetFg = 1012,
                TargetOg = 1050,
                Ebc = 12,
                Srm = 6,
                Ph = 4,
                AttenuationLevel = 80
            },
            new Beer
            {
                Id = 2,
                Name = "Stout",
                Tagline = "Dark and Rich",
                FirstBrewed = "1750",
                Description = "Stout is a dark, top-fermented beer with a number of variations.",
                ImageUrl = "https://example.com/stout.jpg",
                Abv = 7,
                Ibu = 40,
                TargetFg = 1015,
                TargetOg = 1060,
                Ebc = 40,
                Srm = 20,
                Ph = 4,
                AttenuationLevel = 75
            },
            new Beer
            {
                Id = 3,
                Name = "Pilsner",
                Tagline = "Crisp and Refreshing",
                FirstBrewed = "1842",
                Description = "Pilsner is a pale lager with a clean, crisp taste.",
                ImageUrl = "https://example.com/pilsner.jpg",
                Abv = 5,
                Ibu = 30,
                TargetFg = 1010,
                TargetOg = 1045,
                Ebc = 8,
                Srm = 4,
                Ph = 4,
                AttenuationLevel = 78
            },
            new Beer
            {
                Id = 4,
                Name = "Wheat Beer",
                Tagline = "Light and Fruity",
                FirstBrewed = "1602",
                Description = "Wheat beer is a beer, usually top-fermented, which is brewed with a large proportion of wheat relative to the amount of malted barley.",
                ImageUrl = "https://example.com/wheatbeer.jpg",
                Abv = 5,
                Ibu = 20,
                TargetFg = 1012,
                TargetOg = 1048,
                Ebc = 10,
                Srm = 5,
                Ph = 4,
                AttenuationLevel = 75
            },
            new Beer
            {
                Id = 5,
                Name = "Porter",
                Tagline = "Robust and Malty",
                FirstBrewed = "1722",
                Description = "Porter is a dark style of beer originating in London in the 18th century.",
                ImageUrl = "https://example.com/porter.jpg",
                Abv = 6,
                Ibu = 30,
                TargetFg = 1014,
                TargetOg = 1055,
                Ebc = 30,
                Srm = 15,
                Ph = 4,
                AttenuationLevel = 74
            },
            new Beer
            {
                Id = 6,
                Name = "Amber Ale",
                Tagline = "Malty and Caramel",
                FirstBrewed = "1970",
                Description = "Amber ale is a style of beer that has a medium to dark reddish-brown color.",
                ImageUrl = "https://example.com/amberale.jpg",
                Abv = 5,
                Ibu = 25,
                TargetFg = 1012,
                TargetOg = 1050,
                Ebc = 20,
                Srm = 10,
                Ph = 4,
                AttenuationLevel = 76
            },
            new Beer
            {
                Id = 7,
                Name = "Saison",
                Tagline = "Spicy and Fruity",
                FirstBrewed = "1880",
                Description = "Saison is a pale ale that is highly carbonated, fruity, spicy, and often bottle conditioned.",
                ImageUrl = "https://example.com/saison.jpg",
                Abv = 6,
                Ibu = 35,
                TargetFg = 1008,
                TargetOg = 1055,
                Ebc = 12,
                Srm = 6,
                Ph = 4,
                AttenuationLevel = 85
            },
            new Beer
            {
                Id = 8,
                Name = "Brown Ale",
                Tagline = "Toasty and Nutty",
                FirstBrewed = "1930",
                Description = "Brown ale is a style of beer with a dark amber or brown color.",
                ImageUrl = "https://example.com/brownale.jpg",
                Abv = 5,
                Ibu = 25,
                TargetFg = 1010,
                TargetOg = 1050,
                Ebc = 20,
                Srm = 10,
                Ph = 4,
                AttenuationLevel = 80
            },
            new Beer
            {
                Id = 9,
                Name = "Pale Lager",
                Tagline = "Clean and Crisp",
                FirstBrewed = "1842",
                Description = "Pale lager is a very pale-to-golden-colored lager beer with a crisp, clean taste.",
                ImageUrl = "https://example.com/palelager.jpg",
                Abv = 4,
                Ibu = 20,
                TargetFg = 1008,
                TargetOg = 1045,
                Ebc = 8,
                Srm = 4,
                Ph = 4,
                AttenuationLevel = 80
            },
            new Beer
            {
                Id = 10,
                Name = "Red Ale",
                Tagline = "Caramel and Bitter",
                FirstBrewed = "1880",
                Description = "Red ale is a style of beer that is characterized by its red color and balance between malt and hops.",
                ImageUrl = "https://example.com/redale.jpg",
                Abv = 5,
                Ibu = 35,
                TargetFg = 1012,
                TargetOg = 1050,
                Ebc = 16,
                Srm = 8,
                Ph = 4,
                AttenuationLevel = 78
            }
        };

        public beers GetBeerCollection()
        {
            return new beers
            {
                BeersCollection = new List<Beer>(_beers)
            };
        }

        public beers GetByName(string name)
        {
            return new beers
            {
                BeersCollection = new HashSet<Beer>(_beers)
                .Where(beer => beer.Name.Equals(name)).ToList()
            };
        }
    }
}