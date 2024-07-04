

namespace WeatherMonitoringAndReportingService.WeatherDataEnter
{
    public class GetWeatherAdapter : IGetWeatherAdapter
    {
        public IWeatherDataEnterAdapter GetWeatherDataEnterAdapter(string inputData)
        {
            if (inputData != null)
            {
                if (inputData.StartsWith("{"))
                {
                    return new JsonAdapter();
                }
                else if (inputData.StartsWith("<"))
                {
                    return new XmlAdapter();
                }
            }
            return null;
        }

    }
}
