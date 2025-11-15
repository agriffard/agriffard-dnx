# agriffard-card-dnx

[![NuGet](https://img.shields.io/nuget/v/agriffard.svg)](https://www.nuget.org/packages/agriffard)
[![NuGet Downloads](https://img.shields.io/nuget/dt/agriffard.svg)](https://www.nuget.org/packages/agriffard)

A .NET global tool that displays a personal business card in your terminal. 💠

## Overview

A CLI tool built for the .NET ecosystem using the new **`dnx`** command introduced in .NET 10! Run it instantly to access "agriffard" Antoine Griffard's resources and information—no installation required!

## Quick Start with dnx

The easiest way to run this tool is with the new `dnx` command (similar to `npx` in Node.js):

```bash
dnx agriffard
```

That's it! The first time you run it, you'll be prompted to confirm the download. After that, it runs instantly without confirmation.

### Available Commands

View help and available commands:

```bash
dnx agriffard
```

Display the business card:

```bash
dnx agriffard card
```

Open agriffard's blog:

```bash
dnx agriffard blog
```

Check the version:

```bash
dnx agriffard --version
```

### Interactive Mode

Run in interactive mode to execute multiple commands without re-running the tool:

```bash
dnx agriffard -i
```

In interactive mode, simply type commands:

```text
> card
(displays card)

> blog
(opens blog)

> exit
```

Exit by typing `exit`, `quit`, or pressing Enter on an empty line.

### Recent Activity Command

The `recent` command displays your latest activity from multiple platforms:

```bash
dnx agriffard recent
```

Use `--verbose` to see detailed progress from each source:

```bash
dnx agriffard recent --verbose
```

The verbose mode shows:

- ✅ Number of results found from each source
- ⚠️ Sources with no results
- ❌ Any errors encountered while fetching data

Activity is displayed with relative timestamps like "5 min ago" or "2 hours ago" for recent items, and short dates for older items.

## Permanent Installation

To install globally and run as just `agriffard` (without `dnx`):

```bash
dotnet tool install -g agriffard
```

Then run from anywhere:

```bash
agriffard            # Show help
agriffard card       # Display business card
agriffard --version  # Check version
```

### Managing the Installation

Update to the latest version:

```bash
dotnet tool update -g agriffard
```

Uninstall:

```bash
dotnet tool uninstall -g agriffard
```

## Features

- ⚡ **One-command execution** with the new `dnx` command—no installation needed!
- 🎨 Beautiful terminal UI with [Spectre.Console](https://spectreconsole.net/)
- 💼 Quick access to professional links
- 🌐 Cross-platform (Windows, macOS, Linux)
- 🚀 Built with .NET 10.0

## dnx vs. Global Installation

**Key Differences:**

| Method | Command | Installation | Use Case |
|--------|---------|-------------|----------|
| **dnx** | `dnx agriffard` | None (downloads on first run) | Try it once, occasional use |
| **Global Tool** | `agriffard` | Permanent (`dotnet tool install -g`) | Frequent use, always available |

The `dnx` command is .NET's answer to Node.js's `npx`, introduced in .NET 10. It allows you to run .NET tools on-demand without explicitly installing them. Perfect for trying out tools or running one-off commands!

Learn more: [Running one-off .NET tools with dnx](https://andrewlock.net/exploring-dotnet-10-preview-features-5-running-one-off-dotnet-tools-with-dnx/)

## Building from Source

```bash
dotnet build
dotnet pack
dotnet tool install -g --add-source ./bin/Debug agriffard
```

## About

Created by Antoine Griffard "agriffard"

- 🌐 [antoinegriffard.com](https://antoinegriffard.com)

Specializing in Clean Architecture, Domain-Driven Design, and .NET development.

## Contributing

For maintainers: See [CONTRIBUTING.md](CONTRIBUTING.md) for instructions on publishing new versions.

Based on https://github.com/ardalis/ardalis-card-dnx
