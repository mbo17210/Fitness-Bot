namespace FitnessTrackerBot.Data.Schedule;

internal interface ISchedule
{
    public string GetTodaysExercise();
    public List<string> GetNextExercises(int numberOfDays);
}