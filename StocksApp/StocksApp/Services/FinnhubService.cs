using StocksApp.ServiceContracts;
using System.Text.Json;

namespace StocksApp.Services
{
    public class FinnhubService : IFinnhubService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public FinnhubService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        public async Task<Dictionary<string, object>?> GetStockPriceQoute(string stockSymbol)
        {
            string token = _configuration["FinnhubToken"];
            using (HttpClient httpClient = _httpClientFactory.CreateClient())
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
                {
                    RequestUri = new Uri($"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token={token}"),
                    Method = HttpMethod.Get,
                };
                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                Stream stream = httpResponseMessage.Content.ReadAsStream();

                StreamReader reader = new StreamReader(stream);
                string response = reader.ReadToEnd();
                Dictionary<string, object>? dictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(response);

                if (dictionary == null)
                {
                    throw new InvalidOperationException("No response from finnhub server");
                }
                if (dictionary.ContainsKey("error"))
                {
                    throw new InvalidOperationException(Convert.ToString(dictionary["error"]));
                }
                return dictionary;
            }
        }
    }
}
