using Bootcamp_lll.Controllers;
using Bootcamp_lll.Views;
using System;
using System.Windows;
using System.Windows.Input;

namespace Bootcamp_lll
{
    public partial class MainWindow : Window
    {
        ContestantController contestantController = new();
        ManagerController managerController = new();
        SubjectController subjectController = new();
        TeamController teamController = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Effect to Window
        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        #endregion

        #region Buttones ->  Minimize - Maximize - Close

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        #endregion

        #region Views <> Pages
        private void rdHome_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void rdUsers_Click(object sender, RoutedEventArgs e)
        {
            uscMenuContestant uscMenuContestant = new(contestantController);
            gridMain.Children.Clear();
            gridMain.Children.Add(uscMenuContestant);
        }

        private void rdTeams_Click(object sender, RoutedEventArgs e)
        {
            uscMenuTeams uscMenuTeams = new(teamController, contestantController, managerController, subjectController);
            gridMain.Children.Clear();
            gridMain.Children.Add(uscMenuTeams);
        }

        private void rdOptions_Click(object sender, RoutedEventArgs e)
        {
            
        }
        #endregion
    }
}
