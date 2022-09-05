using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrCost.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal AllowedSum { get; set; }
        public decimal Costs { get; set; }
    }
}
