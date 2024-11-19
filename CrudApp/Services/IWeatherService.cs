using CrudApp.Models;

namespace CrudApp.Services;

public interface IWeatherService
{
    Task<WeatherResponse> GetCurrentWeatherAsync(string city);
}
