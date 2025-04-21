using System;

namespace ZooManager.Core.VO
{
    public record Capacity
    {
        public int Value { get; }
        public Capacity(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Вместимость должна быть больше нуля.", nameof(value));
            }
            Value = value;
        }
    }
}