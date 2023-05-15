using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using Weather.Shared.Models.Main;
using Newtonsoft.Json;

namespace Weather.Server.Controllers
{

    [Route("api/weather")]
    [ApiController]
    public class WeatherController
    {
        private readonly HttpClient _httpClient;


        public WeatherController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public void Simple()
        {
            Console.WriteLine("Test");
        }

        [HttpPost]
        public async Task<Weather.Shared.Models.Main.Weather> GetWeatherDataForTucsonAsync(Location location)
        {
            Timezone timezone = await GetTimeZone(location);

            string apiUrl = $"https://api.open-meteo.com/v1/forecast?latitude={location.Latitude}&longitude={location.Longitude}&hourly=temperature_2m,relativehumidity_2m,rain,snowfall,cloudcover,windspeed_10m,winddirection_10m,uv_index,is_day&daily=temperature_2m_max,temperature_2m_min,sunrise,sunset,uv_index_max,precipitation_hours,windspeed_10m_max&current_weather=true&temperature_unit=fahrenheit&windspeed_unit=mph&precipitation_unit=inch&past_days=2&forecast_days=4&timezone={timezone.TimezoneP}";

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                var jsonObject = JsonDocument.Parse(responseContent);
                Weather.Shared.Models.Main.Weather weather = new Shared.Models.Main.Weather();

                weather.CurrentWeather=JsonConvert.DeserializeObject<CurrentWeather>(jsonObject.RootElement.GetProperty("current_weather").ToString());

                weather.DailyUnits= JsonConvert.DeserializeObject<DailyUnits>(jsonObject.RootElement.GetProperty("daily_units").ToString());
                weather.HourlyUnits=JsonConvert.DeserializeObject<HourlyUnits>(jsonObject.RootElement.GetProperty("hourly_units").ToString());
                weather.WeatherHourly=JsonConvert.DeserializeObject<WeatherHourly>(jsonObject.RootElement.GetProperty("hourly").ToString());
                weather.WeatherDaily=JsonConvert.DeserializeObject<WeatherDaily>(jsonObject.RootElement.GetProperty("daily").ToString());

                return weather;
            }
            else
            {
                throw new Exception($"Error retrieving weather data: {response.ReasonPhrase}");
            }

        }

        public async System.Threading.Tasks.Task<Timezone> GetTimeZone(Location location)
        {
            string apiUrl = System.String.Format("https://api.ipgeolocation.io/timezone?apiKey=a1cf5af5a30442fc8f89d77a26e56cc3&lat={0:g}&long={0:g}", location.Latitude, location.Longitude);

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                // Parse the JSON response
                var jsonObject = JsonDocument.Parse(responseContent);

                // Get the latest values for each parameter for Tucson
                string timezone = jsonObject.RootElement.GetProperty("timezone").ToString();
                string date = jsonObject.RootElement.GetProperty("date").ToString();
                string time_24 = jsonObject.RootElement.GetProperty("time_24").ToString();
                string time_12 = jsonObject.RootElement.GetProperty("time_12").ToString();

                Timezone result = new Timezone
                {

                    TimezoneP=timezone,
                    Time24=time_24,
                    Date=date,
                    Time12=time_12
                };

                return result;
            }
            else
            {
                throw new Exception($"Error retrieving weather data: {response.ReasonPhrase}");
            }
        }
    }
}
