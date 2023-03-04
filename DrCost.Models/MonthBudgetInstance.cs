using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrCost.Models.Stuff;

namespace DrCost.Models
{
    public class MonthBudgetInstance
    {
        public int BudgetId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string? BudgetName { get; set; }
        public IEnumerable<StuffItem>? Items { get; set; }
        public decimal AllotedSum { get; set; }
        public bool HasCalendar { get; set; }
    }
}
