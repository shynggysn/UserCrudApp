namespace CrudApp.Models;

public class WeatherResponse
{
    public required Location Location { get; set; }
    public required Current Current { get; set; }
}

public class Location
{
    public required string Name { get; set; }
    public required string Region { get; set; }
    public required string Country { get; set; }
    public required string Localtime { get; set; }
}

public class Current
{
    public required string Last_Updated { get; set; }
    public double Temp_C { get; set; }
    public double Wind_Kph { get; set; }
    public int Humidity { get; set; }
}