using System.Collections.Generic;
using ZooManager.Core.Models;
using ZooManager.Core.VO;

namespace ZooManager.Core.Ports
{
    public interface IFeedingScheduleRepository
    {
        FeedingSchedule GetById(ScheduleId id);
        void Add(FeedingSchedule schedule);
        void Remove(ScheduleId id);
        IEnumerable<FeedingSchedule> ListAll();
    }
}
