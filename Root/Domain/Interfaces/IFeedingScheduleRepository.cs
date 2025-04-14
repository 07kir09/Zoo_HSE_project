using Root.Domain.Entities;

namespace Root.Domain.Interfaces;

public interface IFeedingScheduleRepository
{
    FeedingSchedule GetById(Guid id);
    IEnumerable<FeedingSchedule> GetAll();
    void Add(FeedingSchedule schedule);
    void Update(FeedingSchedule schedule);
    void Delete(Guid id);
}