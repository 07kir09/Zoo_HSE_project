namespace Zoo.Domain;
/// <summary>
/// Интерфейс для сервиса ветеринарного осмотра.
/// </summary>
public interface IVeterinaryService
{
    /// <summary>
    /// Метод, который возвращает решение о приёме животного (здоров/не здоров) в зоопарк от ветклиники.
    /// </summary>
    /// <param name="animal">животное</param>
    /// <returns></returns>
    bool CheckHealth(Animal animal);
}