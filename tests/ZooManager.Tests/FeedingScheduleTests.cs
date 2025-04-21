using System;
using Xunit;
using ZooManager.Core.Models;
using ZooManager.Core.VO;
using ZooManager.Core.Events;

namespace ZooManager.Tests
{
    public class FeedingScheduleTests
    {
        [Fact]
        public void Reschedule_FiresEvent_UpdatesTime()
        {
            var id = new ScheduleId();
            var animalId = new AnimalId();
            var original = DateTime.UtcNow;
            var schedule = new FeedingSchedule(id, animalId, original, FoodType.Meat);

            var newTime = original.AddHours(1);
            var called = false;
            DomainEvents.RegisterHandler(evt =>
            {
                if (evt is FeedingTimeEvent fte && fte.FeedingTime == newTime)
                    called = true;
            });

            schedule.Reschedule(newTime);

            Assert.Equal(newTime, schedule.FeedingTime);
            Assert.True(called);
        }

        [Fact]
        public void MarkAsDone_SetsFlag()
        {
            var schedule = new FeedingSchedule(
                new ScheduleId(), new AnimalId(), DateTime.UtcNow, FoodType.Plants);
            Assert.False(schedule.IsDone);
            schedule.MarkAsDone();
            Assert.True(schedule.IsDone);
        }
    }
}
