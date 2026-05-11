using System;
using System.Drawing;
using System.Windows.Forms;
using PrivacyGuard.Core;

namespace PrivacyGuard.Background
{
    static class Program
    {
        private static NotifyIcon? _trayIcon;
        private static bool _isActive = false;
        private static readonly PrivacyGuardManager _manager = PrivacyGuardManager.Shared;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Create system tray icon
            _trayIcon = new NotifyIcon
            {
                Icon = SystemIcons.Shield,
                Visible = true,
                Text = "PrivacyGuard - Running in background"
            };

            // Context menu
            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Toggle Monitoring (Ctrl+Alt+P)", null, ToggleMonitoring);
            contextMenu.Items.Add("Exit", null, (s, e) => Application.Exit());

            _trayIcon.ContextMenuStrip = contextMenu;
            _trayIcon.DoubleClick += (s, e) => ToggleMonitoring(null, null);

            // Register global hotkey (Ctrl + Alt + P)
            RegisterHotKey();

            // Start monitoring by default
            _manager.StartMonitoring();
            _isActive = true;
            _trayIcon.ShowBalloonTip(3000, "PrivacyGuard", "Running in background. Press Ctrl+Alt+P to toggle.", ToolTipIcon.Info);

            Application.Run();
        }

        private static void ToggleMonitoring(object? sender, EventArgs? e)
        {
            if (_isActive)
            {
                _manager.StopMonitoring();
                _isActive = false;
                _trayIcon!.Text = "PrivacyGuard - Disabled";
                _trayIcon.ShowBalloonTip(2000, "PrivacyGuard", "Monitoring disabled", ToolTipIcon.Warning);
            }
            else
            {
                _manager.StartMonitoring();
                _isActive = true;
                _trayIcon!.Text = "PrivacyGuard - Running in background";
                _trayIcon.ShowBalloonTip(2000, "PrivacyGuard", "Monitoring enabled", ToolTipIcon.Info);
            }
        }

        // Global hotkey (Ctrl + Alt + P)
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        private static void RegisterHotKey()
        {
            // Register Ctrl + Alt + P (0x50 = 'P')
            RegisterHotKey(IntPtr.Zero, 1, 0x0001 | 0x0002, 0x50); // MOD_CONTROL | MOD_ALT
            Console.WriteLine("Global hotkey Ctrl+Alt+P registered");
        }
    }
}