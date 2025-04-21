using System;
using ZooManager.Core.VO;

namespace ZooManager.Core.Events
{
    public class EnclosureCleanedEvent
    {
        public EnclosureId EnclosureId { get; }
        public DateTime CleanedAt { get; }

        public EnclosureCleanedEvent(EnclosureId enclosureId, DateTime cleanedAt)
        {
            EnclosureId = enclosureId;
            CleanedAt = cleanedAt;
        }
    }
}
