# Avalonia Migration Plan

This document tracks the migration of `TimeCopyIconWinForms` from Windows-only WinForms (`net6.0-windows`) to a cross-platform Avalonia UI application that runs on both Windows and macOS.

## Goals

- Run the application on macOS in addition to Windows
- Preserve the existing system tray / menu bar driven workflow
- Keep WinForms project alive in parallel until the Avalonia version reaches feature parity
- Adopt a modern, supported runtime (.NET 10 LTS)

## Target Stack

| Concern | Choice | Notes |
|---|---|---|
| Runtime | **.NET 10 (LTS)** | Supported until 2028-11-14 |
| UI Framework | **Avalonia UI 11.x** | Cross-platform, native look on each OS, ships with `TrayIcon` API |
| MVVM | **CommunityToolkit.Mvvm** | Lightweight, source-generator based |
| Tests | **xUnit** | Runs on macOS via `dotnet test` |
| Notifications | **DesktopNotifications.Avalonia** (planned) | Cross-platform toast/banner |
| Packaging (Win) | Existing `codesign.bat` (Authenticode) | Keep as-is |
| Packaging (mac) | `.app` bundle + `codesign` + `notarytool` + `.dmg` | Apple Developer ID required for distribution |

## Target Solution Layout

```
TimeCopyIcon.sln
├── TimeCopy.Core/                     (new, net10.0)
│   ├── TimeFormatter.cs               (replaces Helper.cs)
│   └── TimeCopy.Core.csproj
├── TimeCopy.Core.Tests/               (new, net10.0)
│   ├── TimeFormatterTests.cs
│   └── TimeCopy.Core.Tests.csproj
├── TimeCopy.Desktop/                  (new, net10.0, Avalonia) — added in Phase 2
│   ├── App.axaml(.cs)
│   ├── Program.cs                     (single-instance + Avalonia bootstrap)
│   ├── ViewModels/MainWindowViewModel.cs
│   ├── Views/MainWindow.axaml(.cs)
│   ├── Services/{Clipboard,Notification,TrayIcon}/...
│   ├── Assets/{stopwatch.ico, stopwatch.icns}
│   └── TimeCopy.Desktop.csproj
└── TimeCopyIconWinForms/              (existing, net6.0-windows) — frozen until retired
```

## Phased Migration

| Phase | Scope | Status |
|---|---|---|
| 0 | Repo prep: `.gitignore`, branch (`migrate-avalonia`) | In progress |
| 1 | Extract `TimeCopy.Core` + xUnit tests | In progress |
| 2 | Bootstrap empty Avalonia project, verify launch on Windows & macOS | Planned |
| 3 | Rebuild `Form1` UI in Avalonia XAML + ViewModel | Planned |
| 4 | TrayIcon (Windows tray / macOS menu bar) with context menu | Planned |
| 5 | Clipboard + cross-platform notifications | Planned |
| 6 | Single-instance enforcement (lockfile / named pipe; cross-platform) | Planned |
| 7 | Packaging: macOS `.app` + signing + notarization, Windows code signing | Planned |
| 8 | Retire `TimeCopyIconWinForms` project | Planned |

## Key Technical Decisions

### Why .NET 10
.NET 10 is the latest LTS (released 2025-11-11, supported until 2028-11-14). .NET 8 is also LTS but already in maintenance with support ending 2026-11-10. Targeting .NET 10 buys the longest runway without sacrificing stability.

### Why Avalonia (vs MAUI / Uno)
- First-class desktop story (MAUI is mobile-first; desktop tray support is weak).
- Native `TrayIcon` API works on both Windows tray and macOS menu bar.
- XAML model is familiar to WinForms/WPF developers and the conceptual gap from WinForms is the smallest of the cross-platform .NET options.

### Why keep WinForms project running in parallel
- Risk reduction: hot-patches for Windows users remain possible while the new code is unfinished.
- The existing WinForms project requires Windows to build; isolating it lets macOS development proceed without setting up a Windows VM.

## Known Risks

| Risk | Mitigation |
|---|---|
| Avalonia `TrayIcon` behavior differs subtly on macOS | Verify the smallest possible tray sample early in Phase 2 |
| `.icns` (macOS) vs `.ico` (Windows) asset duplication | Generate `.icns` from `stopwatch.ico` and select per-platform at runtime |
| Single-instance via `Mutex` is Windows-idiomatic and unreliable across OS | Switch to lockfile/named-pipe pattern in Phase 6 |
| Apple notarization adds operational overhead | Distribute unsigned builds initially; add signing as a separate Phase 7 sub-task |
| WinForms project and Avalonia project diverge during parallel maintenance | Freeze the WinForms project to security-only fixes once Phase 3 starts |

## Local Toolchain (macOS verified)

- `.NET 10 SDK` installed via Homebrew (`/opt/homebrew/Cellar/dotnet/10.0.107`)
- Working branch: `migrate-avalonia`

## Build & Test

The full solution (`TimeCopyIcon.sln`) contains the Windows-only WinForms project, so `dotnet build TimeCopyIcon.sln` fails on macOS/Linux. Use the solution filter when working off Windows:

```bash
# Cross-platform projects only (Core + Tests). Works on macOS, Linux, and Windows.
dotnet build TimeCopyIcon.CrossPlatform.slnf
dotnet test  TimeCopyIcon.CrossPlatform.slnf

# Windows only — full solution including WinForms
dotnet build TimeCopyIcon.sln
```

Add new cross-platform projects to both `TimeCopyIcon.sln` and `TimeCopyIcon.CrossPlatform.slnf`.
