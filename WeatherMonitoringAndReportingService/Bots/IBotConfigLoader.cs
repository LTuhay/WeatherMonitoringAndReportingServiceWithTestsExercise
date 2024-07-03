

namespace WeatherMonitoringAndReportingService.Bots
{
    public interface IBotConfigLoader
    {
        public IEnumerable<IBotConfig> LoadBotConfig(string? customFilePath = null);
    }
}
