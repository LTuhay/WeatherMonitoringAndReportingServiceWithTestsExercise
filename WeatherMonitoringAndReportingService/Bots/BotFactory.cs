

namespace WeatherMonitoringAndReportingService.Bots
{
    public class BotFactory : IBotFactory
    {

        public IBot CreateBot(IBotConfig botConfig)
        {
            IBotStrategy strategy = botConfig.Type switch
            {
                "RainBot" => new RainBotStrategy(botConfig.HumidityThreshold),
                "SunBot" => new SunnyBotStrategy(botConfig.TemperatureThreshold),
                "SnowBot" => new SnowBotStrategy(botConfig.TemperatureThreshold),
                _ => throw new ArgumentException($"Invalid bot type: {botConfig.Type}")
            }; 

            return new Bot(strategy, botConfig.Message);
        }


    }
}
