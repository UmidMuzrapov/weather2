﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Text.Json;
using Weather.Shared.Models.Main;

namespace Weather.Server.Controllers
{
    [Route("api/timezone")]
    [ApiController]
    public class TimezoneController
    {
        private readonly HttpClient _httpClient;

        public TimezoneController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        [HttpPost]
        public async System.Threading.Tasks.Task<Timezone> GetTimeZone(Location location)
        {
            string apiUrl = System.String.Format("https://api.ipgeolocation.io/timezone?apiKey={apikey}&lat={0:g}&long={0:g}", location.Latitude, location.Longitude);

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();

                // Parse the JSON response
                var jsonObject = JsonDocument.Parse(responseContent);

                // Get the latest values for each parameter for Tucson
                string timezone= jsonObject.RootElement.GetProperty("timezone").ToString();
                string date = jsonObject.RootElement.GetProperty("date").ToString();
                string time_24 = jsonObject.RootElement.GetProperty("time_24").ToString();
                string time_12 = jsonObject.RootElement.GetProperty("time_12").ToString();

                Timezone result = new Timezone {
                
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
