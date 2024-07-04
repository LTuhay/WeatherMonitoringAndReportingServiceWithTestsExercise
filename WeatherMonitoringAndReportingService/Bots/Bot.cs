
using WeatherMonitoringAndReportingService.WeatherData_;

namespace WeatherMonitoringAndReportingService.Bots
{
    public  class Bot : IBot
    {
        private readonly IBotStrategy _strategy;
        private readonly string _message;

        public Bot(IBotStrategy strategy, string message)
        {
            _strategy = strategy;
            _message = message;
        }

        public void Update(IWeatherData weatherData)
        {
            _strategy.Execute(weatherData, _message);
        }
    }
}
