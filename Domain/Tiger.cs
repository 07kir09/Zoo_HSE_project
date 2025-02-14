namespace Zoo.Domain;
/// <summary>
/// Класс Тигр.
/// </summary>
public class Tiger :  Predator
{
    public Tiger(int number, bool isHealthy) : base("Тигренок", isHealthy, 10, number)
    {
    }
}
