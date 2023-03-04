using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrCost.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string? DNA { get; set; }
        public string? Name { get; set; }
        public decimal DefaultMoney { get; set; }
        public bool IsActive { get; set; } = true;
        public bool HasCalendar { get; set; }
        [NotMapped]
        public decimal Costs { get; set; }
    }
}
