using Root.Domain.Entities;

namespace Root.Domain.Interfaces;

public interface IEnclosureRepository
{
    Enclosure GetById(Guid id);
    IEnumerable<Enclosure> GetAll();
    void Add(Enclosure enclosure);
    void Update(Enclosure enclosure);
    void Delete(Guid id);
}