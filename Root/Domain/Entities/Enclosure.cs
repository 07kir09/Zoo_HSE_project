namespace Root.Domain.Entities;

public class Enclosure
{
    public Guid Id {  get; private set; }
    
    public string Type {  get; private set; }
    public double Size {  get; private set; }
    public int CurrentCount {  get; private set; }
    public int MaxCapacity {  get; private set; }
    
    private readonly List<Guid> _animalIds = new List<Guid>();
    public IReadOnlyCollection<Guid> AnimalIds => _animalIds.AsReadOnly();

    public Enclosure(string type, double size, int currentCount, int maxCapacity)
    {
        Id = Guid.NewGuid();
        Type = type;
        Size = size;
        CurrentCount = currentCount;
        MaxCapacity = maxCapacity;
    }

    public void AddAnimal(Guid animalId)
    {
        if (_animalIds.Count >= MaxCapacity)
            throw new InvalidOperationException("Вольер переполнен!");

        _animalIds.Add(animalId);
        CurrentCount = _animalIds.Count;
    }

    public void RemoveAnimal(Guid animalId)
    {
        _animalIds.Remove(animalId);
        CurrentCount = _animalIds.Count;
    }
    
    public void CleanUp()
    {
        Console.WriteLine($"Вольер {Type} (ID = {Id}) был убран.");
    }
}