namespace Zoo.Domain;
/// <summary>
/// Базовый класс для вещей, которые инвентаризируются,
/// но не являются живыми (то есть не реализуют IAlive).
/// </summary>
public abstract class Thing : IInventory
{
    public int Number { get; set; }
    public string Name { get; set; }

    protected Thing(string _name, int _number)
    {
        Name = _name;
        Number = _number;
    }
}