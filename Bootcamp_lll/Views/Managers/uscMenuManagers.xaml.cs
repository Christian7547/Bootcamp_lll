using Bootcamp_lll.Controllers;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bootcamp_lll.Views.Managers
{
    public partial class uscMenuManagers : UserControl
    {
        ManagerController _managerController;
        SubjectController _subjectController;
        public static uscMenuManagers? _uscManagersMenu;

        public uscMenuManagers(ManagerController managerController, SubjectController subjectController)
        {
            InitializeComponent();
            _managerController = managerController;
            _subjectController = subjectController;
            _uscManagersMenu = this;
            Select();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            winNewManager winNewManager = new(_managerController, _subjectController);
            winNewManager.ShowDialog();
        }

        public void Select()
        {
            _managerController.ShowManagers(dtgData, _subjectController);
        }
    }
}
