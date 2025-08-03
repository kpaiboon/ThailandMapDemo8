using Microsoft.AspNetCore.Mvc;

namespace MapApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewBag.LongdoApiKey = _configuration["Longdo:ApiKey"];
            return View();
        }
    }
}