// See https://aka.ms/new-console-template for more information
using DSharpPlus;
using DSharpPlus.Commands;
using FitnessBot.Commands;

namespace FitnessBot;

class Program
{
    static async Task Main(string[] args)
    {
        DiscordClientBuilder builder = DiscordClientBuilder.CreateDefault(
            Environment.GetEnvironmentVariable("FITNESS_TRACKER_TOKEN"),
            DiscordIntents.AllUnprivileged
        );

        builder.UseCommands(CommandSetup.Configure);
        DiscordClient client = builder.Build();
    }
}