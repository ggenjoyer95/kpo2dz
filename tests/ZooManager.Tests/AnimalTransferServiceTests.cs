using System;
using Xunit;
using ZooManager.Core.Models;
using ZooManager.Core.VO;
using ZooManager.Core.Ports;
using ZooManager.Persistence.Adapters;
using ZooManager.UseCases.Services;
using ZooManager.UseCases.Contracts;

namespace ZooManager.Tests
{
    public class AnimalTransferServiceTests
    {
        [Fact]
        public void Transfer_Animal_MovesEnclosureId()
        {
            var animalRepo = new InMemoryAnimalRepository();
            var encRepo = new InMemoryEnclosureRepository();

            var enc1 = new Enclosure(new EnclosureId(), EnclosureType.Herbivore, new Size(100), new Capacity(2));
            var enc2 = new Enclosure(new EnclosureId(), EnclosureType.Herbivore, new Size(100), new Capacity(2));
            encRepo.Add(enc1);
            encRepo.Add(enc2);

            var animal = new Animal(new AnimalId(), Species.Herbivore, new Name("T"), new BirthDate(DateTime.UtcNow.AddYears(-1)), Gender.Male, FoodType.Plants, HealthStatus.Healthy, enc1.Id);
            animalRepo.Add(animal);

            IAnimalTransferService svc = new AnimalTransferService(animalRepo, encRepo);
            svc.Transfer(animal.Id, enc2.Id);

            var moved = animalRepo.GetById(animal.Id);
            Assert.Equal(enc2.Id, moved.CurrentEnclosureId);
        }
    }
}
