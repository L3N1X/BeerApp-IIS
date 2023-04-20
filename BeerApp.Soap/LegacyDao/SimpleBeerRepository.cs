using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerApp.Soap.LegacyDao
{
    public class SimpleBeerRepository
    {
        private readonly ICollection<Beer> _simpleBeers = new List<Beer>()
        {
            new Beer(){ Id = 1, Name = "SanServolo", AlcPercentage = 4.3 },
            new Beer(){ Id = 2, Name = "Stella Artoise", AlcPercentage = 4.6 },
            new Beer(){ Id = 3, Name = "Staropranen", AlcPercentage = 4.5 },
            new Beer(){ Id = 4, Name = "Tomislav", AlcPercentage = 8.5 },
            new Beer(){ Id = 5, Name = "Zlaty Bazant", AlcPercentage = 4.1 },
            new Beer(){ Id = 6, Name = "Skopsko", AlcPercentage = 3.9 },
            new Beer(){ Id = 7, Name = "Mythos", AlcPercentage = 3.8 }
        };

        public ICollection<Beer> GetAll()
        {
            return _simpleBeers;
        }

        public ICollection<Beer> GetByName(string name) 
        {
            return _simpleBeers.Where(beer => beer.Name == name).ToList();
        }
    }
}