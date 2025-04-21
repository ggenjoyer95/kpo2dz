using System;

namespace ZooManager.WebApi.ViewModels
{
    public class FeedingScheduleViewModel
    {
        public Guid Id { get; }
        public Guid AnimalId { get; }
        public DateTime FeedingTime { get; }
        public string FoodType { get; }

        public FeedingScheduleViewModel(Guid id, Guid animalId, DateTime time, string food)
        {
            Id = id;
            AnimalId = animalId;
            FeedingTime = time;
            FoodType = food;
        }
    }
}
