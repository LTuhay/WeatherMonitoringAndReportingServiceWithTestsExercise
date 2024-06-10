using WeatherMonitoringAndReportingService.Bots;

namespace WeatherMonitoringAndReportingService.Test.BotTests
{
    public class BotConfigLoaderTests
    {
        private readonly BotConfigLoader sut;

        public BotConfigLoaderTests() 
        {
            sut = new BotConfigLoader();
        }

        [Fact]
        public void LoadBotConfig_ShouldThrowFileNotFoundException_WhenFileDoesNotExist()
        {

            string filePath = "nonexistent_file.json";

            Assert.Throws<FileNotFoundException>(() => sut.LoadBotConfig(filePath));
        }

        [Fact]
        public void LoadBotConfig_ShouldReturnCorrectBotConfig_WhenFileExists()
        {
            string testFilePath = Path.GetTempFileName();

            var botData = @"{
                ""Bot1"": {
                    ""enabled"": true,
                    ""humidityThreshold"": 50,
                    ""temperatureThreshold"": 25,
                    ""message"": ""Test message""
                },
                ""Bot2"": {
                    ""enabled"": false,
                    ""humidityThreshold"": 60,
                    ""temperatureThreshold"": 30,
                    ""message"": ""Another test message""
                }
            }";

            File.WriteAllText(testFilePath, botData);

            var botConfigs = sut.LoadBotConfig(testFilePath);

            Assert.Collection(botConfigs,
                botConfig =>
                {
                    Assert.Equal("Bot1", botConfig.Type);
                    Assert.True(botConfig.Enabled);
                    Assert.Equal(50, botConfig.HumidityThreshold);
                    Assert.Equal(25, botConfig.TemperatureThreshold);
                    Assert.Equal("Test message", botConfig.Message);
                },
                botConfig =>
                {
                    Assert.Equal("Bot2", botConfig.Type);
                    Assert.False(botConfig.Enabled);
                    Assert.Equal(60, botConfig.HumidityThreshold);
                    Assert.Equal(30, botConfig.TemperatureThreshold);
                    Assert.Equal("Another test message", botConfig.Message);
                }
            );
        }
    }
}
