global using StudentsBlazorWebAssembly.Shared;
global using System.Net.Http.Json;
global using StudentsBlazorWebAssembly.Client.Services.StudentService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StudentsBlazorWebAssembly.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IStudentService, StudentService>();

await builder.Build().RunAsync();
