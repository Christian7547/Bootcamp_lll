using Bootcamp_lll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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

        public ListBox GetTeams(ListBox listBox, ManagerController managerController, SubjectController subjectController, ContestantController contestantController)
        {
            List<Contestant> contestants = contestantController.GetMany();
            var query = GetMany().Join(managerController.GetMany().Join(subjectController.GetMany().Join(contestants, s => s.Id, c => c.SubjectId,
                (s, c) => new
                {
                    Id_subject = s.Id,
                    GradeName = c.Grade,
                    Name_subject = s.Name,
                })
                ,m => m.SubjectId, s => s.Id_subject, 
                (m, s) => new
                {
                    grade = s.GradeName,
                    ManagerID = m.Id,
                    ManagerName = m.Name + " " + m.LastName,
                    Subject_Name = s.Name_subject
                }),
                t => t.ManagerId, m => m.ManagerID,
                (t, m) => new
                {
                    name_Grade = m.grade,
                    TName = t.TeamName,
                    SName = m.Subject_Name,
                    MName = m.ManagerName,
                    ListContestans = t.Contestants
                }).GroupBy(q => q.name_Grade);

            foreach(var item in query)
            {
                listBox.Items.Add(item.Key!.ToUpper());
                foreach (var i in item) 
                {
                    listBox.Items.Add(i.TName);
                    listBox.Items.Add(i.SName);
                    listBox.Items.Add(i.MName);
                    foreach (Contestant c in i.ListContestans)
                        listBox.Items.Add(c.Name + " " + c.LastName);
                }
                listBox.Items.Add("-----------------------");
            }
            return listBox;
        }

        public void NewTeam(Team team)
        {
            Teams.Add(team);
        }

        public ComboBox GetManagers(int subjectId, ComboBox comboBox)
        {
            _managerController = new();
            _sujectController = new();
            List<Manager> managers = new List<Manager>();
            var query = _managerController.GetMany().Join(_sujectController.GetMany(), m => m.SubjectId, s => s.Id,
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
                dataGrid.Items.Add(item);
        }

        public ListBox FilterBySubject(int id, ListBox listBox, ManagerController managerController, SubjectController subjectController)
        {
            var query = GetMany().Join(managerController.GetMany().Join(subjectController.GetMany(), m => m.SubjectId, s => s.Id,
                (m, s) => new
                {
                    ManagerID = m.Id,
                    ManagerName = m.Name + " " + m.LastName,
                    Subject_Name = s.Name,
                    SubjectID = s.Id
                }),
                t => t.ManagerId, m => m.ManagerID,
                (t, m) => new
                {
                    SubjectId = m.SubjectID,
                    TName = t.TeamName,
                    SName = m.Subject_Name,
                    MName = m.ManagerName,
                    Contestans = t.Contestants
                }).Where(q => q.SubjectId.Equals(id)).GroupBy(q => q.TName);
            foreach (var item in query)
            {
                listBox.Items.Add(item.Key!.ToUpper());
                foreach (var i in item)
                {
                    listBox.Items.Add(i.SName);
                    listBox.Items.Add(i.MName);
                    i.Contestans.ForEach(c => listBox.Items.Add(c.Name + " " + c.LastName));
                }
                listBox.Items.Add("-----------------------");
            }
            return listBox;
        }
    }
}
