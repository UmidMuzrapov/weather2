using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using Weather.Shared.Models.Main;

namespace Weather.Client.Services
{
    public class WeatherService : IWeatherService
    {
        private HttpClient _httpClient;
        private NavigationManager _navigationManager;
        private List<DayModel> _days;
        private List<HourModel> _today;
        private HourModel _current;

        private Weather.Shared.Models.Main.Weather? weather { get; set; }
        private Location? Location { get; set; }

        public Weather.Shared.Models.Main.Weather? GetWeather()
        {
            return weather;
        }

        public async Task SetWeather()
        {
            weather=await GetWeatherDataForTucsonAsync(Location);
            CreateListOfDays();
            GetTodayInfo();
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
            for (int i = 0; i<weather.WeatherDaily.time.Length; i++)
            {
                _days.Add(new DayModel
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
        private void GetTodayInfo()
        {
            _today =new List<HourModel>();

            for (int i = 48; i<73; i++)
            {
                _today.Add(new HourModel
                {
                    Time=weather.WeatherHourly.time[i],
                    Temperature2M=weather.WeatherHourly.temperature_2m[i],
                    RelativeHumidity=weather.WeatherHourly.relativehumidity_2m[i],
                    Rain=weather.WeatherHourly.rain[i],
                    Snowfall=weather.WeatherHourly.rain[i],
                    CloudCover=weather.WeatherHourly.cloudcover[i],
                    WindDirection=weather.WeatherHourly.winddirection_10m[i],
                    UVIndex=weather.WeatherHourly.uv_index[i],
                    IsDay=weather.WeatherHourly.is_day[i]

                });

                if (weather.WeatherHourly.time[i].Hour.Equals(DateTime.Now.Hour))
                {
                    _current=new HourModel
                    {
                        Time=weather.WeatherHourly.time[i],
                        Temperature2M=weather.WeatherHourly.temperature_2m[i],
                        RelativeHumidity=weather.WeatherHourly.relativehumidity_2m[i],
                        Rain=weather.WeatherHourly.rain[i],
                        Snowfall=weather.WeatherHourly.rain[i],
                        CloudCover=weather.WeatherHourly.cloudcover[i],
                        WindDirection=weather.WeatherHourly.winddirection_10m[i],
                        UVIndex=weather.WeatherHourly.uv_index[i],
                        IsDay=weather.WeatherHourly.is_day[i]

                    };
                }

            }
        }

        public async Task<Weather.Shared.Models.Main.Weather> GetWeatherDataForTucsonAsync(Location location)
        {
            Timezone timezone = await GetTimeZone(location);

            string apiUrl = $"https://api.open-meteo.com/v1/forecast?latitude={location.Latitude}&longitude={location.Longitude}&hourly=temperature_2m,relativehumidity_2m,rain,snowfall,cloudcover,windspeed_10m,winddirection_10m,uv_index,is_day&daily=temperature_2m_max,temperature_2m_min,sunrise,sunset,uv_index_max,precipitation_hours,windspeed_10m_max&current_weather=true&temperature_unit=fahrenheit&windspeed_unit=mph&precipitation_unit=inch&past_days=2&forecast_days=4&timezone={timezone.TimezoneP}";

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                var jsonObject = JsonDocument.Parse(responseContent);
                Weather.Shared.Models.Main.Weather weather = new Weather.Shared.Models.Main.Weather();

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

        List<HourModel> IWeatherService.GetTodayInfo()
        {
            return _today;
        }

        public HourModel GetCurrentInfo()
        {
            return _current;
        }
    }
}
