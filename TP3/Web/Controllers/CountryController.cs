using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;
using Services.DTO;

namespace Web.Controllers
{
    public class CountryController : Controller
    {
        private CountryServices services = new CountryServices();

        // GET: Country
        public ActionResult Index()
        {
            var countries = services.ListAll();
            return View(countries);
        }

        // GET: Country/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
        [HttpPost]
        public ActionResult Create(CountryDTO country)
        {
            try
            {
                this.services.Create(country); 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Country/Edit/5
        [HttpGet]
        public ActionResult Edit(string name)
        {
            ViewBag.name = name;
            return View();
        }

        // POST: Country/Edit/5
        public ActionResult Edit(string country, string name)
        {
            try
            {
                this.services.Update(country, name);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Country/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Country/Delete/5
        [HttpPost]
        public ActionResult Delete(string country)
        {
            try
            {
                this.services.Delete(this.services.CreateFromString(country));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
