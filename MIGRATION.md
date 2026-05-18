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
| 0 | Repo prep: `.gitignore`, branch (`migrate-avalonia`) | Done |
| 1 | Extract `TimeCopy.Core` + xUnit tests | Done |
| 2 | Bootstrap Avalonia project (`TimeCopy.Desktop`), verify launch on Windows & macOS | Done (macOS launch confirmed via `dotnet run`) |
| 3 | Rebuild `Form1` UI in Avalonia XAML + ViewModel | Done (A: ViewModel/services, B: XAML layout, C: services wired, D: AnnounceP) |
| 4 | TrayIcon (Windows tray / macOS menu bar) with context menu | Done (D defers the ~15s macOS startup-lag investigation - see Known Issues) |
| 5 | Clipboard + cross-platform notifications | Deferred (in-window toast in place on all OSes; macOS native postponed to Phase 7 - see Notifications) |
| 6 | Single-instance enforcement (lockfile / named pipe; cross-platform) | Done (`SingleInstanceLock` with `FileShare.None`) |
| 7 | Packaging: macOS `.app` + signing + notarization, Windows code signing | **Next**. Bundles macOS notification identity, expected to unlock `MacOsNotificationService`. |
| 8 | Retire `TimeCopyIconWinForms` project | Planned. Recommended before Phase 7 to keep the .app build config simple. |

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

## Notifications

- All platforms currently use `WindowNotificationService` (Avalonia in-window toast). This works regardless of OS permissions and matches what we have right now.
- A `MacOsNotificationService` (osascript-based) is checked in but unwired. macOS denies osascript notifications by default unless the user explicitly enables Script Editor in System Settings → Notifications, which is too hostile a setup step for the dev loop. The plan is to wire it in **Phase 7** once we ship a `.app` bundle: the bundle gets its own notification identity, the OS shows a one-time permission prompt under the app's name, and `MacOsNotificationService` (or a UNUserNotificationCenter P/Invoke equivalent) becomes the macOS default.
- Native Windows Toast (P/Invoke or `Microsoft.Toolkit.Uwp.Notifications` standalone) remains a follow-up.

## Known Issues

- **macOS menu-bar icon appears ~15s after the window** — `TrayIcon` registration takes a long time to surface in the menu bar on macOS (`Release` build, `.ico` and `.png` both reproduce; the main window and all commands work immediately). Day-to-day usage isn't blocked because the user does not interact with the icon right after launch. Deferred — revisit after the rest of the migration is in place; likely investigation path is the Avalonia 12 `NSStatusItem` integration.

## Local Toolchain (macOS verified)

- `.NET 10 SDK` installed via Homebrew (`/opt/homebrew/Cellar/dotnet/10.0.107`)
- Working branch: `migrate-avalonia` (pushed to origin)
- ImageMagick available at `/opt/homebrew/bin/magick` (used to convert `stopwatch.ico` → `stopwatch.png` for the tray)

## Resume Pointer

Last interactive session ended with Phases 0–6 in place (Phase 5 deferred). To pick up:

1. Decide on **Phase 8 (retire WinForms)** vs **Phase 7 (packaging)** as the next step. Phase 8 first is the cleaner path because it removes Windows-only artefacts before the macOS bundle work begins.
2. After Phase 7: revive `MacOsNotificationService` and switch the OS-routing in `App.CreateNotificationService` back on, since the `.app` bundle owns its own notification identity.
3. Investigation queue: macOS menu-bar icon `~15s` startup lag (Phase 4-D, deferred).

`screenshot_win.png` at the repo root is a user-supplied reference of the Windows Form 1 layout; still untracked - decide whether to move it under `docs/` or `.gitignore` it during Phase 8 cleanup.

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
