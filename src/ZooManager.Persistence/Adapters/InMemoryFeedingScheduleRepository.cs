using System.Collections.Generic;
using ZooManager.Core.Models;
using ZooManager.Core.Ports;
using ZooManager.Core.VO;

namespace ZooManager.Persistence.Adapters
{
    public class InMemoryFeedingScheduleRepository : IFeedingScheduleRepository
    {
        private readonly Dictionary<ScheduleId, FeedingSchedule> _store = new();
        public FeedingSchedule GetById(ScheduleId id) => _store[id];
        public void Add(FeedingSchedule schedule) => _store[schedule.Id] = schedule;
        public void Remove(ScheduleId id) => _store.Remove(id);
        public IEnumerable<FeedingSchedule> ListAll() => _store.Values;
    }
}
