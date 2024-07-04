
using Microsoft.Extensions.DependencyInjection;
using WeatherMonitoringAndReportingService.Bots;
using WeatherMonitoringAndReportingService.Utilities;
using WeatherMonitoringAndReportingService.WeatherData_;
using WeatherMonitoringAndReportingService.WeatherDataEnter;

public class Program
{

    public static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddTransient<IBotFactory, BotFactory>()
            .AddTransient<IWeatherDataProvider, WeatherDataProvider>()
            .BuildServiceProvider();


        IBotConfigLoader botConfigLoader = new BotConfigLoader();
        IEnumerable<IBotConfig> botConfigs = botConfigLoader.LoadBotConfig();


        IWeatherDataProvider weatherDataProvider = serviceProvider.GetService<IWeatherDataProvider>();
        IBotFactory botFactory = serviceProvider.GetService<IBotFactory>();

        foreach (IBotConfig botConfig in botConfigs)
        {
            IBot bot = botFactory.CreateBot(botConfig);
            weatherDataProvider.RegisterObserver(bot);
        }

        IConsole console = new ConsoleWrapper();
        IGetWeatherAdapter adapterType = new GetWeatherAdapter();

        IEneterWeatherData enterWeatherData = new EnterWeatherData(console, adapterType);
        IWeatherData weatherData = enterWeatherData.GetWeatherData();


        weatherDataProvider.SetWeatherData(weatherData);
    }

}
