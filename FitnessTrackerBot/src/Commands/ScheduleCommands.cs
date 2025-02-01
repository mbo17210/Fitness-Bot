using System.Globalization;
using DSharpPlus.Commands;
using DSharpPlus.Commands.ArgumentModifiers;
using FitnessTrackerBot.Data.Schedule;

namespace FitnessTrackerBot.Commands;

[Command("schedule")]
internal class ScheduleCommands 
{
    public IUserDatabase Database { private get; set;}

    public ScheduleCommands(IUserDatabase database)
    {
        Database = database;
    }

    [Command("setWeekly")]
    public async ValueTask SetWeeklySchedule(
        CommandContext context,
        string Monday,
        string Tuesday,
        string Wednesday,
        string Thursday,
        string Friday,
        string Saturday,
        string Sunday
    )
    {
        List<string> workouts = [Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday];
        ISchedule schedule = new WeeklySchedule(workouts);
        string userId = context.User.Id.ToString(CultureInfo.InvariantCulture);
        Database.GetUser(userId).Schedule = schedule;
        await context.RespondAsync($"User {context.User.Username} has updated their schedule!").ConfigureAwait(false);
    }
}