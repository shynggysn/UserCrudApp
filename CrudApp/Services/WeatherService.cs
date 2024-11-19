namespace CrudApp.Services;

using System.Net.Http;
using System.Text.Json;
using CrudApp.Models;

public class WeatherService : IWeatherService
{
    private readonly HttpClient _httpClient;
    private const string ApiKey = "95977cf5956f45d6992175018241911";

    public WeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<WeatherResponse> GetCurrentWeatherAsync(string city)
    {
        var url = $"http://api.weatherapi.com/v1/current.json?key={ApiKey}&q={city}&aqi=no";
        var response = await _httpClient.GetAsync(url);

        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<WeatherResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
}
