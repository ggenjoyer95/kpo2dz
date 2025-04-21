using System;
using ZooManager.Core.Events;

namespace ZooManager.UseCases.EventHandlers
{
    public class EnclosureCleanedEventHandler
    {
        public EnclosureCleanedEventHandler()
        {
            DomainEvents.RegisterHandler(Handle);
        }

        private void Handle(object evt)
        {
            if (evt is EnclosureCleanedEvent e)
            {
                Console.WriteLine($"[Событие] Уборка вольера {e.EnclosureId.Value} в {e.CleanedAt:u}");
            }
        }
    }
}
