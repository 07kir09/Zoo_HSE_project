using System.Linq;
using System.Collections.Generic;

namespace Zoo.Domain;
/// <summary>
/// Класс, описывающий зоопарк. 
/// Имеет ассоциацию с ветеринарной клиникой, которая проверяет новых животных.
/// </summary>
public class Zoo : IZoo
{
    private readonly IVeterinaryService _vetService;
    private readonly List<Animal> _animals = new List<Animal>();
    private readonly List<Thing> _things = new List<Thing>();


    public Zoo(IVeterinaryService vetService)
    {
        _vetService = vetService;
    }

    public IReadOnlyCollection<Animal> Animals => _animals.AsReadOnly();
    public IReadOnlyCollection<Thing> Things => _things.AsReadOnly();

    public void AddAnimal(Animal animal)
    {
        if (_vetService.CheckHealth(animal))
        {
            _animals.Add(animal);
            Console.WriteLine($"Животное {animal.Name} с номером №:{animal.Number} успешно прошло проверку у ветиринара и принято в зоопарк!");
        }
        else
        {
            Console.WriteLine($"Животное {animal.Name} с номером №:{animal.Number} не прошло проверку у ветиринара. УВЫ. Лечитесь!");
        }
    }

    public void AddThing(Thing thing)
    {
        _things.Add(thing);
        Console.WriteLine($"Вещь {thing.Name} с номером №:{thing.Number} добавлена в оборудование зоопарка. Приятного пользования.");
    }

    public int GetDailyTotalFood()
    {
        return _animals.Sum(anim => anim.Food);
    }

    public IEnumerable<Herbo> GetContactToAnimals()
    {
        return _animals.OfType<Herbo>().Where(h => h.Kindness > 5);
    }
    
    public IEnumerable<Herbo> DontGetContactToAnimals()
    {
        return _animals.OfType<Herbo>().Where(h => h.Kindness <= 5);
    }
}