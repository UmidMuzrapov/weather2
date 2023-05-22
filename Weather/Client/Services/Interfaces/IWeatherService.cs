using Microsoft.AspNetCore.Components;
using Weather.Shared.Models.Main;

namespace Weather.Client.Services
{
    public interface IWeatherService
    {
        public Weather.Shared.Models.Main.Weather? GetWeather();

        public Task SetWeather(Location location);

        public void SetDependencies(HttpClient http, NavigationManager navigation);

        public Location GetLocation();

        public List<DayModel> GetDaysInfo();

        public List<HourModel> GetTodayInfo();

        public HourModel GetCurrentInfo();

    }
}
