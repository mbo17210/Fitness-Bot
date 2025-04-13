using System.Text.Json.Serialization;

namespace FitnessTrackerBot.Data.Schedule;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
[JsonDerivedType(typeof(DailyScheduleData), typeDiscriminator: "daily")]
public abstract class ScheduleData
{
    public abstract ISchedule ToSchedule();
}