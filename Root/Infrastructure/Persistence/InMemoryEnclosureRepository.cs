using Root.Domain.Entities;

namespace Root.Infrastructure.Persistence;

public class InMemoryEnclosureRepository
{
    private readonly List<Enclosure> _enclosures = new List<Enclosure>();

    public Enclosure GetById(Guid id) => _enclosures.FirstOrDefault(e => e.Id == id);
    public IEnumerable<Enclosure> GetAll() => _enclosures;

    public void Add(Enclosure enclosure)
    {
        _enclosures.Add(enclosure);
    }

    public void Update(Enclosure enclosure)
    {
        // InMemory: объекты уже в памяти
    }

    public void Delete(Guid id)
    {
        var found = _enclosures.FirstOrDefault(e => e.Id == id);
        if (found != null)
            _enclosures.Remove(found);
    }
}