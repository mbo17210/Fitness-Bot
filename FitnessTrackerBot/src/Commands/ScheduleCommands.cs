using System.Globalization;
using DSharpPlus.Commands;
using DSharpPlus.Commands.ArgumentModifiers;
using FitnessTrackerBot.Data;
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
        try
        {
            Database.GetUser(userId).Schedule = schedule;
        }
        catch
        {
            await context.RespondAsync($"User {context.User.Username} is not yet registered! Please register the user before using any other Fitness Bot Commands!").ConfigureAwait(false);
            return;
        }
        await context.RespondAsync($"User {context.User.Username} has updated their schedule!").ConfigureAwait(false);
    }

    [Command("get")]
    public async ValueTask GetNextDays(
        CommandContext context,
        int numberOfDays
    )
    {
        string userId = context.User.Id.ToString(CultureInfo.InvariantCulture);
        User currentUser;
        try
        {
            currentUser = Database.GetUser(userId);
        }
        catch
        {
            await context.RespondAsync($"User {context.User.Username} is not yet registered! Please register the user before using any other Fitness Bot Commands!").ConfigureAwait(false);
            return;
        }
        if (currentUser.Schedule == null)
        {
            await context.RespondAsync($"User {context.User.Username} has not yet set a schedule. Please set a schedule to start using the other schedule commands!").ConfigureAwait(false);
            return;
        }
        List<string> nextExercises = currentUser.Schedule.GetNextExercises(numberOfDays);
        string nextExercisesString = string.Join(", ", nextExercises);
        await context.RespondAsync($"The next exercises starting from today are {nextExercisesString}").ConfigureAwait(false);
    }
}