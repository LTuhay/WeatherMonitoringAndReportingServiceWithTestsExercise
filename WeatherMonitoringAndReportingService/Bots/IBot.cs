
using WeatherMonitoringAndReportingService.WeatherData_;

namespace WeatherMonitoringAndReportingService.Bots
{
    public interface IBot
    {
        void Update(IWeatherData weatherData);
    }
}
