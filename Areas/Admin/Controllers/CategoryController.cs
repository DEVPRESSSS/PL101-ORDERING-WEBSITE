using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ONLINE_BUSINESS_PROJECT_FOR_PL101_SUBJECT.Data;
using ONLINE_BUSINESS_PROJECT_FOR_PL101_SUBJECT.Models;

namespace ONLINE_BUSINESS_PROJECT_FOR_PL101_SUBJECT.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            List<Category> categories = _context.Categories.ToList();
            return View(categories);
        }


		public IActionResult Create()
		{



			return View();
		}
		[HttpPost]
		public IActionResult Create(Category category)
		{


			if(category == null)
			{
				return Json(new { success = false, message = "Failed to insert category" });

			}
			string ID = $"CAT-{Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper()}";


			category.CategoryID = ID;
			_context.Categories.Add(category);
			_context.SaveChanges();

			TempData["Success"] = "Category added successfully";
			return RedirectToAction("Index");
		}

		public IActionResult Edit(string ID)
		{
			if (string.IsNullOrEmpty(ID))
			{
				return Json(new { success = false, message = "Category ID not found" });


			}

			Category? category = _context.Categories.FirstOrDefault(x => x.CategoryID == ID);
			if (category == null)
			{
				return Json(new { success = false, message = "Category ID not found" });

			}
	

			return View(category);


		}

		[HttpPost]
		public IActionResult Edit(Category category)
		{


			if (category == null)
			{
				return Json(new { success = false, message = "Category ID not found" });

			}
			if (ModelState.IsValid)
			{

				category.CreatedAt = DateOnly.FromDateTime(DateTime.Now);
				_context.Update(category);
				_context.SaveChanges();
				TempData["success"] = "Updated Successfully";
				return RedirectToAction("Index");


			}


		

			return View();


		}

		[HttpDelete]
        public IActionResult Delete(string ID)
        {

            if(string.IsNullOrEmpty(ID))
            {
				return Json(new { success = false, message = "Category ID not found" });
			}

            Category? category = _context.Categories.FirstOrDefault(x=>x.CategoryID ==  ID);
            if(category == null)
            {
				return Json(new { success = false, message = "Category ID not found" });

			}
			_context.Categories.Remove(category);
			_context.SaveChanges();

			return Json(new { success = true, message = "Category deleted successfully" });

		}



		//This region fetch the API DATA from my database

		[HttpGet]
		public IActionResult GetAll()
		{

			List<Category> _categories = _context.Categories.ToList();

			return Json(new { data = _categories });
		}
	}
}
