using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bankingAPP.Controllers
{
    [Authorize]
    public class BankingController : Controller
    {

        [AllowAnonymous]
        public IActionResult AboutBanking()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Accounts()
        {
            List<string> accTypes = new List<string>() { "Savings", "Current", "PF", "Loan" };
            ViewBag.accList = accTypes;
            return View();
        }

        public IActionResult DownloadStatement()
        {
            return View();
        }
        public IActionResult TransferFunds()
        {
            return View();
        }


    }
}
