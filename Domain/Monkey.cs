namespace Zoo.Domain;
/// <summary>
/// Класс Мартышка.
/// </summary>
public class Monkey : Herbo
{
    public Monkey(int _number, bool _isHealthy, int _kindness) : base(_kindness, "Абизяна", _isHealthy, 3, _number)
    {
    }
}