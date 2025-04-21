using System.Collections.Generic;
using ZooManager.Core.Models;
using ZooManager.Core.VO;

namespace ZooManager.Core.Ports
{
    public interface IEnclosureRepository
    {
        Enclosure GetById(EnclosureId id);
        void Add(Enclosure enclosure);
        void Remove(EnclosureId id);
        IEnumerable<Enclosure> ListAll();
    }
}