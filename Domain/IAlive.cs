namespace Zoo.Domain;
/// <summary>
/// Интерфейс, который определяет принадлежность наших типов к категории «живых».
/// </summary>
public interface IAlive
{
    int Food { get; set; }
}