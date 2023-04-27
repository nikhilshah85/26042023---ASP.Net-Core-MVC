using Microsoft.AspNetCore.Mvc;

namespace shoppingAPP.Controllers
{
    public class productsController : Controller
    {
      
        public IActionResult ProductList()
        {
            //collect data from model
            return View();
        }

        public IActionResult TopSellingProducts()
        {
            return View();
        }

        public IActionResult Sale()
        {
            return View();
        }

        public IActionResult AppSummary()
        {
            ViewBag.totalProducts = 10;
            ViewBag.developer = "Nikhil Shah";
            ViewBag.isAppLive = true;
            ViewBag.projectCost = 2.5;

            List<string> teamMembers = new List<string>()
            {
                "Nikhil", "Akshay","Rahul","Rohan","Roshan","Mohan","Minaxi"
            };

            ViewBag.team = teamMembers;

            return View();
        }

    }
}
