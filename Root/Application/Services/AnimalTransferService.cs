using Root.Domain.Events;
using Root.Domain.Interfaces;
using Root.Infrastructure.Persistence;

namespace Root.Application.Services;

public class AnimalTransferService
{
    private readonly IAnimalRepository _animalRepo;
    private readonly IEnclosureRepository _enclosureRepo;
    
    public AnimalTransferService(IAnimalRepository animalRepo, IEnclosureRepository enclosureRepo)
    {
        _animalRepo = animalRepo;
        _enclosureRepo = enclosureRepo;
    }
    
    public void TransferAnimal(Guid animalId, Guid newEnclosureId)
    {
        var animal = _animalRepo.GetById(animalId);
        if (animal == null) throw new Exception("Животное не найдено!");

        var oldEnclosureId = animal.EnclosureId;
        if (oldEnclosureId == newEnclosureId) 
            return;

        // Удаляем из старого вольера
        if (oldEnclosureId != Guid.Empty)
        {
            var oldEnclosure = _enclosureRepo.GetById(oldEnclosureId);
            oldEnclosure?.RemoveAnimal(animalId);
            _enclosureRepo.Update(oldEnclosure);
        }

        // Добавляем в новый вольер
        var newEnclosure = _enclosureRepo.GetById(newEnclosureId);
        if (newEnclosure == null) throw new Exception("Целевой вольер не найден!");
        newEnclosure.AddAnimal(animalId);
        _enclosureRepo.Update(newEnclosure);

        // Обновляем ссылку на вольер в самом животном
        animal.MoveToEnclosure(newEnclosureId);
        _animalRepo.Update(animal);

        // Публикуем событие (упрощённо)
        var @event = new AnimalMovedEvent(animalId, oldEnclosureId, newEnclosureId);
        // EventDispatcher.Publish(@event);

        Console.WriteLine($"[AnimalTransferService] Животное {animal.Name} перемещено из вольера {oldEnclosureId} в {newEnclosureId}.");
    }
}