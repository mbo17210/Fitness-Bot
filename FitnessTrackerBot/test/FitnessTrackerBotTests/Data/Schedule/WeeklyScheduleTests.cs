using FitnessTrackerBot.Data.Schedule;

namespace FitnessTrackerBotTests;

[TestClass]
public class WeeklyScheduleTests
{
    private static readonly List<string> _weeklyExercises = ["Rest", "Push", "Pull", "Legs", "Arms", "Chest", "Back"];
    private static readonly WeeklySchedule Schedule = new WeeklySchedule(_weeklyExercises);
    public static readonly int DayOfWeek = (int) DateTime.Now.DayOfWeek;

    [TestMethod]
    public void GetTodaysExercise_ReturnsProperExercise()
    {
        string todaysExercise = _weeklyExercises[DayOfWeek];

        Assert.AreEqual(todaysExercise, Schedule.GetTodaysExercise());
    }

    [TestMethod]
    public void GetNextExercises_ReturnsProperExercises()
    {
        List<string> nextTwoExercises = Schedule.GetNextExercises(2);
        Assert.AreEqual(2, nextTwoExercises.Count, "Returned wrong number of exercises");
        Assert.AreEqual(_weeklyExercises[DayOfWeek], nextTwoExercises[0], "Wrong first exercise");
        Assert.AreEqual(_weeklyExercises[(DayOfWeek + 1) % 7], nextTwoExercises[1], "Wrong second exercise");
    }
}
