using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WeatherMonitoringAndReportingService.Bots
{
    public class BotConfigLoader : IBotConfigLoader
    {

        private readonly string filePath = @"..\..\..\botConfig.json";
        public IEnumerable<IBotConfig> LoadBotConfig(string? customFilePath = null)
        {
            string finalFilePath = customFilePath ?? filePath;

            if (!File.Exists(finalFilePath))
            {
                throw new FileNotFoundException("Configuration file not found", finalFilePath);
            }

            string jsonContent = File.ReadAllText(finalFilePath);
            JObject botConfigDict = JsonConvert.DeserializeObject<JObject>(jsonContent);

            List<IBotConfig> botConfigs = new List<IBotConfig>();

            foreach (var botConfigEntry in botConfigDict)
            {
                string botName = botConfigEntry.Key;
                JObject botConfigJson = botConfigEntry.Value as JObject;

                BotConfig botConfig = new BotConfig
                {
                    Type = botName,
                    Enabled = botConfigJson.Value<bool>("enabled"),
                    HumidityThreshold = botConfigJson.Value<decimal>("humidityThreshold"),
                    TemperatureThreshold = botConfigJson.Value<decimal>("temperatureThreshold"),
                    Message = botConfigJson.Value<string>("message")
                };

                botConfigs.Add(botConfig);
            }

            return botConfigs;
        }

    }


}
