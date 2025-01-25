using System.Globalization;
using DSharpPlus.Commands;
using FitnessTrackerBot.Data;

namespace FitnessTrackerBot.Commands;

internal static class SetupCommands
{
    [Command("register")]
    public static async ValueTask RegisterUser(CommandContext context)
    {
        string userId = context.User.Id.ToString(CultureInfo.InvariantCulture);
        User newUser = new User(userId);
        await context.RespondAsync($"User {userId} has been registered!").ConfigureAwait(false);
    }
} 