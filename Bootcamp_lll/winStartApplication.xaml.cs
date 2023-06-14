using System;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Bootcamp_lll
{
    public partial class winStartApplication : Window
    {
        public winStartApplication()
        {
            InitializeComponent();
        }

        DispatcherTimer _timer = new DispatcherTimer();
        int counter = 0;

        private void timer_Tick(object sender, EventArgs e)
        {
            counter = counter + 10;
            TimerLabel.Text = counter.ToString();

            if (counter == 100)
            {
                _timer.Stop();
                TimerLabel.Text = "0".ToString();
            }

        }

        private void StartTimer()
        {
            cpb_uc.Visibility = Visibility.Visible;

            if (counter > 0)
            {
                _timer.Tick -= timer_Tick!;
                counter = 0;
            }

            _timer.Interval = TimeSpan.FromMilliseconds(250);
            _timer.Tick += timer_Tick!;
            _timer.Start();
        }

        private void StopTimer()
        {
            if (counter > 0)
            {
                _timer.Tick -= timer_Tick!;
                counter = 0;
            }

            _timer.Stop();
            cpb_uc.Visibility = Visibility.Collapsed;
            TimerLabel.Text = "0".ToString();
        }

        private void StartAnimation()
        {
            ((Storyboard)cpb_uc.Resources["ProgressBarAnimation"]).Begin();
        }

        private void StopAnimation()
        {
            ((Storyboard)cpb_uc.Resources["ProgressBarAnimation"]).Stop();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Start_Btn_Checked(object sender, RoutedEventArgs e)
        {
            StartTimer();
            StartAnimation();
        }

        private void Start_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            StopTimer();
            StopAnimation();
        }

        private void Uncheck_Stop(object sender, RoutedEventArgs e)
        {
            Start_Btn.IsChecked = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StartTimer();
            StartAnimation();
        }
    }
}
