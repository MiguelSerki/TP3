using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Services.DTO;

namespace Services
{
<<<<<<< HEAD
   public class EmployeesServices
=======
    public class EmployeesServices
>>>>>>> 4a577045b4508245c184983a09f489026d6daa84
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
<<<<<<< HEAD
                Shift = c.Shift,
                ValorHora = c.ValorHora
                
=======
                ShiftID = c.Shift
>>>>>>> 4a577045b4508245c184983a09f489026d6daa84
            });
            }

        public EmployeeDTO Find(int employeeID)
        {
            var aux = _EmployeeRepository.Set().Select(c => new EmployeeDTO

            {
                EmployeeID = c.EmployeeID,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Country = c.Country,
                Shift = c.Shift,
                ValorHora = c.ValorHora


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
                ValorHora = dto.ValorHora
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
            employee.ValorHora = dto.ValorHora;
            

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
                        ShiftID = item.Shift
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
