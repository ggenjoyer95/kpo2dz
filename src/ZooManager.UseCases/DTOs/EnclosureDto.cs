using System;

namespace ZooManager.UseCases.DTOs
{
    public class EnclosureDto
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public int CurrentCount { get; set; }
        public int Capacity { get; set; }
    }
}
