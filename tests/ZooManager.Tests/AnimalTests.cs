using System;
using Xunit;
using ZooManager.Core.Models;
using ZooManager.Core.VO;
using ZooManager.Core.Events;

namespace ZooManager.Tests
{
    public class AnimalTests
    {
        [Fact]
        public void CreatingAnimal_SetsPropertiesCorrectly()
        {
            var id = new AnimalId();
            var name = new Name("First");
            var species = Species.Carnivore;
            var gender = Gender.Male;
            var birth = new BirthDate(DateTime.UtcNow.AddYears(-2));
            var food = FoodType.Meat;
            var status = HealthStatus.Healthy;
            var enclosure = new EnclosureId();

            var animal = new Animal(id, species, name, birth, gender, food, status, enclosure);

            Assert.Equal(id, animal.Id);
            Assert.Equal(species, animal.Species);
            Assert.Equal("First", animal.Name.Value);
            Assert.Equal(gender, animal.Gender);
            Assert.Equal(food, animal.FavoriteFood);
            Assert.Equal(status, animal.Status);
            Assert.Equal(enclosure, animal.CurrentEnclosureId);
        }

        [Fact]
        public void Feeding_WithWrongFood_Throws()
        {
            var animal = new Animal(
                new AnimalId(),
                Species.Herbivore,
                new Name("Second"),
                new BirthDate(DateTime.UtcNow.AddYears(-1)),
                Gender.Female,
                FoodType.Plants,
                HealthStatus.Healthy,
                new EnclosureId());

            Assert.Throws<InvalidOperationException>(() =>
                animal.Feed(FoodType.Meat));
        }
    }
}
