using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services.DTO;
using Services;
using Web.Models;

namespace Web.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeesServices _EmployeesServices;
        private CalculateMonthServices _CalculateMonthServices;
        


        
           
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


        public ActionResult Salary()
        {
             
            return View(_EmployeesServices.GetAll());
          
        }

        [HttpPost]
        public ActionResult Salary(int employeeID)
        {
            ViewBag.Calculo = _CalculateMonthServices.CalculoSueldoMes(employeeID);
            return View();
        }

        







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
