using Newtonsoft.Json;
using System.Net;

namespace WeatherExercise
{
    /// <summary>
    /// Contains GET request to openWeatherMap and configuration to get Weather of cities
    /// </summary>
    public class WeatherUtilities
    {
        /// <summary>
        /// Token to access website APIs.
        /// </summary>
        public const string AccessToken = "965bb9f9bfc0ae6f9caf7286b4303baa";

        /// <summary>
        /// Method to make GET request to web API on local weather.
        /// </summary>
        /// <param name="city"></param>
        /// <returns>Model object filled with info read from json</returns>
        public CityWeather GetWeather(string city)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={WeatherUtilities.AccessToken}");
                httpWebRequest.Method = "GET";
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpWebResponse.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(String.Format("Something went wrong during Weather request for {0}", city));
                }
                using (StreamReader webStream = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    string webcontent = webStream.ReadToEnd();
                    return JsonConvert.DeserializeObject<CityWeather>(webcontent);
                }
            }catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);    
            }
            return null;
        }
    }
}
