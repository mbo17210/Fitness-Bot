using DSharpPlus.Commands;

namespace FitnessTrackerBot.Commands;

internal static class ScheduleCommands 
{
    [Command("ping")]
    public static async ValueTask ExecuteAsync(CommandContext context)
    {
        await context.RespondAsync($"Pong!").ConfigureAwait(false);
    }
}