using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Services.DTO;

namespace Services
{
    public class ShiftServices
    {
        private Repository<Shift> ShiftRepo = new Repository<Shift>();

        //Busca el Set de Shifts y los mapea a una Lista de ShiftDTO
        public List<ShiftDTO> GetShifts()
        {

            var listDTO = new List<ShiftDTO>();
            var list = this.ShiftRepo.Set();
            foreach (var item in list)
            {
                listDTO.Add(new ShiftDTO
                {
                    Id = item.Id,
                    Start = item.Start,
                    Finish = item.Finish,
                    EmployeeList = this.GetEmployeeDTOFromShiftList(item.EmployeeList)
                });
            }

            return listDTO;
        }

        //Toma una lista de empleados y los mapea a una lista de EmployeeDTO
        public List<EmployeeDTO> GetEmployeeDTOFromShiftList(List<Employee> list)
        {
            var employeeDTOList = new List<EmployeeDTO>();
            foreach (var employee in list)
            {
                employeeDTOList.Add(new EmployeeDTO
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    EmployeeID = employee.EmployeeID,
                    Country = employee.Country,
                    HireDate = employee.HireDate,
                    ShiftID = employee.Shift.Id
                });
            }

            return employeeDTOList;
        }
    }
}
