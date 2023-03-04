using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrCost.Models
{
    public class MonthlyBudgetProperty
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? value { get; set; }
        public int budgetId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        
    }
}
