namespace Root.Domain.Events;

// Событие возникает, когда животное переместили из одного вольера в другой
public class AnimalMovedEvent
{
    public Guid AnimalId { get; }
    public Guid OldEnclosureId { get; }
    public Guid NewEnclosureId { get; }

    public DateTime OccurredOn { get; }

    public AnimalMovedEvent(Guid animalId, Guid oldEnclosureId, Guid newEnclosureId)
    {
        AnimalId = animalId;
        OldEnclosureId = oldEnclosureId;
        NewEnclosureId = newEnclosureId;
        OccurredOn = DateTime.Now;
    }
}