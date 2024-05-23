using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ServiceStack.Blazor;
using Blazorise;
using Blazorise.Bulma;
using Blazorise.Icons.FontAwesome;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Configure JsonApiClient
builder.Services.AddBlazorApiClient(builder.Configuration["ApiBaseUrl"] ?? builder.HostEnvironment.BaseAddress);

// Blazorise & Bulma.
builder.Services
    .AddBlazorise(options => { options.Immediate = true; })
    .AddBulmaProviders()
    .AddFontAwesomeIcons();

await builder.Build().RunAsync();
