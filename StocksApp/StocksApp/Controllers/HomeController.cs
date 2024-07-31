using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StocksApp.Models;
using StocksApp.ServiceContracts;

namespace StocksApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFinnhubService _myService;
        private readonly IOptions<TradingOptions> _tradingOption;

        public HomeController(IFinnhubService myService, IOptions<TradingOptions> tradingOption)
        {
            _myService = myService;
            _tradingOption = tradingOption;
        }
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            string defaultSymbol = _tradingOption.Value.DefaultStockSymbol ?? "";

            Dictionary<string, object>? dictionary = await _myService.GetStockPriceQoute(defaultSymbol);
            if (dictionary == null)
            {
                return View(null);
            }
            Stock stock = new Stock()
            {
                StockSymbol = defaultSymbol,
                CurrentPrice = Convert.ToDouble(dictionary["c"].ToString()),
                HighestPrice = Convert.ToDouble(dictionary["h"].ToString()),
                LowestPrice = Convert.ToDouble(dictionary["l"].ToString()),
                OpenPrice = Convert.ToDouble(dictionary["o"].ToString()),
            };
            return View(stock);
        }
    }
}
