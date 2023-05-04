using bankingSystemMVC.Models;
using Microsoft.AspNetCore.Mvc;
using bankingSystemMVC.Models;
namespace bankingSystemMVC.Controllers
{
    public class AccountsController : Controller
    {
        Accounts accObj = new Accounts();
        public IActionResult DisplayAccountList()
        {
            ViewBag.accList = accObj.GetAccounts();
            return View();
        }
        //create a view based on it and display the data in table

        public IActionResult GetAccountById()
        {
            ViewBag.errMessage = "";
            return View();
        }

        [HttpPost]
        public IActionResult GetAccountById(int id)
        {
            try
            {
                var acc = accObj.GetAccountById(id);
                ViewBag.acc = acc;
                return View();
            }
            catch (Exception es)
            {
                ViewBag.errMessage = es.Message;
                return View();
            }
        }

        public IActionResult AccNewAccount()
        {
            ViewBag.addResult = "";
            return View();
        }

        [HttpPost]
        public IActionResult AccNewAccount(Accounts newacc)
        {
            ViewBag.addResult =  accObj.AddNewAccount(newacc);
            return View();
        }

    }
}
