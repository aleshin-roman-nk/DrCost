using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrCost.Models.Stuff
{
    public class StuffType
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int KindOfId { get; set; }
        public int BudgetId { get; set; }
        public int CategoryId { get; set; }
    }
}
