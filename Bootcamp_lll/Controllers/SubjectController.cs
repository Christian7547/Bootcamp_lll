using Bootcamp_lll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp_lll.Controllers
{
    internal class SubjectController
    {
        List<Subject> subjects = new List<Subject>()
        {
            new Subject{ Id = 1, Name = "Programación", Credits = 20},
            new Subject{ Id = 2, Name = "Programación Web", Credits = 30},
            new Subject{ Id = 3, Name = "SQL", Credits = 20},
            new Subject{ Id = 4, Name = "Robótica", Credits = 50},
        };

        public List<Subject> GetMany()
        {
            return subjects;
        }
    }
}
