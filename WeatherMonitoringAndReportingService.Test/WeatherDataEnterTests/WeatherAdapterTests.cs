
using WeatherMonitoringAndReportingService.WeatherDataEnter;

namespace WeatherMonitoringAndReportingService.Test.WeatherDataEnterTests
{
    public class WeatherAdapterTests
    {
        private readonly GetWeatherAdapter sut;

        public WeatherAdapterTests()
        {
            sut = new GetWeatherAdapter();
        }
            
        [Theory]
        [InlineData("{\"Location\": \"City Name\", \"Temperature\": 32, \"Humidity\": 40}")]
        public void GetWeatherDataEnterAdapter_ShouldReturnJsonAdapter_WhenInputStartsWithJson(string inputData)
        {

            var result = sut.GetWeatherDataEnterAdapter(inputData);
            Assert.IsType<JsonAdapter>(result);
        }

        [Theory]
        [InlineData("<weather><location>City Name</location><temperature>32</temperature><humidity>40</humidity></weather>")]
        public void GetWeatherDataEnterAdapter_ShouldReturnXmlAdapter_WhenInputStartsWithXml(string inputData)
        {

            var result = sut.GetWeatherDataEnterAdapter(inputData);
            Assert.IsType<XmlAdapter>(result);
        }

        [Theory]
        [InlineData("invalid data")]
        [InlineData("")]
        [InlineData(null)]
        public void GetWeatherDataEnterAdapter_ShouldReturnNull_WhenInputIsInvalid(string inputData)
        {
            var result = sut.GetWeatherDataEnterAdapter(inputData);
            Assert.Null(result);
        }
    }
}
