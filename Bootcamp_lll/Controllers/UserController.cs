using Bootcamp_lll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp_lll.Controllers
{
    public class UserController
    {
        List<User> users = new List<User>()
        {
            new User{ UserName = "admin", Password = "admin"}
        };

        public bool Login(string username, string password)
        {
            var login = users.Where(c => c.UserName!.Equals(username) && c.Password!.Equals(password))
                .FirstOrDefault();
            return login != null ? true : false;
        }
    }
}
