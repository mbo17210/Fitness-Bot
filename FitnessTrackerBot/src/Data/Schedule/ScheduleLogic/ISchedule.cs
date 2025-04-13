namespace FitnessTrackerBot.Data.Schedule;

public interface ISchedule
{
    public string GetTodaysExercise();
    public List<string> GetNextExercises(int numberOfDays);
}