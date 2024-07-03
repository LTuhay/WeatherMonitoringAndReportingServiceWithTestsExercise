
using WeatherMonitoringAndReportingService.WeatherData_;

namespace WeatherMonitoringAndReportingService.Bots
{
    public class SunnyBotStrategy : IBotStrategy
    {
        private readonly decimal _threshold;

        public SunnyBotStrategy(decimal threshold)
        {
            _threshold = threshold;
        }

        public void Execute(IWeatherData weatherData, string message)
        {
            if (weatherData.Temperature > _threshold)
            {
                Console.WriteLine(message);
            }
        }
    }
}
