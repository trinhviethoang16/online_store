using Microsoft.AspNetCore.Mvc;
using ProjectOnlineStore.Data;
using ProjectOnlineStore.Models;
using System.Diagnostics;
using System.Data;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace ProjectOnlineStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public ProductController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult AllProduct()
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
            ViewBag.CategoryName = _appDbContext.Categories.FirstOrDefault(x => id == x.Id).Name;
            List<Product> products = _appDbContext.Products.Where(x => x.Category.Id == id).ToList();
            return View(products);
        }
    }
}
