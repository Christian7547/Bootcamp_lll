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

namespace Bootcamp_lll.Views.Managers
{
    public partial class winNewManager : Window
    {
        ManagerController _managerController;
        SubjectController _subjectController;

        public winNewManager(ManagerController managerController, SubjectController subjectController)
        {
            InitializeComponent();
            _managerController = managerController;
            _subjectController = subjectController;
            cmbSubject.ItemsSource = _subjectController.GetMany();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager manager = new()
            {
                Id = _managerController.GetMany().Count + 1,
                Name = txtName.Text,
                LastName = txtLastName.Text,
                CI = txtCi.Text,
                UserName = txtUserName.Text,
                SubjectId = int.Parse(cmbSubject.SelectedValue.ToString()!) 
            };

            _managerController.New(manager);
            Close();
            uscMenuManagers._uscManagersMenu!.dtgData.ItemsSource = null;
            uscMenuManagers._uscManagersMenu!.Select();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
