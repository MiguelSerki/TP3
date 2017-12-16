using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;

namespace Web.Controllers
{
    public class ShiftsController : Controller
    {

        public ActionResult Index()
        {
            var services = new ShiftServices();
            var ShiftList = services.GetShifts();
            return View(ShiftList);
        }

        [HttpPost]
        public ActionResult ShiftMenu(int ID)
        {
            var services = new EmployeesServices();
            var list = services.GetAllFromShift(ID);
            if (list.Any())
            {
                return View(list);
            }
            return RedirectToAction("Index");
        }

        public ActionResult ShiftMenu()
        {
            return View();
        }
    }
}
