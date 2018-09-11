using GCFinal.MVC.Client;
using System;
using System.Linq;
using Xunit;

namespace GCFinal.MVC.Test
{
    [Trait("Category", "Integration")]
    public class UnitTest1
    {
        [Fact]
        public void WeatherClien_ReturnsData_GivenValidData()
        {
            var sut = new WeatherClient();
            var weatherObject = sut.GetHistoricalWeather("Grand Rapids", new DateTime(2018,01,01), 2)
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            Assert.NotNull(weatherObject);
            Assert.NotNull(weatherObject.First().Hour);
        }
    }
}
