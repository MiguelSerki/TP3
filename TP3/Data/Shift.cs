using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Shift
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTimeKind Start { get; set; }

        [Required]
        public DateTimeKind Finish { get; set; }

        [Required]
        public List<Employee> EmployeeList { get; set; }
    }
}