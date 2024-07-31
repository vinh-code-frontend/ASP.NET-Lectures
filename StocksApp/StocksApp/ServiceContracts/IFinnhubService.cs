namespace StocksApp.ServiceContracts
{
    public interface IFinnhubService
    {
        public Task<Dictionary<string, object>?> GetStockPriceQoute(string stockSymbol);
    }
}
