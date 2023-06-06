using Bootcamp_lll.Controllers;
using System.Windows;
using System.Windows.Controls;

namespace Bootcamp_lll.Views
{
    public partial class uscMenuTeams : UserControl
    {
        TeamController? _teamController;
        ContestantController _contestantController;
        public static uscMenuTeams? _uscMenuTeams;

        public uscMenuTeams(ContestantController contestantController)
        {
            InitializeComponent();
            _contestantController = contestantController;
            _uscMenuTeams = this;
            Select();
        }

        private void btnNewTeam_Click(object sender, RoutedEventArgs e)
        {
            winFormTeam winFormTeam = new(_contestantController);
            winFormTeam.ShowDialog();
        }

        void Select()
        {
            _teamController = new();
            foreach(var item in _teamController.GetMany())
            {
                lstTeams.Items.Add(item.TeamName);
                lstTeams.Items.Add(item.SubjectId);
                lstTeams.Items.Add(item.ManagerId);
                foreach (var i in item.Contestants!)
                {
                    lstTeams.Items.Add(i.Name + " " + i.LastName);
                }
            }
        }
    }
}
