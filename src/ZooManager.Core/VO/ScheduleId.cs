using System;

namespace ZooManager.Core.VO
{
    public record ScheduleId
    {
        public Guid Value { get; }
        public ScheduleId(Guid value) => Value = value;
        public ScheduleId() : this(Guid.NewGuid()) { }
    }
}