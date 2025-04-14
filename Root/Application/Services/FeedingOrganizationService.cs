using Root.Domain.Entities;
using Root.Domain.Events;
using Root.Domain.Interfaces;

namespace Root.Application.Services;

public class FeedingOrganizationService
{
    private readonly IFeedingScheduleRepository _scheduleRepo;
    private readonly IAnimalRepository _animalRepo;

    public FeedingOrganizationService(IFeedingScheduleRepository scheduleRepo, IAnimalRepository animalRepo)
    {
        _scheduleRepo = scheduleRepo;
        _animalRepo = animalRepo;
    }

    // Создать новое расписание кормления
    public FeedingSchedule CreateFeedingSchedule(Guid animalId, DateTime feedingTime, string foodType)
    {
        var schedule = new FeedingSchedule(animalId, feedingTime, foodType);
        _scheduleRepo.Add(schedule);
        return schedule;
    }

    // Отметить, что время кормления наступило
    // (Можно, например, перевести логику на фоновый процесс, который проверяет, не наступило ли время schedule.FeedingTime)
    public void HandleFeedingTime(Guid scheduleId)
    {
        var schedule = _scheduleRepo.GetById(scheduleId);
        if (schedule == null) throw new Exception("Расписание не найдено!");

        // Публикуем событие
        var feedingEvent = new FeedingTimeEvent(schedule.Id, schedule.FeedingTime);
        // EventDispatcher.Publish(feedingEvent);

        // Находим животное и кормим
        var animal = _animalRepo.GetById(schedule.AnimalId);
        if (animal != null)
        {
            animal.Feed();
            // Логика "накормить" — у нас в сущности Animal есть метод Feed()
        }

        // Отмечаем, что кормление выполнено
        schedule.MarkAsDone();
        _scheduleRepo.Update(schedule);
    }
}