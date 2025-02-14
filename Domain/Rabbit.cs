namespace Zoo.Domain;
/// <summary>
/// Класс Кролик
/// </summary>
public class Rabbit : Herbo
{
    public Rabbit(int _number, bool _isHealthy, int _kindness) : base(_kindness, "Кролик", _isHealthy, 2, _number)
    {
    }
}