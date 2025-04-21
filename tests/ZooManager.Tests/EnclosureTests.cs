using System;
using Xunit;
using ZooManager.Core.Models;
using ZooManager.Core.VO;

namespace ZooManager.Tests
{
    public class EnclosureTests
    {
        [Fact]
        public void Add_Remove_Animal_ChangesCount()
        {
            var enc = new Enclosure(
                new EnclosureId(),
                EnclosureType.Herbivore,
                new Size(100),
                new Capacity(2));

            var a1 = new Animal(
                new AnimalId(), Species.Herbivore,
                new Name("A"), new BirthDate(DateTime.UtcNow.AddMonths(-6)),
                Gender.Male, FoodType.Plants, HealthStatus.Healthy,
                enc.Id);

            enc.AddAnimal(a1);
            Assert.Equal(1, enc.CurrentAnimalCount);

            enc.RemoveAnimal(a1);
            Assert.Equal(0, enc.CurrentAnimalCount);
        }

        [Fact]
        public void Add_WhenFull_Throws()
        {
            var enc = new Enclosure(
                new EnclosureId(), EnclosureType.Carnivore,
                new Size(50), new Capacity(1));

            var animal = new Animal(
                new AnimalId(), Species.Carnivore,
                new Name("B"), new BirthDate(DateTime.UtcNow.AddMonths(-3)),
                Gender.Male, FoodType.Meat, HealthStatus.Healthy,
                enc.Id);

            enc.AddAnimal(animal);
            Assert.Throws<InvalidOperationException>(() =>
                enc.AddAnimal(animal));
        }
    }
}
