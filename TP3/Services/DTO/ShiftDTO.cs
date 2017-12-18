using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class ShiftDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTimeKind Start { get; set; }

        public DateTimeKind Finish { get; set; }

        public List<EmployeeDTO> EmployeeList { get; set; }
    }
}
