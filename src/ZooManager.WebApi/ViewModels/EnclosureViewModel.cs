using System;

namespace ZooManager.WebApi.ViewModels
{
    public class EnclosureViewModel
    {
        public Guid Id { get; }
        public string Type { get; }
        public double Size { get; }
        public int CurrentCount { get; }
        public int Capacity { get; }

        public EnclosureViewModel(Guid id, string type, double size, int current, int capacity)
        {
            Id = id;
            Type = type;
            Size = size;
            CurrentCount = current;
            Capacity = capacity;
        }
    }
}
