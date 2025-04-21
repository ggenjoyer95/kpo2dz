using System.Linq;
using ZooManager.Core.Ports;
using ZooManager.UseCases.Contracts;
using ZooManager.UseCases.DTOs;

namespace ZooManager.UseCases.Services
{
    public class ZooStatisticsProvider : IZooStatisticsProvider
    {
        private readonly IAnimalRepository _animalRepo;
        private readonly IEnclosureRepository _enclosureRepo;

        public ZooStatisticsProvider(
            IAnimalRepository animalRepo,
            IEnclosureRepository enclosureRepo)
        {
            _animalRepo = animalRepo;
            _enclosureRepo = enclosureRepo;
        }

        public ZooStatsDto GetStatistics()
        {
            var allAnimals = _animalRepo.ListAll().ToList();
            var totalAnimals = allAnimals.Count;
            var enclosures = _enclosureRepo.ListAll().ToList();
            var free = enclosures.Sum(e =>
                e.Capacity.Value
                - allAnimals.Count(a => a.CurrentEnclosureId == e.Id));
            return new ZooStatsDto
            {
                TotalAnimals = totalAnimals,
                TotalEnclosures = enclosures.Count,
                FreeSpaces = free
            };
        }
    }
}
