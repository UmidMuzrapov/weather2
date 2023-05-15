using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<double[]> GetWeatherDataForTucsonAsync(TimeZone timezone)
        {
            string apiUrl = "https://api.open-meteo.com/v1/forecast?latitude=32.22&longitude=-110.93&current_weather=true&hourly=temperature_2m,cloudcover,windspeed_10m,winddirection_10m,temperature_80m&temperature_unit=fahrenheit&windspeed_unit=mph&precipitation_unit=inch&timezone=America%2FDenver";

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                var jsonObject = JsonDocument.Parse(responseContent);

                double windSpeed = jsonObject.RootElement.GetProperty("current_weather").GetProperty("windspeed").GetDouble();
                double temperature = jsonObject.RootElement.GetProperty("current_weather").GetProperty("temperature").GetDouble();
                double windDirection = jsonObject.RootElement.GetProperty("current_weather").GetProperty("winddirection").GetDouble();

                return new double[] { temperature, windSpeed, windDirection };
            }
            else
            {
                throw new Exception($"Error retrieving weather data: {response.ReasonPhrase}");
            }

        }
    }
}
