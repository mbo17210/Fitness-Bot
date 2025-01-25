namespace FitnessTrackerBot.Data.Schedule;

internal class WeeklySchedule : ISchedule
{
    private List<string> _exercises;
    private const int DaysPerWeek = 7;
    public WeeklySchedule(List<string> exercises)
    {
        if(exercises.Count != 7)
        {
            throw new ArgumentException("Exercises list does not contain a full week of exercies");
        }
        _exercises = exercises;
    }

    public string GetTodaysExercise()
    {
        return GetNextExercises(1)[0];
    }

    public List<string> GetNextExercises(int numberOfDays)
    {
        int currentDay = (int)DateTime.Now.DayOfWeek;
        List<string> nextExercises = [];
        while (numberOfDays > 0)
		{
			nextExercises.Add(GetDaysExercise(currentDay));
			numberOfDays--;
			currentDay = (currentDay + 1) % DaysPerWeek;
		}
		return nextExercises;
    }

	private string GetDaysExercise(int dayOfWeek)
    {
        return _exercises[dayOfWeek];
    }
}