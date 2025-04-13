using System.Text.Json.Serialization;

namespace FitnessTrackerBot.Data.Schedule;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
[JsonDerivedType(typeof(DailyScheduleData), typeDiscriminator: "daily")]
[JsonDerivedType(typeof(WeeklyScheduleData), typeDiscriminator: "weekly")]
public abstract class ScheduleData
{
    public abstract ISchedule ToSchedule();
}