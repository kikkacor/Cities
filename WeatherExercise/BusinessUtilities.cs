using Newtonsoft.Json;
using System.Net;

namespace WeatherExercise
{
    /// <summary>
    /// Contains GET request to YELP and configuration to get businesses of cities
    /// </summary>
    public class BusinessUtilities
    {
        /// <summary>
        /// Token to access website APIs.
        /// </summary>
        public const string AccessToken = "jGUcoEYlIRDIn2oXPnHvH9p1ZhpClTuP3VLS9SZgJQd1DEAs9DVSf8RnacD-I5zdbGu4a7qiFguM9P4kTcxN6nH1L2Va6SfJhEbEg16HVLyq39agxgKl1kBZxYUrY3Yx";

        /// <summary>
        /// Method to make GET request to web API on local businesses.
        /// </summary>
        /// <param name="city"></param>
        /// <returns>Model object filled with info read from json</returns>
        public CityBusinesses GetBusinesses(string city)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create($"https://api.yelp.com/v3/businesses/search?location={city}");
                httpWebRequest.Method = "GET";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + BusinessUtilities.AccessToken);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpWebResponse.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(String.Format("Something went wrong during Businesses request for {0}", city));
                }
                using (StreamReader webStream = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    string webcontent = webStream.ReadToEnd();
                    return JsonConvert.DeserializeObject<CityBusinesses>(webcontent);
                }
            } catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
           return null;

        }
    }
}
