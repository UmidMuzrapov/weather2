using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using Weather.Client;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using Weather.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => { return new HttpClient() { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) }; });

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddSingleton<IIconChooser, IconChooser>();
builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme
);

builder.Services.AddScoped<DialogService>();
builder.Services.AddSingleton<IWeatherService, WeatherService>();

await builder.Build().RunAsync();
