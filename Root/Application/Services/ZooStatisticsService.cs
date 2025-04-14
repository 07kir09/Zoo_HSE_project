using Root.Domain.Interfaces;

namespace Root.Application.Services;

public class ZooStatisticsService
{
    private readonly IAnimalRepository _animalRepo;
    private readonly IEnclosureRepository _enclosureRepo;

    public ZooStatisticsService(IAnimalRepository animalRepo, IEnclosureRepository enclosureRepo)
    {
        _animalRepo = animalRepo;
        _enclosureRepo = enclosureRepo;
    }

    public int GetTotalAnimalsCount()
    {
        return _animalRepo.GetAll().Count();
    }

    public int GetTotalEnclosuresCount()
    {
        return _enclosureRepo.GetAll().Count();
    }

    public int GetFreeEnclosuresCount()
    {
        return _enclosureRepo.GetAll().Count(e => e.CurrentCount == 0);
    }

    // Можно добавить более развернутую статистику при необходимости
}