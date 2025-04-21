using System;
using ZooManager.Core.VO;

namespace ZooManager.Core.Events
{
    public class AnimalMovedEvent
    {
        public AnimalId AnimalId { get; }
        public EnclosureId FromEnclosureId { get; }
        public EnclosureId ToEnclosureId { get; }
        public DateTime OccurredAt { get; }

        public AnimalMovedEvent(AnimalId animalId, EnclosureId from, EnclosureId to, DateTime occurredAt)
        {
            AnimalId = animalId;
            FromEnclosureId = from;
            ToEnclosureId = to;
            OccurredAt = occurredAt;
        }
    }
}