using System;
using System.Linq;
using ZooManager.Core.Ports;
using ZooManager.Core.Models;
using ZooManager.Core.VO;
using ZooManager.UseCases.Contracts;

namespace ZooManager.UseCases.Services
{
    public class FeedingManager : IFeedingManager
    {
        private readonly IFeedingScheduleRepository _scheduleRepo;
        private readonly IAnimalRepository _animalRepo;

        public FeedingManager(
            IFeedingScheduleRepository scheduleRepo,
            IAnimalRepository animalRepo)
        {
            _scheduleRepo = scheduleRepo;
            _animalRepo = animalRepo;
        }

        public FeedingSchedule ScheduleFeeding(AnimalId animalId, DateTime time, FoodType food)
        {
            var schedule = new FeedingSchedule(
                new ScheduleId(), animalId, time, food);
            _scheduleRepo.Add(schedule);
            return schedule;
        }

        public void ExecuteFeedingForToday()
        {
            var now = DateTime.UtcNow;
            var today = _scheduleRepo.ListAll()
                .Where(s => s.FeedingTime.Date == now.Date && s.FeedingTime <= now);
            foreach (var s in today)
            {
                var animal = _animalRepo.GetById(s.AnimalId);
                animal.Feed(s.FoodType);
                s.MarkAsDone();
            }
        }
    }
}
