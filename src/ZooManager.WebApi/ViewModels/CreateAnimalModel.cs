using System;

namespace ZooManager.WebApi.ViewModels
{
    public class CreateAnimalModel
    {
        public string? Name { get; set; }
        public string? Species { get; set; }
        public string? Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string? FavoriteFood { get; set; }
    }
}
