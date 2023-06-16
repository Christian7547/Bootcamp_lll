using Bootcamp_lll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace Bootcamp_lll.Controllers
{
    public class TeamController
    {
        List<Team> Teams = new List<Team>();

        ManagerController? _managerController;
        SubjectController? _sujectController;
        ContestantController? _contestantController;

        public List<Team> GetMany()
        {
            return Teams;
        }

        public DataGrid GetTeams(DataGrid dataGrid)
        {
            var query = GetMany();
            foreach(Team team in query)
                dataGrid.Items.Add(team);
            return dataGrid;
        }

        public void GetContestantsByTeam(Team team, DataGrid dataGrid)
        {
            var query = GetMany().Where(t => t.Id.Equals(team.Id)).FirstOrDefault();
            dataGrid.ItemsSource = query!.Contestants;
        }

        public void NewTeam(Team team)
        {
            Teams.Add(team);
        }

        public ComboBox GetManagers(int subjectId, ComboBox comboBox, ManagerController managerController)
        {
            _sujectController = new();
            List<Manager> managers = new List<Manager>();
            var query = managerController.GetMany().Join(_sujectController.GetMany(), m => m.SubjectId, s => s.Id,
                (m, s) => new
                {
                    ManagerName = m.Name + " " + m.LastName,
                    SubjectID = s.Id,
                    ManagerID = m.Id
                }).Where(q => q.SubjectID.Equals(subjectId));
            foreach(var item in query)
                managers.Add(new Manager { Id = item.ManagerID, Name = item.ManagerName });
            comboBox.ItemsSource = managers;
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
            {
                Contestant contestant = new()
                {
                    Id = item.ContestantID,
                    Grade = item.Academic,
                    Name = item.ContestantName
                };
                dataGrid.Items.Add(contestant);
            }
        }

        public DataGrid FilterBySubject(int id, DataGrid dataGrid)
        {
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            var query = GetMany().Where(t => t.SubjectId.Equals(id));
            dataGrid.ItemsSource = query;
            return dataGrid;
        }

        public DataGrid FilterByManager(int id, DataGrid dataGrid)
        {
            dataGrid.ItemsSource = null;
            dataGrid.Items.Clear();
            var query = GetMany().Where(t => t.ManagerId.Equals(id));
            dataGrid.ItemsSource = query;
            return dataGrid;
        }
    }
}
