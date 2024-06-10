

namespace WeatherMonitoringAndReportingService.Test.WeatherDataEnterTests
{
    using global::WeatherMonitoringAndReportingService.WeatherData_;
    using global::WeatherMonitoringAndReportingService.WeatherDataEnter;
    using Moq;
    using Newtonsoft.Json;
    using Xunit;

    namespace WeatherMonitoringAndReportingService.Tests
    {
        public class JsonAdapterTests
        {
            private readonly JsonAdapter sut;
            public JsonAdapterTests() 
            {
                sut = new JsonAdapter();
            }

            [Fact]
            public void EnterWeatherData_ShouldReturnWeatherDataObject_WhenInputIsValidJson()
            {

                var inputData = "{\"Location\": \"City Name\", \"Temperature\": 32, \"Humidity\": 40}";

                var result = sut.EnterWeatherData(inputData);

                Assert.NotNull(result);
                Assert.IsType<WeatherData>(result);
                Assert.Equal("City Name", result.Location);
                Assert.Equal(32, result.Temperature);
                Assert.Equal(40, result.Humidity);
            }

            [Fact]
            public void EnterWeatherData_ShouldThrowJsonException_WhenInputIsInvalidJson()
            {
                var invalidInputData = "invalid json data";
                var exception = Assert.Throws<JsonException>(() =>
                {
                    sut.EnterWeatherData(invalidInputData);
                });

                Assert.Equal("Invalid JSON format.", exception.Message);
            }
        }
    }

}
