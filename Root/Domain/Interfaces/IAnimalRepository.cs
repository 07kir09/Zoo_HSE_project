using Root.Domain.Entities;

namespace Root.Domain.Interfaces;

public interface IAnimalRepository
{
    Animal GetById(Guid id);
    IEnumerable<Animal> GetAll();
    void Add(Animal animal);
    void Update(Animal animal);
    void Delete(Guid id);
    
}