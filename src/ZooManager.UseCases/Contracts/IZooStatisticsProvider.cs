using ZooManager.UseCases.DTOs;

namespace ZooManager.UseCases.Contracts
{
    public interface IZooStatisticsProvider
    {
        ZooStatsDto GetStatistics();
    }
}
