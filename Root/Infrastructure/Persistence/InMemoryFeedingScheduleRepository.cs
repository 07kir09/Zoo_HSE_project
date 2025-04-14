using Root.Domain.Entities;

namespace Root.Infrastructure.Persistence;

public class InMemoryFeedingScheduleRepository
{
    private readonly List<FeedingSchedule> _schedules = new List<FeedingSchedule>();

    public FeedingSchedule GetById(Guid id) => _schedules.FirstOrDefault(s => s.Id == id);
    public IEnumerable<FeedingSchedule> GetAll() => _schedules;

    public void Add(FeedingSchedule schedule)
    {
        _schedules.Add(schedule);
    }

    public void Update(FeedingSchedule schedule)
    {
        // InMemory: уже обновлено
    }

    public void Delete(Guid id)
    {
        var found = _schedules.FirstOrDefault(s => s.Id == id);
        if (found != null)
            _schedules.Remove(found);
    }
}