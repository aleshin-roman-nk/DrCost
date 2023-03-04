using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrCost.Models
{
    public class AddedMoney
    {
        public int Id { get; set; }
        public decimal SumInRub { get; set; }
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
    }
}
