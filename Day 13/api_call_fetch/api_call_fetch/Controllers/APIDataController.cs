using Microsoft.AspNetCore.Mvc;

namespace api_call_fetch.Controllers
{
    public class APIDataController : Controller
    {
        public IActionResult PostData()
        {
            return View();
        }

        public IActionResult CommentsData()
        {
            return View();
        }
    }
}
