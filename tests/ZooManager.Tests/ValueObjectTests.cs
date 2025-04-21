using System;
using Xunit;
using ZooManager.Core.VO;

namespace ZooManager.Tests
{
    public class ValueObjectTests
    {
        [Fact]
        public void Name_RejectsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Name(""));
        }

        [Fact]
        public void BirthDate_RejectsFuture()
        {
            Assert.Throws<ArgumentException>(() => new BirthDate(DateTime.UtcNow.AddDays(1)));
        }

        [Fact]
        public void Capacity_RejectsNonPositive()
        {
            Assert.Throws<ArgumentException>(() => new Capacity(0));
        }

        [Fact]
        public void Size_RejectsNonPositive()
        {
            Assert.Throws<ArgumentException>(() => new Size(0));
        }

        [Fact]
        public void Ids_GenerateNonEmpty()
        {
            Assert.NotEqual(Guid.Empty, new AnimalId().Value);
            Assert.NotEqual(Guid.Empty, new EnclosureId().Value);
            Assert.NotEqual(Guid.Empty, new ScheduleId().Value);
        }
    }
}
