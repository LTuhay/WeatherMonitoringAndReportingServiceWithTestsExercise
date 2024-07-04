

namespace WeatherMonitoringAndReportingService.WeatherDataEnter
{
    public interface IGetWeatherAdapter
    {
        public IWeatherDataEnterAdapter GetWeatherDataEnterAdapter(string inputData);
    }
}
