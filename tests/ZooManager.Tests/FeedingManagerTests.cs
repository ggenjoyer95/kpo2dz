using System;
using System.Linq;
using Xunit;
using ZooManager.Core.VO;
using ZooManager.Core.Ports;
using ZooManager.Core.Models;
using ZooManager.Persistence.Adapters;
using ZooManager.UseCases.Services;

namespace ZooManager.Tests
{
    public class FeedingManagerTests
    {
        [Fact]
        public void ScheduleAndExecute_Feeding_UpdatesAnimal()
        {
            var animalRepo = new InMemoryAnimalRepository();
            var schedRepo = new InMemoryFeedingScheduleRepository();

            var enc = new Enclosure(new EnclosureId(), EnclosureType.Herbivore, new Size(50), new Capacity(2));
            var animal = new Animal(new AnimalId(), Species.Herbivore, new Name("F"), new BirthDate(DateTime.UtcNow.AddYears(-1)), Gender.Female, FoodType.Plants, HealthStatus.Sick, enc.Id);
            animalRepo.Add(animal);

            var mgr = new FeedingManager(schedRepo, animalRepo);
            mgr.ScheduleFeeding(animal.Id, DateTime.UtcNow, FoodType.Plants);
            mgr.ExecuteFeedingForToday();

            var fromRepo = animalRepo.GetById(animal.Id);
            Assert.Equal(HealthStatus.Healthy, fromRepo.Status);
        }
    }
}
