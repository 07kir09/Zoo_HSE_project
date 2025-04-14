using Root.Domain.Entities;

namespace Root.Infrastructure.Persistence;

public class InMemoryAnimalRepository
{
    private readonly List<Animal> _animals = new List<Animal>();

    public Animal GetById(Guid id) => _animals.FirstOrDefault(a => a.Id == id);

    public IEnumerable<Animal> GetAll() => _animals;

    public void Add(Animal animal)
    {
        _animals.Add(animal);
    }

    public void Update(Animal animal)
    {
        // Для InMemory: фактически делать ничего не нужно, объекты в памяти уже обновлены
    }

    public void Delete(Guid id)
    {
        var found = _animals.FirstOrDefault(a => a.Id == id);
        if (found != null)
            _animals.Remove(found);
    }
}