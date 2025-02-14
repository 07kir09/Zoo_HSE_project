namespace Zoo.Domain;
/// <summary>
/// Класс для всех Животных
/// Является "живым" (IAlive) и "инвентаризируемым" (IInventory).
/// </summary>
public abstract class Animal : IAlive, IInventory
{
    public int Food { get; set; }
    public int Number { get; set; }

    public string Name { get; set; }
    public bool IsHealthy { get; set; }

    protected Animal(string _name, bool _isHealthy, int _food, int _number)
    {
        Name = _name;
        IsHealthy = _isHealthy;
        Number = _number;
        Food = _food;
    }
}