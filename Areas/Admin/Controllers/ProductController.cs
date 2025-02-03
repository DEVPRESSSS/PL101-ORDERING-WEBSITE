using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ONLINE_BUSINESS_PROJECT_FOR_PL101_SUBJECT.Data;
using ONLINE_BUSINESS_PROJECT_FOR_PL101_SUBJECT.Models;
using System.Net;
using static System.Reflection.Metadata.BlobBuilder;

namespace ONLINE_BUSINESS_PROJECT_FOR_PL101_SUBJECT.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ProductController : Controller
    {

        private readonly ApplicationDbContext _context;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public ProductController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
			_webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {

			List<Products> productsList = _context.Products
			 .Include(p => p.Category)
			 .Include(p => p.ListOfProductImages)
			 .ToList();

			return View(productsList);
        }

        public IActionResult UpsertProducts()
        {

            
			ViewBag.CategoryList = _context.Categories.Select(c => new SelectListItem
            {

                Value = c.CategoryID,
                Text= c.Name,


            }).ToList();
         
            return View();
        }

        [HttpPost]
        public IActionResult UpsertProducts(Products products, List<IFormFile>? files)
        {

               if(products== null)
                {
                     return NotFound();
                }

          
                if(ModelState.IsValid)
                {
                     string ID = $"PROD-{Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper()}";
                     products.ProductID = ID;
                     products.CreatedAt = DateOnly.FromDateTime(DateTime.Now);

					_context.Products.Add(products);

					string wwwRooot = _webHostEnvironment.WebRootPath;
					string productPath = @"Images\ProductImg-" + products.ProductID;
					string finalPath = Path.Combine(wwwRooot, productPath);


					//Check if the directory exist

					if (!Directory.Exists(finalPath))
					{
						Directory.CreateDirectory(finalPath);
					}

					if(files != null){


							foreach (IFormFile file in files)
							{
								string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
								using (var fileStream = new FileStream(Path.Combine(finalPath, fileName), FileMode.Create))
								{
									file.CopyTo(fileStream);
								}

							string imageID = $"PROD-{Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper()}";

							ProductImages productImages = new()
							{

								ImageId= imageID,
								ImageUrl = @"\" + productPath + @"\" + fileName,
								ProductID= products.ProductID
							};

							if (products.ListOfProductImages == null)
							{
									products.ListOfProductImages = new List<ProductImages>();
							}


							products.ListOfProductImages.Add(productImages); 
							_context.ProductImages.Add(productImages);



							}

					_context.SaveChanges();
					TempData["Success"] = "Product added successfully";
					return RedirectToAction("Index");

					}



				


				  
                }
             

                 ViewBag.CategoryList = _context.Categories.Select(c => new SelectListItem
                    {

                        Value = c.CategoryID,
                        Text = c.Name,


                 }).ToList();
                
            

            return View();
        }



        public IActionResult Edit(string ID)
        {
			if (string.IsNullOrEmpty(ID))
			{
				return Json(new { success = false, message = "Product ID not found" });


			}

			Products? products = _context.Products.FirstOrDefault(x => x.ProductID == ID);
			if (products == null)
			{
				return Json(new { success = false, message = "Product ID not found" });

			}
			ViewBag.CategoryList = _context.Categories.Select(c => new SelectListItem
			{

				Value = c.CategoryID,
				Text = c.Name,


			}).ToList();

			return View(products);


		}

		[HttpPost]
		public IActionResult Edit(Products products)
		{
			

			if (products == null)
			{
				return Json(new { success = false, message = "Product ID not found" });

			}
			if (ModelState.IsValid)
			{

				products.CreatedAt = DateOnly.FromDateTime(DateTime.Now);
				_context.Update(products);
				_context.SaveChanges();
				TempData["success"] = "Updated Successfully";
				return RedirectToAction("Index");


			}


			ViewBag.CategoryList = _context.Categories.Select(c => new SelectListItem
			{

				Value = c.CategoryID,
				Text = c.Name,


			}).ToList();

			return View(products);


		}

		[HttpDelete]
		public IActionResult Delete(string ID)
		{
			if (string.IsNullOrEmpty(ID))
			{
				return Json(new { success = false, message = "Product ID not found" });
			}

			try
			{
				Products? product = _context.Products.FirstOrDefault(x => x.ProductID == ID);

				if (product == null)
				{
					return Json(new { success = false, message = "Product ID not found" });
				}
				else
				{
					_context.Products.Remove(product);
					_context.SaveChanges();

					return Json(new { success = true, message = "Record deleted successfully" });
				}
			}
			catch
			{
				return Json(new { success = false, message = "An error occurred while deleting the product." });
			}
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

	}
}
