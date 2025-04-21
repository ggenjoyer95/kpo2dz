using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using ZooManager.Core.Ports;
using ZooManager.Core.VO;
using ZooManager.Core.Models;
using ZooManager.UseCases.Contracts;
using ZooManager.WebApi.ViewModels;

namespace ZooManager.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalRepository _repo;
        private readonly IAnimalTransferService _transferService;

        public AnimalsController(
            IAnimalRepository repo,
            IAnimalTransferService transferService)
        {
            _repo = repo;
            _transferService = transferService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _repo.ListAll()
                .Select(a => new AnimalViewModel(
                    a.Id.Value,
                    a.Name.Value,
                    a.Species.ToString(),
                    a.Status.ToString()));
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var animal = _repo.ListAll().FirstOrDefault(a => a.Id.Value == id);
            if (animal == null) return NotFound();
            return Ok(new AnimalViewModel(
                animal.Id.Value,
                animal.Name.Value,
                animal.Species.ToString(),
                animal.Status.ToString()));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateAnimalModel m)
        {
            var animal = new Animal(
                new AnimalId(),
                Enum.Parse<Species>(m.Species!, true),
                new Name(m.Name!),
                new BirthDate(m.BirthDate),
                Enum.Parse<Gender>(m.Gender!, true),
                Enum.Parse<FoodType>(m.FavoriteFood!, true),
                HealthStatus.Healthy,
                new EnclosureId());
            _repo.Add(animal);
            return CreatedAtAction(nameof(GetById), new { id = animal.Id.Value }, null);
        }

        [HttpPost("{id}/transfer")]
        public IActionResult Transfer(Guid id, [FromBody] TransferAnimalModel m)
        {
            _transferService.Transfer(
                new AnimalId(id),
                new EnclosureId(m.TargetEnclosureId));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _repo.Remove(new AnimalId(id));
            return NoContent();
        }
    }
}
