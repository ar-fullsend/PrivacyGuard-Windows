using System;

namespace PrivacyGuard.Core
{
    public class PrivacyGuardManager
    {
        public static PrivacyGuardManager Shared { get; } = new PrivacyGuardManager();

        private bool _isActive = false;
        private int _currentFaceCount = 1;

        public void StartMonitoring()
        {
            _isActive = true;
            Console.WriteLine("Windows webcam monitoring started");
            // TODO: Integrate Windows.Media.Capture and face detection
        }

        public void StopMonitoring()
        {
            _isActive = false;
            Console.WriteLine("Windows webcam monitoring stopped");
        }

        public void HandleFaceCount(int count)
        {
            _currentFaceCount = count;
            if (count > 1)
            {
                Console.WriteLine("🛡️ Shield activated - Multiple faces detected");
                // TODO: Show WPF/WinUI overlay
            }
            else
            {
                Console.WriteLine("✅ Shield deactivated");
            }
        }
    }
}