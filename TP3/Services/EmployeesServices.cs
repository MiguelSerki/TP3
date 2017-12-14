using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Services.DTO;

namespace Services
{
    class EmployeesServices
    {
        private Repository<Employee> _EmployeeRepository;

        public EmployeesServices()
        {
            _EmployeeRepository = new Repository<Employee>();
        }

        public IEnumerable<EmployeeDTO> GetAll()
            {
            return _EmployeeRepository.Set().ToList().Select(c => new EmployeeDTO
            {
                EmployeeID = c.EmployeeID,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Country = c.Country,
                Shift = c.Shift
            });
            }

        public void Create(EmployeeDTO dto)
        {
            _EmployeeRepository.Persist(new Employee
            {
                EmployeeID = dto.EmployeeID,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Shift = dto.Shift,
                Country = dto.Country,
                HireDate = dto.HireDate
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
            employee.Shift = dto.Shift;
            employee.HireDate = dto.HireDate;
            

            _EmployeeRepository.Update(employee);
            _EmployeeRepository.SaveChanges();

            


        }

        public void Delete(EmployeeDTO dto)

        {
            var employee = _EmployeeRepository.Set().FirstOrDefault(x => x.EmployeeID == dto.EmployeeID):

            if(employee==null)

            {
                throw new Exception("El empleado a eliminar no existe");

            }

            _EmployeeRepository.Remove(employee);
            _EmployeeRepository.SaveChanges();

        }

           
            
                
            
        
        



    }
}
