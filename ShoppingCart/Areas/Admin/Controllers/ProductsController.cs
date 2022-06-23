using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Infrastructure;

namespace ShoppingCart.Areas.Admin.Controllers
{
        [Area("Admin")]
        public class ProductsController : Controller
        {
                private readonly DataContext _context;

                public ProductsController(DataContext context)
                {
                        _context = context;
                }

                public async Task<IActionResult> Index(int p = 1)
                {
                        int pageSize = 3;
                        ViewBag.PageNumber = p;
                        ViewBag.PageRange = pageSize;
                        ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.Products.Count() / pageSize);

                        return View(await _context.Products.OrderByDescending(p => p.Id)
                                                                                        .Include(p => p.Category)
                                                                                        .Skip((p - 1) * pageSize)
                                                                                        .Take(pageSize)
                                                                                        .ToListAsync());
                }
        }
}