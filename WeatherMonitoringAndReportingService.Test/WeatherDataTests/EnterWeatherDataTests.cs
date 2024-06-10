using Moq;
using WeatherMonitoringAndReportingService.Utilities;
using WeatherMonitoringAndReportingService.WeatherData_;
using WeatherMonitoringAndReportingService.WeatherDataEnter;

namespace WeatherMonitoringAndReportingService.Test.WeatherDataTests
{
    public class EnterWeatherDataTests
    {
        [Fact]
        public void GetWeatherData_ReturnsCorrectWeatherData()
        {
            var mockConsole = new Mock<IConsole>();
            var mockAdapterType = new Mock<IGetWeatherAdapter>();
            var mockAdapter = new Mock<IWeatherDataEnterAdapter>();
            var mockWeatherData = new Mock<IWeatherData>();

            string userInput = "{\"Location\": \"City Name\", \"Temperature\": 32, \"Humidity\": 40}";

            mockConsole.Setup(c => c.ReadLine()).Returns(userInput);
            mockAdapterType.Setup(a => a.GetWeatherDataEnterAdapter(It.IsAny<string>())).Returns(mockAdapter.Object);
            mockAdapter.Setup(a => a.EnterWeatherData(It.IsAny<string>())).Returns(mockWeatherData.Object);

            var sut = new EnterWeatherData(mockConsole.Object, mockAdapterType.Object);

            var result = sut.GetWeatherData();

            Assert.Equal(mockWeatherData.Object, result);
            mockConsole.Verify(c => c.WriteLine("Enter weather data:"), Times.Once);
            mockConsole.Verify(c => c.ReadLine(), Times.Once);
            mockAdapterType.Verify(a => a.GetWeatherDataEnterAdapter(userInput), Times.Once);
            mockAdapter.Verify(a => a.EnterWeatherData(userInput), Times.Once);
        }
    }
}
