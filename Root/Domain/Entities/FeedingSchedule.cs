namespace Root.Domain.Entities;

public class FeedingSchedule
{
    public Guid Id { get; private set; }
    
    public Guid AnimalId { get; private set; }
    public DateTime FeedingTime { get; private set; }
    public string FoodType { get; private set; }
    
    public bool IsDone { get; private set; }

    public FeedingSchedule(Guid animalId, DateTime feedingTime, string foodType)
    {
        Id = Guid.NewGuid();
        AnimalId = animalId;
        FeedingTime = feedingTime;
        FoodType = foodType;
        IsDone = false;
    }
    
    public void ChangeSchedule(DateTime newTime)
    {
        FeedingTime = newTime;
    }

    public void MarkAsDone()
    {
        IsDone = true;
    }
}