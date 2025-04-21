using System;
using ZooManager.Core.VO;
using ZooManager.Core.Events;

namespace ZooManager.Core.Models
{
    public class Enclosure
    {
        public EnclosureId Id { get; }
        public EnclosureType Type { get; }
        public Size Size { get; }
        public int CurrentAnimalCount { get; private set; }
        public Capacity Capacity { get; }

        public Enclosure(
            EnclosureId id,
            EnclosureType type,
            Size size,
            Capacity capacity)
        {
            Id = id;
            Type = type;
            Size = size;
            Capacity = capacity;
            CurrentAnimalCount = 0;
        }

        public void AddAnimal(Animal animal)
        {
            if (CurrentAnimalCount >= Capacity.Value)
            {
                throw new InvalidOperationException("Вольер заполнен.");
            }
            CurrentAnimalCount++;
        }

        public void RemoveAnimal(Animal animal)
        {
            if (CurrentAnimalCount <= 0)
            {
                throw new InvalidOperationException("В вольере нет животных.");
            }
            CurrentAnimalCount--;
        }

        public void Clean()
        {
            DomainEvents.Raise(new EnclosureCleanedEvent(Id, DateTime.UtcNow));
        }
    }
}
