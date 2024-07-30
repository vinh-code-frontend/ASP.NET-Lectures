using ConfigurationExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigurationExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly WeatherApiOptions _weatherApiOptionsConfigService;

        public HomeController(IConfiguration configuration, IOptions<WeatherApiOptions> weatherApiOptionsConfigService)
        {
            _configuration = configuration;
            _weatherApiOptionsConfigService = weatherApiOptionsConfigService.Value;
        }
        [Route("/")]
        public IActionResult Index()
        {
            string key = _configuration.GetValue("MyCustomKey", "0000-0000");
            ViewBag.Key = key;

            IConfiguration weatherApiConfig = _configuration.GetSection("WeatherApi");
            ViewBag.ClientID = weatherApiConfig["ClientID"];
            ViewBag.ClientSecret = weatherApiConfig["ClientSecret"];

            // Options Pattern
            WeatherApiOptions weatherOptions = _configuration.GetSection("WeatherApi").Get<WeatherApiOptions>();
            ViewBag.ClientID2 = weatherOptions.ClientID;
            ViewBag.ClientSecret2 = weatherOptions.ClientSecret;

            // Services
            ViewBag.ClientID3 = _weatherApiOptionsConfigService.ClientID;
            ViewBag.ClientSecret3 = _weatherApiOptionsConfigService.ClientSecret;

            return View();
        }
    }
}