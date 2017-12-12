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
        // GET: Shifts
        public ActionResult Index()
        {
            var services = new ShiftServices ();
            var ShiftList = services.GetShifts();
            return View(ShiftList); //preguntar a Kevin del futuro.
        }

        // GET: Shifts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Shifts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shifts/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Shifts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Shifts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Shifts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Shifts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
