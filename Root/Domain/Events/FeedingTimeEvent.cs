namespace Root.Domain.Events;

public class FeedingTimeEvent
{
    public Guid FeedingScheduleId { get; }
    public DateTime ScheduledTime { get; }
    public DateTime OccurredOn { get; }

    public FeedingTimeEvent(Guid scheduleId, DateTime scheduledTime)
    {
        FeedingScheduleId = scheduleId;
        ScheduledTime = scheduledTime;
        OccurredOn = DateTime.Now;
    }
}