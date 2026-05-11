# PrivacyGuard-Windows

**Your screen. Yours alone. (Windows Edition)**

Real-time second-face detection for Windows using built-in or USB webcams. Triggers an automatic privacy shield overlay when multiple faces are detected.

## Quick Start

### Option 1: Background .exe (Recommended for daily use)
1. Build the background app:
   ```bash
   cd src/PrivacyGuard.Background
   dotnet publish -c Release -r win-x64 --self-contained -o ./publish
   ```
2. Run `PrivacyGuard.Background.exe` — it starts minimized in the system tray.
3. Press **Ctrl + Alt + P** anytime to toggle monitoring on/off.
4. Right-click the tray icon for manual control or Exit.

### Option 2: Full WinUI Desktop App
1. Open the folder in Visual Studio 2022+
2. Set `PrivacyGuard.WinUI` as startup project
3. Build & Run

### Option 3: CLI Demo
```bash
dotnet run --project src/PrivacyGuard.Demo
```

## Features
- Real-time webcam face detection
- Automatic privacy shield overlay
- **Global hotkey (Ctrl+Alt+P)** to toggle in background
- System tray icon with notifications
- 100% on-device (no cloud)

## Project Structure
- `src/PrivacyGuard.Core/` — Shared library
- `src/PrivacyGuard.Background/` — Tray .exe with hotkey (production background app)
- `src/PrivacyGuard.WinUI/` — Full WinUI 3 desktop app
- `src/PrivacyGuard.Demo/` — Console demo
- `.github/workflows/ci.yml` — Windows CI

## Requirements
- Windows 10 (1809+) or Windows 11
- .NET 8 SDK
- Webcam + Camera permission

## Future
- Full camera preview in WinUI
- System-wide overlay (Windows.Graphics.Capture)
- Windows Hello integration

MIT License — privacy-first Windows protection.