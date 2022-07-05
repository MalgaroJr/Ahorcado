using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using UI;
using UI.Repository.IServices;
using UI.Repository;
using Blazored.LocalStorage;
using UI.Providers;
using Microsoft.AspNetCore.Components.Authorization;
using UI.Handlers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(/*link de la api cuando este*/) });

if (builder.HostEnvironment.IsDevelopment() || builder.HostEnvironment.IsStaging())
{
    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7092/") });
    builder.Services.AddScoped<IUserService, UserHardcodedService>();
    builder.Services.AddScoped<IJuegoService, JuegoHardcodedService>();
} 
if(builder.HostEnvironment.IsProduction())
{
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IJuegoService,JuegoService>();
}

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();
builder.Services
.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
builder.Services.AddScoped<CookieHandler>();

/*
#region Prueba de Base de datos
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7092/") });
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IJuegoService, JuegoService>();
#endregion
*/
await builder.Build().RunAsync();
