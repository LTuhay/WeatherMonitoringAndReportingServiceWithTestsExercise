

namespace WeatherMonitoringAndReportingService.Utilities
{
    public interface IConsole
    {
        void WriteLine(string message);
        string ReadLine();
    }
}
