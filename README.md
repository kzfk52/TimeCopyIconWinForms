# TimeCopyIconWinForms

A small system-tray utility that copies the current time to the clipboard in several formats (UnixTime, `Y/m/d H:i:s`, `YmdHis`) and converts between Unix time and ISO 8601.

## Status

A cross-platform port to **Avalonia UI** (Windows + macOS) is in progress on the [`migrate-avalonia`](../../tree/migrate-avalonia) branch. See [MIGRATION.md](MIGRATION.md) for the plan and current phase.

The existing WinForms project (`TimeCopyIconWinForms/`, `net6.0-windows`) remains the shipping version until the Avalonia rewrite reaches feature parity.

## Build

```bash
# Windows — full solution (includes the WinForms project)
dotnet build TimeCopyIcon.sln

# macOS / Linux — cross-platform projects only
dotnet build TimeCopyIcon.CrossPlatform.slnf
dotnet test  TimeCopyIcon.CrossPlatform.slnf
```

### License

Copyright © 2023, [FUKUDA Kazuyuki](https://github.com/kzfk).
Released under the [MIT License](LICENSE).
