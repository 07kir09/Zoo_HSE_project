using NUnit;
using Zoo.Domain;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using NUnit.Framework;

namespace Zoo.Tests;

public class ZooTests
{
    [Test]
    public void Animal_HealthyAnimal_ShouldBeAddedToCollection()
    {
        // Arrange
        var zoo = CreateZoo();
        var rabbit = new Rabbit(1, true, 7);

        // Act
        zoo.AddAnimal(rabbit);

        // Assert
        Assert.AreEqual(1, zoo.Animals.Count(), "Должен быть один зверь");
        Assert.AreEqual(rabbit, zoo.Animals.First(), "Первый (и единственный) зверь должен быть rabbit");
    }

    [Test]
    public void AddAnimal_UnhealthyAnimal_ShouldNotBeAdded()
    {
        // Arrange
        var zoo = CreateZoo();
        var tiger = new Tiger(number: 2, isHealthy: false);

        // Act
        zoo.AddAnimal(tiger);

        // Assert
        Assert.IsEmpty(zoo.Animals); // Должно быть 0
    }

    [Test]
    public void AddThing_NewThing_ShouldAppearInCollection()
    {
        // Arrange
        var zoo = CreateZoo();
        var table = new Table(10);

        // Act
        zoo.AddThing(table);

        // Assert
        Assert.AreEqual(1, zoo.Things.Count(), "Должна быть одна вещь");
        Assert.AreEqual(table, zoo.Things.First());
    }

    [Test]
    public void GetTotalDailyFood_ShouldSumAllFoodFromAnimals()
    {
        // Arrange
        var zoo = CreateZoo();
        zoo.AddAnimal(new Rabbit(1, true, 7)); // Food = 2
        zoo.AddAnimal(new Monkey(2, true, 8)); // Food = 3
        zoo.AddAnimal(new Tiger(3, true)); // Food = 10

        // Act
        var totalFood = zoo.GetDailyTotalFood();

        // Assert
        Assert.AreEqual(15, totalFood); // 2 + 3 + 10
    }

    [Test]
    public void GetContactZooAnimals_ShouldReturnHerboWithKindnessAbove5()
    {
        // Arrange
        var zoo = CreateZoo();
        // Будут добавлены, т.к. все isHealthy = true
        zoo.AddAnimal(new Rabbit(1, true, 7)); // Kindness=7 -> контактный
        zoo.AddAnimal(new Rabbit(2, true, 2)); // Kindness=2 -> не контактный
        zoo.AddAnimal(new Monkey(3, true, 10)); // Kindness=10 -> контактный
        zoo.AddAnimal(new Tiger(4, true)); // Хищник, не Herbo
        zoo.AddAnimal(new Wolf(5, true)); // Тоже хищник

        // Act
        var contactAnimals = zoo.GetContactToAnimals().ToList();

        // Assert
        Assert.AreEqual(2, contactAnimals.Count); // Должны быть Rabbit(1) и Monkey(3)
        Assert.That(contactAnimals.Any(a => a.Number == 3), Is.True);
        Assert.That(contactAnimals.Any(a => a.Number == 3), Is.True);
    }

    /// <summary>
    /// Создаём экземпляр Zoo с реальной реализацией VeterinaryClinic,
    /// используя DI-контейнер или вручную.
    /// </summary>
    private IZoo CreateZoo()
    {
        // Можно собрать DI-контейнер
        var services = new ServiceCollection();
        services.AddSingleton<IVeterinaryService, VeterinaryClinic>();
        services.AddSingleton<IZoo, Domain.Zoo>();

        var provider = services.BuildServiceProvider();
        return provider.GetRequiredService<IZoo>();
    }
}