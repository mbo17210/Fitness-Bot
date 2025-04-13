namespace FitnessTrackerBot.Data.Schedule;

public class DailyScheduleData : ScheduleData
{
    public List<string> Exercises { get; set; }
    public DateTime StartDay { get; set; }

    public DailyScheduleData(List<string> exercises)
    {
        Exercises = exercises;
        StartDay = DateTime.Now;
    }

    public DailyScheduleData(List<string> exercises, int startExercise)
    {
        Exercises = exercises;
        StartDay = DateTime.Now.AddDays(startExercise * -1);
    }

    public override ISchedule ToSchedule()
    {
        return new DailySchedule(this);
    }
}