using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using ZooManager.Core.VO;
using ZooManager.Core.Ports;
using ZooManager.UseCases.Contracts;
using ZooManager.WebApi.ViewModels;

namespace ZooManager.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedingSchedulesController : ControllerBase
    {
        private readonly IFeedingScheduleRepository _repo;
        private readonly IFeedingManager _manager;

        public FeedingSchedulesController(
            IFeedingScheduleRepository repo,
            IFeedingManager manager)
        {
            _repo = repo;
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _repo.ListAll()
                .Select(s => new FeedingScheduleViewModel(
                    s.Id.Value,
                    s.AnimalId.Value,
                    s.FeedingTime,
                    s.FoodType.ToString()));
            return Ok(list);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(Guid id)
        {
            var s = _repo.GetById(new ScheduleId(id));
            if (s == null) return NotFound();
            return Ok(new FeedingScheduleViewModel(
                s.Id.Value,
                s.AnimalId.Value,
                s.FeedingTime,
                s.FoodType.ToString()));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Create([FromBody] CreateFeedingScheduleModel m)
        {
            var schedule = _manager.ScheduleFeeding(
                new AnimalId(m.AnimalId),
                m.FeedingTime,
                Enum.Parse<FoodType>(m.FoodType!, true));
            return CreatedAtAction(
                nameof(GetById),
                new { id = schedule.Id.Value },
                null);
        }

        [HttpPost("execute-today")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult ExecuteToday()
        {
            _manager.ExecuteFeedingForToday();
            return NoContent();
        }
    }
}
