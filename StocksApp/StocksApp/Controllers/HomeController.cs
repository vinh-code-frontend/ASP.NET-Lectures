using Microsoft.AspNetCore.Mvc;
using StocksApp.Services;

namespace StocksApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyService _myService;
        public HomeController(MyService myService)
        {
            _myService = myService;
        }
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            await _myService.method();
            return View();
        }
    }
}
