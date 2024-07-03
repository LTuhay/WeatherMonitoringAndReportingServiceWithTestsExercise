
using WeatherMonitoringAndReportingService.Bots;

namespace WeatherMonitoringAndReportingService.WeatherData_
{
    public class WeatherData : IWeatherData
    {
        private List<IBot> _bots = new List<IBot>();
        public String Location {  get; set; }
        public decimal Temperature {  get; set; }
        public decimal Humidity {  get; set; }

    }
}
