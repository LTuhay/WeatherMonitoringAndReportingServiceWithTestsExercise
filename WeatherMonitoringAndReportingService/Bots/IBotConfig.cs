

namespace WeatherMonitoringAndReportingService.Bots
{
    public interface IBotConfig
    {
        string Type { get; set; }
        bool Enabled { get; set; }
        decimal HumidityThreshold { get; set; }
        decimal TemperatureThreshold { get; set; }
        string Message { get; set; }
    }
}
