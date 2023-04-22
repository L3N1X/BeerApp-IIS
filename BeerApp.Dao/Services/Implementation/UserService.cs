using BeerApp.Dao.Models;
using BeerApp.Dao.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerApp.Dao.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly ICollection<User> _users = new HashSet<User>()
        {
            new User()
            {
                Username = "lkruslin",
                Email = "lkruslin@racunarstvo.hr",
                Name = "Leon",
                Surname = "Krušlin",
                Password = "1234"
            },
            new User()
            {
                Username = "mkrmpotich",
                Email = "mkrmpotich@racunarstvo.hr",
                Name = "Militza",
                Surname = "Krmpotich",
                Password = "1234"
            },
            new User()
            {
                Username = "rmediro",
                Email = "rmediro@racunarstvo.hr",
                Name = "Robert",
                Surname = "MeDiro",
                Password = "1234"
            },
        };
        public ICollection<User> GetUsers()
        {
            return new HashSet<User>(_users);
        }

        public User TryLogin(string username, string password)
        {
            var user = _users
                .Where(u => u.Username == username && u.Password == password)
                .FirstOrDefault();
            return user ?? throw new Exception("Username or password incorrect!"); ;
        }
    }
}
