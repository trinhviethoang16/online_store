using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using ProjectOnlineStore.Models;
using ProjectOnlineStore.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectOnlineStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;

        public CartController(ILogger<ProductController> logger, AppDbContext appDbContext, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _appDbContext = appDbContext;
            _userManager = userManager;
        }

        /// Thêm sản phẩm vào cart
        [Route("addcart/{productid:int}", Name = "addcart")]
        public IActionResult AddToCart([FromRoute] int productid)
        {
            var product = _appDbContext.Products
                            .Where(p => p.Id == productid)
                            .FirstOrDefault();
            if (product == null)
            {
                return NotFound("Không có sản phẩm");
            }

            //Xử lý đưa vào Cart ...
            var cart = GetCartItems();
            var cartItem = cart.Find(p => p.Product.Id == productid);
            if (cartItem != null)
            {
                //Đã tồn tại, tăng thêm 1
                cartItem.Quantity++;
            }
            else
            {
                //Thêm mới
                cart.Add(new CartItem() { Quantity = 1, Product = product });
            }
            //remains product
            //...

            // Lưu cart vào Session
            SaveCartSession(cart);
            // Chuyển đến trang hiện thị Cart
            return RedirectToAction(nameof(Cart));
        }

        /// xóa item trong cart
        [Route("/removecart/{productid:int}", Name = "removecart")]
        public IActionResult RemoveCart([FromRoute] int productid)
        {

            var cart = GetCartItems();
            var cartItem = cart.Find(p => p.Product.Id == productid);
            if (cartItem != null)
            {
                cart.Remove(cartItem);
            }
            // Lưu cart vào Session
            SaveCartSession(cart);
            return RedirectToAction(nameof(Cart));
        }

        // Cập nhật
        [Route("/updatecart", Name = "updatecart")]
        [HttpPost]
        public IActionResult UpdateCart([FromForm] int productid, [FromForm] int quantity)
        {
            // Cập nhật Cart thay đổi số lượng quantity ...
            var cart = GetCartItems();
            var cartItem = cart.Find(p => p.Product.Id == productid);
            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
            }
            //remains product
            //...

            // Lưu cart vào Session
            SaveCartSession(cart);
            // Trả về mã thành công (không có nội dung gì - chỉ để Ajax gọi)
            return Ok();
        }


        // Hiện thị giỏ hàng
        [Route("/cart", Name = "cart")]
        public IActionResult Cart()
        {
            return View(GetCartItems());
        }

        [Authorize]
        [Route("/checkout", Name = "checkout")]
        public async Task<IActionResult> CheckOut(string id, int total)
        {
            // Xử lý khi đặt hàng
            var cart = GetCartItems();
            Order _order = new Order();
            _order.CreateAt = DateTime.Now;
            var user = await _userManager.FindByIdAsync(id);
            _order.UserId = user.Id;
            _order.UserName = user.UserName;
            _order.Total = total;
            _appDbContext.Orders.Add(_order);
            _appDbContext.SaveChanges();
            foreach (var item in cart)
            {
                OrderProduct _OrderDetail = new OrderProduct();
                _OrderDetail.ProductId = item.Product.Id;
                _OrderDetail.OrderId = _order.Id;
                _OrderDetail.Quantity = item.Quantity;
                double price = item.Product.Price - (item.Product.Price * (item.Product.Sales / 100));
                _OrderDetail.Price = price * item.Quantity;
                _appDbContext.OrderProducts.Add(_OrderDetail);
            }
            _appDbContext.SaveChanges();
            cart.Clear();
            ClearCart();
            return RedirectToAction("Success", "Cart");
        }

        // Key lưu chuỗi json của Cart
        public const string CARTKEY = "CARTKEY";

        // Lấy cart từ Session (danh sách CartItem)
        List<CartItem> GetCartItems()
        {
            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
            }
            return new List<CartItem>();
        }

        // Xóa cart khỏi session
        public void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(CARTKEY);
        }

        // Lưu Cart (Danh sách CartItem) vào session
        void SaveCartSession(List<CartItem> ls)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(ls);
            session.SetString(CARTKEY, jsoncart);
        }

        //Giao diện hiển thị thông báo
        public ActionResult Success()
        {
            List<Order> orders = _appDbContext.Orders.ToList();
            return View(orders);
        }
    }
}
