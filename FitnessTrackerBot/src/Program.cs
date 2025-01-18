// See https://aka.ms/new-console-template for more information
using DSharpPlus;

namespace FitnessBot;

class Program
{
    static async Task Main(string[] args)
    {
        DiscordClientBuilder builder = DiscordClientBuilder.CreateDefault(
            Environment.GetEnvironmentVariable("FITNESS_TRACKER_TOKEN"),
            DiscordIntents.AllUnprivileged
        );
        DiscordClient client = builder.Build();
    }
}