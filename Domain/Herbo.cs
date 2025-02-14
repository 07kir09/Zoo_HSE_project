namespace Zoo.Domain;
/// <summary>
/// Класс Травоядное животное.
/// Имеет дополнительный параметр "доброта" (Kindness).
/// Если Доброта > 5, то подходит для контактного зоопарка.
/// </summary>
public abstract class Herbo : Animal
{
    public int Kindness { get; set; }

    protected Herbo(int _kindness, string _name, bool _isHealthy, int _food, int _number) : base(_name, _isHealthy,
        _food, _number)
    {
        Kindness = _kindness;
    }

}