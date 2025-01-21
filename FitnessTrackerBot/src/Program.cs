// See https://aka.ms/new-console-template for more information
using DSharpPlus;
using DSharpPlus.Commands;
using Microsoft.Extensions.Configuration;
using FitnessTrackerBot.Commands;
using System;

namespace FitnessTrackerBot;

class Program
{
    static async Task Main(string[] args)
    {
        IConfigurationRoot configurationBuilder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        string discordKey = configurationBuilder["Discord:Token"] ?? throw new Exception("Token isn't in config. Make an appsettings.json and add it in the appropriate location.");

        DiscordClientBuilder builder = DiscordClientBuilder.CreateDefault(
            discordKey,
            DiscordIntents.AllUnprivileged
        );

        builder.UseCommands(CommandSetup.Configure);
        DiscordClient client = builder.Build();

        await client.ConnectAsync().ConfigureAwait(false);
        await Task.Delay(-1).ConfigureAwait(false);
    }
}