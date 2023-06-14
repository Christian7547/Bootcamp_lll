using Bootcamp_lll.Controllers;
using Bootcamp_lll.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Bootcamp_lll.Views
{
    public partial class winNewContestant : Window
    {
        Contestant? _contestant;
        ContestantController _contestanController;

        int id;

        public winNewContestant(ContestantController contestantController)
        {
            InitializeComponent();
            _contestanController = contestantController;
            SubjectController subjectController = new();
            cmbSubject.ItemsSource = subjectController.GetMany();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            _contestant = new Contestant()
            {
                Id = _contestanController.GetMany().Count + 1,
                Name = txtName.Text,
                LastName = txtLastName.Text,
                UserName = txtEmail.Text,
                Grade = cmbGrade.Text,
                SubjectId = int.Parse(cmbSubject.SelectedValue.ToString()!)
            };
            _contestanController.AddNew(_contestant);
            Close();
            uscMenuContestant._uscContestant!.dtgData.Items.Clear();
            uscMenuContestant._uscContestant!.Select();
        }

        public void UpdateContestant(Contestant contestant)
        {
            txbTitle.Text = "Actualizar registro";
            txtName.Text = contestant.Name;
            txtLastName.Text = contestant.LastName;
            txtEmail.Text = contestant.UserName;
            ShowDialog();
        }
    }
}
