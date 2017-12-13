using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class CountryDTO
    {
        List<EmployeeDTO> EmployeeList { get; set; }

        public string CountryName { get; set; }

    }
}
