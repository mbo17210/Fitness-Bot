using DSharpPlus.Net;
using FitnessTrackerBot.Data.Schedule;

namespace FitnessTrackerBotTests;

[TestClass]
public class DailyScheduleTests
{
    private static readonly List<string> Exercises = ["Rest", "Push", "Pull", "Legs", "Arms"];
    private static readonly ScheduleData ScheduleData = new DailyScheduleData(Exercises);
    private static readonly ISchedule Schedule = ScheduleData.ToSchedule();
    
    [TestMethod]
    public void GetTodaysExercise_ReturnsProperExercise()
    {
        string today = Schedule.GetTodaysExercise();
        Assert.AreEqual("Rest", today);
    }

    [TestMethod]
    public void GetNextExercises_ReturnsProperExercises()
    {
        List<string> nextExercises = Schedule.GetNextExercises(6);
        Assert.AreEqual(6, nextExercises.Count);
        Assert.AreEqual("Rest", nextExercises[0]);
        Assert.AreEqual("Push", nextExercises[1]);
        Assert.AreEqual("Pull", nextExercises[2]);
        Assert.AreEqual("Legs", nextExercises[3]);
        Assert.AreEqual("Arms", nextExercises[4]);
        Assert.AreEqual("Rest", nextExercises[5]);
    }
}