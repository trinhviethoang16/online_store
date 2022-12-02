using Microsoft.AspNetCore.Mvc;
using ProjectOnlineStore.Data;
using ProjectOnlineStore.Models;
using System.Diagnostics;

namespace ProjectOnlineStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly AppDbContext _appDbContext;

        public ProductController(ILogger<ProductController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            List<Product> productList = _appDbContext.Products.ToList();
            return View(productList);
        }

        public IActionResult Detail(int id)
        {
            Product product = _appDbContext.Products.Where(x => x.Id == id).FirstOrDefault();
            return View(product);
        }

        public IActionResult Category(int id)
        {
            //For homepage product ? ? ? ? ? ? ? ? ? ? add 1 more product for homepage product
            List<Product> productList = _appDbContext.Products.ToList();

            List<Product> products = _appDbContext.Products.Where(x => x.Category.Id == id).ToList();
            ViewBag.CategoryName = _appDbContext.Categories.FirstOrDefault(x => id == x.Id).Name;
            return View(products);
        }
    }
}
