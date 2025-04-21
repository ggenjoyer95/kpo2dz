using System.Collections.Generic;
using ZooManager.Core.Models;
using ZooManager.Core.Ports;
using ZooManager.Core.VO;

namespace ZooManager.Persistence.Adapters
{
    public class InMemoryAnimalRepository : IAnimalRepository
    {
        private readonly Dictionary<AnimalId, Animal> _store = new();
        public Animal GetById(AnimalId id) => _store[id];
        public void Add(Animal animal) => _store[animal.Id] = animal;
        public void Remove(AnimalId id) => _store.Remove(id);
        public IEnumerable<Animal> ListAll() => _store.Values;
    }
}
