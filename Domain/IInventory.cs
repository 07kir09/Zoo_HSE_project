namespace Zoo.Domain;
/// <summary>
/// Интерфейс, который определяет принадлежность наших типов к категории «инвентаризационная вещь».
/// </summary>
public interface IInventory
{
    int Number { get; set; }
}