using System;

namespace ZooManager.UseCases.DTOs
{
    public class AnimalDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Status { get; set; }
    }
}
