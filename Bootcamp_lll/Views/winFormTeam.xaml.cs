using Bootcamp_lll.Controllers;
using Bootcamp_lll.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bootcamp_lll.Views
{
    public partial class winFormTeam : Window
    {
        #region Props
        TeamController? _teamController;
        ContestantController _contestantController;
        ManagerController? _managerController;
        List<Contestant> contestants = new();

        int managerId = 0;
        #endregion

        public winFormTeam(ContestantController contestant)
        {
            InitializeComponent();
            _contestantController = contestant;
            FillComboBox();
            cmbManager.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            _teamController = new();
            _managerController = new();
            Team team = new()
            {
                TeamName = txtNameTeam.Text,
                ManagerId = managerId,
                SubjectId = int.Parse(cmbSubject.SelectedValue.ToString()!),
                Contestants = contestants
            };
            _teamController.NewTeam(team);
            string nameManager = _teamController.GetManager(team.ManagerId);
            Close();
            uscMenuTeams._uscMenuTeams!.lstTeams.Items.Clear();
            foreach (var item in _teamController.GetMany())
            {
                uscMenuTeams._uscMenuTeams.lstTeams.Items.Add(item.TeamName);
                uscMenuTeams._uscMenuTeams.lstTeams.Items.Add(item.SubjectId);
                uscMenuTeams._uscMenuTeams.lstTeams.Items.Add(nameManager);
                foreach (var i in item.Contestants!)
                {
                    uscMenuTeams._uscMenuTeams.lstTeams.Items.Add(i.Name + " " + i.LastName);
                }
            }
        }

        private void cmbSubject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbManager.Items.Clear();
            dtgData.Items.Clear();

            _teamController = new();
            ComboBox manager = _teamController.GetManagers(int.Parse(cmbSubject.SelectedValue.ToString()!), cmbManager);
            _teamController.GetContestants(int.Parse(cmbSubject.SelectedValue.ToString()!), dtgData, _contestantController);
            if (cmbManager.SelectedItem == null)
                cmbManager.Text = string.Empty;
            else
                managerId = int.Parse(manager.SelectedValuePath);  //CORREGIR
        }

        private void ckBoxIsSelected_Checked(object sender, RoutedEventArgs e)
        {
            Contestant contestant = new()
            {
                Name = dtgData.SelectedItem.ToString(),
                Grade = dtgData.SelectedItem.ToString()
            };
            contestants.Add(contestant);
        }

        void FillComboBox()
        {
            _teamController = new();
            SubjectController subjectController = new();
            foreach (var item in subjectController.GetMany())
                cmbSubject.Items.Add(item);
        }

    }
}
