using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public partial class Employee

        
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        public int Shift { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        public string Country { get; set; }

        public DateTime? HireDate { get; set; }

        [Required]
        public decimal Salary { get; set; }
    }
}
