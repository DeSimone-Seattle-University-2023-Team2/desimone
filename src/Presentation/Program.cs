
using Application.Configuration;
using Infrastructure;
using Presentation.Components;
using Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(config);

builder.Services.AddHttpClient();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    await app.InitializeDatabaseAsync();
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
    .AddInteractiveServerRenderMode();

app.Run();