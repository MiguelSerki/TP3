using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DTO;

namespace Services
{
    public class CalculateMonthServices
    {
        public Repository<EmployeeDTO> _EmployeeRepository;
        

        public List<WorkingDayDTO> GetList(int employeeID)
        {
            
            var list = new List<WorkingDayDTO>();
            foreach (var c in _DayRepository.Set())
            {
                if (c.Employee.EmployeeID == employeeID)
                {
                    list.Add(new WorkingDayDTO
                    {
                        Day = c.Day,
                        
                       
                        
                        
                        Hours = c.Hours
                       

                    });
                }



            }
            return list;
        }



        //Constructor
        private Repository<WorkingDay> _DayRepository;

        public CalculateMonthServices()
        {
            _DayRepository = new Repository<WorkingDay>();
        }

        public decimal CalculoSueldoMes(int employeeID)
        {
            decimal calcParc2 = 0;
            var aux = _EmployeeRepository.Set().Select(c => new EmployeeDTO

            {
               
                Salary = c.Salary


            }).FirstOrDefault(x => x.EmployeeID == employeeID);

            var list = GetList(employeeID);
            foreach(var c in list)
            {
                var calcParc = c.Hours * aux.Salary;
                calcParc2 = calcParc2 + calcParc;
            }

            return calcParc2;

           
                
         }













        }
            

            


    }

