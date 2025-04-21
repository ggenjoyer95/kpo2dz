using System.Collections.Generic;
using ZooManager.Core.Models;
using ZooManager.Core.Ports;
using ZooManager.Core.VO;

namespace ZooManager.Persistence.Adapters
{
    public class InMemoryEnclosureRepository : IEnclosureRepository
    {
        private readonly Dictionary<EnclosureId, Enclosure> _store = new();
        public Enclosure GetById(EnclosureId id) => _store[id];
        public void Add(Enclosure enclosure) => _store[enclosure.Id] = enclosure;
        public void Remove(EnclosureId id) => _store.Remove(id);
        public IEnumerable<Enclosure> ListAll() => _store.Values;
    }
}
