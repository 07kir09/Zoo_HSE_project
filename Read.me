Домашнее задание №1. Закрепление принципов SOLID, внедрения
зависимостей средствами DI-контейнера.

ZOO (Зоопарк)
В проекте сделано:

1) Учёт животных (с проверкой здоровья и потребляемого корма)
2) Ведение инвентарных номеров (для животных и вещей)
3) Выделение травоядных с высокой «добротой» (Kindness) для контактного зоопарка

Из чего состоит проект:
1) IAlive: для живых сущностей (поле Food — суточное потребление)
2) IInventory: для инвентаризируемых сущностей (поле Number — инвентарный номер)
3) Animal (базовый класс): одновременно реализует IAlive, IInventory
4) Herbo (травоядные) / Predator (хищники)
5) Rabbit, Monkey (наследуются от Herbo, имеют Kindness), Tiger, Wolf (Predator)
6) Свойства: Name, Number, Food, IsHealthy
7) Thing (базовый класс, реализует IInventory)
8) Table, Computer — примеры вещей
9) IVeterinaryService + VeterinaryClinic: проверяют здоровье животного (CheckHealth)
10) Интерфейс IZoo + реализация Zoo: хранит коллекцию животных/вещей



Как и где я променил принцип SOLID
--S--Single Responsibility-- У каждого класса своя зона ответственности, например, VeterinaryClinic — проверяет здоровье у животных и тд
--O--Open-Closed-- Можно без проблем добавить новых животных, наследуясь от класса Animal, аналогично и с Thing
--L--Liskov Substitution-- Подклассы, те же конкретные виды животных, например Rabbit, Wolf и тд.
--I--Interface Segregation-- Разделенные интерфейсы, такие как живые существа и инвентарь
--D--Dependency Inversion-- Класс Zoo зависит от абстракции IVeterinaryService, а не от конкретной реализации, а также используется DI-контейнер для связывания интерфейсов и реализаций


1) Принцив разделения ответственности: VeterinaryClinic (здоровье), Zoo (коллекции).
2) Использование интерфейсов IAlive, IInventory, IVeterinaryService.
3) Можно при желании легко расширить и добавить новые виды животных и вещи.

Dependency Injection
1) services.AddSingleton<IVeterinaryService, VeterinaryClinic>(), services.AddSingleton<IZoo, Zoo>().
2) Гибкая замена реализации, удобство тестирования.


Инструкция по запуску проекта:
Склонируйте репозиторий или скачайте файлы
Откройте проект в любой IDE (я делал в Rider) можно еще в Visual Studio или VS Code
Убедитесь, что установлен пакет Microsoft.Extensions.DependencyInjection.
Запускать проект в Program.cs

При необходимости нужно ввести в терминал эту строчку, чтобы установить пакет:   dotnet add package Microsoft.Extensions.DependencyInjection
На всякий случай подключить зависимости между тестами и основным проектом

