using System;
using ZooManager.Core.VO;
using ZooManager.Core.Events;

namespace ZooManager.Core.Models
{
    public class FeedingSchedule
    {
        public ScheduleId Id { get; }
        public AnimalId AnimalId { get; }
        public DateTime FeedingTime { get; private set; }
        public FoodType FoodType { get; }
        public bool IsDone { get; private set; }

        public FeedingSchedule(
            ScheduleId id,
            AnimalId animalId,
            DateTime feedingTime,
            FoodType foodType)
        {
            Id = id;
            AnimalId = animalId;
            FeedingTime = feedingTime;
            FoodType = foodType;
            IsDone = false;
        }

        public void Reschedule(DateTime newTime)
        {
            FeedingTime = newTime;
            DomainEvents.Raise(new FeedingTimeEvent(Id, AnimalId, newTime));
        }

        public void MarkAsDone()
        {
            IsDone = true;
        }
    }
}
