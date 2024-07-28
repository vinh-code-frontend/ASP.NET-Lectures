var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsStaging() || app.Environment.IsEnvironment("CustomEnv"))
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();

// Use power shell command to set env $Env:ASPNETCORE_ENVIRONMENT="Env name"
// dotnet run --no-launch-profile