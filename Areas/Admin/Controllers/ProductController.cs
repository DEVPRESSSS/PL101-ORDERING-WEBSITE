using Microsoft.AspNetCore.Mvc;

namespace ONLINE_BUSINESS_PROJECT_FOR_PL101_SUBJECT.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {

        //[HttpGet]
        public IActionResult Products()
        {
            return View();
        }
    }
}
