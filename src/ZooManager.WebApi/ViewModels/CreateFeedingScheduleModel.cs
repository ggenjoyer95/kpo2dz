using System;

namespace ZooManager.WebApi.ViewModels
{
    public class CreateFeedingScheduleModel
    {
        public Guid AnimalId { get; set; }
        public DateTime FeedingTime { get; set; }
        public string? FoodType { get; set; }
    }
}
