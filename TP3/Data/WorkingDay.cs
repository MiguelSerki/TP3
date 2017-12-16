using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class WorkingDay
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public DateTime Day { get; set; }

        [Required]
        public Employee Employee { get; set; }

        [Required]
        public DateTime? Entry { get; set; }

        [Required]
        public DateTime? Exit { get; set; }

        public decimal Hours { get; set; }
    }
}
