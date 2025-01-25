namespace FitnessTrackerBot.Data.Schedule;

internal class DailySchedule : ISchedule
{
    private List<string> _exercises;
    private DateTime _startDay;
    private int _numberOfDaysInSchedule;
    public DailySchedule(List<string> exercises)
    {
        _exercises = exercises;
        _startDay = DateTime.Now;
        _numberOfDaysInSchedule = exercises.Count;
    }

    public DailySchedule(List<string> exercises, int startExercise)
    {
        _exercises = exercises;
        _startDay = DateTime.Now.AddDays(startExercise * -1);
        _numberOfDaysInSchedule = exercises.Count;
    }

	public List<string> GetNextExercises(int numberOfDays)
    {
        List<string> nextExercises = [];
        DateTime currentDay = DateTime.Now;
        int currentExercise = (currentDay - _startDay).Days;
        while (numberOfDays > 0)
		{
			nextExercises.Add(GetDaysExercise(currentExercise));
			numberOfDays--;
			currentExercise++;
		}
		return nextExercises;
    }

    private string GetDaysExercise(int currentExercise)
    {
        return _exercises[currentExercise % _numberOfDaysInSchedule];
    }

	public string GetTodaysExercise()
    {
        return GetNextExercises(1)[0];
    }

    
}