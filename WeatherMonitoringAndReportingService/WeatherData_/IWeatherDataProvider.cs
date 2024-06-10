
using WeatherMonitoringAndReportingService.Bots;

namespace WeatherMonitoringAndReportingService.WeatherData_
{
    public interface IWeatherDataProvider
    {
        void RegisterObserver(IBot bot);
        void RemoveObserver(IBot bot);
        void NotifyObservers();
         void SetWeatherData(IWeatherData weatherData);
    }
}
