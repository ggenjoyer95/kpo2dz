using System;

namespace ZooManager.Core.VO
{
    public record BirthDate
    {
        public DateTime Value { get; }
        public BirthDate(DateTime value)
        {
            if (value > DateTime.UtcNow)
            {
                throw new ArgumentException("Дата рождения не может быть в будущем.", nameof(value));
            }
            Value = value;
        }
    }
}