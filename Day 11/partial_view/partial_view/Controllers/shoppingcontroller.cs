using Microsoft.AspNetCore.Mvc;
using partial_view.Models.EF;

namespace partial_view.Controllers
{
    public class shoppingcontroller : Controller
    {

        ShoppingMvcdbContext _db; // we will use DI

        public shoppingcontroller(ShoppingMvcdbContext _context)
        {
            _db = _context;
        }
       
        public IActionResult Kids()
        {


            ViewBag.products = _db.KidsProducts.ToList();
            return View();
        }

        public IActionResult Mens()
        {
            ViewBag.products = _db.MensProducts.ToList();
            return View();
        }

        public IActionResult Womens()
        {
            ViewBag.products = _db.WomensProducts.ToList();
            return View();
        }


        public IActionResult Holiday()
        {
            ViewBag.products = _db.HolidayProducts.ToList();
            return View();
        }
    }
}
