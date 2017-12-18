using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Services.DTO;

namespace Services
{
   public class EmployeesServices

    {
        private Repository<Employee> _EmployeeRepository;

        public EmployeesServices()
        {
            _EmployeeRepository = new Repository<Employee>();
        }

        public List<EmployeeDTO> GetAll()
            {

            var list = new List<EmployeeDTO>();

            foreach (var c in _EmployeeRepository.Set())
            {
                list.Add(new EmployeeDTO
                {
                    EmployeeID = c.EmployeeID,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Country = c.Country,
                    Salary = c.Salary,
                    ShiftID = c.Shift,
                    HireDate = c.HireDate
                });
                
            }
            return list;
            }

        public EmployeeDTO Find(int employeeID)
        {
            var aux = _EmployeeRepository.Set().Select(c => new EmployeeDTO

            {
                EmployeeID = c.EmployeeID,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Country = c.Country,
                ShiftID = c.Shift,
                Salary = c.Salary


            }).FirstOrDefault(x => x.EmployeeID == employeeID);

            return aux;
            
            
        }

        public void Create(EmployeeDTO dto)
        {
            _EmployeeRepository.Persist(new Employee
            {
                EmployeeID = dto.EmployeeID,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Shift = dto.ShiftID,
                Country = dto.Country,
                HireDate = dto.HireDate,
                Salary = dto.Salary
            });

            _EmployeeRepository.SaveChanges();
        }

        public void Update(EmployeeDTO dto)
        {

            var employee = _EmployeeRepository.Set().FirstOrDefault(x => x.EmployeeID == dto.EmployeeID);
            
            if(employee == null)
            {
                throw new Exception("El empleado a actualizar no existe");


            }

            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.Country = dto.Country;
            employee.Shift = dto.ShiftID;
            employee.HireDate = dto.HireDate;
            employee.Salary = dto.Salary;
            
            _EmployeeRepository.Update(employee);
            _EmployeeRepository.SaveChanges();

            


        }

        public void Delete(EmployeeDTO dto)

        {
            var employee = _EmployeeRepository.Set().FirstOrDefault(x => x.EmployeeID == dto.EmployeeID);

            if(employee==null)

            {
                throw new Exception("El empleado a eliminar no existe");

            }

            _EmployeeRepository.Remove(employee);
            _EmployeeRepository.SaveChanges();

        }

        public List<EmployeeDTO> GetAllFromShift(int id)
        {

           var list =  this._EmployeeRepository.Set().Where(c => c.Shift == id).ToList();
            var listDTO = new List<EmployeeDTO>();
            try
            {
                foreach (var item in list)
                {
                    listDTO.Add(new EmployeeDTO
                    {
                        EmployeeID = item.EmployeeID,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Country = item.Country,
                        ShiftID = item.Shift,
                        Salary = item.Salary
                    });
                }
                return listDTO;
            }
            catch (Exception)
            {
                return null;
            }
           
        }
           
    }
}
