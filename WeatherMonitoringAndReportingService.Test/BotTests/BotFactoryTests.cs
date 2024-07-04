using AutoFixture;
using System.Reflection;
using WeatherMonitoringAndReportingService.Bots;

namespace WeatherMonitoringAndReportingService.Test.BotTests
{
    public  class BotFactoryTests
    {
        private readonly IFixture fixture;
        private readonly BotFactory sut;
        public BotFactoryTests() 
        {
            fixture = new Fixture();
            sut = new BotFactory();
        }

        [Fact]
        public void CreateBot_ShouldReturnRainBot_WhenBotConfigTypeIsSunBot()
        {

            var botConfig = fixture.Build<BotConfig>()
                .With(b => b.Type, "RainBot")
                .Create();

            var bot = sut.CreateBot(botConfig);

            var strategyField = typeof(Bot).GetField("_strategy", BindingFlags.NonPublic | BindingFlags.Instance);
            var strategy = strategyField.GetValue(bot) as IBotStrategy;

            Assert.NotNull(strategy);
            Assert.IsType<RainBotStrategy>(strategy);
        }

        [Fact]
        public void CreateBot_ShouldReturnSunBot_WhenBotConfigTypeIsSunBot()
        {

            var botConfig = fixture.Build<BotConfig>()
                .With(b => b.Type, "SunBot")
                .Create();

            var bot = sut.CreateBot(botConfig);

            var strategyField = typeof(Bot).GetField("_strategy", BindingFlags.NonPublic | BindingFlags.Instance);
            var strategy = strategyField.GetValue(bot) as IBotStrategy;

            Assert.NotNull(strategy);
            Assert.IsType<SunnyBotStrategy>(strategy);
        }

        [Fact]
        public void CreateBot_ShouldReturnSnowBot_WhenBotConfigTypeIsSnowBot()
        {
            var botConfig = fixture.Build<BotConfig>()
                .With(b => b.Type, "SnowBot")
                .Create();

            var bot = sut.CreateBot(botConfig);

            var strategyField = typeof(Bot).GetField("_strategy", BindingFlags.NonPublic | BindingFlags.Instance);
            var strategy = strategyField.GetValue(bot) as IBotStrategy;

            Assert.NotNull(strategy);
            Assert.IsType<SnowBotStrategy>(strategy);
        }

        [Fact]
        public void CreateBot_ShouldThrowArgumentException_WhenBotConfigTypeIsInvalid()
        {

            var botConfig = fixture.Build<BotConfig>()
                .With(b => b.Type, "InvalidBotType")
                .With(b => b.Message, "Invalid bot message")
                .Create();


            Assert.Throws<ArgumentException>(() => sut.CreateBot(botConfig));
        }
    }
}
