using System;
using System.Windows;
using System.Windows.Input;

namespace Bootcamp_lll
{
    public partial class MainWindow : Window
    {
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
            PagesNavigation.Navigate(new System.Uri("Views/HomePage.xaml", UriKind.RelativeOrAbsolute));
        }
        private void rdUsers_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Views/UsersPage.xaml", UriKind.RelativeOrAbsolute));
        }
        private void rdListUsers_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Views/ListUsersPage.xaml", UriKind.RelativeOrAbsolute));
        }
        private void rdOptions_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Views/OptionsPage.xaml", UriKind.RelativeOrAbsolute));

            if (rdOptions.IsChecked == true)
            {
                rdHome.IsChecked = false;
                rdUsers.IsChecked = false;
                rdListUsers.IsChecked = false;
            }

            rdOptions.IsChecked = true;
        }
        #endregion
    }
}
