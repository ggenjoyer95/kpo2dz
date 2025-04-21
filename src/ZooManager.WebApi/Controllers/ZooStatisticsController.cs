using Microsoft.AspNetCore.Mvc;
using ZooManager.UseCases.Contracts;
using ZooManager.WebApi.ViewModels;

namespace ZooManager.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZooStatisticsController : ControllerBase
    {
        private readonly IZooStatisticsProvider _stats;

        public ZooStatisticsController(IZooStatisticsProvider stats)
        {
            _stats = stats;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var dto = _stats.GetStatistics();
            var vm = new ZooStatsViewModel
            {
                TotalAnimals = dto.TotalAnimals,
                TotalEnclosures = dto.TotalEnclosures,
                FreeSpaces = dto.FreeSpaces
            };
            return Ok(vm);
        }
    }
}
