using Bootcamp_lll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp_lll.Controllers
{
    internal class TeamController
    {
        List<Team> Teams = new List<Team>();

        public List<Team> GetMany()
        {
            return Teams;
        }

        public Team GetOne(string name)
        {
            var find = Teams.Where(t => t.TeamName.Equals(name)).FirstOrDefault();
            return find!;
        }

        public List<Team> ByManager(int id)
        {
            var query = Teams.Where(t => t.ManagerId.Equals(id));
            return query.ToList();
        }
    }
}
