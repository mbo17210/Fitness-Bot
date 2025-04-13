using System.ComponentModel;
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

    /// <summary>
    /// Sets a weekly schedule. Must provide an exercise for every day of the week: use "Rest" or something similar for rest days.
    /// </summary>
    /// <param name="context">Context of user who sent message</param>
    /// <param name="monday">Exercise name for Monday</param>
    /// <param name="tuesday">Exercise name for Tuesday</param>
    /// <param name="wednesday">Exercise name for Wednesday</param>
    /// <param name="thursday">Exercise name for Thursday</param>
    /// <param name="friday">Exercise name for Friday</param>
    /// <param name="saturday">Exercise name for Saturday</param>
    /// <param name="sunday">Exercise name for Sunday</param>
    /// <returns>N/A</returns>
    [Command("setWeekly")]
    public async ValueTask SetWeeklySchedule(
        CommandContext context,
        string monday,
        string tuesday,
        string wednesday,
        string thursday,
        string friday,
        string saturday,
        string sunday
    )
	{
		List<string> workouts = [sunday, monday, tuesday, wednesday, thursday, friday, saturday];
		ScheduleData schedule = new WeeklyScheduleData(workouts);
		string userMessage = SetSchedule(context, schedule);
        await context.RespondAsync(userMessage).ConfigureAwait(false);
	}

	/// <summary>
	/// Sets a daily schedule. Provide a space-deliniated list of exercises starting with todays exercise after the command. Make sure to include Rest days!
	/// </summary>
	/// <param name="context">Context of user who sent the message</param>
	/// <param name="exercises">Exercises user is doing</param>
	/// <returns></returns>
	[Command("setDaily")]
    public async ValueTask SetDailySchedule(CommandContext context, string exercises)
    {
        List<string> workouts = exercises.Split(' ').ToList();
        ScheduleData schedule = new DailyScheduleData(workouts);
        string userMessage = SetSchedule(context, schedule);
        await context.RespondAsync(userMessage).ConfigureAwait(false);
    }

	private string SetSchedule(CommandContext context, ScheduleData schedule)
	{
		string userId = context.User.Id.ToString(CultureInfo.InvariantCulture);
		try
		{
			Database.GetUser(userId).Schedule = schedule;
		}
		catch
		{
			return $"User {context.User.Username} is not yet registered! Please register the user before using any other Fitness Bot Commands!";
		}
		return $"User {context.User.Username} has updated their schedule!";
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
        List<string> nextExercises = currentUser.Schedule.ToSchedule().GetNextExercises(numberOfDays);
        string nextExercisesString = string.Join(", ", nextExercises);
        await context.RespondAsync($"The next exercises starting from today are {nextExercisesString}").ConfigureAwait(false);
    }
}