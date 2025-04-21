using System;

namespace ZooManager.Core.VO
{
    public record EnclosureId
    {
        public Guid Value { get; }
        public EnclosureId(Guid value) => Value = value;
        public EnclosureId() : this(Guid.NewGuid()) { }
    }
}