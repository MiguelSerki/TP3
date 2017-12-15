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

        private ShiftServices services = new ShiftServices();

        // GET: Shifts
        public ActionResult Index()
        {
            var services = new ShiftServices();
            var ShiftList = services.GetShifts(); // refactor para que no llame a todo junto.
            return View(ShiftList);
        }

        [HttpPost]
        public ActionResult ShiftMenu(int ID)
        {
            var shift = this.services.GetShiftByID(ID);
            if (shift.EmployeeList.Any())
                return View(shift);
            return RedirectToAction("Index");
        }
    }
}
