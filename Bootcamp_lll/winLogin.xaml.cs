using Bootcamp_lll.Controllers;
using Bootcamp_lll.Models;
using System;
using System.Collections.Generic;
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

namespace Bootcamp_lll
{
    public partial class winLogin : Window
    {
        UserController? _userController;

        public winLogin()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            _userController = new();
            User user = _userController.Login(txtUserName.Text, txtPassword.Password);
            if (user != null)
            {
                switch (user.Role)
                {
                    case 1:
                        MainWindow main = new();
                        Close();
                        main.ShowDialog();
                        break;
                    case 2:
                        MainWindow mainManager = new();
                        mainManager.rdTeams.Visibility = Visibility.Collapsed;
                        mainManager.rdManagers.Visibility = Visibility.Collapsed;
                        Close();
                        mainManager.ShowDialog();
                        break;
                }
            }
        }
    }
}
