using Microsoft.AspNetCore.Mvc;

namespace ViewController_Communication.Controllers
{
    public class GreetingsController : Controller
    {
      
        public IActionResult Greet()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Greet(string guestName)
        {
            string message = "";
            bool hasError = false;

            if (guestName == "" || guestName == null)
            {
                hasError = true;
                message = "Name cannot be left blank";
            }
            else if (guestName.Length < 3)
            {
                hasError = true;
                message = "Please enter a valid Name";
             
            }
          
            else
            {
                message  = "Hello and welcome to the development world of MVC - " + guestName + " create better web apps";
            }
            ViewBag.hasError = hasError;
            ViewBag.greetMessage = message;
            return View();
        }


    }
}
