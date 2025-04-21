using System;

namespace ZooManager.Core.VO
{
    public record AnimalId
    {
        public Guid Value { get; }
        public AnimalId(Guid value) => Value = value;
        public AnimalId() : this(Guid.NewGuid()) { }
    }
}