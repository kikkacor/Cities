namespace WeatherExercise
{
    /// <summary>
    /// Container for model result from get requests
    /// </summary>
    public class CityGetResultObject
    {
        public CityWeather Weather { get; set; }
        public CityBusinesses Businesses { get; set; }

        /// <summary>
        /// Constructor for the final model filled result
        /// </summary>
        /// <param name="weather"></param>
        /// <param name="businesses"></param>
        public CityGetResultObject(CityWeather weather, CityBusinesses businesses)
        {
            Weather = weather;
            Businesses = businesses;

        }
    }
}
