using Bootcamp_lll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp_lll.Controllers
{
    public class ManagerController
    {
        List<Manager> managers = new()
        {
            new Manager{ Id = 1, Name = "Germán", LastName = "Rico", CI = "4859562", UserName = "german@gmail.com", SubjectId = 1},
            new Manager{ Id = 2, Name = "Pavel", LastName = "Caceres", CI = "4596231", UserName = "pavel@gmail.com", SubjectId = 1},
            new Manager{ Id = 3, Name = "Ramiro", LastName = "Ramallo", CI = "5987456", UserName = "ramiro@gmail.com", SubjectId = 3},
            new Manager{ Id = 4, Name = "Oscar", LastName = "Contreras", CI = "6859421", UserName = "oscar@gmail.com", SubjectId = 4},
            new Manager{ Id = 5, Name = "Diego", LastName = "Araos", CI = "7895624", UserName = "diego@gmail.com", SubjectId = 2},
        };

        public List<Manager> GetMany()
        {
            return managers;
        }

        public Manager GetOne(string name)
        {
            var query = managers.FirstOrDefault(manager => manager.Name!.Equals(name));
            return query!;
        }
    }
}
