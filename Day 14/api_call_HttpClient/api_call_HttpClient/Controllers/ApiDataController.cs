using Microsoft.AspNetCore.Mvc;
using api_call_HttpClient.Models;
namespace api_call_HttpClient.Controllers
{
    public class ApiDataController : Controller
    {
                PostModel _pObj; //use DI

        public ApiDataController(PostModel pObj)
        {
            _pObj = pObj;
        }


        public IActionResult PostData()
        {
            ViewBag.post = "";
            return View();
        }

        [HttpPost]
        public IActionResult GetPostData()
        {
            ViewBag.post = _pObj.GetPostData();
            return View("PostData");
        }
    }
}


