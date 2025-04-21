using Xunit;
using ZooManager.Core.VO;
using ZooManager.Persistence.Adapters;
using ZooManager.Core.Models;
using ZooManager.UseCases.Services;
using ZooManager.UseCases.Contracts;
using ZooManager.UseCases.DTOs;

namespace ZooManager.Tests
{
    public class ZooStatisticsProviderTests
    {
        [Fact]
        public void GetStatistics_ReturnsCorrectCounts()
        {
            var animalRepo = new InMemoryAnimalRepository();
            var encRepo = new InMemoryEnclosureRepository();

            var e1 = new Enclosure(new EnclosureId(), EnclosureType.Herbivore, new Size(50), new Capacity(3));
            var e2 = new Enclosure(new EnclosureId(), EnclosureType.Carnivore, new Size(80), new Capacity(2));
            encRepo.Add(e1);
            encRepo.Add(e2);

            animalRepo.Add(new Animal(new AnimalId(), Species.Herbivore, new Name("A1"), new BirthDate(DateTime.UtcNow.AddYears(-2)), Gender.Male, FoodType.Plants, HealthStatus.Healthy, e1.Id));
            animalRepo.Add(new Animal(new AnimalId(), Species.Carnivore, new Name("A2"), new BirthDate(DateTime.UtcNow.AddYears(-3)), Gender.Female, FoodType.Meat, HealthStatus.Healthy, e2.Id));

            IZooStatisticsProvider stats = new ZooStatisticsProvider(animalRepo, encRepo);
            var dto = stats.GetStatistics();

            Assert.Equal(2, dto.TotalAnimals);
            Assert.Equal(2, dto.TotalEnclosures);
            Assert.Equal((3-1)+(2-1), dto.FreeSpaces);
        }
    }
}
