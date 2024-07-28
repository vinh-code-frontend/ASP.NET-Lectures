using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace DIExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICitiesService _citiesServices1;
        private readonly ICitiesService _citiesServices2;
        private readonly ICitiesService _citiesServices3;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        // constructor
        public HomeController(
            ICitiesService citiesService1,
            ICitiesService citiesService2,
            ICitiesService citiesService3,
            IServiceScopeFactory serviceScopeFactory
        )
        {
            _citiesServices1 = citiesService1;
            _citiesServices2 = citiesService2;
            _citiesServices3 = citiesService3;
            _serviceScopeFactory = serviceScopeFactory;
        }
        [Route("/")]
        public IActionResult Index()
        {
            List<string> cities = _citiesServices1.GetCities();
            ViewBag.Service_1 = _citiesServices1.ServiceInstanceId;
            ViewBag.Service_2 = _citiesServices2.ServiceInstanceId;
            ViewBag.Service_3 = _citiesServices3.ServiceInstanceId;

            using (IServiceScope scope = _serviceScopeFactory.CreateScope())
            {
                // Inject CitiesService
                ICitiesService citiesService = scope.ServiceProvider.GetRequiredService<ICitiesService>();
                ViewBag.Service_Scoped = citiesService.ServiceInstanceId;

                // DB work
            } //end of scope; it calls CitiesService.Dispose()

            return View(cities);
        }
        // Use this if only this method of the class need this service, no need for other methods
        /*public IActionResult Index2([FromServices] ICitiesService citiesService)
        {
            List<string> cities = citiesService.GetCities();
            return View(cities);
        }*/
    }
}
