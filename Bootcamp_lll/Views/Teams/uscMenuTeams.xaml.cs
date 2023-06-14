using Bootcamp_lll.Controllers;
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
            this._teamController = teamController;
            _contestantController = contestantController;
            _managerController = managerController;
            _subjectController = subjectController;
            Select();
        }

        private void btnNewTeam_Click(object sender, RoutedEventArgs e)
        {
            winFormTeam winFormTeam = new(_teamController, _contestantController);
            winFormTeam.ShowDialog();
        }

        public void Select()
        {
            _teamController.GetTeams(lstTeams, _managerController, _subjectController, _contestantController);
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
            lstTeams.Items.Clear();
            if(cmbSubjects.SelectedItem != null)
            {
                int selected = int.Parse(cmbSubjects.SelectedValue.ToString()!);
                _teamController.FilterBySubject(selected, lstTeams, _managerController, _subjectController);
            }
        }

        private void cmbManagers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstTeams.Items.Clear();
        }

        private void cmbAcademic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
