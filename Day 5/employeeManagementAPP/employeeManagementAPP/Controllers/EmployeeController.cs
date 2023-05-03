using Microsoft.AspNetCore.Mvc;
using employeeManagementAPP.Models;
namespace employeeManagementAPP.Controllers
{
    public class EmployeeController : Controller
    {



        EmployeeModel eObj = new EmployeeModel(); //this is bad, we will use DI instead



        public IActionResult EmployeeList()
        {
            ViewBag.eList = eObj.GetAllEmployees();
            return View();
        }
    }
}
