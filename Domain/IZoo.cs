using System.Collections.Generic;

namespace Zoo.Domain;
public interface IZoo
{
    void AddAnimal(Animal animal);
    void AddThing(Thing thing);

    IReadOnlyCollection<Animal> Animals { get; }
    IReadOnlyCollection<Thing> Things { get; }

    /// <summary>
    /// Метод, который вычисляет общее количество еды в кг, необходимое всем животным за сутки.
    /// </summary>
    int GetDailyTotalFood();
    
    /// <summary>
    /// Сформировать список животных для контактного зоопарка (Доброта > 5).
    /// </summary>
    /// <returns>Список животных для КЗ</returns>
    IEnumerable<Herbo> GetContactToAnimals();
    
    /// <summary>
    /// Сформировать список животных не подходящих для контактного зоопарка (Доброта > 5).
    /// </summary>
    /// <returns>Список животных не подходящих для КЗ</returns>
    IEnumerable<Herbo> DontGetContactToAnimals();

}