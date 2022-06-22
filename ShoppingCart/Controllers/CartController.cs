using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Infrastructure;
using ShoppingCart.Models;
using ShoppingCart.Models.ViewModels;

namespace ShoppingCart.Controllers
{
        public class CartController : Controller
        {
                private readonly DataContext _context;

                public CartController(DataContext context)
                {
                        _context = context;
                }

                public IActionResult Index()
                {
                        List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

                        CartViewModel cartVM = new()
                        {
                                CartItems = cart,
                                GrandTotal = cart.Sum(x => x.Quantity * x.Price)
                        };

                        return View(cartVM);
                }
        }
}
