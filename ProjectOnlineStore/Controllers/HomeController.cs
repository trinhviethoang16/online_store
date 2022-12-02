using Microsoft.AspNetCore.Mvc;
using ProjectOnlineStore.Data;
using ProjectOnlineStore.Models;
using System.Diagnostics;

namespace ProjectOnlineStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _appDbContext;

        public HomeController(ILogger<HomeController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            List<Product> productList = _appDbContext.Products.ToList();
            return View(productList);
        }

        public IActionResult AllProduct()
        {
            List<Product> productList = _appDbContext.Products.ToList();
            return View(productList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}