namespace WeatherExercise
{
    /// <summary>
    /// Container for List of businesses returned from GET API
    /// </summary>
    public class CityBusinesses
    {
        public IEnumerable<Business> Businesses { get; set; }
    }

    /// <summary>
    /// Single model business to be filled after GET reponse
    /// </summary>
    public class Business
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string IsClosed { get; set; }
        public Location Location {get;set;}

    }

    public class Location
    {
        public string Address1 { get; set; }
    }
}
