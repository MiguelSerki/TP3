using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class WorkingMonthDTO
    {
        public int ID { get; set; }

        public int Month { get; set; }

        public List<WorkingDayDTO> List { get; set; }
    }
}
