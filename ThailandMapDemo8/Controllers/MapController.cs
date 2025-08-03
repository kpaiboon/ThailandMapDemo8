using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace ThailandMapDemo8.Controllers
{
    public class MapController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public MapController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetLongdoRoute(string from, string to)
        {
            var client = _httpClientFactory.CreateClient();
            var apiKey = _configuration["Longdo:ApiKey"];
            var url = $"https://api.longdo.com/RouteService/json?key={apiKey}&from={from}&to={to}";
            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return BadRequest("Failed to fetch route");

            var json = await response.Content.ReadAsStringAsync();
            return Content(json, "application/json");
        }
    }
}