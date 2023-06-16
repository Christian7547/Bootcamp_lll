using Bootcamp_lll.Controllers;
using Bootcamp_lll.Views;
using Bootcamp_lll.Views.Managers;
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
            LoadListContestant();
        }

        public void LoadListContestant()
        {
            contestantController.Recuperar();
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

        #region Views <> UserControls
        private void rdHome_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void rdRegisterMenu_Click(object sender, RoutedEventArgs e)
        {
            if (rdRegisterMenu.IsChecked == true)
            {
                rdHome.IsChecked = false;
                rdContestant.IsChecked = false;
                rdTeams.IsChecked = false;
            }

            rdRegisterMenu.IsChecked = true;
        }

        private void rdContestant_Click(object sender, RoutedEventArgs e)
        {
            uscMenuContestant uscMenuContestant = new(contestantController);
            gridMain.Children.Clear();
            gridMain.Children.Add(uscMenuContestant);
        }

        private void rdManagers_Click(object sender, RoutedEventArgs e)
        {
            uscMenuManagers uscMenuManagers = new(managerController, subjectController);
            gridMain.Children.Clear();
            gridMain.Children.Add(uscMenuManagers);
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
