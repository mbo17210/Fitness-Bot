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
    public async ValueTask RegisterUser(CommandContext context)
    {
        string userId = context.User.Id.ToString(CultureInfo.InvariantCulture);
        User newUser = new User(userId);
		try
		{
            Database.AddUser(newUser);
        }
        catch (ArgumentException)
		{
            await context.RespondAsync($"User {context.User.Username} has already been registered!").ConfigureAwait(false);
            return;
        }
        await context.RespondAsync($"User {context.User.Username} has been registered!").ConfigureAwait(false);
    }
} 