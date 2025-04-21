using System;
using ZooManager.Core.Events;

namespace ZooManager.UseCases.EventHandlers
{
    public class FeedingTimeEventHandler
    {
        public FeedingTimeEventHandler()
        {
            DomainEvents.RegisterHandler(Handle);
        }

        private void Handle(object evt)
        {
            if (evt is FeedingTimeEvent e)
            {
                Console.WriteLine($"[Событие] Кормление {e.ScheduleId.Value}: животное {e.AnimalId.Value} в {e.FeedingTime:u}");
            }
        }
    }
}
