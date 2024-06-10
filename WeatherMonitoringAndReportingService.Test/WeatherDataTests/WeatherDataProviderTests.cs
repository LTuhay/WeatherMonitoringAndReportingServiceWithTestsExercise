using Moq;
using WeatherMonitoringAndReportingService.Bots;
using WeatherMonitoringAndReportingService.WeatherData_;

namespace WeatherMonitoringAndReportingService.Test.WeatherDataTests
{
    public class WeatherDataProviderTests
    {
        private readonly WeatherDataProvider sut;
        private readonly Mock <IBot> mockBot;
        private readonly Mock<IWeatherData> mockWeatherData;

        public WeatherDataProviderTests()
        {
            sut = new WeatherDataProvider();
            mockBot = new Mock<IBot>();
            mockWeatherData = new Mock<IWeatherData>();
            sut = new WeatherDataProvider();
        }

        [Fact]
        public void RegisterObserver_ShouldAddObserverToList()
        {

            sut.RegisterObserver(mockBot.Object);

            Assert.Contains(mockBot.Object, sut.GetObservers());
        }

        [Fact]
        public void RemoveObserver_ShouldRemoveObserverFromList()
        {

            sut.RegisterObserver(mockBot.Object);

            sut.RemoveObserver(mockBot.Object);

            Assert.DoesNotContain(mockBot.Object, sut.GetObservers());
        }

        [Fact]
        public void NotifyObservers_ShouldCallUpdateOnAllRegisteredBots()
        {

            var mockBot2 = new Mock<IBot>();

            sut.RegisterObserver(mockBot.Object);
            sut.RegisterObserver(mockBot2.Object);

            sut.SetWeatherData(mockWeatherData.Object);

            mockBot.Verify(bot => bot.Update(mockWeatherData.Object), Times.Once);
            mockBot2.Verify(bot => bot.Update(mockWeatherData.Object), Times.Once);
        }

        [Fact]
        public void SetWeatherData_ShouldUpdateWeatherDataAndNotifiesObservers()
        {

            sut.RegisterObserver(mockBot.Object);

            sut.SetWeatherData(mockWeatherData.Object);

            mockBot.Verify(bot => bot.Update(mockWeatherData.Object), Times.Once);
        }
    }
}
