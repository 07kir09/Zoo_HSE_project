namespace Zoo.Domain;
/// <summary>
/// Ветеринарная клиника, проверяющая здоровье животного.
/// </summary>
public class VeterinaryClinic : IVeterinaryService
{
    public bool CheckHealth(Animal animal)
    {
        return animal.IsHealthy;
    }
}