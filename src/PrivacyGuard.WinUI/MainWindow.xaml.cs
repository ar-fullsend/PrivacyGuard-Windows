using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using PrivacyGuard.Core;

namespace PrivacyGuard.WinUI
{
    public sealed partial class MainWindow : Window
    {
        private readonly PrivacyGuardManager _manager = PrivacyGuardManager.Shared;
        private bool _isMonitoring = false;

        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            _manager.StartMonitoring();
            _isMonitoring = true;
            StatusText.Text = "Monitoring active — Shield will activate on second face";
            StatusText.Foreground = new Microsoft.UI.Xaml.Media.SolidColorBrush(Microsoft.UI.Colors.Green);
            StartButton.IsEnabled = false;
            StopButton.IsEnabled = true;
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            _manager.StopMonitoring();
            _isMonitoring = false;
            StatusText.Text = "Monitoring stopped";
            StatusText.Foreground = new Microsoft.UI.Xaml.Media.SolidColorBrush(Microsoft.UI.Colors.White);
            StartButton.IsEnabled = true;
            StopButton.IsEnabled = false;
        }
    }
}