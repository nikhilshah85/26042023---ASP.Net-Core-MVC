using Microsoft.AspNetCore.Mvc;
using shoppingAPP.Models;
namespace shoppingAPP.Controllers
{
    public class ProductsController : Controller
    {

        //this is not a good code, we will use DI here
        Products pObj = new Products(); 

        public IActionResult ProductList()
        {
            ViewBag.pCategories = pObj.GetProductCategories();
            ViewBag.pList = pObj.GetAllProducts();
            return View();
        }





    }
}
