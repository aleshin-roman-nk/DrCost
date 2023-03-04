using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrCost.Models.Stuff
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int BudgetId { get; set; }
        public int ParentId { get; set; }
        public IEnumerable<StuffType>? StuffTypes { get; set; }
    }
}
