using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using WeatherExercise;
using WeatherExercise.Controllers;
using Xunit;

namespace TestExercise
{
    public class UnitTest
    {
        private readonly WeatherByCityController _controller;

        public UnitTest()
        {
            _controller = new WeatherByCityController();
        }

        /// <summary>
        /// Tests case of a city from the set, checking success only
        /// </summary>
        [Fact]
        public void GetByCity_ReturnsOkResult()
        {
            var okResult = _controller.getWeatherByCity("bologna");
            Assert.IsType<OkObjectResult>(okResult.Result as OkObjectResult);
        }

        /// <summary>
        /// Tests case of a city from the set, checking results content
        /// </summary>
        [Fact]
        public void GetByCity_ReturnsRightItem()
        {
            var result = _controller.getWeatherByCity("bologna");

            //this will work if previous test passes
            var resultOk = (OkObjectResult)result.Result;
            CityGetResultObject objResult = JsonConvert.DeserializeObject<CityGetResultObject>(resultOk.Value.ToString());
           
            Assert.False(string.IsNullOrEmpty(result.Result.ToString()));

            Assert.False(string.IsNullOrEmpty(objResult.Weather.Weather.First().Main));
            Assert.Equal(20, objResult.Businesses.Businesses.Count());

        }

        /// <summary>
        /// Tests case of a city not present or mispelled passed as parameter to the GET request.
        /// </summary>
        [Fact]
        public void GetByCity_did_not_match()
        {
            var notFoundResult = _controller.getWeatherByCity("bolognia");
            Assert.IsType<BadRequestObjectResult>(notFoundResult.Result);
        }

    }
}