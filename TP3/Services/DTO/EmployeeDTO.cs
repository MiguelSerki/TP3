using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Services.DTO
{
    public class EmployeeDTO
    {
        public int EmployeeID { get; set; }

        public int ShiftID { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Country { get; set; }

        public DateTime? HireDate { get; set; }

        public decimal Salary { get; set; }
    }
}
