using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class WorkingDayDTO
    {
        public int ID { get; set; }

        public DateTime Day { get; set; }

        public EmployeeDTO Employee { get; set; }

        public DateTime? Entry { get; set; }

        public DateTime? Exit { get; set; }

        public decimal Hours { get; set; }
    }
}
