using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Infrastructure;

namespace ShoppingCart.Areas.Admin.Controllers
{
        [Area("Admin")]
        public class ProductsController : Controller
        {
                private readonly DataContext _context;
                private readonly IWebHostEnvironment _webHostEnvironment;


                public ProductsController(DataContext context, IWebHostEnvironment webHostEnvironment)
                {
                        _context = context;
                        _webHostEnvironment = webHostEnvironment;
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

                public IActionResult Create()
                {
                        ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");

                        return View();
                }
        }
}