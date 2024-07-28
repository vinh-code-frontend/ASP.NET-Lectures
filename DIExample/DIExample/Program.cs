using Autofac;
using Autofac.Extensions.DependencyInjection;
using ServiceContracts;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Services.AddControllersWithViews();

/*builder.Services.Add(new ServiceDescriptor(
    typeof(ICitiesService),
    typeof(CitiesService),
    ServiceLifetime.Transient
));*/

//builder.Services.AddTransient<ICitiesService, CitiesService>();

//builder.Services.AddScoped<ICitiesService, CitiesService>();

//builder.Services.AddSingleton<ICitiesService, CitiesService>();

// Singleton: create only 1 service instance from the app init 
// Scoped: create only 1 service instance per request
// Transient: create new service every time it's called

builder.Host.ConfigureContainer<ContainerBuilder>((containerBuilder) =>
{
    //containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().InstancePerDependency(); //AddTransient
    containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().InstancePerLifetimeScope(); //AddScoped
    //containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().SingleInstance(); //AddSingleton
});
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
