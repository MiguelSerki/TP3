using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Data;
using Services.DTO;
using Services;

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
                    Name = item.Name,
                    Start = item.Start,
                    Finish = item.Finish,
                    EmployeeList = this.GetEmployeeDTOFromShiftList(item.EmployeeList)
                });
            }

            return listDTO;
        }

        public ShiftDTO Create()
        {
            return new ShiftDTO();
        }

        public ShiftDTO GetShiftByName(string name)
        {
            var shift = this.ShiftRepo.Set().Select(c=> c.Name == name).FirstOrDefault;

        }

        //Toma una lista de empleados y los mapea a una lista de EmployeeDTO
        public List<EmployeeDTO> GetEmployeeDTOFromShiftList(List<Employee> list)
        {
            var employeeDTOList = new List<EmployeeDTO>();
            try
            {
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
            }
            catch (Exception)
            {
                Console.WriteLine("La lista de Empleados esta vacia.");
            }
            return employeeDTOList;
        }
    }
}
