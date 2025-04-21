namespace ZooManager.WebApi.ViewModels
{
    public class AnimalViewModel
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Species { get; }
        public string Status { get; }

        public AnimalViewModel(Guid id, string name, string species, string status)
        {
            Id = id; Name = name; Species = species; Status = status;
        }
    }
}
