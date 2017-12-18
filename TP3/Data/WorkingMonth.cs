using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class WorkingMonth
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int Month { get; set; }

        [Required]
        public List<WorkingDay>List { get; set; }
    }
}
