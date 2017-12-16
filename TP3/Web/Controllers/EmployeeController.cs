using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services.DTO;
using Services;

namespace Web.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeesServices _EmployeesServices;

        public EmployeeController()
        {
            _EmployeesServices = new EmployeesServices();
        }
           
        
        

        
        public ActionResult Details()
        {
            return View(_EmployeesServices.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeDTO employee)

        {
            _EmployeesServices.Create(employee);
            return View("Details", _EmployeesServices.GetAll());

        }


        //Problemas al devolver employee(Devuelve ID valor 0). solucionar.
        public ActionResult Update(int EmployeeID)
        {
            var EmployeeDto = _EmployeesServices.Find(EmployeeID);
            return View("Update", EmployeeDto);
        }

        
        [HttpPost]
        public ActionResult Update(EmployeeDTO employee)
        {
            
                

              _EmployeesServices.Update(employee);
                return View("Details", _EmployeesServices.GetAll());
            
        }




        //Listo
        public ActionResult Delete(int EmployeeID)
        {
            _EmployeesServices.Delete(new EmployeeDTO
            {
                EmployeeID = EmployeeID
            });
            return View("Details", _EmployeesServices.GetAll());
        }
    }
}
