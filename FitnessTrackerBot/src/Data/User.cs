using FitnessTrackerBot.Data.Schedule;

namespace FitnessTrackerBot.Data;

internal class User
{
    public string Id { get; }
    public ISchedule? Schedule { get; set; }

    public User(string id)
    {
        Id = id;
    }
}