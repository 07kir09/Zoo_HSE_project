using System.Runtime.CompilerServices;

namespace Root.Domain.Entities;

public class Animal
{
    public Guid Id {  get; private set; }
    
    public string Species {  get; private set; }
    public string Name {  get; private set; }
    public DateTime DateOfBirt {  get; private set; }
    public string Sex {  get; private set; }
    public string FavoriteFood {  get; private set; }
    public bool IsHealthy { get; private set; }
    
    public Guid EnclosureId { get; private set; }

    public Animal(string species, string name, DateTime dateOfBirt, string sex, string favoriteFood, bool isHealthy)
    {
        Id = Guid.NewGuid();
        Species = species;
        Name = name;
        DateOfBirt = dateOfBirt;
        Sex = sex;
        FavoriteFood = favoriteFood;
        IsHealthy = isHealthy;
    }
    
    public void Feed()
    {
        // НУЖНО РЕАЛИЗОВАТЬ
        // Логика кормления
        // например, проверить любимую еду, уменьшить голод и т.п.
        Console.WriteLine($"[{Name}] накормлен(а) любимой едой: {FavoriteFood}.");
    }
    
    public void Treat()
    {
        // НУЖНО РЕАЛИЗОВАТЬ
        // Логика лечения
        IsHealthy = true; 
        Console.WriteLine($"[{Name}] успешно вылечен(а).");
    }
    
    public void MoveToEnclosure(Guid newEnclosureId)
    {
        // Проверка: не совпадает ли с текущим вольером
        if (newEnclosureId == EnclosureId)
            return;

        // Можно добавить бизнес-правила (например, проверка совместимости вида и типа вольера)
        EnclosureId = newEnclosureId;
    }
}