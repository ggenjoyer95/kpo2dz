using System;
using ZooManager.Core.Events;

namespace ZooManager.UseCases.EventHandlers
{
    public class AnimalMovedEventHandler
    {
        public AnimalMovedEventHandler()
        {
            DomainEvents.RegisterHandler(Handle);
        }

        private void Handle(object evt)
        {
            if (evt is AnimalMovedEvent e)
            {
                Console.WriteLine($"[Событие] Животное {e.AnimalId.Value} перемещено из {e.FromEnclosureId.Value} в {e.ToEnclosureId.Value} в {e.OccurredAt:u}");
            }
        }
    }
}
