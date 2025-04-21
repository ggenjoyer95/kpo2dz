using System;
using System.Collections.Generic;

namespace ZooManager.Core.Events
{
    public static class DomainEvents
    {
        private static readonly List<Action<object>> Handlers = new();

        public static void RegisterHandler(Action<object> handler)
        {
            Handlers.Add(handler);
        }

        public static void Raise(object eventItem)
        {
            foreach (var handler in Handlers)
                handler(eventItem);
        }
    }
}
