using BeerApp.Dao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerApp.Dao.Services.Interface
{
    public interface IUserService
    {
        User TryLogin(string username, string password);
        ICollection<User> GetUsers();   
    }
}
