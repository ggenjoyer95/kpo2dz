using System;

namespace ZooManager.Core.VO
{
    public record Size
    {
        public double Value { get; }
        public Size(double value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Размер должен быть больше нуля.", nameof(value));
            }
            Value = value;
        }
    }
}