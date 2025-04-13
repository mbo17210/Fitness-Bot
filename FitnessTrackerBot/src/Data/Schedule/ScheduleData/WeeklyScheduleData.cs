namespace FitnessTrackerBot.Data.Schedule;

public class WeeklyScheduleData : DailyScheduleData
{
    public WeeklyScheduleData(List<string> exercises) : base(exercises, (int)DateTime.Now.DayOfWeek)
    {
        if(exercises.Count != 7)
        {
            throw new ArgumentException("Incorrect number of exercises provided for a weekly scheudle!");
        }
    }
}