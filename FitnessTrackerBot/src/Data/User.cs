using FitnessTrackerBot.Data.Schedule;

namespace FitnessTrackerBot.Data;

public class User
{
    public string Id { get; }
    public ScheduleData? Schedule { get; set; }

    public User(string id)
    {
        Id = id;
    }
}