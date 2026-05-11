using PrivacyGuard.Core;

Console.WriteLine("PrivacyGuard Windows Demo - Real-time webcam face detection");
Console.WriteLine("Press Enter to start, type 'stop' to end, 'quit' to exit.");

var manager = PrivacyGuardManager.Shared;

while (true)
{
    Console.Write("\nCommand: ");
    var input = Console.ReadLine()?.ToLower().Trim();

    if (input == "start" || input == "")
    {
        manager.StartMonitoring();
        // Simulate face detection
        Console.WriteLine("Simulating: 2 faces detected → Shield active");
        manager.HandleFaceCount(2);
    }
    else if (input == "stop")
    {
        manager.StopMonitoring();
        manager.HandleFaceCount(1);
    }
    else if (input == "quit")
    {
        manager.StopMonitoring();
        Console.WriteLine("Exiting PrivacyGuard Windows Demo.");
        break;
    }
    else
    {
        Console.WriteLine("Unknown command. Use 'start', 'stop', or 'quit'.");
    }
}