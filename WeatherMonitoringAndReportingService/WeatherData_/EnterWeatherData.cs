
using WeatherMonitoringAndReportingService.Utilities;
using WeatherMonitoringAndReportingService.WeatherDataEnter;

namespace WeatherMonitoringAndReportingService.WeatherData_
{
    public class EnterWeatherData : IEneterWeatherData
    {
        private readonly IConsole _console;
        private readonly IGetWeatherAdapter _adapterType;

        public EnterWeatherData(IConsole console, IGetWeatherAdapter adapterType)
        {
            _console = console;
            _adapterType = adapterType;
        }
        public IWeatherData GetWeatherData()
        {

            _console.WriteLine("Enter weather data:");
            string userInput = _console.ReadLine();

            IWeatherDataEnterAdapter adapter = _adapterType.GetWeatherDataEnterAdapter(userInput);
            if (adapter == null)
            {
                throw new FormatException("The input format is incorrect.");
            }
            return adapter.EnterWeatherData(userInput);
        }
    }
}
