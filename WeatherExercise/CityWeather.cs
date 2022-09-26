namespace WeatherExercise
{
    /// <summary>
    /// Container for Weather information read from GET API
    /// </summary>
    public class CityWeather
    {
        public string Name { get; set; }
        public IEnumerable<Weather> Weather { get; set; }
        public Main Main { get; set; }
    }
    public class Weather
    {
        public string Main { get; set; }
        public string Description { get; set; }
    }
    public class Main
    {
        public string Temp { get; set; }
    }
}
