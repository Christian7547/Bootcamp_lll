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
            _teamController.GetTeams(lstTeams, _managerController, _subjectController);
        }
    }
}
