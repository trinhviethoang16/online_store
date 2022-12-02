using Microsoft.AspNetCore.Mvc;
using ProjectOnlineStore.Data;
using ProjectOnlineStore.Models;
using System.Diagnostics;

namespace ProjectOnlineStore.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _appDbContext;

        public AdminController(ILogger<HomeController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            List<Product> products = _appDbContext.Products.ToList();
            return View(products);
        }

        public IActionResult ProductManager()
        {
            List<Product> products = _appDbContext.Products.ToList();
            return View(products);
        }

        public IActionResult CategoryManager()
        {
            List<Category> categories = _appDbContext.Categories.ToList();
            return View(categories);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}