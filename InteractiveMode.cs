using agriffard.Commands;
using Spectre.Console;
using System;
using System.Threading.Tasks;

namespace agriffard;

public static class InteractiveMode
{
    public static async Task<int> RunAsync()
    {
        AnsiConsole.MarkupLine("[bold deepskyblue3]Interactive Mode[/]");
        AnsiConsole.MarkupLine("[dim]Enter commands (blog, bluesky, books, card, contact, courses, dometrain, linkedin, nimblepros, packages, pluralsight, quote, recent, repos, speaker, subscribe, tips, youtube). Press Ctrl+C or type 'exit' to quit.[/]\n");
        
        while (true)
        {
            var input = AnsiConsole.Prompt(
                new TextPrompt<string>("[deepskyblue3]>[/]")
                    .AllowEmpty()
            );

            // Handle exit conditions
            if (string.IsNullOrWhiteSpace(input) || 
                input.Equals("exit", StringComparison.OrdinalIgnoreCase) ||
                input.Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                AnsiConsole.MarkupLine("[dim]Goodbye![/]");
                return 0;
            }

            // Process commands
            var command = input.Trim().ToLowerInvariant();
            
            try
            {
                switch (command)
                {
                    case "card":
                        new CardCommand().Execute(null!);
                        break;
                    
                    case "blog":
                        new BlogCommand().Execute(null!);
                        break;
                    
                    case "bluesky":
                        new BlueSkyCommand().Execute(null!);
                        break;
                    
                    case "linkedin":
                        new LinkedInCommand().Execute(null!);
                        break;
                    
                    case "help":
                    case "?":
                        AnsiConsole.MarkupLine("[bold]Available commands:[/]");
                        AnsiConsole.WriteLine();
                        AnsiConsole.MarkupLine("[bold]Display Commands:[/]");
                        AnsiConsole.MarkupLine("  [deepskyblue3]card[/]    - Display business card");
                        AnsiConsole.WriteLine();
                        AnsiConsole.MarkupLine("[bold]Open Commands:[/]");
                        AnsiConsole.MarkupLine("  [deepskyblue3]blog[/]    - Open blog");
                        AnsiConsole.WriteLine();
                        AnsiConsole.MarkupLine("  [deepskyblue3]exit[/]    - Exit interactive mode");
                        break;
                    
                    default:
                        AnsiConsole.MarkupLine($"[red]Unknown command:[/] {input}");
                        AnsiConsole.MarkupLine("[dim]Type 'help' for available commands.[/]");
                        break;
                }
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]Error:[/] {ex.Message}");
            }

            AnsiConsole.WriteLine();
        }
    }
}
