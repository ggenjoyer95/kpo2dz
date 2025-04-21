using System;
using ZooManager.Core.VO;
using ZooManager.Core.Events;

namespace ZooManager.Core.Models
{
    public class Animal
    {
        public AnimalId Id { get; }
        public Species Species { get; }
        public Name Name { get; }
        public BirthDate BirthDate { get; }
        public Gender Gender { get; }
        public FoodType FavoriteFood { get; }
        public HealthStatus Status { get; private set; }
        public EnclosureId CurrentEnclosureId { get; private set; }

        public Animal(
            AnimalId id,
            Species species,
            Name name,
            BirthDate birthDate,
            Gender gender,
            FoodType favoriteFood,
            HealthStatus status,
            EnclosureId initialEnclosure)
        {
            Id = id;
            Species = species;
            Name = name;
            BirthDate = birthDate;
            Gender = gender;
            FavoriteFood = favoriteFood;
            Status = status;
            CurrentEnclosureId = initialEnclosure;
        }

        public void Feed(FoodType food)
        {
            if (!FavoriteFood.Equals(food))
            {
                throw new InvalidOperationException("Неподходящий тип пищи.");
            }
            Status = HealthStatus.Healthy;
        }

        public void Treat()
        {
            Status = HealthStatus.Healthy;
        }

        public void MoveTo(Enclosure enclosure)
        {
            CurrentEnclosureId = enclosure.Id;
            DomainEvents.Raise(new AnimalMovedEvent(Id, enclosure.Id, enclosure.Id, DateTime.UtcNow));
        }
    }
}
