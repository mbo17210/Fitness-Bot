namespace FitnessTrackerBot.Data.Schedule;

internal class WeeklySchedule : DailySchedule
{
    public WeeklySchedule(List<string> exercises) : base(exercises, (int)DateTime.Now.DayOfWeek)
    {
    }
}