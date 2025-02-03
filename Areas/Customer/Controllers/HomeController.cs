using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ONLINE_BUSINESS_PROJECT_FOR_PL101_SUBJECT.Data;
using ONLINE_BUSINESS_PROJECT_FOR_PL101_SUBJECT.Models;
using System.Diagnostics;

namespace ONLINE_BUSINESS_PROJECT_FOR_PL101_SUBJECT.Areas.Customer.Controllers
{
    [Area("Customer")]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            var productsList = _context.Products
                .Include(p => p.Category)
                .Include(p => p.ListOfProductImages)
                .Select(p => new ProductVM
                {
                    Product = p,
                    Category = p.Category,
                    ImageUrls = p.ListOfProductImages.Select(img => img.ImageUrl).ToList()
                })
                .ToList();

            return View(productsList);
        }

        public IActionResult Products()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var productsList = _context.Products
                .Include(p => p.Category)
                .Select(p => new
                {
                    p.ProductID,
                    p.Name,
                    p.Description,
                    p.Price,
                    p.Size,
                    p.Stock,
                    p.CreatedAt,
                    CategorName = p.Category.Name,
                    Images = p.ListOfProductImages.Select(img => img.ImageUrl).ToList()
                })
                .ToList();

            return Json(new { data = productsList });
        }


        public IActionResult ProductDetails( string id)
        {


            if (string.IsNullOrEmpty(id))
            {

                TempData["Error"] = "Product ID not found";

            }

            var productId= _context.Products.FirstOrDefault(x=>x.ProductID==id);

            if(productId==null)
            {
                TempData["Error"] = "Product ID not found";


            }

            return View(productId);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
