using Bootcamp_lll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Bootcamp_lll.Controllers
{
    internal class TeamController
    {
        List<Team> Teams = new List<Team>();
        ManagerController? _managerController;
        SubjectController? _sujectController;
        ContestantController? _contestantController;

        public List<Team> GetMany()
        {
            return Teams;
        }

        public void NewTeam(Team team)
        {
            Teams.Add(team);
        }

        public ComboBox GetManagers(int subjectId, ComboBox comboBox)
        {
            _managerController = new();
            _sujectController = new();
            var query = _managerController.GetMany().Join(_sujectController.GetMany(), m => m.SubjectId, s => s.Id,
                (m, s) => new
                {
                    ManagerName = m.Name + " " + m.LastName,
                    SubjectID = s.Id,
                    ManagerID = m.Id
                }).Where(q => q.SubjectID.Equals(subjectId));
            foreach (var item in query)
            {
                comboBox.Items.Add(item.ManagerName);
                comboBox.SelectedValue = item.ManagerID;
            }
            return comboBox;
        }

        public void GetContestants(int subjectId, DataGrid dataGrid, ContestantController controller)
        {
            _sujectController = new();
            var query = controller.GetMany().Join(_sujectController.GetMany(), c => c.SubjectId, s => s.Id,
                (c, s) => new
                {
                    ContestantName = c.Name + " " + c.LastName,
                    SubjectID = s.Id,
                    ContestantID = c.Id,
                    Academic = c.Grade
                }).Where(q => q.SubjectID.Equals(subjectId));
            foreach (var item in query)
                dataGrid.Items.Add(item);
        }

        public string GetManager(int managerId)
        {
            _managerController = new();
            var query = _managerController.GetMany().Where(m => m.Id.Equals(managerId))
                .Select(m => m.Name + " " +m.LastName)
                .FirstOrDefault();
            return query!;
        }
    }
}
