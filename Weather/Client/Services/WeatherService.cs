using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Net.Http.Json;
using Weather.Shared.Models.Main;

namespace Weather.Client.Services
{
    

    public class WeatherService : IWeatherService
    {
        private HttpClient _httpClient;
        private NavigationManager _navigationManager;
        private List<DayModel> _days;

        private Weather.Shared.Models.Main.Weather? weather { get; set; }
        private Location? Location { get; set; }

        public Weather.Shared.Models.Main.Weather? GetWeather()
        {
            return weather;
        }

        public async Task SetWeather()
        {
            var response = await _httpClient.PostAsJsonAsync(_navigationManager.BaseUri+"api/weather", Location);

            if (response.IsSuccessStatusCode)
            {
                weather=await response.Content.ReadFromJsonAsync<Weather.Shared.Models.Main.Weather?>();
                CreateListOfDays();
            }

        }

        public void SertDependencies(HttpClient http, NavigationManager navigation)
        {
            _httpClient=http;
            _navigationManager=navigation;
        }

        public void SetLocation(Location location)
        {
            Location= location;
        }

        public Location? GetLocation()
        {
            return Location;
        }

        public List<DayModel> GetDaysInfo()
        {
            return _days;
        }

        private void CreateListOfDays()
        {
            _days = new List<DayModel>();
            for (int i=0; i<weather.WeatherDaily.time.Length; i++)
            {
                _days.Add (new DayModel
                {
                    time=weather.WeatherDaily.time[i],
                    temperature_2m_max=weather.WeatherDaily.temperature_2m_max[i],
                    temperature_2m_min=weather.WeatherDaily.temperature_2m_min[i],
                    sunrise=weather.WeatherDaily.sunrise[i],
                    sunset=weather.WeatherDaily.sunset[i],
                    uv_index=weather.WeatherDaily.uv_index_max[i],
                    precipitation_hours=weather.WeatherDaily.precipitation_hours[i],
                    windspeed_10m_max=weather.WeatherDaily.windspeed_10m_max[i],
                });
            }
        }
    }
}
