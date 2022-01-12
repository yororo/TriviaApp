using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TriviaApp.UI.Model.Interface;
using TriviaApp.UI.Service.Service;
using TriviaApp.UI.Web;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<ICoreService, CoreServiceApi>();

// TODO: move URI to configuration
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7016") });

await builder.Build().RunAsync();
