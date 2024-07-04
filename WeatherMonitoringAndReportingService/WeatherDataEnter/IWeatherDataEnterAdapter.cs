
using WeatherMonitoringAndReportingService.WeatherData_;

namespace WeatherMonitoringAndReportingService.WeatherDataEnter
{
    public interface IWeatherDataEnterAdapter
    {
        IWeatherData EnterWeatherData(string inputData);
    }
}
