

namespace WeatherMonitoringAndReportingService.Bots
{
    public interface IBotFactory
    {
        public IBot CreateBot(IBotConfig botConfig);
    }
}
