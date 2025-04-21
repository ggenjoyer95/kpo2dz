using System.Collections.Generic;
using ZooManager.Core.Models;
using ZooManager.Core.VO;

namespace ZooManager.Core.Ports
{
    public interface IAnimalRepository
    {
        Animal GetById(AnimalId id);
        void Add(Animal animal);
        void Remove(AnimalId id);
        IEnumerable<Animal> ListAll();
    }
}