using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ServiceStack.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Configure JsonApiClient
builder.Services.AddBlazorApiClient(builder.Configuration["ApiBaseUrl"] ?? builder.HostEnvironment.BaseAddress);

await builder.Build().RunAsync();
