namespace WeatherAPI.Domain
{
    public class WeatherDetails
    {
        public int QueryCost { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string ResolvedAddress { get; set; }
        public string Address { get; set; }
        public string Timezone { get; set; }
        public float Tzoffset { get; set; }
        public Day[] Days { get; set; }
        public Stations Stations { get; set; }
        public CurrentConditions CurrentConditions { get; set; }
    }

    public class Stations
    {
        public DNAA DNAA { get; set; }
    }

    public class DNAA
    {
        public float Distance { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int UseCount { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public int Quality { get; set; }
        public float Contribution { get; set; }
    }

    public class CurrentConditions
    {
        public string Datetime { get; set; }
        public int DatetimeEpoch { get; set; }
        public float Temp { get; set; }
        public float Feelslike { get; set; }
        public float Humidity { get; set; }
        public float Dew { get; set; }
        public float Precip { get; set; }
        public float Precipprob { get; set; }
        public float Snow { get; set; }
        public float SnowDepth { get; set; }
        public object Preciptype { get; set; }
        public object Windgust { get; set; }
        public float WindSpeed { get; set; }
        public float Winddir { get; set; }
        public float Pressure { get; set; }
        public float Visibility { get; set; }
        public float Cloudcover { get; set; }
        public float Solarradiation { get; set; }
        public object Solarenergy { get; set; }
        public float UvIndex { get; set; }
        public string Conditions { get; set; }
        public string Icon { get; set; }
        public string[] Stations { get; set; }
        public string Source { get; set; }
        public string Sunrise { get; set; }
        public int SunriseEpoch { get; set; }
        public string Sunset { get; set; }
        public int SunsetEpoch { get; set; }
        public float Moonphase { get; set; }
    }

    public class Day
    {
        public string Datetime { get; set; }
        public int DatetimeEpoch { get; set; }
        public float Tempmax { get; set; }
        public float Tempmin { get; set; }
        public float Temp { get; set; }
        public float FeelsLikeMax { get; set; }
        public float FeelsLikeMin { get; set; }
        public float FeelsLike { get; set; }
        public float Dew { get; set; }
        public float Humidity { get; set; }
        public float Precip { get; set; }
        public float Precipprob { get; set; }
        public float PrecipCover { get; set; }
        public string[] PrecipType { get; set; }
        public float Snow { get; set; }
        public float SnowDepth { get; set; }
        public float WindGust { get; set; }
        public float WindSpeed { get; set; }
        public float Winddir { get; set; }
        public float Pressure { get; set; }
        public float Cloudcover { get; set; }
        public float Visibility { get; set; }
        public float SolarRadiation { get; set; }
        public float SolarEnergy { get; set; }
        public float UvIndex { get; set; }
        public float SevereRisk { get; set; }
        public string SunRise { get; set; }
        public int SunriseEpoch { get; set; }
        public string Sunset { get; set; }
        public int SunsetEpoch { get; set; }
        public float Moonphase { get; set; }
        public string Conditions { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string[] Stations { get; set; }
        public string Source { get; set; }
    }
}
