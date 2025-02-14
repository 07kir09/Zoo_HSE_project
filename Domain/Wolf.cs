namespace Zoo.Domain;
/// <summary>
/// Класс
/// </summary>
public class Wolf :  Predator
{
    public Wolf(int number, bool isHealthy) : base("Вольк", isHealthy, 8, number)
    {
    }
}
