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
        TeamController _teamController;
        ContestantController _contestantController;
        ManagerController? _managerController;
        List<Contestant> contestants = new();


        public winFormTeam(TeamController teamController, ContestantController contestant, ManagerController managerController)
        {
            InitializeComponent();
            _teamController = teamController;
            _contestantController = contestant;
            _managerController = managerController;
            FillSubjectsComboBox();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Team team = new()
            {
                Id = _teamController.GetMany().Count + 1,
                TeamName = txtNameTeam.Text,
                ManagerId = int.Parse(cmbManager.SelectedValue.ToString()!),
                SubjectId = int.Parse(cmbSubject.SelectedValue.ToString()!),
                Contestants = contestants
            };
            _teamController.NewTeam(team);
            Close();
            uscMenuTeams._uscMenuTeams!.dtgShowTeamsTeams.ItemsSource = null;
            uscMenuTeams._uscMenuTeams!.dtgShowTeamsTeams.Items.Clear(); ;
            uscMenuTeams._uscMenuTeams!.Select();
        }

        private void cmbSubject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbManager.ItemsSource = null;
            dtgData.Items.Clear();
            
            if (cmbSubject.SelectedItem != null)
            {
                _teamController.GetManagers(int.Parse(cmbSubject.SelectedValue.ToString()!), cmbManager, _managerController!);
                _teamController.GetContestants(int.Parse(cmbSubject.SelectedValue.ToString()!), dtgData, _contestantController);
            }
        }

        private void ckBoxIsSelected_Checked(object sender, RoutedEventArgs e)
        {
            Contestant contestant = (Contestant)dtgData.SelectedItem;
            contestants.Add(contestant!);
        }

        void FillSubjectsComboBox()
        {
            SubjectController subjectController = new();
            foreach (var item in subjectController.GetMany())
                cmbSubject.Items.Add(item);
        }

    }
}
