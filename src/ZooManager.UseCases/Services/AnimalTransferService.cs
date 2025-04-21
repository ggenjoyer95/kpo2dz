using ZooManager.Core.Ports;
using ZooManager.Core.Models;
using ZooManager.Core.VO;
using ZooManager.UseCases.Contracts;

namespace ZooManager.UseCases.Services
{
    public class AnimalTransferService : IAnimalTransferService
    {
        private readonly IAnimalRepository _animalRepo;
        private readonly IEnclosureRepository _enclosureRepo;

        public AnimalTransferService(
            IAnimalRepository animalRepo,
            IEnclosureRepository enclosureRepo)
        {
            _animalRepo = animalRepo;
            _enclosureRepo = enclosureRepo;
        }

        public void Transfer(AnimalId animalId, EnclosureId toEnclosureId)
        {
            var animal = _animalRepo.GetById(animalId);
            var target = _enclosureRepo.GetById(toEnclosureId);
            animal.MoveTo(target);
            _animalRepo.Add(animal);
        }
    }
}
