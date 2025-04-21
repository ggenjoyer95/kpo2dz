using System;
using ZooManager.Core.Models;
using ZooManager.Core.VO;

namespace ZooManager.UseCases.Contracts
{
    public interface IFeedingManager
    {
        FeedingSchedule ScheduleFeeding(AnimalId animalId, DateTime time, FoodType food);

        void ExecuteFeedingForToday();
    }
}
