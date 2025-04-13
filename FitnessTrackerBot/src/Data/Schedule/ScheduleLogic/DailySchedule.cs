namespace FitnessTrackerBot.Data.Schedule;

public class DailySchedule : ISchedule
{
    private List<string> _exercises;
    private DateTime _startDay;
    private int _numberOfDaysInSchedule;
    public DailySchedule(DailyScheduleData data)
    {
        _exercises = data.Exercises;
        _startDay = data.StartDay;
        _numberOfDaysInSchedule = data.Exercises.Count;
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