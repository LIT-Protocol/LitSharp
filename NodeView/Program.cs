using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NodeView;
using Nethereum.Web3;
using Blazored.LocalStorage;
using MetaMask.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<Services.Metrics.Poller>();
builder.Services.AddScoped<Radzen.DialogService>();
builder.Services.AddMetaMaskBlazor();
await builder.Build().RunAsync();

