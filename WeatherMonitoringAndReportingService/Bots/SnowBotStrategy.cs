
using WeatherMonitoringAndReportingService.WeatherData_;

namespace WeatherMonitoringAndReportingService.Bots
{
    public class SnowBotStrategy : IBotStrategy
    {
        private readonly decimal _threshold;

        public SnowBotStrategy(decimal threshold)
        {
            _threshold = threshold;
        }

        public void Execute(IWeatherData weatherData, string message)
        {
            if (weatherData.Temperature < _threshold)
            {
                Console.WriteLine(message);
            }
        }
    }
}
