using ConfigurationExample.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.Configure<MasterKeys>(builder.Configuration.GetSection("MasterKeys"));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.Map("/config", async context =>
    {
        await context.Response.WriteAsync(app.Configuration["MyCustomKey"] + "\n");
        await context.Response.WriteAsync(app.Configuration.GetValue<string>("MyCustomKey") + "\n");
        await context.Response.WriteAsync(app.Configuration.GetValue<int>("DoesNotExistKey", 10) + "\n"); // => add defaut value: 10
    });
});

// Load MyOwnConfig.json
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("MyOwnConfig.json", optional: true, reloadOnChange: true);
});

app.MapControllers();

app.Run();

// To use user secrets config 
// using windows PowerShell
// Command: dotnet user-secrets init
// Usage: dotnet user-secrets set "key" "value" 
// Check: dotnet user-secrets list
// If project using Azure, can use Azure Key Vault for better security

// Order (from lowest to highest)
// appsettings.json => appsettings.EnvironmentName.json => User Secrets (Secret Manager) 
// => Environment Variables => Command Line Arguments
