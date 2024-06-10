using System.Xml;
using WeatherMonitoringAndReportingService.WeatherData_;
using WeatherMonitoringAndReportingService.WeatherDataEnter;

namespace WeatherMonitoringAndReportingService.Test.WeatherDataEnterTests
{
    public class XmlAdapterTests
    {
        private readonly XmlAdapter sut;

        public XmlAdapterTests() 
        {
            sut = new XmlAdapter();
        }

        [Fact]
        public void EnterWeatherData_ReturnsWeatherDataObject_WhenInputIsValidXml()
        {
            var inputData = "<WeatherData><Location>City Name</Location><Temperature>32</Temperature><Humidity>40</Humidity></WeatherData>";

            var result = sut.EnterWeatherData(inputData);

            Assert.NotNull(result);
            Assert.IsType<WeatherData>(result);
            Assert.Equal("City Name", result.Location);
            Assert.Equal(32, result.Temperature);
            Assert.Equal(40, result.Humidity);
        }

        [Fact]
        public void EnterWeatherData_ShouldThrowXmlException_WhenInputIsInvalidXml()
        {
            var invalidInputData = "invalid xml data";

            var exception = Assert.Throws<XmlException>(() =>
            {
                sut.EnterWeatherData(invalidInputData);
            });

            Assert.Equal("Invalid Xml Exception", exception.Message);
        }
    }
}
