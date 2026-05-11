# PrivacyGuard-Windows

**Your screen. Yours alone. (Windows Edition)**

Real-time second-face detection for Windows using built-in or USB webcams. Triggers an automatic privacy shield overlay when multiple faces are detected.

## Quick Start

1. Clone the repo
2. Open `PrivacyGuard-Windows.sln` in Visual Studio 2022 (or later)
3. Set target to .NET 8
4. Run on Windows 10/11

Or build from command line:
```bash
dotnet build
dotnet run
```

## How It Works

1. **Capture** — Windows Media Foundation grabs frames from default webcam.
2. **Detect** — Uses Windows Vision API or ML.NET for on-device face detection.
3. **Shield** — WPF/WinUI overlay activates on >1 face.
4. **Restore** — Overlay disappears when single face remains.

## Project Structure (Planned)

- `src/PrivacyGuard.Core/` — Core library (CameraSensor, FaceDetector, ShieldManager)
- `src/PrivacyGuard.Windows/` — WPF/WinUI desktop app
- `.github/workflows/ci.yml` — Windows CI with .NET 8

## Requirements

- Windows 10 version 1809+ or Windows 11
- .NET 8 SDK
- Webcam (built-in or USB)
- Camera permission (Windows Settings > Privacy > Camera)

## Future

- Full WinUI 3 app with live preview
- System-wide overlay using Windows.Graphics.Capture
- Integration with Windows Hello and enterprise policies

MIT License — privacy-first Windows protection.