namespace FitnessTrackerBot.Data.Schedule;

internal class WeeklySchedule : DailySchedule
{
    public WeeklySchedule(List<string> exercises) : base(exercises, (int)DateTime.Now.DayOfWeek)
    {
        if(exercises.Count != 7)
        {
            throw new ArgumentException("Incorrect number of exercises provided for a weekly scheudle!");
        }
    }
}