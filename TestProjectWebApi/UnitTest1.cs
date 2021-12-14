using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using System.Linq;
using WebApiController.Controllers;
using Xunit;

namespace TestProjectWebApi
{
    public class UnitTest1
    {

        private readonly Mock<ILogger<WeatherForecastController>> _mockLogger;


        /// <summary>
        /// Note the simple ctor
        /// </summary>
        public UnitTest1()
        {
            _mockLogger = new Mock<ILogger<WeatherForecastController>>();
        }

        /// <summary>
        /// Test WeatherForecast.Get()
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void TestGet()
        {
            var controller = new WeatherForecastController(_mockLogger.Object);
            var results = controller.Get();
            results.Count().Should().Be(5);
        }
    }


}
