using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Country
    {

        public Country()
        {
            this.EmployeeList = new List<Employee>();
        }

        List<Employee> EmployeeList { get; set; }

        [Key]
        [Required]
        public string CountryName { get; set; }
    }
}
