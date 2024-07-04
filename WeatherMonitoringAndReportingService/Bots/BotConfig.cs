

namespace WeatherMonitoringAndReportingService.Bots
{
    public class BotConfig : IBotConfig
    {
        public string Type { get; set; }
        public bool Enabled { get; set; }
        public decimal HumidityThreshold { get; set; }
        public decimal TemperatureThreshold { get; set; }
        public string Message { get; set; }
    }
}
