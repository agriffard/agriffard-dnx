using System;
using agriffard;
using agriffard.Commands;
using Spectre.Console;
using Spectre.Console.Cli;

// Check for interactive mode
if (args.Length > 0 && (args[0] == "-i" || args[0] == "--interactive"))
{
    return await InteractiveMode.RunAsync();
}

// Check for version flag to add update notification
if (args.Length > 0 && (args[0] == "-v" || args[0] == "--version" || args[0] == "version"))
{
    var currentVersion = typeof(Program).Assembly.GetName().Version?.ToString() ?? "1.0.0";
    AnsiConsole.WriteLine(currentVersion);
    
    // Check for updates on NuGet
    try
    {
        using var httpClient = new System.Net.Http.HttpClient { Timeout = System.TimeSpan.FromSeconds(3) };
        var response = await httpClient.GetStringAsync("https://api.nuget.org/v3-flatcontainer/agriffard/index.json");
        var versionData = System.Text.Json.JsonSerializer.Deserialize<NuGetVersionData>(response);
        
        if (versionData?.Versions != null && versionData.Versions.Length > 0)
        {
            var latestVersion = versionData.Versions[^1]; // Get last version (latest)
            
            // Parse versions for comparison
            var current = System.Version.Parse(currentVersion);
            var latest = System.Version.Parse(latestVersion);
            
            AnsiConsole.WriteLine();
            if (latest > current)
            {
                AnsiConsole.MarkupLine($"[yellow]v{latestVersion} is available; upgrade with:[/]");
                AnsiConsole.MarkupLine($"[cyan]dotnet tool update -g agriffard[/]");
            }
            else
            {
                AnsiConsole.MarkupLine("[green]You are on the latest version.[/]");
            }
        }
    }
    catch (Exception ex)
    {
        // TODO: Use logging and telemetry to report errors
        AnsiConsole.MarkupLine($"[red]Unable to check for updates: {ex.Message}[/]");
    }
    
    return 0;
}

// Check for help flag to add custom installation instructions
if (args.Length > 0 && (args[0] == "-h" || args[0] == "--help" || args[0] == "help"))
{
    var helpApp = new CommandApp();
    helpApp.Configure(config =>
    {
        config.SetApplicationName("agriffard");
        config.SetApplicationVersion(typeof(Program).Assembly.GetName().Version?.ToString() ?? "1.0.0");
        
        // Display commands (alphabetical)
        config.AddCommand<CardCommand>("card").WithDescription("Display agriffard's business card.");
        
        // Open commands (alphabetical)
        config.AddCommand<BlogCommand>("blog").WithDescription("Open agriffard's blog.");
        config.AddCommand<BlueSkyCommand>("bluesky").WithDescription("Open agriffard's Bluesky profile.");
        config.AddCommand<LinkedInCommand>("linkedin").WithDescription("Open agriffard's LinkedIn profile.");
        
        config.AddExample("card");
        config.AddExample("blog");
        config.AddExample("-i");
    });
    
    var result = helpApp.Run(args);
    
    // Add installation instructions after the help output
    AnsiConsole.WriteLine();
    AnsiConsole.MarkupLine("[bold]INSTALLATION:[/]");
    AnsiConsole.MarkupLine("  Install as a global .NET tool:");
    AnsiConsole.MarkupLine("    [cyan]dotnet tool install -g agriffard[/]");
    AnsiConsole.WriteLine();
    AnsiConsole.MarkupLine("  Update to the latest version:");
    AnsiConsole.MarkupLine("    [cyan]dotnet tool update -g agriffard[/]");
    AnsiConsole.WriteLine();
    AnsiConsole.MarkupLine("  [dim]Once installed, use 'agriffard' instead of 'dnx agriffard'[/]");
    
    return result;
}

var app = new CommandApp();

app.Configure(config =>
{
    config.SetApplicationName("agriffard");
    config.SetApplicationVersion(typeof(Program).Assembly.GetName().Version?.ToString() ?? "1.0.0");
    
    // Display commands (alphabetical)
    config.AddCommand<CardCommand>("card")
        .WithDescription("Display agriffard's business card.");

    // Open commands (alphabetical)
    config.AddCommand<BlogCommand>("blog")
        .WithDescription("Open agriffard's blog.");

    config.AddCommand<BlueSkyCommand>("bluesky")
        .WithDescription("Open agriffard's Bluesky profile.");

    config.AddCommand<LinkedInCommand>("linkedin")
        .WithDescription("Open agriffard's LinkedIn profile.");
        
    config.AddExample("card");
    config.AddExample("blog");
    config.AddExample("-i");
});

return app.Run(args);

// Data class for NuGet version response
record NuGetVersionData([property: System.Text.Json.Serialization.JsonPropertyName("versions")] string[] Versions);
