using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WeatherExercise.Controllers
{
    /// <summary>
    /// Controller to invoke requests, invokes utility classes.
    /// </summary>
    [ApiController]
    [Route("api/weatherbycity")]
    public class WeatherByCityController : ControllerBase
    {
        private CityWeather cityWeather { get; set; }
        private CityBusinesses cityBusinesses { get; set; }

        private BusinessUtilities businessUtilities { get; set; }
        private WeatherUtilities weatherUtilities { get; set; }

        private readonly string[] cities = { "Berlin", "Bologna", "Paris", "Rome", "Barcelona" };

        /// <summary>
        /// Constructor to initialize utilities and model
        /// </summary>
        /// <param></param>
        public WeatherByCityController()
        {   businessUtilities = new BusinessUtilities();
            weatherUtilities = new WeatherUtilities();
            cityBusinesses = new CityBusinesses();
            cityWeather = new CityWeather();
        }

        
        /// <summary>
        /// Starting resource of the App; doesn't need parameters.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult getWeather()
        {
            return Ok("Add as last argument of URL one city from the following: Berlin, Bologna, Paris, Rome, Barcelona");
        }

        /// <summary>
        /// Returns information about a city, invoking GET requests.
        /// </summary>
        /// <param name="city">Name of the city to investigate on.</param>
        /// <returns></returns>
        [HttpGet("{city}")]
        public async Task<IActionResult> getWeatherByCity(string city)
        {
            if (!cities.Any(c => c.ToLower().Equals(city.ToLower())))
            {
                return BadRequest("Invalid city parameter given");
            }

            string result=string.Empty;
            cityWeather = weatherUtilities.GetWeather(city);
            cityBusinesses = businessUtilities.GetBusinesses(city);
            
            if (cityWeather != null && cityBusinesses != null)
            {
                //since GET requests did not fail, create the final model object    
                CityGetResultObject cityGetResultObject = new CityGetResultObject(cityWeather, cityBusinesses);

                //serialize json filled result for client
                var jsonString = JsonConvert.SerializeObject(cityGetResultObject);
                JObject cityResult = JObject.Parse(jsonString);
                result = cityResult.ToString();
                
            }
            else
            {
                return BadRequest("An error occurred during GET requests.");
            }

            return Ok(result);
        }

       
       
    }
    
}