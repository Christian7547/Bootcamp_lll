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
            new User{ UserName = "admin", Password = "admin", Role = 1},
            new User{ UserName = "manager", Password = "manager", Role = 2}
        };

        public UserController()
        {
            //AddedManagersToUsers();
        }

        public User Login(string username, string password)
        {
            var login = users.Where(c => c.UserName!.Equals(username) && c.Password!.Equals(password))
                .FirstOrDefault();
            return login != null ? login : null!;
        }

        public void NewUser(User user)
        {
            users.Add(user);
        }

        public void AddedManagersToUsers()
        {
            ManagerController managerController = new();
            foreach(Manager manager in managerController.GetMany())
            {
                User user = new User()
                {
                    UserName = manager.UserName,
                    Password = manager.Password,
                    Role = manager.Role
                };
                users.Add(user);
            }
        }
    }
}
