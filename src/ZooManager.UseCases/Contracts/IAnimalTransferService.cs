using ZooManager.Core.VO;

namespace ZooManager.UseCases.Contracts
{
    public interface IAnimalTransferService
    {
        void Transfer(AnimalId animalId, EnclosureId toEnclosureId);
    }
}
