
using System.Xml;
using System.Xml.Serialization;
using WeatherMonitoringAndReportingService.WeatherData_;

namespace WeatherMonitoringAndReportingService.WeatherDataEnter
{
    public class XmlAdapter : IWeatherDataEnterAdapter
    {
        public IWeatherData EnterWeatherData(string inputData)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(WeatherData)) ?? throw new XmlException("Invalid Xml Exception");
                using (StringReader reader = new StringReader(inputData))
                {
                    return (WeatherData)serializer.Deserialize(reader);
                }
            }
            catch (InvalidOperationException ex)
            {
                throw new XmlException("Invalid Xml Exception", ex);
            }
        }
    }
}
