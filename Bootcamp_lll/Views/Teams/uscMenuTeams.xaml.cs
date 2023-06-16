using Bootcamp_lll.Controllers;
using Bootcamp_lll.Models;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Bootcamp_lll.Views
{
    public partial class uscMenuTeams : UserControl
    {
        TeamController _teamController;
        ContestantController _contestantController;
        ManagerController _managerController;
        SubjectController _subjectController;
        public static uscMenuTeams? _uscMenuTeams;

        public uscMenuTeams(TeamController teamController, ContestantController contestantController, ManagerController managerController, SubjectController subjectController)
        {
            InitializeComponent();
            _uscMenuTeams = this;
            _teamController = teamController;
            _contestantController = contestantController;
            _managerController = managerController;
            _subjectController = subjectController;
            Select();
        }

        private void btnNewTeam_Click(object sender, RoutedEventArgs e)
        {
            winFormTeam winFormTeam = new(_teamController, _contestantController, _managerController);
            winFormTeam.ShowDialog();
        }

        public void Select()
        {
            _teamController.GetTeams(dtgShowTeamsTeams);
        }

        private void cmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbFilter.SelectedItem != null)
            {
                switch (cmbFilter.SelectedIndex)
                {
                    case 0:
                        cmbSubjects.Visibility = Visibility.Visible;
                        cmbManagers.Visibility = Visibility.Collapsed;
                        cmbAcademic.Visibility = Visibility.Collapsed;
                        cmbSubjects.ItemsSource = _subjectController.GetMany(); 
                        break;
                    case 1:
                        cmbSubjects.Visibility = Visibility.Collapsed;
                        cmbManagers.Visibility = Visibility.Visible;
                        cmbAcademic.Visibility = Visibility.Collapsed;
                        cmbManagers.ItemsSource = _managerController.GetMany();
                        break;
                    case 2:
                        cmbSubjects.Visibility = Visibility.Collapsed;
                        cmbManagers.Visibility = Visibility.Collapsed;
                        cmbAcademic.Visibility = Visibility.Visible;
                        break;
                }
            }
        }

        private void cmbSubjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbSubjects.SelectedItem != null)
            {
                dtgContestantsByTeam.ItemsSource = null;
                int selected = int.Parse(cmbSubjects.SelectedValue.ToString()!);
                _teamController.FilterBySubject(selected, dtgShowTeamsTeams);
            }
        }

        private void cmbManagers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbManagers.SelectedItem != null)
            {
                dtgShowTeamsTeams.ItemsSource = null;
                int selected = int.Parse(cmbManagers.SelectedValue.ToString()!);
                _teamController.FilterBySubject(selected, dtgShowTeamsTeams);
            }
        }

        private void cmbAcademic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dtgShowTeamsTeams.ItemsSource= null;
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as FrameworkElement;
            var item = button!.DataContext as Team;

            _teamController.GetContestantsByTeam(item!, dtgContestantsByTeam);
        }
    }
}
