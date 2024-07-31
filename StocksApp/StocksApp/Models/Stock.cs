namespace StocksApp.Models
{
    public class Stock
    {
        /*   c: Current price
             d: Change
             dp: Percent change
             h: High price of the day
             l: Low price of the day
             o: Open price of the day
             pc: Previous close price */
        public string? StockSymbol { get; set; }
        public double CurrentPrice { get; set; }
        public double LowestPrice { get; set; }
        public double HighestPrice { get; set; }
        public double OpenPrice { get; set; }
    }
}
