
using WeatherMonitoringAndReportingService.WeatherData_;

namespace WeatherMonitoringAndReportingService.Bots
{
    public interface IBotStrategy
    {
        void Execute(IWeatherData weatherData, string message);
    }
}
