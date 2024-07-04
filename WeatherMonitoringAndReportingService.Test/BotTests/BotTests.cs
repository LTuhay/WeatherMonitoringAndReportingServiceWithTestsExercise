using AutoFixture;
using Moq;
using WeatherMonitoringAndReportingService.Bots;
using WeatherMonitoringAndReportingService.WeatherData_;

namespace WeatherMonitoringAndReportingService.Test.BotTests
{
    public class BotTests
    {
        private readonly IFixture fixture;
        private readonly Mock<IWeatherData> mockWeatherData;

        public BotTests() 
        {
            fixture = new Fixture();
            mockWeatherData = new Mock<IWeatherData>();
        }

        [Fact]
        public void Update_ShouldCallExecuteOnStrategy_WithCorrectParameters()
        {

            var mockStrategy = new Mock<IBotStrategy>();
            var sutBot = new Bot(mockStrategy.Object, "Test Message");
            sutBot.Update(mockWeatherData.Object);

            mockStrategy.Verify(s => s.Execute(mockWeatherData.Object, "Test Message"), Times.Once);
        }

        [Fact]
        public void Execute_ShouldPrintRainBotMessage_WhenHumidityIsAboveThreshold()
        {

            decimal threshold = fixture.Create<decimal>();
            mockWeatherData.Setup(w => w.Humidity).Returns(threshold + 1); 
            var message = "Rain message";
            var sutStrategy = new RainBotStrategy(threshold);
            var consoleOut = new StringWriter();
            Console.SetOut(consoleOut);

            sutStrategy.Execute(mockWeatherData.Object, message);

            Assert.Equal(message + Environment.NewLine, consoleOut.ToString());
        }

        [Fact]
        public void Execute_ShouldPrintSunnyBotMessage_WhenTemperatureIsAboveThreshold()
        {

            decimal threshold = fixture.Create<decimal>();
            mockWeatherData.Setup(w => w.Temperature).Returns(threshold + 1);
            var message = "Sunny message";
            var sutStrategy = new SunnyBotStrategy(threshold);
            var consoleOut = new StringWriter();
            Console.SetOut(consoleOut);

            sutStrategy.Execute(mockWeatherData.Object, message);

            Assert.Equal(message + Environment.NewLine, consoleOut.ToString());
        }

        [Fact]
        public void Execute_ShouldPrintSnowBotMessage_WhenTemperatureIsBelowThreshold()
        {

            decimal threshold = fixture.Create<decimal>();
            mockWeatherData.Setup(w => w.Temperature).Returns(threshold -1);
            var message = "Snow message";
            var sutStrategy = new SnowBotStrategy(threshold);
            var consoleOut = new StringWriter();
            Console.SetOut(consoleOut);

            sutStrategy.Execute(mockWeatherData.Object, message);

            Assert.Equal(message + Environment.NewLine, consoleOut.ToString());
        }

    }
}