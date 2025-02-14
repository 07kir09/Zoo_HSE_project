using Microsoft.Extensions.DependencyInjection;
using Zoo.Domain;
using System;
using System.Linq;

namespace Zoo
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = SetupServices();
            var zoo = serviceProvider.GetRequiredService<IZoo>();
            
            AddSampleAnimals(zoo);
            AddSampleThings(zoo);
            
            PrintZooReport(zoo);
            PrintInformationAboutKindnessContactAnimals(zoo);
            PrintInformationAboutAngryAnimals(zoo);
            PrintInventoryReport(zoo);
            
            Console.WriteLine();
            Console.WriteLine("!!!!!Нажмите любую клавишу для выхода!!!!!");
            Console.ReadKey();
        }

        /// <summary>
        /// Метод, который настраивает DI-контейнер, регистрирует сервисы и возвращает ServiceProvider.
        /// </summary>
        private static ServiceProvider SetupServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IVeterinaryService, VeterinaryClinic>();
            services.AddSingleton<IZoo, Domain.Zoo>();
            
            return services.BuildServiceProvider();
        }

        /// <summary>
        /// Метод, который добавляет животных в зоопарк.
        /// </summary>
        private static void AddSampleAnimals(IZoo zoo)
        {
            Console.WriteLine();
            zoo.AddAnimal(new Rabbit(1, true, _kindness: 7));
            zoo.AddAnimal(new Rabbit(9, true, _kindness: 13));
            zoo.AddAnimal(new Rabbit(9, false, _kindness: 10));
            zoo.AddAnimal(new Rabbit(9, false, _kindness: 3));
            zoo.AddAnimal(new Rabbit(9, true, _kindness: 3));
            zoo.AddAnimal(new Rabbit(9, true, _kindness: 10));
            zoo.AddAnimal(new Wolf(2, true));
            zoo.AddAnimal(new Wolf(12, false));
            zoo.AddAnimal(new Tiger(13, false));
            zoo.AddAnimal(new Tiger(5, true));
            zoo.AddAnimal(new Monkey(7, true, _kindness: 27));
            zoo.AddAnimal(new Monkey(8, true, _kindness: 8));
            zoo.AddAnimal(new Monkey(8, false, _kindness: 5));
            zoo.AddAnimal(new Monkey(8, false, _kindness: 12));
            zoo.AddAnimal(new Monkey(8, true, _kindness: 12));
            zoo.AddAnimal(new Monkey(8, true, _kindness: 5));
        }

        /// <summary>
        /// Метод, который добавляет вещи в инвентарь зоопарка.
        /// </summary>
        private static void AddSampleThings(IZoo zoo)
        {
            Console.WriteLine();
            zoo.AddThing(new Table(11));
            zoo.AddThing(new Computer(13));
            zoo.AddThing(new Computer(12));
            zoo.AddThing(new Table(10));
        }

        /// <summary>
        /// Метод, который выводит информацию о животных, живущих в зоопарке и о количестве еды.
        /// </summary>
        private static void PrintZooReport(IZoo zoo)
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("----------------Мини отчет по животным, живущих в зоопарке----------------");
            Console.WriteLine($"Всего животных в зоопарке на балансе: {zoo.Animals.Count()}");
            Console.WriteLine($"Общее количество потребляемой еды в сутках: {zoo.GetDailyTotalFood()} кг.");
        }

        /// <summary>
        /// Метод, который выводит информацию о животных, которые  прошли проверку на дорброту.
        /// </summary>
        private static void PrintInformationAboutKindnessContactAnimals(IZoo zoo)
        {
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("---Контактный зоопарк (приём осуществляется с коффициентом доброты > 5) ---");
            
            var contactAnimals = zoo.GetContactToAnimals();
            foreach (var animal in contactAnimals)
            {
                Console.WriteLine($"Животное - {animal.Name} (№{animal.Number}) принято в контактный зоопарк с коффициентом доброты: {animal.Kindness}, здоров: {animal.IsHealthy}");
            }
        }

        /// <summary>
        /// Метод, который выводит информацию о животных, которые не прошли проверку на дорброту.
        /// </summary>
        private static void PrintInformationAboutAngryAnimals(IZoo zoo)
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("--- Животные, не прошедшие проверку в контактный зоопарк (Доброта ≤ 5) ---");
            
            var dontContactAnimals = zoo.DontGetContactToAnimals();
            foreach (var animal in dontContactAnimals)
            {
                Console.WriteLine($"Животное - {animal.Name} (№{animal.Number}) не принято с коффициентом доброты: {animal.Kindness}, здоров: {animal.IsHealthy}. Слишком буйное!");
            }
        }

        /// <summary>
        /// Метод, который выводит в консоль учет всех обьектов в зоопарке.
        /// </summary>
        private static void PrintInventoryReport(IZoo zoo)
        {
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("---Учет всех сущностей на балансе зоопарка (включая животных)---");

            var inventoryItems = zoo.Animals.Cast<IInventory>().Concat(zoo.Things);
            foreach (var item in inventoryItems)
            {
                Console.WriteLine($"- {GetDisplayName(item)} (№{item.Number})");
            }
        }

        /// <summary>
        /// Определяет, как вывести имя сущности (животное / вещь).
        /// </summary>
        private static string GetDisplayName(IInventory inventoryItem)
        {
            return inventoryItem switch
            {
                Animal animal => animal.Name,
                Thing thing   => thing.Name,
                _             => "Неизвестно"
            };
        }
    }
}
 