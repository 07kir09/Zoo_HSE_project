namespace Zoo.Domain;
/// <summary>
/// Класс Хищник
/// </summary>
public abstract class Predator : Animal
{

    protected Predator(string _name, bool _isHealthy, int _food, int _number) : base(_name, _isHealthy,
        _food, _number)
    {
    }
    
}