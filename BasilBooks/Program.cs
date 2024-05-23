using BasilBooks.Client.Pages;
using BasilBooks.Components;
using BasilBooks.ServiceInterface;
using ServiceStack;

var builder = WebApplication.CreateBuilder(args);

// Add ServiceStack services.
builder.Services.AddServiceStack(typeof(MyServices).Assembly);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Use ServiceStack
app.UseServiceStack(new AppHost());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BasilBooks.Client._Imports).Assembly);

app.MapFallbackToFile("index.html");

app.Run();

public class AppHost : AppHostBase
{
    public AppHost() : base("BasilBooks", typeof(MyServices).Assembly)
    {
    }

    public override void Configure(Funq.Container container)
    {
        // Register your dependencies here if needed
        // container.Register<IService>(new ServiceImplementation());
    }
}
