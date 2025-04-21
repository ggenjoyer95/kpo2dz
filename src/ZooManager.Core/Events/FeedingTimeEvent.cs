using System;
using ZooManager.Core.VO;

namespace ZooManager.Core.Events
{
    public class FeedingTimeEvent
    {
        public ScheduleId ScheduleId { get; }
        public AnimalId AnimalId { get; }
        public DateTime FeedingTime { get; }

        public FeedingTimeEvent(ScheduleId scheduleId, AnimalId animalId, DateTime feedingTime)
        {
            ScheduleId = scheduleId;
            AnimalId = animalId;
            FeedingTime = feedingTime;
        }
    }
}
