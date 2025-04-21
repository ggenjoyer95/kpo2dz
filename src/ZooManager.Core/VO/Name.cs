using System;

namespace ZooManager.Core.VO
{
    public record Name
    {
        public string Value { get; }
        public Name(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Имя не может быть пустым.", nameof(value));
            }
            Value = value;
        }
    }
}