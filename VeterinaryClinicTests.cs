global using NUnit.Framework;
using Zoo.Domain;

namespace ZooERP.Tests
{
    public class VeterinaryClinicTests
    {
        [Test]
        public void CheckHealth_WithHealthyAnimal_ReturnsTrue()
        {
            // Arrange
            var clinic = new VeterinaryClinic();
            var healthyWolf = new Wolf(1, true);

            // Act
            var result = clinic.CheckHealth(healthyWolf);

            // Assert
            Assert.True(result);
        }

        [Test]
        public void CheckHealth_WithUnhealthyAnimal_ReturnsFalse()
        {
            // Arrange
            var clinic = new VeterinaryClinic();
            var sickTiger = new Tiger(2, false);

            // Act
            var result = clinic.CheckHealth(sickTiger);

            // Assert
            Assert.False(result);
        }
    }
}