using Bootcamp_lll.Controllers;
using System.Windows;
using System.Windows.Controls;

namespace Bootcamp_lll.Views
{
    public partial class uscMenuContestant : UserControl
    {

        ContestantController _controller;
        public static uscMenuContestant? _uscContestant;

        public uscMenuContestant(ContestantController contestant)
        {
            InitializeComponent();
            _controller = contestant;
            _uscContestant = this;
            Select();
            
        }

        public void Select()
        {
            _controller.GetContestants(dtgData);
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            winNewContestant winNewContestant = new(_controller);
            winNewContestant.ShowDialog();
        }
    }
}
