using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using ZooManager.Core.VO;
using ZooManager.Core.Models;
using ZooManager.Core.Ports;
using ZooManager.WebApi.ViewModels;

namespace ZooManager.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnclosuresController : ControllerBase
    {
        private readonly IEnclosureRepository _repo;

        public EnclosuresController(IEnclosureRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _repo.ListAll()
                .Select(e => new EnclosureViewModel(
                    e.Id.Value,
                    e.Type.ToString(),
                    e.Size.Value,
                    e.CurrentAnimalCount,
                    e.Capacity.Value));
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var enc = _repo.ListAll().FirstOrDefault(e => e.Id.Value == id);
            if (enc == null) return NotFound();
            return Ok(new EnclosureViewModel(
                enc.Id.Value,
                enc.Type.ToString(),
                enc.Size.Value,
                enc.CurrentAnimalCount,
                enc.Capacity.Value));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateEnclosureModel m)
        {
            var enclosure = new Enclosure(
                new EnclosureId(),
                Enum.Parse<EnclosureType>(m.Type!, true),
                new Size(m.Size),
                new Capacity(m.Capacity));
            _repo.Add(enclosure);
            return CreatedAtAction(nameof(GetById), new { id = enclosure.Id.Value }, null);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _repo.Remove(new EnclosureId(id));
            return NoContent();
        }
    }
}
