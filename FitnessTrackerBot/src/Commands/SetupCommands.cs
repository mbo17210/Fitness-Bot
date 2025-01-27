using System.Globalization;
using DSharpPlus.Commands;
using FitnessTrackerBot.Data;
using FitnessTrackerBot.Data.Schedule;

namespace FitnessTrackerBot.Commands;

internal class SetupCommands
{
    public IUserDatabase Database { private get; set;}

    public SetupCommands(IUserDatabase database)
    {
        Database = database;
    }

    [Command("register")]
    public static async ValueTask RegisterUser(CommandContext context)
    {
        string userId = context.User.Id.ToString(CultureInfo.InvariantCulture);
        User newUser = new User(userId);
        await context.RespondAsync($"User {userId} has been registered!").ConfigureAwait(false);
    }
} 