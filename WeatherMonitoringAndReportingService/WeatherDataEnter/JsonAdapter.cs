using Newtonsoft.Json;
using WeatherMonitoringAndReportingService.WeatherData_;

namespace WeatherMonitoringAndReportingService.WeatherDataEnter
{
    public class JsonAdapter : IWeatherDataEnterAdapter
    {
        public IWeatherData EnterWeatherData(string inputData)
        {
            try
            {
                var weatherData = JsonConvert.DeserializeObject<WeatherData>(inputData);
                return weatherData ?? throw new JsonException("Invalid JSON format.");
            }
            catch (JsonException ex)
            {
                throw new JsonException("Invalid JSON format.", ex);
            }
        }
    }
}
