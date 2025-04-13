// See https://aka.ms/new-console-template for more information
using DSharpPlus;
using DSharpPlus.Commands;
using Microsoft.Extensions.Configuration;
using FitnessTrackerBot.Commands;
using System;
using Microsoft.Extensions.DependencyInjection;
using DSharpPlus.Extensions;
using Microsoft.Extensions.DependencyInjection.Extensions;
using DSharpPlus.Entities;
using FitnessTrackerBot.Data.Schedule;
using DSharpPlus.Commands.Processors.TextCommands;
using DSharpPlus.Commands.Processors.SlashCommands;

namespace FitnessTrackerBot;

class Program
{
    static async Task Main(string[] args)
    {
        ServiceCollection services = [];
        
        IConfigurationRoot configurationBuilder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        string discordKey = configurationBuilder["Discord:Token"] ?? throw new Exception("Token isn't in config. Make an appsettings.json and add it in the appropriate location.");

        services.AddDiscordClient(discordKey, DiscordIntents.AllUnprivileged | TextCommandProcessor.RequiredIntents | SlashCommandProcessor.RequiredIntents);

        services.AddCommandsExtension(CommandSetup.Configure, new CommandsConfiguration(){RegisterDefaultCommandProcessors = true});

        services.AddSingleton<IUserDatabase, UserDatabase>();

        services.AddLogging();

        ServiceProvider serviceProvider = services.BuildServiceProvider();

        DiscordClient client = serviceProvider.GetRequiredService<DiscordClient>();

        // We can specify a status for our bot. Let's set it to "playing" and set the activity to "with fire".
        DiscordActivity status = new("with fire", DiscordActivityType.Playing);


        using var cts = new CancellationTokenSource();
        Console.CancelKeyPress += (sender, eventArgs) =>
        {
            Console.WriteLine("Ctrl+C detected! Shutting down...");
            eventArgs.Cancel = true; // Prevent immediate termination
            cts.Cancel(); // Signal cancellation
        };
        try
        {
            serviceProvider.GetRequiredService<IUserDatabase>().LoadUsers();
            await client.ConnectAsync().ConfigureAwait(false);
            // Wait indefinitely until a cancellation is requested
            await Task.Delay(Timeout.Infinite, cts.Token).ConfigureAwait(false);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error occured! {e}");
        }
        finally
        {
            serviceProvider.GetRequiredService<IUserDatabase>().SaveUsers();
            await client.DisconnectAsync().ConfigureAwait(false);
            client.Dispose();
            Console.WriteLine("Bot has been shutdown cleanly.");
        }
    }
}